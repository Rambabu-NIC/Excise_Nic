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
    public partial class ExciseSHORpt : System.Web.UI.Page
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
                BindRevDistrict();
                BindExciseDistrict();
                Viewdata();
                //random();


            }
        }
        public void BindRevDistrict()
        {
            try
            {

                objBE.Statecode = "36";
                DataTable dt1 = new DataTable();
                objBE.Action = "R";
                dt1 = ObjMDL.GetDistDL(objBE, ConnKey);
                objCommon.BindDropDownLists_WithAllOption(ddlRevDistrict, dt1, "DistName", "DistCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindExciseDistrict()
        {
            try
            {

                objBE.Statecode = "36";
                DataTable dt1 = new DataTable();
                objBE.Action = "ER";
                objBE.DistCode = ddlRevDistrict.SelectedValue;
                dt1 = ObjMDL.GetRenDS(objBE, ConnKey);
                objCommon.BindDropDownLists_WithAllOption(ddlExDist, dt1, "ExDist", "ExDist_Cd", "0");
            }
            catch (Exception ex)
            {
                // ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //   Response.Redirect("~/Error.aspx");
            }
        }
        protected void ddlRevDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindExciseDistrict();
            Viewdata();
        }
        protected void ddlExDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            // BindExciseDistrict();
            Viewdata();
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
        protected void GvRpt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                GvRpt.PageIndex = e.NewPageIndex;
                Viewdata();

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


                objBE.Action = "SHOR";
                objBE.DistCode = ddlRevDistrict.SelectedValue;
                objBE.ExDistCode = ddlExDist.SelectedValue;
                // DataTable dt = new DataTable();
                dt = objDL.DistrictStationMapping(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    GvRpt.Visible = true;
                    GvRpt.DataSource = dt;
                    GvRpt.DataBind();
                    dt.Dispose();
                    //Button1.Visible = true;

                }
                else
                {
                    GvRpt.Visible = false;
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

        protected void GvRpt_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvRpt.EditIndex = e.NewEditIndex;
            Viewdata();
        }
        protected void GvRpt_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow row = (GridViewRow)GvRpt.Rows[e.RowIndex];
            Label lblID = (Label)row.FindControl("lblSHOCODE");

            TextBox textMobileNumber = (TextBox)row.Cells[5].Controls[0];

            GvRpt.EditIndex = -1;
            objBE.Action = "SHOMU";
            objBE.NameOfPerm = textMobileNumber.Text;
            objBE.ExStation = lblID.Text;
            objBE.ExDistCode = Session["UserID"].ToString();
            DataTable dt = new DataTable();
            dt = objDL.DistrictStationMapping(objBE, ConnKey);
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
            }
            Viewdata();
        }

        protected void GvRpt_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvRpt.EditIndex = -1;
            Viewdata();
        }

    }

}