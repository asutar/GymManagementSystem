using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.UserAccess.Models
{
    public class RoleModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public string IsInUse { get; set; }
        public string LastUpdateBy { get; set; }
        public string LastUpdateTime { get; set; }
        public int UserID { get; set; }
    }
}
