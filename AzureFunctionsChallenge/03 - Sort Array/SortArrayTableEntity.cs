using Microsoft.WindowsAzure.Storage.Table;

namespace AzureFunctionsChallenge.SortArray
{
    public class SortArrayTableEntity : TableEntity
    {
        public string Values { get; set; }
    }
}