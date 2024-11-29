using ExciseAPI.App_Start;
using ExciseAPI.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ExciseAPI
{
    public partial class Login1 : System.Web.UI.Page
    {
        SqlHelper sql = new SqlHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUname.Attributes.Add("autocomplete", "off");
                txtPwd.Attributes.Add("autocomplete", "off");
                if (!IsPostBack)
                {
                    random();
                    ViewState["KeyGenerator"] = Guid.NewGuid().ToString("N").Substring(0, 16);
                    txtUname.Focus();
                    getCaptchaImage();

                }
            }

        }
        protected bool CheckCaptcha()
        {
            if (captch.Text == ViewState["captchtext"].ToString())
            {
                return true;
            }
            else
            {
                lblActionerror.Text = "Invalid Captcha.";
                captch.Text = "";
                return false;
            }

        }
        public string ShaEncrypt(string Ptext)
        {
            string hash = "";
            System.Security.Cryptography.SHA256CryptoServiceProvider m1 = new System.Security.Cryptography.SHA256CryptoServiceProvider();
            byte[] s1 = System.Text.Encoding.ASCII.GetBytes(Ptext);
            s1 = m1.ComputeHash(s1);
            foreach (byte bt in s1)
            {
                hash = hash + bt.ToString("x2");
            }
            return hash;
        }

        public void getCaptchaImage()
        {
            Captcha ci = new Captcha();
            string text = Captcha.generateRandomCode();
            ViewState["captchtext"] = text;
            Image2.ImageUrl = "~/Assets/cpImg/cpImage.aspx?randomNo=" + text;
        }
        protected void btnImgRefresh_Click(object sender, ImageClickEventArgs e)
        {
            captch.Text = "";
            getCaptchaImage();
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

                Response.Cookies.Add(new HttpCookie("ASPFIXATION2", num));
                hf.Value = num;
                Session["ASPFIXATION2"] = num;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx", false);
            }
        }
        public void check()
        {
            try
            {
                string cookie_value = null;
                string session_value = null;
                //cookie_value = System.Web.HttpContext.Current.Request.Cookies["ASPFIXATION2"].Value;
                cookie_value = hf.Value;
                session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
                if (cookie_value != session_value)
                {
                    System.Web.HttpContext.Current.Session.Abandon();
                    HttpContext.Current.Response.Buffer = false;
                    HttpContext.Current.Response.Redirect("~/Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //if (Session["User"] != null)
            //{
            //    //CheckBrowser();
            //    Response.Redirect("~/Error.aspx", false);
            //    return;
            //}

            //check();
            Session.Clear();
            try
            {
                if (txtUname.Text == "")
                {
                    sql.ShowAlertMessage("Enter UserName");
                    txtUname.Focus();
                    return;
                }
                if (txtPwd.Text == "")
                {
                    sql.ShowAlertMessage("Enter Password");
                    txtPwd.Focus();
                    return;
                }
                if (captch.Text == "")
                {
                    sql.ShowAlertMessage("Enter Captcha");
                    captch.Focus();
                    return;
                }
                if (CheckCaptcha())
                {
                    try
                    {

                        SqlParameter[] Params =
                         {
                            new SqlParameter("@P_UserName",txtUname.Text.ToString()),
                        };
                        DataSet dtLogin = sql.GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetLoginDetails", Params);
                        if (dtLogin != null && dtLogin.Tables.Count > 0)
                        {
                            string password = dtLogin.Tables[0].Rows[0]["Password"].ToString();
                            string myval = ShaEncrypt(ViewState["KeyGenerator"].ToString());
                            string value = ShaEncrypt(password.ToLower() + myval.ToLower());




                            if (txtPwdHash.Value == value.ToLower())
                            {
                                string guid = Guid.NewGuid().ToString();
                                Session["AuthToken"] = guid;
                                Response.ClearContent();
                                Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                                Session["User"] = txtUname.Text;
                                Session["Password"] = password.ToString();
                                Session["UserName"] = dtLogin.Tables[0].Rows[0]["UserName"].ToString();
                                Session["RegistrationID"] = dtLogin.Tables[0].Rows[0]["RegistrationID"].ToString();
                                Session["RoleID"] = dtLogin.Tables[0].Rows[0]["RoleID"].ToString();
                                Session["Section"] = dtLogin.Tables[0].Rows[0]["Section"].ToString();

                                int RoleID = Convert.ToInt32(dtLogin.Tables[0].Rows[0]["RoleID"].ToString());
                                //var rnd = new Random();
                                //int randomNumber = Enumerable.Range(100000, 999999).OrderBy(x => rnd.Next()).Take(1).FirstOrDefault();

                                //Session["EncryptDecryptKey"] = randomNumber.ToString();
                                if (RoleID == 1)
                                {
                                    Response.Redirect("~/EODB/AdminReport.aspx", false);
                                }
                                if (RoleID == 7)
                                {
                                    Response.Redirect("~/EODB/ApplicationsReport.aspx", false);
                                }
                                if (RoleID == 8)
                                {

                                    Response.Redirect("~/EODB/Home.aspx", false);
                                }



                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}