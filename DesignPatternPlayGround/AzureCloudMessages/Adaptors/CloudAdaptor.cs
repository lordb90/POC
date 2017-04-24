using AzureCloudMessages.Interfaces;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCloudMessages.Adaptors
{
    public class CloudAdaptor : IQueueMessages
    {
        public CloudQueueMessage cloudMessage { get; private set; }

        public CloudAdaptor(byte[] content)
        {

            cloudMessage = new CloudQueueMessage(content);
        
        }
        public CloudAdaptor(string content)
        {

            cloudMessage = new CloudQueueMessage(content);
        
        }
        public CloudAdaptor(string messageId, string popReceipt)
        {

            cloudMessage = new CloudQueueMessage(messageId, popReceipt);
        
        }

        public T CreateQueueMessage<T>()
        {
            throw new NotImplementedException();
        }
    }
}
