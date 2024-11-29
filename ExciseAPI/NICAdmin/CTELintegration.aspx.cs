using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using ExciseAPI.App_Start;
using System.Reflection;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace ExciseAPI.NICAdmin
{
    public partial class CTELintegration : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        protected void Page_Load(object sender, EventArgs e)
        {
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && (Session["Role"].ToString() == "50" || Session["Role"].ToString() == "52") && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Error.aspx");
            }


            if (!IsPostBack)
            {

            }

        }

        protected void BtnGet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtstartDate.Text) && !string.IsNullOrEmpty(txtendDate.Text))
                {
                    string StartDate = Convert.ToDateTime(txtstartDate.Text).ToString("yyyy-MM-dd");
                    string EndDate = Convert.ToDateTime(txtendDate.Text).ToString("yyyy-MM-dd");
                    string Date = DateTime.Now.ToString("yyyy-MM-dd"); //"2024-04-15";
                    string Hash = (Date + "b7T@4D").MD5Hash();

                    DataSet ds = GetctelDetails(StartDate, EndDate, Hash);

                    if (ds.Tables.Count > 0)
                    {
                        bool result = objDL.CTEL_Update(ds.Tables[0], objBE, ConnKey);
                        if (result)
                        {
                            lblRetailererror.Text = "Success";
                            return;
                        }
                        else
                        {
                            lblRetailererror.Text = "Please check the details";
                            return;
                        }
                    }
                    else
                    {
                        //lblRetailererror.Text += "Up to date Already..";
                        return;
                    }

                }


            }
            catch (Exception Ex)
            {
                lblMessage.Text = Ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Maroon;
                return;
            }

        }
        public DataSet GetctelDetails(string StartDate, string EndDate, string Hash)
        {
            DataSet result = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("BCLID", typeof(string));
            dt.Columns.Add("BANKTRANS_ID", typeof(string));
            dt.Columns.Add("CHALLAN_NUM", typeof(string));
            dt.Columns.Add("BANK_NAME", typeof(string));
            dt.Columns.Add("TRANS_DATE", typeof(string));
            dt.Columns.Add("BANK_STATUS", typeof(string));
            dt.Columns.Add("AMOUNT", typeof(string));
            dt.Columns.Add("HOA", typeof(string));
            dt.Columns.Add("VERIFIED_ON", typeof(string));
            DataTable dterror = new DataTable();

            dterror.Columns.Add("ErrorMessage", typeof(string));
            var originalCallback = ServicePointManager.ServerCertificateValidationCallback;
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol =
                    (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);

                //string requestUri = "https://tgbcl.telangana.gov.in/ts/index.php/payVerify/VerifiedChallanDetails?startDate=" + StartDate + "&endDate=" + EndDate + "&checkKey=" + Hash;
                //var request = WebRequest.Create(requestUri);
                //request.ContentType = "application/json";
                //request.Method = "GET";
                //var type = request.GetType();
                //var currentMethod = type.GetProperty("CurrentMethod", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(request);
                //var methodType = currentMethod.GetType();
                //methodType.GetField("ContentBodyNotAllowed", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(currentMethod, false);
                ////using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                                                                          ////    streamWriter.Write("<Json string here>");

                ////}
                //var response1 = (HttpWebResponse)request.GetResponse();
                
                // 26-06-2024
                // Set the custom callback
                ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                ServicePointManager.ServerCertificateValidationCallback += IgnoreCertificateValidation;

                var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                
                HttpClient client = new HttpClient(handler);
                
                var json = JsonConvert.SerializeObject(Hash);
                var data = new StringContent(json, Encoding.UTF8, "application/text");
                //HttpResponseMessage response = client.GetAsync("https://tsbcl.telangana.gov.in/ts/index.php/payVerify/VerifiedChallanDetails?checkKey=" + Hash).Result;
                HttpResponseMessage response = client.GetAsync("https://tgbcl.telangana.gov.in/ts/index.php/payVerify/VerifiedChallanDetails?startDate=" + StartDate + "&endDate=" + EndDate + "&checkKey=" + Hash).Result;
                
                //if (response1.StatusCode == HttpStatusCode.OK)
                //{
                //    using (Stream responseStream = response1.GetResponseStream())
                //    {
                //        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                //        //string sourceCode = reader.ReadToEnd();
                //        //lblRetailererror.Text += reader.ReadToEnd();
                //        //return result;
                //        //    }
                //        //}
                if (response.IsSuccessStatusCode)
                {
                    //string apiResponse = reader.ReadToEnd();
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    // ds = JsonConvert.DeserializeObject<ApiDetails.EncResponse>(apiResponse);
                    lblMessage.Text += apiResponse.ToString();
                    dynamic jsonObject = JsonConvert.DeserializeObject(apiResponse);
                    if (jsonObject != null)
                    {
                        foreach (var innerList in jsonObject.Details)
                        {
                            DataRow dr = dt.NewRow();
                            dr["BCLID"] = innerList["BCLID"];
                            dr["BANKTRANS_ID"] = innerList["BANKTRANS_ID"];
                            dr["CHALLAN_NUM"] = innerList["CHALLAN_NUM"];
                            dr["BANK_NAME"] = innerList["BANK_NAME"];
                            dr["TRANS_DATE"] = innerList["TRANS_DATE"];
                            dr["BANK_STATUS"] = innerList["BANK_STATUS"];
                            dr["AMOUNT"] = innerList["AMOUNT"];
                            dr["HOA"] = innerList["HOA"];
                            dr["VERIFIED_ON"] = innerList["VERIFIED_ON"];
                            if (dr["BANK_STATUS"].ToString().ToUpper().Trim() == "Success".ToUpper())
                            {
                                dt.Rows.Add(dr);
                            }
                        }
                        //DataRow[] FilterData = dt.Select("bankstatus = " + "Success".ToString());
                        //DataTable DataFilter = null;

                        result.Tables.Add(dt);
                        //DataRow[] FilterData = dt.Select("BCLID = 'TGBCL24040203617023707462801'");
                        //FilterData[0]["BANKTRANS_ID"].ToString()
                        //lblMessage.Text = dt.Rows.Count.ToString();
                    }
                    else
                    {
                        //objCommon.ShowAlertMessage("No Data Found");
                        lblRetailererror.Text = "No Data Found..";
                    }
                    //}
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                    result.Tables.Add(dt);
                    DataRow drerror = dterror.NewRow();
                    drerror["ErrorMessage"] = "Unable to fetch data from CTEL server..";
                    dterror.Rows.Add(drerror);
                    result.Tables.Add(dterror);
                    return result;
                }
                return result;
            }
            catch (HttpRequestException ex)
            {
                lblMessage.Text += ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.MediumAquamarine;
                return result;
            }
            catch (Exception ex)
            {
                lblRetailererror.Text += ex.InnerException.InnerException.Message;
                lblRetailererror.ForeColor = System.Drawing.Color.Magenta;
                return result;
            }
            finally
            {
                // Restore the original callback
                ServicePointManager.ServerCertificateValidationCallback = originalCallback;
            }
        }
        private static bool IgnoreCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // Always return true to ignore certificate validation
            return true;
        }
        //public static string SendSMS(string pwdUpdStatus, string loginid, string xml)
        //{
        //    string ValueFristRetVal = "Password Status Wrong";
        //    if ((pwdUpdStatus.ToString().Equals("DONE")))// && (IsMobileNo(txtMobNo)))
        //    {
        //        try
        //        {
        //            xml = "<?xml version=\"1.0\"?><a2wml version =\"2.0\"><request pin=\"" + sms_pwd + "\" username=\"" + sms_userid + "\">" + xml;
        //            xml = xml + "</request></a2wml>";

        //            //var url = "https://smsgw.sms.gov.in/failsafe/HttpData_MM";
        //            var url = "http://smsgw.sms.gov.in/failsafe/HttpData_MM";
        //            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
        //            var data = xml;

        //            httpRequest.Method = "POST";
        //            httpRequest.Accept = "application/json";
        //            httpRequest.ContentType = "text/plain";

        //            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
        //            {
        //                streamWriter.Write(data);
        //            }
        //            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
        //            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //            {
        //                ValueFristRetVal = streamReader.ReadToEnd();
        //            }
        //            return ValueFristRetVal;
        //        }
        //        catch (Exception ex)
        //        {
        //            ValueFristRetVal = "<font color='red'>Error in sending SMS : " + ex.Message + " <br />";
        //            ValueFristRetVal = ValueFristRetVal + " Try Again !</font>";
        //        }
        //    }
        //    return ValueFristRetVal;
        //}
    }
}