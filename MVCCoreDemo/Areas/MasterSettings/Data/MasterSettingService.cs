using MVCCoreDemo.Areas.MasterSettings.Models;
using MVCCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreDemo.Areas.MasterSettings.Data
{
    public interface IMasterSettingService
    {
        List<Project> GetProject(int PROJECT_ID);
        MemberRegistrationPagingation GetMember(int MEMBERID, DataTableAjaxPostModel model);
        List<Gender> GetGender(int SEX_ID);
        ReturnResponse AddMember(MemberRegistration model);
        ReturnResponse UpdateMember(MemberRegistration model);
        BATCHPagingation GetBatch(int BATCH_ID, DataTableAjaxPostModel model);
        ReturnResponse AddBatch(BATCH model);
        ReturnResponse UpdateBatch(BATCH model);
        BatchMemberPagingation GetBatchMember(int BATCH_MEMBER_MAPPING_ID, DataTableAjaxPostModel model);
        ReturnResponse AddBatchMember(BatchMember model);
        ReturnResponse UpdateBatchMember(BatchMember model);
        List<MemberList> GetMemberList(int MEMBERID);
        List<BatchList> GetBatchList(int BATCH_ID);
        ReturnResponse AddTrainer(Trainer model);
        ReturnResponse UpdateTrainer(Trainer model);
        TrainerPagingation GetTrainerList(int TRAINER_ID, DataTableAjaxPostModel model);
        List<Specialisation> GetSpecialisationList(int SPECIALIZATION_ID);
        BatchTimingPagingation GetBatchTiming(int BATCH_TIMING_ID, DataTableAjaxPostModel model);
        ReturnResponse AddBatchTiming(BatchTiming model);
        ReturnResponse UpdateBatchTiming(BatchTiming model);
        List<TrainerList> GetTrainerList(int TRAINER_ID);
        ReturnResponse DeleteBatchTiming(int BATCH_TIMING_ID);
        BatchTimingPagingation GetBatchTimingCount(int BATCH_ID, DataTableAjaxPostModel model);
        List<BatchScheduledDateTime> GetBatchScheduledDateTimeList(int BATCH_TIMING_ID);
        PackagePagingation GetPackage(int PACKAGE_ID, DataTableAjaxPostModel model);
        ReturnResponse AddPackage(Package model);
        ReturnResponse UpdatePackage(Package model);
        List<Tax> GetTaxList(int TAX_ID);
        List<PackageList> GetPackageList(int TAX_ID);
        int GetBatchNoOfDays(int BATCH_ID);
        MemberRegistrationPagingation GetMemberToday(int MEMBERID, DataTableAjaxPostModel model);
    }
    public class MasterSettingService: IMasterSettingService
    {
        string CON_STRING = Startup.ConnectionString;
        public List<Project> GetProject(int PROJECT_ID)
        {

            List<Project> lstData = new List<Project>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_PROJECT";
                cmd.Parameters.Add("@PROJECT_ID", SqlDbType.Int).Value = PROJECT_ID;
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new Project
                        {
                            PROJECT_ID = Convert.ToInt32(dr["PROJECT_ID"]),
                            NAME = Convert.ToString(dr["NAME"]),
                            DESCRIPTION = Convert.ToString(dr["DESCRIPTION"]),
                            IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]),
                            IS_DELETED = Convert.ToBoolean(dr["IS_DELETED"])
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public MemberRegistrationPagingation GetMember(int MEMBERID, DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            MemberRegistrationPagingation _MemberRegistrationPagingation = new MemberRegistrationPagingation();
            List<MemberRegistration> lstData = new List<MemberRegistration>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_MEMBER";

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
        public List<Gender> GetGender(int MEMBERID)
        {

            List<Gender> lstData = new List<Gender>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_GENDER";
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new Gender
                        {
                            SEX_ID = Convert.ToInt32(dr["SEX_ID"]),
                            SEX = Convert.ToString(dr["SEX"]),
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public ReturnResponse AddMember(MemberRegistration model)
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
                    cmd.CommandText = "PROC_ADD_MEMBER";
                    cmd.Parameters.Add("@MEMBERID", SqlDbType.VarChar).Value = model.MEMBERID;
                    cmd.Parameters.Add("@FIRSTNAME", SqlDbType.VarChar).Value = model.FIRSTNAME;
                    cmd.Parameters.Add("@LASTNAME", SqlDbType.VarChar).Value = model.LASTNAME;
                    cmd.Parameters.Add("@GENDER", SqlDbType.Int).Value = model.GENDER_ID;
                    cmd.Parameters.Add("@DATEOFBIRTH", SqlDbType.VarChar).Value = model.DATEOFBIRTH;
                    cmd.Parameters.Add("@CONTACTNUMBER", SqlDbType.VarChar).Value = model.CONTACTNUMBER;
                    cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = model.EMAIL;
                    cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = model.ADDRESS;
                    cmd.Parameters.Add("@ADDED_BY", SqlDbType.Int).Value = model.ADDED_BY;
                    cmd.Parameters.Add("@IMAGEDATA", SqlDbType.VarChar).Value = model.IMAGEDATA;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to added member" : "Member added successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to add member";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public ReturnResponse UpdateMember(MemberRegistration model)
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
                    cmd.CommandText = "PROC_UPDATE_MEMBER";
                    cmd.Parameters.Add("@MEMBERID", SqlDbType.VarChar).Value = model.MEMBERID;
                    cmd.Parameters.Add("@FIRSTNAME", SqlDbType.VarChar).Value = model.FIRSTNAME;
                    cmd.Parameters.Add("@LASTNAME", SqlDbType.VarChar).Value = model.LASTNAME;
                    cmd.Parameters.Add("@GENDER", SqlDbType.Int).Value = model.GENDER_ID;
                    cmd.Parameters.Add("@DATEOFBIRTH", SqlDbType.DateTime).Value = model.DATEOFBIRTH;
                    cmd.Parameters.Add("@CONTACTNUMBER", SqlDbType.VarChar).Value = model.CONTACTNUMBER;
                    cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = model.EMAIL;
                    cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = model.ADDRESS;
                    cmd.Parameters.Add("@IMAGEDATA", SqlDbType.VarChar).Value = model.IMAGEDATA;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to update member" : "Member updated successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to update member";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public BATCHPagingation GetBatch(int BATCH_ID, DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            BATCHPagingation _BATCHPagingation = new BATCHPagingation();
            List<BATCH> lstData = new List<BATCH>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_BATCH";

                cmd.Parameters.Add("@BATCH_ID", SqlDbType.Int).Value = BATCH_ID;
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
                        lstData.Add(new BATCH
                        {
                            BATCH_ID = Convert.ToInt32(dr["BATCH_ID"]),
                            NAME = Convert.ToString(dr["NAME"]),
                            DESCRIPTION = Convert.ToString(dr["DESCRIPTION"]),
                            FROM_DATE = Convert.ToString(dr["FROM_DATE"]),
                            TO_DATE = Convert.ToString(dr["TO_DATE"]),
                            AMOUNT = Convert.ToDecimal(dr["AMOUNT"]),
                            TAX_ID = Convert.ToInt32(dr["TAX_ID"]),
                            TAX_NAME = Convert.ToString(dr["TAX_NAME"]),
                            GST_AMOUNT = Convert.ToDecimal(dr["GST_AMOUNT"]),
                            TOTAL_AMOUNT = Convert.ToDecimal(dr["TOTAL_AMOUNT"]),
                            NO_OF_DAYS = Convert.ToInt32(dr["NO_OF_DAYS"]),
                        });
                    }
                    _BATCHPagingation.filteredCount = TotalRecord;
                    _BATCHPagingation.BatchList = lstData;
                }
                con.Close();
            }

            return _BATCHPagingation;
        }
        public ReturnResponse AddBatch(BATCH model)
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
                    cmd.CommandText = "PROC_ADD_BATCH";
                    cmd.Parameters.Add("@NAME", SqlDbType.VarChar).Value = model.NAME;
                    cmd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar).Value = model.DESCRIPTION;
                    cmd.Parameters.Add("@FROM_DATE", SqlDbType.Date).Value = model.FROM_DATE;
                    cmd.Parameters.Add("@TO_DATE", SqlDbType.Date).Value = model.TO_DATE;
                    cmd.Parameters.Add("@AMOUNT", SqlDbType.Decimal).Value = model.AMOUNT;
                    cmd.Parameters.Add("@TAX_ID", SqlDbType.Int).Value = model.TAX_ID;
                    cmd.Parameters.Add("@GST_AMOUNT", SqlDbType.Decimal).Value = model.GST_AMOUNT;
                    cmd.Parameters.Add("@TOTAL_AMOUNT", SqlDbType.Decimal).Value = model.TOTAL_AMOUNT;
                    cmd.Parameters.Add("@NO_OF_DAYS", SqlDbType.Int).Value = model.NO_OF_DAYS;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to added Batch" : "Batch added successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to add Batch";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public ReturnResponse UpdateBatch(BATCH model)
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
                    cmd.CommandText = "PROC_UPDATE_BATCH";
                    cmd.Parameters.Add("@BATCH_ID", SqlDbType.Int).Value = model.BATCH_ID;
                    cmd.Parameters.Add("@NAME", SqlDbType.VarChar).Value = model.NAME;
                    cmd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar).Value = model.DESCRIPTION;
                    cmd.Parameters.Add("@FROM_DATE", SqlDbType.Date).Value = model.FROM_DATE;
                    cmd.Parameters.Add("@TO_DATE", SqlDbType.Date).Value = model.TO_DATE;
                    cmd.Parameters.Add("@AMOUNT", SqlDbType.Decimal).Value = model.AMOUNT;
                    cmd.Parameters.Add("@TAX_ID", SqlDbType.Int).Value = model.TAX_ID;
                    cmd.Parameters.Add("@GST_AMOUNT", SqlDbType.Decimal).Value = model.GST_AMOUNT;
                    cmd.Parameters.Add("@TOTAL_AMOUNT", SqlDbType.Decimal).Value = model.TOTAL_AMOUNT;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to update Batch" : "Batch update successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to update Batch";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public BatchMemberPagingation GetBatchMember(int BATCH_MEMBER_MAPPING_ID, DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            BatchMemberPagingation _BATCHPagingation = new BatchMemberPagingation();
            List<BatchMember> lstData = new List<BatchMember>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_BATCH_MEMBER";

                cmd.Parameters.Add("@BATCH_MEMBER_MAPPING_ID", SqlDbType.Int).Value = BATCH_MEMBER_MAPPING_ID;
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
                        lstData.Add(new BatchMember
                        {
                            BATCH_MEMBER_MAPPING_ID = Convert.ToInt32(dr["BATCH_MEMBER_MAPPING_ID"]),
                            MEMBERID = Convert.ToInt32(dr["MEMBERID"]),
                            MEMBERNAME = Convert.ToString(dr["MEMBERNAME"]),
                            BATCH_ID = Convert.ToInt32(dr["BATCH_ID"]),
                            BATCHNAME = Convert.ToString(dr["BATCHNAME"]),
                            START_DATE = Convert.ToString(dr["START_DATE"]),
                            END_DATE = Convert.ToString(dr["END_DATE"]),
                            PACKAGE_ID = Convert.ToInt32(dr["PACKAGE_ID"]),
                            IS_ON_HOLD = Convert.ToBoolean(dr["IS_ON_HOLD"]),
                            NEXT_FEES_DATETIME = Convert.ToString(dr["NEXT_FEES_DATETIME"]),
                            IS_ACTIVE = Convert.ToBoolean(dr["IS_ACTIVE"]),
                        });
                    }
                    _BATCHPagingation.filteredCount = TotalRecord;
                    _BATCHPagingation.BatchMemberList = lstData;
                }
                con.Close();
            }

            return _BATCHPagingation;
        }
        public ReturnResponse AddBatchMember(BatchMember model)
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
                    cmd.CommandText = "PROC_ADD_BATCH_MEMBER";
                    cmd.Parameters.Add("@BATCH_MEMBER_MAPPING_ID", SqlDbType.Int).Value = model.BATCH_MEMBER_MAPPING_ID;
                    cmd.Parameters.Add("@MEMBERID", SqlDbType.Int).Value = model.MEMBERID;
                    cmd.Parameters.Add("@BATCH_ID", SqlDbType.Int).Value = model.BATCH_ID;
                    cmd.Parameters.Add("@START_DATE", SqlDbType.Date).Value = model.START_DATE;
                    cmd.Parameters.Add("@END_DATE", SqlDbType.Date).Value = model.END_DATE;
                    cmd.Parameters.Add("@ADDED_BY", SqlDbType.Int).Value = model.ADDED_BY;
                    cmd.Parameters.Add("@PACKAGE_ID", SqlDbType.Int).Value = model.PACKAGE_ID;
                    cmd.Parameters.Add("@NEXT_FEES_DATETIME", SqlDbType.Date).Value = model.NEXT_FEES_DATETIME;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Member already register with same batch" : "Batch added successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to add Batch Member";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public ReturnResponse UpdateBatchMember(BatchMember model)
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
                    cmd.CommandText = "PROC_UPDATE_BATCH_MEMBER";
                    cmd.Parameters.Add("@BATCH_MEMBER_MAPPING_ID", SqlDbType.Int).Value = model.BATCH_MEMBER_MAPPING_ID;
                    cmd.Parameters.Add("@MEMBERID", SqlDbType.Int).Value = model.MEMBERID;
                    cmd.Parameters.Add("@BATCH_ID", SqlDbType.Int).Value = model.BATCH_ID;
                    cmd.Parameters.Add("@START_DATE", SqlDbType.Date).Value = model.START_DATE;
                    cmd.Parameters.Add("@END_DATE", SqlDbType.Date).Value = model.END_DATE;
                    cmd.Parameters.Add("@PACKAGE_ID", SqlDbType.Int).Value = model.PACKAGE_ID;
                    cmd.Parameters.Add("@IS_ON_HOLD", SqlDbType.Bit).Value = model.IS_ON_HOLD;
                    cmd.Parameters.Add("@NEXT_FEES_DATETIME", SqlDbType.Date).Value = model.NEXT_FEES_DATETIME;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to update batch member" : "Batch member updated successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to update Batch Member";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public List<MemberList> GetMemberList(int MEMBERID)
        {

            List<MemberList> lstData = new List<MemberList>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_MEMBER_LIST";
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new MemberList
                        {
                            MEMBERID = Convert.ToInt32(dr["MEMBERID"]),
                            NAME = Convert.ToString(dr["NAME"]),
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public List<BatchList> GetBatchList(int BATCH_ID)
        {

            List<BatchList> lstData = new List<BatchList>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_BATCH_LIST";
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new BatchList
                        {
                            BATCH_ID = Convert.ToInt32(dr["BATCH_ID"]),
                            NAME = Convert.ToString(dr["NAME"]),
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public ReturnResponse AddTrainer(Trainer model)
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
                    cmd.CommandText = "PROC_ADD_TRAINER";
                    cmd.Parameters.Add("@FIRSTNAME", SqlDbType.VarChar).Value = model.FIRSTNAME;
                    cmd.Parameters.Add("@LASTNAME", SqlDbType.VarChar).Value = model.LASTNAME;
                    cmd.Parameters.Add("@GENDER", SqlDbType.Int).Value = model.GENDER_ID;
                    cmd.Parameters.Add("@CONTACTNUMBER", SqlDbType.VarChar).Value = model.CONTACTNUMBER;
                    cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = model.EMAIL;
                    cmd.Parameters.Add("@SPECIALIZATION_ID", SqlDbType.Int).Value = model.SPECIALIZATION_ID;
                    cmd.Parameters.Add("@ADDED_BY", SqlDbType.Int).Value = model.ADDED_BY;
                    cmd.Parameters.Add("@DATEOFBIRTH", SqlDbType.Date).Value = model.DATEOFBIRTH;
                    cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = model.ADDRESS;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to added Trainer" : "Trainer added successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to add Trainer";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public ReturnResponse UpdateTrainer(Trainer model)
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
                    cmd.CommandText = "PROC_UPDATE_TRAINER";
                    cmd.Parameters.Add("@TRAINER_ID", SqlDbType.Int).Value = model.TRAINER_ID;
                    cmd.Parameters.Add("@FIRSTNAME", SqlDbType.VarChar).Value = model.FIRSTNAME;
                    cmd.Parameters.Add("@LASTNAME", SqlDbType.VarChar).Value = model.LASTNAME;
                    cmd.Parameters.Add("@GENDER", SqlDbType.Int).Value = model.GENDER_ID;
                    cmd.Parameters.Add("@CONTACTNUMBER", SqlDbType.VarChar).Value = model.CONTACTNUMBER;
                    cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = model.EMAIL;
                    cmd.Parameters.Add("@SPECIALIZATION_ID", SqlDbType.Int).Value = model.SPECIALIZATION_ID;
                    cmd.Parameters.Add("@ADDED_BY", SqlDbType.Int).Value = model.ADDED_BY;
                    cmd.Parameters.Add("@DATEOFBIRTH", SqlDbType.DateTime).Value = model.DATEOFBIRTH;
                    cmd.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = model.ADDRESS;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to update Trainer" : "Trainer update successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to update Trainer";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public TrainerPagingation GetTrainerList(int TRAINER_ID, DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            TrainerPagingation _MemberRegistrationPagingation = new TrainerPagingation();
            List<Trainer> lstData = new List<Trainer>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_TRAINER";

                cmd.Parameters.Add("@TRAINER_ID", SqlDbType.Int).Value = TRAINER_ID;
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
                        lstData.Add(new Trainer
                        {
                            TRAINER_ID = Convert.ToInt32(dr["TRAINER_ID"]),
                            FIRSTNAME = Convert.ToString(dr["FIRSTNAME"]),
                            LASTNAME = Convert.ToString(dr["LASTNAME"]),
                            GENDER_ID = Convert.ToInt32(dr["GENDER_ID"]),
                            GENDER_NAME = Convert.ToString(dr["GENDER_NAME"]),
                            DATEOFBIRTH = Convert.ToString(dr["DATEOFBIRTH"]),
                            CONTACTNUMBER = Convert.ToString(dr["CONTACTNUMBER"]),
                            EMAIL = Convert.ToString(dr["EMAIL"]),
                            ADDRESS = Convert.ToString(dr["ADDRESS"]),
                            ADDED_DATE = Convert.ToString(dr["ADDED_DATETIME"]),
                            SPECIALIZATION_ID = Convert.ToInt32(dr["SPECIALIZATION_ID"]),
                            SPECIALIZATION_NAME = Convert.ToString(dr["SPECIALIZATION_NAME"])
                        });
                    }
                    _MemberRegistrationPagingation.filteredCount = TotalRecord;
                    _MemberRegistrationPagingation.MemberList = lstData;
                }
                con.Close();
            }

            return _MemberRegistrationPagingation;
        }
        public List<Specialisation> GetSpecialisationList(int SPECIALIZATION_ID)
        {

            List<Specialisation> lstData = new List<Specialisation>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_SPECIALIZATION";
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new Specialisation
                        {
                            SPECIALIZATION_ID = Convert.ToInt32(dr["SPECIALIZATION_ID"]),
                            NAME = Convert.ToString(dr["NAME"])
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public BatchTimingPagingation GetBatchTiming(int BATCH_TIMING_ID, DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            BatchTimingPagingation _BatchTimingPagingation = new BatchTimingPagingation();
            List<BatchTiming> lstData = new List<BatchTiming>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_BATCH_TIMIING";

                cmd.Parameters.Add("@BATCH_TIMING_ID", SqlDbType.Int).Value = BATCH_TIMING_ID;
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
                        lstData.Add(new BatchTiming
                        {
                            BATCH_TIMING_ID = Convert.ToInt32(dr["BATCH_TIMING_ID"]),
                            BATCH_ID = Convert.ToInt32(dr["BATCH_ID"]),
                            BATCH_NAME = Convert.ToString(dr["BATCH_NAME"]),
                            TRAINER_ID = Convert.ToInt32(dr["TRAINER_ID"]),
                            TRAINER_NAME = Convert.ToString(dr["TRAINER_NAME"]),
                            FROM_DATE = Convert.ToString(dr["FROM_DATE"]),
                            TO_DATE = Convert.ToString(dr["TO_DATE"]),
                            FROM_TIME = Convert.ToString(dr["FROM_TIME"]),
                            TO_TIME = Convert.ToString(dr["TO_TIME"]),
                        });
                    }
                    _BatchTimingPagingation.filteredCount = TotalRecord;
                    _BatchTimingPagingation.BatchTimingList = lstData;
                }
                con.Close();
            }

            return _BatchTimingPagingation;
        }
        public ReturnResponse AddBatchTiming(BatchTiming model)
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
                    cmd.CommandText = "PROC_ADD_BATCH_TIMING";
                    cmd.Parameters.Add("@BATCH_ID", SqlDbType.VarChar).Value = model.BATCH_ID;
                    cmd.Parameters.Add("@TRAINER_ID", SqlDbType.VarChar).Value = model.TRAINER_ID;
                    //cmd.Parameters.Add("@FROM_DATE", SqlDbType.Date).Value = model.FROM_DATE;
                    //cmd.Parameters.Add("@TO_DATE", SqlDbType.Date).Value = model.TO_DATE;
                    //cmd.Parameters.Add("@FROM_TIME", SqlDbType.Time).Value = model.FROM_TIME;
                    //cmd.Parameters.Add("@TO_TIME", SqlDbType.Time).Value = model.TO_TIME;
                    cmd.Parameters.Add("@ADDED_BY", SqlDbType.Int).Value = model.ADDED_BY;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to added Batch Timing" : "Batch Timing added successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to add Batch Timing";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public ReturnResponse UpdateBatchTiming(BatchTiming model)
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
                    cmd.CommandText = "PROC_UPDATE_BATCH_TIMING";

                    cmd.Parameters.Add("@BATCH_TIMING_ID", SqlDbType.VarChar).Value = model.BATCH_TIMING_ID;
                    cmd.Parameters.Add("@BATCH_ID", SqlDbType.VarChar).Value = model.BATCH_ID;
                    cmd.Parameters.Add("@TRAINER_ID", SqlDbType.VarChar).Value = model.TRAINER_ID;
                    //cmd.Parameters.Add("@FROM_DATE", SqlDbType.Date).Value = model.FROM_DATE;
                    //cmd.Parameters.Add("@TO_DATE", SqlDbType.Date).Value = model.TO_DATE;
                    //cmd.Parameters.Add("@FROM_TIME", SqlDbType.Time).Value = model.FROM_TIME;
                    //cmd.Parameters.Add("@TO_TIME", SqlDbType.Time).Value = model.TO_TIME;
                    cmd.Parameters.Add("@ADDED_BY", SqlDbType.Int).Value = model.ADDED_BY;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to update Batch Timing" : "Batch Timing updated successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to update Batch Timing";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public List<TrainerList> GetTrainerList(int TRAINER_ID)
        {

            List<TrainerList> lstData = new List<TrainerList>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_TRAINER_LIST";
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new TrainerList
                        {
                            TRAINER_ID = Convert.ToInt32(dr["TRAINER_ID"]),
                            TRAINER_NAME = Convert.ToString(dr["TRAINER_NAME"]),
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public ReturnResponse DeleteBatchTiming(int  BATCH_TIMING_ID)
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
                    cmd.CommandText = "PROC_DELETE_BATCH_TIMING";
                    cmd.Parameters.Add("@BATCH_TIMING_ID", SqlDbType.Int).Value = BATCH_TIMING_ID;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to delete Batch timing" : "Batch timing delete successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to delete Batch timing";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public BatchTimingPagingation GetBatchTimingCount(int BATCH_ID, DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            BatchTimingPagingation _BatchTimingPagingation = new BatchTimingPagingation();
            List<BatchTiming> lstData = new List<BatchTiming>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_BATCH_TIMING_COUNT";

                cmd.Parameters.Add("@BATCH_ID", SqlDbType.Int).Value = BATCH_ID;
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
                        lstData.Add(new BatchTiming
                        {
                            BATCH_ID = Convert.ToInt32(dr["BATCH_ID"]),
                            BATCH_NAME = Convert.ToString(dr["BATCH_NAME"]),
                            TRAINER_ID = Convert.ToInt32(dr["TRAINER_ID"]),
                            TRAINER_NAME = Convert.ToString(dr["TRAINER_NAME"]),
                            _NO_OF_BATCH_COUNT = Convert.ToInt32(dr["_NO_OF_BATCH_COUNT"]),
                            BATCH_TIMING_ID = Convert.ToInt32(dr["BATCH_TIMING_ID"]),
                        });
                    }
                    _BatchTimingPagingation.filteredCount = TotalRecord;
                    _BatchTimingPagingation.BatchTimingList = lstData;
                }
                con.Close();
            }

            return _BatchTimingPagingation;
        }
        public List<BatchScheduledDateTime> GetBatchScheduledDateTimeList(int BATCH_TIMING_ID)
        {

            List<BatchScheduledDateTime> lstData = new List<BatchScheduledDateTime>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_BATCH_SCHEDULED_DATETIME_LIST";
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new BatchScheduledDateTime
                        {
                            BATCH_TIMING_ID = Convert.ToInt32(dr["BATCH_TIMING_ID"]),
                            BATCH_NAME = Convert.ToString(dr["BATCH_NAME"]),
                            BATCH_DATETIME = Convert.ToString(dr["BATCH_DATETIME"]),
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public PackagePagingation GetPackage(int PACKAGE_ID, DataTableAjaxPostModel model)
        {
            int TotalRecord = 0;
            PackagePagingation _BATCHPagingation = new PackagePagingation();
            List<Package> lstData = new List<Package>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_PACKAGE_MANAGEMENT";

                cmd.Parameters.Add("@PACKAGE_ID", SqlDbType.Int).Value = PACKAGE_ID;
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
                        lstData.Add(new Package
                        {
                            PACKAGE_ID = Convert.ToInt32(dr["PACKAGE_ID"]),
                            TITLE = Convert.ToString(dr["TITLE"]),
                            DESCRIPTION = Convert.ToString(dr["DESCRIPTION"]),
                            FEES = Convert.ToDecimal(dr["FEES"]),
                            TAX_ID = Convert.ToInt32(dr["TAX_ID"]),
                            TAX_NAME = Convert.ToString(dr["TAX_NAME"]),
                            TOTAL_FEES = Convert.ToDecimal(dr["TOTAL_FEES"]),
                        });
                    }
                    _BATCHPagingation.filteredCount = TotalRecord;
                    _BATCHPagingation.PackageList = lstData;
                }
                con.Close();
            }

            return _BATCHPagingation;
        }
        public ReturnResponse AddPackage(Package model)
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
                    cmd.CommandText = "PROC_ADD_PACKAGE_MANAGEMENT";
                    cmd.Parameters.Add("@TITLE", SqlDbType.VarChar).Value = model.TITLE;
                    cmd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar).Value = model.DESCRIPTION;
                    cmd.Parameters.Add("@FEES", SqlDbType.Decimal).Value = model.FEES;
                    cmd.Parameters.Add("@TAX_ID", SqlDbType.Int).Value = model.TAX_ID;
                    cmd.Parameters.Add("@ADDED_BY", SqlDbType.Int).Value = model.ADDED_BY;
                    cmd.Parameters.Add("@TOTAL_FEES", SqlDbType.Decimal).Value = model.TOTAL_FEES;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to added Package" : "Package added successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to add Package";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public ReturnResponse UpdatePackage(Package model)
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
                    cmd.CommandText = "PROC_UPDATE_PACKAGE_MANAGEMENT";
                    cmd.Parameters.Add("@PACKAGE_ID", SqlDbType.Int).Value = model.PACKAGE_ID;
                    cmd.Parameters.Add("@TITLE", SqlDbType.VarChar).Value = model.TITLE;
                    cmd.Parameters.Add("@DESCRIPTION", SqlDbType.VarChar).Value = model.DESCRIPTION;
                    cmd.Parameters.Add("@FEES", SqlDbType.Decimal).Value = model.FEES;
                    cmd.Parameters.Add("@TAX_ID", SqlDbType.Int).Value = model.TAX_ID;
                    cmd.Parameters.Add("@UPDATED_BY", SqlDbType.Decimal).Value = model.UPDATED_BY;
                    cmd.Parameters.Add("@TOTAL_FEES", SqlDbType.Decimal).Value = model.TOTAL_FEES;

                    cmd.Parameters.Add("@RowCount", SqlDbType.Int);
                    cmd.Parameters["@RowCount"].Direction = ParameterDirection.Output;

                    con.Open();
                    objReturn = cmd.ExecuteScalar();
                    RowsAffected = Convert.ToBoolean(cmd.Parameters["@RowCount"].Value);
                    con.Close();
                    _returnResponse.RESPONSEMESSAGE = (RowsAffected == false) ? "Enabled to update Package" : "Package updated successfully";
                    _returnResponse.RESPONSETYPE = (RowsAffected == false) ? "0" : "1";
                }
            }
            catch (Exception ex)
            {
                _returnResponse.RESPONSEMESSAGE = "Enabled to update Package";
                _returnResponse.RESPONSETYPE = "0";
            }

            return _returnResponse;
        }
        public List<Tax> GetTaxList(int TAX_ID)
        {

            List<Tax> lstData = new List<Tax>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_TAX_LIST";
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new Tax
                        {
                            TAX_ID = Convert.ToInt32(dr["TAX_ID"]),
                            TAX_NAME = Convert.ToString(dr["TAX_NAME"]),
                            DEDUCATION_PERCENT = Convert.ToDecimal(dr["DEDUCATION_PERCENT"]),
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public List<PackageList> GetPackageList(int TAX_ID)
        {

            List<PackageList> lstData = new List<PackageList>();

            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_PACKAGE_LIST";
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lstData.Add(new PackageList
                        {
                            PACKAGE_ID = Convert.ToInt32(dr["PACKAGE_ID"]),
                            TITLE = Convert.ToString(dr["TITLE"])
                        });
                    }
                }
                con.Close();
            }

            return lstData;
        }
        public int GetBatchNoOfDays(int BATCH_ID)
        {
            int NoOfDays = 0;
            using (SqlConnection con = new SqlConnection(CON_STRING))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PROC_GET_BATCH_NO_DAYS";
                cmd.Parameters.Add("@BATCH_ID", SqlDbType.Int).Value = BATCH_ID;
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        NoOfDays = Convert.ToInt32(dr["NO_OF_DAYS"]);
                    }
                }
                con.Close();
            }

            return NoOfDays;
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
    }
}
