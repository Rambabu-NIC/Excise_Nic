using ExciseAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace ExciseAPI.Utility
{
    public class SqlHelper
    {
        Responses.responseMessage resp = new Responses.responseMessage();

        #region "Start GetData"
        //For Data Getting with Parameters  Database Table Values 
        public DataSet GetData(string connString, string procName, params SqlParameter[] paramters)
        {

            DataSet ds = new DataSet();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = new SqlConnection(connString))
                {
                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = procName;
                        if (paramters != null)
                        {
                            command.Parameters.AddRange(paramters);
                        }
                        sqlConnection.Open();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return ds;
        }


        //For Data Getting without Parameters  Database Table Values 
        public DataSet GetDataNew(string connString, string procName)
        {

            DataSet ds = new DataSet();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = new SqlConnection(connString))
                {
                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = procName;

                        sqlConnection.Open();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return ds;
        }
        #endregion "End GetData"



        #region "Start Insert"

        //Data Insert along with DataTable(if document or photos)
        public DataSet GetDataInsert(string connString, string procName, SqlParameter[] paramters, DataTable dataTable,string ParameterTypeName,string TypeName)
        {

            DataSet ds = new DataSet();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = new SqlConnection(connString))
                {
                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = procName;
                        if (paramters != null)
                        {
                            command.Parameters.AddRange(paramters);
                        }

                        SqlParameter parameter = new SqlParameter(ParameterTypeName, SqlDbType.Structured)
                        {
                            TypeName = TypeName,
                            Value = dataTable
                        };

                        command.Parameters.Add(parameter);


                        sqlConnection.Open();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return ds;
        }

        //Data Insert along with two DataTables((if document or photos) or address) 
        public DataSet GetDataInsert_DOCs(string connString, string procName, SqlParameter[] paramters, DataTable dataTable,DataTable newdt)
        {

            DataSet ds = new DataSet();
            SqlConnection sqlConnection = new SqlConnection();
            try
            {
                using (sqlConnection = new SqlConnection(connString))
                {
                    using (var command = sqlConnection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = procName;
                        if (paramters != null)
                        {
                            command.Parameters.AddRange(paramters);
                        }

                        SqlParameter parameter = new SqlParameter("@easydocuments", SqlDbType.Structured)
                        {
                            TypeName = "easy_documents",
                            Value = dataTable
                        };

                        command.Parameters.Add(parameter);


                        SqlParameter parameter_dt = new SqlParameter("@easy_deput_locations", SqlDbType.Structured)
                        {
                            TypeName = "easy_deput_locations",
                            Value = newdt
                        };

                        command.Parameters.Add(parameter_dt);

                        sqlConnection.Open();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                resp.IsSuccess = false;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return ds;
        }


       
        public bool ExecuteProcedureReturnString(string connString, string procName, params SqlParameter[] paramters)
        {
            bool result = false;
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = procName;
                    if (paramters != null)
                    {
                        command.Parameters.AddRange(paramters);
                    }
                    sqlConnection.Open();
                    var ret = command.ExecuteNonQuery();
                    if (ret != 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        public int ExecuteProcedureReturnint(string connString, string procName, params SqlParameter[] paramters)
        {
            int result = 0;
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = procName;
                    if (paramters != null)
                    {
                        command.Parameters.AddRange(paramters);
                    }
                    sqlConnection.Open();
                    var ret = command.ExecuteNonQuery();
                    if (paramters != null)
                    {
                      result =int.Parse(command.Parameters[1].Value.ToString());
                    }
                    else
                    {
                        result = 0;
                    }
                }
            }
            return result;
        }


        #endregion "End Insert"

        //public DataSet GetDataInsert_OD(string connString, string procName, SqlParameter[] paramters, DataTable dataTable, DataTable newdt,DataTable Oddt)
        //{

        //    DataSet ds = new DataSet();
        //    SqlConnection sqlConnection = new SqlConnection();
        //    try
        //    {
        //        using (sqlConnection = new SqlConnection(connString))
        //        {
        //            using (var command = sqlConnection.CreateCommand())
        //            {
        //                command.CommandType = System.Data.CommandType.StoredProcedure;
        //                command.CommandText = procName;
        //                if (paramters != null)
        //                {
        //                    command.Parameters.AddRange(paramters);
        //                }

        //                SqlParameter parameter = new SqlParameter("@easydocuments", SqlDbType.Structured)
        //                {
        //                    TypeName = "easy_documents",
        //                    Value = dataTable
        //                };

        //                command.Parameters.Add(parameter);


        //                SqlParameter parameter_dt = new SqlParameter("@easy_deput_locations", SqlDbType.Structured)
        //                {
        //                    TypeName = "easy_deput_locations",
        //                    Value = newdt
        //                };

        //                command.Parameters.Add(parameter_dt);

        //                SqlParameter parameter_deput_section_subsection = new SqlParameter("@easy_deput_section_subsection", SqlDbType.Structured)
        //                {
        //                    TypeName = "easy_deput_section_subsection",
        //                    Value = Oddt
        //                };

        //                command.Parameters.Add(parameter_deput_section_subsection);

        //                sqlConnection.Open();
        //                SqlDataAdapter da = new SqlDataAdapter(command);
        //                da.Fill(ds);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resp.IsSuccess = false;
        //    }
        //    finally
        //    {
        //        if (sqlConnection.State == ConnectionState.Open)
        //        {
        //            sqlConnection.Close();
        //        }
        //    }
        //    return ds;
        //}

        public void ShowAlertMessage(string error)
        {
            Page page = HttpContext.Current.Handler as Page;

            if (page != null)
            {
                error = error.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
            }
        }


        #region "District Mandal Village Details "
        public DataSet BindDistrictDetails()
        {
            DataSet dist=new DataSet();
            try
            {
                dist = GetDataNew(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetDistrictDetails");
                if (dist != null && dist.Tables.Count > 0)
                {
                    return dist;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dist;
        }

        public DataSet BindMandalDetails(int DistrictID)
        {
            DataSet Mandal = new DataSet();
            try
            {
                SqlParameter[] Params =
                {
                    new SqlParameter("@P_DistrictID", DistrictID ),
                };
                Mandal = GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetMandalDetails",Params);
                if (Mandal != null && Mandal.Tables.Count > 0)
                {
                    return Mandal;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return Mandal;
        }

        public DataSet BindVillageDetails(int DistrictID,int MandalID)
        {
            DataSet Vill = new DataSet();
            try
            {
                SqlParameter[] Params =
                {
                    new SqlParameter("@P_DistrictID", DistrictID ),
                    new SqlParameter("@P_MandalID", MandalID ),
                };
                Vill = GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetVillageDetails", Params);
                if (Vill != null && Vill.Tables.Count > 0)
                {
                    return Vill;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return Vill;
        }


        public DataSet BindExciseDistrictDetails()
        {
            DataSet Edist = new DataSet();
            try
            {
                Edist = GetDataNew(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "MasterExciseDistrict");
                if (Edist != null && Edist.Tables.Count > 0)
                {
                    return Edist;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return Edist;
        }

        public DataSet BindExciseStations(int DistrictID)
        {
            DataSet Stations = new DataSet();
            try
            {
                SqlParameter[] Params =
                {
                    new SqlParameter("@P_ExdistCD", DistrictID ),
                };
                Stations = GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "MasterExciseStations", Params);
                if (Stations != null && Stations.Tables.Count > 0)
                {
                    return Stations;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return Stations;
        }



        #endregion "District Mandal Village Details "


        #region "Documents "
        public DataSet BindDocumentDetails(int ApplicantType, int SubApplicantType,int FormType)
        {
            DataSet Docs  = new DataSet();
            try
            {
                SqlParameter[] Params =
                {
                    new SqlParameter("@P_ApplicantID", ApplicantType ),
                    new SqlParameter("@P_ManufactureID", SubApplicantType ),
                    new SqlParameter("@P_FormType", FormType ),
                };
                Docs = GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetDocumentDetails", Params);
                if (Docs != null && Docs.Tables.Count > 0)
                {
                    return Docs;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return Docs;
        }
       
        #endregion "Documents "
    }
}

