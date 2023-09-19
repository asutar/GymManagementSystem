using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class MemberRegistration
    {
        [JsonProperty("MEMBERID")]
        public int MEMBERID { get; set; }
        [JsonProperty("FIRSTNAME")]
        public string FIRSTNAME { get; set; }
        [JsonProperty("LASTNAME")]
        public string LASTNAME { get; set; }
        [JsonProperty("GENDER_ID")]
        public int GENDER_ID { get; set; }
        [JsonProperty("GENDER")]
        public string GENDER { get; set; }
        [JsonProperty("DATEOFBIRTH")]
        public string DATEOFBIRTH { get; set; }
        [JsonProperty("CONTACTNUMBER")]
        public string CONTACTNUMBER { get; set; }
        [JsonProperty("EMAIL")]
        public string EMAIL { get; set; }
        [JsonProperty("ADDRESS")]
        public string ADDRESS { get; set; }
        [JsonProperty("ADDED_DATE")]
        public string ADDED_DATE { get; set; }
        [JsonProperty("ADDED_BY")]
        public int ADDED_BY { get; set; }
        [JsonProperty("IMAGEDATA")]
        public string IMAGEDATA { get; set; }
        [JsonProperty("OPERATION_STATUS")]
        public string OPERATION_STATUS { get; set; }
        [JsonProperty("IS_ACTIVE")]
        public bool IS_ACTIVE { get; set; }
    }
    public class MemberRegistrationPagingation
    {
        public List<MemberRegistration> MemberList { get; set; }
        public int filteredCount { get; set; }
    }
    public class MemberRegistrationResponse 
    {
        public MemberRegistrationPagingation Data { get; set; }
    }
}
