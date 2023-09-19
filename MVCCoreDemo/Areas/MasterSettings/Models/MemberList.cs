using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class MemberList
    {
        [JsonProperty("MEMBERID")]
        public int MEMBERID { get; set; }
        [JsonProperty("NAME")]
        public string NAME { get; set; }
    }
}
