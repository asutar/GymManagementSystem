using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class Gender
    {
        [JsonProperty("SEX_ID")]
        public int SEX_ID { get; set; }
        [JsonProperty("SEX")]
        public string SEX { get; set; }
    }
}
