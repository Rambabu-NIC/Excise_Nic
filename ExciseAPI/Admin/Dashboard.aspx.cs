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

namespace ExciseAPI.Admin
{
    public partial class Dashboard : System.Web.UI.Page
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

          
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "1" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                GetDashboardData();
                // BindTypeofManf();
                // pannelOK.Visible = false;
                // Viewdata();
                //random();


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
        protected void GetDashboardData()
        {
            try
            {

                /*GET  Prescrutiny Green Red status Applicant details*/
                //   objBE.Action = "R";
                DataTable dt = new DataTable();
                dt = objDL.GetDashboardData(ConnKey);
                if (dt.Rows.Count > 0)
                {
                    TotTrns.Text = dt.Rows[0]["TotTransations"].ToString() == "" ? "0" : dt.Rows[0]["TotTransations"].ToString();
                    TotTodaytrns.Text = dt.Rows[0]["TotTodayTarns"].ToString() == "" ? "0" : dt.Rows[0]["TotTodayTarns"].ToString();
                    // decimal tot = Convert.ToInt64(dt.Rows[0]["TotalAmt"].ToString() == "" ? "0" : dt.Rows[0]["TotalAmt"].ToString());
                    // TotAmt.Text =tot.ToString("N2");
                    //TotTamt.Text = dt.Rows[0]["TotalTAmt"].ToString() == "" ? "0" : dt.Rows[0]["TotalTAmt"].ToString();

                    string fare = dt.Rows[0]["TotalAmt"].ToString();
                    decimal parsed = decimal.Parse(fare, CultureInfo.InvariantCulture);
                    CultureInfo hindi = new CultureInfo("hi-IN");
                    string totalAmt = string.Format(hindi, "{0:c}", parsed);
                    TotAmt.Text = totalAmt;

                    string Tfare = dt.Rows[0]["TotalTAmt"].ToString();
                    decimal Tparsed = decimal.Parse(Tfare, CultureInfo.InvariantCulture);
                    CultureInfo Thindi = new CultureInfo("hi-IN");
                    string TtotalAmt = string.Format(Thindi, "{0:c}", Tparsed);
                    TotTamt.Text = TtotalAmt;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UserId"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");

            }
        }
        protected void btn_Submit_Click(object sender, EventArgs e)
        {


        }
    }
}