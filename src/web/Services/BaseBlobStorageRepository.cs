using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace GroupClue.Services
{
    public abstract class BaseBlobStorageRepository
    {
        protected readonly ICloudClientWrapper cloudClientWrapper;

        protected BaseBlobStorageRepository(ICloudClientWrapper cloudClientWrapper)
        {
            this.cloudClientWrapper = cloudClientWrapper;
        }


        public CloudBlockBlob Get(string fileName, string containerName)
        {
            var container = GetContainer(containerName).Result;
            return container.GetBlockBlobReference(fileName);
        }

        public IEnumerable<IListBlobItem> FindAll(CloudBlobContainer container)
        {
            return container.ListBlobsSegmentedAsync(new BlobContinuationToken()).Result.Results;
        }

        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            var container = cloudClientWrapper.BlobClient.GetContainerReference(containerName.ToLower());
            await container.CreateIfNotExistsAsync();
            await container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            return container;
        }

    }
}
