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
    public partial class AvailableRetailers : BasePage
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
                BindData();
            }
        }
        protected void BindData()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                dt = objDL.GetRetailersDepotCode(ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlDepot.DataSource = dt;
                    ddlDepot.DataTextField = "DepotName";
                    ddlDepot.DataValueField = "DeptCode";
                    ddlDepot.DataBind();
                    ddlDepot.Items.Insert(0, new ListItem("ALL", "99"));
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    dt.Dispose();
                }
                else
                {
                    //GvRpt.Visible = false;
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
            if (string.IsNullOrEmpty(RblRetailers.SelectedValue))
            {
                lblError.Text = "Please Select RadioButton";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlDepot.SelectedValue.ToString() == "0")
            {
                lblError.Text = "Please Select RadioButton";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlStatus.SelectedValue == "0")
            {
                lblError.Text = "Please Select Status";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            try
            {
                divgriddetails.Visible = false;
                btnAvailableImageExportToPdf.Visible = false;
                btnAvailableImageExportToExcel.Visible = false;
                objBE.UnitCode = ddlDepot.SelectedValue;
                objBE.Status = ddlStatus.SelectedValue;
                objBE.RetailerType = RblRetailers.SelectedValue;
                dt = objDL.GetRetailerDetails_Report(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    divgrid.Visible = true;
                    DivGeneratedDate.Visible = true;
                    divgriddetails.Visible = true;
                    btnAvailableImageExportToPdf.Visible = true;
                    btnAvailableImageExportToExcel.Visible = true;
                    gvdetails.DataSource = dt;
                    gvdetails.DataBind();

                }
                else
                {
                    divgrid.Visible = false;
                    DivGeneratedDate.Visible = false;
                    divgriddetails.Visible = false;
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
        protected void btnAvailableImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            lblHeaderDate.Text = DateTime.Now.ToString();
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Availabale Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            //lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            //lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnAvailableImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            lblHeaderDate.Text = DateTime.Now.ToString();
            string GenerateFileName = "Available Report" + ".xls";
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
    }
}