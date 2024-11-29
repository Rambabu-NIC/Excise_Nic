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
    public partial class ChangePassword_M : System.Web.UI.Page
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
                BindQuestioniareDetails();
            }

        }

        public void BindQuestioniareDetails()
        {
            DataTable dtQuestionaire = objLoginDL.GetQuestionnaire(ConnKey);
            if (dtQuestionaire.Rows.Count > 0)
            {
                ddlQuestionaire.Items.Clear();
                objCommon.BindDropDownLists(ddlQuestionaire, dtQuestionaire, "Questionnaire", "QuestionnaireID", "0");
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
            if(ddlQuestionaire.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Please Select Questionnaire..");
                return false;
            }
            if (string.IsNullOrEmpty(txtAnswer.Text))
            {
                objCommon.ShowAlertMessage("Please Enter Answers..");
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
                    int QuestionnaireID = Convert.ToInt32(ddlQuestionaire.SelectedValue);
                    string QuestionnaireAnswer = txtNewAnswers.Value; //txtAnswer.Text.ToString();
                    DataTable dtQuest = objLoginDL.GetQuestionnaire_Insert(username, QuestionnaireID, QuestionnaireAnswer, ConnKey);
                    if (dtQuest.Rows.Count > 0)
                    {
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
                            objCommon.ShowAlertMessage("Please Check the Questionnaire And Answers..");
                            return;
                        }
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
    
    
    
