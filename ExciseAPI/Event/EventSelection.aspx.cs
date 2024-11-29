using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Event
{
    public partial class EventSelection : System.Web.UI.Page
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

                // random();



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


        protected void rblEventSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (rblEventSelection.SelectedValue == "1")
                //{
                //    Response.Redirect("~/EventRegistration.aspx", false);
                //}
                //else if (rblEventSelection.SelectedValue == "2")
                //{
                //    Response.Redirect("~/EditEventRegistration.aspx", false);
                //}
                //else if (rblEventSelection.SelectedValue == "3")
                //{
                //    Response.Redirect("~/UploadDoc.aspx", false);
                //}
                //else if (rblEventSelection.SelectedValue == "4")
                //{
                //    Response.Redirect("~/PaymentDtls.aspx", false);
                //}
            }
            catch (Exception ex) { }
        }
        protected void btnReg_Click(object sender, EventArgs e)
        {
            Panel3.Visible = true;
            Panel2.Visible = false;
            //  Response.Redirect("~/EventRegistration.aspx", false);
        }
        protected void btnRuser_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            getparameter.Visible = true;
            lblApPStatus.Text = "E";
            //Session["RegId"] = txtRegistrationNo.Text;
            //Response.Redirect("~/EditEventRegistration.aspx", false);
            //Panel2.Visible = false;
        }
        protected void btnUploadDoc_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel3.Visible = false;
            getparameter.Visible = true;
            lblApPStatus.Text = "U";
            //Session["RegId"] = txtRegistrationNo.Text;
            //Response.Redirect("~/EditEventRegistration.aspx", false);
            //Panel2.Visible = false;
        }
        protected void btnPaymentD_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel3.Visible = false;
            getparameter.Visible = true;
            lblApPStatus.Text = "P";

        }
        protected void btnSubmitApp_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Panel3.Visible = false;
            getparameter.Visible = true;
            lblApPStatus.Text = "S";

        }



        //protected void btnEdit_Click(object sender, EventArgs e)
        protected void EditAppPage()
        {
            //Panel2.Visible = true;
            Session["RegId"] = txtRegistrationNo.Text;
            Response.Redirect("~/Event/EditEventRegistration.aspx", false);

        }
        //protected void btnUploadDocs_Click(object sender, EventArgs e)
        protected void UploadDocPage()
        {
            //Panel2.Visible = true;
            Session["RegNo"] = txtRegistrationNo.Text;
            Response.Redirect("~/Event/UploadDoc.aspx", false);

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (txtRegistrationNo.Text != "" && txtMobileNumber.Text != "")
            {
                objBE = new Supplier_BE();
                DataTable dt1 = new DataTable();
                objBE.Reg_Code = txtRegistrationNo.Text;// Session["RegId"].ToString();//"360200001423"; //
                objBE.Action = "R";
                dt1 = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    Session["RegId"] = txtRegistrationNo.Text.Trim(); //"360200001423"; //
                    Session["RegMobileNo"] = txtMobileNumber.Text.Trim();
                    // divEdit.Visible = true;
                    if (lblApPStatus.Text == "E")
                    {
                        EditAppPage();
                    }
                    else if (lblApPStatus.Text == "U")
                    {
                        UploadDocPage();
                    }
                    else if (lblApPStatus.Text == "P")
                    {
                        PaymentPage();
                    }
                    else if (lblApPStatus.Text == "S")
                    {
                        SubmitAppPage();
                    }

                }
                else
                {
                    objCommon.ShowAlertMessage("Application already Submitted can't be edited");
                    //divEdit.Visible = false;
                    return;
                }
            }
            else
            {
                objCommon.ShowAlertMessage("Enter Registration Number and Mobile Number");
                txtRegistrationNo.Focus();
            }


            //txtRegistrationNo.Text;
        }


        //protected void btnPayment_Click1(object sender, EventArgs e)
        protected void PaymentPage()
        {
            Session["RegId"] = txtRegistrationNo.Text;
            Response.Redirect("~/Event/PaymentDtls.aspx", false);
        }
        protected void SubmitAppPage()
        {
            Session["RegId"] = txtRegistrationNo.Text;
            Response.Redirect("~/Event/SubmitEventRegistration.aspx", false);
        }
        protected void RbTypeP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbTypeP.SelectedValue == "1")
            {
                Panel2.Visible = false;
                Panel3.Visible = false;
                Response.Redirect("~/Event/EventRegistration.aspx", false);
            }
            else
            {

                Panel2.Visible = true;
                getparameter.Visible = true;
                lblApPStatus.Text = "E";
            }
        }
    }
}