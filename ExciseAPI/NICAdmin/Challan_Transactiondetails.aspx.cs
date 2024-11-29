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

namespace ExciseAPI.NICAdmin
{
    public partial class Challan_Transactiondetails : BasePage
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

        protected void BtnGet_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt1 = new DataTable();
                if(string.IsNullOrEmpty(txtChallan.Text) && string.IsNullOrEmpty(txtTransaction.Text))
                {
                    lblError.Text = "Please Enter Challan No Or Transaction No";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                { 
                objBE.ChallanNumber = txtChallan.Text;
                objBE.DeptTransid = txtTransaction.Text;
                }
                dt1 = objDL.GetChallan_TransactionDetails(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    divgrid.Visible = true;
                    gvdetails.DataSource = dt1;
                    gvdetails.DataBind();
                    dt1.Dispose();
                    gvdetails.Visible = true;
                    btnChallanExportToPdf.Visible = true;
                    btnChallanImageExportToExcel.Visible = true;
                }
                else
                {
                    divgrid.Visible = false;
                    objCommon.ShowAlertMessage("No Data Found");
                }
            }



            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }

        protected void btnChallanExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Challan No Or Transaction Details Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }

        protected void btnChallanImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            string GenerateFileName = "Challan No Or Transaction Details Report" + ".xls";
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;

            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
    }
}