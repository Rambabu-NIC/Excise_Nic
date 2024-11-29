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

namespace ExciseAPI.DPEO_Admin
{
    public partial class DistrictWiseAbstract : System.Web.UI.Page
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

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                //lblUSer.Text = Session["UsrName"].ToString();
                // BindTypeofManf();

                BindDistData("0");
                //random();


            }
        }
        //protected void lnkApplicationRecieved_Click(object sender, EventArgs e)
        //{
        //    getData("0");
        //}
        //protected void lnkPendingSHO_Click(object sender, EventArgs e)
        //{
        //    getData("1");
        //}
        //protected void lnkPendingDPEO_Click(object sender, EventArgs e)
        //{
        //    getData("3");
        //}
        //protected void lnkApplicationApproved_Click(object sender, EventArgs e)
        //{
        //    getData("4");
        //}
        //protected void lnkApplicationRejected_Click(object sender, EventArgs e)
        //{
        //    getData("5");
        //}
        protected void lnkDistName_Click(object sender, EventArgs e)
        {
            //getData("5");
            GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lblDistCode = (Label)clickedRow.FindControl("lblDistCode");
            BindMandalData(lblDistCode.Text, "0");
        }
        protected void lnkMandName_Click(object sender, EventArgs e)
        {

            GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lblDistCode = (Label)clickedRow.FindControl("lblDistCode");
            Label lblMandCode = (Label)clickedRow.FindControl("lblMandCode");
            BindVillageData(lblDistCode.Text, lblMandCode.Text, "0");
        }
        protected void lnkVillName_Click(object sender, EventArgs e)
        {

            GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            Label lblDistCode = (Label)clickedRow.FindControl("lblDistCode");
            Label lblMandCode = (Label)clickedRow.FindControl("lblMandCode");
            Label lblVillCode = (Label)clickedRow.FindControl("lblVillCode");
            lblDCode.Text = lblDistCode.Text;
            lblMCode.Text = lblMandCode.Text;
            lblVCode.Text = lblVillCode.Text;
            getData(lblDistCode.Text, lblMandCode.Text, lblVillCode.Text);
        }

        protected void getData(string DistCode, string MandalCode, string VillageCode)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                //objBE.Rule7 = type;
                //appType.Text = type;
                //objBE.ExDistCode = Session["EXDIST_CODE"].ToString();
                //objBE.ExStation = Session["SHOID"].ToString();// Session["ExStationCode"].ToString();
                objBE.Action = "ABSRDT";
                objBE.DistCode = DistCode;
                objBE.MandCode = MandalCode;
                objBE.VillCode = VillageCode;
                dt = objDL.DistrictStationMapping(objBE, ConnKey);
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
        //protected void getData(string type)
        //{
        //    DataTable dt = new DataTable();
        //    dt = new DataTable();
        //    try
        //    {

        //        objBE.Rule7 = type;
        //        appType.Text = type;
        //        objBE.ExDistCode = Session["EXDIST_CODE"].ToString();
        //        objBE.ExStation = Session["SHOID"].ToString();// Session["ExStationCode"].ToString();
        //        objBE.Action = "SHORDT";

        //        dt = objDL.DistrictStationMapping(objBE, ConnKey);
        //        if (dt.Rows.Count > 0)
        //        {
        //            GvRptDtls.Visible = true;
        //            GvRptDtls.DataSource = dt;
        //            GvRptDtls.DataBind();
        //            dt.Dispose();
        //        }
        //        else
        //        {
        //            GvRptDtls.Visible = false;
        //            objCommon.ShowAlertMessage("No Data Found");
        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}

        protected void GvRptDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                GvRptDtls.PageIndex = e.NewPageIndex;
                //getData(appType.Text.ToString());

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }
        }
        protected void BindDistData(string DistCode)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Action = "ABSD";
                //objBE.ExDistCode = Session["EXDIST_CODE"].ToString();
                //objBE.ExStation = Session["SHOID"].ToString();// Session["ExStationCode"].ToString();
                objBE.DistCode = DistCode;
                dt = objDL.DistrictStationMapping(objBE, ConnKey);
                GvMandalRpt.Visible = false;
                GvVillageRpt.Visible = false;
                GvRptDtls.Visible = false;
                if (dt.Rows.Count > 0)
                {
                    GvDistRpt.Visible = true;
                    GvDistRpt.DataSource = dt;
                    GvDistRpt.DataBind();
                    dt.Dispose();
                }
                else
                {
                    GvDistRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void BindMandalData(string DistCode, string MandCode)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Action = "ABSM";
                //objBE.ExDistCode = Session["EXDIST_CODE"].ToString();
                //objBE.ExStation = Session["SHOID"].ToString();// Session["ExStationCode"].ToString();
                objBE.DistCode = DistCode;
                objBE.MandCode = MandCode;
                dt = objDL.DistrictStationMapping(objBE, ConnKey);
                GvDistRpt.Visible = false;
                GvVillageRpt.Visible = false;
                GvRptDtls.Visible = false;
                if (dt.Rows.Count > 0)
                {
                    GvMandalRpt.Visible = true;
                    GvMandalRpt.DataSource = dt;
                    GvMandalRpt.DataBind();
                    dt.Dispose();
                }
                else
                {
                    GvMandalRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void BindVillageData(string DistCode, string MandCode, string VillCode)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Action = "ABSV";
                //objBE.ExDistCode = Session["EXDIST_CODE"].ToString();
                //objBE.ExStation = Session["SHOID"].ToString();// Session["ExStationCode"].ToString();
                objBE.DistCode = DistCode;
                objBE.MandCode = MandCode;
                objBE.VillCode = VillCode;
                dt = objDL.DistrictStationMapping(objBE, ConnKey);
                GvDistRpt.Visible = false;
                GvMandalRpt.Visible = false;
                GvRptDtls.Visible = false;
                if (dt.Rows.Count > 0)
                {
                    GvVillageRpt.Visible = true;
                    GvVillageRpt.DataSource = dt;
                    GvVillageRpt.DataBind();
                    dt.Dispose();
                }
                else
                {
                    GvVillageRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
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


    }
}
