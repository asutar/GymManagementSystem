using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class BatchScheduledDateTime
    {
        [JsonProperty("BATCH_TIMING_ID")]
        public int BATCH_TIMING_ID { get; set; }
        [JsonProperty("BATCH_NAME")]
        public string BATCH_NAME { get; set; }
        [JsonProperty("BATCH_DATETIME")]
        public string BATCH_DATETIME { get; set; }
        [JsonProperty("BATCH_ID")]
        public int BATCH_ID { get; set; }
    }
}
