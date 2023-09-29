using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAL
{
    public class DAL_HOUR_METER_HMR_READING
    {
        //public string INSERT_HOUR_METER_HMR_READING(string Comp_Code, string Branch_Code, string Emp_Code, HourMeterReport MeterReading)
        //{
        //    string errorMsg = "";

        //    using (var connection = new SqlConnection(sqlConnection.GetConnectionString_SGX()))
        //    {
        //        connection.Open();
        //        SqlCommand command;
        //        SqlTransaction transactionScope = null;
        //        transactionScope = connection.BeginTransaction(IsolationLevel.ReadCommitted);
        //        try
        //        {
        //            SqlParameter[] param =
        //            { 
        //              new SqlParameter("@ERRORSTR", SqlDbType.VarChar, 200)
        //             ,new SqlParameter("@HMR_ID	", SqlDbType.Decimal)  
        //             ,new SqlParameter("@COMP_CODE", Comp_Code)
        //             ,new SqlParameter("@BRANCH_CODE", Branch_Code)
        //             ,new SqlParameter("@SHIFT_TIME", (MeterReading.SHIFT_Code == null)?(object)DBNull.Value : MeterReading.SHIFT_Code)    
        //             ,new SqlParameter("@PRODUCTION_DATE", MeterReading.PRODUCTION_DATE)
        //             ,new SqlParameter("@ADDED_BY", Emp_Code)  
        //            };

        //            param[0].Direction = ParameterDirection.Output;
        //            param[1].Direction = ParameterDirection.Output;

        //            new DataAccess().InsertWithTransaction("[AGG].[USP_INSERT_HOUR_METER_READING_HDR]", CommandType.StoredProcedure, out command, connection, transactionScope, param);
        //            decimal HMR_ID = (decimal)command.Parameters["@HMR_ID"].Value;
        //            string error_1 = (string)command.Parameters["@ERRORSTR"].Value;
        //            if (HMR_ID == -1) { errorMsg = error_1; }

        //            if (HMR_ID > 0)
        //            {
        //                if (MeterReading.HourMeterDtl_List != null)
        //                {
        //                    foreach (HourMeterReport_Dtl item in MeterReading.HourMeterDtl_List)
        //                    {
        //                        SqlParameter[] param2 =
        //                            {
        //                               new SqlParameter("@ERRORSTR", SqlDbType.VarChar, 200)
        //                              ,new SqlParameter("@HMRR_ID", SqlDbType.Decimal)  
        //                              ,new SqlParameter("@HMR_ID", MeterReading.HMR_ID)  
        //                              ,new SqlParameter("@PM_ID", item.PM_ID)
        //                              //,new SqlParameter("@PM_NAME" , item.PM_NAME) 
        //                              ,new SqlParameter("@START", (item.Start == null)? (object)DBNull.Value : item.Start) 
        //                              ,new SqlParameter("@TOTAL_TIME", (item.Total== null)? (object)DBNull.Value : item.Total) 
        //                              ,new SqlParameter("@END  ", (item.End == null)? (object)DBNull.Value : item.End)  
        //                              ,new SqlParameter("@REMARKS", item.Remarks)  
        //                            };
        //                        param2[0].Direction = ParameterDirection.Output;
        //                        param2[1].Direction = ParameterDirection.Output;
        //                        new DataAccess().InsertWithTransaction("[AGG].[USP_INSERT_HOUR_METER_READING_dtl]", CommandType.StoredProcedure, out command, connection, transactionScope, param2);
        //                        decimal HMRR_ID = (decimal)command.Parameters["@HMRR_ID"].Value;
        //                        string error_2 = (string)command.Parameters["@ERRORSTR"].Value;
        //                        if (HMRR_ID == -1) { errorMsg = error_2; break; }


        //                    }
        //                }

        //            }

        //            if (errorMsg == "")
        //            {
        //                transactionScope.Commit();
        //            }
        //            else
        //            {
        //                transactionScope.Rollback();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            try
        //            {
        //                transactionScope.Rollback();
        //            }
        //            catch (Exception ex1)
        //            {
        //                errorMsg = "Error: Exception occured. " + ex1.StackTrace.ToString();
        //            }
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return errorMsg;
        //}
        public string INSERT_HOUR_METER_HMR_READING(string Comp_Code, string Branch_Code, string Emp_Code, HourMeterReport MeterReading)
        {
            string errorMsg = "";

            using (var connection = new SqlConnection(sqlConnection.GetConnectionString_SGX()))
            {
                connection.Open();
                SqlCommand command;
                SqlTransaction transactionScope = null;
                transactionScope = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    SqlParameter[] param =
                    { 
                      new SqlParameter("@ERRORSTR", SqlDbType.VarChar, 200)
                     ,new SqlParameter("@HMR_ID	", SqlDbType.Decimal)  
                     ,new SqlParameter("@COMP_CODE", Comp_Code)
                     ,new SqlParameter("@BRANCH_CODE", Branch_Code)
                     ,new SqlParameter("@SHIFT_TIME", (MeterReading.SHIFT_Code == null)?(object)DBNull.Value : MeterReading.SHIFT_Code)    
                     ,new SqlParameter("@PRODUCTION_DATE", MeterReading.PRODUCTION_DATE)
                     ,new SqlParameter("@ADDED_BY", Emp_Code)  
                    };

                    param[0].Direction = ParameterDirection.Output;
                    param[1].Direction = ParameterDirection.Output;

                    new DataAccess().InsertWithTransaction("[AGG].[USP_INSERT_HOUR_METER_READING_HDR]", CommandType.StoredProcedure, out command, connection, transactionScope, param);
                    decimal HMR_ID = (decimal)command.Parameters["@HMR_ID"].Value;
                    string error_1 = (string)command.Parameters["@ERRORSTR"].Value;
                    if (HMR_ID == -1) { errorMsg = error_1; }

                    //if (HMR_ID > 0)
                    //{
                    //    if (MeterReading.HourMeterDtl_List != null)
                    //    {
                    //        foreach (HourMeterReport_Dtl item in MeterReading.HourMeterDtl_List)
                    //        {
                    //            SqlParameter[] param2 =
                    //                {
                    //                   new SqlParameter("@ERRORSTR", SqlDbType.VarChar, 200)
                    //                  ,new SqlParameter("@HMRR_ID", SqlDbType.Decimal)  
                    //                  ,new SqlParameter("@HMR_ID", MeterReading.HMR_ID)  
                    //                  ,new SqlParameter("@PM_ID", item.PM_ID)
                    //                  //,new SqlParameter("@PM_NAME" , item.PM_NAME) 
                    //                  ,new SqlParameter("@START", (item.Start == null)? (object)DBNull.Value : item.Start) 
                    //                  ,new SqlParameter("@TOTAL_TIME", (item.Total== null)? (object)DBNull.Value : item.Total) 
                    //                  ,new SqlParameter("@END  ", (item.End == null)? (object)DBNull.Value : item.End)  
                    //                  ,new SqlParameter("@REMARKS", item.Remarks)  
                    //                };
                    //            param2[0].Direction = ParameterDirection.Output;
                    //            param2[1].Direction = ParameterDirection.Output;
                    //            new DataAccess().InsertWithTransaction("[AGG].[USP_INSERT_HOUR_METER_READING_dtl]", CommandType.StoredProcedure, out command, connection, transactionScope, param2);
                    //            decimal HMRR_ID = (decimal)command.Parameters["@HMRR_ID"].Value;
                    //            string error_2 = (string)command.Parameters["@ERRORSTR"].Value;
                    //            if (HMRR_ID == -1) { errorMsg = error_2; break; }


                    //        }
                    //    }

                    //}

                    if (errorMsg == "")
                    {
                        transactionScope.Commit();
                    }
                    else
                    {
                        transactionScope.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        transactionScope.Rollback();
                    }
                    catch (Exception ex1)
                    {
                        errorMsg = "Error: Exception occured. " + ex1.StackTrace.ToString();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return errorMsg;
        }
        public List<HourMeterReport_Dtl> GET_HOUR_METER_READING_DTLS(string Comp_Code, string Branch_Code, string Shift_Time, string PRODUCTION_DATE)
        {
            SqlParameter[] param = { 
                                       new SqlParameter("@COMP_CODE", Comp_Code),
                                       new SqlParameter("@BRANCH_CODE", Branch_Code),
                                       new SqlParameter("@SHIFT_TIME", Shift_Time), 
                                       new SqlParameter("@PRODUCTION_DATE", PRODUCTION_DATE),
                            
                     
                                   };

            DataTable dt = new DataAccess(sqlConnection.GetConnectionString_SGX()).GetDataTable("[AGG].[USP_SELECT_HOUR_METER_READING_DTLS]", CommandType.StoredProcedure, param);
            List<HourMeterReport_Dtl> list = new List<HourMeterReport_Dtl>();


            HourMeterReport_Dtl dtl = null;

            foreach (DataRow row in dt.Rows)
            {
                dtl = new HourMeterReport_Dtl();
                dtl.HMRR_ID = Convert.ToDecimal(row["HMRR_ID"] == DBNull.Value ? 0 : row["HMRR_ID"]);
                //dtl.HMR_ID = Convert.ToDecimal(row["HMR_ID"] == DBNull.Value ? 0 : row["HMR_ID"]);
                dtl.PM_ID = Convert.ToInt32(row["PM_ID"] == DBNull.Value ? 0 : row["PM_ID"]);

                dtl.PM_NAME = Convert.ToString(row["PM_NAME"] == DBNull.Value ? "" : row["PM_NAME"]);
                dtl.Start = Convert.ToDecimal(row["START"] == DBNull.Value ? 0 : row["START"]);

                dtl.End = Convert.ToDecimal(row["END"] == DBNull.Value ? 0 : row["END"]);

                dtl.Total = Convert.ToDecimal(row["TOTAL_TIME"] == DBNull.Value ? 0 : row["TOTAL_TIME"]);
                dtl.Remarks = Convert.ToString(row["REMARKS"] == DBNull.Value ? "" : row["REMARKS"]);
                dtl.IS_LOCKED = Convert.ToInt32(row["IS_LOCKED"] == DBNull.Value ? 0 : row["IS_LOCKED"]);   
                list.Add(dtl);

            }
            return list;
        }




        //public string UPDATE_HOUR_METER_READING_LOCK(string Emp_Code, decimal HMR_ID)
        //{
        //    string errorMsg = "";

        //    using (var connection = new SqlConnection(sqlConnection.GetConnectionString_SGX()))
        //    {
        //        connection.Open();
        //        SqlCommand command;
        //        SqlTransaction transactionScope = null;
        //        transactionScope = connection.BeginTransaction(IsolationLevel.ReadCommitted);
        //        try
        //        {

        //            SqlParameter[] param =
        //            { 
        //              new SqlParameter("@ERRORSTR", SqlDbType.VarChar, 200)
        //             ,new SqlParameter("@HMR_ID", HMR_ID)   
        //             ,new SqlParameter("@LOCKED_BY", Emp_Code)   
        //            };

        //            param[0].Direction = ParameterDirection.Output;


        //            new DataAccess().InsertWithTransaction("[AGG].[USP_UPDATE_HOUR_METER_READING_LOCK]", CommandType.StoredProcedure, out command, connection, transactionScope, param);

        //            string error_1 = (string)command.Parameters["@ERRORSTR"].Value;
        //            if (error_1 != "") { errorMsg = error_1; }



        //            if (errorMsg == "")
        //            {
        //                transactionScope.Commit();
        //            }
        //            else
        //            {
        //                transactionScope.Rollback();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            try
        //            {
        //                transactionScope.Rollback();
        //            }
        //            catch (Exception ex1)
        //            {
        //                errorMsg = "Error: Exception occured. " + ex1.StackTrace.ToString();
        //            }
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return errorMsg;
        //}


        //public VIEW_HMR_METER_READING GET_METER_READING(decimal HMR_ID)
        //{
        //    SqlParameter[] param = { new SqlParameter("@HMR_ID", HMR_ID) };

        //    DataSet ds = new DataAccess(sqlConnection.GetConnectionString_SGX()).GetDataSet("[AGG].[USP_GET_HOUR_METER_READING_DTLS]", CommandType.StoredProcedure, param);

        //    DataTable dt = ds.Tables[0];
        //    DataTable dt1 = ds.Tables[1];

        //    VIEW_HMR_METER_READING MeterReport = new VIEW_HMR_METER_READING();
        //    List<METER_READING_DTL> list = new List<METER_READING_DTL>();

        //    if (dt.Rows.Count > 0)
        //    {
        //        MeterReport.HMR_ID = Convert.ToDecimal(row["HMR_ID"]);
        //        MeterReport.PRODUCTION_DATE = Convert.ToString(row["PRODUCTION_DATE"]);
        //        MeterReport.SHIFT_TIME = Convert.ToInt32(row["SHIFT_TIME"]);
        //        MeterReport.SHIFT_DESC = Convert.ToString(row["SHIFT_DESC"]);
        //        MeterReport.ADDED_BY = Convert.ToString(row["ADDED_BY"]);
        //        MeterReport.PREPARE_BY = Convert.ToString(row["PREPARE_BY"]);
        //        MeterReport.LOCKED_BY = Convert.ToString(row["LOCKED_BY"]);
        //        MeterReport.LOCKED_BY_NAME = Convert.ToString(row["LOCKED_BY_NAME"]);

        //        METER_READING_DTL dtl = null;

        //        foreach (DataRow row in dt1.Rows)
        //        {
        //            dtl = new METER_READING_DTL();


        //            dtl.HMRR_ID = Convert.ToDecimal(row["HMRR_ID"] == DBNull.Value ? "0" : row["HMRR_ID"]);
        //            dtl.PM_NAME = Convert.ToString(row["PM_NAME"] == DBNull.Value ? "" : row["PM_NAME"]);
        //            dtl.PM_ID = Convert.ToInt32(row["PM_ID"] == DBNull.Value ? "0" : row["PM_ID"]);
        //            dtl.START = Convert.ToDecimal(row["START"] == DBNull.Value ? "0" : row["START"]);
        //            dtl.END = Convert.ToDecimal(row["END"] == DBNull.Value ? "0" : row["END"]);
        //            dtl.TOTAL = Convert.ToDecimal(row["TOTAL"] == DBNull.Value ? "0" : row["TOTAL"]);
        //            dtl.REMARKS = Convert.ToString(row["REMARKS"] == DBNull.Value ? "" : row["REMARKS"]);

        //            list.Add(dtl);


        //        }
        //    }

        //    MeterReport.READING_LIST = list;

        //    return MeterReport;
        //}

    }
}