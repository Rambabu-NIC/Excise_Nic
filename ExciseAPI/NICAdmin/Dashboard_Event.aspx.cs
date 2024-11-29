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

namespace ExciseAPI.NICAdmin
{
    public partial class Dashboard_Event : System.Web.UI.Page
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

                GetEventPermitData();
                // GetEventPermitDataFuture();

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

        protected void GetEventPermitData()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Action = "EDB_GDC";
                objBE.BdrEast = "ALL";
                dt = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    GvRpt.Visible = true;
                    GvRpt.DataSource = dt;
                    GvRpt.DataBind();
                    dt.Dispose();
                }
                else
                {
                    GvRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void GetEventPermitDataDS(String Edistrict_Cd)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Action = "EDB_GDSC";
                objBE.BdrEast = "ALL";
                objBE.DistCode = Edistrict_Cd;
                dt = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    GvRptDistict.Visible = true;
                    GvRptDistict.DataSource = dt;
                    GvRptDistict.DataBind();
                    dt.Dispose();
                }
                else
                {
                    GvRptDistict.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void GetEventPermitDataDS(String Edistrict_Cd, String EStationCode)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Action = "DBAD_DSC";
                objBE.BdrEast = "ALL";
                objBE.DistCode = Edistrict_Cd;
                objBE.Division = EStationCode;
                dt = objDL.EventReg_IUR(objBE, ConnKey);
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
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        protected void GvRptDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {



                string Exdistrict_cd = Session["Exdistrict_cd"].ToString();
                string Exstation_cd = Session["Exstation_cd"].ToString();

                GetEventPermitDataDS(Exdistrict_cd, Exstation_cd);

                GvRptDtls.PageIndex = e.NewPageIndex;
                GvRptDtls.DataBind();
                //if (gridData.Text == "A")
                //{
                //    if (dateGrid.Text.ToString() == "1" || string.IsNullOrEmpty(dateGrid.Text.ToString()))
                //        getData(appType.Text.ToString());
                //    else if (dateGrid.Text.ToString() == "2")
                //        getDataReg(appType.Text.ToString());
                //}
                //else if (gridData.Text == "F")
                //{
                //    getDataF(appType.Text.ToString());
                //}


            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }
        }

        protected void GetEventPermitDataFuture()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Action = "DBRFT";
                dt = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    //GvRptFuture.Visible = true;
                    //GvRptFuture.DataSource = dt;
                    //GvRptFuture.DataBind();
                    dt.Dispose();
                }
                else
                {
                    //  GvRptFuture.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        protected void lnkApplicationRecieved_Click(object sender, EventArgs e)
        {

        }
        protected void lnkPendingSHO_Click(object sender, EventArgs e)
        {

        }
        protected void lnkReturnSHO_Click(object sender, EventArgs e)
        {

        }
        protected void lnkPendingDPEO_Click(object sender, EventArgs e)
        {

        }





        protected void lnkDistrictID_Click(object sender, EventArgs e)
        {

            string Exdistrict_cd = ((LinkButton)(GvRpt.FindControl("lnkDistrictID"))).Text;
            GetEventPermitDataDS(Exdistrict_cd);


        }
        protected void EventReg_Count_Click(object sender, EventArgs e)
        {

        }

        protected void GvRptDtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "CmdDistrictID")
                {


                    //int index = Convert.ToInt32(e.CommandArgument.ToString());

                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Sel_Distict.Text = ((LinkButton)(gRow.FindControl("ExDist"))).Text;

                    string Exdistrict_cd = ((LinkButton)(gRow.FindControl("lnkDistrictID"))).Text;
                    GetEventPermitDataDS(Exdistrict_cd);

                    DIVEXD.Visible = false;
                    DIVEXS.Visible = true;
                    BackClick.Visible = true;
                }


                if (e.CommandName == "CmdStationCode")
                {
                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                    string Exdistrict_cd = ((LinkButton)(gRow.FindControl("lnkDistrictID"))).Text;
                    string Exstation_cd = ((LinkButton)(gRow.FindControl("lnkStationID"))).Text;
                    Session["Exdistrict_cd"] = Exdistrict_cd;
                    Session["Exstation_cd"] = Exstation_cd;
                    GetEventPermitDataDS(Exdistrict_cd, Exstation_cd);

                }

            }
            catch
            {
            }
            finally
            {
            }

        }




        protected void lnkApplicationsFilled_Click(object sender, EventArgs e)
        {

        }
        protected void lnkApplicationsPaymentMade_Click(object sender, EventArgs e)
        {

        }

        protected void lnkApplicationRecievedF_Click(object sender, EventArgs e)
        {

        }
        protected void lnkPendingSHOF_Click(object sender, EventArgs e)
        {

        }
        protected void lnkReturnSHOF_Click(object sender, EventArgs e)
        {

        }
        protected void lnkPendingDPEOF_Click(object sender, EventArgs e)
        {

        }
        protected void lnkApplicationApprovedF_Click(object sender, EventArgs e)
        {

        }
        protected void lnkApplicationRejectedF_Click(object sender, EventArgs e)
        {

        }
        protected void lnkApplicationsFilledF_Click(object sender, EventArgs e)
        {

        }
        protected void lnkApplicationsPaymentMadeF_Click(object sender, EventArgs e)
        {

        }
        protected void lnkPaymentNotMadeF_Click(object sender, EventArgs e)
        {

        }

        protected void BackClick_Click(object sender, EventArgs e)
        {
            DIVEXD.Visible = true;
            DIVEXS.Visible = false;
            BackClick.Visible = false;

            GvRptDistict.DataSource = null;
            GvRptDistict.DataBind();
            GvRptDtls.DataSource = null;
            GvRptDtls.DataBind();
        }
    }
}