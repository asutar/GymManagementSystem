using MVCCoreDemo.Areas.MasterSettings.Models;
using MVCCoreDemo.Areas.PaymentDetails.Models;
using MVCCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.PaymentDetails.Data
{
    public interface IPaymentService
    {
        List<PaymentTypeList> GetPaymentType(int PAYMENT_ID, int USER_ID);
        PayFeesPagingation GetPayFees(int FEES_MEMBER_ID, int USER_ID, DataTableAjaxPostModel model);
        PayFees GetPendingAmount(int MEMBER_ID,int BATCH_ID, int USER_ID);
        ReturnResponse PayFees(PayFees model);
        PayFeesPagingation GetPayFeesDetails(int FEES_MEMBER_ID, int USER_ID, DataTableAjaxPostModel model);
        List<BatchScheduledDateTime> GetBatchByMember(int MEMBERID,int USER_ID);
        PayFeesPagingation GetTodayPayFeesHistory(int FEES_MEMBER_ID, int USER_ID, DataTableAjaxPostModel model);
    }
        public class PaymentService : IPaymentService
    {
        string CON_STRING = Startup.ConnectionString;
        public List<PaymentTypeList> GetPaymentType(int PAYMENT_ID,int USER_ID)
        {

            List<PaymentTypeList> lstData = new List<PaymentTypeList>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_PAYMENT_TYPE_LIST";
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;
                // cmd.Parameters.Add("@PROJECT_ID", SqlDbType.Int).Value = PAYMENT_ID;
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new PaymentTypeList
                        {
                            PAYMENT_ID = Convert.ToInt32(dr["PAYMENT_ID"]),
                            TYPE_NAME = Convert.ToString(dr["TYPE_NAME"]),
                          
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public PayFeesPagingation GetPayFees(int FEES_MEMBER_ID,int USER_ID, DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            PayFeesPagingation _PayFeesPagingation = new PayFeesPagingation();
            List<PayFees> lstData = new List<PayFees>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_PAID_FEES";

                cmd.Parameters.Add("@FEES_MEMBER_ID", SqlDbType.Int).Value = FEES_MEMBER_ID;
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
                        lstData.Add(new PayFees
                        {
                            FEES_MEMBER_ID = Convert.ToInt32(dr["FEES_MEMBER_ID"]),
                            MEMBER_ID = Convert.ToInt32(dr["MEMBER_ID"]),
                            MEMBER_NAME = Convert.ToString(dr["MEMBER_NAME"]),
                            PAID_AMOUNT = Convert.ToDecimal(dr["PAID_AMOUNT"]),
                            TOTAL_AMOUNT = Convert.ToDecimal(dr["TOTAL_AMOUNT"]),
                            PENDING_AMOUNT = Convert.ToDecimal(dr["PENDING_AMOUNT"]),
                            PAYMENT_ID = Convert.ToInt32(dr["PAYMENT_ID"]),
                            TYPE_NAME = Convert.ToString(dr["TYPE_NAME"]),
                            TRASACTION_NO = Convert.ToString(dr["TRASACTION_NO"]),
                            TRANSATION_DATETIME = Convert.ToString(dr["TRANSATION_DATETIME"]),
                        });
                    }
                    _PayFeesPagingation.filteredCount = TotalRecord;
                    _PayFeesPagingation.PayFeesList = lstData;
                }
                con.Close();
            }

            return _PayFeesPagingation;
        }
        public PayFees  GetPendingAmount(int MEMBER_ID,int BATCH_ID,int USER_ID)
        {
            PayFees _payFees = new PayFees();
            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_PANDING_FEES_AMOUNT_BY_MEMBER";
                cmd.Parameters.Add("@MEMBER_ID", SqlDbType.Int).Value = MEMBER_ID;
                cmd.Parameters.Add("@BATCH_ID", SqlDbType.Int).Value = BATCH_ID;
                cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        _payFees.PENDING_AMOUNT = Convert.ToInt32(dr["PENDING_AMOUNT"]);
                    }
                }
                con.Close();
            }

            return _payFees;
        }
        public ReturnResponse PayFees(PayFees model)
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
                    cmd.CommandText = "PROC_ADD_FEES";
                    cmd.Parameters.Add("@MEMBER_ID", SqlDbType.Int).Value = model.MEMBER_ID;
                    cmd.Parameters.Add("@PAID_AMOUNT", SqlDbType.Decimal).Value = model.PAID_AMOUNT;
                    cmd.Parameters.Add("@TOTAL_AMOUNT", SqlDbType.Decimal).Value = model.TOTAL_AMOUNT;
                    cmd.Parameters.Add("@PENDING_AMOUNT", SqlDbType.Decimal).Value = model.PENDING_AMOUNT;
                    cmd.Parameters.Add("@PAYMENT_ID", SqlDbType.Int).Value = model.PAYMENT_ID;
                   // cmd.Parameters.Add("@TRASACTION_NO", SqlDbType.VarChar).Value = model.TRASACTION_NO;
                    cmd.Parameters.Add("@ADDED_BY", SqlDbType.Int).Value = model.ADDED_BY;
                    cmd.Parameters.Add("@BATCH_ID", SqlDbType.Int).Value = model.BATCH_ID;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to added Payment" : "Payment added successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to add Payment";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public PayFeesPagingation GetPayFeesDetails(int FEES_MEMBER_ID,int USER_ID,DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            PayFeesPagingation _PayFeesPagingation = new PayFeesPagingation();
            List<PayFees> lstData = new List<PayFees>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_FEES_DETAILS";

                cmd.Parameters.Add("@FEES_MEMBER_HISTORY_ID", SqlDbType.Int).Value = FEES_MEMBER_ID;
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
                        lstData.Add(new PayFees
                        {
                            FEES_MEMBER_ID = Convert.ToInt32(dr["FEES_MEMBER_HISTORY_ID"]),
                            MEMBER_ID = Convert.ToInt32(dr["MEMBER_ID"]),
                            MEMBER_NAME = Convert.ToString(dr["MEMBER_NAME"]),
                            PAID_AMOUNT = Convert.ToDecimal(dr["PAID_AMOUNT"]),
                            TOTAL_AMOUNT = Convert.ToDecimal(dr["TOTAL_AMOUNT"]),
                            PENDING_AMOUNT = Convert.ToDecimal(dr["PENDING_AMOUNT"]),
                            PAYMENT_ID = Convert.ToInt32(dr["PAYMENT_ID"]),
                            TYPE_NAME = Convert.ToString(dr["TYPE_NAME"]),
                            TRASACTION_NO = Convert.ToString(dr["TRANSACTION_NO"]),
                            TRANSATION_DATETIME = Convert.ToString(dr["TRANSACTION_DATETIME"]),
                        });
                    }
                    _PayFeesPagingation.filteredCount = TotalRecord;
                    _PayFeesPagingation.PayFeesList = lstData;
                }
                con.Close();
            }

            return _PayFeesPagingation;
        }
        public List<BatchScheduledDateTime> GetBatchByMember(int MEMBERID,int USER_ID)
        {

            List<BatchScheduledDateTime> lstData = new List<BatchScheduledDateTime>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_BATCH_BY_MEMBER";
                cmd.Parameters.Add("@MEMBERID", SqlDbType.Int).Value = MEMBERID;
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new BatchScheduledDateTime
                        {
                            BATCH_ID = Convert.ToInt32(dr["BATCH_ID"]),
                            BATCH_NAME = Convert.ToString(dr["BATCH_NAME"]),
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public PayFeesPagingation GetTodayPayFeesHistory(int FEES_MEMBER_ID,int USER_ID, DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            PayFeesPagingation _PayFeesPagingation = new PayFeesPagingation();
            List<PayFees> lstData = new List<PayFees>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_TODAY_FEES_HISTORY";

                cmd.Parameters.Add("@FEES_MEMBER_HISTORY_ID", SqlDbType.Int).Value = FEES_MEMBER_ID;
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
                        lstData.Add(new PayFees
                        {
                            FEES_MEMBER_ID = Convert.ToInt32(dr["FEES_MEMBER_HISTORY_ID"]),
                            MEMBER_ID = Convert.ToInt32(dr["MEMBER_ID"]),
                            MEMBER_NAME = Convert.ToString(dr["MEMBER_NAME"]),
                            PAID_AMOUNT = Convert.ToDecimal(dr["PAID_AMOUNT"]),
                            TOTAL_AMOUNT = Convert.ToDecimal(dr["TOTAL_AMOUNT"]),
                            PENDING_AMOUNT = Convert.ToDecimal(dr["PENDING_AMOUNT"]),
                            PAYMENT_ID = Convert.ToInt32(dr["PAYMENT_ID"]),
                            TYPE_NAME = Convert.ToString(dr["TYPE_NAME"]),
                            TRASACTION_NO = Convert.ToString(dr["TRANSACTION_NO"]),
                            TRANSATION_DATETIME = Convert.ToString(dr["TRANSACTION_DATETIME"]),
                        });
                    }
                    _PayFeesPagingation.filteredCount = TotalRecord;
                    _PayFeesPagingation.PayFeesList = lstData;
                }
                con.Close();
            }

            return _PayFeesPagingation;
        }
    }
}
