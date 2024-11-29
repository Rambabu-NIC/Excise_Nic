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
    public partial class ExistingRetailerReport : BasePage
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
            if (Session["Role"] != null && (Session["Role"].ToString() == "50" || Session["Role"].ToString() == "52" || Session["Role"].ToString() == "51" || Session["Role"].ToString() == "4") || Session["Role"] != null   && Request.Cookies["AuthToken"] != null)
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

                //BindInstallmentNo();
                BindRetailerType();
                BindExDistrict();
                divdist.Visible = true;
                if (Session["Role"].ToString() == "4")
                {
                    divdist.Visible = false;
                } 
            }
        }


        public void BindExDistrict()
        {
            try
            {

                objBE.Statecode = "36";
                DataTable dt1 = new DataTable();
                objBE.Action = "ED";
                dt1 = ObjMDL.CommonMasters(objBE, ConnKey);
                objCommon.BindDropDownLists_WithAll_0_Option_Last(ddlExDistrict, dt1, "EXDist", "ExDist_Cd", "99");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindRetailerType()
        {
            try
            {

                DataTable dt1 = new DataTable();
                //objBE.Type_of_Manu = Session["Type_Retailer"].ToString();
                dt1 = objDL.GetRetailerType(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlRType, dt1, "Retailer_Type_Description", "Retailer_Type_Code", "0");
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindData()
        {
            try
            {
                DivGeneratedDate.Visible = false;
                DataTable dt = new DataTable();
                objBE.RetailerType = ddlRType.SelectedValue;
                if (Session["Role"].ToString() == "4")
                {
                    objBE.ExDist = Session["ExDist_Cd"].ToString();
                }
                else
                {
                    objBE.ExDist = ddlExDistrict.SelectedValue;
                }
                //dt1 = objDL.GetDistrictWiseRetailer(objBE, ConnKey);
                dt = objDL.GetExsitingRetailers(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    DivGeneratedDate.Visible = true;
                    divRetailerIndividual.Visible = true;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    dt.Dispose();
                }
                else
                {
                    divRetailerIndividual.Visible = false;                  
                    objCommon.ShowAlertMessage("No Data Found");

                }           
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        protected void BtnGet_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (ddlRType.SelectedValue !="0" && ddlExDistrict.SelectedValue !="0")
            {
                BindData();
            }
            else
            {
                lblError.Text = "Please select RetailerType OR Excise District....";
                return;
            }

        }

        protected void ddlRType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindInstallmentNo();
        }

        protected void btnAvailableImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            GridView gridviewid = GridView1;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Existing Retailer Report" + ".Pdf";
            divheading.Visible = true;
            DivGeneratedDate.Visible = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divRetailerIndividual;
            //lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            //lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnAvailableImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            DivGeneratedDate.Visible = false;
            string GenerateFileName = "Existing Retailer Report" + ".xls";
            GridView gridviewid = GridView1;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divRetailerIndividual;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Assuming the mobile number is in the first cell (index 0)
                string mobileNumber = e.Row.Cells[7].Text;

                if (!string.IsNullOrEmpty(mobileNumber) && mobileNumber.Length >= 10)
                {
                    // Mask all but last 4 digits
                    e.Row.Cells[7].Text = "****-****-" + mobileNumber.Substring(mobileNumber.Length - 4);
                }
            }
        }
    }
}