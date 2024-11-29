using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Excise_BE;
namespace Excise_DAL
{
    public class SupplierDAL
    {

        public DataTable Supplier_IUR(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InsertSupplier_IUR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@SupplierId", SqlDbType.VarChar).Value = obj.Id;
                    da.SelectCommand.Parameters.Add("@Manuf_Code", SqlDbType.VarChar).Value = obj.ManufCd;
                    da.SelectCommand.Parameters.Add("@Supplier_Code", SqlDbType.VarChar).Value = obj.Supplier_Code;
                    da.SelectCommand.Parameters.Add("@Suppliername", SqlDbType.VarChar).Value = obj.SupplierName;
                    da.SelectCommand.Parameters.Add("@TypeofManuf", SqlDbType.VarChar).Value = obj.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@Statecode", SqlDbType.VarChar).Value = obj.Statecode;
                    da.SelectCommand.Parameters.Add("@Dist_code", SqlDbType.VarChar).Value = obj.DistCode;
                    da.SelectCommand.Parameters.Add("@MandCode", SqlDbType.VarChar).Value = obj.MandCode;
                    da.SelectCommand.Parameters.Add("@Vill_code", SqlDbType.VarChar).Value = obj.VillCode;
                    da.SelectCommand.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = obj.MobNo;
                    da.SelectCommand.Parameters.Add("@TINNo", SqlDbType.VarChar).Value = obj.TINNo;
                    da.SelectCommand.Parameters.Add("@PAN", SqlDbType.VarChar).Value = obj.PANNo;
                    da.SelectCommand.Parameters.Add("@SGST", SqlDbType.VarChar).Value = obj.SGSTNo;
                    da.SelectCommand.Parameters.Add("@PinCode", SqlDbType.VarChar).Value = obj.Pincode;
                    da.SelectCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = obj.Address;
                    da.SelectCommand.Parameters.Add("@DDOCode", SqlDbType.VarChar).Value = obj.DDoCode;
                    da.SelectCommand.Parameters.Add("@LicenseNo", SqlDbType.VarChar).Value = obj.LicNo;
                    da.SelectCommand.Parameters.Add("@User_Type", SqlDbType.VarChar).Value = obj.UserType;
                    da.SelectCommand.Parameters.Add("@Lfromdt", SqlDbType.Date).Value = obj.Dt_Valid_Fm;
                    da.SelectCommand.Parameters.Add("@Ltodt", SqlDbType.Date).Value = obj.Dt_Valid_To;
                    da.SelectCommand.Parameters.Add("@IpAddress", SqlDbType.VarChar).Value = obj.IPAddress;
                    da.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = obj.UserName;
                    da.SelectCommand.Parameters.Add("@Annual_LicCap", SqlDbType.VarChar).Value = obj.Annual_Lic_Capacity;

                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Manuf_IUR(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InsertManuf_IUR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Manuf_Code", SqlDbType.VarChar).Value = obj.SupplierCode;
                    da.SelectCommand.Parameters.Add("@Contact_Person", SqlDbType.VarChar).Value = obj.NameOfPerm;
                    da.SelectCommand.Parameters.Add("@Manufname", SqlDbType.VarChar).Value = obj.SupplierName;
                    da.SelectCommand.Parameters.Add("@TypeofManuf", SqlDbType.VarChar).Value = obj.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@Statecode", SqlDbType.VarChar).Value = obj.Statecode;
                    da.SelectCommand.Parameters.Add("@Dist_code", SqlDbType.VarChar).Value = obj.DistCode;
                    da.SelectCommand.Parameters.Add("@MandCode", SqlDbType.VarChar).Value = obj.MandCode;
                    da.SelectCommand.Parameters.Add("@Vill_code", SqlDbType.VarChar).Value = obj.VillCode;
                    da.SelectCommand.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = obj.MobNo;
                    da.SelectCommand.Parameters.Add("@TINNo", SqlDbType.VarChar).Value = obj.TINNo;
                    da.SelectCommand.Parameters.Add("@PAN", SqlDbType.VarChar).Value = obj.PANNo;
                    da.SelectCommand.Parameters.Add("@SGST", SqlDbType.VarChar).Value = obj.SGSTNo;
                    da.SelectCommand.Parameters.Add("@PinCode", SqlDbType.VarChar).Value = obj.Pincode;
                    da.SelectCommand.Parameters.Add("@LicenseNo", SqlDbType.VarChar).Value = obj.LicNo;
                    da.SelectCommand.Parameters.Add("@Lfromdt", SqlDbType.Date).Value = obj.Dt_Valid_Fm;
                    da.SelectCommand.Parameters.Add("@Ltodt", SqlDbType.Date).Value = obj.Dt_Valid_To;
                    da.SelectCommand.Parameters.Add("@Annual_LicCap", SqlDbType.VarChar).Value = obj.Annual_Lic_Capacity;
                    da.SelectCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = obj.Address;
                    da.SelectCommand.Parameters.Add("@User_Type", SqlDbType.VarChar).Value = obj.UserType;
                    da.SelectCommand.Parameters.Add("@IpAddress", SqlDbType.VarChar).Value = obj.IPAddress;
                    da.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = obj.UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        //-added by Prog-M-03052023
        public DataTable ExciseMandal(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("EXDistrict_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@Distcode", SqlDbType.VarChar).Value = obj.DistCode;

                    da.SelectCommand.Parameters.Add("@stationCode", SqlDbType.VarChar).Value = obj.ExStation;

                    da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = obj.Status;

                    if (obj.Action == "DBR_DT" || obj.Action == "DBAD_DT" || obj.Action == "DBPD_DT" || obj.Action == "DBRDT_DT" || obj.Action == "SHO_DT")  //   
                    {
                        da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.VarChar).Value = obj.BdrWest;
                        da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.VarChar).Value = obj.BdrNorth;
                    }
                    else
                    {
                        da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.Date).Value = obj.BdrWest;
                        da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.Date).Value = obj.BdrNorth;
                    }
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        //-added by Prog-M-03052023

        public DataTable GetEventDetailsBySHO(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetEventDetailsBySho", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@Distcode", SqlDbType.VarChar).Value = obj.DistCode;

                    da.SelectCommand.Parameters.Add("@stationCode", SqlDbType.VarChar).Value = obj.ExStation;

                    da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = obj.Status;

