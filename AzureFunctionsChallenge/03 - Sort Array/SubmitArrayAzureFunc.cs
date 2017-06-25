using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureFunctionsChallenge.SortArray
{
    public static class SubmitArrayAzureFunc
    {
        const string PartitionKey = "SubmitArrayPartitionKey";

        [FunctionName("SubmitArray")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequestMessage req,
            IBinder binder,
            TraceWriter log)
        {
            log.Info("SubmitArray was triggered!");

            string jsonContent = await req.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<SortArrayInputModel>(jsonContent);

            if (string.IsNullOrWhiteSpace(data.Key) ||
                data.ArrayOfValues == null || data.ArrayOfValues.Length == 0)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }

            var collector = await binder.BindAsync<IAsyncCollector<SortArrayTableEntity>>(
                new TableAttribute("SortArrayAzureFuncTable"));

            await collector.AddAsync(new SortArrayTableEntity
            {
                RowKey = data.Key,
                PartitionKey = PartitionKey,
                Values = JsonConvert.SerializeObject(data.ArrayOfValues)
            });

            return req.CreateResponse(HttpStatusCode.OK, new { });
        }
    }
}