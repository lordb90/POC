using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Blob;
using Swashbuckle.Swagger;
using DashboardDevWebApi.Common;
using Microsoft.WindowsAzure.Storage.Queue;

namespace DashboardDevWebApi.Controllers
{
    public class DashboardController : ApiController
    {
        AzureStorageInitializer storage;

        public DashboardController()
        {
            storage = new AzureStorageInitializer();
        }
        // POST api/values
        [SwaggerOperation("CreatePdf")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public async Task<Response> CreatePdf(string ccn, string reportingQId)
        {
            return await PublishMessage(ccn, reportingQId, "CreatePdf");
        }

        private async Task<Response> PublishMessage(string ccn, string reportingQId, string action)
        {
            //CloudBlockBlob dashBlob = null;
            QueueMessage queueInfo = new QueueMessage() { CCN = ccn, ReportingQId = reportingQId, ActionType = action};
            var queueMessage = new CloudQueueMessage(JsonConvert.SerializeObject(queueInfo));
            await storage.DashRequestQueue.AddMessageAsync(queueMessage);
            return new Response();
        }

        // DELETE api/values/5
        [SwaggerOperation("DeletePdf")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public async Task<Response> Delete(string ccn, string reportingQId)
        {
            return await PublishMessage(ccn, reportingQId, "DeletePdf");
        }
    }
}
