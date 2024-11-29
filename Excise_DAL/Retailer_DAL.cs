using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excise_BE;
using System.Data;
using System.Data.SqlClient;

namespace Excise_DAL
{
   public class Retailer_DAL
    {
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


       public DataTable RetailerTypeIUDR(Retailer_BE objBE, string ConnKey)
       {
           using (SqlConnection con = new SqlConnection(ConnKey))
           {
               using (SqlDataAdapter da = new SqlDataAdapter("RetailerType_IUDR", con))
               {
                   da.SelectCommand.CommandType = CommandType.StoredProcedure;
                   da.SelectCommand.Parameters.Add("@RetailerTypeCode", SqlDbType.VarChar).Value = objBE.retailertypecode;
                   da.SelectCommand.Parameters.Add("@RetailerShortName", SqlDbType.VarChar).Value = objBE.retailershortname;
                   da.SelectCommand.Parameters.Add("@RetailerDescription", SqlDbType.VarChar).Value = objBE.retailername;
                   da.SelectCommand.Parameters.Add("@IpAddress", SqlDbType.VarChar).Value = objBE.IPAddress;
                   da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = objBE.UserID;
                   da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = objBE.Action;
                   DataTable dt = new DataTable();
                   da.Fill(dt);
                   return dt;
               }
           }
       }
    }
}

