using System;
using System.Collections.Generic;
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

namespace ExciseAPI.Event
{
    public partial class EventDefault : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Validate objValidate = new Validate();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetEventPermitData();
        }
        protected void GetEventPermitData()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                //objBE.Action = "DBRP";
                objBE.Action = "DBABS";

                objBE.dtfrom = null;
                objBE.dtTo = null;
                dt = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    //lblTimeLimit.Text = dt.Rows[0]["TimeLimit"].ToString(); //"2";// 
                    //lblTotalAppReceived.Text = dt.Rows[0]["AppReceived"].ToString(); //"718";// 
                    //lblTotalAppApproved.Text = dt.Rows[0]["AppApproved"].ToString(); //"717";// 
                    //lblAvgTime.Text = dt.Rows[0]["AvgTime"].ToString(); //"1.1";//
                    //lblMedianTime.Text = dt.Rows[0]["MedianTime"].ToString(); //"1";//
                    //lblMinimum.Text = dt.Rows[0]["MinimumTime"].ToString(); //"1";//
                    //lblMaximum.Text = dt.Rows[0]["MaximumTime"].ToString();// "2";//

                    lblReceived.Text = dt.Rows[0]["TOTALCOUNT"].ToString();
                    lblDayCount.Text = dt.Rows[0]["DAYCOUNT"].ToString();
                    lblMonthCount.Text = dt.Rows[0]["MONTHCOUNT"].ToString();
                    lblYearCount.Text = dt.Rows[0]["YEARCOUNT"].ToString();

                    lblNoofPermitIssued.Text = dt.Rows[0]["APPISSUEDCOUNT"].ToString();
                    lblDayIssued.Text = dt.Rows[0]["DAYISSUEDCOUNT"].ToString();
                    lblMonthIssued.Text = dt.Rows[0]["MONTHISSUEDCOUNT"].ToString();
                    lblYearIssued.Text = dt.Rows[0]["YEARISSUEDCOUNT"].ToString();

                    lblNoofUnderProcess.Text = dt.Rows[0]["APPPROCESSCOUNT"].ToString();
                    lblDayProcess.Text = dt.Rows[0]["DAYPROCESSCOUNT"].ToString();
                    lblMonthProcess.Text = dt.Rows[0]["MONTHPROCESSCOUNT"].ToString();
                    lblYearProcess.Text = dt.Rows[0]["YEARPROCESSCOUNT"].ToString();

                    lblNoofRejected.Text = dt.Rows[0]["APPREJECTEDCOUNT"].ToString();
                    lblDayRejected.Text = dt.Rows[0]["DAYREJECTEDCOUNT"].ToString();
                    lblMonthRejected.Text = dt.Rows[0]["MONTHREJECTEDCOUNT"].ToString();
                    lblYearRejected.Text = dt.Rows[0]["YEARREJECTEDCOUNT"].ToString();

                    dt.Dispose();
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");
                }


            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void btnReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void lnkMore_OnClink(object sender, EventArgs e)
        {
            Session["RptStatus"] = "1,2,3,4,5";// "ALL";
            Response.Redirect("~/Event/EventDetails.aspx");
        }
        protected void lnkIssuedMore_OnClink(object sender, EventArgs e)
        {
            Session["RptStatus"] = "4";
            Response.Redirect("~/Event/EventDetails.aspx");
        }
        protected void lnkProcessMore_OnClink(object sender, EventArgs e)
        {
            Session["RptStatus"] = "1,2,3";
            Response.Redirect("~/Event/EventDetails.aspx");
        }
        protected void lnkRejectedMore_OnClink(object sender, EventArgs e)
        {
            Session["RptStatus"] = "5";
            Response.Redirect("~/Event/EventDetails.aspx");
        }

        protected void lnkInfo_Click(object sender, EventArgs e)
        {

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}