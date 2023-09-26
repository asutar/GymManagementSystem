using MVCCoreDemo.Areas.Dashboard.Models;
using MVCCoreDemo.Areas.MasterSettings.Models;
using MVCCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.Dashboard.Data
{
    public interface IDashboardService
    {
        AllCount GetAllCount(int TAX_ID);
        YearMonthlyChart GetYearlyMonthyFeesDetailsChart(int USER_ID);
        YearMonthlyChart GetYearlyMonthyAdmissionDetailsChart(int USER_ID);
        BirthdayPagingation GetBirthday(int USER_ID, DataTableAjaxPostModel model);
        MemberRegistrationPagingation GetMemberToday(int MEMBERID, DataTableAjaxPostModel model);
        UnpaidPagingation GetUnPaidDetails(int USER_ID, DataTableAjaxPostModel model);
    }
    public class DashboardService : IDashboardService
    {
        string CON_STRING = Startup.ConnectionString;
        public AllCount GetAllCount(int USER_ID)
        {

            AllCount lstData = new AllCount();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_ALL_COUNT";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.DAILY_ENQUIRY = Convert.ToInt32(dr["DAILY_ENQUIRY"]);
                        lstData.REGISTERED_MEMBER = Convert.ToInt32(dr["REGISTERED_MEMBER"]);
                        lstData.TODAYS_BIRTHDAY = Convert.ToInt32(dr["TODAYS_BIRTHDAY"]);
                        lstData.TODAY_FEES_COLLECTION = Convert.ToInt32(dr["TODAY_FEES_COLLECTION"]);
                        lstData.PRESENT_MEMBER = Convert.ToInt32(dr["PRESENT_MEMBER"]);
                        lstData.TODAY_REGISTERED_MEMBER = Convert.ToInt32(dr["TODAY_REGISTERED_MEMBER"]);
                        lstData.TOTAL_BATCHES = Convert.ToInt32(dr["TOTAL_BATCHES"]);
                        lstData.TOTAL_TRAINERS = Convert.ToInt32(dr["TOTAL_TRAINERS"]);
                        lstData.TOTAL_PACKAGE = Convert.ToInt32(dr["TOTAL_PACKAGE"]);
                        lstData.FEES_UNPAID = Convert.ToInt32(dr["FEES_UNPAID"]);
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public YearMonthlyChart GetYearlyMonthyFeesDetailsChart(int USER_ID)
        {

            YearMonthlyChart lstData = new YearMonthlyChart();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_YEARLY_FEES_DETAILS_CHART";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Year = Convert.ToString(dr["Year"]);
                        lstData.January = Convert.ToString(dr["January"]);
                        lstData.February = Convert.ToString(dr["February"]);
                        lstData.March = Convert.ToString(dr["March"]);
                        lstData.April = Convert.ToString(dr["April"]);
                        lstData.May = Convert.ToString(dr["May"]);
                        lstData.June = Convert.ToString(dr["June"]);
                        lstData.July = Convert.ToString(dr["July"]);
                        lstData.August = Convert.ToString(dr["August"]);
                        lstData.September = Convert.ToString(dr["September"]);
                        lstData.October = Convert.ToString(dr["October"]);
                        lstData.November = Convert.ToString(dr["November"]);
                        lstData.December = Convert.ToString(dr["December"]);
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public YearMonthlyChart GetYearlyMonthyAdmissionDetailsChart(int USER_ID)
        {

            YearMonthlyChart lstData = new YearMonthlyChart();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_MONTHLY_ADMISSION_DETAILS_CHART";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Year = Convert.ToString(dr["Year"]);
                        lstData.January = Convert.ToString(dr["January"]);
                        lstData.February = Convert.ToString(dr["February"]);
                        lstData.March = Convert.ToString(dr["March"]);
                        lstData.April = Convert.ToString(dr["April"]);
                        lstData.May = Convert.ToString(dr["May"]);
                        lstData.June = Convert.ToString(dr["June"]);
                        lstData.July = Convert.ToString(dr["July"]);
                        lstData.August = Convert.ToString(dr["August"]);
                        lstData.September = Convert.ToString(dr["September"]);
                        lstData.October = Convert.ToString(dr["October"]);
                        lstData.November = Convert.ToString(dr["November"]);
                        lstData.December = Convert.ToString(dr["December"]);
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public BirthdayPagingation GetBirthday(int USER_ID, DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            BirthdayPagingation _BATCHPagingation = new BirthdayPagingation();
            List<Birthday> lstData = new List<Birthday>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_BIRTHDAY";

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
                        lstData.Add(new Birthday
                        {
                            NAME = Convert.ToString(dr["NAME"]),
                            GENDER = Convert.ToString(dr["GENDER"]),
                            DATEOFBIRTH = Convert.ToString(dr["DATEOFBIRTH"]),
                            CONTACTNUMBER = Convert.ToString(dr["CONTACTNUMBER"]),
                            EMAIL = Convert.ToString(dr["EMAIL"]),
                            TYPE = Convert.ToString(dr["TYPE"]),
                        });
                    }
                    _BATCHPagingation.filteredCount = TotalRecord;
                    _BATCHPagingation.BirthdayList = lstData;
                }
                con.Close();
            }

            return _BATCHPagingation;
        }
        public MemberRegistrationPagingation GetMemberToday(int MEMBERID, DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            MemberRegistrationPagingation _MemberRegistrationPagingation = new MemberRegistrationPagingation();
            List<MemberRegistration> lstData = new List<MemberRegistration>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_MEMBER_TODAY";

                cmd.Parameters.Add("@MEMBERID", SqlDbType.Int).Value = MEMBERID;
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
                        lstData.Add(new MemberRegistration
                        {
                            MEMBERID = Convert.ToInt32(dr["MEMBERID"]),
                            FIRSTNAME = Convert.ToString(dr["FIRSTNAME"]),
                            LASTNAME = Convert.ToString(dr["LASTNAME"]),
                            GENDER_ID = Convert.ToInt32(dr["GENDER_ID"]),
                            GENDER = Convert.ToString(dr["GENDER"]),
                            DATEOFBIRTH = Convert.ToString(dr["DATEOFBIRTH"]),
                            CONTACTNUMBER = Convert.ToString(dr["CONTACTNUMBER"]),
                            EMAIL = Convert.ToString(dr["EMAIL"]),
                            ADDRESS = Convert.ToString(dr["ADDRESS"]),
                            ADDED_DATE = Convert.ToString(dr["ADDED_DATE"]),
                            IMAGEDATA = Convert.ToString(dr["IMAGEDATA"]),
                            IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]),
                        });
                    }
                    _MemberRegistrationPagingation.filteredCount = TotalRecord;
                    _MemberRegistrationPagingation.MemberList = lstData;
                }
                con.Close();
            }

            return _MemberRegistrationPagingation;
        }
        public UnpaidPagingation GetUnPaidDetails(int USER_ID, DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            UnpaidPagingation _MemberRegistrationPagingation = new UnpaidPagingation();
            List<Unpaid> lstData = new List<Unpaid>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_UNPAID_DETAILS";

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
                        lstData.Add(new Unpaid
                        {
                            MEMBER_ID = Convert.ToInt32(dr["MEMBER_ID"]),
                            BATCH_ID = Convert.ToInt32(dr["BATCH_ID"]),
                            NEXT_FEES_DATETIME = Convert.ToString(dr["NEXT_FEES_DATETIME"]),
                            NAME = Convert.ToString(dr["NAME"]),
                            GENDER = Convert.ToString(dr["GENDER"]),
                            PENDING_AMOUNT = Convert.ToDecimal(dr["PENDING_AMOUNT"]),
                            CONTACTNUMBER = Convert.ToString(dr["CONTACTNUMBER"]),
                        });
                    }
                    _MemberRegistrationPagingation.filteredCount = TotalRecord;
                    _MemberRegistrationPagingation.UnpaidList = lstData;
                }
                con.Close();
            }

            return _MemberRegistrationPagingation;
        }
    }
}