                    if (obj.Action == "DBR_DT" || obj.Action == "DBAD_DT" || obj.Action == "DBPD_DT" || obj.Action == "DBRDT_DT" || obj.Action == "SHO_DT")  //   
                    {
                        da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.VarChar).Value = obj.BdrWest;
                        da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.VarChar).Value = obj.BdrNorth;
                    }
                    else
                    {
                        da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.Date).Value = obj.BdrWest;
                        da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.Date).Value = obj.BdrNorth;
                    }
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable ShamshabadReport(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Shamshabad_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@Distcode", SqlDbType.VarChar).Value = obj.DistCode;

                    da.SelectCommand.Parameters.Add("@stationCode", SqlDbType.VarChar).Value = obj.ExStation;
                    da.SelectCommand.Parameters.Add("@ExDist_Cd", SqlDbType.VarChar).Value = obj.ExDistCode;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable EventReg_IUR(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("EventReg_IUR_NEW", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Reg_No", SqlDbType.VarChar).Value = obj.Reg_Code;
                    da.SelectCommand.Parameters.Add("@AppName", SqlDbType.VarChar).Value = obj.AppName;
                    da.SelectCommand.Parameters.Add("@Aadhaar", SqlDbType.VarChar).Value = obj.Aadhaar;
                    da.SelectCommand.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = obj.MobNo;
                    da.SelectCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = obj.Email;
                    da.SelectCommand.Parameters.Add("@Age", SqlDbType.VarChar).Value = obj.Age;
                    da.SelectCommand.Parameters.Add("@Fname", SqlDbType.VarChar).Value = obj.FatherName;
                    da.SelectCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = obj.Address;
                    da.SelectCommand.Parameters.Add("@Hno", SqlDbType.VarChar).Value = obj.HouseNo;
                    da.SelectCommand.Parameters.Add("@Name_Premises", SqlDbType.VarChar).Value = obj.NameOfPerm;
                    da.SelectCommand.Parameters.Add("@Street", SqlDbType.VarChar).Value = obj.Street;
                    da.SelectCommand.Parameters.Add("@Bdr_East", SqlDbType.VarChar).Value = obj.BdrEast;
                    da.SelectCommand.Parameters.Add("@Bdr_West", SqlDbType.VarChar).Value = obj.BdrWest;
                    da.SelectCommand.Parameters.Add("@Bdr_North", SqlDbType.VarChar).Value = obj.BdrNorth;
                    da.SelectCommand.Parameters.Add("@Bdr_South", SqlDbType.VarChar).Value = obj.BdrSouth;
                    da.SelectCommand.Parameters.Add("@Statecode", SqlDbType.VarChar).Value = obj.Statecode;
                    da.SelectCommand.Parameters.Add("@Dist_code", SqlDbType.VarChar).Value = obj.DistCode;
                    da.SelectCommand.Parameters.Add("@MandCode", SqlDbType.VarChar).Value = obj.MandCode;
                    da.SelectCommand.Parameters.Add("@Division", SqlDbType.VarChar).Value = obj.Division;
                    da.SelectCommand.Parameters.Add("@Circle", SqlDbType.VarChar).Value = obj.Circle;
                    da.SelectCommand.Parameters.Add("@Vill_code", SqlDbType.VarChar).Value = obj.VillCode;
                    da.SelectCommand.Parameters.Add("@PinCode", SqlDbType.VarChar).Value = obj.Pincode;
                    da.SelectCommand.Parameters.Add("@ExDist_Cd", SqlDbType.VarChar).Value = obj.ExDistCode;
                    da.SelectCommand.Parameters.Add("@ExStationCode", SqlDbType.VarChar).Value = obj.ExStation;
                    da.SelectCommand.Parameters.Add("@Rule7", SqlDbType.VarChar).Value = obj.Rule7;
                    da.SelectCommand.Parameters.Add("@Date", SqlDbType.VarChar).Value = obj.EDate;
                    da.SelectCommand.Parameters.Add("@Eventtime", SqlDbType.VarChar).Value = obj.Eventtime;
                    da.SelectCommand.Parameters.Add("@Event_Occasion", SqlDbType.VarChar).Value = obj.EventOccasion;
                    //  da.SelectCommand.Parameters.Add("@License_Fee", SqlDbType.VarChar).Value = obj.License_Fee;
                    // da.SelectCommand.Parameters.Add("@Total_FeePaid", SqlDbType.Decimal).Value = obj.TotalFeePaid;

                    da.SelectCommand.Parameters.Add("@ShoRemarks", SqlDbType.VarChar).Value = obj.Remarks;
                    da.SelectCommand.Parameters.Add("@ShoInspecDt", SqlDbType.VarChar).Value = obj.LicData;
                    da.SelectCommand.Parameters.Add("@ShoInspecTime", SqlDbType.Decimal).Value = obj.TotalFeePaid;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    da.SelectCommand.Parameters.Add("@IpAddress", SqlDbType.VarChar).Value = obj.IPAddress;

                    da.SelectCommand.Parameters.Add("@DocNme", SqlDbType.VarChar).Value = obj.fileNme;
                    da.SelectCommand.Parameters.Add("@DocSizee", SqlDbType.VarChar).Value = obj.fileSizee;
                    da.SelectCommand.Parameters.Add("@DocTypee", SqlDbType.VarChar).Value = obj.fileTypee;
                    da.SelectCommand.Parameters.AddWithValue("@Doccontentt", obj.contentt);
                    da.SelectCommand.Parameters.Add("@DocRemarks", SqlDbType.VarChar).Value = obj.DocRemarks;
                    da.SelectCommand.Parameters.Add("@AppStatus", SqlDbType.VarChar).Value = obj.SupStatus;
                    da.SelectCommand.Parameters.Add("@EventID", SqlDbType.VarChar).Value = obj.EventId;
                    da.SelectCommand.Parameters.Add("@GHMC", SqlDbType.VarChar).Value = obj.ghmc;
                    da.SelectCommand.Parameters.Add("@EventType", SqlDbType.VarChar).Value = obj.EventType;
                    da.SelectCommand.Parameters.Add("@Paymenttype", SqlDbType.VarChar).Value = obj.Paymenttype;
                    da.SelectCommand.Parameters.Add("@License_Fee", SqlDbType.VarChar).Value = obj.License_Fee;
                    da.SelectCommand.Parameters.Add("@PermitId", SqlDbType.VarChar).Value = obj.PermitId;
                    da.SelectCommand.Parameters.Add("@TofM", SqlDbType.Int).Value = obj.TofM;
                    da.SelectCommand.Parameters.Add("@TofP", SqlDbType.Int).Value = obj.TofP;
                    if (obj.BdrEast == "TMPC_DT" || obj.BdrEast == "TMPC_DT_I")
                    {
                        da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.DateTime).Value = obj.dtfrom;
                        da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.DateTime).Value = obj.dtTo;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(obj.dtfrom.ToString()) && !string.IsNullOrEmpty(obj.dtTo.ToString()))
                        {
                            da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.DateTime).Value = obj.dtfrom;
                            da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.DateTime).Value = obj.dtTo;
                        }
                    }
                    da.SelectCommand.Parameters.Add("@IsRegionLevel", SqlDbType.Int).Value = obj.IsRegionLevel;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Duties_IUR(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("TypeDutiesFee_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DF_Code", SqlDbType.VarChar).Value = obj.Id;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.VarChar).Value = obj.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@DF_Descr", SqlDbType.VarChar).Value = obj.Type_of_Duties;
                    da.SelectCommand.Parameters.Add("@Minor_Head", SqlDbType.VarChar).Value = obj.MinorHead;
                    da.SelectCommand.Parameters.Add("@Sub_Head", SqlDbType.VarChar).Value = obj.SubHead;
                    da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = obj.IPAddress;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Duties_R(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Master_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = obj.IPAddress;

                    da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = obj.IPAddress;

                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable HOA_IUDR(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("HOA_IUDR", con))
                {

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ID", SqlDbType.VarChar).Value = obj.Id;
                    da.SelectCommand.Parameters.Add("@Type_of_Manu", SqlDbType.VarChar).Value = obj.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@HOA_Code", SqlDbType.VarChar).Value = obj.HOACode;
                    da.SelectCommand.Parameters.Add("@Major_Head", SqlDbType.VarChar).Value = obj.MajorHead;
                    da.SelectCommand.Parameters.Add("@SubMajor_Head", SqlDbType.VarChar).Value = obj.SubMajorHead;
                    da.SelectCommand.Parameters.Add("@Minor_Head", SqlDbType.VarChar).Value = obj.MinorHead;
                    da.SelectCommand.Parameters.Add("@Group_Head", SqlDbType.VarChar).Value = obj.GPHead;
                    da.SelectCommand.Parameters.Add("@Sub_Head", SqlDbType.VarChar).Value = obj.SubHead;
                    da.SelectCommand.Parameters.Add("@Detailed_Head", SqlDbType.VarChar).Value = obj.DtHead;
                    da.SelectCommand.Parameters.Add("@subDetailed_Head", SqlDbType.VarChar).Value = obj.SubDtHead;
                    da.SelectCommand.Parameters.Add("@IpAddress", SqlDbType.VarChar).Value = obj.IPAddress;
                    da.SelectCommand.Parameters.Add("@Name_Of_Treasury", SqlDbType.VarChar).Value = obj.NameOfTreasury;
                    //da.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = obj.UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
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
                    da.SelectCommand.Parameters.Add("@Supplier_Code", SqlDbType.VarChar).Value = Obj.Supplier_Code;
                    da.SelectCommand.Parameters.Add("@Installment", SqlDbType.VarChar).Value = Obj.Installment;

                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable ManufacoryMasters(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("TypeManFactory_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    // da.SelectCommand.Parameters.Add("@Type_Man_Nm", SqlDbType.Int).Value = Obj.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.VarChar).Value = Obj.MajorHead;
                    // da.SelectCommand.Parameters.Add("@Minor_Head_Code", SqlDbType.VarChar).Value = Obj.MinorHead;
                    // da.SelectCommand.Parameters.Add("@Sub_Head", SqlDbType.VarChar).Value = Obj.SubHead;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable ManufacoryMasters_All(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Type_Manf", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.VarChar).Value = Obj.ManufCd;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Minor_IUR(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("MinorHead_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = obj.Id;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = obj.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@Minor_Head", SqlDbType.VarChar).Value = obj.MinorHead;
                    da.SelectCommand.Parameters.Add("@Minor_Head_Desc", SqlDbType.VarChar).Value = obj.MinorHeadDesc;
                    da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = obj.IPAddress;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable SubHead_IUDR(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SubHead_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = obj.Id;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = obj.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@Minor_Head", SqlDbType.VarChar).Value = obj.MinorHead;
                    da.SelectCommand.Parameters.Add("@Minor_Head_Desc", SqlDbType.VarChar).Value = obj.MinorHeadDesc;
                    da.SelectCommand.Parameters.Add("@Sub_Head_Code", SqlDbType.VarChar).Value = obj.SubHead;
                    da.SelectCommand.Parameters.Add("@Sub_Head_Desc", SqlDbType.VarChar).Value = obj.SubHeadDesc;
                    da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = obj.IPAddress;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetPaymentSaveDtls(Supplier_BE objreg, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InsertPaymentDtls_NEW", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = objreg.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@Minor_Head", SqlDbType.VarChar).Value = objreg.MinorHead;
                    da.SelectCommand.Parameters.Add("@Sub_Head_Code", SqlDbType.VarChar).Value = objreg.SubHead;
                    da.SelectCommand.Parameters.Add("@DFCode", SqlDbType.Int).Value = objreg.Type_of_Duties;
                    da.SelectCommand.Parameters.Add("@SupplierCode", SqlDbType.VarChar).Value = objreg.Supplier_Code;
                    da.SelectCommand.Parameters.Add("@SupplierNm", SqlDbType.VarChar).Value = objreg.SupplierName;
                    da.SelectCommand.Parameters.Add("@DeptCode", SqlDbType.VarChar).Value = objreg.DeptCode;
                    da.SelectCommand.Parameters.Add("@DDOCode", SqlDbType.VarChar).Value = objreg.DDoCode;
                    da.SelectCommand.Parameters.Add("@HOAccount", SqlDbType.VarChar).Value = objreg.HOAccount;
                    da.SelectCommand.Parameters.Add("@DeptTransid", SqlDbType.VarChar).Value = objreg.DeptTransid;
                    da.SelectCommand.Parameters.Add("@RemitterName", SqlDbType.VarChar).Value = objreg.RemitterName;
                    da.SelectCommand.Parameters.Add("@Amount", SqlDbType.Decimal).Value = objreg.Amount;
                    da.SelectCommand.Parameters.Add("@PaymentRemarks", SqlDbType.VarChar).Value = objreg.PaymentRemarks;
                    da.SelectCommand.Parameters.Add("@PaymentMode", SqlDbType.VarChar).Value = objreg.PaymentMode;
                    da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = objreg.IpAddress;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = objreg.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }


        }
        public DataTable GetPaymentSaveCPEDtls(Supplier_BE objreg, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InsertPaymentDtls_NEW", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = objreg.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@Minor_Head", SqlDbType.VarChar).Value = objreg.MinorHead;
                    da.SelectCommand.Parameters.Add("@Sub_Head_Code", SqlDbType.VarChar).Value = objreg.SubHead;
                    da.SelectCommand.Parameters.Add("@DFCode", SqlDbType.Int).Value = objreg.Type_of_Duties;
                    da.SelectCommand.Parameters.Add("@SupplierCode", SqlDbType.VarChar).Value = objreg.Supplier_Code;
                    da.SelectCommand.Parameters.Add("@SupplierNm", SqlDbType.VarChar).Value = objreg.SupplierName;
                    da.SelectCommand.Parameters.Add("@DeptCode", SqlDbType.VarChar).Value = objreg.DeptCode;
                    da.SelectCommand.Parameters.Add("@DDOCode", SqlDbType.VarChar).Value = objreg.DDoCode;
                    da.SelectCommand.Parameters.Add("@HOAccount", SqlDbType.VarChar).Value = objreg.HOAccount;
                    da.SelectCommand.Parameters.Add("@DeptTransid", SqlDbType.VarChar).Value = objreg.DeptTransid;
                    da.SelectCommand.Parameters.Add("@RemitterName", SqlDbType.VarChar).Value = objreg.RemitterName;
                    da.SelectCommand.Parameters.Add("@Installmet", SqlDbType.Int).Value = objreg.Installment;
                    da.SelectCommand.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = objreg.TotalFeePaid;
                    da.SelectCommand.Parameters.Add("@Amount", SqlDbType.Decimal).Value = objreg.Amount;
                    da.SelectCommand.Parameters.Add("@PaymentRemarks", SqlDbType.VarChar).Value = objreg.PaymentRemarks;
                    da.SelectCommand.Parameters.Add("@PaymentMode", SqlDbType.VarChar).Value = objreg.PaymentMode;
                    da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = objreg.IpAddress;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = objreg.Action;
                    da.SelectCommand.Parameters.Add("@P_Installment", SqlDbType.SmallInt).Value = objreg.Installment_No;
                    da.SelectCommand.Parameters.Add("@P_ActivityType", SqlDbType.Char).Value = objreg.ActivityType;
                    da.SelectCommand.Parameters.Add("@P_TypeOfPayment", SqlDbType.Int).Value = objreg.TypePayment;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }


        }
        public DataTable GetPaymentSaveCPEDtls_LateFee(Supplier_BE objreg, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InsertPaymentDtls_NEW", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = objreg.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@Minor_Head", SqlDbType.VarChar).Value = objreg.MinorHead;
                    da.SelectCommand.Parameters.Add("@Sub_Head_Code", SqlDbType.VarChar).Value = objreg.SubHead;
                    da.SelectCommand.Parameters.Add("@DFCode", SqlDbType.Int).Value = objreg.Type_of_Duties;
                    da.SelectCommand.Parameters.Add("@SupplierCode", SqlDbType.VarChar).Value = objreg.Supplier_Code;
                    da.SelectCommand.Parameters.Add("@SupplierNm", SqlDbType.VarChar).Value = objreg.SupplierName;
                    da.SelectCommand.Parameters.Add("@DeptCode", SqlDbType.VarChar).Value = objreg.DeptCode;
                    da.SelectCommand.Parameters.Add("@DDOCode", SqlDbType.VarChar).Value = objreg.DDoCode;
                    da.SelectCommand.Parameters.Add("@HOAccount", SqlDbType.VarChar).Value = objreg.HOAccount;
                    da.SelectCommand.Parameters.Add("@DeptTransid", SqlDbType.VarChar).Value = objreg.DeptTransid;
                    da.SelectCommand.Parameters.Add("@RemitterName", SqlDbType.VarChar).Value = objreg.RemitterName;
                    da.SelectCommand.Parameters.Add("@Installmet", SqlDbType.Int).Value = objreg.Installment;
                    da.SelectCommand.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = objreg.TotalFeePaid;
                    da.SelectCommand.Parameters.Add("@Amount", SqlDbType.Decimal).Value = objreg.Amount;
                    da.SelectCommand.Parameters.Add("@PaymentRemarks", SqlDbType.VarChar).Value = objreg.PaymentRemarks;
                    da.SelectCommand.Parameters.Add("@PaymentMode", SqlDbType.VarChar).Value = objreg.PaymentMode;
                    da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = objreg.IpAddress;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = objreg.Action;
                    da.SelectCommand.Parameters.Add("@P_Installment", SqlDbType.SmallInt).Value = objreg.Installment_No;
                    da.SelectCommand.Parameters.Add("@P_ActivityType", SqlDbType.Char).Value = objreg.ActivityType;
                    da.SelectCommand.Parameters.Add("@P_TypeOfPayment", SqlDbType.Int).Value = objreg.TypePayment;
                    da.SelectCommand.Parameters.Add("@P_Penalty_Amount", SqlDbType.Decimal).Value = objreg.PenaltyAmount;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }


        }
        public DataTable GetPaymentSaveCPEDtls_RSP(Supplier_BE objreg, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InsertPaymentDtls_NEW_RSP", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = objreg.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@Minor_Head", SqlDbType.VarChar).Value = objreg.MinorHead;
                    da.SelectCommand.Parameters.Add("@Sub_Head_Code", SqlDbType.VarChar).Value = objreg.SubHead;
                    da.SelectCommand.Parameters.Add("@DFCode", SqlDbType.Int).Value = objreg.Type_of_Duties;
                    da.SelectCommand.Parameters.Add("@SupplierCode", SqlDbType.VarChar).Value = objreg.Supplier_Code;
                    da.SelectCommand.Parameters.Add("@SupplierNm", SqlDbType.VarChar).Value = objreg.SupplierName;
                    da.SelectCommand.Parameters.Add("@DeptCode", SqlDbType.VarChar).Value = objreg.DeptCode;
                    da.SelectCommand.Parameters.Add("@DDOCode", SqlDbType.VarChar).Value = objreg.DDoCode;
                    da.SelectCommand.Parameters.Add("@HOAccount", SqlDbType.VarChar).Value = objreg.HOAccount;
                    da.SelectCommand.Parameters.Add("@DeptTransid", SqlDbType.VarChar).Value = objreg.DeptTransid;
                    da.SelectCommand.Parameters.Add("@RemitterName", SqlDbType.VarChar).Value = objreg.RemitterName;
                    da.SelectCommand.Parameters.Add("@Installmet", SqlDbType.Int).Value = objreg.Installment;
                    da.SelectCommand.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = objreg.TotalFeePaid;
                    da.SelectCommand.Parameters.Add("@Amount", SqlDbType.Decimal).Value = objreg.Amount;
                    da.SelectCommand.Parameters.Add("@PaymentRemarks", SqlDbType.VarChar).Value = objreg.PaymentRemarks;
                    da.SelectCommand.Parameters.Add("@PaymentMode", SqlDbType.VarChar).Value = objreg.PaymentMode;
                    da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = objreg.IpAddress;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = objreg.Action;
                    da.SelectCommand.Parameters.Add("@P_Installment", SqlDbType.SmallInt).Value = objreg.Installment_No;
                    da.SelectCommand.Parameters.Add("@P_ActivityType", SqlDbType.Char).Value = objreg.ActivityType;
                    da.SelectCommand.Parameters.Add("@P_TypeOfPayment", SqlDbType.Int).Value = objreg.TypePayment;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }


        }
        public DataTable GetPaymentUpdateDtls(Supplier_BE objreg, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InsertPaymentDtls_NEW", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    string RegNo = null;
                    if (!string.IsNullOrEmpty(objreg.Reg_Code))
                    {
                        RegNo = objreg.Reg_Code;
                    }
                    da.SelectCommand.Parameters.Add("@Reg_No", SqlDbType.VarChar).Value = RegNo;
                    da.SelectCommand.Parameters.Add("@DeptTransid", SqlDbType.VarChar).Value = objreg.DeptTransid;
                    da.SelectCommand.Parameters.Add("@BankStatus", SqlDbType.VarChar).Value = objreg.BankStatus;
                    da.SelectCommand.Parameters.Add("@ChallanNumber", SqlDbType.VarChar).Value = objreg.ChallanNumber;
                    da.SelectCommand.Parameters.Add("@TreasuryDate", SqlDbType.Date).Value = objreg.TreasuryDate;
                    da.SelectCommand.Parameters.Add("@BankCode", SqlDbType.VarChar).Value = objreg.BankCode;
                    da.SelectCommand.Parameters.Add("@BankTransid", SqlDbType.VarChar).Value = objreg.BankTransid;
                    da.SelectCommand.Parameters.Add("@Amount", SqlDbType.Decimal).Value = objreg.Amount;
                    da.SelectCommand.Parameters.Add("@BankDate", SqlDbType.Date).Value = objreg.BankDate;
                    da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = objreg.IpAddress;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = objreg.Action;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }


        }

        public DataTable GetPaymentUpdateDtls_RSP(Supplier_BE objreg, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InsertPaymentDtls_NEW_RSP", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    string RegNo = null;
                    if (!string.IsNullOrEmpty(objreg.Reg_Code))
                    {
                        RegNo = objreg.Reg_Code;
                    }
                    da.SelectCommand.Parameters.Add("@Reg_No", SqlDbType.VarChar).Value = RegNo;
                    da.SelectCommand.Parameters.Add("@DeptTransid", SqlDbType.VarChar).Value = objreg.DeptTransid;
                    da.SelectCommand.Parameters.Add("@BankStatus", SqlDbType.VarChar).Value = objreg.BankStatus;
                    da.SelectCommand.Parameters.Add("@ChallanNumber", SqlDbType.VarChar).Value = objreg.ChallanNumber;
                    da.SelectCommand.Parameters.Add("@TreasuryDate", SqlDbType.Date).Value = objreg.TreasuryDate;
                    da.SelectCommand.Parameters.Add("@BankCode", SqlDbType.VarChar).Value = objreg.BankCode;
                    da.SelectCommand.Parameters.Add("@BankTransid", SqlDbType.VarChar).Value = objreg.BankTransid;
                    da.SelectCommand.Parameters.Add("@Amount", SqlDbType.Decimal).Value = objreg.Amount;
                    da.SelectCommand.Parameters.Add("@BankDate", SqlDbType.Date).Value = objreg.BankDate;
                    da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = objreg.IpAddress;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = objreg.Action;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }


        }
        public DataTable GetBankdetailssendtotreasuryDAL(string flag, DataTable dtt, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("UpdateBankStatus", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (dtt != null)
                    {
                        if (dtt.Rows.Count > 0)
                        {
                            da.SelectCommand.Parameters.Add("@tvp", SqlDbType.Structured).Value = dtt;
                        }
                    }
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = flag;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }


        }

        public DataTable GetPaymentDtls(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetPayMentDtls", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = objBE.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@Sub_Head", SqlDbType.Int).Value = objBE.SubHead;
                    da.SelectCommand.Parameters.Add("@Minor_Head", SqlDbType.BigInt).Value = objBE.MinorHead;
                    da.SelectCommand.Parameters.Add("@DF_Code", SqlDbType.BigInt).Value = objBE.DFCode;
                    da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.DateTime).Value = objBE.dtfrom;
                    da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.DateTime).Value = objBE.dtTo;
                    da.SelectCommand.Parameters.Add("@Role", SqlDbType.Int).Value = objBE.Role;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = objBE.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }







        public DataTable GetPaymentForEvent(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("EventPermitWPayment", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.DateTime).Value = objBE.dtfrom;
                    da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.DateTime).Value = objBE.dtTo;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = objBE.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GettextFile(Supplier_BE objBE, DataTable dttemp, string ConnKey)
        {
            throw new NotImplementedException();
        }

        public void InsertSharedFilesDL(Supplier_BE objBE, string ConnKey)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDashboardData(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DashboardReport", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    // da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = objBE.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetGetUploadDocSelectDAL(Supplier_BE objbe, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Insert_UploadDocs_NEW", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Reg_No", objbe.Reg_Code);
                    da.SelectCommand.Parameters.AddWithValue("@Applicantiontype", objbe.ApplicationType);
                    da.SelectCommand.Parameters.AddWithValue("@UploadDocCode", objbe.UploadDco_Code);
                    da.SelectCommand.Parameters.AddWithValue("@UploadFileid", objbe.UploadDco_FileID);
                    da.SelectCommand.Parameters.AddWithValue("@UploadFile", objbe.UploadFile);
                    da.SelectCommand.Parameters.AddWithValue("@UploadType", objbe.UploadFiletype);
                    da.SelectCommand.Parameters.AddWithValue("@UploadDocSno", objbe.SNo);
                    da.SelectCommand.Parameters.AddWithValue("@Action", objbe.Action);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }


        }

        public DataTable DistrictStationMapping(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ExDistStationMapping_IUR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = obj.DistCode;
                    da.SelectCommand.Parameters.Add("@ExDistCode", SqlDbType.VarChar).Value = obj.ExDistCode;
                    da.SelectCommand.Parameters.Add("@ExStationCode", SqlDbType.VarChar).Value = obj.ExStation;
                    da.SelectCommand.Parameters.Add("@ExStationName", SqlDbType.VarChar).Value = obj.NameOfPerm;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = obj.MandCode;
                    da.SelectCommand.Parameters.Add("@VillageCode", SqlDbType.VarChar).Value = obj.VillCode;
                    da.SelectCommand.Parameters.Add("@IPAddress", SqlDbType.VarChar).Value = obj.IPAddress;
                    da.SelectCommand.Parameters.Add("@ExciseStationMapping_TVP", SqlDbType.Structured).Value = obj.TVP;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable RetailerDashboard(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RetailerDashboard_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ExDist_Cd", SqlDbType.VarChar).Value = obj.ExDistCode;
                    da.SelectCommand.Parameters.Add("@Rule7", SqlDbType.VarChar).Value = obj.Rule7;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    if (!string.IsNullOrEmpty(obj.dtfrom.ToString()) && !string.IsNullOrEmpty(obj.dtTo.ToString()))
                    {
                        da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.DateTime).Value = obj.dtfrom;
                        da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.DateTime).Value = obj.dtTo;
                    }
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        #region "Recent added 10-08-2023"

        public DataTable CyberChallanUpdate(DataTable challan, Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("CyberChallanUpdate", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter Cyber = new SqlParameter("@P_UpdateCyberChallans", challan);
                    Cyber.SqlDbType = SqlDbType.Structured;
                    da.SelectCommand.Parameters.Add(Cyber);
                    da.SelectCommand.Parameters.Add("@From", SqlDbType.DateTime).Value = obj.dtfrom;
                    da.SelectCommand.Parameters.Add("@To", SqlDbType.DateTime).Value = obj.dtTo;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable MultipleCyberChallanUpdate(DataTable challan, Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("MultipleCyberChallanUpdate", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter Cyber = new SqlParameter("@P_UpdateCyberChallan", challan);
                    Cyber.SqlDbType = SqlDbType.Structured;
                    da.SelectCommand.Parameters.Add(Cyber);
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetRetailerDetails(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetDDODetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_DeptCode", SqlDbType.VarChar).Value = obj.DepotCode;
                    da.SelectCommand.Parameters.Add("@P_RetailerCode", SqlDbType.VarChar).Value = obj.RetailerCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetRetailerDetails_MD(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetDDODetailsByDepotCode", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_DeptCode", SqlDbType.VarChar).Value = obj.DepotCode;
                    da.SelectCommand.Parameters.Add("@P_RetailerCode", SqlDbType.VarChar).Value = obj.RetailerCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetRetailerDetailsByID(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetRetailerDetailsByID", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_RetailerCode", SqlDbType.VarChar).Value = obj.RetailerCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }




        public DataTable GetRetailersDepotCode(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DepotCodes", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetRetailerDetails_Report(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Retailers_Available", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UnitCode", SqlDbType.VarChar).Value = obj.UnitCode;
                    da.SelectCommand.Parameters.Add("@RetailerType", SqlDbType.VarChar).Value = obj.RetailerType;
                    da.SelectCommand.Parameters.Add("@Status", SqlDbType.Int).Value = obj.Status;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }




        public DataTable GetBankWiseReport(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("BankWiseReport", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@From", SqlDbType.DateTime).Value = obj.FromDate;
                    da.SelectCommand.Parameters.Add("@To", SqlDbType.DateTime).Value = obj.ToDate;
                    da.SelectCommand.Parameters.Add("@BankName", SqlDbType.VarChar).Value = obj.BankName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetRetailer_WiseReport(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RetailerWise_Report", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UnitCode", SqlDbType.VarChar).Value = obj.UnitCode;
                    da.SelectCommand.Parameters.Add("@RetailerCode", SqlDbType.VarChar).Value = obj.RetailerCode;
                    da.SelectCommand.Parameters.Add("@From", SqlDbType.DateTime).Value = obj.FromDate;
                    da.SelectCommand.Parameters.Add("@To", SqlDbType.DateTime).Value = obj.ToDate;
                    //da.SelectCommand.Parameters.Add("@BankName", SqlDbType.VarChar).Value = obj.BankName;
                    //da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetSFT_WiseReport1(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SFT_Report", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@From", SqlDbType.DateTime).Value = obj.FromDate;
                    da.SelectCommand.Parameters.Add("@To", SqlDbType.DateTime).Value = obj.ToDate;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetLedger_WiseReport(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Ledger_Report", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@From", SqlDbType.DateTime).Value = obj.FromDate;
                    da.SelectCommand.Parameters.Add("@To", SqlDbType.DateTime).Value = obj.ToDate;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public bool GetAdd_Retailer(Supplier_BE obj, string ConnKey)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("Add_Retailer", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@Type_Retailer", SqlDbType.VarChar).Value = obj.RetailerType;
                        da.Parameters.Add("@RetailerCode", SqlDbType.VarChar).Value = obj.RetailerCode;
                        da.Parameters.Add("@Retailer_Name", SqlDbType.VarChar).Value = obj.RetailerName;
                        da.Parameters.Add("@DepotCode", SqlDbType.VarChar).Value = obj.DepotCode;
                        da.Parameters.Add("@RDist", SqlDbType.VarChar).Value = obj.RDist;
                        da.Parameters.Add("@ExDist", SqlDbType.VarChar).Value = obj.ExDist;
                        da.Parameters.Add("@License_Name", SqlDbType.VarChar).Value = obj.LicenseName;
                        da.Parameters.Add("@License_No", SqlDbType.VarChar).Value = obj.LicNo;
                        da.Parameters.Add("@Address1", SqlDbType.VarChar).Value = obj.Address1;
                        da.Parameters.Add("@Address2", SqlDbType.VarChar).Value = obj.Address2;
                        da.Parameters.Add("@Pan_No", SqlDbType.VarChar).Value = obj.PANNo;
                        da.Parameters.Add("@Status", SqlDbType.VarChar).Value = obj.Status;
                        da.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
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


        public DataTable GetUpdateRetailer(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Edit_Retailer", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@RetailerCode", SqlDbType.VarChar).Value = obj.Retailer_Code;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetRetailer_type(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RetailerType", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetExDistrict(string ConnKey)
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

        public DataTable GetRevenueDistrict(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RevenueDistricts", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public bool GetRetailerPaymentDtails(Supplier_BE objreg, string ConnKey)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("Retailer_Payments", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@P_DepotCode", SqlDbType.Int).Value = objreg.DepotCode;
                        da.Parameters.Add("@P_RetailerCode", SqlDbType.VarChar).Value = objreg.Retailer_Code;
                        da.Parameters.Add("@P_LicenseNO", SqlDbType.VarChar).Value = objreg.LicenseNO;
                        da.Parameters.Add("@P_Amount", SqlDbType.Decimal).Value = objreg.Amount;
                        da.Parameters.Add("@P_TransactionID", SqlDbType.VarChar).Value = objreg.DeptTransid;
                        da.Parameters.Add("@P_RetailerName", SqlDbType.VarChar).Value = objreg.RetailerName;
                        da.Parameters.Add("@P_DDOCODE", SqlDbType.VarChar).Value = objreg.DDoCode;
                        da.Parameters.Add("@P_Purpose", SqlDbType.VarChar).Value = objreg.Purpose;
                        da.Parameters.Add("@P_PtName", SqlDbType.VarChar).Value = objreg.LicenseName;
                        da.Parameters.Add("@P_CreatedBy", SqlDbType.VarChar).Value = objreg.CreatedBy;
                        con.Open();

                        //DataTable dt = new DataTable();
                        //da.Fill(dt);
                        //return dt;

                        if (da.ExecuteNonQuery().ToString() == "1")
                        {
                            result = true;
                        }
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                return result;
            }
        }

        //public bool MatchTransactionDetails(string TransactionID,string ConnKey)
        //{
        //    bool dt = false;
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(ConnKey))
        //        {
        //            using (SqlCommand da = new SqlCommand("MatchTransactionDetails", con))
        //            {
        //                da.CommandType = CommandType.StoredProcedure;
        //                da.Parameters.Add("@P_transaction_id", SqlDbType.VarChar).Value = TransactionID;
        //                con.Open();
        //                da.ExecuteNonQuery();
        //                dt = true;
        //                return dt;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        public DataTable MatchTransactionDetails(string TransactionID, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("MatchTransactionDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_transaction_id", SqlDbType.VarChar).Value = TransactionID;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public bool GetRetailerPaymentUpdateDtls(Supplier_BE objreg, string ConnKey)
        {
            bool dt = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("RetailerPaymentUpdate", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@P_TransactionID", SqlDbType.VarChar).Value = objreg.DeptTransid;
                        da.Parameters.Add("@P_BankTransactionID", SqlDbType.VarChar).Value = objreg.BankTransid;
                        da.Parameters.Add("@P_Challan", SqlDbType.VarChar).Value = objreg.ChallanNumber;
                        da.Parameters.Add("@P_BankName", SqlDbType.VarChar).Value = objreg.BankCode;
                        da.Parameters.Add("@P_TransactionDate", SqlDbType.Date).Value = objreg.TreasuryDate;
                        da.Parameters.Add("@P_BankStatus", SqlDbType.VarChar).Value = objreg.BankStatus;
                        da.Parameters.Add("@P_Amount", SqlDbType.Decimal).Value = objreg.Amount;
                        da.Parameters.Add("@P_HOA", SqlDbType.VarChar).Value = objreg.HOA;
                        da.Parameters.Add("@P_BankDate", SqlDbType.DateTime).Value = objreg.BankDate;
                        //DataTable dt = new DataTable();
                        //da.Fill(dt);
                        con.Open();
                        da.ExecuteNonQuery();
                        dt = true;
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetLedgerVsSFTVSTransReport(Supplier_BE objreg, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetLedgerVsSFTVSTransReport", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_FromDate", SqlDbType.DateTime).Value = objreg.FromDate;
                    da.SelectCommand.Parameters.Add("@P_ToDate", SqlDbType.DateTime).Value = objreg.ToDate;
                    da.SelectCommand.Parameters.Add("@P_PendingAction", SqlDbType.VarChar).Value = objreg.PendingAction;
                    da.SelectCommand.Parameters.Add("@P_PendingAction1", SqlDbType.VarChar).Value = objreg.PendingAction1;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GETRetailersByunitCode(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GETRetailersByunitCode", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_unitCode", SqlDbType.VarChar).Value = obj.UnitCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        #endregion

        #region "Retailer Insert Update"
        public DataTable Retailer_insert(DataTable retailer, Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Retailer_insert", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter Cyber = new SqlParameter("@Retailer_insert", retailer);
                    Cyber.SqlDbType = SqlDbType.Structured;
                    da.SelectCommand.Parameters.Add(Cyber);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable Retailer_Update(DataTable retailer, Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Retailer_update", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter Cyber = new SqlParameter("@Retailer_insert", retailer);
                    Cyber.SqlDbType = SqlDbType.Structured;
                    da.SelectCommand.Parameters.Add(Cyber);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetretailerInformation(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetRetailerInformation", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_retailer_code", SqlDbType.VarChar).Value = obj.Retailer_Code;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public bool RetailerConfirmation(string Retailer_Code, int Isconfirm, string ConnKey)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("RetailerConfirmation", con))
                    {

                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@P_Retailer_Code", SqlDbType.VarChar).Value = Retailer_Code;
                        da.Parameters.Add("@P_Isconfirm", SqlDbType.Int).Value = Isconfirm;

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

        public DataTable GetCPEPaymentLateFee(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetCPELateFeeInstallmetDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_Installment", SqlDbType.Int).Value = obj.Installment_No;
                    da.SelectCommand.Parameters.Add("@P_RetailerCode", SqlDbType.VarChar).Value = obj.Retailer_Code;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = obj.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@Sub_Head_Code", SqlDbType.Int).Value = obj.SubHead;


                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        #endregion "Retailer Insert Update"
        public DataSet GetViewPayment(Supplier_BE obj, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("View_Payment", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@RetailerCode", SqlDbType.VarChar).Value = obj.RetailerCode;

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

        public DataSet GetReceiptDetails(Supplier_BE obj, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetReceiptDetails", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@DeptID", SqlDbType.VarChar).Value = obj.DeptTransid;

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

        public DataSet GetCPE_Details(Supplier_BE obj, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetCPEPaymentDetails", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@InstallmentNo", SqlDbType.VarChar).Value = obj.InstallmentNo;
                        da.SelectCommand.Parameters.Add("@RetailerCode", SqlDbType.VarChar).Value = obj.RetailerCode;

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

        public DataTable Get_Retailer(Supplier_BE obj, string ConnKey)//method name
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("Get_Retailer", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@Retailer_code", SqlDbType.VarChar).Value = obj.RetailerCode;
                        da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.VarChar).Value = obj.from;
                        da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.VarChar).Value = obj.To;
                        //da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;

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

        public DataTable Get_transactions_transdatepending(Supplier_BE obj, string ConnKey)//method name
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("Get_Retailer_SalesProceeds_AC", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_FromDate", SqlDbType.DateTime).Value = obj.from;
                        da.SelectCommand.Parameters.Add("@P_ToDate", SqlDbType.DateTime).Value = obj.To;

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

        public DataTable Get_Retailer_SalesProceeds_AC_Fail(Supplier_BE obj, string ConnKey)//method name
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("Get_Retailer_SalesProceeds_AC_Fail", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@From", SqlDbType.VarChar).Value = obj.from;
                        da.SelectCommand.Parameters.Add("@To", SqlDbType.VarChar).Value = obj.To;



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


        public DataTable Retailer_CyberChallanUpdate(DataTable challan, Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Retailer_CyberChallanUpdate", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter Cyber = new SqlParameter("@P_UpdateCyberChallan", challan);
                    Cyber.SqlDbType = SqlDbType.Structured;
                    da.SelectCommand.Parameters.Add(Cyber);
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Retailer_FailureCyberChallanUpdate(DataTable challan, Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Retailer_FailureChallanUpdate", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter Cyber = new SqlParameter("@P_UpdateCyberChallan", challan);
                    Cyber.SqlDbType = SqlDbType.Structured;
                    da.SelectCommand.Parameters.Add(Cyber);
                    //da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public bool CTEL_Update(DataTable challan, Supplier_BE obj, string ConnKey)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("CTEL_Update", con))
                    {

                        da.CommandType = CommandType.StoredProcedure;
                        SqlParameter Cyber = new SqlParameter("@P_Updatecteldetails", challan);
                        Cyber.SqlDbType = SqlDbType.Structured;
                        da.Parameters.Add(Cyber);
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
        public bool Type_Of_Payment(Supplier_BE obj, string ConnKey)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("Type_Of_Payment", con))
                    {

                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@Retailer_Type_Code", SqlDbType.Int).Value = obj.RetailerTypeCode;
                        da.Parameters.Add("@Type_Payment", SqlDbType.Int).Value = obj.TypePayment;
                        da.Parameters.Add("@Payment_Desc", SqlDbType.VarChar).Value = obj.PaymentDesc;
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
        public DataSet GetSalesProceedingReceiptDetails(Supplier_BE obj, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetSalesProceedingReceiptDetails", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@DeptID", SqlDbType.VarChar).Value = obj.DeptTransid;

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


        public DataSet GetSalesProceedingsViewPayment(Supplier_BE obj, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetSalesProceedingsViewPayment", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@RetailerCode", SqlDbType.VarChar).Value = obj.RetailerCode;

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

        public DataTable GetEvent(Supplier_BE obj, string ConnKey)//method name
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("Event_Update", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@Mob_No", SqlDbType.VarChar).Value = obj.MobNo;
                        da.SelectCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = obj.Email;
                        da.SelectCommand.Parameters.Add("@DateOfEvent", SqlDbType.DateTime).Value = obj.Date;
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

        public DataTable GetDistrictEvent(Supplier_BE obj, string ConnKey)//method name
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("DistrictWisePermitDetails", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.Int).Value = obj.DistCode;
                        da.SelectCommand.Parameters.Add("@Year", SqlDbType.VarChar).Value = obj.Year;

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

        public DataTable GetEventStatus(Supplier_BE obj, string ConnKey)//method name
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("EventStatus", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@Mob_No", SqlDbType.VarChar).Value = obj.MobNo;
                        da.SelectCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = obj.Email;
                        da.SelectCommand.Parameters.Add("@DateOfEvent", SqlDbType.DateTime).Value = obj.Date;
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
        public DataTable EventUpdate_SHO(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("EventUpdate_SHO", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@AppReg_NO", SqlDbType.VarChar).Value = obj.Reg_Code;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public bool SHO_Event(Supplier_BE obj, string ConnKey)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("SHO_Event_Update", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@AppReg_NO", SqlDbType.VarChar).Value = obj.Reg_Code;
                        da.Parameters.Add("@App_Name", SqlDbType.VarChar).Value = obj.AppName;
                        da.Parameters.Add("@Mob_No", SqlDbType.VarChar).Value = obj.MobNo;
                        da.Parameters.Add("@Email", SqlDbType.VarChar).Value = obj.Email;
                        da.Parameters.Add("@Name_Premises", SqlDbType.VarChar).Value = obj.NameOfPerm;
                        da.Parameters.Add("@Street", SqlDbType.VarChar).Value = obj.Street;
                        da.Parameters.Add("@Bdr_East", SqlDbType.VarChar).Value = obj.BdrEast;
                        da.Parameters.Add("@Bdr_West", SqlDbType.VarChar).Value = obj.BdrWest;
                        da.Parameters.Add("@Bdr_North", SqlDbType.VarChar).Value = obj.BdrNorth;
                        da.Parameters.Add("@Bdr_South", SqlDbType.VarChar).Value = obj.BdrSouth;
                        da.Parameters.Add("@Date", SqlDbType.DateTime).Value = obj.ToDate;
                        da.Parameters.Add("@Eventtime", SqlDbType.VarChar).Value = obj.Eventtime;
                        da.Parameters.Add("@GHMC", SqlDbType.VarChar).Value = obj.ghmc;
                        //da.Parameters.Add("@Mandal", SqlDbType.VarChar).Value = obj.MandCode;
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



        #region "PaymentController"
        public DataSet GetPaymentDetails(string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetPaymentDetails", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        //da.SelectCommand.Parameters.Add("@DeptID", SqlDbType.VarChar).Value = obj.DeptTransid;

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
        #endregion "PaymentController"

        public DataTable GetPaymentDetails(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Download_PaymentDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataSet GetPaymentDetailsAPI(Supplier_BE obj, string ConnKey)
        {
            DataSet ds = null;
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Download_PaymentDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(ds);
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    //return dt;
                    return ds;
                }
            }
        }
        public DataTable EventMandal(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Event_Mandal", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@AppReg_NO", SqlDbType.VarChar).Value = obj.Reg_Code;
                    da.SelectCommand.Parameters.Add("@ExStation", SqlDbType.VarChar).Value = obj.ExStation;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable EventMandalAC(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Event_Mandal_AC", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@AppReg_NO", SqlDbType.VarChar).Value = obj.Reg_Code;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public bool Mandal_Update(Supplier_BE obj, string ConnKey)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("Mandal_Update", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@AppReg_NO", SqlDbType.VarChar).Value = obj.Reg_Code;
                        da.Parameters.Add("@Mandal", SqlDbType.VarChar).Value = obj.MandCode;
                        da.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = obj.DistCode;
                        //da.Parameters.Add("@ExDist_Cd", SqlDbType.VarChar).Value = obj.ExDistCode;
                        da.Parameters.Add("@VillCode", SqlDbType.VarChar).Value = obj.VillCode;
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
        public DataTable Get_Supplier(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Get_Supplier", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Supplier_Code", SqlDbType.VarChar).Value = obj.SupplierCode;
                    da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.DateTime).Value = obj.from;
                    da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.DateTime).Value = obj.To;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable Supplier_CyberChallanUpdate(DataTable challan, Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Supplier_CyberChallanUpdate", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter Cyber = new SqlParameter("@P_UpdateCyberChallan", challan);
                    Cyber.SqlDbType = SqlDbType.Structured;
                    da.SelectCommand.Parameters.Add(Cyber);
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable Events_DetailedView(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Event_Permits_DetailedView", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.VarChar).Value = obj.FDate;
                    da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.VarChar).Value = obj.TDate;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable Events_Permits(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetEvent_PermitsCount", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.VarChar).Value = obj.FDate;
                    da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.VarChar).Value = obj.TDate;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable Get_TypeofManfacturer(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("TypeofManfacturer", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable Get_Supplier_Report(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Supplier_Report", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Manuf_Code", SqlDbType.VarChar).Value = obj.ManufCd;
                    da.SelectCommand.Parameters.Add("@Manuf_Name", SqlDbType.VarChar).Value = obj.SupplierName;
                    da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.VarChar).Value = obj.FDate;
                    da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.VarChar).Value = obj.TDate;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable Get_SupplierDetails(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Supplier_Details", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Type_of_Manufacturing", SqlDbType.VarChar).Value = obj.ManufCd;
                    //da.SelectCommand.Parameters.Add("@Supplier_Name", SqlDbType.VarChar).Value = obj.SupplierName;
                    //da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.VarChar).Value = obj.FDate;
                    //da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.VarChar).Value = obj.TDate;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable Supplier(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Supplier", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Supplier_Code", SqlDbType.VarChar).Value = obj.SupplierCode;
                    da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.Date).Value = obj.FDate;
                    da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.Date).Value = obj.TDate;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        //
        public bool Rsp_insert(string Retailer_Code, string Retailer_Type, int Type_Payment, decimal Amount, string DPEoCode, string ConnKey)
        {
            bool result = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("RetailerSpecailPayments_Insert", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@P_Retailer_Code", SqlDbType.VarChar).Value = Retailer_Code;
                        da.Parameters.Add("@P_Retailer_Type", SqlDbType.VarChar).Value = Retailer_Type;
                        da.Parameters.Add("@P_Type_Payment", SqlDbType.Int).Value = Type_Payment;
                        da.Parameters.Add("@P_Amount", SqlDbType.Decimal).Value = Amount;
                        da.Parameters.Add("@P_DPEoCode", SqlDbType.VarChar).Value = DPEoCode;

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
        public DataTable GetRSPAmounts(string RetailerCode, int TypePayment, string ConnKey)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetRSPAmounts", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_RetailerCode", SqlDbType.VarChar).Value = RetailerCode;
                        da.SelectCommand.Parameters.Add("@P_Type_Payment", SqlDbType.Int).Value = TypePayment;

                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public DataTable GetDPEOForEvent(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DPEOEventReport", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.DateTime).Value = objBE.dtfrom;
                    da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.DateTime).Value = objBE.dtTo;
                    da.SelectCommand.Parameters.Add("@ExDist_Cd", SqlDbType.VarChar).Value = objBE.UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = objBE.Action;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetSHOForEvent(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SHOEventReport", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.DateTime).Value = objBE.dtfrom;
                    da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.DateTime).Value = objBE.dtTo;
                    da.SelectCommand.Parameters.Add("@ExDist_Cd", SqlDbType.VarChar).Value = objBE.UserName;
                    da.SelectCommand.Parameters.Add("@ExSho_Cd", SqlDbType.VarChar).Value = objBE.SHOID;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = objBE.Action;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetCpeDetails(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Get_CPEPaymentReport", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@InstallmentNo", SqlDbType.VarChar).Value = objBE.InstallmentNo;
                    da.SelectCommand.Parameters.Add("@RetailerCode", SqlDbType.VarChar).Value = objBE.RetailerCode;
                    da.SelectCommand.Parameters.Add("@From", SqlDbType.VarChar).Value = objBE.from;
                    da.SelectCommand.Parameters.Add("@To", SqlDbType.VarChar).Value = objBE.To;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetInstallmentNo(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Get_InstallmentNo", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_Type_Retailer", SqlDbType.VarChar).Value = Obj.Type_of_Manu;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetRetailerType(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Retailer_Type", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //da.SelectCommand.Parameters.Add("@P_Type_Retailer", SqlDbType.VarChar).Value = Obj.Type_of_Manu;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetDistrict_Slab_WiseRetailer_tax(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DistrictWiseSlabRetailer_Tax_Cons_Report", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@Type_Retailer", SqlDbType.VarChar).Value = objBE.RetailerType;
                    da.SelectCommand.Parameters.Add("@IsSpecial", SqlDbType.Int).Value = 0;
                    da.SelectCommand.Parameters.Add("@ExDist_Cd", SqlDbType.Int).Value = objBE.ExDist;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetDistrict_Slab_WiseRetailer_tax_Special(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DistrictWiseSlabRetailer_Tax_Cons_Report", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@Type_Retailer", SqlDbType.VarChar).Value = objBE.RetailerType;
                    da.SelectCommand.Parameters.Add("@IsSpecial", SqlDbType.Int).Value = 1;
                    da.SelectCommand.Parameters.Add("@ExDist_Cd", SqlDbType.Int).Value = objBE.ExDist;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetDistrict_Slab_WiseRetailer_tax_indiv(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DistrictWiseSlabRetailer_Tax_Indiv_Report", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@Type_Retailer", SqlDbType.VarChar).Value = objBE.RetailerType;

                    da.SelectCommand.Parameters.Add("@DDOCode", SqlDbType.VarChar).Value = objBE.DDoCode;
                    da.SelectCommand.Parameters.Add("@TypeofPayment", SqlDbType.Int).Value = objBE.SubHead;
                    da.SelectCommand.Parameters.Add("@Installment", SqlDbType.Int).Value = objBE.Installment;
                    da.SelectCommand.Parameters.Add("@SlabNo", SqlDbType.Int).Value = objBE.Type_of_Duties;


                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetDistrictWiseRetailer(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DistrictWiseRetailerReport", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@Type_Retailer", SqlDbType.VarChar).Value = objBE.RetailerType;
                    da.SelectCommand.Parameters.Add("@From", SqlDbType.VarChar).Value = objBE.from;
                    da.SelectCommand.Parameters.Add("@To", SqlDbType.VarChar).Value = objBE.To;
                    da.SelectCommand.Parameters.Add("@ExDist", SqlDbType.VarChar).Value = objBE.ExDist;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetDistrictWiseRetailerReport(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DistrictWiseRReport", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@Type_Retailer", SqlDbType.VarChar).Value = objBE.RetailerType;
                    da.SelectCommand.Parameters.Add("@From", SqlDbType.VarChar).Value = objBE.from;
                    da.SelectCommand.Parameters.Add("@To", SqlDbType.VarChar).Value = objBE.To;
                    da.SelectCommand.Parameters.Add("@ExDist", SqlDbType.VarChar).Value = objBE.ExDist;
                    //da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.VarChar).Value = objBE.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@Type_Payment", SqlDbType.VarChar).Value = objBE.TypePayment;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetExsitingRetailers(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetExsitingRetailers", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@P_Type_Retailer", SqlDbType.VarChar).Value = objBE.RetailerType;
                    da.SelectCommand.Parameters.Add("@P_ExDist", SqlDbType.VarChar).Value = objBE.ExDist;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetDepot(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Get_Depot", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //da.SelectCommand.Parameters.Add("@Role", SqlDbType.VarChar).Value = Obj.Role;
                    //da.SelectCommand.Parameters.Add("@DeptCode", SqlDbType.VarChar).Value = Obj.DeptCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }








        public bool CreateRetailer(Supplier_BE obj, string ConnKey)//method name
        {
            //DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            bool dt = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("Create_Retailer", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@Type_Retailer", SqlDbType.VarChar).Value = obj.RetailerType;
                        da.Parameters.Add("@Retailer_Code", SqlDbType.VarChar).Value = obj.Retailer_Code;
                        da.Parameters.Add("@Retailer_Name", SqlDbType.VarChar).Value = obj.RetailerName;
                        da.Parameters.Add("@DEPOTCODE", SqlDbType.VarChar).Value = obj.DepotCode;
                        da.Parameters.Add("@RDist", SqlDbType.VarChar).Value = obj.RDist;
                        da.Parameters.Add("@ExDist", SqlDbType.VarChar).Value = obj.ExDist;
                        da.Parameters.Add("@License_Name", SqlDbType.VarChar).Value = obj.LicenseName;
                        da.Parameters.Add("@License_No", SqlDbType.VarChar).Value = obj.LicenseNO;
                        da.Parameters.Add("@Excise_tax", SqlDbType.Decimal).Value = obj.ExTax;
                        da.Parameters.Add("@SlabNo", SqlDbType.VarChar).Value = obj.slabNo;
                        da.Parameters.Add("@Address", SqlDbType.VarChar).Value = obj.Address;
                        da.Parameters.Add("@Email_Id", SqlDbType.VarChar).Value = obj.Email;
                        da.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = obj.MobNo;
                        da.Parameters.Add("@Gazette_Code", SqlDbType.VarChar).Value = obj.GazetteCode;
                        da.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = obj.Pincode;
                        da.Parameters.Add("@Pan_Number", SqlDbType.VarChar).Value = obj.PANNo;
                        da.Parameters.Add("@LicenseValid_From", SqlDbType.DateTime).Value = null;
                        da.Parameters.Add("@LicenseValid_To", SqlDbType.DateTime).Value = null;
                        da.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = obj.CreatedBy;
                        da.Parameters.Add("@IsActive", SqlDbType.Int).Value = obj.IsActive;
                        con.Open();

                        da.ExecuteNonQuery();
                        dt = true;
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return dt;
            }
        }


        public DataTable GetSlab(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetSlabNo", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@RetailerType", SqlDbType.VarChar).Value = objBE.RetailerType;
                    da.SelectCommand.Parameters.Add("@SlabAmount", SqlDbType.VarChar).Value = objBE.Amount;
                    //da.SelectCommand.Parameters.Add("@To", SqlDbType.VarChar).Value = objBE.To;


                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetExDistrict(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetExDistrict", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = Obj.DistCode;
                    //da.SelectCommand.Parameters.Add("@ExDist_Cd", SqlDbType.VarChar).Value = Obj.ExDistCode;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetRetailer(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Get_RetailerDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Retailer_Code", SqlDbType.VarChar).Value = obj.RetailerCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetUserDetailsByDeptTransid(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetUserDetailsByDeptTransid", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_DeptTransid", SqlDbType.VarChar).Value = obj.DeptTransid;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetSalesProceedsByDepotCode(Supplier_BE obj, string ConnKey)//method name
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetSalesProceedsByDepotCode", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_DDOCODE ", SqlDbType.VarChar).Value = obj.DDoCode;
                        da.SelectCommand.Parameters.Add("@P_ROle", SqlDbType.VarChar).Value = obj.Role;
                        da.SelectCommand.Parameters.Add("@DeptCode", SqlDbType.VarChar).Value = obj.DepotName;
                        da.SelectCommand.Parameters.Add("@P_FromDate", SqlDbType.DateTime).Value = obj.from;
                        da.SelectCommand.Parameters.Add("@P_ToDate", SqlDbType.DateTime).Value = obj.To;
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

        public DataTable GetSalesProceedsPendingDetailsByDepotCode(Supplier_BE obj, string ConnKey)//method name
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetSalesProceedsPendingDetailsByDepotCode", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_DDOCODE ", SqlDbType.VarChar).Value = obj.DDoCode;
                        da.SelectCommand.Parameters.Add("@P_ROle", SqlDbType.VarChar).Value = obj.Role;
                        da.SelectCommand.Parameters.Add("@P_FromDate", SqlDbType.DateTime).Value = obj.from;
                        da.SelectCommand.Parameters.Add("@P_ToDate", SqlDbType.DateTime).Value = obj.To;
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
        public DataTable R_ResetPassword(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Retailer_ResetPassword", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@Retailer_Code", SqlDbType.VarChar).Value = objBE.RetailerCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetSPTransactionsVerified(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetSPTransactionsVerified", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@P_Date", SqlDbType.DateTime).Value = objBE.from;
                    da.SelectCommand.Parameters.Add("@P_Verified", SqlDbType.Int).Value = objBE.Verified;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetDepotExsitingRetailers(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetDepotExsitingRetailers", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    //da.SelectCommand.Parameters.Add("@P_Type_Retailer", SqlDbType.VarChar).Value = objBE.RetailerType;
                    da.SelectCommand.Parameters.Add("@DepotName", SqlDbType.VarChar).Value = objBE.DepotName;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetDepotsByRetailerCode(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetDepotsByRetailerCode", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@P_RetailerCode", SqlDbType.VarChar).Value = objBE.RetailerCode;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataSet GetEventDetailsByAppRegNo(string AppregNo, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetEventDetailsByAppRegNo", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@Reg_No", SqlDbType.VarChar).Value = AppregNo;
                        //da.SelectCommand.Parameters.Add("@Applicantiontype", SqlDbType.VarChar).Value = ApplicationType;
                        //da.SelectCommand.Parameters.Add("@UploadDocCode", SqlDbType.VarChar).Value = UploadDco_Code;
                        //da.SelectCommand.Parameters.Add("@UploadDocSno", SqlDbType.VarChar).Value =SNo;
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
        public DataSet GetDPEOEventDetailsByAppRegNo(string AppregNo, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetDPEOEventDetailsByAppRegNo", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@Reg_No", SqlDbType.VarChar).Value = AppregNo;
                        //da.SelectCommand.Parameters.Add("@ExDist_Cd", SqlDbType.VarChar).Value = ExDistCode;
                        //da.SelectCommand.Parameters.Add("@UploadDocCode", SqlDbType.VarChar).Value = UploadDco_Code;
                        //da.SelectCommand.Parameters.Add("@UploadDocSno", SqlDbType.VarChar).Value =SNo;
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



        public DataTable SalesProceedByDepot(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Sales_ProceedsByDepots", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@From", SqlDbType.VarChar).Value = objBE.from;
                    da.SelectCommand.Parameters.Add("@To", SqlDbType.VarChar).Value = objBE.To;
                    da.SelectCommand.Parameters.Add("@DepotName", SqlDbType.VarChar).Value = objBE.DepotName;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetDepot_Codes(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Get_DepotCodes", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@RoleId", SqlDbType.VarChar).Value = objBE.Role;
                    da.SelectCommand.Parameters.Add("@DepotName", SqlDbType.VarChar).Value = objBE.DepotName;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetRetailerSPTransactionsVerified(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetRetailerSPTransactionsVerified", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@P_Retailer_Code", SqlDbType.VarChar).Value = objBE.RetailerCode;
                    da.SelectCommand.Parameters.Add("@P_FromDate", SqlDbType.VarChar).Value = objBE.from;
                    da.SelectCommand.Parameters.Add("@P_ToDate", SqlDbType.VarChar).Value = objBE.To;
                    da.SelectCommand.Parameters.Add("@P_Verified", SqlDbType.Int).Value = objBE.Verified;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable Get_Supplier_Details(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Get_SupplierDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Supplier_Code", SqlDbType.VarChar).Value = obj.SupplierCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable Supplier_ResetPassword(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Supplier_ResetPassword", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@Supplier_Code", SqlDbType.VarChar).Value = objBE.SupplierCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GETEventPermitYearWise_New(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GETEventPermitYearWise_New", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@P_StartYear", SqlDbType.VarChar).Value = objBE.StartYear;
                    da.SelectCommand.Parameters.Add("@P_EndYear", SqlDbType.VarChar).Value = objBE.EndYear;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataSet Get_AdminDashboard_Details(Supplier_BE obj, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("Get_AdminDashboard_Details", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_FromDate", SqlDbType.VarChar).Value = obj.from;
                        da.SelectCommand.Parameters.Add("@P_ToDate", SqlDbType.VarChar).Value = obj.To;
                        da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = obj.Action;
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

        public DataTable Get_SFTChallans(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Get_SFT_Challans", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@From", SqlDbType.VarChar).Value = obj.from;
                    da.SelectCommand.Parameters.Add("@To", SqlDbType.VarChar).Value = obj.To;
                    da.SelectCommand.Parameters.Add("@BankName", SqlDbType.VarChar).Value = obj.BankName;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable Get_RetailerBankscrollDate(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("BankWise_ScrollDate", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_From", SqlDbType.VarChar).Value = obj.from;
                    da.SelectCommand.Parameters.Add("@P_To", SqlDbType.VarChar).Value = obj.To;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable Get_SFTBank(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Get_SFT_Bank", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@From", SqlDbType.VarChar).Value = obj.from;
                    da.SelectCommand.Parameters.Add("@To", SqlDbType.VarChar).Value = obj.To;
                    da.SelectCommand.Parameters.Add("@BankName", SqlDbType.VarChar).Value = obj.BankName;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable ManufacturerDetails(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Supplier_ManufacturerWise", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ManfCode", SqlDbType.VarChar).Value = Obj.ManufCd;
                    da.SelectCommand.Parameters.Add("@Supplier_Code", SqlDbType.VarChar).Value = Obj.Supplier_Code;
                    da.SelectCommand.Parameters.Add("@P_Role", SqlDbType.VarChar).Value = Obj.Role;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable ManufacturerDetails_new(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Supplier_ManufacturerWise_New", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ManfCode", SqlDbType.VarChar).Value = Obj.ManufCd;
                    da.SelectCommand.Parameters.Add("@Supplier_Code", SqlDbType.VarChar).Value = Obj.Supplier_Code;
                    da.SelectCommand.Parameters.Add("@Minor_Head ", SqlDbType.VarChar).Value = Obj.MinorHead;
                    da.SelectCommand.Parameters.Add("@Sub_Head ", SqlDbType.VarChar).Value = Obj.SubHead;
                    da.SelectCommand.Parameters.Add("@DF_Code ", SqlDbType.VarChar).Value = Obj.DFCode;

                    da.SelectCommand.Parameters.Add("@P_Role", SqlDbType.VarChar).Value = Obj.Role;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable RetailersActiveInActiveList(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetRetailer_ActiveInactiveList", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@IsActive", SqlDbType.VarChar).Value = Obj.IsActive;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable GetChallan_TransactionDetails(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetChallan_TransactionDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@transaction_id", SqlDbType.VarChar).Value = Obj.DeptTransid;
                    da.SelectCommand.Parameters.Add("@challan_num", SqlDbType.VarChar).Value = Obj.ChallanNumber;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable SupplierDtls(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SupplierDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Supplier_Code", SqlDbType.VarChar).Value = obj.SupplierCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public bool SupplierUpdate(Supplier_BE obj, string ConnKey)
        {
            bool dt = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("SupplierDetails_Update", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@Supplier_Code", SqlDbType.VarChar).Value = obj.SupplierCode;
                        da.Parameters.Add("@Type_of_Manufacturing", SqlDbType.VarChar).Value = obj.Type_of_Manu;
                        da.Parameters.Add("@Dist", SqlDbType.VarChar).Value = obj.DistCode;
                        da.Parameters.Add("@Mandal", SqlDbType.VarChar).Value = obj.MandCode;
                        da.Parameters.Add("@Village", SqlDbType.VarChar).Value = obj.VillCode;
                        da.Parameters.Add("@Address", SqlDbType.VarChar).Value = obj.Address;
                        da.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = obj.MobNo;
                        da.Parameters.Add("@Pincode", SqlDbType.VarChar).Value = obj.Pincode;
                        da.Parameters.Add("@Active", SqlDbType.Decimal).Value = obj.IsActive;
                        con.Open();

                        da.ExecuteNonQuery();
                        dt = true;
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return dt;
            }



        }


        public DataTable GetEventPermits_Approve_Rejected(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetEventPermits_Approve_Rejected", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@ExDist_Cd", SqlDbType.VarChar).Value = objBE.ExDistCode;
                    da.SelectCommand.Parameters.Add("@From", SqlDbType.VarChar).Value = objBE.from;
                    da.SelectCommand.Parameters.Add("@To", SqlDbType.VarChar).Value = objBE.To;
                    da.SelectCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = objBE.Status;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataSet GetEODBDashboardInfo(Supplier_BE obj, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetEODBDashboardInfo", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public DataTable EODB_Dashboard_Insert(DataTable EoDBInformation, Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("EODB_Dashboard_Insert", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_FromName", SqlDbType.VarChar).Value = obj.EODBFormName;
                    da.SelectCommand.Parameters.Add("@P_Formdate", SqlDbType.DateTime).Value = obj.EODBFromDate;
                    da.SelectCommand.Parameters.Add("@P_Todate", SqlDbType.DateTime).Value = obj.EODBToDate;
                    da.SelectCommand.Parameters.Add("@P_CreatedBy", SqlDbType.VarChar).Value = obj.EODBCreatedBy;
                    SqlParameter EoDBInformation1 = new SqlParameter("@EoDBInformation", EoDBInformation);
                    EoDBInformation1.SqlDbType = SqlDbType.Structured;
                    da.SelectCommand.Parameters.Add(EoDBInformation1);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataSet GetServicechartDetails(Supplier_BE obj, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetEODBServicechartDetails", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public DataTable Supplier_Payments_StateWise(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Supplier_Payments_StateWise", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.VarChar).Value = Obj.Type_of_Manu;
                    da.SelectCommand.Parameters.Add("@Dist", SqlDbType.VarChar).Value = Obj.DistCode;
                    //da.SelectCommand.Parameters.Add("@P_Role", SqlDbType.VarChar).Value = Obj.Role;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable Get_Pending_transactions_transdate(Supplier_BE obj, string ConnKey)//method name
        {
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("GetPendingRetailersByDate", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_FromDate", SqlDbType.VarChar).Value = obj.from;
                        da.SelectCommand.Parameters.Add("@P_ToDate", SqlDbType.VarChar).Value = obj.To;

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
        public DataTable GetDistrictWise_Installment_Report(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetDistrictWise_Installment_Report", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@Type_Retailer", SqlDbType.VarChar).Value = objBE.RetailerType;
                    da.SelectCommand.Parameters.Add("@TypePayment", SqlDbType.VarChar).Value = objBE.TypePayment;
                    da.SelectCommand.Parameters.Add("@InstallmentNo", SqlDbType.Int).Value = objBE.InstallmentNo;
                    da.SelectCommand.Parameters.Add("@FinID", SqlDbType.Int).Value = objBE.FinID;
                    da.SelectCommand.Parameters.Add("@ExDist_Cd", SqlDbType.Int).Value = objBE.ExDist;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetRetailerType_Payment_Installment(Supplier_BE Obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetTypeOfPaymetsByRetailerCode", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Retailer_Code", SqlDbType.VarChar).Value = Obj.Retailer_Code;
                    da.SelectCommand.Parameters.Add("@Type_Payment", SqlDbType.VarChar).Value = Obj.TypePayment;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Obj.Action;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        #region "START RENEWALS"
        public DataSet GetSupplierDetails(string Supplier_Code, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("R_GetSupplierDetails", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_Supplier_Code", SqlDbType.VarChar).Value = Supplier_Code;
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

        public DataSet GetRetailerDetails(string Retailer_Code, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("R_GetRetailerRenewalDetails", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_Retailer_Code", SqlDbType.VarChar).Value = Retailer_Code;
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

        public DataTable MBRenewalApplications_Insert(string Supplier_Code, string Sd_Bg_FdrNo, string Sd_Bg_FdrDate, string Sd_CD_Challan_No, string Sd_CD_challan_date, decimal Sd_Amount, string @Sd_Bank, string @Validity_FromDate
            , string Validity_ToDate, int Status_ID, string SystemIP, string CreatedBy, string Sd_BranchName, int Type_Man_Cd, int Application_No, string Ex_Dist, string SHOUsername, int IsBG_CD, DataTable FileUpload, string ConnKey)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("R_MBRenewalApplications_Insert", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Supplier_Code", SqlDbType.VarChar).Value = Supplier_Code;
                    da.SelectCommand.Parameters.Add("@Sd_Bg_FdrNo", SqlDbType.VarChar).Value = Sd_Bg_FdrNo;
                    da.SelectCommand.Parameters.Add("@Sd_Bg_FdrDate", SqlDbType.VarChar).Value = Sd_Bg_FdrDate;
                    da.SelectCommand.Parameters.Add("@Sd_CD_Challan_No", SqlDbType.VarChar).Value = Sd_CD_Challan_No;
                    da.SelectCommand.Parameters.Add("@Sd_CD_challan_date", SqlDbType.VarChar).Value = Sd_CD_challan_date;
                    da.SelectCommand.Parameters.Add("@Sd_Amount", SqlDbType.Decimal).Value = Sd_Amount;
                    da.SelectCommand.Parameters.Add("@Sd_Bank", SqlDbType.VarChar).Value = Sd_Bank;
                    da.SelectCommand.Parameters.Add("@Validity_FromDate", SqlDbType.VarChar).Value = Validity_FromDate;
                    da.SelectCommand.Parameters.Add("@Validity_ToDate", SqlDbType.VarChar).Value = Validity_ToDate;
                    da.SelectCommand.Parameters.Add("@Status_ID", SqlDbType.Int).Value = Status_ID;
                    da.SelectCommand.Parameters.Add("@SystemIP", SqlDbType.VarChar).Value = SystemIP;
                    da.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;
                    da.SelectCommand.Parameters.Add("@Sd_BranchName", SqlDbType.VarChar).Value = Sd_BranchName;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = Type_Man_Cd;
                    da.SelectCommand.Parameters.Add("@Application_No", SqlDbType.Int).Value = Application_No;
                    da.SelectCommand.Parameters.Add("@Ex_Dist", SqlDbType.VarChar).Value = Ex_Dist;
                    da.SelectCommand.Parameters.Add("@SHOUsername", SqlDbType.VarChar).Value = SHOUsername;
                    da.SelectCommand.Parameters.Add("@IsBG_CD", SqlDbType.Int).Value = IsBG_CD;
                    SqlParameter Documents = new SqlParameter("@RenewalDocumentDetailsType", FileUpload);
                    Documents.SqlDbType = SqlDbType.Structured;
                    da.SelectCommand.Parameters.Add(Documents);
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable BARRenewalApplications_Insert(string Retailer_Code, string Sd_Bg_FdrNo, string Sd_Bg_FdrDate, string Sd_CD_Challan_No, string Sd_CD_challan_date, decimal Sd_Amount, string @Sd_Bank, string @Validity_FromDate
            , string Validity_ToDate, int Status_ID, string SystemIP, string CreatedBy, string Sd_BranchName, int Type_Man_Cd, int Application_No, string Ex_Dist, string SHOUsername, int IsBG_CD, DataTable FileUpload, string ConnKey)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("R_BARRenewalApplications_Insert", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Retailer_Code", SqlDbType.VarChar).Value = Retailer_Code;
                    da.SelectCommand.Parameters.Add("@Sd_Bg_FdrNo", SqlDbType.VarChar).Value = Sd_Bg_FdrNo;
                    da.SelectCommand.Parameters.Add("@Sd_Bg_FdrDate", SqlDbType.VarChar).Value = Sd_Bg_FdrDate;
                    da.SelectCommand.Parameters.Add("@Sd_CD_Challan_No", SqlDbType.VarChar).Value = Sd_CD_Challan_No;
                    da.SelectCommand.Parameters.Add("@Sd_CD_challan_date", SqlDbType.VarChar).Value = Sd_CD_challan_date;
                    da.SelectCommand.Parameters.Add("@Sd_Amount", SqlDbType.Decimal).Value = Sd_Amount;
                    da.SelectCommand.Parameters.Add("@Sd_Bank", SqlDbType.VarChar).Value = Sd_Bank;
                    da.SelectCommand.Parameters.Add("@Validity_FromDate", SqlDbType.VarChar).Value = Validity_FromDate;
                    da.SelectCommand.Parameters.Add("@Validity_ToDate", SqlDbType.VarChar).Value = Validity_ToDate;
                    da.SelectCommand.Parameters.Add("@Status_ID", SqlDbType.Int).Value = Status_ID;
                    da.SelectCommand.Parameters.Add("@SystemIP", SqlDbType.VarChar).Value = SystemIP;
                    da.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;
                    da.SelectCommand.Parameters.Add("@Sd_BranchName", SqlDbType.VarChar).Value = Sd_BranchName;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = Type_Man_Cd;
                    da.SelectCommand.Parameters.Add("@Application_No", SqlDbType.Int).Value = Application_No;
                    da.SelectCommand.Parameters.Add("@Ex_Dist", SqlDbType.VarChar).Value = Ex_Dist;
                    da.SelectCommand.Parameters.Add("@SHOUsername", SqlDbType.VarChar).Value = SHOUsername;
                    da.SelectCommand.Parameters.Add("@IsBG_CD", SqlDbType.Int).Value = IsBG_CD;
                    SqlParameter Documents = new SqlParameter("@RenewalDocumentDetailsType", FileUpload);
                    Documents.SqlDbType = SqlDbType.Structured;
                    da.SelectCommand.Parameters.Add(Documents);
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataSet GetDepartmentRenewalAPPDetails(int Role, string UserName, string EXDIST_CODE, string ApplicationType, string UserSection, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("R_GetDepartmentRenewalAPPDetails", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_Role", SqlDbType.Int).Value = Role;
                        da.SelectCommand.Parameters.Add("@P_SHOUsername", SqlDbType.VarChar).Value = UserName;
                        da.SelectCommand.Parameters.Add("@P_ExDist", SqlDbType.VarChar).Value = EXDIST_CODE;
                        da.SelectCommand.Parameters.Add("@P_ApplicationType", SqlDbType.VarChar).Value = ApplicationType;
                        da.SelectCommand.Parameters.Add("@P_UserSection", SqlDbType.VarChar).Value = UserSection;
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

        public DataSet GetFWDRenewalAPPCountDetails(int Role, string UserName, string EXDIST_CODE, string UserSection, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("R_GetFWDRenewalAPPCountDetails", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_Role", SqlDbType.Int).Value = Role;
                        da.SelectCommand.Parameters.Add("@P_SHOUsername", SqlDbType.VarChar).Value = UserName;
                        da.SelectCommand.Parameters.Add("@P_ExDist", SqlDbType.VarChar).Value = EXDIST_CODE;

                        da.SelectCommand.Parameters.Add("@P_UserSection", SqlDbType.VarChar).Value = UserSection;
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
        public DataSet GetFWDRenewalAPPDetails(int Role, string UserName, string EXDIST_CODE, string ApplicationType, string UserSection, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("R_GetFWDRenewalAPPDetails", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_Role", SqlDbType.Int).Value = Role;
                        da.SelectCommand.Parameters.Add("@P_SHOUsername", SqlDbType.VarChar).Value = UserName;
                        da.SelectCommand.Parameters.Add("@P_ExDist", SqlDbType.VarChar).Value = EXDIST_CODE;
                        da.SelectCommand.Parameters.Add("@P_ApplicationType", SqlDbType.VarChar).Value = ApplicationType;
                        da.SelectCommand.Parameters.Add("@P_UserSection", SqlDbType.VarChar).Value = UserSection;
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


        public DataSet GetDepartmentRenewalApplications(int Role, string UserName, string EXDIST_CODE, string UserSection, string ConnKey)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("R_GetDepartmentRenewalApplications", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_Role", SqlDbType.Int).Value = Role;
                        da.SelectCommand.Parameters.Add("@P_SHOUsername", SqlDbType.VarChar).Value = UserName;
                        da.SelectCommand.Parameters.Add("@P_ExDist", SqlDbType.VarChar).Value = EXDIST_CODE;
                        da.SelectCommand.Parameters.Add("@P_UserSection", SqlDbType.VarChar).Value = UserSection;
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
        public DataSet GetViewRetailerRenewalDetails(string Retailer_Code, string ApplicationNo, int Type_Man_Cd, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("R_GetViewRetailerRenewalDetails", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_Retailer_Code", SqlDbType.VarChar).Value = Retailer_Code;
                        da.SelectCommand.Parameters.Add("@P_ApplicatinNo", SqlDbType.VarChar).Value = ApplicationNo;
                        da.SelectCommand.Parameters.Add("@P_Type_Man_Cd", SqlDbType.VarChar).Value = Type_Man_Cd;
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
        public DataSet GetViewSupplierRenewalDetails(string Retailer_Code, string ApplicationNo, int Type_Man_Cd, string ConnKey)//method name
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("R_GetViewSupplierRenewalDetails", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_Retailer_Code", SqlDbType.VarChar).Value = Retailer_Code;
                        da.SelectCommand.Parameters.Add("@P_ApplicatinNo", SqlDbType.VarChar).Value = ApplicationNo;
                        da.SelectCommand.Parameters.Add("@P_Type_Man_Cd", SqlDbType.VarChar).Value = Type_Man_Cd;
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
        public bool RenewalAction_Flow(string ApplicationNo, int Type_Man_Cd, int Application_SL_No, string TypeofUser, int Current_Level, string CreatedBy, int DirectionFlag, string Remarks, byte[] documenttype, string ConnKey)
        {
            bool dt = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("R_RenewalAction_Flow", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@ApplicationNo", SqlDbType.VarChar).Value = ApplicationNo;
                        da.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = Type_Man_Cd;
                        da.Parameters.Add("@Application_SL_No", SqlDbType.Int).Value = Application_SL_No;
                        da.Parameters.Add("@TypeofUser", SqlDbType.VarChar).Value = TypeofUser;
                        da.Parameters.Add("@Current_Level", SqlDbType.Int).Value = Current_Level;
                        da.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;
                        da.Parameters.Add("@DirectionFlag", SqlDbType.Int).Value = DirectionFlag;
                        da.Parameters.Add("@FRemarks", SqlDbType.VarChar).Value = Remarks;
                        da.Parameters.Add("@Document", SqlDbType.Binary).Value = documenttype;
                        con.Open();
                        da.ExecuteNonQuery();
                        dt = true;
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RenewalAction_Revert_Flow(string ApplicationNo, int Type_Man_Cd, int Application_SL_No, string TypeofUser, int Current_Level, string CreatedBy, int DirectionFlag, string Remarks, byte[] documenttype, int NextLevel, string ConnKey)
        {
            bool dt = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("R_RenewalAction_Flow_N", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@ApplicationNo", SqlDbType.VarChar).Value = ApplicationNo;
                        da.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = Type_Man_Cd;
                        da.Parameters.Add("@Application_SL_No", SqlDbType.Int).Value = Application_SL_No;
                        da.Parameters.Add("@TypeofUser", SqlDbType.VarChar).Value = TypeofUser;
                        da.Parameters.Add("@Current_Level", SqlDbType.Int).Value = Current_Level;
                        da.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;
                        da.Parameters.Add("@DirectionFlag", SqlDbType.Int).Value = DirectionFlag;
                        da.Parameters.Add("@FRemarks", SqlDbType.VarChar).Value = Remarks;
                        da.Parameters.Add("@Document", SqlDbType.Binary).Value = documenttype;
                        da.Parameters.Add("@NextLevel", SqlDbType.Int).Value = NextLevel;
                        con.Open();
                        da.ExecuteNonQuery();
                        dt = true;
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public DataTable GetDocumentDetails(string TypeofUser, int Type_Man_Cd, int Application_SL_No, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("R_GetRenewalDocumentList", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@TypeofUser", SqlDbType.VarChar).Value = TypeofUser;
                    da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = Type_Man_Cd;
                    da.SelectCommand.Parameters.Add("@Application_SL_No", SqlDbType.Int).Value = Application_SL_No;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public bool Proceedings_Insert(string ProceedingNo, decimal PlintArea, string LicenceDate, string PremisesBearingNO, string UserID, string ApplicationNo, int Type_Man_Cd, string TypeofUser, string CreatedBy, string ConnKey)
        {
            bool dt = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("R_Proceedings_Insert", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@ProceedingNo", SqlDbType.VarChar).Value = ProceedingNo;
                        da.Parameters.Add("@PlintArea", SqlDbType.Decimal).Value = PlintArea;
                        da.Parameters.Add("@LicenceDate", SqlDbType.VarChar).Value = LicenceDate;
                        da.Parameters.Add("@PremisesBearingNO", SqlDbType.VarChar).Value = PremisesBearingNO;
                        da.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
                        da.Parameters.Add("@ApplicationNo", SqlDbType.VarChar).Value = ApplicationNo;
                        da.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = Type_Man_Cd;
                        da.Parameters.Add("@TypeofUser", SqlDbType.VarChar).Value = TypeofUser;
                        da.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;
                        con.Open();
                        da.ExecuteNonQuery();
                        dt = true;
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataSet GetProceedings(string UserID, string ApplicationNo, int Type_Man_Cd, string TypeofUser, string ConnKey)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("R_GetProceedings", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
                        da.SelectCommand.Parameters.Add("@ApplicationNo", SqlDbType.VarChar).Value = ApplicationNo;
                        da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = Type_Man_Cd;
                        da.SelectCommand.Parameters.Add("@TypeofUser", SqlDbType.VarChar).Value = TypeofUser;
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

        public bool MBEndrosement_Insert
                    (string CrNo, string Premises, string North, string South, string East, string West, string Fromyear, string Toyear, string Remitted, string UserID, string ApplicationNo, int Type_Man_Cd,
                    string TypeofUser, string CreatedBy, string ConnKey)
        {
            bool dt = false;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand da = new SqlCommand("R_MBRenewalEndrosement_Insert", con))
                    {
                        da.CommandType = CommandType.StoredProcedure;
                        da.Parameters.Add("@CrNo", SqlDbType.VarChar).Value = CrNo;
                        da.Parameters.Add("@premises", SqlDbType.VarChar).Value = Premises;
                        da.Parameters.Add("@North", SqlDbType.VarChar).Value = North;
                        da.Parameters.Add("@South", SqlDbType.VarChar).Value = South;
                        da.Parameters.Add("@East", SqlDbType.VarChar).Value = East;
                        da.Parameters.Add("@West", SqlDbType.VarChar).Value = West;
                        da.Parameters.Add("@Fromyear", SqlDbType.VarChar).Value = Fromyear;
                        da.Parameters.Add("@Toyear", SqlDbType.VarChar).Value = Toyear;
                        da.Parameters.Add("@Remitted", SqlDbType.VarChar).Value = Remitted;
                        da.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
                        da.Parameters.Add("@ApplicationNo", SqlDbType.VarChar).Value = ApplicationNo;
                        da.Parameters.Add("@Type_Man_Cd", SqlDbType.VarChar).Value = Type_Man_Cd;
                        da.Parameters.Add("@TypeofUser", SqlDbType.VarChar).Value = TypeofUser;
                        da.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy;

                        con.Open();
                        da.ExecuteNonQuery();
                        dt = true;
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataSet GetMBEndrosement(string UserID, string ApplicationNo, int Type_Man_Cd, string TypeofUser, string ConnKey)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("R_GetMBEndrosement", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
                        da.SelectCommand.Parameters.Add("@ApplicationNo", SqlDbType.VarChar).Value = ApplicationNo;
                        da.SelectCommand.Parameters.Add("@Type_Man_Cd", SqlDbType.Int).Value = Type_Man_Cd;
                        da.SelectCommand.Parameters.Add("@TypeofUser", SqlDbType.VarChar).Value = TypeofUser;
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

        #endregion "END RENEWALS"

        #region "Upload Signatue"

        public DataTable Signature_Upload(Supplier_BE objBE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Specimen_Signature_Insert", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = objBE.UserName;
                    da.SelectCommand.Parameters.Add("@DocumentFile", SqlDbType.VarBinary).Value = objBE.UploadFile;
                    da.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = objBE.UserName;


                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        #endregion "Upload Signature"

        #region " Commisioner Login"
        public DataTable GetEvents_WiseReport(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetEventPermitCommisionerLogin", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_FormDate", SqlDbType.DateTime).Value = obj.FromDate;
                    da.SelectCommand.Parameters.Add("@P_ToDate", SqlDbType.DateTime).Value = obj.ToDate;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        #endregion " Commisioner Login"
        #region "TSBCL Commisioner Login"
        public DataTable GetTSBCL_WiseReport(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetTSBCLSalesProceeds", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_FormDate", SqlDbType.DateTime).Value = obj.FromDate;
                    da.SelectCommand.Parameters.Add("@P_ToDate", SqlDbType.DateTime).Value = obj.ToDate;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        #endregion "TSBCL Commisioner Login"
        //Added new methods and procedures by Rambabu
        //Supplier
        public DataTable getPrimaryDistilleryCount(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_getPrimaryDistilleryCount", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable getDistilleryCount(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_getDistilleryCount", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable getBreweryCount(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_getBreweryCount", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable getWineryCount(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_getWineryCount", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable getMicroBreweryCount(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_getMicroBreweryCount", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable SupplierdataList(string ConnKey,string MFtype)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_getSupplierdataListBasedonId", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ManufactureType", SqlDbType.Text).Value = MFtype;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }













        public DataTable getEvent_app_pay(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_GetCount_event_app_pay", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable get_event_app_reg(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_event_app_reg", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable get_event_app_reg_list(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_event_app_reg_list", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable get_DPEO_Event_pay_list(string ConnKey, int skip, int pageSize)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_get_DPEO_Event_pay", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Skip", SqlDbType.Int).Value = skip;
                    da.SelectCommand.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable getMonthWisePayment(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_getMonthWisePayment", con))
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