using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class Tax
    {
        [JsonProperty("TAX_ID")]
        public int TAX_ID { get; set; }
        [JsonProperty("TAX_NAME")]
        public string TAX_NAME { get; set; }
        [JsonProperty("DEDUCATION_PERCENT")]
        public decimal DEDUCATION_PERCENT { get; set; }
    }
}
