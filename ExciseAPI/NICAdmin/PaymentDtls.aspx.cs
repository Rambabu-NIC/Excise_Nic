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

namespace ExciseAPI.NICAdmin
{
    public partial class PaymentDtls : System.Web.UI.Page
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
            
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "9" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                //  lblUSer.Text = Session["UsrName"].ToString();
                Getdata();
                BindTypeofpayment();
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
        protected void Getdata()
        {
            try
            {
                objBE = new Supplier_BE();
                DataTable dt1 = new DataTable();
                objBE.Reg_Code = Session["RegId"].ToString();
                objBE.Action = "PR";
                dt1 = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    //  pannel1.Visible = true;
                    lblName.Text = dt1.Rows[0]["App_Name"].ToString();
                    lblRegNo.Text = Session["RegId"].ToString();
                    lblFee.Text = dt1.Rows[0]["License_Fee"].ToString();
                    txtDDOCode.Text = dt1.Rows[0]["DDO_Code"].ToString();
                    objBE.Statecode = "36";

                    //   dt1.Rows[0]["License_Fee"] = txtLicen.Text;
                }
                else
                {

                    objCommon.ShowAlertMessage("There Is No Data Found For this Registration Number");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("../Error.aspx");
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {

            if (lblFee.Text != "0" && lblFee.Text != "")
            {
                string transid = GenerateNumber();
                DataTable dt = new DataTable();
                dt = new DataTable();
                objBE.DeptCode = "2304";
                objBE.PaymentMode = "P";
                // Session["DDOCode"]=txtDDOCode.Text ;
                //objBE.BankTransid = "5435";
                objBE.SupplierName = lblRegNo.Text;
                objBE.DDoCode = txtDDOCode.Text;
                objBE.HOAccount = "0039001050002000000NVN";
                objBE.DeptTransid = lblRegNo.Text + transid;//txtDdocd.Text.Trim() + transid;
                objBE.RemitterName = lblName.Text;
                objBE.Amount = Convert.ToDecimal(lblFee.Text.Trim());
                objBE.IpAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();

                objBE.Action = "EP";

                dt = objDL.GetPaymentSaveDtls(objBE, ConnKey);

                //objemailsms.sendSms("9866992393", "ODLS Testing.. ");

                Response.Clear();
                StringBuilder sb = new StringBuilder();
                sb.Append("<html>");

                sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");

                sb.AppendFormat("<form name='form' action='{0}' method='post'>", "https://treasury.telangana.gov.in/tg_cybertry/deptrequest.php");


                sb.AppendFormat("<input type='hidden' name='MD' value='{0}'>", "P");
                sb.AppendFormat("<input type='hidden' name='deptcode' value='{0}'>", "2304");
                sb.AppendFormat("<input type='hidden' name='depttransid' value='{0}'>", lblRegNo.Text + transid);
                sb.AppendFormat("<input type='hidden' name='ddocode' value='{0}'>", txtDDOCode.Text);
                sb.AppendFormat("<input type='hidden' name='hoa' value='{0}'>", "0039001050002000000NVN");
                sb.AppendFormat("<input type='hidden' name='remittersname' value='{0}'>", lblName.Text);
                sb.AppendFormat("<input type='hidden' name='amount' value='{0}'>", "1.00");
                sb.AppendFormat("<input type='hidden' name='dru' value='{0}'>", "http://excise.telangana.gov.in/PaymentView.aspx");

                //sb.AppendFormat("<input type='hidden' name='MD' value='{0}'>", "P");
                //sb.AppendFormat("<input type='hidden' name='deptcode' value='{0}'>", "2304");
                //sb.AppendFormat("<input type='hidden' name='depttransid' value='{0}'>", lblRegNo.Text + transid);
                //sb.AppendFormat("<input type='hidden' name='ddocode' value='{0}'>", txtDDOCode.Text);
                //sb.AppendFormat("<input type='hidden' name='hoa' value='{0}'>", txtHOA.Text);
                //sb.AppendFormat("<input type='hidden' name='remittersname' value='{0}'>", lblName.Text);
                //sb.AppendFormat("<input type='hidden' name='amount' value='{0}'>", "1.00");
                //sb.AppendFormat("<input type='hidden' name='dru' value='{0}'>", "http://excise.telangana.gov.in/PaymentView.aspx");
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
        public void BindTypeofpayment()
        {
            //try
            //{

            //    DataTable dt1 = new DataTable();
            //    objBE.Action = "R1";
            //    dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
            //    objCommon.BindDropDownLists(ddlTypeofpayment, dt1, "DF_Descr", "DF_Code", "0");
            //}
            //catch (Exception ex)
            //{
            //    ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            //    Response.Redirect("~/Error.aspx");
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
}