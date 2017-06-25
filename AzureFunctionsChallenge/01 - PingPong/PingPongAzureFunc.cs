using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureFunctionsChallenge.PingPong
{
    public static class PingPongAzureFunc
    {
        [FunctionName("PingPong")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequestMessage req,
            TraceWriter log)
        {
            log.Info($"PingPong was triggered!");

            string jsonContent = await req.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<PingPongInputModel>(jsonContent);

            if (string.IsNullOrWhiteSpace(data.Ping))
            {
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }

            return req.CreateResponse(HttpStatusCode.OK, new
            {
                pong = data.Ping
            });
        }
    }
}