using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.UserAccess.Models
{
    public class UserRole
    {
        public int RoleId { get; set; } // int, not null
        public string RoleName { get; set; } // varchar(50), not null
        public string RoleDescription { get; set; } // varchar(200), null
        public bool IsInUse { get; set; } // bit, not null
        public string LastUpdateBy { get; set; } // int, null
        public DateTime LastUpdateTime { get; set; } // datetime, not null
    }
}
