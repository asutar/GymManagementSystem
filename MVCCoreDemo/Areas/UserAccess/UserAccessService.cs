using MVCCoreDemo.Areas.UserAccess.Models;
using MVCCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.UserAccess
{
    public interface IUserAccessService
    {
        List<MenuModel> GetRoleWiseMenu_GetAllMenu(string RoleId);
        List<UserRole> UpdateRepositoryForIDAsync(int roleID);
        List<RoleMenuMap> GetRoleWiseMenuList(string RoleId);
        bool UpdateRoleMenuMapList(List<RoleMenuMap> value, string updateByUserID);
        bool UpdateRoleMenuOperationAccess(List<RoleMenuMap> value, string updateByUserID);
    }
    public class UserAccessService : IUserAccessService
    {
        string CON_STRING = Startup.ConnectionString;
        public List<MenuModel> GetRoleWiseMenu_GetAllMenu(string RoleId)
        {

            List<MenuModel> lstData = new List<MenuModel>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ROLE_WISE_MENU_GET_ALL_MENU";

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new MenuModel
                        {
                            MenuId = Convert.ToInt32(dr["MENU_ID"]),
                            MenuCode = Convert.ToString(dr["MENU_CODE"]),
                            MenuName = Convert.ToString(dr["MENU_NAME"]),
                            MenuUrl = Convert.ToString(dr["MENU_URL"]),
                            ParentMenuId = Convert.ToInt32(dr["PARENT_MENU_ID"]),
                            IconCssName = Convert.ToString(dr["ICON_CSS_NAME"])
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public List<UserRole> UpdateRepositoryForIDAsync(int roleID)
        {
            List<UserRole> retVal =new List<UserRole>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_USER_ROLE_FOR_ID";

                cmd.Parameters.Add("ROLE_ID", SqlDbType.Int).Value = roleID;

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        retVal.Add(new UserRole
                        {
                            RoleId = Convert.ToInt32(dr["ROLE_ID"]),
                            RoleName = Convert.ToString(dr["ROLE_NAME"]),
                            RoleDescription = Convert.ToString(dr["ROLE_DESCRIPTION"]),
                            IsInUse = Convert.ToBoolean(dr["IS_IN_USE"]),
                            LastUpdateBy = Convert.ToString(dr["LAST_UPDATE_BY"]),
                            LastUpdateTime = Convert.ToDateTime(dr["LAST_UPDATE_TIME"]),
                        });
                    }
                }
                con.Close();
            }

            return retVal;
        }
        public List<RoleMenuMap> GetRoleWiseMenuList(string RoleId)
        {

            List<RoleMenuMap> lstData = new List<RoleMenuMap>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_ROLE_MENU_MAP_FOR_ROLE_ID";
                cmd.Parameters.Add("ROLE_ID", SqlDbType.Int).Value = RoleId;

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new RoleMenuMap
                        {
                            RoleMenuMapId = Convert.ToInt32(dr["ROLE_MENU_MAP_ID"]),
                            RoleId = Convert.ToInt32(dr["ROLE_ID"]),
                            MenuId = Convert.ToInt32(dr["MENU_ID"]),
                            IsEnable = Convert.ToBoolean(dr["IS_ENABLE"]),
                            LastUpdateBy = Convert.ToString(dr["LAST_UPDATE_BY"]),
                            LastUpdateTime = Convert.ToDateTime(dr["LAST_UPDATE_TIME"]),
                            ActiveChilds = Convert.ToInt32(dr["ActiveChilds"]),
                            IsAddAccess = Convert.ToBoolean(dr["IS_ADD_ACCESS"]),
                            IsEditAccess = Convert.ToBoolean(dr["IS_EDIT_ACCESS"]),
                            IsDeleteAccess = Convert.ToBoolean(dr["IS_DELETE_ACCESS"]),
                            IS_ADD = Convert.ToBoolean(dr["IS_ADD"]),
                            IS_EDIT = Convert.ToBoolean(dr["IS_EDIT"]),
                            IS_DELETE = Convert.ToBoolean(dr["IS_DELETE"]),
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public bool UpdateRoleMenuMapList(List<RoleMenuMap> value, string updateByUserID)
        {

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_UPDATE_ROLE_MENU_MAP_LIST";

                DataTable dtDetail = new DataTable("TYP_ROLE_MENU_MAP");
                dtDetail.Columns.Add("ROLE_ID", typeof(int));
                dtDetail.Columns.Add("MENU_ID", typeof(int));
                dtDetail.Columns.Add("IS_ENABLE", typeof(bool));

                foreach (RoleMenuMap data in value)
                {
                    dtDetail.Rows.Add(data.RoleId, data.MenuId, data.IsEnable);
                }

                cmd.Parameters.AddWithValue("ROLE_MENU_MAP", dtDetail);

                cmd.Parameters.Add("USER_ID", SqlDbType.VarChar).Value = updateByUserID;

                 con.Open();
                 cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }
        public bool UpdateRoleMenuOperationAccess(List<RoleMenuMap> value, string updateByUserID)
        {

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_UPDATE_ROLE_MENU_OPERATION_ACCESS";

                cmd.Parameters.Add("ROLE_MENU_MAP_ID", SqlDbType.Int).Value = value[0].RoleMenuMapId;
                cmd.Parameters.Add("IS_ADD_ACCESS", SqlDbType.Bit).Value = value[0].IsAddAccess;
                cmd.Parameters.Add("IS_EDIT_ACCESS", SqlDbType.Bit).Value = value[0].IsEditAccess;
                cmd.Parameters.Add("IS_DELETE_ACCESS", SqlDbType.Bit).Value = value[0].IsDeleteAccess;
                cmd.Parameters.Add("USER_ID", SqlDbType.VarChar).Value = updateByUserID;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }
    }
}
