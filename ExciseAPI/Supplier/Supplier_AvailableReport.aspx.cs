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

namespace ExciseAPI.Supplier
{
    public partial class Supplier_AvailableReport : BasePage
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
            if (Session["Role"] != null && Session["Role"].ToString() == "50" || Session["Role"] != null && Session["Role"].ToString() == "3" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                if (Session["Role"].ToString() == "50")
                { 

                BindManufactory();
                    

                }
                else
                {
                    ddlManf.Visible = false;
                    BtnGet.Visible = false;
                    BindData();
                    
                }
            }
        }
        public void BindManufactory()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Action = "R";
                dt1 = objDL.ManufacoryMasters(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlManf, dt1, "Type_Man_Nm", "Type_Man_Cd", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        public void BindDuty()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Type_of_Manu = ddlManf.SelectedValue;
                objBE.Action = "MH";
                dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlMinor, dt1, "Minor_Head_Desc", "Minor_Head_Code", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindSubHead()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Type_of_Manu = ddlManf.SelectedValue;
                objBE.MinorHead = ddlMinor.SelectedValue;
                objBE.Action = "SH";
                dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlSubHead, dt1, "Sub_Head_Desc", "Sub_Head_Code", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindTypeofpayment()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Type_of_Manu = ddlManf.SelectedValue;
                objBE.MinorHead = ddlMinor.SelectedValue;
                objBE.SubHead = ddlSubHead.SelectedValue;
                objBE.Action = "R1";
                dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlPayment, dt1, "DF_Descr", "DF_Code", "0");
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
            string GenerateFileName = "Supplier Manufacturer Wise Report" + ".Pdf";
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
            string GenerateFileName = "Supplier Manufacturer Wise Report" + ".xls";
            GridView gridviewid = gvManf;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgrid;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }

        protected void BindData()
        {
            try
            {

                DataTable dt = new DataTable();
                if (Session["Role"].ToString() == "50")
                {
                    objBE.ManufCd = ddlManf.SelectedValue;
                    objBE.Supplier_Code = null;
                    objBE.MinorHead = ddlMinor.SelectedValue;
                    objBE.SubHead = ddlSubHead.SelectedValue;
                    objBE.DFCode = ddlPayment.SelectedValue;
                }
                else
                {
                    objBE.Supplier_Code = Session["UsrName"].ToString();
                    objBE.ManufCd = null;
                }
                objBE.Role = Convert.ToInt16(Session["Role"].ToString());
                dt = objDL.ManufacturerDetails_new(objBE, ConnKey);
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
        protected void BtnGet_Click(object sender, EventArgs e)
        {
            if (ddlManf.SelectedValue.ToString() == "")
            {
                lblError.Text = "Please Select Manufacturer";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            BindData();
        }

        protected void ddlMinor_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubHead();
        }

        protected void ddlSubHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTypeofpayment();
        }

        protected void ddlManf_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDuty();
        }

        
    }
}