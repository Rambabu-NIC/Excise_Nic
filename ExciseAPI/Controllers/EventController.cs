using Excise_DAL;
using Excise_BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ExciseAPI.Models.EventModel;

namespace ExciseAPI.Controller
{
    [RoutePrefix("api/Event")]
    public class EventController : ApiController
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        [Route("Details")]
        [HttpPost]
        public IHttpActionResult getEventDetails(SHORequest req)
        {
            EventResponse resp = new EventResponse();
            try
            {
                
                DataSet ds = objDL.GetEventDetailsByAppRegNo(req.AppRegNo, ConnKey);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    resp.Details = (from DataRow dr in dt.Rows
                                    select new RowEventDetails
                                    {
                                        Applicant_Name = dr["App_Name"].ToString(),
                                        Applicant = "",
                                        Aadhaar = dr["Aadhaar"].ToString(),
                                        MobileNo = dr["Mob_No"].ToString(),
                                        Email = dr["Email"].ToString(),
                                        Age = Convert.ToInt32(dr["Age"].ToString()),
                                        Father_Name = dr["FName"].ToString(),
                                        Residential_Address = dr["Res_Address"].ToString(),
                                        House_Number = dr["HNo"].ToString(),
                                        Street = dr["Street"].ToString(),
                                        Name_Premises = dr["Name_Premises"].ToString(),
                                        East = dr["Bdr_East"].ToString(),
                                        West = dr["Bdr_West"].ToString(),
                                        North = dr["Bdr_North"].ToString(),
                                        South = dr["Bdr_South"].ToString(),
                                        Revenue_District = dr["DistName"].ToString(),
                                        Mandal = dr["Mandal"].ToString(),
                                        Village = dr["Village"].ToString(),
                                        Excise_District = dr["ExDist"].ToString(),
                                        Excise_Station = dr["ExStation"].ToString(),
                                        GHMC = dr["GHMC"].ToString(),
                                        Date_TimeofEvent = dr["Eventtime"].ToString(),
                                        Occassion = dr["Event_Occasion"].ToString(),
                                        TypeOf_Event = dr["Event_Type"].ToString(),
                                        Licence_Fee = dr["License_Fee"].ToString(),
                                        Differential_Fee = dr["Diffential_Amt"].ToString(),
                                        Premises_Address = dr["EVENTDESC"].ToString(),
                                        
                                        
                        PaymentDetails = (from DataRow dr1 in ds.Tables[1].Rows
                    select new RowEventPaymentDetails
                    {
                                             Depttrans_id = dr1["DeptTransid"].ToString(),
                                            banktrans_id = dr1["BankTransid"].ToString(),
                                            challan_num = dr1["ChallanNumber"].ToString(),
                                            bank_name = dr1["BankCode"].ToString(),
                                            trans_date = dr1["TreasuryDate"].ToString(),
                                            bank_status = dr1["BankStatus"].ToString(),
                                            amount = dr1["Amount"].ToString(),
                                            //hoa = dr1["hoa"].ToString(),
                                            BankDate = dr1["BankDate"].ToString()
                                        }).ToList(),




                                        DocumentDetails = (from DataRow dr2 in ds.Tables[2].Rows
                                                          select new RowEventDocumentsDetails
                                                          {
                                                              UploadDco_File = dr2["UploadDco_File"].ToString(),
                                                              UploadDco_FileType = dr2["UploadDco_FileType"].ToString(),
                                                              UploadDocs_Sno = dr2["UploadDocs_Sno"].ToString(),
                                                             
                                                          }).ToList()

                                    }).ToList();
                    resp.IsSuccess = true;
                    resp.ReturnMessage = Responses.StatusCodes.Success.ToString();
                    resp.SuccessCode = (int)Responses.StatusCodes.Success;
                }
                else
                {
                    resp.IsSuccess = false;
                    resp.ReturnMessage = "Not Found";
                    resp.SuccessCode = (int)Responses.StatusCodes.NotFound;
                }

                return Json(resp);

            }
            catch (Exception ex)
            {
                resp.IsSuccess = true;
                resp.ReturnMessage = "Bad Request";
                resp.SuccessCode = (int)Responses.StatusCodes.Badrequest;
                return Json(resp);
            }

        }


        [Route("EventPermission")]
        [HttpPost]
        public IHttpActionResult EventPermissionDetails(SHOEventPermissionRequest req)
        {
            EventPermissionResponse resp = new EventPermissionResponse();
            try
            {
                objBE.Action = "SHO";
                objBE.ExDistCode = req.EXDIST_CODE;
                objBE.ExStation = req.SHOID;
                //DataSet ds = objDL.EventReg_IUR(objBE, ConnKey);
                DataTable dt = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    resp.Details = (from DataRow dr in dt.Rows
                                    select new RowEventPermissionDetails
                                    {
                                        AppReg_NO = dr["AppReg_NO"].ToString(),
                                        Reg_No = dr["Reg_No"].ToString(),
                                        App_Name = dr["App_Name"].ToString(),
                                        
                                        Aadhaar = dr["Aadhaar"].ToString(),
                                        MobileNo = dr["Mob_No"].ToString(),
                                        Email = dr["Email"].ToString(),
                                        Age = Convert.ToInt32(dr["Age"].ToString()),
                                        FName = dr["FName"].ToString(),
                                        Res_Address = dr["Res_Address"].ToString(),
                                        HNo = dr["HNo"].ToString(),
                                        Name_Premises = dr["Name_Premises"].ToString(),
                                        Street = dr["Street"].ToString(),

                                        Bdr_East = dr["Bdr_East"].ToString(),
                                        Bdr_West = dr["Bdr_West"].ToString(),
                                        Bdr_North = dr["Bdr_North"].ToString(),
                                        Bdr_South = dr["Bdr_South"].ToString(),
                                        State = dr["State"].ToString(),
                                        DistCode = dr["DistCode"].ToString(),
                                        DistName = dr["DistName"].ToString(),
                                        
                                        Mandal = dr["Mandal"].ToString(),
                                        MandName = dr["MandName"].ToString(),
                                        Division = dr["Division"].ToString(),
                                        Circle = dr["Circle"].ToString(),
                                        Village = dr["Village"].ToString(),
                                        VillName = dr["VillName"].ToString(),
                                        Pincode = dr["Pincode"].ToString(),

                                        ExDist_Cd = dr["ExDist_Cd"].ToString(),
                                        ExStationCode = dr["ExStationCode"].ToString(),
                                        ExDist = dr["ExDist"].ToString(),
                                        ExStation = dr["ExStation"].ToString(),
                                        Rule7 = dr["Rule7"].ToString(),
                                        Date = dr["Date"].ToString(),
                                        Eventtime = dr["Eventtime"].ToString(),
                                        Event_Occasion = dr["Event_Occasion"].ToString(),
                                        License_Fee = dr["License_Fee"].ToString(),
                                        Event_ID = dr["Event_ID"].ToString()
                                       


                                        

                                    }).ToList();
                    resp.IsSuccess = true;
                    resp.ReturnMessage = Responses.StatusCodes.Success.ToString();
                    resp.SuccessCode = (int)Responses.StatusCodes.Success;
                }
                else
                {
                    resp.IsSuccess = false;
                    resp.ReturnMessage = "Not Found";
                    resp.SuccessCode = (int)Responses.StatusCodes.NotFound;
                }

                return Json(resp);

            }
            catch (Exception ex)
            {
                resp.IsSuccess = true;
                resp.ReturnMessage = "Bad Request";
                resp.SuccessCode = (int)Responses.StatusCodes.Badrequest;
                return Json(resp);
            }

        }


        [Route("DPEOEventPermission")]
        [HttpPost]
        public IHttpActionResult DPEOEventPermissionDetails(DPEOEventPermissionRequest req)
        {
            DPEOEventPermissionResponse resp = new DPEOEventPermissionResponse();
            try
            {
                objBE.Action = "SUPDE";
                objBE.ExDistCode = req.ExDist_Cd;
                //DataSet ds = objDL.GetEventDetailsByAppRegNo(req.AppRegNo, ConnKey);

                DataTable dt = objDL.EventReg_IUR(objBE, ConnKey);

                if (dt.Rows.Count > 0)
                {
                    resp.Details = (from DataRow dr in dt.Rows
                                    select new RowDPEOEventDetails
                                    {
                                        AppReg_NO = dr["AppReg_NO"].ToString(),
                                        Reg_No = dr["Reg_No"].ToString(),
                                        App_Name = dr["App_Name"].ToString(),

                                        Aadhaar = dr["Aadhaar"].ToString(),
                                        Mob_No = dr["Mob_No"].ToString(),
                                        Email = dr["Email"].ToString(),
                                        Age = Convert.ToInt32(dr["Age"].ToString()),
                                        FName = dr["FName"].ToString(),
                                        Res_Address = dr["Res_Address"].ToString(),
                                        HNo = dr["HNo"].ToString(),
                                        Name_Premises = dr["Name_Premises"].ToString(),
                                        Street = dr["Street"].ToString(),

                                        Bdr_East = dr["Bdr_East"].ToString(),
                                        Bdr_West = dr["Bdr_West"].ToString(),
                                        Bdr_North = dr["Bdr_North"].ToString(),
                                        Bdr_South = dr["Bdr_South"].ToString(),
                                        State = dr["State"].ToString(),
                                        DistCode = dr["DistCode"].ToString(),
                                        DistName = dr["DistName"].ToString(),

                                        Mandal = dr["Mandal"].ToString(),
                                        MandName = dr["MandName"].ToString(),
                                        Division = dr["Division"].ToString(),
                                        Circle = dr["Circle"].ToString(),
                                        Village = dr["Village"].ToString(),
                                        VillName = dr["VillName"].ToString(),
                                        Pincode = dr["Pincode"].ToString(),

                                        ExDist_Cd = dr["ExDist_Cd"].ToString(),
                                        ExStationCode = dr["ExStationCode"].ToString(),
                                        ExDist = dr["ExDist"].ToString(),
                                        ExStation = dr["ExStation"].ToString(),
                                        Rule7 = dr["Rule7"].ToString(),
                                        Date = dr["Date"].ToString(),
                                        Eventtime = dr["Eventtime"].ToString(),
                                        Event_Occasion = dr["Event_Occasion"].ToString(),
                                        License_Fee = dr["License_Fee"].ToString(),
                                        Event_ID = dr["Event_ID"].ToString(),
                                        ShoInspecDt= dr["ShoInspecDt"].ToString(),
                                        ShoInspecTime = dr["ShoInspecTime"].ToString(),
                                        ShoRemarks = dr["ShoRemarks"].ToString()


                                        //DPEOPaymentDetails = (from DataRow dr1 in dt.Rows[""]
                                        //             select new RowDPEOEventPaymentDetails
                                        //             {
                                        //                 Depttrans_id = dr1["DeptTransid"].ToString(),
                                        //                 banktrans_id = dr1["BankTransid"].ToString(),
                                        //                 challan_num = dr1["ChallanNumber"].ToString(),
                                        //                 bank_name = dr1["BankCode"].ToString(),
                                        //                 trans_date = dr1["TreasuryDate"].ToString(),
                                        //                 bank_status = dr1["BankStatus"].ToString(),
                                        //                 amount = dr1["Amount"].ToString(),
                                        //                 //hoa = dr1["hoa"].ToString(),
                                        //                 BankDate = dr1["BankDate"].ToString()
                                        //             }).ToList(),


                                    }).ToList();
                    resp.IsSuccess = true;
                    resp.ReturnMessage = Responses.StatusCodes.Success.ToString();
                    resp.SuccessCode = (int)Responses.StatusCodes.Success;
                }
                else
                {
                    resp.IsSuccess = false;
                    resp.ReturnMessage = "Not Found";
                    resp.SuccessCode = (int)Responses.StatusCodes.NotFound;
                }

                return Json(resp);

            }
            catch (Exception ex)
            {
                resp.IsSuccess = true;
                resp.ReturnMessage = "Bad Request";
                resp.SuccessCode = (int)Responses.StatusCodes.Badrequest;
                return Json(resp);
            }

        }


        [Route("DPEODetails")]
        [HttpPost]
        public IHttpActionResult getDPEOEventDetails(DPEORequest req)
        {
            DPEOEventResponse resp = new DPEOEventResponse();
            try
            {

                DataSet ds = objDL.GetDPEOEventDetailsByAppRegNo(req.AppRegNo, ConnKey);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    resp.Details = (from DataRow dr in dt.Rows
                                    select new RowDPEOEventDetails
                                    {
                                        AppReg_NO = dr["AppReg_NO"].ToString(),
                                        Reg_No = dr["Reg_No"].ToString(),
                                        App_Name = dr["App_Name"].ToString(),

                                        Aadhaar = dr["Aadhaar"].ToString(),
                                        Mob_No = dr["Mob_No"].ToString(),
                                        Email = dr["Email"].ToString(),
                                        Age = Convert.ToInt32(dr["Age"].ToString()),
                                        FName = dr["FName"].ToString(),
                                        Res_Address = dr["Res_Address"].ToString(),
                                        HNo = dr["HNo"].ToString(),
                                        Name_Premises = dr["Name_Premises"].ToString(),
                                        Street = dr["Street"].ToString(),

                                        Bdr_East = dr["Bdr_East"].ToString(),
                                        Bdr_West = dr["Bdr_West"].ToString(),
                                        Bdr_North = dr["Bdr_North"].ToString(),
                                        Bdr_South = dr["Bdr_South"].ToString(),
                                        State = dr["State"].ToString(),
                                        DistCode = dr["DistCode"].ToString(),
                                        DistName = dr["DistName"].ToString(),

                                        Mandal = dr["Mandal"].ToString(),
                                        MandName = dr["MandName"].ToString(),
                                        Division = dr["Division"].ToString(),
                                        Circle = dr["Circle"].ToString(),
                                        Village = dr["Village"].ToString(),
                                        VillName = dr["VillName"].ToString(),
                                        Pincode = dr["Pincode"].ToString(),

                                        ExDist_Cd = dr["ExDist_Cd"].ToString(),
                                        ExStationCode = dr["ExStationCode"].ToString(),
                                        ExDist = dr["ExDist"].ToString(),
                                        ExStation = dr["ExStation"].ToString(),
                                        Rule7 = dr["Rule7"].ToString(),
                                        Date = dr["Date"].ToString(),
                                        Eventtime = dr["Eventtime"].ToString(),
                                        Event_Occasion = dr["Event_Occasion"].ToString(),
                                        License_Fee = dr["License_Fee"].ToString(),
                                        Event_ID = dr["Event_ID"].ToString(),


                                        DPEOPaymentDetails = (from DataRow dr1 in ds.Tables[1].Rows
                                                              select new RowDPEOEventPaymentDetails
                                                              {
                                                                  DeptTransid = dr1["DeptTransid"].ToString(),
                                                                  BankTransid = dr1["BankTransid"].ToString(),
                                                                  ChallanNumber = dr1["ChallanNumber"].ToString(),
                                                                  BankCode = dr1["BankCode"].ToString(),
                                                                  TreasuryDate = dr1["TreasuryDate"].ToString(),
                                                                  BankStatus = dr1["BankStatus"].ToString(),
                                                                  Amount = dr1["Amount"].ToString(),
                                                                  //hoa = dr1["hoa"].ToString(),
                                                                  BankDate = dr1["BankDate"].ToString()
                                                              }).ToList(),




                                        DocumentDetails = (from DataRow dr2 in ds.Tables[2].Rows
                                                           select new RowEventDocumentsDetails
                                                           {
                                                               UploadDco_File = dr2["UploadDco_File"].ToString(),
                                                               UploadDco_FileType = dr2["UploadDco_FileType"].ToString(),
                                                               UploadDocs_Sno = dr2["UploadDocs_Sno"].ToString(),

                                                           }).ToList()

                                    }).ToList();
                    resp.IsSuccess = true;
                    resp.ReturnMessage = Responses.StatusCodes.Success.ToString();
                    resp.SuccessCode = (int)Responses.StatusCodes.Success;
                }
                else
                {
                    resp.IsSuccess = false;
                    resp.ReturnMessage = "Not Found";
                    resp.SuccessCode = (int)Responses.StatusCodes.NotFound;
                }

                return Json(resp);

            }
            catch (Exception ex)
            {
                resp.IsSuccess = true;
                resp.ReturnMessage = "Bad Request";
                resp.SuccessCode = (int)Responses.StatusCodes.Badrequest;
                return Json(resp);
            }

        }

    }
}
