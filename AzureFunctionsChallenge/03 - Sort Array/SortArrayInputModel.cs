using Newtonsoft.Json;

namespace AzureFunctionsChallenge.SortArray
{
    public class SortArrayInputModel
    {
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        public int[] ArrayOfValues { get; set; }
    }
}