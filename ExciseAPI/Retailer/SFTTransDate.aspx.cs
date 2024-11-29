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

namespace ExciseAPI.Retailer
{
    public partial class SFTTransDate : BasePage
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
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "50" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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

        protected void BindData()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.from = txtFrom.Text.ToString();
                objBE.To = txtTo.Text.ToString();
                dt = objDL.Get_RetailerBankscrollDate(objBE, ConnKey);
                if (dt.Rows.Count > 0)

                   {
                    ViewState["FromDate"] = txtFrom.Text.ToString();
                    txtFrom.Text = string.Empty;
                    ViewState["ToDate"] = txtTo.Text.ToString();
                    txtTo.Text = string.Empty;
                    divretailer.Visible = true;
                    gvRetailerBankwise.Visible = true;
                    gvRetailerBankwise.DataSource = dt;
                    gvRetailerBankwise.DataBind();
                    dt.Dispose();

                }

                else
               {
                   
                    divretailer.Visible = false;
                    gvRetailerBankwise.Visible = true;
                    objCommon.ShowAlertMessage("No Data Found");
                    txtFrom.Text = "";
                    txtTo.Text = "";
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btn_Get_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFrom.Text))
            {
                lblError.Text = "Please Select From Date";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(txtTo.Text))
            {
                lblError.Text = "Please Select To Date";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            BindData();
        }

        public DataTable dtTransaction
        {
            get
            {
                return ViewState["dtTransaction"] as DataTable;
            }
            set
            {
                ViewState["dtTransaction"] = value;
            }
        }

        protected void gvRetailerBankwise_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Transaction")
                {
                    
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string BankName = commandArgs[0];
                    string FromDate = commandArgs[1];
                    string ToDate = commandArgs[2];
                    Response.Redirect("~/Retailer/SFT_BankName.aspx?FromDate=" + Encrypt(FromDate) + "&ToDate=" + Encrypt(ToDate) + "&Bankname=" + Encrypt(BankName), false);
                   

                }


            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btnTransactionImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divBankChallanReport.Visible = true;
            GridView gridviewid = gvRetailerBankwise;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Sft Transaction Wise Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divretailer;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }

        protected void btnTransactionImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divBankChallanReport.Visible = true;
            string GenerateFileName = "Sft Transaction Wise Report" + ".xls";
            GridView gridviewid = gvRetailerBankwise;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divretailer;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
    }
}