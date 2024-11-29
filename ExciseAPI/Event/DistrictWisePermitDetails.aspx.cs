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
    public partial class DistrictWisePermitDetails : System.Web.UI.Page
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


            if (!IsPostBack)
            {

                BindRevDistrict();
                getCaptchaImage();

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
       
        public void BindData()
        {
            lblError.Text = "";
            if (ddlDistrict.SelectedValue == "0")
            {
                lblError.Text = "Please Select District";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlYear.SelectedValue == "0")
            {
                lblError.Text = "Please Select Year";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (captch.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Captcha");
                captch.Focus();
                return;

            }
            if (CheckCaptcha())
            {
                DataTable dt = new DataTable();
                divDisEvent.Visible = false;
                objBE.DistCode = ddlDistrict.SelectedValue;
                objBE.Year = ddlYear.SelectedValue;

                dt = objDL.GetDistrictEvent(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    gvDisEvent.DataSource = dt;
                    gvDisEvent.DataBind();
                    divDisEvent.Visible = true;
                }
                else
                {
                    lblError.Text = "No Data Found";


                }
            }
            else
            {
                captch.Text = "";
                getCaptchaImage();
                lblError.Text = "Invalid Captcha";

            }
            }

        public void BindRevDistrict()
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = new DataTable();
                try
                {
                    objBE.Statecode = "36";
                    objBE.Action = "RD";
                    dt1 = ObjMDL.CommonMasters(objBE, ConnKey);
                    if (dt1.Rows.Count > 0)
                    {

                        ddlDistrict.DataSource = dt1;
                        ddlDistrict.DataTextField = "DistName";
                        ddlDistrict.DataValueField = "DistCode";
                        ddlDistrict.DataBind();
                        ddlDistrict.Items.Insert(0, new ListItem("ALL", "99"));
                        dt1.Dispose();

                    }
                    else
                    {
                        //GvRpt.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                    Response.Redirect("~/Error.aspx");
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}