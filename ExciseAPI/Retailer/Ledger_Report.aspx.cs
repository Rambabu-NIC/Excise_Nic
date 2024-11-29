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
    public partial class Ledger_Report : BasePage
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
            if (Session["Role"] != null && (Session["Role"].ToString() == "1" || Session["Role"].ToString() == "50" || Session["Role"].ToString() == "52") && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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


                if (Session != null && !string.IsNullOrEmpty(Session["UsrName"].ToString()))
                {
                    //lblUSer.Text = Session["UsrName"].ToString();
                }

            }

        }
        public DataTable dt
        {
            get
            {
                return ViewState["dt"] as DataTable;
            }
            set
            {
                ViewState["dt"] = value;
            }

        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (string.IsNullOrEmpty(rblLedger.SelectedValue))
            {
                lblError.Text = "Please Select RadioButton";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
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

            try
            {
                divgriddetails.Visible = false;
                div1.Visible = false;
                div2.Visible = false;
                div3.Visible = false;
                divlp.Visible = false;
                btnDetailImageExportToPdf.Visible = false;
                btnDetailImageExportToExcel.Visible = false;
                btnBankImageExportToPdf.Visible = false;
                btnBankImageExportToExcel.Visible = false;
                btnDateImageExportToPdf.Visible = false;
                btnDateImageExportToExcel.Visible = false;
                btnDepotImageExportToPdf.Visible = false;
                btnDepotImageExportToExcel.Visible = false;
                btnLedgerImageExportToPdf.Visible = false;
                btnLedgerImageExportToExcel.Visible = false;
                //gvdetails.DataSource = "";
                //gvdetails.DataBind();
                //gvBank.DataSource = "";
                //gvBank.DataBind();
                //gvDate.DataSource = "";
                //gvDate.DataBind();
                //gvDepot.DataSource = "";
                //gvDepot.DataBind();
                //gvledgerpending.DataSource = "";
                //gvledgerpending.DataBind();
                objBE.Action = rblLedger.SelectedValue;
                objBE.FromDate = Convert.ToDateTime(txtFrom.Text.ToString().Trim());
                objBE.ToDate = Convert.ToDateTime(txtTo.Text.ToString().Trim());
                dt = objDL.GetLedger_WiseReport(objBE, ConnKey);
                if (dt.Rows.Count > 0 && rblLedger.SelectedValue == "0")
                {
                    gvdetails.DataSource = dt;
                    gvdetails.DataBind();
                    divgriddetails.Visible = true;
                    btnDetailImageExportToPdf.Visible = true;
                    btnDetailImageExportToExcel.Visible = true;
                    ViewState["FromDate"] = txtFrom.Text.ToString();
                    txtFrom.Text = string.Empty;
                    ViewState["ToDate"] = txtTo.Text.ToString();
                    txtTo.Text = string.Empty;
                }
                else if (dt.Rows.Count > 0 && rblLedger.SelectedValue == "1")
                {
                    gvBank.DataSource = dt;
                    gvBank.DataBind();
                    div1.Visible = true;
                    btnBankImageExportToPdf.Visible = true;
                    btnBankImageExportToExcel.Visible = true;
                    ViewState["FromDate"] = txtFrom.Text.ToString();
                    txtFrom.Text = string.Empty;
                    ViewState["ToDate"] = txtTo.Text.ToString();
                    txtTo.Text = string.Empty;

                }
                else if (dt.Rows.Count > 0 && rblLedger.SelectedValue == "2")
                {
                    gvDate.DataSource = dt;
                    gvDate.DataBind();
                    div2.Visible = true;
                    btnDateImageExportToPdf.Visible = true;
                    btnDateImageExportToExcel.Visible = true;
                    ViewState["FromDate"] = txtFrom.Text.ToString();
                    txtFrom.Text = string.Empty;
                    ViewState["ToDate"] = txtTo.Text.ToString();
                    txtTo.Text = string.Empty;
                }
                else if (dt.Rows.Count > 0 && rblLedger.SelectedValue == "3")
                {
                    gvDepot.DataSource = dt;
                    gvDepot.DataBind();
                    div3.Visible = true;
                    btnDepotImageExportToPdf.Visible = true;
                    btnDepotImageExportToExcel.Visible = true;
                    ViewState["FromDate"] = txtFrom.Text.ToString();
                    txtFrom.Text = string.Empty;
                    ViewState["ToDate"] = txtTo.Text.ToString();
                    txtTo.Text = string.Empty;
                }
                else if (dt.Rows.Count > 0 && rblLedger.SelectedValue == "4")
                {
                    gvledgerpending.DataSource = dt;
                    gvledgerpending.DataBind();
                    divlp.Visible = true;
                    btnLedgerImageExportToPdf.Visible = true;
                    btnLedgerImageExportToExcel.Visible = true;
                    ViewState["FromDate"] = txtFrom.Text.ToString();
                    txtFrom.Text = string.Empty;
                    ViewState["ToDate"] = txtTo.Text.ToString();
                    txtTo.Text = string.Empty;
                }
                else
                {
                    divgriddetails.Visible = false;
                    div1.Visible = false;
                    div2.Visible = false;
                    div3.Visible = false;
                    divlp.Visible = false;
                    objCommon.ShowAlertMessage("No Data Found");
                    lblError.Text = "No Data Found";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    txtFrom.Text = string.Empty;
                    txtTo.Text = string.Empty;
                    return;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }
        protected void btnDetailImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Details Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnDetailImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            string GenerateFileName = "Details Report" + ".xls";
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
        protected void btnBankImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divbankheading.Visible = true;
            GridView gridviewid = gvBank;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Bankwise Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = div1;
            lblBankFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblbankTo.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnBankImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divbankheading.Visible = true;
            string GenerateFileName = "Bankwise Report" + ".xls";
            GridView gridviewid = gvBank;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = div1;
            lblBankFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblbankTo.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
        protected void btnDateImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divDateheading.Visible = true;
            GridView gridviewid = gvDate;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Datewise Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = div2;
            lblReportFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblReportTo.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnDateImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divDateheading.Visible = true;
            string GenerateFileName = "Datewise Report" + ".xls";
            GridView gridviewid = gvDate;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = div2;
            lblReportFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblReportTo.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
        protected void btnDepotImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divDepotheading.Visible = true;
            GridView gridviewid = gvDepot;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "DepotWise Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = div3;
            lblDepotFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblDepotTo.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnDepotImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divDepotheading.Visible = true;
            string GenerateFileName = "DepotWise Report" + ".xls";
            GridView gridviewid = gvDepot;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = div3;
            lblDepotFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblDepotTo.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
        protected void btnLedgerImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divLedHeading.Visible = true;
            GridView gridviewid = gvledgerpending;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Ledger Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divlp;
            lblLedgerFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblLedgerTo.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnLedgerImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divLedHeading.Visible = true;
            string GenerateFileName = "Ledger Report" + ".xls";
            GridView gridviewid = gvledgerpending;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divlp;
            lblLedgerFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblLedgerTo.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }


        protected void gvdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvdetails.PageIndex = e.NewPageIndex;
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
        }

        protected void gvBank_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBank.PageIndex = e.NewPageIndex;
            gvBank.DataSource = dt;
            gvBank.DataBind();
        }

        protected void gvDate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDate.PageIndex = e.NewPageIndex;
            gvDate.DataSource = dt;
            gvDate.DataBind();
        }

        protected void gvDepot_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepot.PageIndex = e.NewPageIndex;
            gvDepot.DataSource = dt;
            gvDepot.DataBind();
        }

        protected void gvledgerpending_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvledgerpending.PageIndex = e.NewPageIndex;
            gvledgerpending.DataSource = dt;
            gvledgerpending.DataBind();
        }
    }
}