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
    public partial class DepotSelection : System.Web.UI.Page
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
            if (Session["RetailerPassword"].ToString() == "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4")
            {
                Response.Redirect("~/Retailer/ChangePassword.aspx");
            }
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
                Binddepot();
            }
        }
        public void Binddepot()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.RetailerCode = Session["UsrName"].ToString();
                dt1 = objDL.GetDepotsByRetailerCode(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlDepot, dt1, "DepotName", "DepotCode", "0");
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void ddlDepot_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (ddlDepot.SelectedIndex > 0)
            {
                Session["DepotCode"] = ddlDepot.SelectedValue;
            }
            else
            {
                lblError.Text = "Please Select Depot Name ..";
            }

        }

        protected void btndepot_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (ddlDepot.SelectedIndex > 0)
            {
                Response.Redirect("~/Retailer/PaymentRetailarDtls_MD.aspx", false);
            }
            else
            {
                lblError.Text = "";
            }

        }
    }
}