using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class Project
    {
        [JsonProperty("PROJECT_ID")]
        public int PROJECT_ID { get; set; }
        [JsonProperty("NAME")]
        public string NAME { get; set; }
        [JsonProperty("DESCRIPTION")]
        public string DESCRIPTION { get; set; }
        [JsonProperty("ADDED_DATETIME")]
        public string ADDED_DATETIME { get; set; }
        [JsonProperty("IS_ACTIVE")]
        public  bool IS_ACTIVE { get; set; }
        [JsonProperty("IS_DELETED")]
        public bool IS_DELETED { get; set; }
    }
}
