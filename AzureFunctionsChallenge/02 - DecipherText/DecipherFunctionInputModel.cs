using Newtonsoft.Json;
using System.Collections.Generic;

namespace AzureFunctionsChallenge.DecipherText
{
    public class DecipherFunctionInputModel
    {
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "msg")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "cipher")]
        public Dictionary<string, string> Cipher { get; set; }
    }
}