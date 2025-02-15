﻿using System;
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
    public partial class AbstractRpt : System.Web.UI.Page
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

            //if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            //{
            //    Response.Redirect("~/Error.aspx");
            //}
            //else
            //{
            //    string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            //    string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            //    int len = http_hos.Length;
            //    if (http_ref.IndexOf(http_hos, 0) < 0)
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }
            //}
            /*KILL COOKIE & clear Caching*/
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
                // pannelOK.Visible = false;
                // Viewdata();
                //random();


            }
        }

        //public void random()
        //{
        //    try
        //    {
        //        string strString = "abcdefghijklmnpqrstuvwxyzABCDQEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //        string num = "";
        //        Random rm = new Random();
        //        for (int i = 0; i < 16; i++)
        //        {
        //            int randomcharindex = rm.Next(0, strString.Length);
        //            char randomchar = strString[randomcharindex];
        //            num += Convert.ToString(randomchar);
        //        }
        //        hf.Value = num;
        //        Session["ASPFIXATION2"] = num;
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}
        //public void check()
        //{
        //    try
        //    {
        //        string cookie_value = null;
        //        string session_value = null;

        //        cookie_value = hf.Value;
        //        session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
        //        if (cookie_value != session_value)
        //        {
        //            System.Web.HttpContext.Current.Session.Abandon();
        //            HttpContext.Current.Response.Buffer = false;
        //            HttpContext.Current.Response.Redirect("~/Error.aspx");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Redirect("~/Error.aspx", false);
        //    }
        //}
        protected void GvHOA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //try
            //{
            //    GvHOA.PageIndex = e.NewPageIndex;
            //    GvHOA.DataBind();
            //}
            //catch (Exception ex)
            //{
            //    ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            //    objCommon.ShowAlertMessage(ex.ToString());
            //}
            try
            {
                GvHOA.PageIndex = e.NewPageIndex;
                if (Session["dt1"] != null)
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)Session["dt1"];
                    Viewdata();
                    GvHOA.DataSource = dt;
                    GvHOA.DataBind();
                    dt.Dispose();
                    decimal net = 0;
                    decimal total = dt.AsEnumerable().Where(row => decimal.TryParse(row["Amount"].ToString(), out net)).Sum(row => net > 0 ? net : 0);
                    GvHOA.FooterRow.Cells[4].Text = "Total";
                    GvHOA.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;

                    GvHOA.FooterRow.Cells[5].Text = total.ToString("N2");
                }
                else
                {
                    this.Viewdata();
                }
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
                objBE.Role =Convert.ToInt32( Session["Role"].ToString());
                objBE.Type_of_Manu = null;
                objBE.SubHead = null;
                objBE.MinorHead = null;
                objBE.DFCode = null;
                objBE.dtfrom = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                objBE.dtTo = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                objBE.Action = "R";
                // DataTable dt = new DataTable();
                dt = objDL.GetPaymentDtls(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    divhoa.Visible = true;
                    //GvHOA.Visible = true;
                    GvHOA.DataSource = dt;
                    GvHOA.DataBind();
                    dt.Dispose();
                    decimal net = 0;
                    decimal total = dt.AsEnumerable().Where(row => decimal.TryParse(row["Amount"].ToString(), out net)).Sum(row => net > 0 ? net : 0);
                    GvHOA.FooterRow.Cells[4].Text = "Total";
                    GvHOA.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;

                    GvHOA.FooterRow.Cells[5].Text = total.ToString("N2");

                    //decimal net = 0;
                    //decimal totalnet = dt.AsEnumerable().Where(row => decimal.TryParse(row["Amount"].ToString(), out net)).Sum(row => net > 0 ? net : 0);

                    //GvHOA.FooterRow.Cells[4].Font.Bold = true;
                    //GvHOA.FooterRow.Cells[4].Text = totalnet.ToString("N2");

                    Button1.Visible = true;
                    //ReptReg.Visible = true;
                    //ReptReg.LocalReport.DataSources.Clear();
                    //ReptReg.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                    //// OR Set Report Path  
                    //ReptReg.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Report_Payment.rdlc");
                    //ReptReg.ShowPrintButton = true;
                    //// Refresh and Display Report  
                    //ReptReg.LocalReport.Refresh();
                }
                else
                {
                    divhoa.Visible = false;
                    //GvHOA.Visible = false;
                    //ReptReg.Visible = false;
                    //objCommon.ShowAlertMessage("No data found");
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void imgbtnExcel_Click1(object sender, EventArgs e)
        {
            // try
            // {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["dt1"];
            Session["dt2"] = null;
            //if (Session["dt2"] == null)
            //{

            //    dt.Columns.Remove("Supplier_Code");
            //    dt.Columns.Remove("Supplier_Name");
            //    dt.Columns.Remove("DeptTransid");
            //    dt.Columns.Remove("HOAccount");
            //    dt.Columns.Remove("Type_Man_Nm");
            //    dt.Columns.Remove("DF_Descr");
            //    dt.Columns.Remove("BankDate");
            //    dt.Columns.Remove("BankCode");
            //    dt.Columns.Remove("ChallanNumber");               
            //    dt.Columns.Remove("BankStatus");

            //}
            Session["dt2"] = dt;
            if (dt.Rows.Count > 0)
            {
                string attachment = "attachment; filename=Payment_Details.xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/vnd.ms-excel";
                string tab = "";
                foreach (DataColumn dc in dt.Columns)
                {
                    Response.Write(tab + dc.ColumnName);
                    tab = "\t";
                }
                Response.Write("\n");
                int i;
                foreach (DataRow dr in dt.Rows)
                {
                    tab = "";
                    for (i = 0; i < dt.Columns.Count; i++)
                    {
                        if (i == 0)
                        {
                            string s = dr[i].ToString();
                            Response.Write(tab + dr[i].ToString());
                            tab = "\t";
                        }
                        else
                        {
                            Response.Write(tab + dr[i].ToString());
                            tab = "\t";
                        }
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
            else
            {
                //lblmsg.Text = "No Data Available";
            }
            // }
            //catch (Exception ex)
            //{
            //    ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            //}
        }
        //protected void PrintAllPages(object sender, EventArgs e)
        //{
        //    GvHOA.AllowPaging = false;
        //    //  GvHOA.AllowPaging = false;
        //    Viewdata();
        //    //GvHOA.DataBind();

        //    StringWriter sw = new StringWriter();

        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    // GvHOA.RenderControl(hw);

        //    string gridHTML = sw.ToString().Replace("\"", "'")

        //        .Replace(System.Environment.NewLine, "");

        //    StringBuilder sb = new StringBuilder();

        //    sb.Append("<script type = 'text/javascript'>");

        //    sb.Append("window.onload = new function(){");

        //    sb.Append("var printWin = window.open('', '', 'left=0");

        //    sb.Append(",top=0,width=1000,height=600,status=0');");

        //    sb.Append("printWin.document.write(\"");

        //    sb.Append(gridHTML);

        //    sb.Append("\");");

        //    sb.Append("printWin.document.close();");

        //    sb.Append("printWin.focus();");

        //    sb.Append("printWin.print();");

        //    sb.Append("printWin.close();};");

        //    sb.Append("</script>");

        //    ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());

        //    GvHOA.AllowPaging = true;
        //    Viewdata();
        //    GvHOA.DataBind();

        //}
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfrm.Text == "")
                {
                    objCommon.ShowAlertMessage("Please Select From Date");
                    return;
                }
                //else
                //{
                //    if (!objValidate.IsDate(txtfrm.Text.Trim()))
                //    {
                //        objCommon.ShowAlertMessage("Please Enter Valid date");
                //        return;
                //    }
                //}
                if (txtto.Text == "")
                {
                    objCommon.ShowAlertMessage("Please Select To Date");
                    return;
                }
                //else
                //{
                //    if (!objValidate.IsDate(txtto.Text.Trim()))
                //    {
                //        objCommon.ShowAlertMessage("Please Enter Valid date");
                //        return;
                //    }
                //}
                objBE.Role = Convert.ToInt32(Session["Role"].ToString());
                objBE.Type_of_Manu = null;
                objBE.SubHead = null;
                objBE.MinorHead = null;
                objBE.DFCode = null;
                objBE.dtfrom = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                objBE.dtTo = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                objBE.Action = "R";
                DataTable dt = new DataTable();
                dt = objDL.GetPaymentDtls(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    Session["dt1"] = dt;
                    divhoa.Visible = true;
                    //imgbtnExcel.Visible = true;
                    //GvHOA.Visible = true;
                    GvHOA.DataSource = dt;
                    GvHOA.DataBind();
                    dt.Dispose();
                    decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("Amount"));
                    GvHOA.FooterRow.Cells[4].Text = "Total";
                    GvHOA.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    GvHOA.FooterRow.Cells[5].Text = total.ToString("N2");
                    Button1.Visible = true;
                    //ReptReg.Visible = true;
                    //ReptReg.LocalReport.DataSources.Clear();
                    //ReptReg.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                    //// OR Set Report Path  
                    //ReptReg.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Report_Payment.rdlc");
                    //ReptReg.ShowPrintButton = true;
                    //// Refresh and Display Report  
                    //ReptReg.LocalReport.Refresh();
                }
                else
                {
                    divhoa.Visible = false;
                    //GvHOA.Visible = false;
                    //ReptReg.Visible = false;
                    objCommon.ShowAlertMessage("No data found");
                }
            }

            catch
            {

            }
        }
        //protected void PrintCurrentPage(object sender, EventArgs e)
        //{
        //    GridView1.PagerSettings.Visible = false;

        //    GridView1.DataBind();

        //    StringWriter sw = new StringWriter();

        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    GridView1.RenderControl(hw);

        //    string gridHTML = sw.ToString().Replace("\"", "'")

        //        .Replace(System.Environment.NewLine, "");

        //    StringBuilder sb = new StringBuilder();

        //    sb.Append("<script type = 'text/javascript'>");

        //    sb.Append("window.onload = new function(){");

        //    sb.Append("var printWin = window.open('', '', 'left=0");

        //    sb.Append(",top=0,width=1000,height=600,status=0');");

        //    sb.Append("printWin.document.write(\"");

        //    sb.Append(gridHTML);

        //    sb.Append("\");");

        //    sb.Append("printWin.document.close();");

        //    sb.Append("printWin.focus();");

        //    sb.Append("printWin.print();");

        //    sb.Append("printWin.close();};");

        //    sb.Append("</script>");

        //    ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());

        //    GridView1.PagerSettings.Visible = true;

        //    GridView1.DataBind();
        //}
    }

}