using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Models
{
    public class LoginModel
    {
        public int USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public int ROLE_ID { get; set; }
        public bool REMEMBER { get; set; }
    }
}
