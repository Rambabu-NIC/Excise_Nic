using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;
using System.Configuration;
using System.Net;
using System.Text;

namespace ExciseAPI.Admin
{
    public partial class InstallementMaster : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();

        protected void Page_Load(object sender, EventArgs e)
        {
         
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && (Session["Role"].ToString() == "1" || Session["Role"].ToString() == "50") && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

                //BindTypeofManf();
                //Viewdata();
                BindData();
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


        public void BindData()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                //objBE.Action = "R";
                dt = ObjMDL.GetInstallments(Session["ConnKey"].ToString());
                if (dt.Rows.Count > 0)
                {
                    objCommon.BindDropDownLists(ddlInstallement, dt, "InstallmentType", "InstallmentNo", "0");
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found For This ");
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }

        protected void ddlInstallement_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.InstallmentNo = Convert.ToInt32(ddlInstallement.SelectedValue);
                dt = ObjMDL.GetInst_dt(objBE, Session["ConnKey"].ToString());
                if (dt.Rows.Count > 0)
                {
                    txtStartDate.Text = dt.Rows[0]["StartDate"].ToString();
                    txtEndDate.Text = dt.Rows[0]["EndDate"].ToString();
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                if (ddlInstallement.SelectedValue.ToString() == "")
                {
                    lblError.Text = "Please Select installment";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtEndDate.Text))
                {
                    lblError.Text = "Please Select End Date";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                objBE.InstallmentNo = Convert.ToInt32(ddlInstallement.SelectedValue);
                objBE.BankDate = Convert.ToDateTime(txtEndDate.Text.ToString());
                objBE.CreatedBy = Session["UsrName"].ToString();
                bool result = ObjMDL.GetInstallmentDates(objBE, Session["ConnKey"].ToString());
                if (result == true)
                {
                    objCommon.ShowAlertMessage("Updated Successfully");
                    Clear();
                    lblError.Visible = false;
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }

        public void Clear()
        {
            ddlInstallement.SelectedIndex = 0;
            txtStartDate.Text = "";
            txtEndDate.Text = "";
        }
    }
}