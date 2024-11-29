using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ExciseAPI.Controller
{
    [RoutePrefix("api/Payment")]
    public class PaymentController : ApiController
    {
        SupplierDAL objDL = new SupplierDAL();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        [Route("Details")]
        [HttpGet]
        public IHttpActionResult getPaymentDetails()
        {
            PaymentResponse resp = new PaymentResponse();
            try
            {
               
                //SqlParameter[] Params =
                //    {
                //            //new SqlParameter("@P_LesseeNo ",dashboard.LesseeNo),
                //            //new SqlParameter("@P_RoleID",dashboard.RoleID)
                //            //new SqlParameter("@P_OfficeID",Param.OfficeID)
                //        };
                DataSet ds = objDL.GetPaymentDetails(ConnKey);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    resp.Details = (from DataRow dr in dt.Rows
                                      select new RowPaymentDetails
                                      {
                                          bclid = dr["bclid"].ToString(),
                                          banktrans_id = dr["banktrans_id"].ToString(),
                                          challan_num = dr["challan_num"].ToString(),
                                          bank_name = dr["bank_name"].ToString(),
                                          trans_date = dr["trans_date"].ToString(),
                                          bank_status = dr["bank_status"].ToString(),
                                          amount = dr["amount"].ToString(),
                                          hoa = dr["hoa"].ToString(),
                                          timestamp = dr["timestamp"].ToString()
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
public class Responses
{
    public class responseMessage
    {
        public bool IsSuccess { get; set; }
        public string ReturnMessage { get; set; }
        public int SuccessCode { get; set; }
        public string Message { get; set; }
    }
    public enum StatusCodes
    {
        Success = 200,
        Create = 201,
        Accept = 202,
        Badrequest = 400,
        Unauthorized = 401,
        NotFound = 404,
        InternalServerError = 500,
        InvalidDetails = 100
    }

    //retrun OK --200
    //retrun Create --201
    //retrun Accept --202,
    //retrun badrequst -400
    //return NotFound --404
    //LocalRedirect -301
    //LocalRedirectPermanent --302
    //internal server error --500
}

public class PaymentResponse:Responses.responseMessage
{
    public List<RowPaymentDetails> Details { get; set; }
}

public class RowPaymentDetails
{
    public string bclid { get; set; }
    public string banktrans_id { get; set; }
    public string challan_num { get; set; }
    public string bank_name { get; set; }
    public string trans_date { get; set; }
    public string bank_status { get; set; }
    public string amount { get; set; }
    public string hoa { get; set; }
    public string timestamp { get; set; }

}