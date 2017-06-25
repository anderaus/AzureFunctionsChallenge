using Newtonsoft.Json;

namespace AzureFunctionsChallenge.SortArray
{
    public class RetrieveArrayInputModel
    {
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
    }
}