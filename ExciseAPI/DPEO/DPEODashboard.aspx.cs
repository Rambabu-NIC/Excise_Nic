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

namespace ExciseAPI.DPEO
{
    public partial class DPEODashboard : System.Web.UI.Page
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
            if (Session["Role"] != null && Session["Role"].ToString() == "4" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
        //protected void lnkApplicationsFilled_Click(object sender, EventArgs e)
        //{
        //    getData("A");
        //}
        //protected void lnkApplicationsPaymentMade_Click(object sender, EventArgs e)
        //{
        //    getData("P");
        //}
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
                objBE.Action = "DPEORDT";

                dt = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    GvRptDtls.Visible = true;
                    GvRptDtls.DataSource = dt;
                    GvRptDtls.DataBind();
                    dt.Dispose();
                }
                else
                {
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
                objBE.Action = "DPEODB";
                objBE.ExDistCode = Session["EXDIST_CODE"].ToString();
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
                dt = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    GvRpt.Visible = true;
                    GvRpt.DataSource = dt;
                    Div1.Visible = true;
                    GvRpt.DataBind();
                    dt.Dispose();
                }
                else
                {
                    GvRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
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