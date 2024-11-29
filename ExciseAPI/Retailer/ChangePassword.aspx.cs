using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Retailer
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        Supplier_BE objRegBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
        Login_DL objLoginDL = new Login_DL();
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
            if (Session["Role"] != null && (Session["Role"].ToString() == "3" || Session["Role"].ToString() == "12" || 
                Session["Role"].ToString() == "4" || Session["Role"].ToString() == "13" || Session["Role"].ToString() == "2" )
                && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
        public bool ValidateSave()
        {
            if (txtPassword.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter New Password");
                return false;
            }
            if (txtconfirmpassword.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter Confirm Password");
                return false;
            }
            if (txtPassword.Text != txtconfirmpassword.Text)
            {
                objCommon.ShowAlertMessage("Please check new password and confirm password should be same");
                return false;
            }
            if (!(Regex.Match(txtPassword.Text, CommonFuncs.PasswordValidtor)).Success)
            {
                objCommon.ShowAlertMessage("Please Enter Valid Password");
                return false;
            }
            if (!(Regex.Match(txtconfirmpassword.Text, CommonFuncs.PasswordValidtor)).Success)
            {
                objCommon.ShowAlertMessage("Please Enter Valid Password");
                return false;
            }

            return true;
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSave())
                {
                    txtPassword.Text = txtNewPwdHash.Value.ToString();
                    txtconfirmpassword.Text = txtNewPwdHash.Value.ToString();

                    string username = Session["UsrName"].ToString();

                    string pwd = txtNewPwdHash.Value;
                    if (!string.IsNullOrEmpty(pwd))
                    {
                        string ipaddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                        objLoginDL.changepassword(username, pwd, ipaddress, ConnKey);
                        txtNewPwdHash.Value = "";
                        string strLoginPage = "../Logout.aspx";
                        string scriptText = "alert('Password Updated Successfully, Please Login once again'); window.location='" + Request.ApplicationPath + strLoginPage + "'";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", scriptText, true);
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("Please Check The Password");
                    }

                }
            }
            catch (Exception ae)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}
    
    
    
