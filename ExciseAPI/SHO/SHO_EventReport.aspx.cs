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
    public partial class SHO_EventReport : BasePage
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
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "2" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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


        public void BindGrid()
        {
            try
            {
                if (validateDates())
                {
                    Div3.Visible = false;
                    hfDate.Value = "1";
                    //Session["DateHidden"] = "1";
                    dateGrid.Text = "1";
                    objBE.UserName = Session["EXDIST_CODE"].ToString();
                    objBE.dtfrom = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                    objBE.dtTo = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                    objBE.Action = "Total";
                    objBE.SHOID = Session["SHOID"].ToString();
                    DataTable dt = new DataTable();
                    dt = objDL.GetSHOForEvent(objBE, ConnKey);

                    // Session["dt1"] = dt;
                    if (dt.Rows.Count > 0)
                    {
                        Div2.Visible = true;
                        Div3.Visible = false;
                        //GvRpt.Visible = true;
                        GvRpt.DataSource = dt;
                        GvRpt.DataBind();
                        dt.Dispose();
                    }
                    else
                    {
                        Div2.Visible = false;
                        //GvRpt.Visible = false;
                        objCommon.ShowAlertMessage("No Data Found");
                        txtfrm.Text = "";
                        txtto.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //objCommon.ShowAlertMessage(ex.ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected bool validateDates()
        {
            if (txtfrm.Text == "")
            {
                objCommon.ShowAlertMessage("Please Select From Date");
                return false;
            }
            if (txtto.Text == "")
            {
                objCommon.ShowAlertMessage("Please Select To Date");
                return false;
            }
            if (txtfrm.Text != "" && txtto.Text != "")
            {
                DateTime fromDt = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                DateTime toDt = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                if (toDt < fromDt)
                {
                    objCommon.ShowAlertMessage("Please check the dates, To date must be greater than From Date");
                    return false;
                }
            }

            return true;
        }


        protected void lnkApplicationsFilled_Click(object sender, EventArgs e)
        {

            getAllDashboard("A", "A", 0);
        }
        protected void getAllDashboard(string value, string gridDataValue, int Status)
        {


            gridData.Text = gridDataValue;// "A";

            if (string.IsNullOrEmpty(dateGrid.Text.ToString()))
            {
                getData(value);
            }
            else if (dateGrid.Text.ToString() == "1")
            {
                getData(value);
            }




        }

        protected void getData(string type)
        {
            Div3.Visible = false;
            GvRptDtls.Visible = false;
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                objBE.UserName = Session["EXDIST_CODE"].ToString();
                objBE.SHOID = Session["SHOID"].ToString();
                objBE.dtfrom = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                objBE.dtTo = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;


                objBE.Rule7 = type;
                appType.Text = type;
                if (type == "A")
                    objBE.Action = "Reg";
                else if (type == "P")
                    objBE.Action = "PAmount";
                else if (type == "0")
                    objBE.Action = "Received";
                else if (type == "1")
                    objBE.Action = "SHO";
                else if (type == "2")
                    objBE.Action = "DAmount";
                else if (type == "3")
                    objBE.Action = "DPEO";
                else if (type == "4")
                    objBE.Action = "Permit";
                else
                    objBE.Action = "Rejected";


                dt = objDL.GetSHOForEvent(objBE, ConnKey);

                Session["dt1"] = null;
                Session["dt1"] = dt;


                if (dt.Rows.Count > 0)
                {
                    Div3.Visible = true;
                    DivGeneratedDate.Visible = true;
                    divgriddetails.Visible = true;
                    btnEventImageExportToExcel.Visible = true;
                    GvRptDtls.Visible = true;
                    GvRptDtls.DataSource = dt;
                    GvRptDtls.DataBind();
                    dt.Dispose();
                    ViewState["FromDate"] = txtfrm.Text.ToString();
                    ViewState["ToDate"] = txtto.Text.ToString();

                }
                else
                {
                    Div3.Visible = false;
                    DivGeneratedDate.Visible = false;
                    divgriddetails.Visible = false;
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

        protected void lnkApplicationsPaymentMade_Click(object sender, EventArgs e)
        {
            getAllDashboard("P", "A", 0);
        }
        protected void lnkApplicationRecieved_Click(object sender, EventArgs e)
        {
            getAllDashboard("0", "A", 0);

        }
        protected void lnkPendingSHO_Click(object sender, EventArgs e)
        {
            getAllDashboard("1", "A", 1);
        }
        protected void lnkReturnSHO_Click(object sender, EventArgs e)
        {
            getAllDashboard("2", "A", 2);
        }


        protected void GvRptDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                GvRptDtls.PageIndex = e.NewPageIndex;
                if (gridData.Text == "A")
                {
                    if (dateGrid.Text.ToString() == "1" || string.IsNullOrEmpty(dateGrid.Text.ToString()))
                        getData(appType.Text.ToString());

                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }
        }
        protected void lnkPendingDPEO_Click(object sender, EventArgs e)
        {
            getAllDashboard("3", "A", 3);
        }
        protected void lnkApplicationApproved_Click(object sender, EventArgs e)
        {
            getAllDashboard("4", "A", 4);
        }
        protected void lnkApplicationRejected_Click(object sender, EventArgs e)
        {
            getAllDashboard("5", "A", 5);
        }


        protected void btnGet_Click(object sender, EventArgs e)
        {

            Div2.Visible = true;
            BindGrid();

        }


        protected void btnEventImageExportToExcel_Click(object sender, ImageClickEventArgs e)

        {

            divheading.Visible = true;

            string GenerateFileName = "Event Permit Report" + ".xls";
            GridView gridviewid = GvRptDtls;
            gridviewid.AllowPaging = true;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }

        protected void GvRptDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find the Label control inside the TemplateField
                Label lblMobile = (Label)e.Row.FindControl("lblAppNo");

                if (lblMobile != null)
                {
                    string mobileNumber = lblMobile.Text;

                    // Ensure the mobile number is exactly 10 digits long
                    if (mobileNumber.Length == 10)
                    {
                        // Mask the first 6 digits of the mobile number
                        string maskedMobile = new string('*', 6) + mobileNumber.Substring(6);
                        lblMobile.Text = maskedMobile; // Replace the original number with the masked one
                    }
                }
            }
        }
    }
}