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

namespace ExciseAPI.Depot
{
    public partial class SalesProceedReport : BasePage
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
            if (Session["Role"] != null && (Session["Role"].ToString() == "13" || Session["Role"].ToString() == "1" || Session["Role"].ToString() == "9" || Session["Role"].ToString() == "50" || Session["Role"].ToString() == "52") && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                if (Session["Role"].ToString() == "13")
                {
                    DivGeneratedDate.Visible = false;
                    depot.Visible = false;
                }
                   else
                {
                    DivGeneratedDate.Visible = false;
                    BindData();
                    depot.Visible = true;
                }
            }

        }
        public DataTable RetailerSalesProceeddt
        {
            get
            {
                return ViewState["RetailerSalesProceeddt"] as DataTable;
            }
            set
            {
                ViewState["RetailerSalesProceeddt"] = value;
            }
        }
        protected void Viewdata()
        {
            try
            {
                if (Session["Role"].ToString() == "13")
                {
                    objBE.DDoCode = Session["salesproceedDepotcode"].ToString();
                    objBE.DepotName = Session["UsrName"].ToString();
                }
                else
                {
                    objBE.DDoCode = null;
                    objBE.DepotName = ddlDepot.SelectedValue;
                }
                objBE.Role = Convert.ToInt16(Session["Role"].ToString());
                objBE.from = txtFrom.Text;
                objBE.To = txtTo.Text;


                RetailerSalesProceeddt = objDL.GetSalesProceedsByDepotCode(objBE, ConnKey);
                if (RetailerSalesProceeddt.Columns.Count == 1)
                {
                    objCommon.ShowAlertMessage(RetailerSalesProceeddt.Rows[0][0].ToString());
                    return;
                }
                else
                {
                    if (RetailerSalesProceeddt.Rows.Count > 0)
                    {
                        divretailer.Visible = true;
                        gvRetailerdetails.Visible = true;
                        gvRetailerdetails.DataSource = RetailerSalesProceeddt;
                        gvRetailerdetails.DataBind();
                        DivGeneratedDate.Visible = true;
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("No Data Found");
                        gvRetailerdetails.Visible = false;
                        divretailer.Visible = false;
                    }
                }


            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void BindData()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                //objBE.Role = Convert.ToInt16(Session["Role"].ToString());
                //objBE.DeptCode = Session["UsrName"].ToString().Trim();
                dt = objDL.GetDepot(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlDepot.DataSource = dt;
                    ddlDepot.DataTextField = "DepotName";
                    ddlDepot.DataValueField = "DeptCode";
                    ddlDepot.DataBind();
                    ddlDepot.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlDepot.Items.Insert(1, new ListItem("ALL", "99"));
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
        protected void btn_Get_Click(object sender, EventArgs e)
        {
            if (Session["Role"].ToString() == "13")
            {
                if (string.IsNullOrEmpty(txtFrom.Text))
                {
                    lblError.Text = "Please Enter From Date";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtTo.Text))
                {
                    lblError.Text = "Please Enter To Date";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else {
                if (string.IsNullOrEmpty(txtFrom.Text))
                {
                    lblError.Text = "Please Enter From Date";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtTo.Text))
                {
                    lblError.Text = "Please Enter To Date";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (ddlDepot.SelectedValue == "0")
                {
                    lblError.Text = "Please Select Depot";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            Viewdata();
            //if (!string.IsNullOrEmpty(txtFrom.Text) && !string.IsNullOrEmpty(txtTo.Text) && !string.IsNullOrEmpty(ddlDepot.SelectedValue))
            //{
            //    Viewdata();
            //}
            //else
            //{
            //    lblError.Text = "Please Select/Enter all details..";
            //    lblError.ForeColor = System.Drawing.Color.Red;
            //    return;
            //}
        
        }

        protected void btnAvailableImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            GridView gridviewid = gvRetailerdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Retailer Sales Proceeds Report" + ".Pdf";
            divheading.Visible = true;
            DivGeneratedDate.Visible = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divretailer;
            //lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            //lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnAvailableImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            DivGeneratedDate.Visible = false;
            string GenerateFileName = "Retailer Sales Proceeds Report" + ".xls";
            GridView gridviewid = gvRetailerdetails;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divretailer;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }

        
    }
}