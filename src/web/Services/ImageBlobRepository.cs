using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Structure.Sketching;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GroupClue.Services
{
    public class ImageBlobRepository : BaseBlobStorageRepository, IImageRepository
    {
        protected const string DefaultImageContainer = "Images";
        
        public ImageBlobRepository(ICloudClientWrapper cloudClientWrapper) : base(cloudClientWrapper)
        {
        }

        public async Task<string> UploadImage(MemoryStream fileStream, string filename, string containerName = "Images")
        {
            if (string.IsNullOrEmpty(containerName))
                containerName = DefaultImageContainer;  
                      
            using (fileStream)
            {
                var blockBlob = await GetImageBlob(filename, containerName);
                // blockBlob.Properties.ContentType = "image\\png";

                await blockBlob.UploadFromStreamAsync(fileStream);
                return blockBlob.SnapshotQualifiedUri.AbsoluteUri;
            }
        }

        public async Task<string> UploadImage(string filePath, long fileSize, string containerName = null)
        {
            if (string.IsNullOrEmpty(containerName)) containerName = DefaultImageContainer;
            var filename = Path.GetFileName(filePath);
            var blockBlob = await GetImageBlob(filename, containerName);
            blockBlob.Properties.ContentType = "image\\jpeg";

            using (var fileStream = File.OpenRead(filePath))
            {
                fileSize = fileStream.Length;
                await blockBlob.UploadFromStreamAsync(fileStream);
                return blockBlob.SnapshotQualifiedUri.AbsoluteUri;
            }
        }

        public async Task<string> UploadImageStream(MemoryStream fileStream, string filename, string containerName = null)
        {
            if (string.IsNullOrEmpty(containerName)) containerName = DefaultImageContainer;
            ArraySegment<byte> imageBytes;

            if (fileStream.TryGetBuffer(out imageBytes))
            {
                using (var imageStream = new MemoryStream(imageBytes.Array))
                {
                    var blockBlob = await GetImageBlob(filename, containerName);
                    blockBlob.Properties.ContentType = "image\\jpeg";

                    await blockBlob.UploadFromStreamAsync(imageStream);
                    return blockBlob.SnapshotQualifiedUri.AbsoluteUri;
                }
            }

            return null;
        }


        public async Task<ICloudBlob> GetImageBlob(string fileName, string containerName = DefaultImageContainer)
        {
            var container = await GetContainer(containerName);
            return container.GetBlockBlobReference(fileName);
        }

        public async void DownloadImage(string fileName, string outputFilePath)
        {
            var blockBlob = await GetImageBlob(fileName);
            blockBlob.Properties.ContentType = "image\\jpeg";

            // Save blob contents to a file.
            using (var fileStream = File.OpenWrite(outputFilePath))
            {
                await blockBlob.DownloadToStreamAsync(fileStream);
            }
        }

        public async void DeleteImage(string fileName, string container)
        {
            try
            {
                if (string.IsNullOrEmpty(container)) container = DefaultImageContainer;
                var image = await GetImageBlob(fileName, container);
                // Delete the blob.
                await image.DeleteAsync();
            }
            catch (StorageException ex)
            {
                if (ex.Message != "The remote server returned an error: (404) Not Found.")
                    throw;
            }
        }

        public async Task<Image> GetImage(string fileName)
        {
            var blockBlob = await GetImageBlob(fileName);
            blockBlob.Properties.ContentType = "image\\jpeg";

            Image image;
            using (var memoryStream = new MemoryStream())
            {
                await blockBlob.DownloadToStreamAsync(memoryStream);
                image = new Image(memoryStream);
            }

            return image;
        }

        /// <summary>
        /// Upload file in azure storage
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public async Task<string> UploadFileAsBlob(Stream stream, string filename)
        {           
            // Create the blob client.
            CloudBlobClient blobClient = cloudClientWrapper.BlobClient;

            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference("profileimages");
            await container.CreateIfNotExistsAsync();

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(filename);

            AddMimeType(filename, ref blockBlob);

            await blockBlob.UploadFromStreamAsync(stream);

            stream.Dispose();
            return blockBlob?.Uri.ToString();
        }
        

        private void AddMimeType(string fileName, ref CloudBlockBlob cloudBlob)
        {
            var extension = Path.GetExtension(fileName);
            string contentType;
            _contentTypes.TryGetValue(extension, out contentType);
            if (!string.IsNullOrEmpty(contentType))
            {
                cloudBlob.Properties.ContentType = contentType;
            }
        }

        private readonly Dictionary<string, string> _contentTypes = new Dictionary<string, string>
        {
            {".jpeg", "image/jpeg"},
            {".jpg", "image/jpeg" },
            {".png", "image/png"}
        };

    }
}
