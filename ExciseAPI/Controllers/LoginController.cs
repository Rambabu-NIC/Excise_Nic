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
using static ExciseAPI.Models.LoginModel;

namespace ExciseAPI.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        [Route("Details")]
        [HttpPost]
        public IHttpActionResult getLoginDetails(LoginRequest req)
        {
            LoginResponse resp = new LoginResponse();
            try
            {
                Login_DL objLogin = new Login_DL();
               DataTable dtLogin = objLogin.getLoginDetails(req.UserName, objBE, ConnKey);

                if (dtLogin.Rows.Count > 0)
                {
                    if (dtLogin.Rows[0]["Password"].ToString() == req.Password)
                    {
                        resp.Details = (from DataRow dr in dtLogin.Rows
                                        select new RowLoginDetails
                                        {
                                            UserId = dr["UserId"].ToString(),
                                            UserName = dr["UserName"].ToString(),
                                            Role = dr["Role"].ToString(),
                                            Password = dr["Password"].ToString(),
                                            StateCode = dr["StateCode"].ToString(),
                                            DistCode = dr["DistCode"].ToString(),
                                            MandCode = dr["MandCode"].ToString(),
                                            Active = dr["Active"].ToString(),
                                            Supplier_Name = dr["Supplier_Name"].ToString(),
                                            Mobile = dr["Mobile"].ToString(),
                                            DDOCode = dr["DDOCode"].ToString(),
                                            License_No = dr["License_No"].ToString(),
                                            Type_of_Manufacturing = dr["Type_of_Manufacturing"].ToString(),
                                            ExDistCode = dr["EXDIST_CODE"].ToString(),  
                                            SHOID = dr["SHOID"].ToString(),
                                            ExDist_Cd = dr["ExDist_Cd"].ToString(),
                                            Retailer_Name = dr["Retailer_Name"].ToString(),
                                            Excise_tax = dr["Excise_tax"].ToString(),
                                            DepotCode = dr["DepotCode"].ToString(),
                                            Type_Retailer = dr["Type_Retailer"].ToString(),
                                            Retailer_Type_Short_Name = dr["Retailer_Type_Short_Name"].ToString(),
                                            Role_Name = dr["Role_Name"].ToString(),
                                            SHO_ST_NAME = dr["SHO_ST_NAME"].ToString(),
                                            DPEO_DistName = dr["DPEO_DistName"].ToString()

                                        }).ToList();
                        resp.IsSuccess = true;
                        resp.ReturnMessage = Responses.StatusCodes.Success.ToString();
                        resp.SuccessCode = (int)Responses.StatusCodes.Success;
                    }
                    else
                    {
                        resp.IsSuccess = false;
                        resp.ReturnMessage = "Please Enter Correct Password";
                        resp.SuccessCode = (int)Responses.StatusCodes.NotFound;
                    }
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
