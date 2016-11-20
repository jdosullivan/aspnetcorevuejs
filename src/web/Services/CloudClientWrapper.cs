using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;

namespace GroupClue.Services
{
    public class CloudClientWrapper : ICloudClientWrapper
    {
        public CloudClientWrapper(CloudStorageAccount storageAccount)
        {
            StorageAccount = storageAccount;
        }

        public CloudStorageAccount StorageAccount { get; private set; }

        private CloudTableClient tableClient;
        public CloudTableClient TableClient
        {
            get { return tableClient ?? (tableClient = StorageAccount.CreateCloudTableClient()); }
        }

        private CloudBlobClient blobClient;
        public CloudBlobClient BlobClient
        {
            get { return blobClient ?? (blobClient = StorageAccount.CreateCloudBlobClient()); }
        }


        private CloudQueueClient queueClient;
        public CloudQueueClient QueueClient
        {
            get { return queueClient ?? (queueClient = StorageAccount.CreateCloudQueueClient()); }
        }

    }
}
