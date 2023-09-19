using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class BatchTiming
    {
        [JsonProperty("BATCH_TIMING_ID")]
        public int BATCH_TIMING_ID { get; set; }
        [JsonProperty("BATCH_ID")]
        public int BATCH_ID { get; set; }
        [JsonProperty("BATCH_NAME")]
        public string BATCH_NAME { get; set; }
        [JsonProperty("TRAINER_ID")]
        public int TRAINER_ID { get; set; }
        [JsonProperty("TRAINER_NAME")]
        public string TRAINER_NAME { get; set; }
        [JsonProperty("FROM_DATE")]
        public string FROM_DATE { get; set; }
        [JsonProperty("TO_DATE")]
        public string TO_DATE { get; set; }
        [JsonProperty("FROM_TIME")]
        public string FROM_TIME { get; set; }
        [JsonProperty("TO_TIME")]
        public string TO_TIME { get; set; }
        [JsonProperty("ADDED_BY")]
        public int ADDED_BY { get; set; }
        [JsonProperty("OPERATION_STATUS")]
        public string OPERATION_STATUS { get; set; }
        [JsonProperty("_NO_OF_BATCH_COUNT")]
        public int _NO_OF_BATCH_COUNT { get; set; }
    }
    public class BatchTimingPagingation
    {
        public List<BatchTiming> BatchTimingList { get; set; }
        public int filteredCount { get; set; }
    }
    public class BatchTimingResponse
    {
        public BatchTimingPagingation Data { get; set; }
    }
}
