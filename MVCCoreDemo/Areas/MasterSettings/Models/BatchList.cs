using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class BatchList
    {
        [JsonProperty("BATCH_ID")]
        public int BATCH_ID { get; set; }
        [JsonProperty("NAME")]
        public string NAME { get; set; }
    }
}
