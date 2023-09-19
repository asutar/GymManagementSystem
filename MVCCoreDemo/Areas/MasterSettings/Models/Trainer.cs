using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class Trainer
    {
        [JsonProperty("TRAINER_ID")]
        public int TRAINER_ID { get; set; }
        [JsonProperty("FIRSTNAME")]
        public string FIRSTNAME { get; set; }
        [JsonProperty("LASTNAME")]
        public string LASTNAME { get; set; }
        [JsonProperty("GENDER_ID")]
        public int GENDER_ID { get; set; }
        [JsonProperty("GENDER_NAME")]
        public string GENDER_NAME { get; set; }
        [JsonProperty("CONTACTNUMBER")]
        public string CONTACTNUMBER { get; set; }
        [JsonProperty("EMAIL")]
        public string EMAIL { get; set; }
        [JsonProperty("SPECIALIZATION_ID")]
        public int SPECIALIZATION_ID { get; set; }
        [JsonProperty("SPECIALIZATION_NAME")]
        public string SPECIALIZATION_NAME { get; set; }
        [JsonProperty("ADDED_BY")]
        public int ADDED_BY { get; set; }
        [JsonProperty("OPERATION_STATUS")]
        public string OPERATION_STATUS { get; set; }
        [JsonProperty("DATEOFBIRTH")]
        public string DATEOFBIRTH { get; set; }
        [JsonProperty("ADDRESS")]
        public string ADDRESS { get; set; }
        [JsonProperty("ADDED_DATE")]
        public string ADDED_DATE { get; set; }
    }
    public class TrainerPagingation
    {
        public List<Trainer> MemberList { get; set; }
        public int filteredCount { get; set; }
    }
    public class TrainerResponse
    {
        public TrainerPagingation Data { get; set; }
    }
}
