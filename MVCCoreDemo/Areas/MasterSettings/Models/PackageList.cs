using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class PackageList
    {
        [JsonProperty("PACKAGE_ID")]
        public int PACKAGE_ID { get; set; }
        [JsonProperty("TITLE")]
        public string TITLE { get; set; }
    }
}
