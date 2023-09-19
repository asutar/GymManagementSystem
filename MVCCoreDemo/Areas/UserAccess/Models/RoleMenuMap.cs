using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.UserAccess.Models
{
    public class RoleMenuMap
    {
        public int RoleMenuMapId { get; set; } // int, not null
        public int RoleId { get; set; } // int, not null
        public int MenuId { get; set; } // int, not null
        public bool IsEnable { get; set; } // bit, not null
        public string LastUpdateBy { get; set; } // int, not null
        public DateTime LastUpdateTime { get; set; } // datetime, not null
        public int ActiveChilds { get; set; } // int
        public bool IsAddAccess { get; set; } // bit
        public bool IsEditAccess { get; set; } // bit
        public bool IsDeleteAccess { get; set; } // bit
        public bool Is_Edited { get; set; } // bit


        public bool IS_ADD { get; set; } // bit
        public bool IS_EDIT { get; set; } // bit
        public bool IS_DELETE { get; set; } // bit

    }
}
