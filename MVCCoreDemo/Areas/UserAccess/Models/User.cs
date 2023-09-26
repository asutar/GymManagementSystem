using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.UserAccess.Models
{
    public class User
    {
        [JsonProperty("USER_ID")]
        public int USER_ID { get; set; }
        [JsonProperty("USER_NAME")]
        public string USER_NAME { get; set; }

        [JsonProperty("FIRST_NAME")]
        public string FIRST_NAME { get; set; }
        [JsonProperty("LAST_NAME")]
        public string LAST_NAME { get; set; }
        [JsonProperty("MIDDLE_NAME")]
        public string MIDDLE_NAME { get; set; }
        [JsonProperty("EMAIL_ID")]
        public string EMAIL_ID { get; set; }
        [JsonProperty("MOBILE_NO")]
        public string MOBILE_NO { get; set; }
        [JsonProperty("ADDRESS")]
        public string ADDRESS { get; set; }
        [JsonProperty("SEX_ID")]
        public int SEX_ID { get; set; }
        [JsonProperty("IMAGEDATA")]
        public string IMAGEDATA { get; set; }

        [JsonProperty("PASSWORD")]
        public string PASSWORD { get; set; }
        [JsonProperty("ADDED_BY_ID")]
        public int ADDED_BY_ID { get; set; }
        [JsonProperty("ADDED_BY_NAME")]
        public string ADDED_BY_NAME { get; set; }
        [JsonProperty("ADDED_BY_DATETIME")]
        public string ADDED_BY_DATETIME { get; set; }
        [JsonProperty("IS_ACTIVE")]
        public bool IS_ACTIVE { get; set; }
        [JsonProperty("SUB_CLIENT_ID")]
        public int SUB_CLIENT_ID { get; set; }
        [JsonProperty("UPDATED_BY_ID")]
        public int UPDATED_BY_ID { get; set; }
        [JsonProperty("UPDATED_BY_NAME")]
        public string UPDATED_BY_NAME { get; set; }
        [JsonProperty("UPDATED_BY_DATETIME")]
        public string UPDATED_BY_DATETIME { get; set; }
        [JsonProperty("ROLE_ID")]
        public int ROLE_ID { get; set; }
        [JsonProperty("ADDED_BY")]
        public int ADDED_BY { get; set; }
        [JsonProperty("OPERATION_STATUS")]
        public string OPERATION_STATUS { get; set; }
        [JsonProperty("GENDER")]
        public string GENDER { get; set; }
        [JsonProperty("BIRTH_DATE")]
        public string BIRTH_DATE { get; set; }
    }
    public class UserPagingation
    {
        public List<User> UserList { get; set; }
        public int filteredCount { get; set; }
    }
    public class UserResponse
    {
        public UserPagingation Data { get; set; }
    }
}
