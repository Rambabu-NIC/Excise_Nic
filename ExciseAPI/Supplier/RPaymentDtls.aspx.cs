using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using Excise_BE;
using Excise_DAL;
using System.Text;
using System.Net;
using System.IO;

namespace ExciseAPI.Supplier
{
    public partial class RPaymentDtls : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
                Response.Redirect("~/Error.aspx");
            }
            else
            {
                string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
                string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
                int len = http_hos.Length;
                if (http_ref.IndexOf(http_hos, 0) < 0)
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "12" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                //lblUSer.Text = Session["UsrName"].ToString();
                lblTypeofmanyf.Text = Session["UsrName"].ToString();
                lblSuppNm.Text = Session["SuppName"].ToString();
                lblMob.Text = Session["Mob"].ToString();
                txtDDOCode.Text = Session["DDOCode"].ToString();
                txtLicNo.Text = Session["License_No"].ToString();
                txt_Extax.Text = Session["Type_of_Manufacturing"].ToString();
                BindDuty();
                // BindTypeofpayment();
                //random();



                //try
                //{
                //    string[] keys = Request.Form.AllKeys;
                //    string result = "";
                //    if (keys.Length > 0)
                //    {
                //        t1.Visible = true;
                //        //for (int i = 0; i < keys.Length; i++)
                //        //{
                //        //    Response.Write("i==" + i + "=" + "///" + keys[i] + ": " + Request.Form[keys[i]] + "<br>");
                //        //    result += keys[i] + ": " + Request.Form[keys[i]] + "<br>";
                //        //}
                //        try
                //        {
                //            lblbankStatus.Text = Request.Form[keys[2]].ToString();
                //            lblchno.Text = Request.Form[keys[3]].ToString();
                //            lbldepttransid.Text = Request.Form[keys[4]].ToString();
                //            lbltrydate.Text = Request.Form[keys[5]].ToString();
                //            lblbanktransid.Text = Request.Form[keys[6]].ToString();
                //            lblbankname.Text = Request.Form[keys[7]].ToString();
                //            lblbankdate.Text = Request.Form[keys[8]].ToString();
                //            lblhoa.Text = Request.Form[keys[9]].ToString();
                //            //lblrnm.Text = Request.Form[keys[10]].ToString();
                //            lblddocode.Text = Request.Form[keys[11]].ToString();
                //            lblAmt.Text = Request.Form[keys[12]].ToString();
                //            string flag = Request.Form[keys[13]].ToString();
                //        }
                //        catch
                //        {
                //        }


                //        objBE.TreasuryDate = DateTime.Parse(lbltrydate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                //        objBE.BankStatus = lblbankStatus.Text.Trim();
                //        objBE.ChallanNumber = lblchno.Text.Trim();
                //        objBE.DeptTransid = lbldepttransid.Text.Trim();
                //        objBE.BankTransid = lblbanktransid.Text.Trim();
                //        objBE.BankCode = lblbankname.Text.Trim();
                //        objBE.BankDate = DateTime.Parse(lblbankdate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                //        objBE.IpAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                //        objBE.Action = "UA";
                //        DataTable dt = new DataTable();
                //        dt = objDL.GetPaymentUpdateDtls(objBE,ConnKey);               


                //        string StrContent = Session["UsrName"].ToString() + "|" + "|" + DateTime.Parse(lbltrydate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date + "|" + lblbankStatus.Text.Trim() + "|" + lblchno.Text.Trim() + "|" + lbldepttransid.Text.Trim() + "|" + lblbanktransid.Text.Trim() + "|" + DateTime.Parse(lblbankdate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date + "\n";

                //    }
                //    else
                //        t1.Visible = false;
                //}
                //catch
                //{
                //}




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
        //        Response.Redirect("~/Error.aspx");
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
        //            HttpContext.Current.Response.Redirect("~/Error.aspx");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Redirect("~/Error.aspx", false);
        //    }
        //}





        protected void btn_Save_Click(object sender, EventArgs e)
        {




            if (txtAmt.Text != "0" && txtAmt.Text != "")
            {
                string transid = GenerateNumber();
                DataTable dt = new DataTable();
                dt = new DataTable();
                objBE.DeptCode = "2304";
                objBE.PaymentMode = "P";
                Session["DDOCode"] = txtDDOCode.Text;
                //objBE.BankTransid = "5435";
                objBE.SupplierName = Session["UsrName"].ToString();
                objBE.DDoCode = txtDDOCode.Text;
                objBE.HOAccount = txtHOA.Text;
                objBE.DeptTransid = Session["UsrName"].ToString() + transid;//txtDdocd.Text.Trim() + transid;
                objBE.RemitterName = Session["UsrName"].ToString();
                objBE.Amount = Convert.ToDecimal(txtAmt.Text.Trim());
                objBE.IpAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                objBE.Supplier_Code = Session["UsrName"].ToString();
                objBE.SupplierName = Session["SuppName"].ToString();
                objBE.Type_of_Manu = "4";
                objBE.MinorHead = ddlduty.SelectedValue;
                objBE.SubHead = ddlSubH.SelectedValue;
                objBE.Type_of_Duties = "0";
                objBE.Action = "IA";

                dt = objDL.GetPaymentSaveDtls(objBE, ConnKey);

                //objemailsms.sendSms("9866992393", "ODLS Testing.. ");

                Response.Clear();
                StringBuilder sb = new StringBuilder();
                sb.Append("<html>");

                sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");

                sb.AppendFormat("<form name='form' action='{0}' method='post'>", "https://treasury.telangana.gov.in/tg_cybertry/deptrequest.php");


                sb.AppendFormat("<input type='hidden' name='MD' value='{0}'>", "P");
                sb.AppendFormat("<input type='hidden' name='deptcode' value='{0}'>", "2304");
                sb.AppendFormat("<input type='hidden' name='depttransid' value='{0}'>", Session["UsrName"].ToString() + transid);
                sb.AppendFormat("<input type='hidden' name='ddocode' value='{0}'>", txtDDOCode.Text);
                sb.AppendFormat("<input type='hidden' name='hoa' value='{0}'>", "0039001050002000000NVN");
                sb.AppendFormat("<input type='hidden' name='remittersname' value='{0}'>", Session["UsrName"].ToString());
                sb.AppendFormat("<input type='hidden' name='amount' value='{0}'>", "1.00");
                sb.AppendFormat("<input type='hidden' name='dru' value='{0}'>", WebApiConfig.paymentredirect + "Supplier/PaymentView");
                // Other params go here
                sb.Append("</form>");
                sb.Append("</body>");
                sb.Append("</html>");
                Response.Write(sb.ToString());
                Response.End();

            }
            else
            {
                objCommon.ShowAlertMessage("Enter Valid Amount");
                return;
            }



        }
        public void BindDuty()
        {
            try
            {

                DataTable dt1 = new DataTable();
                //objBE.Type_of_Manu = lblmfcd.Text;
                objBE.Action = "RT";
                dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlduty, dt1, "Retailer_Type_Description", "Retailer_Type_Code", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        //public void BindTypeofpayment()
        //{
        //    try
        //    {

        //        DataTable dt1 = new DataTable();
        //        objBE.Type_of_Manu = lblmfcd.Text;
        //        objBE.MinorHead = ddlduty.SelectedValue;
        //        objBE.SubHead = ddlSubH.SelectedValue;
        //        objBE.Action = "R1";
        //        dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
        //        objCommon.BindDropDownLists(ddlTypeofpayment, dt1, "DF_Descr", "DF_Code", "0");
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}
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
        protected void ddlduty_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubHead();
        }
        public void BindSubHead()
        {
            try
            {

                DataTable dt1 = new DataTable();
                //objBE.Type_of_Manu = lblmfcd.Text;
                //objBE.MinorHead = ddlduty.SelectedValue;
                objBE.Action = "RP";
                dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlSubH, dt1, "Payment_Desc", "Type_Payment", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void ddlSubH_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindHOA();
        }
        protected void ddlTypeofpayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void BindHOA()
        {
            try
            {

                DataTable dt1 = new DataTable();

                objBE.MinorHead = ddlduty.SelectedValue;
                objBE.SubHead = ddlSubH.SelectedValue;
                objBE.Action = "RA";
                dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                txtHOA.Text = dt1.Rows[0]["HOA"].ToString();
                //objCommon.BindDropDownLists(ddlSubH, dt1, "Sub_Head_Desc", "Sub_Head_Code", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void RbRemarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbdstatus.SelectedValue == "1")
            {

                objBE.MinorHead = Session["UsrName"].ToString();
                objBE.Action = "IP";
                DataTable dt2 = new DataTable();
                dt2 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                txtAmt.Text = dt2.Rows[0]["InstallMent6"].ToString();
                txtAmt.Enabled = false;
            }
            else
            {
                txtAmt.Text = "";
                txtAmt.Enabled = true;
            }
        }
        public void GetInsAmt()
        {
            try
            {

                DataTable dt1 = new DataTable();

                objBE.MinorHead = ddlduty.SelectedValue;
                objBE.SubHead = ddlSubH.SelectedValue;
                objBE.Action = "RA";
                dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                txtHOA.Text = dt1.Rows[0]["HOA"].ToString();
                //objCommon.BindDropDownLists(ddlSubH, dt1, "Sub_Head_Desc", "Sub_Head_Code", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}