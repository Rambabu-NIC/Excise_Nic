using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Excise_BE;
namespace Excise_DAL
{
   public class ECMS_DAL
    {
        public DataTable GetComplaint_type(string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetComplaint_Type", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetComplaint_Status(int Role,string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetStatus", con))//SP NAME
                {

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_Role", SqlDbType.VarChar).Value = Role;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetComplaint_Reason(string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetComplaintReason", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetComplaint_Types(string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetComplaintTypes", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAVoilation(string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetAVoilation", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetBVoilation(string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetBVoilation", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable ComplaintRegistration(ECMS_BE Obj, string ConnKey)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("ComplaintRegistration", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_Name", SqlDbType.VarChar).Value = Obj.Name;
                        da.SelectCommand.Parameters.Add("@P_Phone", SqlDbType.VarChar).Value = Obj.Phone;
                        da.SelectCommand.Parameters.Add("@P_Aadhaar", SqlDbType.VarChar).Value = Obj.Aadhaar;
                        da.SelectCommand.Parameters.Add("@P_Email", SqlDbType.VarChar).Value = Obj.Email;
                        da.SelectCommand.Parameters.Add("@P_DistrictID", SqlDbType.Int).Value = Obj.DistrictID;
                        da.SelectCommand.Parameters.Add("@P_MandalID", SqlDbType.Int).Value = Obj.MandalID;
                        da.SelectCommand.Parameters.Add("@P_VillageID", SqlDbType.Int).Value = Obj.VillageID;
                        da.SelectCommand.Parameters.Add("@P_ComplaintDetails", SqlDbType.VarChar).Value = Obj.ComplaintDetails;
                        da.SelectCommand.Parameters.Add("@P_ComplaintSource", SqlDbType.Int).Value = Obj.ComplaintSource;
                        da.SelectCommand.Parameters.Add("@P_CreatedBy", SqlDbType.VarChar).Value = Obj.CreatedBy;
                        da.SelectCommand.Parameters.Add("@P_DocumentFile", SqlDbType.Binary).Value = Obj.DocumentFile;
                        da.SelectCommand.Parameters.Add("@P_DocumentName", SqlDbType.VarChar).Value = Obj.DocumentName;
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
        public DataSet GetComplaintsByRoleID(int Role, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetComplaints", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_Role", SqlDbType.VarChar).Value = Role;

                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                return ds;
            }
        }
        public DataSet GetComplaintsByComplaintID(string ComplaintID, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetComplaintsByComplaintID", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_ComplaintID", SqlDbType.VarChar).Value = ComplaintID;

                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        public DataTable GetDC_Status(string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetDC_Status", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAssignedOfficers(string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetAssignedOfficers", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetCrimeDetection(string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetCrimeDetection", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }        
        public DataTable GetAssignedTo(string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetAssignedTo", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public bool Insert_ControlRoomDetails(string ComplaintID, int Status, string Reason, int ComplaintType, int A4ShopViolationCode, int B2VioaltionCode, int AssignedTo,int AtrNo, string CreateBy, string FeedbackRemarks
            , string Feedback_UpdatedBy, int DistrictCode, int ExciseDistrictCode, string ConnKey)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("ECMS_ControlRoomDetails_Insert", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@P_ComplaintID", SqlDbType.VarChar).Value =ComplaintID ;
                        da.Parameters.Add("@P_Status", SqlDbType.Int).Value = Status;
                        da.Parameters.Add("@P_Reason", SqlDbType.VarChar).Value = Reason;
                        da.Parameters.Add("@P_ComplaintType", SqlDbType.Int).Value = ComplaintType;
                        da.Parameters.Add("@P_A4ShopViolationCode", SqlDbType.Int).Value = A4ShopViolationCode;
                        da.Parameters.Add("@P_B2VioaltionCode", SqlDbType.Int).Value = B2VioaltionCode;
                        da.Parameters.Add("@P_AssignedTo", SqlDbType.Int).Value = AssignedTo;
                        da.Parameters.Add("@P_AtrNo", SqlDbType.Int).Value = AtrNo;
                        da.Parameters.Add("@P_CreateBy", SqlDbType.VarChar).Value = CreateBy;
                        da.Parameters.Add("@P_FeedbackRemarks", SqlDbType.VarChar).Value = FeedbackRemarks;
                        da.Parameters.Add("@P_Feedback_UpdatedBy", SqlDbType.VarChar).Value = Feedback_UpdatedBy;
                        da.Parameters.Add("@P_DistrictCode", SqlDbType.Int).Value = DistrictCode;
                        da.Parameters.Add("@P_ExciseDistrictCode", SqlDbType.Int).Value = ExciseDistrictCode;
                        con.Open();
                        da.ExecuteNonQuery();
                        result = true;
                        return result;

                    }
                }
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        public bool Insert_DCFormDetails(string ComplaintID, int AssignedToEnquiryOfficerCode, string EnquiryOfficerPlace, int StatusCode, string CreateBy, int DistrictCode, int ExciseDistrictCode,string Remarks, string ConnKey)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("ECMS_DC_FormEnqOfficer_Insert", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@P_ComplaintID", SqlDbType.VarChar).Value = ComplaintID;
                        da.Parameters.Add("@P_AssignedToEnquiryOfficerCode", SqlDbType.Int).Value = AssignedToEnquiryOfficerCode;
                        da.Parameters.Add("@P_EnquiryOfficerPlace", SqlDbType.VarChar).Value = EnquiryOfficerPlace;
                        da.Parameters.Add("@P_StatusCode", SqlDbType.Int).Value = StatusCode;
                        da.Parameters.Add("@P_CreateBy", SqlDbType.VarChar).Value = CreateBy;
                        da.Parameters.Add("@P_DistrictCode", SqlDbType.Int).Value = DistrictCode;
                        da.Parameters.Add("@P_ExciseDistrictCode", SqlDbType.Int).Value = ExciseDistrictCode;
                        da.Parameters.Add("@P_Remarks", SqlDbType.VarChar).Value = Remarks;
                        con.Open();
                        da.ExecuteNonQuery();
                        result = true;
                        return result;

                    }
                }
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        public DataTable GetDC_Status(int Status, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetStatus", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_Role", SqlDbType.Int).Value = Status;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public bool EnquiryForm(ECMS_BE Obj, string ConnKey)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("Enquiry_officer_Insert", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@AtrPreliminaryID", SqlDbType.Int).Value = Obj.AtrPreliminaryID;
                        da.Parameters.Add("@ComplaintID", SqlDbType.VarChar).Value = Obj.ComplaintID;
                        da.Parameters.Add("@InspectionDate", SqlDbType.DateTime).Value = Obj.InspectionDate;
                        da.Parameters.Add("@InspectingOfficerName", SqlDbType.VarChar).Value = Obj.InspectingOfficerName;
                        da.Parameters.Add("@CrimeDetectionCode", SqlDbType.Int).Value = Obj.CrimeDetectionCode;
                        da.Parameters.Add("@CrimeLocation", SqlDbType.VarChar).Value = Obj.CrimeLocation;
                        da.Parameters.Add("@CorNo", SqlDbType.VarChar).Value = Obj.CorNo;
                        da.Parameters.Add("@PersonsArrested", SqlDbType.VarChar).Value = Obj.PersonsArrested;
                        da.Parameters.Add("@ContrabandSeized", SqlDbType.Int).Value = Obj.ContrabandSeized;
                        da.Parameters.Add("@ContrabandValueRs", SqlDbType.VarChar).Value = Obj.ContrabandValueRs;
                        da.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = Obj.Remarks;
                        da.Parameters.Add("@P_Status", SqlDbType.Int).Value = Obj.Status;
                        da.Parameters.Add("@AtrNo", SqlDbType.Int).Value = Obj.AtrNo;
                        da.Parameters.Add("@CasesBooked", SqlDbType.VarChar).Value = Obj.CasesBooked;
                        da.Parameters.Add("@SeizureType", SqlDbType.Int).Value = Obj.SeizureType;
                        da.Parameters.Add("@NumberOfVehiclesSeized", SqlDbType.VarChar).Value = Obj.NumberOfVehiclesSeized;
                        da.Parameters.Add("@ContrabandType", SqlDbType.Int).Value = Obj.ContrabandType;
                        da.Parameters.Add("@QuantitySeizedInLitres", SqlDbType.VarChar).Value = Obj.QuantitySeizedInLitres;
                        da.Parameters.Add("@IllicitLiquor", SqlDbType.VarChar).Value = Obj.IllicitLiquor;
                        da.Parameters.Add("@Ndps", SqlDbType.VarChar).Value = Obj.Ndps;
                        da.Parameters.Add("@UnderSection", SqlDbType.VarChar).Value = Obj.UnderSection;
                        da.Parameters.Add("@P_DocumentFile", SqlDbType.Binary).Value = Obj.DocumentFile;
                        da.Parameters.Add("@P_DocumentName", SqlDbType.VarChar).Value = Obj.DocumentName;
                        da.Parameters.Add("@P_Action", SqlDbType.VarChar).Value = Obj.Action;
                        con.Open();
                        da.ExecuteNonQuery();
                        result = true;
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        public DataTable GetContraband(string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetContraband", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetSeizureType(string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetSeizure_Type", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetIllicitLiquor(string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetIllicitLiquor", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetNDPS(string ConnKey)//method name
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetNDPS", con))//SP NAME
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetComplaintStatus_Report(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetComplaintDistrictStatus", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_DistCode", SqlDbType.VarChar).Value = obj.DistCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Getdisplaycatwise(Supplier_BE obj, string ConnKey, string value)
        //public DataTable Getdisplaycatwise(string ConnKey,string value)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetValueComplaintStatus", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_DistCode", SqlDbType.VarChar).Value = obj.DistCode;
                    da.SelectCommand.Parameters.Add("@P_Value", SqlDbType.VarChar).Value = value;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable CountComplaintStatus(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetCountComplaintStatus", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_DistCode", SqlDbType.VarChar).Value = obj.DistCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
