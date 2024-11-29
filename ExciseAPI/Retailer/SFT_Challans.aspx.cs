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
    public partial class SFT_Challans : BasePage
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
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public string FromDate
        {
            get
            {
                if (Request.QueryString["FromDate"] != null)
                {
                    return Decrypt(Request.QueryString["FromDate"].ToString());
                }
                else
                {
                    return null;
                }
            }
        }
        public string ToDate
        {
            get
            {
                if (Request.QueryString["ToDate"] != null)
                {
                    return Decrypt(Request.QueryString["ToDate"].ToString());
                }
                else
                {
                    return null;
                }
            }
        }
        public string BankName
        {
            get
            {
                if (Request.QueryString["BankName"] != null)
                {
                    return Decrypt(Request.QueryString["BankName"].ToString());
                }
                else
                {
                    return null;
                }
            }
        }

        public void BindData()
        {
            try
            { 
            objBE = new Supplier_BE();
            DataTable dt1 = new DataTable();
            objBE.from = FromDate;
            objBE.To = ToDate;
            objBE.BankName = BankName;
            dt1 = objDL.Get_SFTChallans(objBE, ConnKey);
            if (dt1.Rows.Count > 0)
            {
                gvSftChallan.Visible = true;
                gvSftChallan.DataSource = dt1;
                gvSftChallan.DataBind();
                divBankChallanDetails.Visible = true;
                btnBankImageExportToExcel.Visible = true;
                btnBankImageExportToPdf.Visible = true;
            }
            else
            {
                gvSftChallan.Visible = false;
                objCommon.ShowAlertMessage("No Data Found");
            }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btnBankImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divBankChallanReport.Visible = true;
            GridView gridviewid = gvSftChallan;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Bankwise Challan Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divBankChallanDetails;
            lblBankFrom.Text = "FromDate  : " + FromDate;
            lblBankto.Text = "ToDate  : " + ToDate;
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }

        protected void btnBankImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divBankChallanReport.Visible = true;
            string GenerateFileName = "Bankwise Challan Report" + ".xls";
            GridView gridviewid = gvSftChallan;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divBankChallanDetails;
            lblBankFrom.Text = "FromDate  : " + FromDate;
            lblBankto.Text = "ToDate  : " + ToDate;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
    }
}