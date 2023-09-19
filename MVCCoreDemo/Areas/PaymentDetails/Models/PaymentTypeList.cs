using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.PaymentDetails.Models
{
    public class PaymentTypeList
    {
        [JsonProperty("PAYMENT_ID")]
        public int PAYMENT_ID { get; set; }
        [JsonProperty("TYPE_NAME")]
        public string TYPE_NAME { get; set; }
    }
}
