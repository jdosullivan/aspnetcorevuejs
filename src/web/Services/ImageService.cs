using System.IO;
using Structure.Sketching;
using System.Threading.Tasks;
using Structure.Sketching.Filters.Resampling;
using Structure.Sketching.Filters.Resampling.Enums;
using Structure.Sketching.Formats;
using GroupClue.Data;

namespace GroupClue.Services
{
    public class ImageService : IImageService
    {
        protected readonly IImageRepository _imageRepository;
        public const int ThumbnailWidthHeightInPx = 250;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public virtual async Task<string> UploadImage(MemoryStream fileStream, string fileName, string imageContainer)
        {
            return await _imageRepository.UploadImage(fileStream, fileName, imageContainer);
        }

        public void Delete(string name)
        {        
            _imageRepository.DeleteImage(name, "imageContainer name");
        }

        public virtual Stream Convert(Image image, FileFormats format)
        {
            var imageStream = new MemoryStream();
            new Manager().Encode(imageStream, image, format);
            
            return new MemoryStream(imageStream.ToArray());
        }

        public virtual Image ResizeImage(Stream imageStream, int width = ThumbnailWidthHeightInPx, int height = ThumbnailWidthHeightInPx)
        {
            var image = new Image(imageStream);
            new Resize(width, height, ResamplingFiltersAvailable.NearestNeighbor).Apply(image);

            return image;
        }

        public async Task<Image> GetImage(string fileName)
        {
            var blockBlob = await _imageRepository.GetImageBlob(fileName);
            blockBlob.Properties.ContentType = "image\\jpeg";

            Image image;
            using (var memoryStream = new MemoryStream())
            {
                await blockBlob.DownloadToStreamAsync(memoryStream);
                image = new Image(memoryStream);
            }

            return image;
        }

        public Stream GenerateThumbnail(Stream image, int width = 128, int height = 128)
        {
            var thumbnail = ResizeImage(image, width, height);
            return Convert(thumbnail, ModelExtensions.ParseEnum<FileFormats>("JPEG"));
        }
    }
}
