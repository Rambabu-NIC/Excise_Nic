using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Event
{
    public partial class Ack_EventReg : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
                //  Response.Redirect("~/Error.aspx");
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
            //PrevBrowCache.enforceNoCache();
            //if (Session["Role"] != null && Session["Role"].ToString() == "1" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            //{
            //    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }
            //}
            //else
            //{
            //  //  Response.Redirect("~/Error.aspx");
            //}

            if (!IsPostBack)
            {

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                // lblUSer.Text = Session["UsrName"].ToString();
                //GetTypeManFDAL();
                //BindDistrict();
                //Viewdata();
                // random();
                //BindRevDistrict();
                //BindEventType();
                //BindExciseDistrict();
                getCaptchaImage();


            }

        }
        protected void btnImgRefresh_Click(object sender, ImageClickEventArgs e)
        {
            captch.Text = "";
            getCaptchaImage();
        }

        public void getCaptchaImage()
        {
            Captcha ci = new Captcha();
            string text = Captcha.generateRandomCode();
            ViewState["captchtext"] = text;
            Image2.ImageUrl = "~/Assets/cpImg/cpImage.aspx?randomNo=" + text;
        }
        protected bool CheckCaptcha()
        {
            if (captch.Text == ViewState["captchtext"].ToString())
            {
                return true;
            }
            else
            {
                lblError.Text = "Invalid Captcha.";
                captch.Text = "";
                return false;
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
        protected bool Validate()
        {

            if (txtRegistrationNo.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Registration No");
                txtRegistrationNo.Focus();
                return false;
            }
            if (txtMobileNumber.Text == "")
            {
                objCommon.ShowAlertMessage("Enter MobileNumber");
                txtMobileNumber.Focus();
                return false;
            }
            if (captch.Text == "")
            {

                objCommon.ShowAlertMessage("Enter Captcha");
                captch.Focus();
                return false;
            }


            return true;


        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    if (CheckCaptcha())
                    {
                        objBE.Statecode = "36";
                        //objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                        objBE.Reg_Code = txtRegistrationNo.Text;
                        objBE.MobNo = txtMobileNumber.Text;
                        objBE.Action = "ACK";
                        DataTable dt = new DataTable();
                        dt = objDL.EventReg_IUR(objBE, ConnKey);
                        if (dt.Rows.Count > 0)
                        {
                            datadiv.Visible = true;
                            //objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                            //Session["RegId"] = dt.Rows[0][0].ToString();
                            //Response.Redirect("EditEventRegistration.aspx", false);
                            lblAppNo.Text = dt.Rows[0]["AppReg_No"].ToString();
                            lblPay.Text = dt.Rows[0]["License_Fee"].ToString();
                            lblApplicantName.Text = dt.Rows[0]["App_Name"].ToString();
                            lblchno.Text = dt.Rows[0]["ChallanNumber"].ToString();
                            lblbankdate.Text = dt.Rows[0]["BankDate"].ToString();
                            lblbankStatus.Text = dt.Rows[0]["BankStatus"].ToString();
                            lblError.Text = string.Empty;
                        }
                        else
                        {
                            objCommon.ShowAlertMessage("No Data Found");
                            datadiv.Visible = false;
                            return;
                        }

                    }
                    else
                    {
                        captch.Text = "";
                        getCaptchaImage();
                        lblError.Text = "Invalid Captcha";

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}