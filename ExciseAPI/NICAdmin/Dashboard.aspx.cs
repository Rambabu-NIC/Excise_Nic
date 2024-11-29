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
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Http;

namespace ExciseAPI.NICAdmin
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
        SupplierDataHandler supplierDataHandler = new SupplierDataHandler();
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

            }
            getgetSupplierCount();
            getDistilleryCount();
            getBreweryCount();
            getWineryCount();
            getMicroBreweryCount();

            //count_event_app_pay();
            //count_event_app_reg();
            //event_app_reg_list();
            //event_app_pay_list();
            //get_monthlydata_barchart();

        }
        //----------------------------------------------------------------------------------------------
        //Supplier
        public void getgetSupplierCount()
        {
            DataTable dt = null;
            dt = objDL.getPrimaryDistilleryCount(ConnKey);
            DataRow row = dt.Rows[0];
            decimal value = Convert.ToDecimal(row["No_manfactures"]);
            btnPrimaryDistillery.Text = value.ToString("N0");
        }

        public void getDistilleryCount()
        {
            DataTable dt = null;
            dt = objDL.getDistilleryCount(ConnKey);
            DataRow row = dt.Rows[0];
            decimal value = Convert.ToDecimal(row["No_manfactures"]);
            btnDistillery.Text = value.ToString("N0");
        }
        public void getBreweryCount()
        {
            DataTable dt = null;
            dt = objDL.getBreweryCount(ConnKey);
            DataRow row = dt.Rows[0];
            decimal value = Convert.ToDecimal(row["No_manfactures"]);
            btnBrewery.Text = value.ToString("N0");
        }
        public void getWineryCount()
        {
            DataTable dt = null;
            dt = objDL.getWineryCount(ConnKey);
            DataRow row = dt.Rows[0];
            decimal value = Convert.ToDecimal(row["No_manfactures"]);
            btnWinery.Text = value.ToString("N0");
        }
        public void getMicroBreweryCount()
        {
            DataTable dt = null;
            dt = objDL.getMicroBreweryCount(ConnKey);
            DataRow row = dt.Rows[0];
            decimal value = Convert.ToDecimal(row["No_manfactures"]);
            btnMicroBrewery.Text = value.ToString("N0");
        }
        public void btnPrimaryDistillery_Click(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            Button btn = (Button)sender;
            string MFType = btn.CommandArgument;
            html = supplierDataHandler.GetSupplierdataList(MFType);
            tblSupplierdataList.InnerHtml = html.ToString();
            statusTable.Style["display"] = "block";
            card_cont.Style["display"] = "none";
        }

        public void btnDistillery_Click(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            Button btn = (Button)sender;
            string MFType = btn.CommandArgument;
            html = supplierDataHandler.GetSupplierdataList(MFType);
            tblSupplierdataList.InnerHtml = html.ToString();
            statusTable.Style["display"] = "block";
            card_cont.Style["display"] = "none";
        }
        public void btnBrewery_Click(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            Button btn = (Button)sender;
            string MFType = btn.CommandArgument;
            html = supplierDataHandler.GetSupplierdataList(MFType);
            tblSupplierdataList.InnerHtml = html.ToString();
            statusTable.Style["display"] = "block";
            card_cont.Style["display"] = "none";
        }
        public void btnWinery_Click(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            Button btn = (Button)sender;
            string MFType = btn.CommandArgument;
            html = supplierDataHandler.GetSupplierdataList(MFType);
            tblSupplierdataList.InnerHtml = html.ToString();
            statusTable.Style["display"] = "block";
            card_cont.Style["display"] = "none";
        }
        public void btnMicroBrewery_Click(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            Button btn = (Button)sender;
            string MFType = btn.CommandArgument;
            html = supplierDataHandler.GetSupplierdataList(MFType);
            tblSupplierdataList.InnerHtml = html.ToString();
            statusTable.Style["display"] = "block";
            card_cont.Style["display"] = "none";
        }
        public void btnclose_Click(object sender, EventArgs e)
        {
            Response.Redirect("../NICAdmin/Dashboard.aspx");
        }

        //---------------------------------------------------------------------------------------------

        //public void count_event_app_pay()
        //{
        //    DataTable dt = null;
        //    dt = objDL.getEvent_app_pay(ConnKey);
        //    DataRow row = dt.Rows[0];
        //    decimal value = Convert.ToDecimal(row["Total_Payment"]);
        //    //lbl_event_app_pay.InnerHtml = value.ToString();
        //    lbl_event_app_pay.InnerText = string.Format("₹{0:N0}", Math.Floor(value));

        //}
        //public void count_event_app_reg()
        //{
        //    DataTable dt = null;
        //    dt = objDL.get_event_app_reg(ConnKey);
        //    DataRow row = dt.Rows[0];
        //    object value = row["Totaleventappreg"];
        //    lbl_event_app_Reg.InnerHtml = value.ToString();
        //}
        //public void event_app_reg_list()
        //{
        //    DataTable dt = null;
        //    dt = objDL.get_event_app_reg_list(ConnKey);
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        StringBuilder html = new StringBuilder();
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            html.Append("<tr>");
        //            html.Append("<td>" + row["status_code"].ToString() + "</td>");
        //            html.Append("<td>" + row["status_descritpion"].ToString() + "</td>");
        //            html.Append("<td>" + row["Total"].ToString() + "</td>");
        //            html.Append("</tr>");
        //        }

        //        tblStatus.InnerHtml = html.ToString();
        //    }
        //    else
        //    {
        //        tblStatus.InnerHtml = "<tr><td colspan='3'>No data available.</td></tr>";
        //    }
        //}
        //public void event_app_pay_list(int pageNumber = 1, int pageSize = 10)
        //{
        //    int skip = (pageNumber - 1) * pageSize;
        //    DataTable dt = objDL.get_DPEO_Event_pay_list(ConnKey, skip, pageSize);
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        StringBuilder html = new StringBuilder();
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            html.Append("<tr>");
        //            html.Append("<td>" + row["DDOCode"].ToString() + "</td>");
        //            html.Append("<td>" + row["Dist_name"].ToString() + "</td>");
        //            html.Append("<td>" + row["Total_Payment"].ToString() + "</td>");
        //            html.Append("</tr>");
        //        }
        //        tblDistrict.InnerHtml = html.ToString();
        //    }
        //    else
        //    {
        //        tblDistrict.InnerHtml = "<tr><td colspan='3'>No data available.</td></tr>";
        //    }
        //}
        //public void get_monthlydata_barchart()
        //{
        //    try
        //    {
        //        DataTable dt = objDL.getMonthWisePayment(ConnKey);
        //        if (dt == null || dt.Rows.Count == 0)
        //        {
        //            throw new Exception("No data returned from the database.");
        //        }

        //        var monthlyPaymentsData = dt.AsEnumerable().Select(row => new
        //        {
        //            month = row["Month"] != DBNull.Value
        //                    ? (row["Month"] is DateTime ? ((DateTime)row["Month"]).ToString("yyyy-MM")
        //                        : (row["Month"] is string ? row["Month"].ToString() : ""))
        //                    : "",

        //            payment = row["Payment"] != DBNull.Value
        //                      ? (row["Payment"] is decimal ? (decimal)row["Payment"]
        //                        : Convert.ToDecimal(row["Payment"]))
        //                      : 0m
        //        }).ToList();

        //        var jsonData = new JavaScriptSerializer().Serialize(monthlyPaymentsData);
        //        ClientScript.RegisterStartupScript(this.GetType(), "monthlyPaymentsData",
        //            "var monthlyPaymentsData = " + jsonData + ";", true);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.IO.File.WriteAllText("error.log", ex.ToString());
        //        throw;
        //    }
        //}


    }
}

