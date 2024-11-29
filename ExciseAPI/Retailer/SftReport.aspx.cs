using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Retailer
{
    public partial class SftReport : BasePage
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && (Session["Role"].ToString() == "1" || Session["Role"].ToString() == "50" || Session["Role"].ToString() == "52") && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                //if (Session != null && !string.IsNullOrEmpty(Session["UsrName"].ToString()))
                //{
                //lblUSer.Text = Session["UsrName"].ToString();
                //}
                //BindData();

            }
        }


        public DataTable dtSft
        {
            get
            {
                return ViewState["dtSft"] as DataTable;
            }
            set
            {
                ViewState["dtSft"] = value;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (string.IsNullOrEmpty(rblSft.SelectedValue))
            {
                lblError.Text = "Please Select RadioButton";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(txtFrom.Text))
            {
                lblError.Text = "Please Select From Date";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(txtTo.Text))
            {
                lblError.Text = "Please Select To Date";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            //DataTable dt = new DataTable();
            dtSft = null;
            try
            {
                divgriddetails.Visible = false;
                divBankDetails.Visible = false;
                divData.Visible = false;
                divDepot.Visible = false;
                btnDetailImageExportToPdf.Visible = false;
                btnDetailImageExportToExcel.Visible = false;
                btnBankImageExportToPdf.Visible = false;
                btnBankImageExportToExcel.Visible = false;
                btnDateImageExportToPdf.Visible = false;
                btnDateImageExportToExcel.Visible = false;
                btnDepotImageExportToPdf.Visible = false;
                btnDepotImageExportToExcel.Visible = false;

                gvdetails.DataSource = "";
                gvdetails.DataBind();
                gvBank.DataSource = "";
                gvBank.DataBind();
                gvDate.DataSource = "";
                gvDate.DataBind();
                gvDepot.DataSource = "";
                gvDepot.DataBind();
                objBE.Action = rblSft.SelectedValue;
                objBE.FromDate = Convert.ToDateTime(txtFrom.Text.ToString().Trim());
                objBE.ToDate = Convert.ToDateTime(txtTo.Text.ToString().Trim());
                dtSft = objDL.GetSFT_WiseReport1(objBE, ConnKey);
                if (dtSft.Rows.Count > 0 && rblSft.SelectedValue == "0")
                {

                    gvdetails.DataSource = dtSft;
                    gvdetails.DataBind();
                    divgrid.Visible = true;
                    divgriddetails.Visible = true;
                    btnDetailImageExportToPdf.Visible = true;
                    btnDetailImageExportToExcel.Visible = true;
                    ViewState["FromDate"] = txtFrom.Text.ToString();
                    txtFrom.Text = string.Empty;
                    ViewState["ToDate"] = txtTo.Text.ToString();
                    txtTo.Text = string.Empty;
                }
                else if (dtSft.Rows.Count > 0 && rblSft.SelectedValue == "1")
                {
                    gvBank.DataSource = dtSft;
                    gvBank.DataBind();
                    divBankDetails.Visible = true;
                    btnBankImageExportToPdf.Visible = true;
                    btnBankImageExportToExcel.Visible = true;
                    ViewState["FromDate"] = txtFrom.Text.ToString();
                    txtFrom.Text = string.Empty;
                    ViewState["ToDate"] = txtTo.Text.ToString();
                    txtTo.Text = string.Empty;
                }
                else if (dtSft.Rows.Count > 0 && rblSft.SelectedValue == "2")
                {
                    gvDate.DataSource = dtSft;
                    gvDate.DataBind();
                    divData.Visible = true;
                    btnDateImageExportToPdf.Visible = true;
                    btnDateImageExportToExcel.Visible = true;
                    ViewState["FromDate"] = txtFrom.Text.ToString();
                    txtFrom.Text = string.Empty;
                    ViewState["ToDate"] = txtTo.Text.ToString();
                    txtTo.Text = string.Empty;
                }
                else if (dtSft.Rows.Count > 0 && rblSft.SelectedValue == "3")
                {
                    gvDepot.DataSource = dtSft;
                    gvDepot.DataBind();
                    divDepot.Visible = true;
                    btnDepotImageExportToPdf.Visible = true;
                    btnDepotImageExportToExcel.Visible = true;
                    ViewState["FromDate"] = txtFrom.Text.ToString();
                    txtFrom.Text = string.Empty;
                    ViewState["ToDate"] = txtTo.Text.ToString();
                    txtTo.Text = string.Empty;
                }
                else
                {
                    txtFrom.Text = string.Empty;
                    txtTo.Text = string.Empty;
                    divgriddetails.Visible = false;
                    divBankDetails.Visible = false;
                    divData.Visible = false;
                    divDepot.Visible = false;
                    objCommon.ShowAlertMessage("No Data Found");
                    lblError.Text = "No Data Found";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }

            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }

        protected void btnDetailImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Details Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnDetailImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            string GenerateFileName = "Details Report" + ".xls";
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
        protected void btnBankImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divBankReport.Visible = true;
            GridView gridviewid = gvBank;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Bankwise Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divBankDetails;
            lblBankFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblBankto.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnBankImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divBankReport.Visible = true;
            string GenerateFileName = "Bankwise Report" + ".xls";
            GridView gridviewid = gvBank;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divBankDetails;
            lblBankFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblBankto.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
        protected void btnDateImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            DivDataReport.Visible = true;
            GridView gridviewid = gvDate;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Datewise Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divData;
            lblDataFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblDataTo.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnDateImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            DivDataReport.Visible = true;
            string GenerateFileName = "Datewise Report" + ".xls";
            GridView gridviewid = gvDate;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divData;
            lblDataFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblDataTo.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
        protected void btnDepotImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divDpt.Visible = true;
            GridView gridviewid = gvDepot;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "DepotWise Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divDepot;
            lblDepotFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblDepotTo.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnDepotImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divDpt.Visible = true;
            string GenerateFileName = "DepotWise Report" + ".xls";
            GridView gridviewid = gvDepot;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divDepot;
            lblDepotFrom.Text = "FromDate  : " + ViewState["FromDate"];
            lblDepotTo.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }

        protected void gvBank_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Challans")
                {
                    //var commandArgument = e.CommandArgument.ToString();
                    //GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    //DataRow drDetails = dtSft.Rows[gvBank.Rows[].RowIndex];
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string BankName = commandArgs[0];
                    string FromDate = commandArgs[1];
                    string ToDate = commandArgs[2];
                    Response.Redirect("~/Retailer/SFT_Challans.aspx?FromDate="+ Encrypt(FromDate) +"&ToDate="+ Encrypt(ToDate) +"&Bankname="+ Encrypt(BankName),false);
                    //DataTable dt = new DataTable();

                    //GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;


                    //objBE = new Supplier_BE();
                    //DataTable dt1 = new DataTable();
                    //objBE.from = txtFrom.Text;
                    //objBE.To = txtTo.Text;
                    //objBE.BankName = rblSft.SelectedValue.ToString();
                    //dt1 = objDL.Get_SFTChallans(objBE, ConnKey);
                    //if (dt1.Rows.Count > 0)
                    //{
                        

                    //}

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