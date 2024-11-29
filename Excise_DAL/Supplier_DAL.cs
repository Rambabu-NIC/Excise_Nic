using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Excise_BE;

namespace Excise_DAL
{
    class Supplier_DAL
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
                using (SqlDataAdapter da = new SqlDataAdapter("EventReg_IUR", con))
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
                using (SqlDataAdapter da = new SqlDataAdapter("CommonMasters", con))
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
                using (SqlDataAdapter da = new SqlDataAdapter("InsertPaymentDtls", con))
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
                using (SqlDataAdapter da = new SqlDataAdapter("InsertPaymentDtls", con))
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
                using (SqlDataAdapter da = new SqlDataAdapter("InsertPaymentDtls", con))
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

                    da.SelectCommand.Parameters.Add("@DtFrom", SqlDbType.DateTime).Value = objBE.dtfrom;
                    da.SelectCommand.Parameters.Add("@DtTo", SqlDbType.DateTime).Value = objBE.dtTo;
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
                using (SqlDataAdapter da = new SqlDataAdapter("Insert_UploadDocs", con))
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
                    using (SqlDataAdapter da = new SqlDataAdapter("Retailer_Payments", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@P_DepotCode", SqlDbType.Int).Value = objreg.DepotCode;
                        da.SelectCommand.Parameters.Add("@P_RetailerCode", SqlDbType.VarChar).Value = objreg.Retailer_Code;
                        da.SelectCommand.Parameters.Add("@P_LicenseNO", SqlDbType.VarChar).Value = objreg.LicenseNO;
                        da.SelectCommand.Parameters.Add("@P_Amount", SqlDbType.Decimal).Value = objreg.Amount;
                        da.SelectCommand.Parameters.Add("@P_TransactionID", SqlDbType.VarChar).Value = objreg.DeptTransid;
                        da.SelectCommand.Parameters.Add("@P_RetailerName", SqlDbType.VarChar).Value = objreg.RetailerName;
                        da.SelectCommand.Parameters.Add("@P_DDOCODE", SqlDbType.VarChar).Value = objreg.DDoCode;
                        da.SelectCommand.Parameters.Add("@P_Purpose", SqlDbType.VarChar).Value = objreg.Purpose;
                        da.SelectCommand.Parameters.Add("@P_PtName", SqlDbType.VarChar).Value = objreg.LicenseName;
                        da.SelectCommand.Parameters.Add("@P_CreatedBy", SqlDbType.VarChar).Value = objreg.CreatedBy;
                        //DataTable dt = new DataTable();
                        //da.Fill(dt);
                        //return dt;
                        result = true;
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

        public DataTable GetRetailerPaymentUpdateDtls(Supplier_BE objreg, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RetailerPaymentUpdate", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_TransactionID", SqlDbType.VarChar).Value = objreg.DeptTransid;
                    da.SelectCommand.Parameters.Add("@P_BankTransactionID", SqlDbType.VarChar).Value = objreg.BankTransid;
                    da.SelectCommand.Parameters.Add("@P_Challan", SqlDbType.VarChar).Value = objreg.ChallanNumber;
                    da.SelectCommand.Parameters.Add("@P_BankName", SqlDbType.VarChar).Value = objreg.BankCode;
                    da.SelectCommand.Parameters.Add("@P_TransactionDate", SqlDbType.Date).Value = objreg.TreasuryDate;
                    da.SelectCommand.Parameters.Add("@P_BankStatus", SqlDbType.VarChar).Value = objreg.BankStatus;
                    da.SelectCommand.Parameters.Add("@P_Amount", SqlDbType.VarChar).Value = objreg.Amount;
                    da.SelectCommand.Parameters.Add("@P_HOA", SqlDbType.Decimal).Value = objreg.HOA;
                    da.SelectCommand.Parameters.Add("@P_BankDate", SqlDbType.Date).Value = objreg.BankDate;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
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

        public DataTable GetCPEPaymentLateFee(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetCPELateFeeInstallmetDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@P_Installment", SqlDbType.Int).Value = obj.Installment_No;
                    da.SelectCommand.Parameters.Add("@P_RetailerCode", SqlDbType.VarChar).Value = obj.Retailer_Code;
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


        public DataTable EventMandal(Supplier_BE obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Event_Mandal", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@AppReg_NO", SqlDbType.VarChar).Value = obj.Reg_Code;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        //public DataTable Mandal_Update(Supplier_BE obj, string ConnKey)
        //{
        //    using (SqlConnection con = new SqlConnection(ConnKey))
        //    {
        //        using (SqlDataAdapter da = new SqlDataAdapter("Mandal_Update", con))
        //        {
        //            da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //            da.SelectCommand.Parameters.Add("@AppReg_NO", SqlDbType.VarChar).Value = obj.Reg_Code;
        //            da.SelectCommand.Parameters.Add("@Mandal", SqlDbType.VarChar).Value = obj.MandCode;
        //            //da.SelectCommand.Parameters.Add("@ExDist_Cd", SqlDbType.VarChar).Value = obj.ExDistCode;
        //            da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = obj.DistCode;
        //            da.SelectCommand.Parameters.Add("@VillCode", SqlDbType.VarChar).Value = obj.VillCode;
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            return dt;
        //        }
        //    }
        //}




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
                        da.Parameters.Add("@ExDist_Cd", SqlDbType.VarChar).Value = obj.ExDistCode;
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

    }
}
