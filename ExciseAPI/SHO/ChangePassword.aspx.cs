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

namespace ExciseAPI.SHO
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

        }
        public bool ValidateSave()
        {
            if (txtNpwd.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter New Password");
                return false;
            }
            if (txtCpwd.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter Confirm Password");
                return false;
            }
            if (txtNpwd.Text != txtCpwd.Text)
            {
                objCommon.ShowAlertMessage("Please check new password and confirm password should be same");
                return false;
            }
            if (!(Regex.Match(txtNpwd.Text, CommonFuncs.PasswordValidtor)).Success)
            {
                objCommon.ShowAlertMessage("Please Enter Valid Password");
                return false;
            }
            if (!(Regex.Match(txtCpwd.Text, CommonFuncs.PasswordValidtor)).Success)
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
    
    
    
