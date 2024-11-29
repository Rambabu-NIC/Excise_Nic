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
    public partial class Retailer_ViewPaymet : System.Web.UI.Page
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


                // lblUSer.Text = Session["UsrName"].ToString();
                BindData();

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

        public void BindData()
        {
            //string RetailerCode = System.Web.HttpContext.Current.Session["Retailer_Code"].ToString();
            objBE.RetailerCode = Session["UsrName"].ToString();

            dtRetailers = objDL.GetViewPayment(objBE, ConnKey);

            if (dtRetailers.Tables.Count > 0 && dtRetailers.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = dtRetailers.Tables[0];
                gvdetails.DataBind();
            }
        }




        protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkView = e.Row.FindControl("lnkview") as LinkButton;
                string BankStatus = dtRetailers.Tables[0].Rows[0]["BankStatus"].ToString();
                //byte[] Document = Encoding.ASCII.GetBytes(dtRetailers.Tables[0].Rows[0]["DocumentFile"].ToString());
                if (BankStatus.ToUpper() == "SUCCESS")
                {
                    lnkView.Enabled = true;
                    lnkView.Text = "Click..!";
                }
                else
                {
                    lnkView.Enabled = false;
                    lnkView.Text = "Not Available";
                    lnkView.ForeColor = System.Drawing.Color.Black;
                }
            }
        }
        public DataSet dtReceiptDetails
        {
            get
            {
                return ViewState["dtReceiptDetails"] as DataSet;
            }
            set
            {
                ViewState["dtReceiptDetails"] = value;
            }
        }
        protected void gvdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "View")
            {
                //string CompalientID = e.CommandArgument.ToString();
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string DeptId = commandArgs[0];

                if (!string.IsNullOrEmpty(DeptId))
                {
                    objBE.DeptTransid = DeptId.ToString();
                    dtReceiptDetails = new SupplierDAL().GetReceiptDetails(objBE, ConnKey);
                    if (dtReceiptDetails.Tables.Count > 0 && dtReceiptDetails.Tables[0].Rows.Count > 0)
                    {
                        var item = dtReceiptDetails.Tables[0].Rows[0];
                        lblRetailerCode.Text= item["Supplier_Code"].ToString();
                        lblRetailerName.Text = item["Supplier_Name"].ToString();
                        lblbankStatus.Text = item["BankStatus"].ToString();
                        lblchno.Text = item["ChallanNumber"].ToString();
                        lbldepttransid.Text = item["DeptTransid"].ToString();
                        lbltrydate.Text = item["TreasuryDate"].ToString();
                        lblbanktransid.Text = item["BankTransid"].ToString();
                        lblbankname.Text = item["BankCode"].ToString();
                        lblbankdate.Text = item["BankDate"].ToString();
                        lblhoa.Text = item["HOAccount"].ToString();
                        //lblrnm.Text = Request.Form[keys[10]].ToString();
                        lblddocode.Text = item["DDOCode"].ToString();
                        lblAmt.Text = item["Amount"].ToString();
                        lblInstallment.Text = item["Installmet"].ToString();


                        //string flag = Request.Form[keys[13]].ToString();
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ReciptConfirm();", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ReciptConfirm();", true);
                        //Response.Redirect("~/Retailer/PaymentReceipt.aspx?id=" + DeptId + "", false);
                        string script = "printDiv('PrintDiv');";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "PrintDivScript", script, true);
                    }
                    else
                    {

                    }
                }

            }

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ReceiptHide();", true);
        }
    }
}