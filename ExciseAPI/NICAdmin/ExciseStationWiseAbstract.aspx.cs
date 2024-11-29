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
    public partial class ExciseStationWiseAbstract : BasePage
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
            if (Session["Role"] != null && (Session["Role"].ToString() == "9" || Session["Role"].ToString() == "50") && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                BindExciseDistrict();


                //ddlExStation.Visible = false;

            }


        }
        protected void BindExciseStation(int stationcode)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Action = "ST";
                objBE.ExStation = stationcode.ToString();
                objBE.DistCode = ddlExDist.SelectedValue;
                //objBE.MandCode = ddlExMnd.SelectedValue;
                dt = objDL.GetEventDetailsBySHO(objBE, ConnKey);

                if (dt.Rows.Count > 0)
                {
                    objCommon.BindDropDownLists_WithAll_0_Option_Last(ddlExStation, dt, "ExStation", "ExStationCode", "99");

                    //objCommon.BindDropDownLists(ddlExStation, dt, "Station", "DistCode", "0");
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        //protected void BindMandal()
        //{
        //    DataTable dt = new DataTable();
        //    dt = new DataTable();
        //    try
        //    {
        //        objBE.Action = "M";
        //        //objBE.DistCode = Session["DistCode"].ToString();
        //        //objBE.MandCode = MandCode;
        //        dt = objDL.ExciseMandal(objBE, ConnKey);

        //        if (dt.Rows.Count > 0)
        //        {
        //            objCommon.BindDropDownLists_WithAll_0_Option_Last(ddlExDist, dt, "MandName", "MandCode", "0");
        //            //objCommon.BindDropDownLists(ddlExMnd, dt, "MandName", "MandCode", "0");
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}

        protected void BindExciseDistrict()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Action = "ExDist";

                //objBE.MandCode = ddlExMnd.SelectedValue;
                dt = objDL.GetEventDetailsBySHO(objBE, ConnKey);

                if (dt.Rows.Count > 0)
                {
                    objCommon.BindDropDownLists_WithAll_0_Option_Last(ddlExDist, dt, "ExDist", "ExDist_Cd", "99");

                    //objCommon.BindDropDownLists(ddlExDist, dt, "ExDist", "ExDist_Cd", "0");
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
        public void BindGrid()
        {
            try
            {
                if (validate())
                {
                    if (ddlExDist.SelectedValue == "")
                    {
                        Div2.Visible = false;
                        GvRpt.Visible = false;
                    }
                    else
                    {
                        //GvRpt.Visible = false;
                        // objBE.EventId = ddlEvntType.SelectedValue;
                        DataTable dt1 = new DataTable();
                        objBE.DistCode = ddlExDist.SelectedValue;
                        //objBE.MandCode = ddlExMnd.SelectedValue;
                        if (!string.IsNullOrEmpty(ddlExStation.SelectedValue))
                        {
                            objBE.ExStation = ddlExStation.SelectedValue;
                        }


                        String FromDate = null;
                        String ToDate = null;
                        if (!string.IsNullOrEmpty(txtfrm.Text.ToString()) && !string.IsNullOrEmpty(txtto.Text.ToString()))
                        {
                            FromDate = txtfrm.Text.ToString();
                            ToDate = txtto.Text.ToString();
                            objBE.BdrWest = FromDate;
                            objBE.BdrNorth = ToDate;
                        }
                        else
                        {
                            objBE.BdrWest = FromDate;
                            objBE.BdrNorth = ToDate;
                        }

                        objBE.Action = "DBR";
                        dt1 = objDL.GetEventDetailsBySHO(objBE, ConnKey);
                        if (dt1.Rows.Count > 0)
                        {
                            GvRpt.Visible = true;
                            GvRpt.DataSource = dt1;
                            GvRpt.DataBind();
                            dt1.Dispose();
                            
                        }
                    }
                    //else
                    //{
                    //    Div2.Visible = false;
                    //}
                    //objCommon.BindDropDownLists(ddlLicenceFee, dt1, "Fee", "Payment_Type", "0");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        //public void BindGrid_dt()
        //{
        //    try
        //    {
        //        if (validate())
        //        {
        //            if (ddlExDist.SelectedValue == "")
        //            {
        //                Div2.Visible = false;
        //                GvRpt.Visible = false;
        //            }
        //            else
        //            {
        //                //GvRpt.Visible = false;
        //                // objBE.EventId = ddlEvntType.SelectedValue;
        //                DataTable dt1 = new DataTable();
        //                objBE.DistCode = ddlExDist.SelectedValue;
        //                //objBE.MandCode = ddlExMnd.SelectedValue;
        //                if (!string.IsNullOrEmpty(ddlExStation.SelectedValue))
        //                {
        //                    objBE.ExStation = ddlExStation.SelectedValue;
        //                }
        //                objBE.Action = "DBR_DT";

        //                objBE.dtfrom = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
        //                objBE.dtTo = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

        //                dt1 = objDL.ExciseMandal(objBE, ConnKey);
        //                if (dt1.Rows.Count > 0)
        //                {
        //                    GvRpt.Visible = true;
        //                    GvRpt.DataSource = dt1;
        //                    GvRpt.DataBind();
        //                    dt1.Dispose();
        //                }
        //            }
        //            //else
        //            //{
        //            //    Div2.Visible = false;
        //            //}
        //            //objCommon.BindDropDownLists(ddlLicenceFee, dt1, "Fee", "Payment_Type", "0");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}

        public bool validate()
        {
            if (ddlExDist.SelectedIndex == 0)
            {

                objCommon.ShowAlertMessage("Please Select Excise District");
                ddlExDist.Focus();
                return false;
            }
            if (ddlExStation.SelectedIndex == 0)
            {

                objCommon.ShowAlertMessage("Please Select Excise Station");
                ddlExStation.Focus();
                return false;
            }
            if (txtfrm.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Please Enter From Date");
                txtfrm.Focus();
                return false;
            }
            if (txtto.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Please Enter To Date");
                txtto.Focus();
                return false;
            }

            return true;
        }
        public void BindGridStation()
        {
            try
            {

                // objBE.EventId = ddlEvntType.SelectedValue;
                DataTable dt1 = new DataTable();
                objBE.ExStation = ddlExStation.SelectedValue;
                //objBE.MandCode = ddlExMnd.SelectedValue;
                //objBE.ExStation = ddlExStation.SelectedValue;

                objBE.Action = "ExStation";
                dt1 = objDL.GetEventDetailsBySHO(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    GvRpt.Visible = true;
                    GvRpt.DataSource = dt1;
                    GvRpt.DataBind();
                    dt1.Dispose();
                }
                else
                {
                }
                //objCommon.BindDropDownLists(ddlLicenceFee, dt1, "Fee", "Payment_Type", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
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
                getData(value, Status);
            }
            else if (dateGrid.Text.ToString() == "1")
            {
                getData(value, Status);
            }
            else if (dateGrid.Text.ToString() == "2")
            {
                getDataReg(value);
            }



        }
        protected void getDataReg(string type)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                if (string.IsNullOrEmpty(dateGrid.Text.ToString()))
                {
                    objBE.BdrEast = "ALL";
                }
                else if (dateGrid.Text.ToString() == "2")
                {//hfDate.Value
                 //objBE.MandCode = ddlExMnd.SelectedValue;
                    objBE.ExStation = ddlExStation.SelectedValue;
                }

                objBE.Rule7 = type;
                appType.Text = type;//set
                if (type == "A")
                    objBE.Action = "DBADRR";
                else if (type == "P")
                    objBE.Action = "DBPDRR";//added
                else
                    objBE.Action = "DBRDTRR";
                // objBE.Action = "DBRDT";
                dt = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ViewState["RptDtls"] = dt;

                    GvRptDtls.Visible = true;
                    GvRptDtls.DataSource = dt;
                    GvRptDtls.DataBind();
                    dt.Dispose();
                    lblPaymentDetailsNo.Visible = false;
                    dltPaymentDetails.Visible = false;
                    DivExcel.Visible = true;
                    //ibtnexportToPdf.Visible = true;
                    ibtnexportToExcel.Visible = true;
                    ViewState["FromDate"] = txtfrm.Text.ToString();
                    txtfrm.Text = string.Empty;
                    ViewState["ToDate"] = txtto.Text.ToString();
                    txtto.Text = string.Empty;
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
        protected void getData(string type, int Status)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                //Session["DateHidden"] 
                //if (string.IsNullOrEmpty(hfDate.Value))
                //if (string.IsNullOrEmpty(dateGrid.Text.ToString()))
                //{
                //    objBE.BdrEast = "ALL";
                //}
                //else if (dateGrid.Text.ToString() == "1")
                //{//hfDate.Value

                //}


                objBE.DistCode = ddlExDist.SelectedValue;
                objBE.ExStation = ddlExStation.SelectedValue;
                String Date1 = null;
                String Date2 = null;

                if (!string.IsNullOrEmpty(txtfrm.Text) && !string.IsNullOrEmpty(txtto.Text))
                {
                    Date1 = txtfrm.Text;
                    Date2 = txtto.Text;
                    objBE.BdrWest = Date1;
                    objBE.BdrNorth = Date2;
                }
                else
                {
                    objBE.BdrWest = Date1;
                    objBE.BdrNorth = Date2;
                }
                objBE.Rule7 = type;
                objBE.Status = Status.ToString();
                appType.Text = type;//set
                if (type == "A")
                    objBE.Action = "DBAD";
                else if (type == "P")
                    objBE.Action = "DBPD";//added
                else if (type == "0")
                    objBE.Action = "DBRDT";
                else
                    objBE.Action = "SHO";
                // objBE.Action = "DBRDT";
                dt = objDL.GetEventDetailsBySHO(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ViewState["RptDtls"] = dt;
                    GvRptDtls.Visible = true;
                    GvRptDtls.DataSource = dt;
                    GvRptDtls.DataBind();
                    dt.Dispose();
                    lblPaymentDetailsNo.Visible = false;
                    dltPaymentDetails.Visible = false;
                    DivExcel.Visible = true;
                    //ibtnexportToPdf.Visible = true;
                    ibtnexportToExcel.Visible = true;
                    ViewState["FromDate"] = txtfrm.Text.ToString();
                    txtfrm.Text = string.Empty;
                    ViewState["ToDate"] = txtto.Text.ToString();
                    txtto.Text = string.Empty;
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
        protected void lnkApplicationsPaymentMade_Click(object sender, EventArgs e)
        {
            //pannelOK.Visible = false;
            //PerGen.Visible = false;
            //gridData.Text = "A";
            //getData("P");
            getAllDashboard("P", "A", 0);
        }
        protected void lnkApplicationRecieved_Click(object sender, EventArgs e)
        {
            //gridData.Text = "A";
            //getData("0");

            getAllDashboard("0", "A", 0);

        }
        protected void lnkPendingSHO_Click(object sender, EventArgs e)
        {
            //pannelOK.Visible = false;
            //PerGen.Visible = false;
            //gridData.Text = "A";
            //getData("1");
            getAllDashboard("1", "A", 1);
        }
        protected void lnkReturnSHO_Click(object sender, EventArgs e)
        {
            //pannelOK.Visible = false;
            //PerGen.Visible = false;
            //gridData.Text = "A";
            //getData("2");
            getAllDashboard("2", "A", 2);
        }
        protected void getDataF(string type)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                //if (string.IsNullOrEmpty(hfDate.Value))
                //{
                //    objBE.BdrEast = "ALL";
                //}
                //else if (hfDate.Value == "1")
                //{
                //    objBE.BdrEast = "1";
                //    objBE.BdrWest = DateTime.ParseExact(txtfrm.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();// txtfrm.Text.Trim();// DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                //    objBE.BdrNorth = DateTime.ParseExact(txtto.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();// txtto.Text.Trim();// DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                //}
                // if (string.IsNullOrEmpty(dateGrid.Text.ToString()))
                // {
                objBE.BdrEast = "ALL";
                // }

                objBE.Rule7 = type;
                appType.Text = type;//set
                if (type == "A")
                    objBE.Action = "DBADF";
                else if (type == "P")
                    objBE.Action = "DBPDF";//added
                else if (type == "N")
                    objBE.Action = "DBPDFN";//added
                else
                    objBE.Action = "DBRDTF";
                // objBE.Action = "DBRDT";
                dt = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    GvRptDtls.Visible = true;
                    GvRptDtls.DataSource = dt;
                    GvRptDtls.DataBind();
                    dt.Dispose();
                    lblPaymentDetailsNo.Visible = false;
                    dltPaymentDetails.Visible = false;
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
        protected void GvRptDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                GvRptDtls.PageIndex = e.NewPageIndex;
                if (gridData.Text == "A")
                {
                    if (dateGrid.Text.ToString() == "1" || string.IsNullOrEmpty(dateGrid.Text.ToString()))
                        getData(appType.Text.ToString(), 0);
                    else if (dateGrid.Text.ToString() == "2")
                        getDataReg(appType.Text.ToString());
                }
                else if (gridData.Text == "F")
                {
                    getDataF(appType.Text.ToString());
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
            //pannelOK.Visible = false;
            // PerGen.Visible = false;
            // gridData.Text = "A";
            //getData("3");
            getAllDashboard("3", "A", 3);
        }
        protected void lnkApplicationApproved_Click(object sender, EventArgs e)
        {
            //pannelOK.Visible = false;
            // PerGen.Visible = false;
            // gridData.Text = "A";
            //getData("4");
            getAllDashboard("4", "A", 4);
        }
        protected void lnkApplicationRejected_Click(object sender, EventArgs e)
        {
            //pannelOK.Visible = false;
            // PerGen.Visible = false;
            // gridData.Text = "A";
            //getData("5");
            getAllDashboard("5", "A", 5);
        }
        protected void ddlExStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvRpt.DataSource = null;
            GvRpt.DataBind();
            GvRptDtls.DataSource = null;
            GvRptDtls.DataBind();

        }
        //protected void ddlExMnd_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindGrid();
        //}
        protected void btnGet_Click(object sender, EventArgs e)
        {

            Div2.Visible = true;

            //if (validateDates())
            //    BindGrid_dt();
            //else
            BindGrid();

        }



        //protected bool validateDates()
        //{
        //    if (txtfrm.Text == "")
        //    {
        //        // objCommon.ShowAlertMessage("Please Select From Date");
        //        return false;
        //    }
        //    if (txtto.Text == "")
        //    {
        //        // objCommon.ShowAlertMessage("Please Select To Date");
        //        return false;
        //    }
        //    if (txtfrm.Text != "" && txtto.Text != "")
        //    {
        //        DateTime fromDt = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
        //        DateTime toDt = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
        //        if (toDt < fromDt)
        //        {
        //            objCommon.ShowAlertMessage("Please check the dates, To date must be greater than From Date");
        //            return false;
        //        }
        //    }

        //    return true;
        //}


        protected void btnClose_Click(object sender, EventArgs e)
        {
            VerifyScan.Visible = false;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ReceiptHide();", true);
        }

        protected void ddlExDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvRpt.DataSource = null;
            GvRpt.DataBind();
            GvRptDtls.DataSource = null;
            GvRptDtls.DataBind();

            if (!string.IsNullOrEmpty(ddlExDist.SelectedValue) && int.Parse(ddlExDist.SelectedValue) != 0)
            {
                int stationcode = int.Parse(ddlExDist.SelectedValue.ToString());
                BindExciseStation(stationcode);

            }
            else
            {

                Div2.Visible = false;
                //Div3.Visible = false;

            }
        }
        protected void GvRptDtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "ViewDoc")
            //{
            //    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

            //    RegDoc.Visible = true;
            //    lblDocReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;
            //    lblDocReg.Visible = false;
            //    getapplicantdocs(lblDocReg.Text);
            //}



            try
            {

                if (e.CommandName == "View")
                {
                    string gRow = e.CommandArgument.ToString();
                    VerifyScan.Visible = true;
                    //Scan.Attributes["src"] = "../Verify_Scan.aspx?id=" + gRow + "";
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "ReciptConfirm();", true);
                    //
                    //Scan.Attributes ="../Verify_Scan.aspx?id=" + gRow + "";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('../Event/Verify_Scan.aspx?id=" + gRow + "','_blank');", true);

                    //ScriptManager.RegisterStartupScript(this.Page,this.GetType,"../NICAdmin/Verify_Scan.aspx?id =" + gRow + "",true)

                    //objBE.Statecode = "36";
                    ////objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    ////objBE.PermitId = Request.QueryString["RegNo"].ToString();
                    //objBE.Reg_Code = id.ToString();
                    ////   objBE.MobNo = txtMobileNumber.Text;
                    //objBE.Reg_Code=
                    //objBE.Action = "PER";
                    //DataTable dt = new DataTable();
                    //dt = objDL.EventReg_IUR(objBE, ConnKey);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    Panel1.Visible = true;
                    //    lblExDepoNm.Text = dt.Rows[0]["DPEO_NAME"].ToString();
                    //    lblPerLic.Text = dt.Rows[0]["PermitId"].ToString();
                    //    lblPerDt.Text = dt.Rows[0]["PermitDt"].ToString();
                    //    lblLicFee.Text = dt.Rows[0]["License_Fee"].ToString();
                    //    lblExdist.Text = dt.Rows[0]["ExDist"].ToString();
                    //    lblRAddress.Text = dt.Rows[0]["Res_Address"].ToString();
                    //    lblAddress.Text = dt.Rows[0]["Name_Premises"].ToString();
                    //    lblAppNAme.Text = dt.Rows[0]["App_Name"].ToString();
                    //    lblOccasion.Text = dt.Rows[0]["Event_Occasion"].ToString();
                    //    lblDttime.Text = dt.Rows[0]["Date"].ToString();
                    //    // lblExStation.Text = dt.Rows[0]["ExStation"].ToString();
                    //    lblBEast.Text = dt.Rows[0]["Bdr_East"].ToString();
                    //    lblBWest.Text = dt.Rows[0]["Bdr_West"].ToString();
                    //    lblBNorth.Text = dt.Rows[0]["Bdr_North"].ToString();
                    //    lblSouth.Text = dt.Rows[0]["Bdr_South"].ToString();

                    //    //
                    //    // Byte[] bytes = Captcha.QRCodeGenerate(dt.Rows[0]["PermitId"].ToString());

                    //    Byte[] bytes = Captcha.QRCodeGenerate("https://excise.telangana.gov.in/Verify_Scan.aspx?RegNo=" + objBE.PermitId);
                    //    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    //    ImgQR.ImageUrl = "data:image/png;base64," + base64String;
                    //    ImgQR.Visible = true;

                    //}
                    //else
                    //{
                    //    objCommon.ShowAlertMessage("No Data Found");
                    //    // Panel2.Visible = false;
                    //    // datadiv.Visible = false;
                    //    return;
                    //}


                    //if (e.CommandName == "ViewPay")
                    //{
                    //    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                    //    Payment.Visible = true;
                    //    lblAppReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;
                    //    lblAppReg.Visible = false;
                    //    getapplicantdocs(lblDocReg.Text);
                    //}
                    //else
                    //{
                    //    lblAppReg.Visible = false;
                    //}
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        public void BindEventType()
        {
            try
            {


                DataTable dt1 = new DataTable();
                objBE.Action = "ER";
                dt1 = ObjMDL.GetEventFee(objBE, ConnKey);
                //objCommon.BindDropDownLists(ddlEvntType, dt1, "Event", "Event_ID", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        public void BindLicenceFee()
        {
            try
            {

                // objBE.EventId = ddlEvntType.SelectedValue;
                DataTable dt1 = new DataTable();

                objBE.Action = "FR";
                dt1 = ObjMDL.GetEventFee(objBE, ConnKey);
                //objCommon.BindDropDownLists(ddlLicenceFee, dt1, "Fee", "Payment_Type", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void ibtnexportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=ExciseDistrictWise.xls");
            //Response.ContentType = "application/vnd.xls";
            //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htmlWrite =
            //new HtmlTextWriter(stringWrite);
            //GridView gv = new GridView();
            //gv.DataSource = ViewState["RptDtls"];
            //gv.DataBind();
            //gv.RenderControl(htmlWrite);
            //Response.Write(stringWrite.ToString());
            //Response.End();
            //string GenerateFileName = "Excise Station Wise Report" + ".xls";
            //GridView gridviewid = GvRptDtls;
            //gridviewid.AllowPaging = false;
            //System.Web.UI.HtmlControls.HtmlGenericControl div = Div3;
            //ExportGridToExcelWithLabel(GenerateFileName, div);
            string GenerateFileName = "Excise Station Wise Report" + ".xls";
            GridView gridviewid = GvRptDtls;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = Div3;
            ExportGridToExcelWithLabel(GenerateFileName, div);

        }



        //protected void ibtnexportToPdf_Click(object sender, ImageClickEventArgs e)
        //{



        //    divheading.Visible = true;
        //    GridView gridviewid = GvRptDtls;
        //    gridviewid.AllowPaging = false;
        //    string GenerateFileName = "Excise Station Wise Report" + ".Pdf";

        //    System.Web.UI.HtmlControls.HtmlGenericControl div = Div3;
        //    lblFromDate.Text = "FromDate  : " + ViewState["FromDate"];
        //    lblToDate.Text = "ToDate  : " + ViewState["ToDate"];
        //    ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        //    //divheading.Visible = true;
        //    //GridView gridviewid = GvRptDtls;
        //    //gridviewid.AllowPaging = false;
        //    //string GenerateFileName = "Excise Station Wise" + ".Pdf";

        //    //System.Web.UI.HtmlControls.HtmlGenericControl div = Div3;
        //    //lblDatetime.InnerHtml = "Date  : " + DateTime.Now.ToString();
        //    //ExportGridToPDFWithGeneratedDate(GenerateFileName, div);


        //}

        protected void GvRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GvRptDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find the Label control inside the TemplateField
                Label lblMobile = (Label)e.Row.FindControl("lblAppNo");

                if (lblMobile != null)
                {
                    string mobileNumber = lblMobile.Text;

                    // Ensure the mobile number is exactly 10 digits long
                    if (mobileNumber.Length == 10)
                    {
                        // Mask the first 6 digits of the mobile number
                        string maskedMobile = new string('*', 6) + mobileNumber.Substring(6);
                        lblMobile.Text = maskedMobile; // Replace the original number with the masked one
                    }
                }
            }
        }
        //public override void VerifyRenderingInServerForm(Control control)
        //{

        //}
        //public void ExportGridToExcelWithLabel(string GenerateFileName, System.Web.UI.HtmlControls.HtmlGenericControl gridviewid)
        //{

        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment;filename=" + GenerateFileName);
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";

        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);
        //    gridviewid.RenderControl(htw);
        //    Response.Output.Write(sw.ToString());

        //    Response.Flush();
        //    Response.End();

        //}
    }
}