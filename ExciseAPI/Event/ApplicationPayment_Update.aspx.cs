using Excise_BE;
using Excise_DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Event
{
    public partial class ApplicationPayment_Update : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                // lblUSer.Text = Session["UsrName"].ToString();
                //BindTypeofManf();           

                random();
                //btn_Save.Visible = false;
                // data.Visible = false;
                getCaptchaImage();
            }
        }

        protected void btnImgRefresh_Click(object sender, ImageClickEventArgs e)
        {
            captch.Text = "";
            getCaptchaImage();
        }

        public void getCaptchaImage()
        {
            Captcha ci = new Captcha();
            string text = Captcha.generateRandomCode();
            ViewState["captchtext"] = text;
            Image2.ImageUrl = "~/Assets/cpImg/cpImage.aspx?randomNo=" + text;
        }
        protected bool CheckCaptcha()
        {
            if (captch.Text == ViewState["captchtext"].ToString())
            {
                return true;
            }
            else
            {
                lblmsg.Text = "Invalid Captcha.";
                captch.Text = "";
                return false;
            }

        }

        protected bool Validate1()
        {
            if (txtRegistrationNo.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter Registration No");
                txtRegistrationNo.Focus();
                return false;
            }
            else if (captch.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter Captcha");
                captch.Focus();
                return false;
            }
            else if (!CheckCaptcha())
            {
                objCommon.ShowAlertMessage("Please Enter Valid Captcha");
                captch.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }


        protected void btn_Get_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate1())
                {
                    Viewdata();
                }

            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }
        }

        public void Clear()
        {
            txtRegistrationNo.Text = "";
        }
        protected DataTable Viewdata()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Reg_Code = txtRegistrationNo.Text;
                objBE.Action = "PGR";
                dt = objDL.EventReg_IUR(objBE, ConnKey);
            }

            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

            return dt;
        }
        public void random()
        {
            try
            {
                string strString = "abcdefghijklmnpqrstuvwxyzABCDQEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                string num = "";
                Random rm = new Random();
                for (int i = 0; i < 16; i++)
                {
                    int randomcharindex = rm.Next(0, strString.Length);
                    char randomchar = strString[randomcharindex];
                    num += Convert.ToString(randomchar);
                }
                hf.Value = num;
                Session["ASPFIXATION2"] = num;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
        public void check()
        {
            try
            {
                string cookie_value = null;
                string session_value = null;

                cookie_value = hf.Value;
                session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
                if (cookie_value != session_value)
                {
                    System.Web.HttpContext.Current.Session.Abandon();
                    HttpContext.Current.Response.Buffer = false;
                    HttpContext.Current.Response.Redirect("~/Error.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx", false);
            }
        }





        //protected void lblDeptTransid_Click(object sender, EventArgs e)
        //{
        //    //string DeptTransId = null;

        //}


        protected void GvDF_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                //if (e.CommandName == "Dept")
                //{
                //    string DeptTransId = e.CommandArgument.ToString();

                //    Depttrans detr = new Depttrans();
                //    detr.deptcode = 2304;
                //    //detr.depttransid = Convert.ToInt64(DeptTransId.Substring(5));
                //    detr.depttransid = DeptTransId.ToString();
                //    DataSet ds = GetIfmsDetails(detr);

                //    if (ds.Tables.Count > 0)
                //    {
                //        var item = ds.Tables[0].Rows[0];
                //        DataTable dt = new DataTable();
                //        objBE.Reg_Code = txtRegistrationNo.Text.ToString();
                //        objBE.ChallanNumber= item["challanno"].ToString();
                //        objBE.DeptTransid = item["depttransid"].ToString();
                //        objBE.HOA = item["hoa"].ToString();
                //        objBE.Amount = Convert.ToDecimal(item["bankamount"].ToString());
                //        objBE.BankTransid = item["banktransid"].ToString();
                //        objBE.DDoCode = item["ddocode"].ToString();
                //        objBE.DeptCode = item["deptcode"].ToString();
                //        objBE.RemitterName = item["remittersname"].ToString();
                //        objBE.BankDate = Convert.ToDateTime(item["scrolldate"].ToString());
                //        objBE.BankStatus = item["bankstatus"].ToString();
                //        objBE.BankCode = item["bankcode"].ToString();
                //        objBE.Action = "ChallanUpdate";

                //        dt = objDL.CyberChallanUpdate(objBE, ConnKey);
                //        if (dt.Rows.Count > 0)
                //        {
                //            objCommon.ShowAlertMessage("Application Submitted Sucessfully");

                //        }
                //        else
                //        {
                //            objCommon.ShowAlertMessage("No Details Found");
                //        }

                //    }

                //}
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }
        public class Depttrans
        {
            public int deptcode { get; set; }
            public string depttransid { get; set; }
        }
        //public DataSet GetIfmsDetails(Depttrans c)
        //{
        //    DataSet result = new DataSet();
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("challanno", typeof(string));
        //    dt.Columns.Add("depttransid", typeof(string));
        //    dt.Columns.Add("hoa", typeof(string));
        //    dt.Columns.Add("bankamount", typeof(string));
        //    dt.Columns.Add("banktransid", typeof(string));
        //    dt.Columns.Add("ddocode", typeof(string));
        //    dt.Columns.Add("deptcode", typeof(string));
        //    dt.Columns.Add("remittersname", typeof(string));
        //    dt.Columns.Add("scrolldate", typeof(string));
        //    dt.Columns.Add("bankstatus", typeof(string));
        //    dt.Columns.Add("bankcode", typeof(string));
        //    DataTable dterror = new DataTable();

        //    dterror.Columns.Add("ErrorMessage", typeof(string));
        //    try
        //    {
        //        ServicePointManager.Expect100Continue = true;
        //        ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
        //        HttpClient client = new HttpClient();
        //        // client.BaseAddress = new Uri("https://ifmis.telangana.gov.in/payment/");
        //        var json = JsonConvert.SerializeObject(c);
        //        var data = new StringContent(json, Encoding.UTF8, "application/text");
        //        HttpResponseMessage response = client.GetAsync("https://ifmis.telangana.gov.in/payment/get_cyber_challan_details?deptcode=" + c.deptcode + "&depttransid=" + c.depttransid).Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string apiResponse = response.Content.ReadAsStringAsync().Result;
        //            //ds = JsonConvert.DeserializeObject<ApiDetails.EncResponse>(apiResponse);
        //            dynamic jsonObject = JsonConvert.DeserializeObject(apiResponse);
        //            if (jsonObject != null)
        //            {
        //                foreach (var innerList in jsonObject.challandetails)
        //                {
        //                    DataRow dr = dt.NewRow();
        //                    dr["challanno"] = innerList["challanno"];
        //                    dr["depttransid"] = innerList["depttransid"];
        //                    dr["hoa"] = innerList["hoa"];
        //                    dr["bankamount"] = innerList["bankamount"];
        //                    dr["banktransid"] = innerList["banktransid"];
        //                    dr["ddocode"] = innerList["ddocode"];
        //                    dr["remittersname"] = innerList["remittersname"];
        //                    dr["scrolldate"] = innerList["scrolldate"];
        //                    dr["bankstatus"] = innerList["bankstatus"];
        //                    dr["bankcode"] = innerList["bankcode"];
        //                    dt.Rows.Add(dr);
        //                }
        //                result.Tables.Add(dt);
        //            }
        //            else
        //            {
        //                objCommon.ShowAlertMessage("No Data Found");
        //            }
        //        }
        //        else
        //        {
        //            DataRow dr = dt.NewRow();
        //            dt.Rows.Add(dr);
        //            result.Tables.Add(dt);
        //            DataRow drerror = dterror.NewRow();
        //            drerror["ErrorMessage"] = "Unable to fetch data from IFMS server..";
        //            dterror.Rows.Add(drerror);
        //            result.Tables.Add(dterror);
        //            return result;
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return result;
        //    }
        //}
        private DataTable challandetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Supplier_Code", typeof(string));
            dt.Columns.Add("DeptTransid", typeof(string));
            dt.Columns.Add("ChallanNumber", typeof(string));
            dt.Columns.Add("HOAccount", typeof(string));
            dt.Columns.Add("BankAmount", typeof(string));
            dt.Columns.Add("BankTransid", typeof(string));
            dt.Columns.Add("DDOCode", typeof(string));
            dt.Columns.Add("RemitterName", typeof(string));
            dt.Columns.Add("BankDate", typeof(string));
            dt.Columns.Add("BankStatus", typeof(string));
            dt.Columns.Add("BankCode", typeof(string));
            return dt;
        }
        protected void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ChkSelectAll = (CheckBox)sender;
            GridViewRow gRow = (GridViewRow)ChkSelectAll.NamingContainer;

            if (ChkSelectAll.Checked == true)
            {
                foreach (GridViewRow gr in GvDF.Rows)
                {
                    ((CheckBox)gr.FindControl("ChkSelect")).Checked = true;
                }
            }
            else
            {
                foreach (GridViewRow gr in GvDF.Rows)
                {
                    ((CheckBox)gr.FindControl("ChkSelect")).Checked = false;
                }
            }
        }


        public DataSet UPINJsonStringToDataTable(string jsonStringDS)
        {
            jsonStringDS = jsonStringDS.Replace("<pre>", "");
            //jsonStringDS = jsonStringDS.Replace("<pre>{\"TmpReGSno\":", "");
            // jsonString = jsonString.Replace("\"PartyDetails\":", "");
            jsonStringDS = jsonStringDS.Replace("}</pre>", "");

            jsonStringDS = jsonStringDS.Replace(jsonStringDS.Substring(0, jsonStringDS.IndexOf("[{")), "");
            jsonStringDS = jsonStringDS.Replace("}]}", "}]");
            //jsonStringDS = jsonStringDS.Replace("{"challandetails":", "");


            DataSet DS = new DataSet();




            string[] jsonDSarray = Regex.Split(jsonStringDS, "}],");



            foreach (string jSADS in jsonDSarray)
            {

                string jsonString = jSADS;//.Substring(idx1 + 1);
                DataTable dt = new DataTable();
                dt.TableName = "pniu";
                string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
                List<string> ColumnsName = new List<string>();
                foreach (string jSA in jsonStringArray)
                {
                    string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",\"");
                    foreach (string ColumnsNameData in jsonStringData)
                    {
                        try
                        {
                            int idx = ColumnsNameData.IndexOf(":");
                            string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                            if (!ColumnsName.Contains(ColumnsNameString))
                            {
                                ColumnsName.Add(ColumnsNameString);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                        }
                    }
                    break;
                }
                foreach (string AddColumnName in ColumnsName)
                {
                    dt.Columns.Add(AddColumnName);
                }
                foreach (string jSA in jsonStringArray)
                {
                    string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",\"");
                    DataRow nr = dt.NewRow();
                    foreach (string rowData in RowData)
                    {
                        try
                        {
                            int idx = rowData.IndexOf(":");
                            string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", "");
                            string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
                            nr[RowColumns] = RowDataString;
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                    dt.Rows.Add(nr);
                }
                DS.Tables.Add(dt);
            }
            return DS;
        }

        public DataSet GetDt(int deptcode, string depttransid)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3 | (SecurityProtocolType)3072;// | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11; //| SecurityProtocolType.Tls13
            var newTable = new DataSet();
            string strUrl = String.Format("https://ifmis.telangana.gov.in/payment/get_cyber_challan_details?deptcode=" + deptcode + "&depttransid=" + depttransid);
            WebRequest rqObjPost = HttpWebRequest.Create(strUrl);
            rqObjPost.Method = "GET";
            rqObjPost.ContentType = "application/text";

            // string postdata = "deptcode=" + deptcode + "&depttransid=" + depttransid;
            //  using (rqObjPost)
            {

                // streamwriter.Write(postdata);
                //streamwriter.Flush();
                //streamwriter.Close();



                try
                {



                    //  ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                    //  HttpWebResponse response = (HttpWebResponse)rqObjPost.GetResponse();

                    var httprsp = (HttpWebResponse)rqObjPost.GetResponse();

                    using (var strreader = new StreamReader(httprsp.GetResponseStream()))
                    {
                        var rs = strreader.ReadToEnd();
                        // JsonStringToDataTable(rs);
                        //var reader = new System.IO.StreamReader(xmlStream);

                        newTable = UPINJsonStringToDataTable(rs);
                        //newTable.ReadXml(strreader);
                    }
                }
                catch (Exception ex)
                { }
                finally
                { }
            }

            return newTable;
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate1())
                {
                    Viewdata();
                }

            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }
        }

        public DataSet GetIfmsDetails(Depttrans c)
        {
            DataSet result = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("challanno", typeof(string));
            dt.Columns.Add("depttransid", typeof(string));
            dt.Columns.Add("hoa", typeof(string));
            dt.Columns.Add("bankamount", typeof(string));
            dt.Columns.Add("banktransid", typeof(string));
            dt.Columns.Add("ddocode", typeof(string));
            dt.Columns.Add("deptcode", typeof(string));
            dt.Columns.Add("remittersname", typeof(string));
            dt.Columns.Add("scrolldate", typeof(string));
            dt.Columns.Add("bankstatus", typeof(string));
            dt.Columns.Add("bankcode", typeof(string));
            DataTable dterror = new DataTable();

            dterror.Columns.Add("ErrorMessage", typeof(string));
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "IFMIS");
                // client.BaseAddress = new Uri("https://ifmis.telangana.gov.in/payment/");
                var json = JsonConvert.SerializeObject(c);
                var data = new StringContent(json, Encoding.UTF8, "application/text");
                HttpResponseMessage response = client.GetAsync("https://ifmis.telangana.gov.in/payment/get_cyber_challan_details?deptcode=" + c.deptcode + "&depttransid=" + c.depttransid).Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    //ds = JsonConvert.DeserializeObject<ApiDetails.EncResponse>(apiResponse);
                    dynamic jsonObject = JsonConvert.DeserializeObject(apiResponse);
                    if (jsonObject != null)
                    {
                        foreach (var innerList in jsonObject.challandetails)
                        {
                            DataRow dr = dt.NewRow();
                            dr["challanno"] = innerList["challanno"];
                            dr["depttransid"] = innerList["depttransid"];
                            dr["hoa"] = innerList["hoa"];
                            dr["bankamount"] = innerList["bankamount"];
                            dr["banktransid"] = innerList["banktransid"];
                            dr["ddocode"] = innerList["ddocode"];
                            dr["remittersname"] = innerList["remittersname"];
                            dr["scrolldate"] = innerList["scrolldate"];
                            dr["bankstatus"] = innerList["bankstatus"];
                            dr["bankcode"] = innerList["bankcode"];
                            dt.Rows.Add(dr);
                        }
                        result.Tables.Add(dt);
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("No Data Found");
                    }
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                    result.Tables.Add(dt);
                    DataRow drerror = dterror.NewRow();
                    drerror["ErrorMessage"] = "Unable to fetch data from IFMS server..";
                    dterror.Rows.Add(drerror);
                    result.Tables.Add(dterror);
                    return result;
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            DataTable dtrans = null;
            string Transactionchek = null;
            try
            {
                if (Validate1())
                {
                    dtrans = Viewdata();
                }

                if (dtrans !=null & dtrans.Columns.Count == 1)
                {
                    objCommon.ShowAlertMessage(dtrans.Rows[0][0].ToString());
                    return;
                }
                else if (dtrans.Rows.Count > 0)
                {
                    for (int i = 0; i < dtrans.Rows.Count; i++)
                    {
                        Transactionchek += dtrans.Rows[i]["DeptTransid"] + ",";
                    }

                    if (!string.IsNullOrEmpty(Transactionchek))
                    {
                        Depttrans detr = new Depttrans();
                        detr.deptcode = 2304;
                        detr.depttransid = Transactionchek.ToString();
                        DataSet ds = GetIfmsDetails(detr);
                        if (ds.Tables.Count > 0)
                        {
                            DataTable dt = challandetails();
                            DataTable ChallanUpdate = ds.Tables[0];
                            foreach (DataRow innerList in ChallanUpdate.Rows)
                            {
                                DataRow dr = dt.NewRow();
                                dr["Supplier_Code"] = txtRegistrationNo.Text.ToString();
                                dr["DeptTransid"] = innerList["depttransid"];
                                dr["ChallanNumber"] = innerList["challanno"];
                                dr["HOAccount"] = innerList["hoa"];
                                dr["BankAmount"] = innerList["bankamount"];
                                dr["BankTransid"] = innerList["banktransid"];
                                dr["DDOCode"] = innerList["ddocode"];
                                dr["RemitterName"] = innerList["remittersname"];
                                dr["BankDate"] = innerList["scrolldate"];
                                dr["BankStatus"] = innerList["bankstatus"];
                                dr["BankCode"] = innerList["bankcode"];
                                dt.Rows.Add(dr);
                            }


                            objBE.Action = "EventChallanUpdate";

                            dt = objDL.Retailer_CyberChallanUpdate(dt, objBE, ConnKey);
                            if (dt.Rows.Count > 0)
                            {
                                lblError.Text = "Application Submitted Sucessfully";
                                lblError.ForeColor = System.Drawing.Color.Green;
                                lblError.Font.Size = 14;
                                objCommon.ShowAlertMessage("Application Submitted Sucessfully");
                                return;
                            }
                            else
                            {
                                lblError.Text = "No Details Found";
                                objCommon.ShowAlertMessage("No Details Found");
                                return;
                            }

                        }


                    }
                }
                else
                {
                    objCommon.ShowAlertMessage("Please Enter Registration No");
                    txtRegistrationNo.Focus();
                   
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        //DataTable dtrans = null;
        //try
        //{
        //    if (Validate1())
        //    {
        //        dtrans = Viewdata();
        //    }

        //    if (dtrans.Columns.Count == 1)
        //    {
        //        objCommon.ShowAlertMessage(dtrans.Rows[0][0].ToString());
        //        return;
        //    }
        //    else if (dtrans.Rows.Count > 0)
        //    {
        //        string Transactionchek = null;
        //        foreach (DataRow gr in dtrans.Rows)
        //        {

        //            Transactionchek += gr["DeptTransid"].ToString() + ",";
        //        }
        //        //((CheckBox)gr.FindControl("ChkSelect")).Checked = false;

        //        if (!string.IsNullOrEmpty(Transactionchek))
        //        {
        //            Depttrans detr = new Depttrans();
        //            detr.deptcode = 2304;
        //            //detr.depttransid = Convert.ToInt64(DeptTransId.Substring(5));
        //            detr.depttransid = Transactionchek.ToString();
        //            //  DataSet ds = GetIfmsDetails(detr);


        //            DataSet ds = GetDt(detr.deptcode, detr.depttransid);

        //            if (ds.Tables.Count > 0)
        //            {
        //                DataTable dt = challandetails();
        //                DataTable ChallanUpdate = ds.Tables[0];
        //                foreach (DataRow innerList in ChallanUpdate.Rows)
        //                {
        //                    DataRow dr = dt.NewRow();
        //                    dr["AppReg_No"] = txtRegistrationNo.Text.ToString();
        //                    dr["DeptTransid"] = innerList["depttransid"];
        //                    dr["ChallanNumber"] = innerList["challanno"];
        //                    dr["HOAccount"] = innerList["hoa"];
        //                    dr["BankAmount"] = innerList["bankamount"];
        //                    dr["BankTransid"] = innerList["banktransid"];
        //                    dr["DDOCode"] = innerList["ddocode"];
        //                    dr["RemitterName"] = innerList["remittersname"];
        //                    dr["BankDate"] = innerList["scrolldate"];
        //                    dr["BankStatus"] = innerList["bankstatus"];
        //                    dr["BankCode"] = innerList["bankcode"];
        //                    dt.Rows.Add(dr);
        //                }


        //                //var item = ds.Tables[0].Rows[0];

        //                //objBE.Reg_Code = txtRegistrationNo.Text.ToString();
        //                //objBE.ChallanNumber= item["challanno"].ToString();
        //                //objBE.DeptTransid = item["depttransid"].ToString();
        //                //objBE.HOA = item["hoa"].ToString();
        //                //objBE.Amount = Convert.ToDecimal(item["bankamount"].ToString());
        //                //objBE.BankTransid = item["banktransid"].ToString();
        //                //objBE.DDoCode = item["ddocode"].ToString();
        //                //objBE.DeptCode = item["deptcode"].ToString();
        //                //objBE.RemitterName = item["remittersname"].ToString();
        //                //objBE.BankDate = Convert.ToDateTime(item["scrolldate"].ToString());
        //                //objBE.BankStatus = item["bankstatus"].ToString();
        //                //objBE.BankCode = item["bankcode"].ToString();
        //                objBE.Action = "ChallanUpdate";

        //                dt = objDL.UserCyberChallanUpdate(dt, objBE, ConnKey);
        //                if (dt.Rows.Count > 0)
        //                {
        //                    objCommon.ShowAlertMessage("Application Submitted Sucessfully");
        //                    GvDF.Visible = false;
        //                    txtRegistrationNo.Text = "";
        //                    // BtnUpdate.Visible = false;
        //                }
        //                else
        //                {
        //                    objCommon.ShowAlertMessage("No Details Found");
        //                }

        //            }


        //        }
        //        else
        //        {
        //            objCommon.ShowAlertMessage("Please Select Atleast One Checkbox");
        //        }

        //    }
        //}
        //catch (Exception ex)
        //{
        //    //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //    Response.Redirect("~/Error.aspx");
        //}


    }
}
           
       