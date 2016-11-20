using System.IO;
using Microsoft.WindowsAzure.Storage.Blob;
using Structure.Sketching;
using System.Threading.Tasks;

namespace GroupClue.Services
{
    public interface IImageRepository
    {
        Task<string> UploadImage(string filePath, long fileSize, string container);
        Task<string> UploadImage(MemoryStream fileStream, string filename, string containerName);
        Task<ICloudBlob> GetImageBlob(string fileName, string containerName = "Images");

        void DownloadImage(string fileName, string outputFilePath);
        void DeleteImage(string fileName, string container);
        Task<Image> GetImage(string fileName);
        Task<string> UploadImageStream(MemoryStream fileStream, string filename, string container = "Images");

        Task<string> UploadFileAsBlob(Stream stream, string filename);
    }
}