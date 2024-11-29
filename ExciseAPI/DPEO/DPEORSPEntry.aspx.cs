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

namespace ExciseAPI.DPEO
{
    public partial class DPEORSPEntry : System.Web.UI.Page
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
            if (!IsPostBack)
            {
               
            }
        }
        public DataTable dtRetailer
        {
            get
            {
                return ViewState["dtRetailer"] as DataTable;
            }
            set
            {
                ViewState["dtRetailer"] = value;
            }
        }
        public void BindSubHead(string Type_Retailer)
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Type_of_Manu = Type_Retailer;
                //objBE.MinorHead = ddlduty.SelectedValue;
                //objBE.Action = "RP";
                objBE.Action = "RSPecialPayments";
                dt1 = objDL.CommonMasters(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlSubH, dt1, "Payment_Desc", "Type_Payment", "0");
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindData(string RetailerCode)
        {
            try
            {
                secondpanel.Visible = false;
                lblretailererror.Text = "";
                if (!string.IsNullOrEmpty(RetailerCode))
                {
                    objBE.RetailerCode = RetailerCode;

                    dtRetailer = objDL.GetRetailerDetailsByID(objBE, ConnKey);
                    if (dtRetailer.Rows.Count > 0)
                    {
                        secondpanel.Visible = true;
                        txtRetailerCode.Text = dtRetailer.Rows[0]["ptcode"].ToString();
                        txtlincesename.Text = dtRetailer.Rows[0]["contact"].ToString();
                        txtshopName.Text = dtRetailer.Rows[0]["ptname"].ToString();
                        txtGazette_Code.Text = dtRetailer.Rows[0]["Gazette_Code"].ToString();
                        txtretaileraddress.Text = dtRetailer.Rows[0]["Address"].ToString();
                        //string ddocode = System.Web.HttpContext.Current.Session["DDOCode"].ToString();
                        string Type_Retailer = dtRetailer.Rows[0]["Type_Retailer"].ToString();
                        BindSubHead(Type_Retailer);
                    }

                }
                else
                {
                    lblretailererror.Text = "Please enter valid retailer code..";
                    return;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnGetDetails_Click(object sender, EventArgs e)
        {
            lblretailererror.Text = "";
            string RetailerCode = txtRetailerCode.Text.ToString().Trim();

            if (!string.IsNullOrEmpty(RetailerCode))
            {
                BindData(RetailerCode);
            }
            else
            {
                lblretailererror.Text = "Please enter valid retailer code..";
                return;
            }
        }

        protected void ddlSubH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtamount.Text = "";
            txtamount.Enabled = false;
            btnsubmit.Enabled = false;
            if (Convert.ToInt32(ddlSubH.SelectedValue) >0)
            {
                txtamount.Enabled = true;
                btnsubmit.Enabled = true;
            }
            else
            {
                lblretailererror.Text = "Please enter valid retailer code..";
                return;
            }

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string Retailer_Code=txtRetailerCode.Text.ToString();
            string Retailer_Type = dtRetailer.Rows[0]["Type_Retailer"].ToString();
            int Type_Payment = Convert.ToInt32(ddlSubH.SelectedValue);
            decimal Amount = Convert.ToDecimal(txtamount.Text.ToString());
            string DPEoCode = Session["UsrName"].ToString();
            if (string.IsNullOrEmpty(txtRetailerCode.Text.ToString()))
            {
                lblError.Text = "Please check the retailer code...";
                return;
            }
            if (ddlSubH.SelectedValue =="0")
            {
                lblError.Text = "Please select the type of payment...";
                return;
            }
            if (string.IsNullOrEmpty(txtamount.Text.ToString()))
            {
                lblError.Text = "Please enter valid amount...";
                return;
            }

            bool result = objDL.Rsp_insert(Retailer_Code, Retailer_Type, Type_Payment, Amount, DPEoCode,ConnKey);

            if (result)
            {
                txtamount.Text = "";
                ddlSubH.Items.Clear();
                txtRetailerCode.Text = "";
                secondpanel.Visible = false;
                lblretailererror.Text = "Inserted Successfully...";
                lblretailererror.ForeColor = System.Drawing.Color.Green;
                return;
            }
            else
            {
                lblError.Text = "Please check the details...";
                return;
            }
        }
    }
}