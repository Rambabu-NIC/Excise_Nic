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
    public partial class RetailerReport_Individual : BasePage
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
            if (Session["Role"] != null && (Session["Role"].ToString() == "50" || Session["Role"] != null && Session["Role"].ToString() == "51" || Session["Role"].ToString() == "4") || Session["Role"] != null   && Request.Cookies["AuthToken"] != null)
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
                BindRevDistrict();
                divdist.Visible = true;
                if (Session["Role"].ToString() == "4")
                {
                    divdist.Visible = false;
                } 
            }
        }


        public void BindRevDistrict()
        {
            try
            {

                objBE.Statecode = "36";
                DataTable dt1 = new DataTable();
                objBE.Action = "ExDist";
                dt1 = ObjMDL.CommonMasters(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlExDistrict, dt1, "ExDist_Name", "ExDist_Cd", "0");
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
                objBE.from = txtFrom.Text.ToString();
                objBE.To = txtTo.Text.ToString();
                if(RSP.Checked==true)
                {
                    objBE.TypePayment = "2";
                }
                else
                {
                    objBE.TypePayment = "0";
                }
                if (Session["Role"].ToString() == "4")
                {
                    objBE.ExDist = Session["ExDist_Cd"].ToString();
                }
                else
                {
                    objBE.ExDist = ddlExDistrict.SelectedValue;
                }
                //dt1 = objDL.GetDistrictWiseRetailer(objBE, ConnKey);
                dt = objDL.GetDistrictWiseRetailerReport(objBE, ConnKey);
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
                    txtFrom.Text = "";
                    txtTo.Text = "";
                    //ddlInstallment. ="0";
                    objCommon.ShowAlertMessage("No Data Found");

                }
                //if (dt1.Rows.Count > 0)
                //{
                //    divgrid.Visible = true;
                //    gvdetails.DataSource = dt1;
                //    gvdetails.DataBind();
                //    dt1.Dispose();
                //}
                //else
                //{
                //    divgrid.Visible = false;
                //    txtFrom.Text = "";
                //    txtTo.Text = "";
                //    //ddlInstallment. ="0";
                //    objCommon.ShowAlertMessage("No Data Found");

                //}
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
            if (!string.IsNullOrEmpty(txtFrom.Text) && !string.IsNullOrEmpty(txtTo.Text))
            {
                BindData();
            }
            else
            {
                lblError.Text = "Please select dates....";
                return;
            }

        }

        //protected void btnRetailerImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        //{
        //    divheading.Visible = true;

        //    string GenerateFileName = "CPE Payments Report" + ".xls";
        //    GridView gridviewid = gvdetails;
        //    gridviewid.AllowPaging = true;
        //    System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
        //    lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
        //    lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
        //    ExportGridToExcelWithLabel(GenerateFileName, div);
        //}

        protected void ddlRType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindInstallmentNo();
        }

        protected void gvdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                DataTable dt = new DataTable();
                objBE.RetailerType = ddlRType.SelectedValue;
                objBE.from = txtFrom.Text.ToString();
                objBE.To = txtTo.Text.ToString();
                objBE.ExDist = ddlExDistrict.SelectedValue;
                dt = objDL.GetDistrictWiseRetailerReport(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    divRetailerIndividual.Visible = true;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    dt.Dispose();
                }
                else
                {
                    divRetailerIndividual.Visible = false;
                    txtFrom.Text = "";
                    txtTo.Text = "";
                    //ddlInstallment. ="0";
                    objCommon.ShowAlertMessage("No Data Found");

                }
            }
            else
            {

            }
        }
        protected void btnAvailableImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            GridView gridviewid = GridView1;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Retailer Individual Installment Report" + ".Pdf";
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
            string GenerateFileName = "Retailer Individual Installment Report" + ".xls";
            GridView gridviewid = GridView1;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divRetailerIndividual;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }

    }
}