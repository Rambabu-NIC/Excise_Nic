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

namespace ExciseAPI
{
    public partial class ForgotPassword : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                BindQuestioniareDetails();
                ViewState["KeyGenerator"] = Guid.NewGuid().ToString("N").Substring(0, 16);
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
            if (ddlQuestionaire.SelectedValue == "0")
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

            }
            catch (Exception ae)
            {
                Response.Redirect("~/Error.aspx");
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

        protected void btnGet_Click(object sender, EventArgs e)
        {
            divresetpassword.Visible = false;
            int QuestionnaireID = Convert.ToInt32(ddlQuestionaire.SelectedValue);
            string Answers = txtNewAnswers.Value;
            //string myval = ShaEncrypt(ViewState["KeyGenerator"].ToString());
            //string value = ShaEncrypt(password.ToLower() + myval.ToLower());

            string QuestionnaireAnswer = Answers;
            string username = txtUserName.Text.ToString().Trim();
            DataTable dtQuest = objLoginDL.GetQuestionnaire_Match(username, QuestionnaireID, QuestionnaireAnswer, ConnKey);
            if (dtQuest.Rows.Count > 0)
            {
                divresetpassword.Visible = true;
            }
            else
            {
                lblmsg.Text = "Please check the given details..";
                return;
            }
        }

        protected void btnAnswerUpdate_Click(object sender, EventArgs e)
        {
            DataTable dtQuest = objLoginDL.GetQAnswers(ConnKey);
            if (dtQuest.Rows.Count > 0)
            {
                for (int i = 0; i < dtQuest.Rows.Count; i++)
                {
                    string user = dtQuest.Rows[i]["UserName"].ToString();
                    string answerold = dtQuest.Rows[i]["Answers"].ToString();
                    //string myval = ShaEncrypt(ViewState["KeyGenerator"].ToString());
                    string value = ShaEncrypt(answerold);
                    string answer = value;
                    DataTable dt = objLoginDL.GetQuestionnaire_Update(user, answer, ConnKey);

                }
            }
            else
            {
                lblmsg.Text = "Please check the given details..";
                return;
            }
        }
    }
}
