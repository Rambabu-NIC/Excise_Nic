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
using System.Globalization;

namespace ExciseAPI.Supplier
{
    public partial class Supplier_Report : BasePage
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);

        protected void Page_Load(object sender, EventArgs e)
        {
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "3" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
       

       
        protected void GetSupplierData()
        {
            if (string.IsNullOrEmpty(txtfrm.Text))
            {
                lblError.Text = "Please Select From Date";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(txtto.Text))
            {
                lblError.Text = "Please Select To Date";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            GvRptDtls.DataSource = null;
            GvRptDtls.DataBind();

            Div2.Visible = false;
            try
            {


                DataTable dt = new DataTable();
                objBE.SupplierCode = Session["UsrName"].ToString();
                objBE.FDate = Convert.ToDateTime(txtfrm.Text).ToString();
                objBE.TDate = Convert.ToDateTime(txtto.Text).ToString();


                dt = objDL.Supplier(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    Div2.Visible = true;
                    DivGeneratedDate.Visible = true;
                    divgriddetails.Visible = true;
                    //GvRptDtls.Visible = true;
                    GvRptDtls.DataSource = dt;
                    GvRptDtls.DataBind();
                    dt.Dispose();
                    ViewState["FromDate"] = txtfrm.Text.ToString();
                    //txtfrm.Text = string.Empty;
                    ViewState["ToDate"] = txtto.Text.ToString();
                    //divYearDiv.Visible = true;
                    btnEventImageExportToExcel.Visible = true;
                    //txtto.Text = string.Empty;
                }
                else
                {
                    Div2.Visible = false;
                    objCommon.ShowAlertMessage("No Data Found");
                }



            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //objCommon.ShowAlertMessage(ex.ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


       
        protected void GvRptDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            //try
            //{
            //    GvRptDtls.PageIndex = e.NewPageIndex;
            //    GetSupplierData();



            //}
            //catch (Exception ex)
            //{
            //    ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            //    objCommon.ShowAlertMessage(ex.ToString());
            //}
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            GetSupplierData();
        }

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


            //DataTable dt = new DataTable();
            //dt = (DataTable)Session["dt1"];
            //Session["dt2"] = null;
            ////if (Session["dt2"] == null)
            ////{

            ////    dt.Columns.Remove("Supplier_Code");
            ////    dt.Columns.Remove("Supplier_Name");
            ////    dt.Columns.Remove("DeptTransid");
            ////    dt.Columns.Remove("HOAccount");
            ////    dt.Columns.Remove("Type_Man_Nm");
            ////    dt.Columns.Remove("DF_Descr");
            ////    dt.Columns.Remove("BankDate");
            ////    dt.Columns.Remove("BankCode");
            ////    dt.Columns.Remove("ChallanNumber");               
            ////    dt.Columns.Remove("BankStatus");

            ////}
            //Session["dt2"] = dt;
            //if (dt.Rows.Count > 0)
            //{
            //    string attachment = "attachment; filename=Event_Details.xls";
            //    Response.ClearContent();
            //    Response.AddHeader("content-disposition", attachment);
            //    Response.ContentType = "application/vnd.ms-excel";
            //    string tab = "";
            //    foreach (DataColumn dc in dt.Columns)
            //    {
            //        Response.Write(tab + dc.ColumnName);
            //        tab = "\t";
            //    }
            //    Response.Write("\n");
            //    int i;
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        tab = "";
            //        for (i = 0; i < dt.Columns.Count; i++)
            //        {
            //            if (i == 0)
            //            {
            //                string s = dr[i].ToString();
            //                Response.Write(tab + dr[i].ToString());
            //                tab = "\t";
            //            }
            //            else
            //            {
            //                Response.Write(tab + dr[i].ToString());
            //                tab = "\t";
            //            }
            //        }
            //        Response.Write("\n");
            //    }
            //    Response.End();
            //}
            //else
            //{
            //    //lblmsg.Text = "No Data Available";
            //}

        }
    }
}