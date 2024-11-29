using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;

namespace ExciseAPI.NICAdmin
{
    public partial class EventPermitReport : BasePage
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
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "9" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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

                //BindDistData("0");
                //random();
                //BindMandal();
                // BindExciseDistrict();


                //ddlExStation.Visible = false;

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
                    string FromDate = null;
                    string ToDate = null;
                    if (!string.IsNullOrEmpty(txtfrm.Text.ToString()) && !string.IsNullOrEmpty(txtto.Text.ToString()))
                    {
                        FromDate = txtfrm.Text.ToString();
                        ToDate = txtto.Text.ToString();
                        objBE.from = FromDate;
                        objBE.To = ToDate;
                    }
                    else
                    {
                        objBE.from = FromDate;
                        objBE.To = ToDate;
                    }
                    objBE.Action = "PENG";
                    DataTable dt = new DataTable();
                    dt = objDL.GetPaymentForEvent(objBE, ConnKey);

                    // Session["dt1"] = dt;
                    if (dt.Rows.Count > 0)
                    {
                        Div3.Visible = true;
                        //GvRpt.Visible = true;
                        GvRpt.DataSource = dt;
                        GvRpt.DataBind();
                        dt.Dispose();
                    }
                    else
                    {
                        Div3.Visible = false;
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
            if (string.IsNullOrEmpty(txtfrm.Text))
            {
                lblError.Text = "Please Select From Date";
                lblError.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (string.IsNullOrEmpty(txtto.Text))
            {
                lblError.Text = "Please Select To Date";
                lblError.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            //if (txtfrm.Text != "" && txtto.Text != "")
            //{
            //    DateTime fromDt = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            //    DateTime toDt = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            //    if (toDt < fromDt)
            //    {
            //        objCommon.ShowAlertMessage("Please check the dates, To date must be greater than From Date");
            //        return false;
            //    }
            //}

            return true;
        }


        protected void lnkApplicationsFilled_Click(object sender, EventArgs e)
        {

            getAllDashboard("A", "A", 0);
        }
        protected void getAllDashboard(string value, string gridDataValue, int Status)
        {
            //pannelOK.Visible = false;

            gridData.Text = gridDataValue;// "A";

            if (string.IsNullOrEmpty(dateGrid.Text.ToString()))
            {
                getData(value);
            }
            else if (dateGrid.Text.ToString() == "1")
            {
                getData(value);
            }
            //else if (dateGrid.Text.ToString() == "2")
            //{
            //    getDataReg(value);
            //}



        }
       
        protected void getData(string type)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                //Session["DateHidden"] 
                //if (string.IsNullOrEmpty(hfDate.Value))

                //objBE.BdrEast = "1";
                String FromDate = null;
                String ToDate = null;
                if (!string.IsNullOrEmpty(txtfrm.Text.ToString()) && !string.IsNullOrEmpty(txtto.Text.ToString()))
                {
                    FromDate = txtfrm.Text.ToString();
                    ToDate = txtto.Text.ToString();
                    objBE.from = FromDate;
                    objBE.To = ToDate;
                }
                else
                {
                    objBE.from = FromDate;
                    objBE.To = ToDate;
                }


                objBE.Rule7 = type;
                appType.Text = type;//set
                if (type == "A")
                    objBE.Action = "DBAD";
                else if (type == "P")
                    objBE.Action = "DBPD";//added
                else if (type == "0")
                    objBE.Action = "DBRDT";
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
                
                // objBE.Action = "DBRDT";
                dt = objDL.GetPaymentForEvent(objBE, ConnKey);

                Session["dt1"] = null;
                Session["dt1"] = dt;


                if (dt.Rows.Count > 0)
                {
                    Div3.Visible = true;
                    DivGeneratedDate.Visible = true;
                    divgriddetails.Visible = true;
                    //btnEventImageExportToPdf.Visible = true;
                    btnEventImageExportToExcel.Visible = true;
                    GvRptDtls.Visible = true;
                    GvRptDtls.DataSource = dt;
                    GvRptDtls.DataBind();
                    dt.Dispose();
                    ViewState["FromDate"] = txtfrm.Text.ToString();
                    txtfrm.Text = string.Empty;
                    ViewState["ToDate"] = txtto.Text.ToString();
                    txtto.Text = string.Empty;
                    //lblPaymentDetailsNo.Visible = false;
                    //dltPaymentDetails.Visible = false;
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
                    //else if (dateGrid.Text.ToString() == "2")
                    //    getDataReg(appType.Text.ToString());
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

        //protected void btnEventImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        //{
        //    divheading.Visible = true;
            
        //    GridView gridviewid = GvRptDtls;
        //    gridviewid.AllowPaging = false;
        //    string GenerateFileName = "Event Permit Report" + ".Pdf";

        //    System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
        //    lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
        //    lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
        //    ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        //}

        protected void btnEventImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
           
            string GenerateFileName = "Event Permit Report" + ".xls";
            GridView gridviewid = GvRptDtls;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
            lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
    }
}