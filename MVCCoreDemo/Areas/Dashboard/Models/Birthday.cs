using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.Dashboard.Models
{
    public class Birthday
    {
        [JsonProperty("NAME")]
        public string NAME { get; set; }
        [JsonProperty("GENDER")]
        public string GENDER { get; set; }
        [JsonProperty("DATEOFBIRTH")]
        public string DATEOFBIRTH { get; set; }
        [JsonProperty("CONTACTNUMBER")]
        public string CONTACTNUMBER { get; set; }
        [JsonProperty("EMAIL")]
        public string EMAIL { get; set; }
        [JsonProperty("TYPE")]
        public string TYPE { get; set; }
    }
    public class BirthdayPagingation
    {
        public List<Birthday> BirthdayList { get; set; }
        public int filteredCount { get; set; }
    }
    public class BATCHResponse
    {
        public BirthdayPagingation Data { get; set; }
    }
}
