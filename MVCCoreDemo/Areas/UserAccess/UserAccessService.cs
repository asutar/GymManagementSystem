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
        UserPagingation GetSubClientAsync(int USER_ID, DataTableAjaxPostModel model);
        ReturnResponse AddSubClient(User model);
        ReturnResponse UpdateSubClient(User model);
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
                    while (dr.Read())
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
        public UserPagingation GetSubClientAsync(int USER_ID, DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            UserPagingation _UserPagingation = new UserPagingation();
            List<User> retVal = new List<User>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_SUB_CLIENTS";

                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;
                cmd.Parameters.Add("@SORTCOLUMN", SqlDbType.VarChar).Value = model.columns[model.order[0].column].data == null ? "" : model.columns[model.order[0].column].data;
                cmd.Parameters.Add("@SORTORDER", SqlDbType.VarChar).Value = model.order[0].dir == null ? "" : model.order[0].dir;
                cmd.Parameters.Add("@OFFSETVALUE", SqlDbType.Int).Value = model.start;
                cmd.Parameters.Add("@PAGINGSIZE", SqlDbType.Int).Value = model.length;
                cmd.Parameters.Add("@SEARCHTEXT", SqlDbType.VarChar).Value = model.search.value == null ? "" : model.search.value;

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TotalRecord = Convert.ToInt32(dr["TOTALCOUNT"]);
                        retVal.Add(new User
                        {
                            USER_ID = Convert.ToInt32(dr["USER_ID"]),
                            USER_NAME = Convert.ToString(dr["USER_NAME"]),

                            FIRST_NAME = Convert.ToString(dr["FIRST_NAME"]),
                            LAST_NAME = Convert.ToString(dr["LAST_NAME"]),
                            MIDDLE_NAME = Convert.ToString(dr["MIDDLE_NAME"]),
                            EMAIL_ID = Convert.ToString(dr["EMAIL_ID"]),
                            ADDRESS = Convert.ToString(dr["ADDRESS"]),
                            MOBILE_NO = Convert.ToString(dr["MOBILE_NO"]),
                            SEX_ID = Convert.ToInt32(dr["SEX_ID"]),
                            GENDER = Convert.ToString(dr["SEX"]),
                            ROLE_ID = Convert.ToInt32(dr["ROLE_ID"]),
                            IMAGEDATA = Convert.ToString(dr["IMAGEDATA"]),
                            ADDED_BY_ID = Convert.ToInt32(dr["ADDED_BY_ID"]),
                            ADDED_BY_NAME = Convert.ToString(dr["ADDED_BY_NAME"]),
                            ADDED_BY_DATETIME = Convert.ToString(dr["ADDED_BY_DATETIME"]),
                            IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]),
                            SUB_CLIENT_ID = Convert.ToInt32(dr["SUB_CLIENT_ID"]),
                            UPDATED_BY_ID = Convert.ToInt32(dr["UPDATED_BY_ID"]),
                            UPDATED_BY_NAME = Convert.ToString(dr["UPDATED_BY_NAME"]),
                            UPDATED_BY_DATETIME = Convert.ToString(dr["UPDATED_BY_DATETIME"]),
                            BIRTH_DATE = Convert.ToString(dr["BIRTH_DATE"]),
                        });
                    }
                    _UserPagingation.filteredCount = TotalRecord;
                    _UserPagingation.UserList = retVal;
                }
                con.Close();
            }

            return _UserPagingation;
        }
        public ReturnResponse AddSubClient(User model)
        {
            ReturnResponse _returnResponse = new ReturnResponse();
            bool RowsAffected = false;
            object objReturn = null;
            try
            {
                using (SqlConnection con = new SqlConnection(CON_STRING))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PROC_CREATE_SUB_CLIENT";
                    cmd.Parameters.Add("@USER_NAME", SqlDbType.VarChar).Value = model.USER_NAME;
                    cmd.Parameters.Add("@FIRST_NAME", SqlDbType.VarChar).Value = model.FIRST_NAME;
                    cmd.Parameters.Add("@LAST_NAME", SqlDbType.VarChar).Value = model.LAST_NAME;
                    cmd.Parameters.Add("@MIDDLE_NAME", SqlDbType.VarChar).Value = model.MIDDLE_NAME;
                    cmd.Parameters.Add("@EMAIL_ID", SqlDbType.VarChar).Value = model.EMAIL_ID;
                    cmd.Parameters.Add("@MOBILE_NO", SqlDbType.VarChar).Value = model.MOBILE_NO;
                    cmd.Parameters.Add("@BIRTH_DATE", SqlDbType.Date).Value = model.BIRTH_DATE;
                    cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = model.ADDRESS;
                    cmd.Parameters.Add("@GENDER", SqlDbType.VarChar).Value = model.SEX_ID;
                    cmd.Parameters.Add("@IMAGEDATA", SqlDbType.VarChar).Value = model.IMAGEDATA;
                    cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = model.PASSWORD;
                    cmd.Parameters.Add("@ROLE_ID", SqlDbType.Int).Value = model.ROLE_ID;
                    cmd.Parameters.Add("@ADDED_BY", SqlDbType.Int).Value = model.ADDED_BY_ID;
                    cmd.Parameters.Add("@IS_ACTIVE", SqlDbType.Bit).Value = 1;
                    cmd.Parameters.Add("@SUB_CLIENT_ID", SqlDbType.VarChar).Value = model.SUB_CLIENT_ID;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to added sub client" : "sub client added successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to add sub client";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public ReturnResponse UpdateSubClient(User model)
        {
            ReturnResponse _returnResponse = new ReturnResponse();
            bool RowsAffected = false;
            object objReturn = null;
            try
            {
                using (SqlConnection con = new SqlConnection(CON_STRING))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PROC_UPDATE_SUB_CLIENTS";
                    cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = model.USER_ID;
                    cmd.Parameters.Add("@USER_NAME", SqlDbType.VarChar).Value = model.USER_NAME;
                    cmd.Parameters.Add("@FIRST_NAME", SqlDbType.VarChar).Value = model.FIRST_NAME;
                    cmd.Parameters.Add("@LAST_NAME", SqlDbType.VarChar).Value = model.LAST_NAME;
                    cmd.Parameters.Add("@MIDDLE_NAME", SqlDbType.VarChar).Value = model.MIDDLE_NAME;
                    cmd.Parameters.Add("@EMAIL_ID", SqlDbType.VarChar).Value = model.EMAIL_ID;
                    cmd.Parameters.Add("@MOBILE_NO", SqlDbType.VarChar).Value = model.MOBILE_NO;
                    cmd.Parameters.Add("@GENDER", SqlDbType.VarChar).Value = model.SEX_ID;
                    cmd.Parameters.Add("@IMAGEDATA", SqlDbType.VarChar).Value = model.IMAGEDATA;
                    cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = model.ADDRESS;
                    cmd.Parameters.Add("@BIRTH_DATE", SqlDbType.Date).Value = model.BIRTH_DATE;

                    cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = model.PASSWORD;
                    cmd.Parameters.Add("@ROLE_ID", SqlDbType.Int).Value = model.ROLE_ID;
                    cmd.Parameters.Add("@UPDATED_BY", SqlDbType.Int).Value = model.UPDATED_BY_ID;
                    cmd.Parameters.Add("@IS_ACTIVE", SqlDbType.Bit).Value = 1;
                    cmd.Parameters.Add("@SUB_CLIENT_ID", SqlDbType.Int).Value = model.SUB_CLIENT_ID;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to update sub client" : "sub client updated successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to update sub client";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public List<UserRole> GetRoleList(string RoleId)
        {

            List<UserRole> lstData = new List<UserRole>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_ROLE";

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new UserRole
                        {
                            RoleId = Convert.ToInt32(dr["ROLE_ID"]),
                            RoleName = Convert.ToString(dr["ROLE_NAME"]),
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
    }
}
