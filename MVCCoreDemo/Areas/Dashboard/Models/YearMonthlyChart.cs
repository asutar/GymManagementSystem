using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.Dashboard.Models
{
    public class YearMonthlyChart
    {
        [JsonProperty("Year")]
        public string Year { get; set; }
        [JsonProperty("January")]
        public string January { get; set; }
        [JsonProperty("February")]
        public string February { get; set; }
        [JsonProperty("March")]
        public string March { get; set; }
        [JsonProperty("April")]
        public string April { get; set; }
        [JsonProperty("May")]
        public string May { get; set; }
        [JsonProperty("June")]
        public string June { get; set; }
        [JsonProperty("July")]
        public string July { get; set; }
        [JsonProperty("August")]
        public string August { get; set; }
        [JsonProperty("September")]
        public string September { get; set; }
        [JsonProperty("October")]
        public string October { get; set; }
        [JsonProperty("November")]
        public string November { get; set; }
        [JsonProperty("December")]
        public string December { get; set; }
        [JsonProperty("USER_ID")]
        public int USER_ID { get; set; }
    }
}
