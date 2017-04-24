using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCloudMessages.Interfaces
{
    public interface IQueueMessages
    {
       T CreateQueueMessage<T>();
    }
}
