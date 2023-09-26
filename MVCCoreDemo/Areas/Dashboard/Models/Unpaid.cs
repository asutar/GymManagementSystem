using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.Dashboard.Models
{
    public class Unpaid
    {
        [JsonProperty("MEMBER_ID")]
        public int MEMBER_ID { get; set; }
        [JsonProperty("BATCH_ID")]
        public int BATCH_ID { get; set; }
        [JsonProperty("NEXT_FEES_DATETIME")]
        public string NEXT_FEES_DATETIME { get; set; }
        [JsonProperty("NAME")]
        public string NAME { get; set; }
        [JsonProperty("GENDER")]
        public string GENDER { get; set; }
        [JsonProperty("PENDING_AMOUNT")]
        public decimal PENDING_AMOUNT { get; set; }
        [JsonProperty("CONTACTNUMBER")]
        public string CONTACTNUMBER { get; set; }
    }
    public class UnpaidPagingation
    {
        public List<Unpaid> UnpaidList { get; set; }
        public int filteredCount { get; set; }
    }
    public class UnpaidResponse
    {
        public UnpaidPagingation Data { get; set; }
    }
}
