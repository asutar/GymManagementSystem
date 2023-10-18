using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class BATCH
    {
        [JsonProperty("BATCH_ID")]
        public int BATCH_ID { get; set; }
        [JsonProperty("NAME")]
        public string NAME { get; set; }
        [JsonProperty("DESCRIPTION")]
        public string DESCRIPTION { get; set; }
        [JsonProperty("ADDED_BY")]
        public int ADDED_BY { get; set; }
        [JsonProperty("OPERATION_STATUS")]
        public string OPERATION_STATUS { get; set; }
        [JsonProperty("FROM_DATE")]
        public string FROM_DATE { get; set; }
        [JsonProperty("TO_DATE")]
        public string TO_DATE { get; set; }
        [JsonProperty("AMOUNT")]
        public decimal AMOUNT { get; set; }
        [JsonProperty("TAX_ID")]
        public int TAX_ID { get; set; }
        [JsonProperty("GST_AMOUNT")]
        public decimal GST_AMOUNT { get; set; }
        [JsonProperty("TOTAL_AMOUNT")]
        public decimal TOTAL_AMOUNT { get; set; }
        [JsonProperty("TAX_NAME")]
        public string TAX_NAME { get; set; }
        [JsonProperty("NO_OF_DAYS")]
        public int NO_OF_DAYS { get; set; }
        [JsonProperty("UPDATED_BY")]
        public int UPDATED_BY { get; set; }
    }
    public class BATCHPagingation
    {
        public List<BATCH> BatchList { get; set; }
        public int filteredCount { get; set; }
    }
    public class BATCHResponse
    {
        public BATCHPagingation Data { get; set; }
    }
}
