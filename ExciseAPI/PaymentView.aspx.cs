using Excise_BE;
using Excise_DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Retailer_PaymentView : System.Web.UI.Page
{
    Supplier_BE objRegBE = new Supplier_BE();
    SupplierDAL objDL = new SupplierDAL();
    Master_DAL ObjMDL = new Master_DAL();
    CommonFuncs objCommon = new CommonFuncs();
    SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
    Validate objValidate = new Validate();
    string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            //lblUSer.Text = Session["UsrName"].ToString();
            // BindTypeofpayment();
            //random();



            try
            {
                t1.Visible = false;
                string[] keys = Request.Form.AllKeys;
                string result = "";
                if (keys.Length > 0)
                {
                    t1.Visible = true;
                    //for (int i = 0; i < keys.Length; i++)
                    //{
                    //    Response.Write("i==" + i + "=" + "///" + keys[i] + ": " + Request.Form[keys[i]] + "<br>");
                    //    result += keys[i] + ": " + Request.Form[keys[i]] + "<br>";
                    //}
                    try
                    {
                        lblbankStatus.Text = Request.Form[keys[2]].ToString();
                        lblchno.Text = Request.Form[keys[3]].ToString();
                        lbldepttransid.Text = Request.Form[keys[4]].ToString();
                        lbltrydate.Text = Request.Form[keys[5]].ToString();
                        lblbanktransid.Text = Request.Form[keys[6]].ToString();
                        lblbankname.Text = Request.Form[keys[7]].ToString();
                        lblbankdate.Text = Request.Form[keys[8]].ToString();
                        lblhoa.Text = Request.Form[keys[9]].ToString();
                        //lblrnm.Text = Request.Form[keys[10]].ToString();
                        lblddocode.Text = Request.Form[keys[11]].ToString();
                        lblAmt.Text = Request.Form[keys[12]].ToString();
                        string flag = Request.Form[keys[13]].ToString();
                    }
                    catch
                    {
                    }


                    objRegBE.TreasuryDate = DateTime.Parse(lbltrydate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                    objRegBE.BankStatus = lblbankStatus.Text.Trim();
                    objRegBE.ChallanNumber = lblchno.Text.Trim();
                    objRegBE.DeptTransid = lbldepttransid.Text.Trim();
                    objRegBE.BankTransid = lblbanktransid.Text.Trim();
                    objRegBE.BankCode = lblbankname.Text.Trim();
                    // objRegBE.SupplierCode=
                    objRegBE.BankDate = DateTime.Parse(lblbankdate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                    objRegBE.IpAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objRegBE.Action = "UA";
                    DataTable dt = new DataTable();
                    dt = objDL.GetPaymentUpdateDtls(objRegBE, ConnKey);


                    string StrContent = lbldepttransid.Text + "|" + "|" + DateTime.Parse(lbltrydate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date + "|" + lblbankStatus.Text.Trim() + "|" + lblchno.Text.Trim() + "|" + lbldepttransid.Text.Trim() + "|" + lblbanktransid.Text.Trim() + "|" + DateTime.Parse(lblbankdate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date + "\n";

                }
                else
                {
                    t1.Visible = false;
                    Depttrans detr = new Depttrans();
                    detr.deptcode = 2304;
                    //detr.depttransid = Convert.ToInt64(DeptTransId.Substring(5));
                    detr.depttransid = Session["RDeptTransId"].ToString();
                    DataSet ds = GetIfmsDetails(detr);

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count >0)
                    {
                        try
                        {
                            t1.Visible = true;
                            var item = ds.Tables[0].Rows[0];
                            lblbankStatus.Text = item["bankstatus"].ToString();
                            lblchno.Text = item["challanno"].ToString();
                            lbldepttransid.Text = item["depttransid"].ToString();
                            lbltrydate.Text = item["scrolldate"].ToString();
                            lblbanktransid.Text = item["banktransid"].ToString();
                            lblbankname.Text = item["bankcode"].ToString();
                            lblbankdate.Text = item["scrolldate"].ToString();
                            lblhoa.Text = item["hoa"].ToString();
                            //lblrnm.Text = Request.Form[keys[10]].ToString();
                            lblddocode.Text = item["ddocode"].ToString();
                            lblAmt.Text = item["bankamount"].ToString();
                            //string flag = item[""].ToString();
                        }
                        catch
                        {
                        }


                        objRegBE.TreasuryDate = DateTime.Parse(lbltrydate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                        objRegBE.BankStatus = lblbankStatus.Text.Trim();
                        objRegBE.ChallanNumber = lblchno.Text.Trim();
                        objRegBE.DeptTransid = lbldepttransid.Text.Trim();
                        objRegBE.BankTransid = lblbanktransid.Text.Trim();
                        objRegBE.BankCode = lblbankname.Text.Trim();
                        // objRegBE.SupplierCode=
                        objRegBE.BankDate = DateTime.Parse(lblbankdate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                        objRegBE.IpAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                        objRegBE.Action = "UA";
                        DataTable dt = new DataTable();
                        dt = objDL.GetPaymentUpdateDtls(objRegBE, ConnKey);


                        string StrContent = lbldepttransid.Text + "|" + "|" + DateTime.Parse(lbltrydate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date + "|" + lblbankStatus.Text.Trim() + "|" + lblchno.Text.Trim() + "|" + lbldepttransid.Text.Trim() + "|" + lblbanktransid.Text.Trim() + "|" + DateTime.Parse(lblbankdate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date + "\n";
                    }
                }

            }
            catch
            {
            }
        }
        
    }

    public class Depttrans
    {
        public int deptcode { get; set; }
        public string depttransid { get; set; }
    }
    //DataSet result = new DataSet();

    public DataSet result
    {
        get
        {
            return ViewState["result"] as DataSet;
        }
        set
        {
            ViewState["result"] = value;
        }
    }

    public DataSet GetIfmsDetails(Depttrans c)
    {
       
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




    //public void random()
    //{
    //    try
    //    {
    //        string strString = "abcdefghijklmnpqrstuvwxyzABCDQEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    //        string num = "";
    //        Random rm = new Random();
    //        for (int i = 0; i < 16; i++)
    //        {
    //            int randomcharindex = rm.Next(0, strString.Length);
    //            char randomchar = strString[randomcharindex];
    //            num += Convert.ToString(randomchar);
    //        }
    //        hf.Value = num;
    //        Session["ASPFIXATION2"] = num;
    //    }
    //    catch (Exception ex)
    //    {
    //        //  Response.Redirect("~/Error.aspx");
    //    }
    //}

    //public void check()
    //{
    //    try
    //    {
    //        string cookie_value = null;
    //        string session_value = null;

    //        cookie_value = hf.Value;
    //        session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
    //        if (cookie_value != session_value)
    //        {
    //            System.Web.HttpContext.Current.Session.Abandon();
    //            HttpContext.Current.Response.Buffer = false;
    //            // HttpContext.Current.Response.Redirect("~/Error.aspx");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        // Response.Redirect("~/Error.aspx", false);
    //    }
    //}





    protected void btn_Save_Click(object sender, EventArgs e)
    {
        //if (ddlFNm.SelectedIndex != 0)
        //{
        //    if (ddlpayment.SelectedValue == "1")
        //    {
        //        if (txtAmount.Text != "0" && txtAmount.Text != "")
        //        {
        //            string transid = GenerateNumber();
        //            dt = new DataTable();
        //            Session["Firmid"] = ddlFNm.SelectedValue;
        //            objRegBE.ApplicantId = Session["ApplicantId"].ToString();
        //            objRegBE.FirmId = ddlFNm.SelectedValue;
        //            objRegBE.System = Session["System"].ToString();
        //            objRegBE.LicenseType_Code = Session["LicenseType"].ToString();
        //            objRegBE.LicenseMode_Code = Session["Licensem"].ToString();
        //            objRegBE.DeptCode = txtDeptcd.Text.Trim();
        //            objRegBE.DDOCode = txtDdocd.Text.Trim();
        //            objRegBE.HOAccount = txtHaccont.Text.Trim();
        //            objRegBE.DeptTransid = ddlFNm.SelectedValue.ToString().Trim() + transid;//txtDdocd.Text.Trim() + transid;
        //            objRegBE.RemitterName = txtRemitterNm.Text.Trim();
        //            objRegBE.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
        //            objRegBE.PaymentRemarks = txtPRemarks.Text;
        //            objRegBE.PaymentMode = ddlpayment.SelectedItem.ToString();
        //            objRegBE.IpAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
        //            objRegBE.Action = "IA";

        //            dt = objRegDL.GetPaymentSaveDtls(objRegBE);

        //            //objemailsms.sendSms("9866992393", "ODLS Testing.. ");

        //            Response.Clear();
        //            StringBuilder sb = new StringBuilder();
        //            sb.Append("<html>");

        //            sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
        //            sb.AppendFormat("<form name='form' action='{0}' method='post'>", "https://treasury.telangana.gov.in/tg_cybertry_test/deptrequest.php");


        //            sb.AppendFormat("<input type='hidden' name='MD' value='{0}'>", "P");
        //            sb.AppendFormat("<input type='hidden' name='deptcode' value='{0}'>", "0906");
        //            sb.AppendFormat("<input type='hidden' name='depttransid' value='{0}'>", ddlFNm.SelectedValue.ToString().Trim() + transid);
        //            sb.AppendFormat("<input type='hidden' name='ddocode' value='{0}'>", "25000906044");
        //            sb.AppendFormat("<input type='hidden' name='hoa' value='{0}'>", "0210032000081001000NVN");
        //            sb.AppendFormat("<input type='hidden' name='remittersname' value='{0}'>", txtRemitterNm.Text);
        //            sb.AppendFormat("<input type='hidden' name='amount' value='{0}'>", "1.00");
        //            sb.AppendFormat("<input type='hidden' name='dru' value='{0}'>", "http://ayushdls.telangana.gov.in/Applicant/Manuf/PaymentDtls.aspx");
        //            // Other params go here
        //            sb.Append("</form>");
        //            sb.Append("</body>");
        //            sb.Append("</html>");
        //            Response.Write(sb.ToString());
        //            Response.End();

        //        }
        //        else
        //        {
        //            objCommon.ShowAlertMessage("Enter Valid Amount");
        //            return;
        //        }
        //    }
        //    else if (ddlpayment.SelectedValue == "2")
        //    {
        //        if (ddlFNm.SelectedValue != "")
        //        {
        //            if (ddlpayment.SelectedValue != "")
        //            {
        //                if (FileUpload_cha.HasFile)
        //                {

        //                    Stream fs = FileUpload_cha.PostedFile.InputStream;
        //                    BinaryReader br = new BinaryReader(fs);
        //                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //                    string mime = MimeType.GetMimeType(bytes, FileUpload_cha.PostedFile.FileName);

        //                    if (mime == "application/pdf")
        //                    {
        //                        int len = FileUpload_cha.PostedFile.ContentLength;
        //                        if ((len / 1024) > 5120)
        //                        {

        //                            objCommon.ShowAlertMessage("File size is exceeded");
        //                            FileUpload_cha.Focus();
        //                            return;
        //                        }
        //                        string fileext = Path.GetExtension(FileUpload_cha.PostedFile.FileName);

        //                        objRegBE.UploadFiletype = fileext;
        //                        objRegBE.UploadFile = bytes;


        //                        dt = new DataTable();
        //                        objRegBE.ApplicantId = Session["ApplicantId"].ToString();
        //                        objRegBE.FirmId = ddlFNm.SelectedValue;
        //                        objRegBE.System = Session["System"].ToString();
        //                        objRegBE.LicenseType_Code = Session["LicenseType"].ToString();
        //                        objRegBE.LicenseMode_Code = Session["Licensem"].ToString();
        //                        //objRegBE.DeptCode = txtDeptcd.Text.Trim();
        //                        // objRegBE.DDOCode = txtDdocd.Text.Trim();
        //                        //objRegBE.HOAccount = txtHaccont.Text.Trim();
        //                        objRegBE.RemitterName = ddlFNm.SelectedItem.ToString();
        //                        objRegBE.PaymentMode = ddlpayment.SelectedItem.ToString();
        //                        objRegBE.Amount = Convert.ToDecimal(txtCamount.Text.Trim());
        //                        objRegBE.ChallanNumber = txtchallanno.Text.Trim();
        //                        DateTime regdt = DateTime.Parse(txtChallanDt.Text.ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
        //                        objRegBE.BankDate = regdt;
        //                        objRegBE.IpAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
        //                        objRegBE.Action = "CH";

        //                        dt = objRegDL.GetPaymentSaveDtls(objRegBE);
        //                        if (dt.Rows.Count > 0)
        //                        {
        //                            GetPaymentChaDtls();
        //                            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
        //                            return;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        objCommon.ShowAlertMessage("Select PDF File only");
        //                        return;
        //                    }
        //                }
        //                else
        //                {
        //                    objCommon.ShowAlertMessage("Select Challan File");
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                objCommon.ShowAlertMessage("Select Firm Name");
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            objCommon.ShowAlertMessage("Select Payment type");
        //            return;
        //        }
        //    }
        //}
        //else
        //{
        //    objCommon.ShowAlertMessage("Select Firm Name");
        //    return;
        //}
    }

    protected string GenerateNumber()
    {

        string characters = "1234567890";

        string otp = string.Empty;
        for (int i = 0; i < 5; i++)
        {
            string character = string.Empty;
            do
            {
                int index = new Random().Next(0, characters.Length);
                character = characters.ToCharArray()[index].ToString();
            } while (otp.IndexOf(character) != -1);
            otp += character;
        }

        string cdate = DateTime.Now.ToString("ddMMyyyy");

        return cdate + otp;

    }

}