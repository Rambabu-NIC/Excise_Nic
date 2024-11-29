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
    public partial class ApplicantRegistration : System.Web.UI.Page
    {
        SqlHelper sql = new SqlHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
               
                divfirstpanel.Visible = true;
                divsecondpanel.Visible = false;
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
        protected void btnregsubmit_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }

          





                SqlParameter[] Params =
                     {
                    new SqlParameter("@MobileNo",txtMobileNo.Text.ToString()),
                    new SqlParameter("@Password",txtNewPwdHash.Value),//txtconfirmpassword.Text.ToString()),
                    new SqlParameter("@ApplicantName",txtApplicantName.Text.ToString()),
                    new SqlParameter("@Aadhar",txtAadhar.Text.ToString()),
                    new SqlParameter("@PanNo",txtPanNo.Text.ToString()),
                    new SqlParameter("@GstNo",txtGstNo.Text.ToString()),
                    new SqlParameter("@Email",txtEmail.Text.ToString()),
                    new SqlParameter("@DistrictID",ddlDistrict.SelectedValue),
                    new SqlParameter("@MandalID",ddlMandal.SelectedValue),
                    new SqlParameter("@VillageID",ddlVillage.SelectedValue),
                    new SqlParameter("@HouseNo",txtHouseNo.Text.ToString()),
                    new SqlParameter("@Street",txtStreet.Text.ToString()),
                    new SqlParameter("@CreatedBy","")

            };

            try
            {
                if (CheckCaptcha())
                {
                    DataSet data = sql.GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "ApplicantrRegistration_Insert", Params);
                    if (data != null && data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0 && data.Tables[0].Rows[0]["Status"].ToString() == "Success")
                    {





                        clear();

                        lblRegisterd.Text = "Registration completed successfully  your UserName:" + data.Tables[0].Rows[0]["UserName"].ToString() + "..";
                        lblRegisterd.ForeColor = System.Drawing.Color.Green;

                        return;
                    }

                    else if (data != null && data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0 && data.Tables[0].Rows[0]["Status"].ToString() == "Registered")
                    {
                        lblActionerror.Text = "User Already Registered With This Mobile No ";
                        lblActionerror.ForeColor = System.Drawing.Color.Green;

                        return;
                    }
                    else
                    {
                        lblActionerror.Text = "Please check the values..";
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

            catch (Exception ex)
            {
                lblActionerror.Text = "Please check the values..";
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('msg');", true);
                return;
            }
            }
        

        
        protected void txtMobileNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMobileNo.Text))
            {
                txtUserName.Text = txtMobileNo.Text.ToString();
            }
        }
        
        public void clear()
        {
            txtMobileNo.Text = "";
            txtconfirmpassword.Text = "";
            txtApplicantName.Text = "";
            txtAadhar.Text = "";
            txtPanNo.Text = "";
            txtGstNo.Text = "";
            txtEmail.Text = "";
            ddlDistrict.SelectedValue = "0";
            ddlMandal.SelectedValue = "0";
            ddlVillage.SelectedValue = "0";
            txtHouseNo.Text = "";
            txtStreet.Text = "";
            divfirstpanel.Visible = false;
            divsecondpanel.Visible = true;
        }
        
    }
}