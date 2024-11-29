using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;
using System.Globalization;

namespace ExciseAPI.Admin
{
    public partial class EventPermitDashboard : BasePage
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
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
            if (Session["Role"] != null && (Session["Role"].ToString() == "53" || Session["Role"].ToString() == "54") && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                GetDashboardData();
            }
        }

        protected void GetDashboardData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objDL.GetDashboardData(ConnKey);
                if (dt.Rows.Count > 0)
                {

                    lblTodayCount.Text = dt.Rows[0]["TodayEvents"].ToString();
                    lblTodayAmount.Text = dt.Rows[0]["TodayEventsAmount"].ToString();
                    lblTotalCount.Text = dt.Rows[0]["TotalEvents"].ToString();
                    lblTotalAmount.Text = dt.Rows[0]["TotalAmounts"].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UserId"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");

            }
        }
        public DataTable DtEventsData
        {
            get
            {
                return ViewState["DtEventsData"] as DataTable;
            }
            set
            {
                ViewState["DtEventsData"] = value;
            }
        }

        protected void GetDetails_Click(object sender, EventArgs e)
        {
            btnDetailImageExportToPdf.Visible = false;
            btnDetailImageExportToExcel.Visible = false;
            divEventsData.Visible = false;
            divgriddetails.Visible = false;
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
                objBE.FromDate = Convert.ToDateTime(txtFrom.Text.ToString().Trim());
                objBE.ToDate = Convert.ToDateTime(txtTo.Text.ToString().Trim());
                DtEventsData = objDL.GetEvents_WiseReport(objBE, ConnKey);
                if (DtEventsData.Rows.Count > 0)
                {
                   
                    divEventsData.Visible = true;
                    divgriddetails.Visible = true;
                    btnDetailImageExportToPdf.Visible = true;
                    btnDetailImageExportToExcel.Visible = true;
                    ViewState["FromDate"] = txtFrom.Text.ToString();
                    txtFrom.Text = string.Empty;
                    ViewState["ToDate"] = txtTo.Text.ToString();
                    txtTo.Text = string.Empty;

                    gvdetails.DataSource = DtEventsData;
                    gvdetails.DataBind();

                }
                else
                {
                    txtFrom.Text = string.Empty;
                    txtTo.Text = string.Empty;
                    gvdetails.DataSource = "";
                    gvdetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UserId"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");

            }
        }
        protected void btnDetailImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Event Permits  Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnDetailImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            string GenerateFileName = "Event Permits Report" + ".xls";
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
    }
}