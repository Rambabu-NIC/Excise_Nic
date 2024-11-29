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

namespace ExciseAPI.SHO
{
    public partial class SHO : System.Web.UI.Page
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
                objBE.ExStation = Session["SHOID"].ToString();// Session["ExStationCode"].ToString();
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
                objBE.Action = "SHORDT";

                dt = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    Div3.Visible = true;
                    GvRptDtls.Visible = true;
                    dtAppRegNo = dt;
                    GvRptDtls.DataSource = dt;
                    GvRptDtls.DataBind();
                    dt.Dispose();
                }
                else
                {
                    Div3.Visible = false;
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
                objBE.Action = "SHODB";
                objBE.ExDistCode = Session["EXDIST_CODE"].ToString();
                objBE.ExStation = Session["SHOID"].ToString();
                //objBE.ExStation = Session["SHOID"].ToString();// 

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


        public DataTable dtAppRegNo
        {
            get
            {
                return ViewState["dtAppRegNo"] as DataTable;
            }
            set
            {
                ViewState["dtAppRegNo"] = value;
            }
        }


        protected void GvRptDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkView = e.Row.FindControl("lnkview") as LinkButton;
                int Status = Convert.ToInt16(dtAppRegNo.Rows[0]["Status"].ToString());
                //byte[] Document = Encoding.ASCII.GetBytes(dtComplaints.Tables[0].Rows[0]["DocumentFile"].ToString());
                if (Status > 0)
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

        protected void GvRptDtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                //string CompalientID = e.CommandArgument.ToString();
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string AppRegNo = commandArgs[0];
                int Status = Convert.ToInt16(commandArgs[1]);

                if (Status == 1)
                {
                    Session["AppRegNo_SHO"] = AppRegNo.ToString();
                    Response.Redirect("~/SHO/EventPermission?id=" + AppRegNo + "", false);
                }
                else if (Status == 2)
                {
                    objCommon.ShowAlertMessage("Return for Balance Amount..");
                }
                else if (Status == 3)
                {
                    objCommon.ShowAlertMessage("Under process at DPEO..");   
                }
                else if(Status == 4)
                {
                    objCommon.ShowAlertMessage("Permit Already Generated..");
                }
                //else if (!string.IsNullOrEmpty(CompalientID) && (Role == 21 || Role == 27))//(Status == 3 || Status == 9 || Status ==10 || Status ==5))
                //{
                //    Response.Redirect("~/ECMS/DC_Form.aspx?id=" + CompalientID + "", false);
                //}
                //else if (!string.IsNullOrEmpty(CompalientID) && Role == 2)//(Status == 4 || Status ==9))
                //{
                //    Response.Redirect("~/ECMS/EnquiryForm.aspx?id=" + CompalientID + "", false);
                //}
            }

        }
    }
}