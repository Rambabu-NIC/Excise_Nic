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
    public partial class Event_Update : System.Web.UI.Page
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
            DataTable dt = new DataTable();
            divEvent.Visible = false;
            objBE.MobNo = txtMobileNumber.Text;
            objBE.Email = txtEmail.Text;
            objBE.Date = Convert.ToDateTime(txtDate.Text);
            dt = objDL.GetEvent(objBE, ConnKey);
            if (dt.Rows.Count > 0)
            {
                gvEvent.DataSource = dt;
                gvEvent.DataBind();
                divEvent.Visible = true;
            }
            else
            {
                lblError.Text = "No Data Found";
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}