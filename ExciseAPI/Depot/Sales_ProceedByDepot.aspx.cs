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
    public partial class Sales_ProceedByDepot : BasePage
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
                BindData();
                DivGeneratedDate.Visible = false;
            }

        }

        protected void BindData()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Role = Convert.ToInt16(Session["Role"].ToString());
                objBE.DepotName= Session["UsrName"].ToString().Trim();
                dt = objDL.GetDepot_Codes(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlDepot.DataSource = dt;
                    ddlDepot.DataTextField = "DepotName";
                    ddlDepot.DataValueField = "DeptCode";
                    ddlDepot.DataBind();
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
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
        protected void Viewdata()
        {
            try
            {
                DataTable dt = new DataTable();
                objBE.DepotName = Session["UsrName"].ToString().Trim();
                objBE.from = txtFrom.Text;
                objBE.To = txtTo.Text;
                dt = objDL.SalesProceedByDepot(objBE, ConnKey);
                
                    if (dt.Rows.Count > 0)
                    {
                        divretailer.Visible = true;
                        gvSalesProceed.Visible = true;
                        gvSalesProceed.DataSource = dt;
                        gvSalesProceed.DataBind();
                        DivGeneratedDate.Visible = true;
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("No Data Found");
                        gvSalesProceed.Visible = false;
                        divretailer.Visible = false;
                    }
               


            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void btnSalesProceedExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            GridView gridviewid = gvSalesProceed;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Retailer Sales Proceeds Report" + ".Pdf";
            divheading.Visible = true;
            DivGeneratedDate.Visible = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divretailer;
            //lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            //lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }

        protected void btnSalesProceedExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            DivGeneratedDate.Visible = false;
            string GenerateFileName = "Retailer Sales Proceeds Report" + ".xls";
            GridView gridviewid = gvSalesProceed;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divretailer;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }

        protected void btn_Get_Click(object sender, EventArgs e)
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
            if (!string.IsNullOrEmpty(txtFrom.Text) && !string.IsNullOrEmpty(txtTo.Text))
            {
                Viewdata();
            }
            else
            {
                lblError.Text = "No Data Found";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
    }
}