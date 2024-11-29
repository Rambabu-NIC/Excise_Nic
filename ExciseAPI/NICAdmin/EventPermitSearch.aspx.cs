using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;
using System.Configuration;

namespace ExciseAPI.NICAdmin
{
    public partial class EventPermitSearch : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
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
            ///*KILL COOKIE & clear Caching*/
            //PrevBrowCache.enforceNoCache();
            //if (Session["Role"] != null && Session["Role"].ToString() == "9" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            //{
            //    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }
            //}
            //else
            //{
            //    Response.Redirect("~/Error.aspx");
            //}

            if (!IsPostBack)
            {

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                //lblUSer.Text = Session["UsrName"].ToString();
                //BindTypeofManf();           

                //random();
                //pannelOK.Visible = false;
            }
        }



        protected bool Validate()
        {
            if (txtRegistrationNO.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter Registration No");
                txtRegistrationNO.Focus();
                return false;
            }

            return true;
        }

        protected void btn_Get_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    Viewdata();
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }
        }

        public void Clear()
        {
            txtRegistrationNO.Text = "";
        }
        protected void Viewdata()
        {
            //GvRptDtls.Visible = false;
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Reg_Code = txtRegistrationNO.Text;
                objBE.Action = "PSR";
                dt = objDL.EventReg_IUR(objBE, Session["ConnKey"].ToString());
                if (dt.Columns.Count == 1)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    return;
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        pannelOK.Visible = false;
                        PerGen.Visible = false;
                        div2.Visible = true;
                        GvRptDtls.Visible = true;
                        GvRptDtls.DataSource = dt;
                        GvRptDtls.DataBind();
                        dt.Dispose();
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("No Data Found");
                        GvRptDtls.Visible = false;
                        div2.Visible = false;
                        //pannelOK.Visible = false;
                    }
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
                Viewdata();
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
                    PerGen.Visible = false;
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

                        // lblPaymentDetails.Text = dt1.Rows[0]["PaymentDetails"].ToString();

                        DataTable dt2 = new DataTable();
                        objBE.Reg_Code = ((LinkButton)(gRow.FindControl("lblAppRegNo"))).Text;
                        objBE.Action = "PDR";
                        dt2 = objDL.EventReg_IUR(objBE, ConnKey);
                        if (dt2.Rows.Count > 0)
                        {
                            lblPaymentDetailsNo.Visible = false;
                            dltPaymentDetails.Visible = true;
                            dltPaymentDetails.DataSource = dt2;
                            dltPaymentDetails.DataBind();
                        }
                        else
                        {

                            dltPaymentDetails.Visible = false;
                            lblPaymentDetailsNo.Visible = true;
                            lblPaymentDetailsNo.Text = "No Payment Details";
                        }



                    }

                }
                else
                {
                    pannelOK.Visible = false;
                }

                if (e.CommandName == "PerDown")
                {
                    pannelOK.Visible = false;
                    objBE.Statecode = "36";
                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    PerGen.Visible = true;
                    objBE.Reg_Code = ((LinkButton)(gRow.FindControl("lblAppRegNo"))).Text;
                    objBE.Action = "PER";
                    DataTable dt = new DataTable();
                    dt = objDL.EventReg_IUR(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        Panel1.Visible = true;
                        lblExDepoNm.Text = dt.Rows[0]["DPEO_NAME"].ToString();
                        lblPerLic.Text = dt.Rows[0]["PermitId"].ToString();
                        lblPerDt.Text = dt.Rows[0]["PermitDt"].ToString();
                        lblLicFee.Text = dt.Rows[0]["License_Fee"].ToString();
                        lblExd.Text = dt.Rows[0]["ExDist"].ToString();
                        lblRAddress.Text = dt.Rows[0]["Res_Address"].ToString();
                        lblAddress.Text = dt.Rows[0]["Name_Premises"].ToString();
                        lblAppNAme.Text = dt.Rows[0]["App_Name"].ToString();
                        lblOccasion.Text = dt.Rows[0]["Event_Occasion"].ToString();
                        lblDttime.Text = dt.Rows[0]["Date"].ToString();
                        // lblExStation.Text = dt.Rows[0]["ExStation"].ToString();
                        lblBEast.Text = dt.Rows[0]["Bdr_East"].ToString();
                        lblBWest.Text = dt.Rows[0]["Bdr_West"].ToString();
                        lblBNorth.Text = dt.Rows[0]["Bdr_North"].ToString();
                        lblSouth.Text = dt.Rows[0]["Bdr_South"].ToString();

                        //dpeoDistrictName.Text = dt.Rows[0]["DistName"].ToString();
                        dpeoDistrictName.Text = dt.Rows[0]["DPEO_DistName"].ToString();


                    }
                    else
                    {

                    }
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