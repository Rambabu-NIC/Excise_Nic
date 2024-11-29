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
    public partial class Financial_Year_Event_PermitsReport : BasePage
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
            if (!IsPostBack)
            {

            }

            }

        public void BindData()
        {
            try
            {
                if (ddlFyid.SelectedValue.ToString() == "0")
                {
                    lblError.Text = "Please Select Year";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (ddlFyid.SelectedValue == "1")
                {
                    objBE.StartYear = "2021";
                    objBE.EndYear = "2022";
                }
                if (ddlFyid.SelectedValue == "2")
                {
                    objBE.StartYear = "2022";
                    objBE.EndYear = "2023";
                }
                if (ddlFyid.SelectedValue == "3")
                {
                    objBE.StartYear = "2023";
                    objBE.EndYear = "2024";
                }
                DataTable dt1 = new DataTable();
                
                divgrid.Visible = false;
                DivGeneratedDate.Visible = false;

                dt1 = objDL.GETEventPermitYearWise_New(objBE, ConnKey);

                if (dt1.Rows.Count > 0)
                {
                    divgrid.Visible = true;
                    DivGeneratedDate.Visible = true;
                    btnEventPermitExportToPdf.Visible = true;
                    btnEventPermitExportToExcel.Visible = true;
                    gvdetails.DataSource = dt1;
                    gvdetails.DataBind();
                    dt1.Dispose();
                }
                else
                {
                    divgrid.Visible = false;
                    DivGeneratedDate.Visible = false;
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
            BindData();
        }

        protected void btnEventPermitExportToPdf_Click(object sender, ImageClickEventArgs e)
        {

            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Event Permits Year Wise Report" + ".Pdf";
            divheading.Visible = true;
            DivGeneratedDate.Visible = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgrid;
            //lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            //lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }

        protected void btnEventPermitExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            DivGeneratedDate.Visible = false;
            string GenerateFileName = "Event Permits Year Wise Report" + ".xls";
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgrid;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
    }
}