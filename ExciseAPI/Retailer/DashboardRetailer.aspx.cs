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
    public partial class DashboardRetailer : System.Web.UI.Page
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
            if (Session["RetailerPassword"].ToString() == "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4")
            {
                Response.Redirect("~/Retailer/ChangePassword.aspx");
            }
            if (Session["IsConfirm"].ToString() == "0")
            {
                Response.Redirect("~/Retailer/RetailerProfile_Confirm.aspx");
            }


            if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
                Response.Redirect("~/Error.aspx");
            }
            else
            {
                string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
                string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
                int len = http_hos.Length;
                if (http_ref.IndexOf(http_hos, 0) < 0)
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
            /*KILL COOKIE & clear Caching*/
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
                Viewdata();
                spnpermits_db.InnerText = "0";
                spntransitforms_db.InnerText = "0";
            }

        }
        protected void Viewdata()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                objBE.Retailer_Code = Session["UsrName"].ToString();
                dt = objDL.GetretailerInformation(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {

                    lblRetailercode.Text = dt.Rows[0]["Retailer_Code"].ToString();
                    lblRetailerName.Text = dt.Rows[0]["Retailer_Name"].ToString();
                    lblRetailer_Type.Text = dt.Rows[0]["Retailer_type_Short_Name"].ToString();
                    lbldepotName.Text = dt.Rows[0]["DepotName"].ToString();
                    lbllicensename.Text = dt.Rows[0]["License_Name"].ToString();
                    lbllicenseno.Text = dt.Rows[0]["License_No"].ToString();
                    lblmobile.Text = dt.Rows[0]["Mobile"].ToString();
                    lblemail.Text = dt.Rows[0]["Email_Id"].ToString();
                    lblStatus.Text = dt.Rows[0]["Status1"].ToString();
                    lblLicenseValidity.Text = dt.Rows[0]["Lic_Validupto"].ToString();
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");
                    return;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}