using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class BatchMember
    {
        [JsonProperty("BATCH_MEMBER_MAPPING_ID")]
        public int BATCH_MEMBER_MAPPING_ID { get; set; }
        [JsonProperty("MEMBERID")]
        public int MEMBERID { get; set; }
        [JsonProperty("MEMBERNAME")]
        public string MEMBERNAME { get; set; }
        [JsonProperty("BATCH_ID")]
        public int BATCH_ID { get; set; }
        [JsonProperty("BATCHNAME")]
        public string BATCHNAME { get; set; }
        [JsonProperty("START_DATE")]
        public string START_DATE { get; set; }
        [JsonProperty("END_DATE")]
        public string END_DATE { get; set; }
        [JsonProperty("ADDED_BY")]
        public int ADDED_BY { get; set; }
        [JsonProperty("OPERATION_STATUS")]
        public string OPERATION_STATUS { get; set; }
        [JsonProperty("PACKAGE_ID")]
        public int PACKAGE_ID { get; set; }
        [JsonProperty("IS_ON_HOLD")]
        public bool IS_ON_HOLD { get; set; }
        [JsonProperty("NEXT_FEES_DATETIME")]
        public string NEXT_FEES_DATETIME { get; set; }
        [JsonProperty("IS_ACTIVE")]
        public bool IS_ACTIVE { get; set; }
        [JsonProperty("UPDATED_BY")]
        public int UPDATED_BY { get; set; }
    }
    public class BatchMemberPagingation
    {
        public List<BatchMember> BatchMemberList { get; set; }
        public int filteredCount { get; set; }
    }
    public class BatchMemberResponse
    {
        public BatchMemberPagingation Data { get; set; }
    }
}
