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
    public partial class RetailersReport : BasePage 
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
            if (Session["Role"] != null && Session["Role"].ToString() == "50" || Session["Role"] != null && Session["Role"].ToString() == "4" || Session["Role"] != null && Session["Role"].ToString() == "51" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                divheading.Visible = false;
                divheading1.Visible = false;
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

                DataTable dt1 = new DataTable();
                objBE.RetailerType = ddlRType.SelectedValue;
                //objBE.from = txtFrom.Text.ToString();
                //objBE.To = txtTo.Text.ToString();
                if(Session["Role"].ToString() == "4")
                {
                    objBE.ExDist = Session["ExDist_Cd"].ToString();
                }
                if (RSP.Checked == true)
                {
                    divgrid.Visible = false;
                    DivGeneratedDate.Visible = false;
                    DivGenerated2.Visible = false;
                    dt1 = objDL.GetDistrict_Slab_WiseRetailer_tax_Special(objBE, ConnKey);

                    if (dt1.Rows.Count > 0)
                    {
                        divgridSpec.Visible = true;
                        DivGeneratedDate.Visible = true;
                        DivGenerated2.Visible = true;
                        gvdetails_spec.DataSource = dt1;
                        gvdetails_spec.DataBind();
                        dt1.Dispose();
                    }
                    else
                    {
                        divgridSpec.Visible = false;
                        //txtFrom.Text = "";
                        //txtTo.Text = "";
                        //ddlInstallment. ="0";
                        objCommon.ShowAlertMessage("No Data Found");

                    }
                }
                else
                {
                    DivGenerated2.Visible = false;
                    DivGeneratedDate.Visible = false;
                    divgridSpec.Visible = false;
                    dt1 = objDL.GetDistrict_Slab_WiseRetailer_tax(objBE, ConnKey);

                    if (dt1.Rows.Count > 0)
                    {
                        divgrid.Visible = true;
                        DivGenerated2.Visible = true;
                        DivGeneratedDate.Visible = true;
                        gvdetails.DataSource = dt1;
                        gvdetails.DataBind();
                        dt1.Dispose();
                    }
                    else
                    {
                        divgrid.Visible = false;
                        //txtFrom.Text = "";
                        //txtTo.Text = "";
                        //ddlInstallment. ="0";
                        objCommon.ShowAlertMessage("No Data Found");

                    }

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
           // if (!string.IsNullOrEmpty(txtFrom.Text) && !string.IsNullOrEmpty(txtTo.Text))
           if(ddlRType.SelectedIndex>0)
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

            divgrid.Visible = false;
            divgridSpec.Visible = false;
            RSP.Checked = false;
            





        }

        protected void gvdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                DataTable dt = new DataTable();
                objBE.RetailerType = ddlRType.SelectedValue;

                GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                String DDOCODE = ((Label)(gRow.FindControl("DDOCode"))).Text; ;
                String SlabNo= ((Label)(gRow.FindControl("SlabNo"))).Text;
                String TypeofPayment = ((Label)(gRow.FindControl("Sub_Head"))).Text;
                String Installment_No = ((Label)(gRow.FindControl("Installment_No"))).Text;

                objBE.DDoCode = DDOCODE;
                objBE.SubHead = TypeofPayment;
                objBE.Installment = Installment_No;
                objBE.Type_of_Duties = SlabNo;

                //objBE.from = txtFrom.Text.ToString();
                //objBE.To = txtTo.Text.ToString();
                dt = objDL.GetDistrict_Slab_WiseRetailer_tax_indiv(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    div1.Visible = true;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    dt.Dispose();
                }
                else
                {
                    div1.Visible = false;
                    //txtFrom.Text = "";
                    //txtTo.Text = "";
                    //ddlInstallment. ="0";
                    objCommon.ShowAlertMessage("No Data Found");

                }
            }
            else
            {

            }
        }

        protected void RSP_CheckedChanged(object sender, EventArgs e)
        {
            divgrid.Visible = false;
            divgridSpec.Visible = false;
        }

        protected void btnAvailableImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Retailer Report" + ".Pdf";
            divheading.Visible = true;
            DivGeneratedDate.Visible = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgrid;
            //lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            //lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnAvailableImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            DivGeneratedDate.Visible = false;
            string GenerateFileName = "Retailer Report" + ".xls";
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgrid;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }

        protected void ImageSpecialPdf_Click(object sender, ImageClickEventArgs e)
        {
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Retailer Special Payments Report" + ".Pdf";
            DivGenerated2.Visible = false;
            divheading1.Visible = true;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgridSpec;
            //lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            //lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }

        protected void ImagespecialExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading1.Visible = true;
            DivGenerated2.Visible = false;
            string GenerateFileName = "Retailer Special Payments Report" + ".xls";
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgridSpec;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
    }
}