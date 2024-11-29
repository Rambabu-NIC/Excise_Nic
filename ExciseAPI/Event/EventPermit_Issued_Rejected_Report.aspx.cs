using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Event
{
    public partial class EventPermit_Issued_Rejected_Report : BasePage
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*KILL COOKIE & clear Caching*/
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
                //  Response.Redirect("~/Error.aspx");
            }
            if (!IsPostBack)
            {

                BindExciseDistrict();

            }
        }
        
        public void BindExciseDistrict()
        {
            try
            {

                objBE.Statecode = "36";
                DataTable dt1 = new DataTable();
                dt1 = ObjMDL.GetExDistricts(objBE, ConnKey);
                objCommon.BindDropDownLists_WithAll_0_Option_Last(ddlExDistrict, dt1, "ExDist", "ExDist_Cd", "99");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void BindData()
        {
            lblError.Text = "";
            if (string.IsNullOrEmpty(txtfrm.Text))
            {
                lblError.Text = "Please Select From Date";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(txtto.Text))
            {
                lblError.Text = "Please Select To Date";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
           
            if (ddlExDistrict.SelectedValue.ToString() == "")
            {
                lblError.Text = "Please Select Excise District";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlStatus.SelectedValue.ToString() == "0")
            {
                lblError.Text = "Please Select Status";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                objBE.ExDistCode = ddlExDistrict.SelectedValue;
                objBE.from = txtfrm.Text;
                objBE.To = txtto.Text;
                objBE.Status = ddlStatus.SelectedValue;
                dt = objDL.GetEventPermits_Approve_Rejected(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                  
                    divgriddetails.Visible = true;
                    divgrid.Visible = true;
                    btnEventImageExportToPdf.Visible = true;
                    btnEventWiseImageExportToExcel.Visible = true;
                      
                    gvdetails.Visible = true;
                    gvdetails.DataSource = dt;
                    gvdetails.DataBind();
                    dt.Dispose();
                    ViewState["FromDate"] = txtfrm.Text.ToString();
                    txtfrm.Text = string.Empty;
                    ViewState["ToDate"] = txtto.Text.ToString();
                    txtto.Text = string.Empty;
                    //lblPaymentDetailsNo.Visible = false;
                    //dltPaymentDetails.Visible = false;
                    ddlExDistrict.SelectedValue = "";
                    ddlStatus.SelectedValue = "0";
                    lblError.Visible = false;
                }
                else
                {
                    lblError.Visible = false;
                    divgriddetails.Visible = false;
                    divgrid.Visible = false;
                    btnEventImageExportToPdf.Visible = false;
                    btnEventWiseImageExportToExcel.Visible = false;
                    txtfrm.Text = "";
                    txtto.Text = "";
                    ddlExDistrict.SelectedValue = "";
                    ddlStatus.SelectedValue = "0";
                    gvdetails.Visible = false;
                    objCommon.ShowAlertMessage("No Data Found");
                    return;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnEventImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Event permits Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);

        }

        protected void btnEventWiseImageExportToExcel_Click(object sender, ImageClickEventArgs e)
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