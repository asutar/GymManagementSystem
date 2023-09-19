using MVCCoreDemo.Areas.Dashboard.Models;
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
        YearMonthlyChart GetYearlyMonthyFeesDetailsChart(string YEAR);
    }
    public class DashboardService : IDashboardService
    {
        string CON_STRING = Startup.ConnectionString;
        public AllCount GetAllCount(int TAX_ID)
        {

            AllCount lstData = new AllCount();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_ALL_COUNT";
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
        public YearMonthlyChart GetYearlyMonthyFeesDetailsChart(string YEAR)
        {

            YearMonthlyChart lstData = new YearMonthlyChart();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_YEARLY_FEES_DETAILS_CHART";
                cmd.Parameters.Add("@YEAR", SqlDbType.VarChar).Value = YEAR;

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
    }
}
