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
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;

namespace ExciseAPI.Retailer
{
    public partial class SFT_BankName : BasePage
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
            PrevBrowCache.enforceNoCache();
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
                dt1 = objDL.Get_SFTBank(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    gvSftChallan.Visible = true;
                    gvSftChallan.DataSource = dt1;
                    gvSftChallan.DataBind();
                    divSftBank.Visible = true;
                    btnSftBankImageExportToExcel.Visible = true;
                    btnSftBankImageExportToPdf.Visible = true;
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

        protected void btnSftBankImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            divBankChallanReport.Visible = true;
            GridView gridviewid = gvSftChallan;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Bankwise Challan Report" + ".Pdf";

            System.Web.UI.HtmlControls.HtmlGenericControl div = divSftBank;
            lblBankFrom.Text = "FromDate  : " + FromDate;
            lblBankto.Text = "ToDate  : " + ToDate;
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }

        protected void btnSftBankImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divBankChallanReport.Visible = true;
            string GenerateFileName = "Bankwise Challan Report" + ".xls";
            GridView gridviewid = gvSftChallan;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divSftBank;
            lblBankFrom.Text = "FromDate  : " + FromDate;
            lblBankto.Text = "ToDate  : " + ToDate;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
    }
}