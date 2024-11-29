using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;
using System.Configuration;
using System.Net;
using System.Text;

namespace ExciseAPI.Retailer
{
    public partial class PaymentRetailarDtls_MD : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-GB", true);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RetailerPassword"].ToString() == "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4")
            {
                Response.Redirect("~/Retailer/ChangePassword.aspx");
            }
            if (Session["IsConfirm"].ToString() == "0")
            {
                Response.Redirect("~/Retailer/RetailerProfile_Confirm.aspx");
            }
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
                //lblUSer.Text = Session["UsrName"].ToString();
                BindData();
            }

        }
        public DataTable dtRetailer
        {
            get
            {
                return ViewState["dtRetailer"] as DataTable;
            }
            set
            {
                ViewState["dtRetailer"] = value;
            }
        }

        public void BindData()
        {
            try
            {
                string DeptCode = System.Web.HttpContext.Current.Session["DepotCode"].ToString();
                string RetailerCode = System.Web.HttpContext.Current.Session["UsrName"].ToString();

                if (!string.IsNullOrEmpty(DeptCode) && !string.IsNullOrEmpty(RetailerCode))
                {
                    objBE.DepotCode = DeptCode;
                    objBE.RetailerCode = RetailerCode;

                    dtRetailer = objDL.GetRetailerDetails_MD(objBE, ConnKey);
                    if (dtRetailer.Rows.Count > 0)
                    {
                        Session["salesprocedDDO"] = dtRetailer.Rows[0]["major_head"].ToString();

                        txtdeptName.Text = dtRetailer.Rows[0]["unit_name"].ToString();
                        txtRetailerCode.Text = dtRetailer.Rows[0]["ptcode"].ToString();
                        txtlincesename.Text = dtRetailer.Rows[0]["contact"].ToString();
                        txtshopName.Text = dtRetailer.Rows[0]["ptname"].ToString();
                        txtGazette_Code.Text = dtRetailer.Rows[0]["Gazette_Code"].ToString();
                        txtretaileraddress.Text = dtRetailer.Rows[0]["Address"].ToString();
                        txtexciselicenseno.Text = dtRetailer.Rows[0]["license_no"].ToString();
                        txthead.Text = "8443008000009000000NVN";
                        string ddocode = System.Web.HttpContext.Current.Session["salesprocedDDO"].ToString();
                        txtddocode.Text = ddocode;
                        txtpurpose.Text = "Towards Sale proceeds";
                        // Response.Write("Done!");
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }
        protected string GenerateNumber()
        {
            //result:
            string characters = "1234567890";

            string otp = string.Empty;
            for (int i = 0; i < 7; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }

            string DeptCode = System.Web.HttpContext.Current.Session["DepotCode"].ToString();
            string RetailerCode = System.Web.HttpContext.Current.Session["UsrName"].ToString();
            string cdate = DateTime.Now.ToString("yyMMdd");
            string transaction = "TGBCL" + cdate + DeptCode + RetailerCode + otp;

            //DataTable matchtransction = objDL.MatchTransactionDetails(transaction, ConnKey);

            //if (matchtransction.Rows.Count >0)
            //{
            //    goto result;
            //}
            //else
            //{
            return otp;
            //}

            //string cdate = DateTime.Now.ToString("ddMMyyyy");




        }
        protected void btnpaymentSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtamount.Text))
            {


                decimal amount = Convert.ToDecimal(txtamount.Text);
                if (amount < 10000)
                {
                    lblError.Text = "Retailer remittance amount should be above Rs.9,999/-";
                    return;
                }
                else
                {
                    string DeptCode = System.Web.HttpContext.Current.Session["DepotCode"].ToString();
                    string RetailerCode = System.Web.HttpContext.Current.Session["UsrName"].ToString();
                    string RetailerName = System.Web.HttpContext.Current.Session["SuppName"].ToString();
                    string ddocode = System.Web.HttpContext.Current.Session["salesprocedDDO"].ToString();
                    string transid = GenerateNumber();
                    decimal Amounts = Convert.ToDecimal(txtamount.Text);

                    string cdate = DateTime.Now.ToString("yyMMdd");

                    string DepartmentTransactionID = "TGBCL" + cdate + DeptCode + RetailerCode + transid;

                    //DataTable dt = new DataTable();
                    //dt = new DataTable();
                    objBE.DepotCode = DeptCode;
                    objBE.Retailer_Code = RetailerCode;
                    objBE.LicenseNO = txtexciselicenseno.Text.ToString();
                    objBE.Amount = Amounts;
                    objBE.DeptTransid = DepartmentTransactionID.ToString();
                    objBE.RetailerName = RetailerName;
                    objBE.DDoCode = ddocode;
                    objBE.Purpose = txtpurpose.Text.ToString();
                    objBE.LicenseName = txtlincesename.Text.ToString();
                    objBE.CreatedBy = RetailerCode;
                    bool dt = objDL.GetRetailerPaymentDtails(objBE, ConnKey);
                    if (dt == true)
                    {
                        Session["RDeptTransId"] = DepartmentTransactionID.ToString();
                        Response.Clear();

                        StringBuilder sb = new StringBuilder();
                        sb.Append("<html>");
                        sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
                        sb.AppendFormat("<form name='form' action='{0}' method='post'>", "https://ifmis.telangana.gov.in/payment/payment_gateway?");
                        sb.AppendFormat("<input type='hidden' name='MD' value='{0}'>", "P");
                        sb.AppendFormat("<input type='hidden' name='deptcode' value='{0}'>", "2314");
                        sb.AppendFormat("<input type='hidden' name='depttransid' value='{0}'>", DepartmentTransactionID.ToString());
                        sb.AppendFormat("<input type='hidden' name='ddocode' value='{0}'>", txtddocode.Text);
                        sb.AppendFormat("<input type='hidden' name='hoa' value='{0}'>", "8443008000009000000NVN");
                        sb.AppendFormat("<input type='hidden' name='remittersname' value='{0}'>", Session["SuppName"].ToString());
                        sb.AppendFormat("<input type='hidden' name='amount' value='{0}'>", txtamount.Text);//
                        sb.AppendFormat("<input type='hidden' name='dru' value='{0}'>", WebApiConfig.paymentredirect + "Retailer/RetailerPaymentView");
                        // Other params go here
                        sb.Append("</form>");
                        sb.Append("</body>");
                        sb.Append("</html>");
                        Response.Write(sb.ToString());
                        Response.End();

                    }
                    else
                    {
                        lblError.Text = "Please check the values..";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    //StringBuilder sb = new StringBuilder();
                    //sb.Append("<html>");
                    //sb.AppendFormat("<body onload=\"document.forms['form'].submit()\">");
                    //sb.AppendFormat("<form name='form' action='{0}' method='post'>", "https://treasury.telangana.gov.in/tg_cybertry/deptrequest.php");
                    //sb.AppendFormat("<input type='hidden' name='MD' value='{0}'>", "P");
                    //sb.AppendFormat("<input type='hidden' name='deptcode' value='{0}'>", "2304");
                    //sb.AppendFormat("<input type='hidden' name='depttransid' value='{0}'>", "TGBCL" + Session["UsrName"].ToString() + transid);
                    //sb.AppendFormat("<input type='hidden' name='ddocode' value='{0}'>", txtddocode.Text);
                    //sb.AppendFormat("<input type='hidden' name='hoa' value='{0}'>", "8443008000009000000NVN");
                    //sb.AppendFormat("<input type='hidden' name='remittersname' value='{0}'>", Session["SuppName"].ToString());
                    //sb.AppendFormat("<input type='hidden' name='amount' value='{0}'>", txtamount.Text);
                    //sb.AppendFormat("<input type='hidden' name='dru' value='{0}'>", "https://excise.telangana.gov.in/ExciseAPI/Retailer/RetailerPaymentView.aspx");
                    //// Add other hidden input fields as needed
                    //sb.Append("</form>");
                    //sb.Append("</body>");
                    //sb.Append("</html>");

                    // Output the HTML form
                    //                Response.Write(sb.ToString());

                    // End the response to immediately redirect to the target page
                    //               Response.End();



                }

            }
            else
            {
                lblError.Text = "Please enter the Amount...";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
    }
}