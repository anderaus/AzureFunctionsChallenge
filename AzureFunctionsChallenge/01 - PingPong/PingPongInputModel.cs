using Newtonsoft.Json;

namespace AzureFunctionsChallenge.PingPong
{
    public class PingPongInputModel
    {
        [JsonProperty(PropertyName = "ping")]
        public string Ping { get; set; }
    }
}