using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GroupClue.Data;
using GroupClue.Services;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using GroupClue.Web.Api.Attributes;
using System.Threading.Tasks;
using Structure.Sketching.Formats;
using System.Text.Encodings.Web;
using System.Net;
using GroupClue.Web.ViewModels;
using Structure.Sketching;

namespace GroupClue.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly IImageService imageService;
        private readonly IImageRepository _imageRepo;
        private ApplicationDbContext _context;

        public FileController(ApplicationDbContext context, IImageService imageService, IImageRepository imageRepo)
        {
            this.imageService = imageService;
            _context = context;
            _imageRepo = imageRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file, int? minWidth, int? minHeight, bool prependDate = false)
        {
            UploadedFileViewModel result = null;

            if (file != null && file.Length > 0 && file.FileName != null)
            {
                //using (var imageStreamForDimensions = file.OpenReadStream())
                //{
                //    var image = new Image(imageStreamForDimensions);

                //    if ((minWidth != null && image.Width < minWidth) || (minHeight != null && image.Height < minHeight))
                //    {
                //        return new BadRequestResult();
                //    }
                //}

                string fileName = file.FileName;
               // string thumbFileName = "thumbnail_" + file.FileName;
                if (prependDate)
                {
                    fileName = DateTime.UtcNow.ToString("yyyyMMdd_hh_mm_ss_") + fileName;
                  //  thumbFileName = DateTime.UtcNow.ToString("yyyyMMdd_hh_mm_ss_") + "thumbnail_" + fileName;
                }

               
                string uploadedFile;
                using (var imageStream = file.OpenReadStream())
                {
                    uploadedFile = await _imageRepo.UploadFileAsBlob(imageStream, fileName);
                }

                //string uploadedThumbnail;
                //using (var thumbStream = file.OpenReadStream())
                //{
                //    var thumbNailImage = imageService.GenerateThumbnail(thumbStream);
                //    uploadedThumbnail = await _imageRepo.UploadFileAsBlob(thumbNailImage, thumbFileName);
                //}

                result = new UploadedFileViewModel
                {
                    FilePath = uploadedFile,
                    // ThumbnailPath = uploadedThumbnail
                };
            }
            return Ok(result);
        }

        
    }
}