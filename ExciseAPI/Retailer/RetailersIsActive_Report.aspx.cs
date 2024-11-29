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
    public partial class RetailersIsActive_Report : BasePage
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
                //BindData();
            }
        }

        protected void BtnGet_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlRetailer.SelectedValue.ToString() == "0")
                {
                    lblError.Text = "Please Select Retailer";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                objBE = new Supplier_BE();
                DataTable dt1 = new DataTable();
                if(ddlRetailer.SelectedValue=="1")
                {
                    objBE.IsActive = 1;
                }
                else
                {
                    objBE.IsActive = 0;
                }

                dt1 = objDL.RetailersActiveInActiveList(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    gvdetails.Visible = true;
                    gvdetails.DataSource = dt1;
                    gvdetails.DataBind();
                    divgrid.Visible = true;
                    divgriddetails.Visible = true;
                    btnRetailerActiveInActiveImageExportToExcel.Visible = true;
                    btnRetailerActiveInActiveImageExportToPdf.Visible = true;
                }
                else
                {
                    divgriddetails.Visible = false;
                    gvdetails.Visible = false;
                    objCommon.ShowAlertMessage("No Data Found");
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }

        protected void btnRetailerActiveInActiveImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Retailer Active InActive Report" + ".Pdf";
            divheading.Visible = true;
           
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgrid;
           
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }

        protected void btnRetailerActiveInActiveImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            
            string GenerateFileName = "Retailer Active InActive Report" + ".xls";
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgrid;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
    }
}