using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Models
{
    public class MenuModel: MenuAccess
    {
        public int MenuId { get; set; } 
        public string MenuCode { get; set; } 
        public string MenuName { get; set; }
        public int? ParentMenuId { get; set; }
        public string MenuUrl { get; set; }
        public string IconCssName { get; set; } 
        public int SeqNo { get; set; }
        public bool IS_POP_UP { get; set; }
        public bool IS_ADD_ACCESS { get; set; }
        public bool IS_EDIT_ACCESS { get; set; }
        public bool IS_DELETE_ACCESS { get; set; }
    }
    public class MenuAccess
    {
        public string Mnu_Action { get; set; }
        public string Mnu_Controller { get; set; }
        public string Mnu_Area { get; set; }
    }

    public class MenuDetails 
    {
        public List<MenuModel> MENU_MODEL_LIST { get; set; }
        public MenuAccess MENU_ACCESS { get; set; }
    }
}
