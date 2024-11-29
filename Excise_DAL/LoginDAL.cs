using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Excise_BE;

namespace Excise_DAL
{
    public class Login_DL
    {

        public DataTable getLoginDetails(string user,  string ConnKey) //Supplier_BE obj,
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetLoginDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = user;
                   // da.SelectCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable getLoginDetailsR(string user, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetLoginDetailsR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = user;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public int insertUserLoginStatus(string userId, DateTime dateAndTime, string ipAddress, string loginStatus, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                SqlCommand cmd = new SqlCommand("UserLoginStatus_IU", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = userId;
                cmd.Parameters.Add("@Login_or_LogoutDateAndTime", SqlDbType.DateTime).Value = dateAndTime;
                cmd.Parameters.Add("@IpAddress", SqlDbType.NVarChar).Value = ipAddress;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = loginStatus;
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "I";
                cmd.Parameters.Add("@LoginSno", SqlDbType.Int);

                //cmd.Parameters.Add("@LogoutDateAndTime", SqlDbType.DateTime).Value = LogoutDateAndTime;
                cmd.Parameters["@LoginSno"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                int code = Convert.ToInt32(cmd.Parameters["@LoginSno"].Value);
                con.Close();
                con.Dispose();
                return code;
            }
        }

        public void updateUserLoginStatus(int id, string status, DateTime logouttime, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                SqlCommand cmd = new SqlCommand("UserLoginStatus_IU", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginSno_toUpdate", SqlDbType.BigInt).Value = id;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = status;
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "U";
                cmd.Parameters.Add("@Login_or_LogoutDateAndTime", SqlDbType.DateTime).Value = logouttime;
                cmd.Parameters.Add("@LoginSno", SqlDbType.Int);
                cmd.Parameters["@LoginSno"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void updateUserLoginStatusDAL(int id, string status, DateTime logouttime, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                SqlCommand cmd = new SqlCommand("UserLoginStatus_IU", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginSno_toUpdate", SqlDbType.BigInt).Value = id;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = status;
                cmd.Parameters.Add("@Login_or_LogoutDateAndTime", SqlDbType.DateTime).Value = logouttime;
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "U";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public int changepassword(string username, string newpwd, string IP, string Connkey)
        {
            SqlConnection con = new SqlConnection(Connkey);
            SqlCommand cmd = new SqlCommand("ChangePwd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            cmd.Parameters.Add("@newpwd", SqlDbType.NVarChar).Value = newpwd;
            cmd.Parameters.Add("@ip", SqlDbType.VarChar).Value = IP;
            con.Open();
            int rowCoutn = cmd.ExecuteNonQuery();
            con.Close();
            return rowCoutn;
        }

        public DataTable UserCreation_IUDR(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("UserCreation", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@SupplierId", SqlDbType.VarChar).Value = obj.Id;
                    da.SelectCommand.Parameters.Add("@Supplier_Code", SqlDbType.VarChar).Value = obj.Supplier_Code;
                    da.SelectCommand.Parameters.Add("@User_Type", SqlDbType.VarChar).Value = obj.UserType;
                    da.SelectCommand.Parameters.Add("@IpAddress", SqlDbType.VarChar).Value = obj.IPAddress;
                    da.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = obj.UserName;
                    da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = obj.Status;
                    da.SelectCommand.Parameters.Add("@Type_of_Manufacturing", SqlDbType.VarChar).Value = obj.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@UserCreation_TVP", SqlDbType.Structured).Value = obj.TVP;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable getLoginDetails(string user, Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetLoginDetails_RT", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.NVarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetQAnswers(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetQAnswers", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetQuestionnaire_Update(string user, string QuestionnaireAnswer, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetQuestionnaire_Update", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_UserName", SqlDbType.NVarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@P_QuestionnaireAnswer", SqlDbType.NVarChar).Value = QuestionnaireAnswer;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetQuestionnaire(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetQuestionnaire", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetQuestionnaire_Insert(string user, int QuestionnaireID, string QuestionnaireAnswer, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetQuestionnaire_Insert", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_UserName", SqlDbType.NVarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@P_QuestionnaireID", SqlDbType.Int).Value = QuestionnaireID;
                    da.SelectCommand.Parameters.Add("@P_QuestionnaireAnswer", SqlDbType.NVarChar).Value = QuestionnaireAnswer;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetQuestionnaire_Match(string user, int QuestionnaireID, string QuestionnaireAnswer, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetQuestionnaire_Match", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_UserName", SqlDbType.NVarChar).Value = user;
                    da.SelectCommand.Parameters.Add("@P_QuestionnaireID", SqlDbType.Int).Value = QuestionnaireID;
                    da.SelectCommand.Parameters.Add("@P_QuestionnaireAnswer", SqlDbType.NVarChar).Value = QuestionnaireAnswer;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

    }
}
