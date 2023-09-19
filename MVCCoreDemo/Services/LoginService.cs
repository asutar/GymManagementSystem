using MVCCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Services
{
    public interface ILoginService
    {
         string GetMessage();
        LoginModel IsUserValidate(string USER_NAME, string PASSWORD);
        MenuDetails GetUserMenuByRole(int USER_ID);
    }
    public class LoginService : ILoginService
    {
        string CON_STRING = Startup.ConnectionString;
        public string GetMessage()
        {
            return "Inside GetMessage method...";
        }
        public LoginModel IsUserValidate(string USER_NAME,string PASSWORD)
        {
            LoginModel loginModel = new LoginModel();
            try
            {
                using (SqlConnection con = new SqlConnection(CON_STRING))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PROC_IS_USER_VALID";
                    cmd.Parameters.Add("@USER_NAME", SqlDbType.VarChar, 20).Value = USER_NAME;
                    cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar, 20).Value = PASSWORD;

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            loginModel.USER_ID = Convert.ToInt32(dr["USER_ID"]);
                            loginModel.USER_NAME = Convert.ToString(dr["USER_NAME"]);
                            loginModel.ROLE_ID = Convert.ToInt32(dr["ROLE_ID"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return loginModel;
        }
        public MenuDetails GetUserMenuByRole(int USER_ID)
        {
            try
            {
                MenuDetails menuDetails = new MenuDetails();
                List<MenuModel> lstMenuModel = new List<MenuModel>();
                MenuAccess menuAccess = new MenuAccess();

                using (SqlConnection con = new SqlConnection(CON_STRING))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PROC_GET_MENU_BY_ROLE";
                    cmd.Parameters.Add("@USER_ID", SqlDbType.VarChar).Value = USER_ID;

                     con.Open();

                    using (SqlDataReader dr =  cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            lstMenuModel.Add(new MenuModel
                            {
                                MenuId = Convert.ToInt32(dr["MENU_ID"]),
                                MenuName = dr["MENU_NAME"].ToString(),
                                ParentMenuId = Convert.ToInt32(dr["PARENT_MENU_ID"]),
                                MenuUrl = dr["MENU_URL"].ToString(),
                                IconCssName = dr["ICON_CSS_NAME"].ToString(),
                                SeqNo = Convert.ToInt32(dr["SEQ_NO"]),
                                Mnu_Action = dr["MNU_ACTION"].ToString(),
                                Mnu_Controller = dr["MENU_CONTROLLER"].ToString(),
                                Mnu_Area = dr["MENU_AREA"].ToString(),
                                IS_POP_UP = Convert.ToBoolean(dr["IS_POPUP_UP"]),
                                IS_ADD_ACCESS = Convert.ToBoolean(dr["IS_ADD_ACCESS"] != DBNull.Value ? Convert.ToString(dr["IS_ADD_ACCESS"]) : "false"),
                                IS_EDIT_ACCESS = Convert.ToBoolean(dr["IS_EDIT_ACCESS"] != DBNull.Value ? Convert.ToString(dr["IS_EDIT_ACCESS"]) : "false"),
                                IS_DELETE_ACCESS = Convert.ToBoolean(dr["IS_DELETE_ACCESS"] != DBNull.Value ? Convert.ToString(dr["IS_DELETE_ACCESS"]) : "false")
                            });

                        }
                        menuDetails.MENU_MODEL_LIST = lstMenuModel;


                        //START# TO FETCH ACCESS MENU FOR USER

                        if (dr.NextResult())
                        {
                            while (dr.Read())
                            {

                                menuAccess.Mnu_Action = dr["MNU_ACTION"].ToString();
                                menuAccess.Mnu_Controller = dr["MENU_CONTROLLER"].ToString();
                                menuAccess.Mnu_Area = dr["MENU_AREA"].ToString();
                            }

                            menuDetails.MENU_ACCESS = menuAccess;

                        }
                        //END# TO FETCH ACCESS MENU FOR USER
                    }

                }

                return menuDetails;
            }
            catch (Exception ex)
            {
                //write log
                throw ex;
            }
        }
    }
}
