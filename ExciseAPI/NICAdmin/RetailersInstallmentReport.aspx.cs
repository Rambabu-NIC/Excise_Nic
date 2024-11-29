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
    public partial class RetailersInstallmentReport : BasePage 
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
                BindRetailerType();
                divheading.Visible = false;
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
                int SpecialPayment = Convert.ToInt32(Session["IsSpecialPayment"].ToString());
                int InstallmentNo = 0;
                if (SpecialPayment == 0)
                {
                    InstallmentNo= Convert.ToInt32(ddlinstallments.SelectedValue);
                }
                DataTable dt1 = new DataTable();
                objBE.RetailerType = ddlRType.SelectedValue;
                objBE.TypePayment = ddltypeofpayments.SelectedValue;
                objBE.InstallmentNo = InstallmentNo;
                objBE.FinID = Convert.ToInt32(ddlFinancialYear.SelectedValue);
                //objBE.from = txtFrom.Text.ToString();
                //objBE.To = txtTo.Text.ToString();
                if (Session["Role"].ToString() == "4")
                {
                    objBE.ExDist = Session["ExDist_Cd"].ToString();
                }
                DivGeneratedDate.Visible = false;
                dt1 = objDL.GetDistrictWise_Installment_Report(objBE, ConnKey);
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
            // if (!string.IsNullOrEmpty(txtFrom.Text) && !string.IsNullOrEmpty(txtTo.Text))
            int SpecialPayment = Convert.ToInt32(Session["IsSpecialPayment"].ToString());
            if (ddlRType.SelectedIndex > 0 && ddltypeofpayments.SelectedIndex > 0 
                && ddlFinancialYear.SelectedIndex >0 )
            {

                BindData();
            }
            else
            {
                lblError.Text = "Please select all fields....";
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
            BindTypeOfPayments();
        }

        public void BindTypeOfPayments()
        {
            try
            {

                if (ddlRType.SelectedValue == "0")
                {
                    objCommon.ShowAlertMessage("Please select Retailer Type");
                }
                else
                {
                    DataTable dtTypePayment = new DataTable();
                    objBE.Retailer_Code = ddlRType.SelectedValue;
                    objBE.TypePayment = "0";
                    objBE.Action = "TypePayment";
                    dtTypePayment = objDL.GetRetailerType_Payment_Installment(objBE, ConnKey);

                   

                    objCommon.BindDropDownLists(ddltypeofpayments, dtTypePayment, "Payment_Desc", "Type_Payment", "0");
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
            
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

    

       
        protected void ddltypeofpayments_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Rtype = Convert.ToInt32(ddlRType.SelectedValue);
            int TPayments = Convert.ToInt32(ddltypeofpayments.SelectedValue);
            if (Rtype > 0 && TPayments > 0)
            {
                DataTable dtSpecial = new DataTable();
                objBE.Retailer_Code = ddlRType.SelectedValue;
                objBE.TypePayment = ddltypeofpayments.SelectedValue;
                objBE.Action = "IsSpecial";
                dtSpecial = objDL.GetRetailerType_Payment_Installment(objBE, ConnKey);
                Session["IsSpecialPayment"] = dtSpecial.Rows[0]["IsSpecial"].ToString();
                int SpecialPayment = Convert.ToInt32(Session["IsSpecialPayment"].ToString());
                divInstallment.Visible = false;
                if (SpecialPayment == 0)
                {
                    divInstallment.Visible = true;
                }

                BindInstallmentType();
            }
            else
            {
                objCommon.ShowAlertMessage("Please select Retailer Type & Type of Payment");
            }
        }

        public void BindInstallmentType()
        {
            try
            {

                if (ddlRType.SelectedValue == "0" || ddltypeofpayments.SelectedValue =="0")
                {
                    objCommon.ShowAlertMessage("Please select Retailer Type  & Type of Payment");
                }
                else
                {
                    DataTable dtInstallementType = new DataTable();
                    objBE.Retailer_Code = ddlRType.SelectedValue;
                    objBE.TypePayment = ddltypeofpayments.SelectedValue;
                    objBE.Action = "Installment";
                    dtInstallementType = objDL.GetRetailerType_Payment_Installment(objBE, ConnKey);
                    objCommon.BindDropDownLists(ddlinstallments, dtInstallementType, "InstallmentType", "InstallmentNo", "0");
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }
    }
}