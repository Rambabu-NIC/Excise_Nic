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

namespace ExciseAPI.NICAdmin
{
    public partial class Supplier_Payments_StateWise : BasePage
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

                BindManufactory();
                BindExciseDistrict();


            }

        }
        public void BindManufactory()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Action = "R";
                dt1 = objDL.ManufacoryMasters(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists_WithAll_0_Option_Last(ddlManf, dt1, "Type_Man_Nm", "Type_Man_Cd", "99");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        protected void BindExciseDistrict()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Action = "ExDist";

                //objBE.MandCode = ddlExMnd.SelectedValue;
                dt = objDL.GetEventDetailsBySHO(objBE, ConnKey);

                if (dt.Rows.Count > 0)
                {
                    objCommon.BindDropDownLists_WithAll_0_Option_Last(ddlExDist, dt, "ExDist", "ExDist_Cd", "99");

                    //objCommon.BindDropDownLists(ddlExDist, dt, "ExDist", "ExDist_Cd", "0");
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btnManufacturerWiseImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            GridView gridviewid = gvManf;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Supplier State Wise Payments Report" + ".Pdf";
            divheading.Visible = true;
            //DivGeneratedDate.Visible = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgrid;
            //lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            //lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }

        protected void btnManufacturerWiseImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            //DivGeneratedDate.Visible = false;
            string GenerateFileName = "Supplier State Wise Payments Report" + ".xls";
            GridView gridviewid = gvManf;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgrid;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }

        protected void BtnGet_Click(object sender, EventArgs e)
        {
            if (ddlManf.SelectedValue.ToString() == "")
            {
                lblError.Text = "Please Select Manufacturer";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlExDist.SelectedValue.ToString() == "")
            {
                lblError.Text = "Please Select Excise District";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            BindData();
        }


        protected void BindData()
        {
            try
            {

                DataTable dt = new DataTable();
                
                    objBE.Type_of_Manu = ddlManf.SelectedValue;
                    objBE.DistCode = ddlExDist.SelectedValue;
                
                
                dt = objDL.Supplier_Payments_StateWise(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    divgrid.Visible = true;
                    //GvRptDtls.Visible = true;
                    gvManf.DataSource = dt;
                    gvManf.DataBind();

                    dt.Dispose();
                    divgriddetails.Visible = true;
                    btnManufacturerWiseImageExportToExcel.Visible = true;
                    btnManufacturerWiseImageExportToPdf.Visible = true;
                    lblError.Visible = false;
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
                //objCommon.ShowAlertMessage(ex.ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        
    }
}