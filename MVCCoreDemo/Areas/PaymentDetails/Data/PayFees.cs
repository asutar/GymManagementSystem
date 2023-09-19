using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.PaymentDetails.Data
{
    public class PayFees
    {
        [JsonProperty("FEES_MEMBER_ID")]
        public int FEES_MEMBER_ID { get; set; }
        [JsonProperty("FEES_MEMBER_HISTORY_ID")]
        public int FEES_MEMBER_HISTORY_ID { get; set; }
        [JsonProperty("MEMBER_ID")]
        public int MEMBER_ID { get; set; }
        [JsonProperty("MEMBER_NAME")]
        public string MEMBER_NAME { get; set; }
        [JsonProperty("PAID_AMOUNT")]
        public decimal PAID_AMOUNT { get; set; }
        [JsonProperty("TOTAL_AMOUNT")]
        public decimal TOTAL_AMOUNT { get; set; }
        [JsonProperty("PENDING_AMOUNT")]
        public decimal PENDING_AMOUNT { get; set; }
        [JsonProperty("PAYMENT_ID")]
        public int PAYMENT_ID { get; set; }
        [JsonProperty("TYPE_NAME")]
        public string TYPE_NAME { get; set; }
        [JsonProperty("TRASACTION_NO")]
        public string TRASACTION_NO { get; set; }
        [JsonProperty("TRANSATION_DATETIME")]
        public string TRANSATION_DATETIME { get; set; }
        [JsonProperty("ADDED_BY")]
        public int ADDED_BY { get; set; }
        [JsonProperty("BATCH_ID")]
        public int BATCH_ID { get; set; }
    }
    public class PayFeesPagingation
    {
        public List<PayFees> PayFeesList { get; set; }
        public int filteredCount { get; set; }
    }
    public class PayFeesResponse
    {
        public PayFeesPagingation Data { get; set; }
    }
}
