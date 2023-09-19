using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.Dashboard.Models
{
    public class AllCount
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("DAILY_ENQUIRY")]
        public int DAILY_ENQUIRY { get; set; }
        [JsonProperty("REGISTERED_MEMBER")]
        public int REGISTERED_MEMBER { get; set; }
        [JsonProperty("TODAYS_BIRTHDAY")]
        public int TODAYS_BIRTHDAY { get; set; }
        [JsonProperty("TODAY_FEES_COLLECTION")]
        public int TODAY_FEES_COLLECTION { get; set; }
        [JsonProperty("PRESENT_MEMBER")]
        public int PRESENT_MEMBER { get; set; }
        [JsonProperty("TODAY_REGISTERED_MEMBER")]
        public int TODAY_REGISTERED_MEMBER { get; set; }
        [JsonProperty("TOTAL_BATCHES")]
        public int TOTAL_BATCHES { get; set; }
        [JsonProperty("TOTAL_TRAINERS")]
        public int TOTAL_TRAINERS { get; set; }
        [JsonProperty("TOTAL_PACKAGE")]
        public int TOTAL_PACKAGE { get; set; }
        [JsonProperty("FEES_UNPAID")]
        public int FEES_UNPAID { get; set; }
    }
}
