using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Models
{
    public class ReturnResponse
    {
        [JsonProperty("RESPONSEMESSAGE")]
        public string RESPONSEMESSAGE { get; set; }
        [JsonProperty("RESPONSETYPE")]
        public string RESPONSETYPE { get; set; }
    }
}
