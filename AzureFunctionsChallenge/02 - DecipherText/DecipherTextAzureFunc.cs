using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureFunctionsChallenge.DecipherText
{
    public static class DecipherTextAzureFunc
    {
        [FunctionName("DecipherText")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequestMessage req,
            TraceWriter log)
        {
            log.Info($"DecipherText was triggered!");

            string jsonContent = await req.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<DecipherFunctionInputModel>(jsonContent);

            if (string.IsNullOrWhiteSpace(data.Key) ||
                string.IsNullOrWhiteSpace(data.Message) ||
                data.Cipher == null || data.Cipher.Count == 0)
            {
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }

            var decipherer = new Decipherer(data.Cipher);
            return req.CreateResponse(HttpStatusCode.OK, new
            {
                key = data.Key,
                result = decipherer.Decipher(data.Message)
            });
        }
    }
}