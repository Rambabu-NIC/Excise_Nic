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
    public partial class RetailerWiseReport : BasePage
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
                //lblUSer.Text = Session["UsrName"].ToString();
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
                    ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    dt.Dispose();
                }
                else
                {
                    //GvRpt.Visible = false;
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
            DataTable dt = new DataTable();
            dt = null;
            try
            {
                divgriddetails.Visible = false;
                btnRetailerImageExportToExcel.Visible = false;
                btnRetailerImageExportToPdf.Visible = false;

                lblError.Text = "";
                if (string.IsNullOrEmpty(ddlDepot.SelectedValue))
                {
                    lblError.Text = "Please Select Depot";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(ddlRetailer.SelectedValue))
                {
                    lblError.Text = "Please Select Retailer";
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


                objBE.UnitCode = ddlDepot.SelectedValue;
                objBE.RetailerCode = ddlRetailer.SelectedItem.Text;
                objBE.FromDate = Convert.ToDateTime(txtFrom.Text.ToString().Trim());
                objBE.ToDate = Convert.ToDateTime(txtTo.Text.ToString().Trim());


                dt = objDL.GetRetailer_WiseReport(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    divgrid.Visible = true;
                    DivGeneratedDate.Visible = true;
                    divgriddetails.Visible = true;
                    gvdetails.DataSource = dt;
                    gvdetails.DataBind();
                    divgriddetails.Visible = true;
                    btnRetailerImageExportToExcel.Visible = true;
                    btnRetailerImageExportToPdf.Visible = true;
                    ViewState["FromDate"] = txtFrom.Text.ToString();
                    txtFrom.Text = string.Empty;
                    ViewState["ToDate"] = txtTo.Text.ToString();
                    txtTo.Text = string.Empty;
                }
                else
                {
                    txtFrom.Text = string.Empty;
                    txtTo.Text = string.Empty;
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
        protected void btnRetailerImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Retailerwise Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnRetailerImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            string GenerateFileName = "RetailerWise Report" + ".xls";
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
        protected void BindRetailersData(string unitcode)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.UnitCode = unitcode;
                dt = objDL.GETRetailersByunitCode(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlRetailer.DataSource = dt;
                    ddlRetailer.DataTextField = "Retailer_Code";
                    ddlRetailer.DataValueField = "Retailer_Code";
                    ddlRetailer.DataBind();
                    ddlRetailer.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    dt.Dispose();
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");
                    lblError.Text = "No Data Found";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                    //GvRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void ddlDepot_SelectedIndexChanged(object sender, EventArgs e)
        {
            string unitcode = ddlDepot.SelectedValue;
            BindRetailersData(unitcode);
        }

    }
}