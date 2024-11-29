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
    public partial class EventStatus : System.Web.UI.Page
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


            if (!IsPostBack)
            {
                DateTime StartDate = DateTime.Today;
                Calendar1.StartDate = StartDate;
                //Calendar1.StartDate = StartDate.AddDays(1);

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


        public DataTable dtStatusDetails
        {
            get
            {
                return ViewState["dtStatusDetails"] as DataTable;
            }
            set
            {
                ViewState["dtStatusDetails"] = value;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtDate.Text))
            {
                lblError.Text = "Please Enter Date Of Event";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrEmpty(txtMobileNumber.Text))
            {
                lblError.Text = "Please Enter Mobile No";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                lblError.Text = "Please Enter Email";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(captch.Text))
            {
                lblError.Text = "Please Enter Captcha";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (CheckCaptcha())
            {
                //DataTable dt = new DataTable();
                divStatus.Visible = false;
                Session["EventMobile"] = txtMobileNumber.Text;
                Session["EventEmail"] = txtEmail.Text;
                Session["EventDate"] = txtDate.Text;
                objBE.MobNo = txtMobileNumber.Text;
                objBE.Email = txtEmail.Text;
                objBE.Date = Convert.ToDateTime(txtDate.Text);
                dtStatusDetails = objDL.GetEventStatus(objBE, ConnKey);
                if (dtStatusDetails.Rows.Count > 0)
                {

                    gvStatus.DataSource = dtStatusDetails;
                    gvStatus.DataBind();
                    divStatus.Visible = true;

                    //int Status = Convert.ToInt16(dt.Rows[0]["Status"].ToString());
                    //if (Status == 0)
                    //{
                    //    Session["RegId"] = dt.Rows[0]["AppReg_NO"].ToString();
                    //    Response.Redirect("~/Event/PaymentDtls.aspx", false);
                    //}
                    //else
                    //{
                    //    gvStatus.DataSource = dt;
                    //    gvStatus.DataBind();
                    //    divStatus.Visible = true;
                    //}

                }
                else
                {
                    Response.Redirect("../Event/EventRegistration.aspx");
                }
            }
            else
            {
                captch.Text = "";
                getCaptchaImage();
                lblError.Text = "Invalid Captcha";
            }

        }

        protected void gvStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkView = e.Row.FindControl("lnkview") as LinkButton;
                int Status = Convert.ToInt16(dtStatusDetails.Rows[0]["Status"].ToString());
                //byte[] Document = Encoding.ASCII.GetBytes(dtComplaints.Tables[0].Rows[0]["DocumentFile"].ToString());
                if (Status == 0 || Status == 11)
                {
                    lnkView.Enabled = true;
                    lnkView.Text = "Click..!";
                }
                else if (Status == 10)
                {
                    lnkView.Enabled = true;
                    lnkView.Text = "Click..!";
                }
                else
                {
                    lnkView.Enabled = false;
                    lnkView.Text = "Not Available";
                    lnkView.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        protected void gvStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string AppRegNo = commandArgs[0];
                int Status = Convert.ToInt16(commandArgs[1]);

                if (Status == 11)
                {
                    Session["RegId"] = AppRegNo.ToString();
                    Response.Redirect("~/Event/PaymentDtls.aspx", false);
                }
                if (Status == 0 || Status == 10)
                {
                    Session["RegId"] = AppRegNo.ToString();
                    Response.Redirect("~/Event/EditEventRegistration.aspx", false);
                }
            }

        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtDate.Text) && Convert.ToDateTime(txtDate.Text.ToString()) < DateTime.Today)
            {
                txtDate.Text = "";
                lblError.Text = "Please select the Date..";
                txtDate.ReadOnly = false;
            }
            else if(string.IsNullOrEmpty(txtDate.Text))
            {
                lblError.Text = "Please select the Date..";
                txtDate.ReadOnly = false;
            }
            else
            {
                txtDate.Attributes.Add("readonly", "readonly");
            }
           
            //txtDate.ReadOnly = true;
        }
    }
}