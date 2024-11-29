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

namespace ExciseAPI.ECMS
{
    public partial class ComplaintStatusReport : BasePage
    {
        ECMS_BE ECMSBE = new ECMS_BE();
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        ECMS_DAL ECMSDAL = new ECMS_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        string headername = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDistrict();
            }
        }
        public void BindDistrict()
        {
            try
            {

                objBE.Statecode = "36";
                DataTable dt1 = new DataTable();
                objBE.Action = "R";
                dt1 = ObjMDL.GetDistDL(objBE, ConnKey);
                objCommon.BindDropDownLists(ddldist, dt1, "DistName", "DistCode", "0");
                ddldist.Items.Insert(1, new ListItem("ALL", "99"));
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindComplaintCount()
        {
            DataTable dt = new DataTable();
            objBE.DistCode = ddldist.SelectedValue;
            try
            {
                divgridcount.Visible = false;
                dt = ECMSDAL.CountComplaintStatus(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    divgridcount.Visible = true;
                    grvcount.DataSource = dt;
                    grvcount.DataBind();

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindGrid()
        {
            //lblstatusreport.Text = "District Wise/All";
            DataTable dt = new DataTable();
            objBE.DistCode = ddldist.SelectedValue;
            try
            {
                divgriddetails.Visible = false;
                btnAvailableImageExportToPdf.Visible = false;
                btnAvailableImageExportToExcel.Visible = false;
                dt = ECMSDAL.GetComplaintStatus_Report(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    lblError.Text = "";
                    divgrid.Visible = true;
                    DivGeneratedDate.Visible = true;
                    divgriddetails.Visible = true;
                    btnAvailableImageExportToPdf.Visible = true;
                    btnAvailableImageExportToExcel.Visible = true;
                    gvdetails.DataSource = dt;
                    gvdetails.DataBind();
                }
                else
                {
                    divgrid.Visible = false;
                    DivGeneratedDate.Visible = false;
                    divgriddetails.Visible = false;
                    lblError.Text = "No Data Found";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindComplaintCount();
            BindGrid();
        }

        protected void btnAvailableImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {

            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            string GenerateFileName = lblstatusreport.Text + " Complaint Report" + ".Pdf";
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }
        protected void btnAvailableImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            string GenerateFileName = lblstatusreport.Text + " Complaint Report" + ".xls";
            GridView gridviewid = gvdetails;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }

        protected void lnkNewFilled_Click(object sender, EventArgs e)
        {
            headername = grvcount.Columns[0].HeaderText.ToString().Trim();
            getAllDashboard(headername.ToString().Trim());
        }
        protected void lnkUnattendedFilled_Click(object sender, EventArgs e)
        {
            headername = grvcount.Columns[1].HeaderText.ToString().Trim();
            getAllDashboard(headername.ToString().Trim());
        }
        protected void lnkAssignedtoDCFilled_Click(object sender, EventArgs e)
        {
            headername = grvcount.Columns[2].HeaderText.ToString().Trim();
            getAllDashboard(headername.ToString().Trim());
        }
        protected void lnkAssignedtoEnquiryOfficerFilled_Click(object sender, EventArgs e)
        {
            headername = grvcount.Columns[3].HeaderText.ToString().Trim();
            getAllDashboard(headername.ToString().Trim());
        }
        protected void lnkEnquiryCompletedFilled_Click(object sender, EventArgs e)
        {
            headername = grvcount.Columns[4].HeaderText.ToString().Trim();
            getAllDashboard(headername.ToString().Trim());
        }
        protected void lnkInvalidFilled_Click(object sender, EventArgs e)
        {
            headername = grvcount.Columns[5].HeaderText.ToString().Trim();
            getAllDashboard(headername.ToString().Trim());
        }
        protected void lnkClosedFilled_Click(object sender, EventArgs e)
        {
            headername = grvcount.Columns[6].HeaderText.ToString().Trim();
            getAllDashboard(headername.ToString().Trim());
        }
        protected void lnkReviewFilled_Click(object sender, EventArgs e)
        {
            headername = grvcount.Columns[7].HeaderText.ToString().Trim();
            getAllDashboard(headername.ToString().Trim());
        }
        protected void lnkATRPreliminarySubmittedFilled_Click(object sender, EventArgs e)
        {
            headername = grvcount.Columns[8].HeaderText.ToString().Trim();
            getAllDashboard(headername.ToString().Trim());
        }
        protected void lnkATRSubmittedFilled_Click(object sender, EventArgs e)
        {
            headername = grvcount.Columns[9].HeaderText.ToString().Trim();
            getAllDashboard(headername.ToString().Trim());
        }
        protected void getAllDashboard(string value)
        {
            lblstatusreport.Text = value;
            DataTable dt = new DataTable();
            objBE.DistCode = ddldist.SelectedValue;
            try
            {
                divgriddetails.Visible = false;
                btnAvailableImageExportToPdf.Visible = false;
                btnAvailableImageExportToExcel.Visible = false;
                dt = ECMSDAL.Getdisplaycatwise(objBE, ConnKey, value);
                //dt = objDL.Getdisplaycatwise(ConnKey, value);
                if (dt.Rows.Count > 0)
                {
                    lblError.Text = "";
                    divgrid.Visible = true;
                    DivGeneratedDate.Visible = true;
                    divgriddetails.Visible = true;
                    btnAvailableImageExportToPdf.Visible = true;
                    btnAvailableImageExportToExcel.Visible = true;
                    gvdetails.DataSource = dt;
                    gvdetails.DataBind();
                }
                else
                {
                    divgrid.Visible = false;
                    DivGeneratedDate.Visible = false;
                    divgriddetails.Visible = false;
                    lblError.Text = "No Data Found";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}