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
    public partial class JurisdictionWiseFee :BasePage
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
                BindDistrict();
                //BindExciseDistrict();
                //  Viewdata();
                //random();


            }
        }
        public void BindDistrict()
        {
            try
            {

                objBE.Statecode = "36";
                DataTable dt1 = new DataTable();
                objBE.Action = "R";
                dt1 = ObjMDL.GetDistDL(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlDistrict, dt1, "DistName", "DistCode", "0");
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
                objBE.DistCode = ddlDistrict.SelectedValue;
                dt1 = ObjMDL.GetRenDS(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlExDistrict, dt1, "ExDist", "ExDist_Cd", "0");
            }
            catch (Exception ex)
            {
                // ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //   Response.Redirect("~/Error.aspx");
            }
        }
        public void BindExStations()
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.DistCode = ddlDistrict.SelectedValue.ToString();
                objBE.ExDistCode = ddlExDistrict.SelectedValue.ToString();
                objBE.Action = "ES";
                dt1 = objDL.DistrictStationMapping(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlExStation, dt1, "ExStation", "ExStationCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindMandals()
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.DistCode = ddlDistrict.SelectedValue.ToString();
                objBE.ExDistCode = ddlExDistrict.SelectedValue.ToString();
                objBE.ExStation = ddlExStation.SelectedValue.ToString();
                objBE.Action = "JM";
                dt1 = objDL.DistrictStationMapping(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlMandal, dt1, "MandName", "MandCode", "0");
                // Viewdata();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindExciseDistrict();
            GvRpt.Visible = false;
            if (ddlDistrict.SelectedValue == "31")
            {
                ddlMandal.ClearSelection();
                ddlMandal.Enabled = false;
            }
            else
            {
                ddlMandal.ClearSelection();
                ddlMandal.Enabled = true;
            }
        }
        protected void ddlExDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvRpt.Visible = false;
            BindExStations();
        }
        protected void ddlExStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvRpt.Visible = false;
            if (ddlDistrict.SelectedValue == "31")
            {
                ddlMandal.ClearSelection();
                ddlMandal.Enabled = false;
                Viewdata();
            }
            else
            {

                BindMandals();
                ddlMandal.Enabled = true;
            }

        }
        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
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


                objBE.Action = "FRD";
                objBE.DistCode = ddlDistrict.SelectedValue;
                objBE.ExDistCode = ddlExDistrict.SelectedValue;
                objBE.ExStation = ddlExStation.SelectedValue;
                objBE.MandCode = ddlMandal.SelectedValue;
                // DataTable dt = new DataTable();
                dt = objDL.DistrictStationMapping(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    DivJ.Visible = true;
                    divgriddetails.Visible = true;
                    DivGeneratedDate.Visible = true;
                    btneventImageExportToExcel.Visible = true;
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

        protected void btneventImageExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            divheading.Visible = true;
            string GenerateFileName = "Jurisdiction Wise Event Permits Report" + ".xls";
            GridView gridviewid = GvRpt;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divgriddetails;
            
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
    }


}