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
    public partial class VerifiedTransactions : BasePage
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
                // BindRetailerType();
                divheading.Visible = false;
                //divheading1.Visible = false;
            }
        }




        public void BindData()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.from = txtDate.Text.ToString();
                objBE.Verified = 0;
                if (RSP.Checked == true)
                {
                    objBE.Verified = 1;
                }
                divgrid.Visible = false;
                DivGeneratedDate.Visible = false;

                dt1 = objDL.GetSPTransactionsVerified(objBE, ConnKey);

                if (dt1.Rows.Count > 0)
                {
                    divgrid.Visible = true;
                    DivGeneratedDate.Visible = true;
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
            lblError.Text = "";
            if (string.IsNullOrEmpty(txtDate.Text))
            {
                lblError.Text = "Please Select  Date";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            BindData();


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


        protected void gvdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "View")
            //{
            //    DataTable dt = new DataTable();
            //    objBE.RetailerType = ddlRType.SelectedValue;

            //    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

            //    String DDOCODE = ((Label)(gRow.FindControl("DDOCode"))).Text; ;
            //    String SlabNo= ((Label)(gRow.FindControl("SlabNo"))).Text;
            //    String TypeofPayment = ((Label)(gRow.FindControl("Sub_Head"))).Text;
            //    String Installment_No = ((Label)(gRow.FindControl("Installment_No"))).Text;

            //    objBE.DDoCode = DDOCODE;
            //    objBE.SubHead = TypeofPayment;
            //    objBE.Installment = Installment_No;
            //    objBE.Type_of_Duties = SlabNo;

            //    //objBE.from = txtFrom.Text.ToString();
            //    //objBE.To = txtTo.Text.ToString();
            //    dt = objDL.GetDistrict_Slab_WiseRetailer_tax_indiv(objBE, ConnKey);
            //    if (dt.Rows.Count > 0)
            //    {
            //        div1.Visible = true;
            //        GridView1.DataSource = dt;
            //        GridView1.DataBind();
            //        dt.Dispose();
            //    }
            //    else
            //    {
            //        div1.Visible = false;
            //        //txtFrom.Text = "";
            //        //txtTo.Text = "";
            //        //ddlInstallment. ="0";
            //        objCommon.ShowAlertMessage("No Data Found");

            //    }
            //}
            //else
            //{

            //}
        }



        protected void btnAvailableImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Verified Challans Report" + ".Pdf";
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
            string GenerateFileName = "Verified Challans Report" + ".xls";
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgrid;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }


    }
}