using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Retailer
{
    public partial class RetailerDashboard : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
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
            if (Session["Role"] != null && Session["Role"].ToString() == "12" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                //lblUSer.Text = Session["UsrName"].ToString();
                // BindTypeofManf();

                //Viewdata();
                random();


            }
        }
        protected void lnkApplicationRecieved_Click(object sender, EventArgs e)
        {
            getData("0");
        }
        protected void lnkPendingSHO_Click(object sender, EventArgs e)
        {
            getData("1");
        }
        protected void lnkPendingDPEO_Click(object sender, EventArgs e)
        {
            getData("3");
        }
        protected void lnkApplicationApproved_Click(object sender, EventArgs e)
        {
            getData("4");
        }
        protected void lnkApplicationRejected_Click(object sender, EventArgs e)
        {
            getData("5");
        }
        protected void getData(string type)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                objBE.Rule7 = type;
                appType.Text = type;
                objBE.ExDistCode = Session["EXDIST_CODE"].ToString();

                String Date1 = null;
                String Date2 = null;
                if (!string.IsNullOrEmpty(txtfrm.Text) && !string.IsNullOrEmpty(txtto.Text))
                {
                    divretailer2.Visible = true;
                    Date1 = txtfrm.Text;
                    Date2 = txtto.Text;
                    objBE.dtfrom = Convert.ToDateTime(Date1);
                    objBE.dtTo = Convert.ToDateTime(Date2);

                }
                else
                {
                    objBE.dtfrom = Convert.ToDateTime(Date1);
                    objBE.dtTo = Convert.ToDateTime(Date2);

                }
                objBE.Action = "RData";

                dt = objDL.RetailerDashboard(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    txtfrm.Text = string.Empty;
                    txtto.Text = string.Empty;
                    GvRptDtls.Visible = true;
                    GvRptDtls.DataSource = dt;
                    GvRptDtls.DataBind();
                    dt.Dispose();
                }
                else
                {
                    txtfrm.Text = string.Empty;
                    txtto.Text = string.Empty;
                    divretailer2.Visible = false;
                    GvRptDtls.Visible = false;
                    objCommon.ShowAlertMessage("No Data Found");
                    return;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void GvRptDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                GvRptDtls.PageIndex = e.NewPageIndex;
                getData(appType.Text.ToString());

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }
        }
        protected void Viewdata()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Action = "RD";
                objBE.ExDistCode = Session["EXDIST_CODE"].ToString();
                //objBE.ExStation = Session["SHOID"].ToString();
                String Date1 = null;
                String Date2 = null;
                if (!string.IsNullOrEmpty(txtfrm.Text) && !string.IsNullOrEmpty(txtto.Text))
                {

                    Date1 = txtfrm.Text;
                    Date2 = txtto.Text;

                    objBE.dtfrom = Convert.ToDateTime(Date1);
                    objBE.dtTo = Convert.ToDateTime(Date2);

                }
                else
                {
                    objBE.dtfrom = Convert.ToDateTime(Date1);
                    objBE.dtTo = Convert.ToDateTime(Date2);

                }
                dt = objDL.RetailerDashboard(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    divretailer1.Visible = true;
                    GvRpt.Visible = true;
                    GvRpt.DataSource = dt;
                    Div1.Visible = true;
                    GvRpt.DataBind();
                    dt.Dispose();
                }
                else
                {
                    divretailer1.Visible = false;
                    GvRpt.Visible = false;
                    objCommon.ShowAlertMessage("No Data Found");
                    return;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
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

        protected void btnGet_Click(object sender, EventArgs e)
        {
            if (txtfrm.Text.Trim() == "")
            {

                objCommon.ShowAlertMessage("Please Enter From Date");
                txtfrm.Focus();
                return;
            }
            if (txtto.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Please Enter To Date");
                txtto.Focus();
                return;
            }


            Viewdata();
        }
    }
}