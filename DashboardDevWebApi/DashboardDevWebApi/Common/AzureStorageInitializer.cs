using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DashboardDevWebApi.Common
{
    public class AzureStorageInitializer
    {
        private readonly CloudBlobClient blobClient;
        private readonly CloudQueue dashRequestQueue;
        private readonly CloudBlobContainer imagesBlobContainer;
        private readonly CloudQueueClient queueClient;
        private readonly CloudStorageAccount storageAccount;

        public CloudBlobClient BlobClient
        {
            get
            {
                return blobClient;
            }
        }

        public CloudQueue DashRequestQueue
        {
            get
            {
                return dashRequestQueue;
            }
        }

        public CloudBlobContainer ImagesBlobContainer
        {
            get
            {
                return imagesBlobContainer;
            }
        }

        public CloudQueueClient QueueClient
        {
            get
            {
                return queueClient;
            }
        }

        public CloudStorageAccount StorageAccount
        {
            get
            {
                return storageAccount;
            }
        }

        public AzureStorageInitializer()
        {
            // Open storage account using credentials from .cscfg file.
            storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureWebStorage"].ToString());

            // Get context object for working with blobs, and 
            // set a default retry policy appropriate for a web user interface.
            blobClient = storageAccount.CreateCloudBlobClient();
            //blobClient.DefaultRequestOptions.RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(3), 3);

            // Get a reference to the blob container.
            imagesBlobContainer = blobClient.GetContainerReference("dashblob");

            // Get context object for working with queues, and 
            // set a default retry policy appropriate for a web user interface.
            queueClient = storageAccount.CreateCloudQueueClient();
            //queueClient.DefaultRequestOptions.RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(3), 3);

            // Get a reference to the queue.
            dashRequestQueue = queueClient.GetQueueReference("dashqueue");
        }

    }
}