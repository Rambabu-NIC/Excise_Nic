using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;


namespace ExciseAPI
{
    public partial class ChangePasswordS : System.Web.UI.Page
    {
        Login_DL objLoginDL = new Login_DL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        protected void Page_Load(object sender, EventArgs e)
        {

            //if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            //{
            //    Response.Redirect("~/Error.aspx");
            //}
            //else
            //{
            //    string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            //    string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            //    int len = http_hos.Length;
            //    if (http_ref.IndexOf(http_hos, 0) < 0)
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }
            //}
            ///*KILL COOKIE & clear Caching*/
            //PrevBrowCache.enforceNoCache();
            //if (Session["Role"] != null && Session["Role"].ToString() == "3" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            //{
            //    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }
            //}
            //else
            //{
            //    Response.Redirect("~/Error.aspx");
            //}

            if (!IsPostBack)
            {

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                //lblUSer.Text = Session["UsrName"].ToString();
                // BindTypeofManf();
                // pannelOK.Visible = false;
                //Viewdata();
                random();


            }
        }

        public void random()
        {
            try
            {
                string strString = "abcdefghijklmnpqrstuvwxyzABCDQEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                string num = "";
                Random rm = new Random();
                for (int i = 0; i < 16; i++)
                {
                    int randomcharindex = rm.Next(0, strString.Length);
                    char randomchar = strString[randomcharindex];
                    num += Convert.ToString(randomchar);
                }
                hf.Value = num;
                Session["ASPFIXATION2"] = num;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
        public void check()
        {
            try
            {
                string cookie_value = null;
                string session_value = null;

                cookie_value = hf.Value;
                session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
                if (cookie_value != session_value)
                {
                    System.Web.HttpContext.Current.Session.Abandon();
                    HttpContext.Current.Response.Buffer = false;
                    HttpContext.Current.Response.Redirect("~/Error.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx", false);
            }
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

            return true;
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {

                //objLoginDL.changepassword(Session["UsrName"].ToString(), txtNewPwdHash.Value,Request.ServerVariables["REMOTE_ADDR"].ToString(),ConnKey);
                if (ValidateSave())
                {
                    string username = Session["UsrName"].ToString();
                    string pwd = txtNewPwdHash.Value;
                    string ipaddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objLoginDL.changepassword(username, pwd, ipaddress, ConnKey);
                    txtNewPwdHash.Value = "";
                    //objCommon.ShowAlertMessage("Password Updated Successfully");
                    //Response.Redirect("~/Logout.aspx", false);
                    string strLoginPage = "/Logout.aspx";
                    string scriptText = "alert('Password Updated Successfully, Please Login once again'); window.location='" + Request.ApplicationPath + strLoginPage + "'";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", scriptText, true);


                }

            }
            catch (Exception ae)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

    }

}