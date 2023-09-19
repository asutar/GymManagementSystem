using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class Specialisation
    {
        [JsonProperty("SPECIALIZATION_ID")]
        public int SPECIALIZATION_ID { get; set; }
        [JsonProperty("NAME")]
        public string NAME { get; set; }
    }
}
