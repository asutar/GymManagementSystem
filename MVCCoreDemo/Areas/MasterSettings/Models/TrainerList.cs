using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Models
{
    public class TrainerList
    {
        [JsonProperty("TRAINER_ID")]
        public int TRAINER_ID { get; set; }
        [JsonProperty("TRAINER_NAME")]
        public string TRAINER_NAME { get; set; }
    }
}
