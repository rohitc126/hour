using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAL
{
    public class DAL_SPECIFIC_GRAVITY_FINE_TEST
    {


        public string INSERT_SPECIFIC_FINE_GRAVITY(string Emp_Code, Specific_Gravity_Fine _SPGRAVITY , out ResultMessage oblMsg)
        {

            string errorMsg = "";
            oblMsg = new ResultMessage();
            using (var connection = new SqlConnection(sqlConnection.GetConnectionString_SGX()))
            {

                connection.Open();
                SqlCommand command;
                SqlTransaction transactionScope = null;
                transactionScope = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    int IS_FILE_UPLOAD = 0;
                    string DMS_Path = ConfigurationManager.AppSettings["DMSPATH"].ToString();
                    string filePath = "REPORT\\SPECIFIC GRAVITY FINE\\";
                    string directoryPath = DMS_Path + filePath;
                    string ext = "";
                    if (_SPGRAVITY.UploadFile != null)
                    {
                        IS_FILE_UPLOAD = 1;
                        ext = new System.IO.FileInfo(_SPGRAVITY.UploadFile.FileName).Extension;
                    }

                    SqlParameter[] param =
                    { 
                      new SqlParameter("@ERRORSTR", SqlDbType.VarChar, 200)
                     ,new SqlParameter("@Test_ID", SqlDbType.Decimal) 
                     ,new SqlParameter("@Test_No", SqlDbType.VarChar, 20)  
                     ,new SqlParameter("@Date", _SPGRAVITY.Date)
                     ,new SqlParameter("@Source", _SPGRAVITY.Source)  
                     ,new SqlParameter("@Fine_Aggregate_Type", _SPGRAVITY.Fine_Aggregate_Type)    
                     ,new SqlParameter("@Colour", _SPGRAVITY.Colour)   
                     ,new SqlParameter("@Texture", _SPGRAVITY.Texture) 
                     ,new SqlParameter("@Shape", _SPGRAVITY.Shape)  
                     ,new SqlParameter("@Rock_Type", _SPGRAVITY.Rock_Type)
                     ,new SqlParameter("@Tested_By", _SPGRAVITY.TESTED_BY) 
                     ,new SqlParameter("@Qc_Incharge", _SPGRAVITY.QC_INCHARGE) 
                      ,new SqlParameter("@Remarks", _SPGRAVITY.REMARKS) 
                     ,new SqlParameter("@Added_By",Emp_Code)  
                    };
                    param[0].Direction = ParameterDirection.Output;
                    param[1].Direction = ParameterDirection.Output;
                    param[2].Direction = ParameterDirection.Output;
                    new DataAccess().InsertWithTransaction("[AGG].[USP_INSERT_SPECIFIC_GRAVITY_FINE_HDR]", CommandType.StoredProcedure, out command, connection, transactionScope, param);
                    decimal Test_ID = (decimal)command.Parameters["@Test_ID"].Value;
                    string Test_No = (string)command.Parameters["@Test_No"].Value;
                    string error_1 = (string)command.Parameters["@ERRORSTR"].Value;
                  
                    if (Test_ID == -1) { errorMsg = error_1; }

                   
                         SqlParameter[] param2 =
                                    {
                                new SqlParameter("@ERRORSTR", SqlDbType.VarChar, 200)
                               ,new SqlParameter("@Test_Dtl_ID", SqlDbType.Decimal)  
                               ,new SqlParameter("@DESK_FILE_PATH", SqlDbType.VarChar, 50)
                               ,new SqlParameter("@Test_ID" ,Test_ID)   
                               ,new SqlParameter("@Wt_Dry_Sample1" , (_SPGRAVITY.Wt_Dry_Sample == null)? (object)DBNull.Value : _SPGRAVITY.Wt_Dry_Sample) 
                               ,new SqlParameter("@Wt_SSD_Sample1", (_SPGRAVITY.Wt_SSD_Sample == null)? (object)DBNull.Value : _SPGRAVITY.Wt_SSD_Sample) 
                               ,new SqlParameter("@Wt_Pycnometer1", (_SPGRAVITY.Wt_Pycnometer == null)? (object)DBNull.Value : _SPGRAVITY.Wt_Pycnometer) 
                               ,new SqlParameter("@Wt_Oven_Dried1", (_SPGRAVITY.Wt_Oven_Dried	 == null)? (object)DBNull.Value: _SPGRAVITY.Wt_Oven_Dried)  
                               ,new SqlParameter("@Bulk_Sp_Gravity1", (_SPGRAVITY.Bulk_Sp_Gravity == null)? (object)DBNull.Value : _SPGRAVITY.Bulk_Sp_Gravity) 
                               ,new SqlParameter("@SP_Gravity_SSD_Basis1", (_SPGRAVITY.SP_Gravity_SSD_Basis == null)? (object)DBNull.Value : _SPGRAVITY.SP_Gravity_SSD_Basis) 
                               ,new SqlParameter("@Apparent_SP_Gravity1 ", (_SPGRAVITY.Apparent_SP_Gravity  == null)? (object)DBNull.Value : _SPGRAVITY.Apparent_SP_Gravity) 
                               ,new SqlParameter("@Effective_SP_Gravity1", (_SPGRAVITY.Effective_SP_Gravity == null)? (object)DBNull.Value : _SPGRAVITY.Effective_SP_Gravity) 
                               ,new SqlParameter("@Water_Absorption1", (_SPGRAVITY.Water_Absorption == null)? (object)DBNull.Value : _SPGRAVITY.Water_Absorption) 


                                ,new SqlParameter("@Wt_Dry_Sample2" , (_SPGRAVITY.Wt_Dry_Sample2 == null)? (object)DBNull.Value : _SPGRAVITY.Wt_Dry_Sample2) 
                               ,new SqlParameter("@Wt_SSD_Sample2", (_SPGRAVITY.Wt_SSD_Sample2 == null)? (object)DBNull.Value : _SPGRAVITY.Wt_SSD_Sample2) 
                               ,new SqlParameter("@Wt_Pycnometer2", (_SPGRAVITY.Wt_Pycnometer2 == null)? (object)DBNull.Value : _SPGRAVITY.Wt_Pycnometer2) 
                               ,new SqlParameter("@Wt_Oven_Dried2", (_SPGRAVITY.Wt_Oven_Dried2	 == null)? (object)DBNull.Value: _SPGRAVITY.Wt_Oven_Dried2)  
                               ,new SqlParameter("@Bulk_Sp_Gravity2", (_SPGRAVITY.Bulk_Sp_Gravity2 == null)? (object)DBNull.Value : _SPGRAVITY.Bulk_Sp_Gravity2) 
                               ,new SqlParameter("@SP_Gravity_SSD_Basis2", (_SPGRAVITY.SP_Gravity_SSD_Basis2 == null)? (object)DBNull.Value : _SPGRAVITY.SP_Gravity_SSD_Basis2) 
                               ,new SqlParameter("@Apparent_SP_Gravity2", (_SPGRAVITY.Apparent_SP_Gravity2  == null)? (object)DBNull.Value : _SPGRAVITY.Apparent_SP_Gravity2) 
                               ,new SqlParameter("@Effective_SP_Gravity2", (_SPGRAVITY.Effective_SP_Gravity2 == null)? (object)DBNull.Value : _SPGRAVITY.Effective_SP_Gravity2) 
                               ,new SqlParameter("@Water_Absorption2", (_SPGRAVITY.Water_Absorption2 == null)? (object)DBNull.Value : _SPGRAVITY.Water_Absorption2) 

                                 ,new SqlParameter("@Avg_Wt_Dry" , (_SPGRAVITY.Avg_Wt_Dry == null)? (object)DBNull.Value : _SPGRAVITY.Avg_Wt_Dry) 
                               ,new SqlParameter("@Avg_Wt_SSD", (_SPGRAVITY.Avg_Wt_SSD == null)? (object)DBNull.Value : _SPGRAVITY.Avg_Wt_SSD) 
                               ,new SqlParameter("@Avg_Wt_Pycnometer", (_SPGRAVITY.Avg_Wt_Pycnometer == null)? (object)DBNull.Value : _SPGRAVITY.Avg_Wt_Pycnometer) 
                               ,new SqlParameter("@Avg_Wt_Oven_Dried", (_SPGRAVITY.Avg_Wt_Oven_Dried	 == null)? (object)DBNull.Value: _SPGRAVITY.Avg_Wt_Oven_Dried)  
                               ,new SqlParameter("@Avg_Bulk_SpGravity", (_SPGRAVITY.Avg_Bulk_SpGravity == null)? (object)DBNull.Value : _SPGRAVITY.Avg_Bulk_SpGravity) 
                               ,new SqlParameter("@Avg_SpGravity_SSD_Basis", (_SPGRAVITY.Avg_SpGravity_SSD_Basis == null)? (object)DBNull.Value : _SPGRAVITY.Avg_SpGravity_SSD_Basis) 
                               ,new SqlParameter("@Avg_Apparent_SpGravity", (_SPGRAVITY.Avg_Apparent_SpGravity  == null)? (object)DBNull.Value : _SPGRAVITY.Avg_Apparent_SpGravity) 
                               ,new SqlParameter("@Avg_Effective_SpGravity", (_SPGRAVITY.Avg_Effective_SpGravity == null)? (object)DBNull.Value : _SPGRAVITY.Avg_Effective_SpGravity) 
                               ,new SqlParameter("@Avg_Water_Absorption", (_SPGRAVITY.Avg_Water_Absorption == null)? (object)DBNull.Value : _SPGRAVITY.Avg_Water_Absorption) 

                                ,new SqlParameter("@IS_FILE_UPLOAD", IS_FILE_UPLOAD)  
                               ,new SqlParameter("@FILE_PATH", string.IsNullOrEmpty(ext)?(object)DBNull.Value:ext)
                          };

                        param2[0].Direction = ParameterDirection.Output;
                        param2[2].Direction = ParameterDirection.Output;
                        param2[1].Direction = ParameterDirection.Output;

                        new DataAccess().InsertWithTransaction("[AGG].[USP_INSERT_SPECIFIC_GRAVITY_FINE_Dtl]", CommandType.StoredProcedure, out command, connection, transactionScope, param2);
                        decimal Test_Dtl_ID = (decimal)command.Parameters["@Test_Dtl_ID"].Value;
                        string error_2 = (string)command.Parameters["@ERRORSTR"].Value;
                        string deskFilePath = (string)command.Parameters["@DESK_FILE_PATH"].Value;

                        if (Test_Dtl_ID == -1) { errorMsg = error_2; }                     

                            if (_SPGRAVITY.UploadFile != null)
                            {
                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }

                                if (_SPGRAVITY.UploadFile != null)
                                {

                                    string fileName = deskFilePath;
                                    _SPGRAVITY.UploadFile.SaveAs(directoryPath + fileName);

                                }
                            }
                        
                    if (errorMsg == "")
                    {
                       

                        oblMsg.ID = Test_ID;
                        oblMsg.CODE = Test_No;
                        oblMsg.MsgType = "Success";
                        transactionScope.Commit();
                    }
                    else
                    {
                        oblMsg.Msg = errorMsg;
                        oblMsg.MsgType = "Error";
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
        


        public List<Specific_GRavity_Fine_Datalist> Select_SpeceficGravity_Fine_List(GravityFine_list Gravity_Datalist)
        {
            SqlParameter[] param = {    new SqlParameter("@FROM_DT", Gravity_Datalist.From_DT),
                                       new SqlParameter("@TO_DT", Gravity_Datalist.To_DT) , 
                                   };

            DataSet ds = new DataAccess(sqlConnection.GetConnectionString_SGX()).GetDataSet("[AGG].[USP_SELECT_SPECIFIC_GRAVITY_FINE]", CommandType.StoredProcedure, param);

            List<Specific_GRavity_Fine_Datalist> _list = new List<Specific_GRavity_Fine_Datalist>();
            DataTable dt = ds.Tables[0];
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Rows in ds.Tables[0].Rows)
                {
                    _list.Add(new Specific_GRavity_Fine_Datalist
                    {
                        Test_ID = Convert.ToDecimal(Rows["Test_ID"] == DBNull.Value ? 0 : Rows["Test_ID"]),
                        Test_No = Convert.ToString(Rows["Test_No"] == DBNull.Value ? "" : Rows["Test_No"]),
                        Date = Convert.ToString(Rows["Date"]),
                        Source = Convert.ToString(Rows["Source"]),
                        Fine_Aggregate_Type = Convert.ToString(Rows["Fine_Aggregate_Type"]),
                        Colour = Convert.ToString(Rows["Colour"]),
                        Texture = Convert.ToString(Rows["Texture"]),
                        Shape = Convert.ToString(Rows["Shape"]),
                        Rock_Type = Convert.ToString(Rows["Rock_Type"]),
                        IS_LOCKED = Convert.ToInt32(Rows["IS_LOCKED"]) 

                    });
                }
            }

            return _list;
        }
        public SpGRavityFineSample2 Edit_Specific_Gravity_FINE_Entry(decimal Test_ID)
        {
            SqlParameter[] param = { new SqlParameter("@Test_ID", Test_ID) };

            DataSet ds = new DataAccess(sqlConnection.GetConnectionString_SGX()).GetDataSet("[AGG].[USP_SPECIFIC_GRAVITY_FINE_EDIT]", CommandType.StoredProcedure, param);
            SpGRavityFineSample2 _objSPGR = new SpGRavityFineSample2();

            List<SpGRavityFineSample2> _list = new List<SpGRavityFineSample2>();
            SpGRavityFineSample2 dtl = null;
            DataTable dt = ds.Tables[0];
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dtl = new SpGRavityFineSample2();
                _objSPGR.Test_ID = Convert.ToInt32(dt.Rows[0]["Test_ID"] == DBNull.Value ? 0 : dt.Rows[0]["Test_ID"]);
                _objSPGR.Test_No = Convert.ToString(dt.Rows[0]["Test_No"]);
                _objSPGR.Date = Convert.ToDateTime(dt.Rows[0]["Date"]);
                _objSPGR.Source = Convert.ToString(dt.Rows[0]["Source"]);
                _objSPGR.Fine_Aggregate_Type = Convert.ToString(dt.Rows[0]["Fine_Aggregate_Type"]);
                _objSPGR.Colour = Convert.ToString(dt.Rows[0]["Colour"]);
                _objSPGR.Texture = Convert.ToString(dt.Rows[0]["Texture"]);
                _objSPGR.Shape = Convert.ToString(dt.Rows[0]["Shape"]);
                _objSPGR.Rock_Type = Convert.ToString(dt.Rows[0]["Rock_Type"]);
                //_objSPGR.TESTED_BY = Convert.ToString(dt.Rows[0]["Tested_By"]);
                //_objSPGR.QC_INCHARGE = Convert.ToString(dt.Rows[0]["Qc_Incharge"]);
                //_objSPGR.Added_By = Convert.ToString(dt.Rows[0]["Added_By"]);
                _objSPGR.Wt_Dry_Sample = Convert.ToDecimal(dt.Rows[0]["Wt_Dry_Sample1"] == DBNull.Value ? 0 : dt.Rows[0]["Wt_Dry_Sample1"]);
                _objSPGR.Wt_SSD_Sample = Convert.ToDecimal(dt.Rows[0]["Wt_SSD_Sample1"] == DBNull.Value ? 0 : dt.Rows[0]["Wt_SSD_Sample1"]);
                _objSPGR.Wt_Pycnometer = Convert.ToDecimal(dt.Rows[0]["Wt_Pycnometer1"] == DBNull.Value ? 0 : dt.Rows[0]["Wt_Pycnometer1"]);
                _objSPGR.Wt_Oven_Dried = Convert.ToDecimal(dt.Rows[0]["Wt_Oven_Dried1"] == DBNull.Value ? 0 : dt.Rows[0]["Wt_Oven_Dried1"]);
                _objSPGR.Bulk_Sp_Gravity = Convert.ToDecimal(dt.Rows[0]["Bulk_Sp_Gravity1"] == DBNull.Value ? 0 : dt.Rows[0]["Bulk_Sp_Gravity1"]);
                _objSPGR.SP_Gravity_SSD_Basis = Convert.ToDecimal(dt.Rows[0]["SP_Gravity_SSD_Basis1"] == DBNull.Value ? 0 : dt.Rows[0]["SP_Gravity_SSD_Basis1"]);
                _objSPGR.Apparent_SP_Gravity = Convert.ToDecimal(dt.Rows[0]["Apparent_SP_Gravity1"] == DBNull.Value ? 0 : dt.Rows[0]["Apparent_SP_Gravity1"]);
                _objSPGR.Effective_SP_Gravity = Convert.ToDecimal(dt.Rows[0]["Effective_SP_Gravity1"] == DBNull.Value ? 0 : dt.Rows[0]["Effective_SP_Gravity1"]);
                _objSPGR.Water_Absorption = Convert.ToDecimal(dt.Rows[0]["Water_Absorption1"] == DBNull.Value ? 0 : dt.Rows[0]["Water_Absorption1"]);

                _objSPGR.Wt_Dry_Sample2 = Convert.ToDecimal(dt.Rows[0]["Wt_Dry_Sample2"] == DBNull.Value ? 0 : dt.Rows[0]["Wt_Dry_Sample2"]);
                _objSPGR.Wt_SSD_Sample2 = Convert.ToDecimal(dt.Rows[0]["Wt_SSD_Sample2"] == DBNull.Value ? 0 : dt.Rows[0]["Wt_SSD_Sample2"]);
                _objSPGR.Wt_Pycnometer2 = Convert.ToDecimal(dt.Rows[0]["Wt_Pycnometer2"] == DBNull.Value ? 0 : dt.Rows[0]["Wt_Pycnometer2"]);
                _objSPGR.Wt_Oven_Dried2 = Convert.ToDecimal(dt.Rows[0]["Wt_Oven_Dried2"] == DBNull.Value ? 0 : dt.Rows[0]["Wt_Oven_Dried2"]);
                _objSPGR.Bulk_Sp_Gravity2 = Convert.ToDecimal(dt.Rows[0]["Bulk_Sp_Gravity2"] == DBNull.Value ? 0 : dt.Rows[0]["Bulk_Sp_Gravity2"]);
                _objSPGR.SP_Gravity_SSD_Basis2 = Convert.ToDecimal(dt.Rows[0]["SP_Gravity_SSD_Basis2"] == DBNull.Value ? 0 : dt.Rows[0]["SP_Gravity_SSD_Basis2"]);
                _objSPGR.Apparent_SP_Gravity2 = Convert.ToDecimal(dt.Rows[0]["Apparent_SP_Gravity2"] == DBNull.Value ? 0 : dt.Rows[0]["Apparent_SP_Gravity2"]);
                _objSPGR.Effective_SP_Gravity2 = Convert.ToDecimal(dt.Rows[0]["Effective_SP_Gravity2"] == DBNull.Value ? 0 : dt.Rows[0]["Effective_SP_Gravity2"]);
                _objSPGR.Water_Absorption2 = Convert.ToDecimal(dt.Rows[0]["Water_Absorption2"] == DBNull.Value ? 0 : dt.Rows[0]["Water_Absorption2"]);

                _objSPGR.Avg_Wt_Dry = Convert.ToDecimal(dt.Rows[0]["Avg_Wt_Dry"] == DBNull.Value ? 0 : dt.Rows[0]["Avg_Wt_Dry"]);
                _objSPGR.Avg_Wt_SSD = Convert.ToDecimal(dt.Rows[0]["Avg_Wt_SSD"] == DBNull.Value ? 0 : dt.Rows[0]["Avg_Wt_SSD"]);
                _objSPGR.Avg_Wt_Pycnometer = Convert.ToDecimal(dt.Rows[0]["Wt_Pycnometer2"] == DBNull.Value ? 0 : dt.Rows[0]["Wt_Pycnometer2"]);
                _objSPGR.Avg_Wt_Oven_Dried = Convert.ToDecimal(dt.Rows[0]["Wt_Oven_Dried2"] == DBNull.Value ? 0 : dt.Rows[0]["Wt_Oven_Dried2"]);
                _objSPGR.Avg_Bulk_SpGravity = Convert.ToDecimal(dt.Rows[0]["Bulk_Sp_Gravity2"] == DBNull.Value ? 0 : dt.Rows[0]["Bulk_Sp_Gravity2"]);
                _objSPGR.Avg_SpGravity_SSD_Basis = Convert.ToDecimal(dt.Rows[0]["SP_Gravity_SSD_Basis2"] == DBNull.Value ? 0 : dt.Rows[0]["SP_Gravity_SSD_Basis2"]);
                _objSPGR.Avg_Apparent_SpGravity = Convert.ToDecimal(dt.Rows[0]["Apparent_SP_Gravity2"] == DBNull.Value ? 0 : dt.Rows[0]["Apparent_SP_Gravity2"]);
                _objSPGR.Avg_Effective_SpGravity = Convert.ToDecimal(dt.Rows[0]["Effective_SP_Gravity2"] == DBNull.Value ? 0 : dt.Rows[0]["Effective_SP_Gravity2"]);
                _objSPGR.Avg_Water_Absorption = Convert.ToDecimal(dt.Rows[0]["Water_Absorption2"] == DBNull.Value ? 0 : dt.Rows[0]["Avg_Water_Absorption"]);
                _objSPGR.FILE_PATH = Convert.ToString(dt.Rows[0]["FILE_PATH"]);
                _objSPGR.IS_FILE_UPLOAD = Convert.ToInt32(dt.Rows[0]["IS_FILE_UPLOAD"] == DBNull.Value ? 0 : dt.Rows[0]["IS_FILE_UPLOAD"]);
                _objSPGR.IS_LOCKED = Convert.ToInt32(ds.Tables[0].Rows[0]["IS_LOCKED"]);
            }
            return _objSPGR;
        }




        public string LOCK_SPECIFIC_GRAVITY_FINE(string Emp_Code, decimal Test_ID, string Test_No, out ResultMessage oblMsg)
        {
            string errorMsg = "";
            oblMsg = new ResultMessage();
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
                     ,new SqlParameter("@Test_ID", Test_ID)  
                     ,new SqlParameter("@LOCKED_BY", Emp_Code)  
                     
                    };

                    param[0].Direction = ParameterDirection.Output;

                    new DataAccess().InsertWithTransaction("[AGG].[USP_UPDATE_SPECIFIC_GRAVITY_FINE_LOCK]", CommandType.StoredProcedure, out command, connection, transactionScope, param);

                    string error_1 = (string)command.Parameters["@ERRORSTR"].Value;

                    if (error_1 != "") { errorMsg = error_1; }

                    if (errorMsg == "")
                    {
                        oblMsg.ID = Test_ID;
                        oblMsg.CODE = Test_No;
                        oblMsg.MsgType = "Success";
                        transactionScope.Commit();
                    }
                    else
                    {
                        oblMsg.Msg = errorMsg;
                        oblMsg.MsgType = "Error";
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





        public string UPDATE_SPECIFIC_FINE_TEST(string Emp_Code, SpGRavityFineSample2 _objEdit, out ResultMessage oblMsg)
        {
            string errorMsg = "";
            oblMsg = new ResultMessage();
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
                               ,new SqlParameter("@Test_ID", _objEdit.Test_ID)  
                               ,new SqlParameter("@Wt_Dry_Sample1" , (_objEdit.Wt_Dry_Sample == null)? (object)DBNull.Value : _objEdit.Wt_Dry_Sample) 
                               ,new SqlParameter("@Wt_SSD_Sample1", (_objEdit.Wt_SSD_Sample == null)? (object)DBNull.Value : _objEdit.Wt_SSD_Sample) 
                               ,new SqlParameter("@Wt_Pycnometer1", (_objEdit.Wt_Pycnometer == null)? (object)DBNull.Value : _objEdit.Wt_Pycnometer) 
                               ,new SqlParameter("@Wt_Oven_Dried1", (_objEdit.Wt_Oven_Dried	 == null)? (object)DBNull.Value: _objEdit.Wt_Oven_Dried)  
                               ,new SqlParameter("@Bulk_Sp_Gravity1", (_objEdit.Bulk_Sp_Gravity == null)? (object)DBNull.Value : _objEdit.Bulk_Sp_Gravity) 
                               ,new SqlParameter("@SP_Gravity_SSD_Basis1", (_objEdit.SP_Gravity_SSD_Basis == null)? (object)DBNull.Value : _objEdit.SP_Gravity_SSD_Basis) 
                               ,new SqlParameter("@Apparent_SP_Gravity1 ", (_objEdit.Apparent_SP_Gravity  == null)? (object)DBNull.Value : _objEdit.Apparent_SP_Gravity) 
                               ,new SqlParameter("@Effective_SP_Gravity1", (_objEdit.Effective_SP_Gravity == null)? (object)DBNull.Value : _objEdit.Effective_SP_Gravity) 
                               ,new SqlParameter("@Water_Absorption1", (_objEdit.Water_Absorption == null)? (object)DBNull.Value : _objEdit.Water_Absorption) 


                                ,new SqlParameter("@Wt_Dry_Sample2" , (_objEdit.Wt_Dry_Sample2 == null)? (object)DBNull.Value : _objEdit.Wt_Dry_Sample2) 
                               ,new SqlParameter("@Wt_SSD_Sample2", (_objEdit.Wt_SSD_Sample2 == null)? (object)DBNull.Value : _objEdit.Wt_SSD_Sample2) 
                               ,new SqlParameter("@Wt_Pycnometer2", (_objEdit.Wt_Pycnometer2 == null)? (object)DBNull.Value : _objEdit.Wt_Pycnometer2) 
                               ,new SqlParameter("@Wt_Oven_Dried2", (_objEdit.Wt_Oven_Dried2	 == null)? (object)DBNull.Value: _objEdit.Wt_Oven_Dried2)  
                               ,new SqlParameter("@Bulk_Sp_Gravity2", (_objEdit.Bulk_Sp_Gravity2 == null)? (object)DBNull.Value : _objEdit.Bulk_Sp_Gravity2) 
                               ,new SqlParameter("@SP_Gravity_SSD_Basis2", (_objEdit.SP_Gravity_SSD_Basis2 == null)? (object)DBNull.Value : _objEdit.SP_Gravity_SSD_Basis2) 
                               ,new SqlParameter("@Apparent_SP_Gravity2", (_objEdit.Apparent_SP_Gravity2  == null)? (object)DBNull.Value : _objEdit.Apparent_SP_Gravity2) 
                               ,new SqlParameter("@Effective_SP_Gravity2", (_objEdit.Effective_SP_Gravity2 == null)? (object)DBNull.Value : _objEdit.Effective_SP_Gravity2) 
                               ,new SqlParameter("@Water_Absorption2", (_objEdit.Water_Absorption2 == null)? (object)DBNull.Value : _objEdit.Water_Absorption2) 

                                 ,new SqlParameter("@Avg_Wt_Dry" , (_objEdit.Avg_Wt_Dry == null)? (object)DBNull.Value : _objEdit.Avg_Wt_Dry) 
                               ,new SqlParameter("@Avg_Wt_SSD", (_objEdit.Avg_Wt_SSD == null)? (object)DBNull.Value : _objEdit.Avg_Wt_SSD) 
                               ,new SqlParameter("@Avg_Wt_Pycnometer", (_objEdit.Avg_Wt_Pycnometer == null)? (object)DBNull.Value : _objEdit.Avg_Wt_Pycnometer) 
                               ,new SqlParameter("@Avg_Wt_Oven_Dried", (_objEdit.Avg_Wt_Oven_Dried	 == null)? (object)DBNull.Value: _objEdit.Avg_Wt_Oven_Dried)  
                               ,new SqlParameter("@Avg_Bulk_SpGravity", (_objEdit.Avg_Bulk_SpGravity == null)? (object)DBNull.Value : _objEdit.Avg_Bulk_SpGravity) 
                               ,new SqlParameter("@Avg_SpGravity_SSD_Basis", (_objEdit.Avg_SpGravity_SSD_Basis == null)? (object)DBNull.Value : _objEdit.Avg_SpGravity_SSD_Basis) 
                               ,new SqlParameter("@Avg_Apparent_SpGravity", (_objEdit.Avg_Apparent_SpGravity  == null)? (object)DBNull.Value : _objEdit.Avg_Apparent_SpGravity) 
                               ,new SqlParameter("@Avg_Effective_SpGravity", (_objEdit.Avg_Effective_SpGravity == null)? (object)DBNull.Value : _objEdit.Avg_Effective_SpGravity) 
                               ,new SqlParameter("@Avg_Water_Absorption", (_objEdit.Avg_Water_Absorption == null)? (object)DBNull.Value : _objEdit.Avg_Water_Absorption) 

                    };

                    param[0].Direction = ParameterDirection.Output;

                    new DataAccess().InsertWithTransaction("[AGG].[USP_UPDATE_SPECIFIC_GRAVITY_FINE_Dtl]", CommandType.StoredProcedure, out command, connection, transactionScope, param);

                    string error_1 = (string)command.Parameters["@ERRORSTR"].Value;

                    if (error_1 != "") { errorMsg = error_1; }




                    if (errorMsg == "")
                    {

                        oblMsg.ID = _objEdit.Test_ID;
                        oblMsg.CODE = _objEdit.Test_No;
                        oblMsg.MsgType = "Success";
                        transactionScope.Commit();
                    }
                    else
                    {
                        oblMsg.Msg = errorMsg;
                        oblMsg.MsgType = "Error";
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

    }

}