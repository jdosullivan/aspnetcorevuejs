using Structure.Sketching;
using Structure.Sketching.Formats;
using System.IO;
using System.Threading.Tasks;

namespace GroupClue.Services
{
    public interface IImageService
    {
        Task<string> UploadImage(MemoryStream fileStream, string fileName, string imageContainer);
        
        Task<Image> GetImage(string fileName);
                
        void Delete(string imageName);
        
        Stream GenerateThumbnail(Stream image, int width = 128, int height = 128);
    }
}