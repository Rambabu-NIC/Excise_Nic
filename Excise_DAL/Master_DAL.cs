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
  public class Master_DAL
    {
      public DataTable GetStateDL(Supplier_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("StateMaster_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }
      public DataTable GetDistDL(Supplier_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("DistrictMaster_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = Obj.Statecode;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }
      public DataTable GetmandalsDAL(Supplier_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("MandalMst_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = Obj.Statecode;
                  da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = Obj.DistCode;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }


      }
      public DataTable GetvillDAL(Supplier_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("VillMst_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = Obj.DistCode;
                  da.SelectCommand.Parameters.Add("@MandCode", SqlDbType.VarChar).Value = Obj.MandCode;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }


      }
      public DataTable GetRenDS(Supplier_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("RevDS_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = Obj.DistCode;
                  da.SelectCommand.Parameters.Add("@MandCode", SqlDbType.VarChar).Value = Obj.MandCode;
                  da.SelectCommand.Parameters.Add("@VillCode", SqlDbType.VarChar).Value = Obj.VillCode;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }


      }
      //public DataTable GetTypeManFDAL(Supplier_BE Obj, string ConnKey)
      //{
      //    using (SqlConnection con = new SqlConnection(ConnKey))
      //    {
      //        using (SqlDataAdapter da = new SqlDataAdapter("TypeManFactory_IUDR", con))
      //        {
      //            da.SelectCommand.CommandType = CommandType.StoredProcedure;                 
      //            da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
      //            DataTable dt = new DataTable();
      //            da.Fill(dt);
      //            return dt;
      //        }
      //    }


      //}
      public DataTable TypeofManufacturing_IUR(Supplier_BE obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("TypeManFactory_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.VarChar).Value = obj.Id;
                  da.SelectCommand.Parameters.Add("@Type_Man_Nm", SqlDbType.VarChar).Value = obj.Type_of_Manu;
                  da.SelectCommand.Parameters.Add("@IpAddress", SqlDbType.VarChar).Value = obj.IPAddress;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }
      public DataTable GetEventFee(Supplier_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("EventFeeDtls", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@EventID", SqlDbType.VarChar).Value = Obj.EventId;
                  da.SelectCommand.Parameters.Add("@GHMC", SqlDbType.VarChar).Value = Obj.ghmc;
                  da.SelectCommand.Parameters.Add("@Payment_Type", SqlDbType.VarChar).Value = Obj.Paymenttype;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }
      public DataTable CommonMasters(Supplier_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("CommonMasters_NEW", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = Obj.Type_of_Manu;
                  da.SelectCommand.Parameters.Add("@Major_Head", SqlDbType.VarChar).Value = Obj.MajorHead;
                  da.SelectCommand.Parameters.Add("@Minor_Head_Code", SqlDbType.VarChar).Value = Obj.MinorHead;
                  da.SelectCommand.Parameters.Add("@Sub_Head", SqlDbType.VarChar).Value = Obj.SubHead;
                  da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = Obj.Statecode;
                  da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = Obj.DistCode;
                  da.SelectCommand.Parameters.Add("@MandCode", SqlDbType.VarChar).Value = Obj.MandCode;
                  da.SelectCommand.Parameters.Add("@VillCode", SqlDbType.VarChar).Value = Obj.VillCode;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }
      /*Mayuri*/
      public DataTable Retailers(Master_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("Retailers_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;

                  da.SelectCommand.Parameters.Add("@RetailerCode", SqlDbType.VarChar).Value = Obj.Retailer_Code;
                  da.SelectCommand.Parameters.Add("@RetailerName", SqlDbType.VarChar).Value = Obj.RetailerName;
                  da.SelectCommand.Parameters.Add("@Retailer_Type", SqlDbType.VarChar).Value = Obj.Retailer_Type;
                  da.SelectCommand.Parameters.Add("@License_Name", SqlDbType.VarChar).Value = Obj.License_Name;
                  da.SelectCommand.Parameters.Add("@License_Gazette_number", SqlDbType.VarChar).Value = Obj.License_Gazette_number;
                  da.SelectCommand.Parameters.Add("@District", SqlDbType.VarChar).Value = Obj.District;
                  da.SelectCommand.Parameters.Add("@Mandal", SqlDbType.VarChar).Value = Obj.Mandal;
                  da.SelectCommand.Parameters.Add("@Village", SqlDbType.VarChar).Value = Obj.Village;
                  da.SelectCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = Obj.Address;
                  da.SelectCommand.Parameters.Add("@Primary_Depot_Code", SqlDbType.VarChar).Value = Obj.Primary_Depot_Code;
                  da.SelectCommand.Parameters.Add("@Primary_Depot_Active_YN", SqlDbType.VarChar).Value = Obj.Primary_Depot_Active_YN;
                  da.SelectCommand.Parameters.Add("@Secondary_Depot_Code", SqlDbType.VarChar).Value = Obj.Secondary_Depot_Code;
                  da.SelectCommand.Parameters.Add("@Secondary_Depot_Active_YN ", SqlDbType.VarChar).Value = Obj.Secondary_Depot_Active_YN;
                  da.SelectCommand.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = Obj.EmailID;
                  da.SelectCommand.Parameters.Add("@MobileNumber", SqlDbType.VarChar).Value = Obj.MobileNumber;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }
      public DataTable Depots(Master_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("Depot_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@DEPOTCODE", SqlDbType.VarChar).Value = Obj.DEPOTCODE;
                  da.SelectCommand.Parameters.Add("@DEPOTNAME", SqlDbType.VarChar).Value = Obj.DepotName;
                  da.SelectCommand.Parameters.Add("@ADDRESS", SqlDbType.VarChar).Value = Obj.Address;
                  da.SelectCommand.Parameters.Add("@DISTRICT", SqlDbType.VarChar).Value = Obj.District;
                  da.SelectCommand.Parameters.Add("@DEPOT_DDO_CODE", SqlDbType.BigInt).Value = Obj.Depot_DDO_Code;
                  da.SelectCommand.Parameters.Add("@IP_Address ", SqlDbType.VarChar).Value = Obj.Ip_Address;
                  da.SelectCommand.Parameters.Add("@ID ", SqlDbType.BigInt).Value = Obj.ID;
                  da.SelectCommand.Parameters.Add("@TVP", SqlDbType.Structured).Value = Obj.TVP;//added
                  da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = Obj.UserID;//added
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }

      public DataTable HOADetails(Master_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("HOA_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@HOA_Code", SqlDbType.VarChar).Value = Obj.HOA_Code;
                  da.SelectCommand.Parameters.Add("@HOA_Description", SqlDbType.VarChar).Value = Obj.HOA_Description;
                  da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = Obj.Ip_Address;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }
      public DataTable Password(Master_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("Password_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = Obj.Password;
                  da.SelectCommand.Parameters.Add("@WEFForm", SqlDbType.VarChar).Value = Obj.WEF_Form;
                  da.SelectCommand.Parameters.Add("@Active_YN", SqlDbType.VarChar).Value = Obj.Active_YN;
                  da.SelectCommand.Parameters.Add("@IP_Address", SqlDbType.VarChar).Value = Obj.Ip_Address;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }
      public DataTable Purpose(Master_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("Purpose_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@Purpose_Code", SqlDbType.VarChar).Value = Obj.Purpose_Code;
                  da.SelectCommand.Parameters.Add("@purpose_Description", SqlDbType.VarChar).Value = Obj.purpose_Description;
                  da.SelectCommand.Parameters.Add("@IP_Address", SqlDbType.VarChar).Value = Obj.Ip_Address;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }
      public DataTable RelocationDepot(Master_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("Relocation_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@Retailer_Code", SqlDbType.VarChar).Value = Obj.Retailer_Code;
                  da.SelectCommand.Parameters.Add("@Secondary_Depot_Code", SqlDbType.VarChar).Value = Obj.Secondary_Depot_Code;
                  da.SelectCommand.Parameters.Add("@From_Date", SqlDbType.VarChar).Value = Obj.From_Date;
                  da.SelectCommand.Parameters.Add("@To_Date", SqlDbType.VarChar).Value = Obj.To_Date;
                  da.SelectCommand.Parameters.Add("@IP_Address", SqlDbType.VarChar).Value = Obj.Ip_Address;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }

      public DataTable Transaction(Master_BE Obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("Transaction_IUDR", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@Depot_Code", SqlDbType.VarChar).Value = Obj.Depot_Code;
                  da.SelectCommand.Parameters.Add("@HOA_Code", SqlDbType.VarChar).Value = Obj.HOA_Code;
                  da.SelectCommand.Parameters.Add("@DDO_Code", SqlDbType.VarChar).Value = Obj.DDO_Code;
                  da.SelectCommand.Parameters.Add("@Purpose_Code", SqlDbType.VarChar).Value = Obj.Purpose_Code;
                  da.SelectCommand.Parameters.Add("@Date_of_Payment", SqlDbType.VarChar).Value = Obj.Date_of_Payment;
                  da.SelectCommand.Parameters.Add("@Amount", SqlDbType.VarChar).Value = Obj.Amount;
                  da.SelectCommand.Parameters.Add("@Dept_Trans_id", SqlDbType.VarChar).Value = Obj.Dept_Trans_id;
                  da.SelectCommand.Parameters.Add("@Challan_Number", SqlDbType.VarChar).Value = Obj.Challan_Number;
                  da.SelectCommand.Parameters.Add("@Challan_Date", SqlDbType.VarChar).Value = Obj.Challan_Date;
                  da.SelectCommand.Parameters.Add("@Payment_Status", SqlDbType.VarChar).Value = Obj.Payment_Status;
                  da.SelectCommand.Parameters.Add("@Bank_Name", SqlDbType.VarChar).Value = Obj.Bank_Name;
                  da.SelectCommand.Parameters.Add("@Bank_Transaction_Id", SqlDbType.VarChar).Value = Obj.Bank_Transaction_Id;
                  da.SelectCommand.Parameters.Add("@IP_Address", SqlDbType.VarChar).Value = Obj.Ip_Address;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }
      public DataTable RetailerTypeIUDR(Retailer_BE Obj, string ConnKey)//method name
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("RetailerType_IUDR", con))//SP NAME
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  //parameters
                  da.SelectCommand.Parameters.Add("@RetailerTypeCode", SqlDbType.VarChar).Value = Obj.retailertypecode;
                  da.SelectCommand.Parameters.Add("@RetailerShortName", SqlDbType.VarChar).Value = Obj.retailershortname;
                  da.SelectCommand.Parameters.Add("@RetailerDescription", SqlDbType.VarChar).Value = Obj.retailername;
                  da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = Obj.IPAddress;
                  da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = Obj.UserID;
                  da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }

        /*Mayuri ENd*/



        #region "Installments"

      public DataTable GetInstallments(string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("GetInstallments", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }
      public bool GetInstallmentDates(Supplier_BE Obj, string ConnKey)
      {
          bool result = false;
          try
          {
              using (SqlConnection con = new SqlConnection(ConnKey))
              {
                  using (SqlCommand da = new SqlCommand("Get_InstallmentDates", con))
                  {

                      da.CommandType = CommandType.StoredProcedure;
                      da.Parameters.Add("@InstallmentNo", SqlDbType.SmallInt).Value = Obj.InstallmentNo;
                      da.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = Obj.BankDate;
                      da.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Obj.CreatedBy;

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



      public DataTable GetInst_dt(Supplier_BE obj, string ConnKey)
      {
          using (SqlConnection con = new SqlConnection(ConnKey))
          {
              using (SqlDataAdapter da = new SqlDataAdapter("GetInstallMents_Data", con))
              {
                  da.SelectCommand.CommandType = CommandType.StoredProcedure;
                  da.SelectCommand.Parameters.Add("@P_INS", SqlDbType.VarChar).Value = obj.InstallmentNo;
                  DataTable dt = new DataTable();
                  da.Fill(dt);
                  return dt;
              }
          }
      }

        #endregion

        public DataTable Getmandal(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Get_Mandals", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = Obj.Statecode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = Obj.DistCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }


        }
        public DataTable GetEventTime(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetEventTime", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                   
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }


        }

        public DataTable GetExDistricts(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ExDistricts", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }


        }
    }
}
