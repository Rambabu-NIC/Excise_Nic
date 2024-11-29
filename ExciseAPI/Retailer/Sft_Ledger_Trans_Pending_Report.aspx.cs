using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Retailer
{
    public partial class Sft_Ledger_Trans_Pending_Report : BasePage
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
            if (string.IsNullOrEmpty(rblPending.SelectedValue))
            {
                lblError.Text = "Please Select RadioButton";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(rblPending1.SelectedValue))
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
                divlp.Visible = false;
                btnPendingImageExportToExcel.Visible = false;
                btnPendingImageExportToPdf.Visible = false;
                objBE.PendingAction = rblPending.SelectedValue;
                objBE.PendingAction1 = rblPending1.SelectedValue;
                objBE.FromDate = Convert.ToDateTime(txtFrom.Text.ToString().Trim());
                objBE.ToDate = Convert.ToDateTime(txtTo.Text.ToString().Trim());
                dt = objDL.GetLedgerVsSFTVSTransReport(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    gvledgervsSFTvsTrans.DataSource = dt;
                    gvledgervsSFTvsTrans.DataBind();
                    divlp.Visible = true;
                    DivGeneratedDate.Visible = true;
                    btnPendingImageExportToExcel.Visible = true;
                    btnPendingImageExportToPdf.Visible = true;
                    ViewState["FromDate"] = txtFrom.Text.ToString();
                    txtFrom.Text = string.Empty;
                    ViewState["ToDate"] = txtTo.Text.ToString();
                    txtTo.Text = string.Empty;
                }

                else
                {
                    txtFrom.Text = string.Empty;
                    txtTo.Text = string.Empty;
                    divlp.Visible = false;
                    objCommon.ShowAlertMessage("No Data Found");
                    lblError.Text = "No Data Found";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }

        protected void gvledgervsSFTvsTrans_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
            }
        }

        protected void btnPendingImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            GridView gridviewid = gvledgervsSFTvsTrans;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Pending Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divlp;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnPendingImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            string GenerateFileName = "Pending Report" + ".xls";
            GridView gridviewid = gvledgervsSFTvsTrans;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divlp;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }

        protected void gvledgervsSFTvsTrans_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvledgervsSFTvsTrans.PageIndex = e.NewPageIndex;
            gvledgervsSFTvsTrans.DataSource = dt;
            gvledgervsSFTvsTrans.DataBind();
        }
    }
}