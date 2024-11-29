using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using Excise_BE;
using Excise_DAL;
using System.Text;
using System.Net;
using System.IO;

namespace ExciseAPI.Supplier
{
    public partial class Reset_Password : System.Web.UI.Page
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
            if (Session["Role"] != null && Session["Role"].ToString() == "3" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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

        protected void BtnGet_Click(object sender, EventArgs e)
        {
            divreset.Visible = false;
            try
            {
                if (string.IsNullOrEmpty(txtsupplier.Text))
                {
                    lblSupplierererror.Text = "Please Enter Supplier Code";
                    lblSupplierererror.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                DataTable dtt = new DataTable();
                dtt = new DataTable();


                objBE.SupplierCode = txtsupplier.Text;
                dtt = objDL.Get_Supplier_Details(objBE, ConnKey);
                if (dtt.Rows.Count > 0)
                {
                    divreset.Visible = true;
                    return;
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");
                    return;
                }
            }
            catch (Exception Ex)
            {

            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = new DataTable();
                objBE.SupplierCode = txtsupplier.Text;
                dt = objDL.Supplier_ResetPassword(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage("Password Updated Successfully");
                    divreset.Visible = false;
                    return;
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");
                    divreset.Visible = false;
                    return;
                }
            }
            catch (Exception Ex)
            {

            }
        }
    }
}