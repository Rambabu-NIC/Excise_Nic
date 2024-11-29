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

namespace ExciseAPI.Retailer
{
    public partial class RPaymentDtls_LateFee : System.Web.UI.Page
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
            if (Session["IsConfirm"].ToString() == "0")
            {
                Response.Redirect("~/Retailer/RetailerProfile_Confirm.aspx");
            }
            //if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            //{
            //    Response.Redirect("~/Error.aspx");
            //}
            //else
            //{
            //    string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            //    string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            //    int len = http_hos.Length;
            //    if (http_ref.IndexOf(http_hos, 0) < 0)
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }
            //}
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

                txtRetailercode.Text = Session["UsrName"].ToString();
                txtRetailerName.Text = Session["SuppName"].ToString();
                txtMobile.Text = Session["Mob"].ToString();
                txtDDOCode.Text = Session["DDOCode"].ToString();
                txtLicNo.Text = Session["License_No"].ToString();
                txt_Extax.Text = Session["Type_of_Manufacturing"].ToString();
                txt_retailer.Text = Session["Retailer_Type_Short_Name"].ToString();
                random();


                BindSubHead();
                

            }

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





        protected void btn_Save_Click(object sender, EventArgs e)
        {

            if (ddlSubH.SelectedValue.ToString() == "")
            {
                lblError.Text = "Please Select Type Of Payment";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlInsNo.SelectedValue.ToString() == "")
            {
                lblError.Text = "Please Select Installment Number";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(rbdstatus.SelectedValue))
            {
                lblError.Text = "Please Select Installment Amount Pay";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            //if (rbdstatus.SelectedValue == "0")
            //{
            //    objCommon.ShowAlertMessage("Please Select Istallment Amount Pay");
            //    return;
            //}
            if (rbdstatus.SelectedValue == "2")
            {
                if (txtAmt.Text == "")
                {
                    lblError.Text = "Please Enter Amount";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            decimal balance = Convert.ToDecimal(txtBalancepaid.Text);
            if (!string.IsNullOrEmpty(txtBalancepaid.Text) && balance > 0)
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
                    objBE.Installment = ddlInsNo.SelectedValue;
                    objBE.TotalFeePaid = Convert.ToDecimal(txtAmount.Text.Trim());
                    objBE.DDoCode = txtDDOCode.Text;
                    objBE.HOAccount = txtHOA.Text;
                    objBE.DeptTransid = Session["UsrName"].ToString() + transid;//txtDdocd.Text.Trim() + transid;
                    objBE.RemitterName = Session["UsrName"].ToString();
                    objBE.Amount = Convert.ToDecimal(txtAmt.Text.Trim());
                    objBE.IpAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.Supplier_Code = Session["UsrName"].ToString();
                    objBE.SupplierName = Session["SuppName"].ToString();
                    objBE.Type_of_Manu = Session["Type_Retailer"].ToString();
                    objBE.MinorHead = txt_retailer.Text.ToString();
                    objBE.SubHead = ddlSubH.SelectedValue;
                    objBE.Type_of_Duties = "0";
                    objBE.Action = "CPELATE";
                    objBE.TypePayment = ddlSubH.SelectedValue;
                    objBE.PenaltyAmount = txtLateFee.Text.ToString();
                    dt = objDL.GetPaymentSaveCPEDtls_LateFee(objBE, ConnKey);
                    Response.Clear();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<html>");
                    sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
                    sb.AppendFormat("<form name='form' action='{0}' method='post'>", "https://treasury.telangana.gov.in/tg_cybertry/deptrequest.php");
                    sb.AppendFormat("<input type='hidden' name='MD' value='{0}'>", "P");
                    sb.AppendFormat("<input type='hidden' name='deptcode' value='{0}'>", "2304");
                    sb.AppendFormat("<input type='hidden' name='depttransid' value='{0}'>", Session["UsrName"].ToString() + transid);
                    sb.AppendFormat("<input type='hidden' name='ddocode' value='{0}'>", txtDDOCode.Text);
                    sb.AppendFormat("<input type='hidden' name='hoa' value='{0}'>", txtHOA.Text.ToString());
                    sb.AppendFormat("<input type='hidden' name='remittersname' value='{0}'>", Session["UsrName"].ToString());
                    sb.AppendFormat("<input type='hidden' name='amount' value='{0}'>", txtAmt.Text);// 
                    //sb.AppendFormat("<input type='hidden' name='dru' value='{0}'>", "http://localhost/Excise/Retailer/CPEPaymentView");
                    sb.AppendFormat("<input type='hidden' name='dru' value='{0}'>", WebApiConfig.paymentredirect + "Retailer/CPEPaymentView");
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
            else
            {
                objCommon.ShowAlertMessage("Balance amount to be paid greater then zero..");
                return;
            }


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
        protected void ddlduty_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindSubHead();
            //if (ddlduty.SelectedValue == "4")
            //{
            //    BindInstallmentNo();
            //}
        }
        public void BindSubHead()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Type_of_Manu = Session["Type_Retailer"].ToString();
                //objBE.MinorHead = ddlduty.SelectedValue;
                objBE.Action = "RPTypeOfPayment";
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
            BindInstallmentNo();
        }
        protected void ddlTypeofpayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void BindInstallmentNo()
        {
            try
            {

                DataTable dt1 = new DataTable();

                //objBE.MinorHead = ddlduty.SelectedValue;
                objBE.MinorHead = Session["Type_Retailer"].ToString();
                objBE.SubHead = ddlSubH.SelectedValue;
                objBE.Action = "INS1";
                dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                if (dt1.Rows.Count > 0)
                {
                    objCommon.BindDropDownLists(ddlInsNo, dt1, "InstallmentType", "InstallmentNo", "0");
                }
                else
                {
                }
                //objCommon.BindDropDownLists(ddlSubH, dt1, "Sub_Head_Desc", "Sub_Head_Code", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindHOA()
        {
            try
            {

                DataTable dt1 = new DataTable();

                //objBE.MinorHead = ddlduty.SelectedValue;
                objBE.MinorHead = Session["Type_Retailer"].ToString();
                objBE.SubHead = ddlSubH.SelectedValue;
                objBE.Action = "RA";
                dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                if (dt1.Rows.Count > 0)
                {
                    txtHOA.Text = dt1.Rows[0]["HOA"].ToString();
                }
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
           // InstallmentAmount();
        }

        public void InstallmentAmount()
        {
            if (rbdstatus.SelectedValue == "1")
            {

                objBE.Supplier_Code = Session["UsrName"].ToString();
                objBE.Action = "IP";
                objBE.Installment = ddlInsNo.SelectedValue;
                objBE.SubHead = ddlSubH.SelectedValue;
                objBE.Type_of_Manu = Session["Type_Retailer"].ToString();
                DataTable dt2 = new DataTable();
                dt2 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                decimal AfterLateFeeAmount = Convert.ToDecimal(dt2.Rows[0]["InstallMentAmt"].ToString()) + Convert.ToDecimal(LateFee);
                txtAmt.Text = AfterLateFeeAmount.ToString();
                txtAmt.Enabled = false;
            }
            else
            {
                //txtAmt.Text = "";
                //txtAmt.Enabled = true;
            }
        }
        public void GetInsAmt()
        {
            try
            {

                DataTable dt1 = new DataTable();

                //objBE.MinorHead = ddlduty.SelectedValue;
                objBE.MinorHead = txt_retailer.Text.ToString();
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
        public string LateFee
        {
            get
            {
                return ViewState["LateFee"] as string;
            }
            set
            {
                ViewState["LateFee"] = value;
            }
        }
        protected void ddlInsNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            //dvpnl.Visible = true;
            if (ddlInsNo.SelectedValue != "0")
            {
                objBE.Installment_No = Convert.ToInt32(ddlInsNo.SelectedValue);
                objBE.Retailer_Code = Session["UsrName"].ToString();
                objBE.Type_of_Manu= Session["Type_Retailer"].ToString();
                objBE.SubHead = ddlSubH.SelectedValue;

                dt1 = objDL.GetCPEPaymentLateFee(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    txtAmount.Text = dt1.Rows[0]["TotalAmount"].ToString();
                    txtStartDate.Text = dt1.Rows[0]["StartDate"].ToString();
                    txtEnddate.Text = dt1.Rows[0]["EndDate"].ToString();
                    // lblDemand.Text = dt1.Rows[0]["InstallMentAmt"].ToString();
                    txtBalancepaid.Text = dt1.Rows[0]["InstallMentAmt"].ToString();
                    txtTotalAmountPaid.Text = dt1.Rows[0]["TotalAmountPaid"].ToString();
                    //txtTotalAmountPaid.Text = dt1.Rows[0]["InstallMentAmt"].ToString();
                    //if (lblAmount.Text != lblBalancePaid.Text)
                    //{
                    //    dvinsA.Visible = true;
                    //}
                    //lblBalancePaid.Text = Convert.ToInt32(lblAmount.Text) - Convert.ToInt32(lblDemand.Text);
                    DateTime EndDate = Convert.ToDateTime(dt1.Rows[0]["dueDate"].ToString());
                    DateTime Today = DateTime.Today;
                    //int Count=(Today-EndDate).TotalDays;
                    //int count = (Convert.ToDateTime(Today) - Convert.ToDateTime(EndDate));
                    //int count = Convert.ToInt32(Today.ToString()) - Convert.ToInt32( EndDate.ToString());


                    TimeSpan NoDays = Today - EndDate;
                    //TimeSpan NoDays = EndDate - Today;
                    //decimal LateFee = 0;
                    decimal BalanceAmount = 0;
                    decimal Fee = 0;
                    decimal PenaltyFee = 0;
                    if (NoDays.TotalDays > 0 || NoDays.TotalDays < 0)
                    {
                        divlatefee.Visible = true;
                        //txtLateFee.Visible = true;
                        BalanceAmount = Decimal.Truncate(Convert.ToDecimal(txtBalancepaid.Text));
                        Fee = ((BalanceAmount * 18) / 100) / 365;
                        PenaltyFee = Math.Round(Fee * Convert.ToDecimal(NoDays.TotalDays), 0);

                    }
                    txtLateFee.Text = PenaltyFee.ToString();
                    
                    decimal AfterLateFeeAmount = Decimal.Truncate(BalanceAmount) + Decimal.Truncate(PenaltyFee);
                    txtAmt.Text = AfterLateFeeAmount.ToString();
                    txtAmt.Enabled = false;

                    //decimal result = LateFee;
                    //decimal Latefee = BalanceAmount * Convert.ToDecimal(((18 / 100) / 365) * NoDays.TotalDays);
                    //int Fee = (Latefee * NoDays);
                    BindData(Convert.ToInt32(ddlInsNo.SelectedValue));
                    rbdstatus.SelectedValue = "1";
                    //InstallmentAmount();
                }
                else
                {
                    txtAmount.Text = "";
                    txtStartDate.Text = "";
                    txtEnddate.Text = "";
                    txtBalancepaid.Text = "";
                }
            }
        }
        public DataSet dtRetailers
        {
            get
            {
                return ViewState["dtRetailers"] as DataSet;
            }
            set
            {
                ViewState["dtRetailers"] = value;
            }
        }
        public void BindData(int InstallmentNo)
        {
            divpayment.Visible = false;
            //string RetailerCode = System.Web.HttpContext.Current.Session["Retailer_Code"].ToString();
            objBE.RetailerCode = Session["UsrName"].ToString();
            objBE.InstallmentNo = InstallmentNo;
            dtRetailers = objDL.GetCPE_Details(objBE, ConnKey);

            if (dtRetailers.Tables.Count > 0 && dtRetailers.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = dtRetailers.Tables[0];
                gvdetails.DataBind();
                divpayment.Visible = true;
            }
        }
    }
}