using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureFunctionsChallenge.SortArray
{
    public static class RetrieveArrayAzureFunc
    {
        const string PartitionKey = "SubmitArrayPartitionKey";

        [FunctionName("RetrieveArray")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequestMessage req,
            IBinder binder,
            TraceWriter log)
        {
            log.Info("RetrieveArray was triggered!");

            string jsonContent = await req.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<RetrieveArrayInputModel>(jsonContent);

            if (string.IsNullOrWhiteSpace(data.Key))
            {
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }

            var valueString = await binder.BindAsync<SortArrayTableEntity>(
                new TableAttribute("SortArrayAzureFuncTable", PartitionKey, data.Key));

            if (valueString == null)
            {
                return req.CreateResponse(HttpStatusCode.NotFound);
            }

            var resultArray = JsonConvert.DeserializeObject<int[]>(valueString.Values);
            Array.Sort(resultArray);

            return req.CreateResponse(HttpStatusCode.OK, new
            {
                key = data.Key,
                ArrayOfValues = resultArray
            });
        }
    }
}