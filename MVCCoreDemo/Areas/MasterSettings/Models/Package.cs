using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class Package
    {
        [JsonProperty("PACKAGE_ID")]
        public int PACKAGE_ID { get; set; }
        [JsonProperty("TITLE")]
        public string TITLE { get; set; }
        [JsonProperty("DESCRIPTION")]
        public string DESCRIPTION { get; set; }
        [JsonProperty("FEES")]
        public decimal FEES { get; set; }
        [JsonProperty("TAX_ID")]
        public int TAX_ID { get; set; }
        [JsonProperty("TAX_NAME")]
        public string TAX_NAME { get; set; }
        [JsonProperty("TOTAL_FEES")]
        public decimal TOTAL_FEES { get; set; }
        [JsonProperty("ADDED_BY")]
        public int ADDED_BY { get; set; }
        [JsonProperty("UPDATED_BY")]
        public int UPDATED_BY { get; set; }
        [JsonProperty("OPERATION_STATUS")]
        public string OPERATION_STATUS { get; set; }
        

    }
    public class PackagePagingation
    {
        public List<Package> PackageList { get; set; }
        public int filteredCount { get; set; }
    }
    public class PackageResponse
    {
        public PackagePagingation Data { get; set; }
    }
}
