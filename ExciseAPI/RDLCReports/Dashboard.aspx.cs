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
using Microsoft.Reporting.WebForms;
using System.Globalization;

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

        if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
        {
            Response.Redirect("~/Error.aspx");
        }
        else
        {
            string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            int len = http_hos.Length;
            if (http_ref.IndexOf(http_hos, 0) < 0)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
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
            lblUSer.Text = Session["UsrName"].ToString();
            GetDashboardData();
            GetEventPermitData();
            // BindTypeofManf();
            // pannelOK.Visible = false;
            // Viewdata();
            random();


        }
    }

    public void random()
    {
        try
        {
            string strString = "abcdefghijklmnpqrstuvwxyzABCDQEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string num = "";
            Random rm = new Random();
            for (int i = 0; i < 16; i++)
            {
                int randomcharindex = rm.Next(0, strString.Length);
                char randomchar = strString[randomcharindex];
                num += Convert.ToString(randomchar);
            }
            hf.Value = num;
            Session["ASPFIXATION2"] = num;
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    public void check()
    {
        try
        {
            string cookie_value = null;
            string session_value = null;

            cookie_value = hf.Value;
            session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
            if (cookie_value != session_value)
            {
                System.Web.HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.Buffer = false;
                HttpContext.Current.Response.Redirect("~/Error.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx", false);
        }
    }
    
    protected void imgbtnExcel_Click1(object sender, EventArgs e)
    {
       // try
       // {
         DataTable   dt = new DataTable();
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

    protected void GetEventPermitData()
    {
        DataTable dt = new DataTable();
        dt = new DataTable();
        try
        {
            objBE.Action = "DBR";
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
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        
          
    }
    protected void lnkApplicationRecieved_Click(object sender, EventArgs e)
    {
        getData("0");
    }
    protected void lnkPendingSHO_Click(object sender, EventArgs e)
    {
        getData("1");
    }
    protected void lnkPendingDPEO_Click(object sender, EventArgs e)
    {
        getData("3");
    }
    protected void lnkApplicationApproved_Click(object sender, EventArgs e)
    {
        getData("4");
    }
    protected void lnkApplicationRejected_Click(object sender, EventArgs e)
    {
        getData("5");
    }
    protected void lnkApplicationsFilled_Click(object sender, EventArgs e)
    {
        getData("A");
    }
    protected void lnkApplicationsPaymentMade_Click(object sender, EventArgs e)
    {
        getData("P");
    }
    protected void getData(string type)
    {
        DataTable dt = new DataTable();
        dt = new DataTable();
        try
        {
            
            objBE.Rule7 = type;
            appType.Text = type;//set
            if (type == "A")
                objBE.Action = "DBAD";
            else if (type == "P")
                objBE.Action = "DBPD";//added
            else
                objBE.Action = "DBRDT";
               // objBE.Action = "DBRDT";
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
            getData(appType.Text.ToString());
           
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            objCommon.ShowAlertMessage(ex.ToString());
        }
    }
    protected void GvRptDtls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "View")
            {
                DataTable dt = new DataTable();

                GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                pannelOK.Visible = true;
                objBE = new Supplier_BE();
                DataTable dt1 = new DataTable();
                objBE.Reg_Code = ((LinkButton)(gRow.FindControl("lblAppRegNo"))).Text;
                objBE.Action = "ADMV";
                dt1 = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    lblReg.Text = dt1.Rows[0]["AppReg_No"].ToString();
                    txtAppliName.Text = dt1.Rows[0]["App_Name"].ToString();
                    txtAdharNum.Text = dt1.Rows[0]["Aadhaar"].ToString();
                    txtMobile.Text = dt1.Rows[0]["Mob_No"].ToString();
                    txtEmail.Text = dt1.Rows[0]["Email"].ToString();
                    txtAge.Text = dt1.Rows[0]["Age"].ToString();
                    txtFatherName.Text = dt1.Rows[0]["FName"].ToString();
                    txtAdd.Text = dt1.Rows[0]["Res_Address"].ToString();
                    txtHsNum.Text = dt1.Rows[0]["HNo"].ToString();
                    txtNmePrem.Text = dt1.Rows[0]["Name_Premises"].ToString();
                    txtStreet.Text = dt1.Rows[0]["Street"].ToString();
                    txtEast.Text = dt1.Rows[0]["Bdr_East"].ToString();
                    txtWest.Text = dt1.Rows[0]["Bdr_West"].ToString();
                    txtNorth.Text = dt1.Rows[0]["Bdr_North"].ToString();
                    txtSouth.Text = dt1.Rows[0]["Bdr_South"].ToString();
                    objBE.Statecode = "36";
                    //  BindRevDistrict();
                    lblRDist.Text = dt1.Rows[0]["DistName"].ToString();

                    //BindRevMandal();
                    lblbRMand.Text = dt1.Rows[0]["MandName"].ToString();

                    // BindVillage();
                    lblbRVill.Text = dt1.Rows[0]["VillName"].ToString();
                    // BindRevdistVill();
                    lblExDistCode.Text = dt1.Rows[0]["ExDist_Cd"].ToString();
                    lblExStation.Text = dt1.Rows[0]["ExStation"].ToString();
                    lblExDist.Text = dt1.Rows[0]["ExDist"].ToString();
                    lblExStationCd.Text = dt1.Rows[0]["ExStationCode"].ToString();
                    lblGHMC.Text = dt1.Rows[0]["GHMC"].ToString();
                    //BindExciseDistrict();
                    //ddlExciseDistrict.SelectedValue = dt1.Rows[0]["ExDist_Cd"].ToString();

                    //BindExMandal();
                    ////  ddlExciseStation.SelectedValue = dt1.Rows[0]["ExStationCode"].ToString();
                    ////  ddlWhether.SelectedValue = dt1.Rows[0]["Rule7"].ToString();
                    ddlEvntTm.Text = dt1.Rows[0]["Eventtime"].ToString();
                    lblRule7.Text = dt1.Rows[0]["Rule7"].ToString();
                    txtEvnDate.Text = dt1.Rows[0]["Date"].ToString();
                    txtEvent.Text = dt1.Rows[0]["Event_Occasion"].ToString();
                    BindEventType();
                    lblevent.Text = dt1.Rows[0]["Event_Type"].ToString();
                    lbleventid.Text = dt1.Rows[0]["Event_ID"].ToString();
                    //ddlEvntType.SelectedValue = dt1.Rows[0]["Event_ID"].ToString();
                    Label5.Text = dt1.Rows[0]["Event"].ToString();
                    lbleventtypee.Text = dt1.Rows[0]["EVENTDESC"].ToString();
                    //Bindtickes();
                    //if (lblevent.Text == "2")
                    //{
                    //    Rbtype.SelectedValue = dt1.Rows[0]["Event_Type"].ToString();

                    //}
                    //if (lblevent.Text == "1")
                    //{

                    //    RbTypeP.SelectedValue = dt1.Rows[0]["Event_Type"].ToString();
                    //}

                    BindLicenceFee();
                    // ddlLicenceFee.SelectedValue = dt1.Rows[0]["Payment_Type"].ToString();
                    lblFee.Text = dt1.Rows[0]["License_Fee"].ToString();
                    lblDFee.Text = dt1.Rows[0]["Diffential_Amt"].ToString();
                    txtDtInsp.Text = dt1.Rows[0]["ShoInspecDt"].ToString();

                    txtRemarks.Text = dt1.Rows[0]["ShoRemarks"].ToString();



                }

            }
            else
            {
                pannelOK.Visible = false;
            }



            //if (e.CommandName == "ViewDoc")
            //{
            //    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

            //    RegDoc.Visible = true;
            //    lblDocReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;
            //    lblDocReg.Visible = false;
            //    getapplicantdocs(lblDocReg.Text);
            //}
            //else
            //{
            //    RegDoc.Visible = false;
            //}
            //if (e.CommandName == "ViewPay")
            //{
            //    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

            //    Payment.Visible = true;
            //    lblAppReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;
            //    //lblAppReg.Visible = false;
            //    // getapplicantdocs(lblDocReg.Text);
            //}
            //else
            //{
            //    lblAppReg.Visible = false;
            //}
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
   
}

