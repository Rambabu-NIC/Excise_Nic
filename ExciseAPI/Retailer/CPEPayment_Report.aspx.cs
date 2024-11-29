using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Retailer
{
    public partial class CPEPayment_Report : BasePage
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsConfirm"].ToString() == "0")
            {
                Response.Redirect("~/Retailer/RetailerProfile_Confirm.aspx");
            }
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "12" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                BindInstallmentNo();
                txtFrom.Text = "";
                txtTo.Text = "";
                btnRetailerImageExportToExcel.Visible = false;
            }
        
    }


        public void BindInstallmentNo()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Type_of_Manu = Session["Type_Retailer"].ToString();
                dt1 = objDL.GetInstallmentNo(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlInstallment, dt1, "InstallmentType", "InstallmentNo", "0");
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
                btnRetailerImageExportToExcel.Visible = false;
                DataTable dt1 = new DataTable();
                objBE.RetailerCode = Session["UsrName"].ToString();
                objBE.InstallmentNo = Convert.ToInt32(ddlInstallment.SelectedValue);
                objBE.from = txtFrom.Text.ToString();
                objBE.To = txtTo.Text.ToString();
                dt1 = objDL.GetCpeDetails(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    divgrid.Visible = true;
                    btnRetailerImageExportToExcel.Visible = true;
                    gvdetails.DataSource = dt1;
                    gvdetails.DataBind();
                    dt1.Dispose();
                }
                else
                {
                    divgrid.Visible = false;
                    txtFrom.Text = "";
                    txtTo.Text = "";
                    //ddlInstallment. ="0";
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
            if (!string.IsNullOrEmpty(txtFrom.Text) && !string.IsNullOrEmpty(txtTo.Text) && 
                Convert.ToInt32(ddlInstallment.SelectedValue) > 0)
            {
                BindData();
            }
            else
            {
                lblError.Text = "Please select dates and Installment....";
                return;
            }

        }

        protected void btnRetailerImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;

            string GenerateFileName = "CPE Payments Report" + ".xls";
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = true;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
    }
}