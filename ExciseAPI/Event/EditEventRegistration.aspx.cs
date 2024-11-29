using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Event
{
    public partial class EditEventRegistration : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
                //  Response.Redirect("~/Error.aspx");
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
            //  RegId = Session["UserId"].ToString();
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            //if (Session["Role"] != null && Session["Role"].ToString() == "1" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            //{
            //    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }
            //}
            //else
            //{
            //  //  Response.Redirect("~/Error.aspx");
            //}

            if (!IsPostBack)
            {

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                // lblUSer.Text = Session["UsrName"].ToString();
                //GetTypeManFDAL();
                // BindDistrict();
                //Viewdata();
                random();
                Getdata();
                BindRevDistrict();
                // BindExciseDistrict();
                DateTime StartDate = DateTime.Today;
                Calendar1.StartDate = StartDate.AddDays(1);
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
        protected void btn_Update_Click(object sender, EventArgs e)
        {

            try
            {
                if (Validate())
                {
                    objBE.AppName = txtAppliName.Text;
                    objBE.Aadhaar = txtAdharNum.Text;
                    objBE.MobNo = txtMobile.Text;
                    objBE.Email = txtEmail.Text;
                    objBE.Age = txtAge.Text;
                    objBE.FatherName = txtFatherName.Text;
                    objBE.Address = txtAdd.Text;
                    objBE.HouseNo = txtHsNum.Text;
                    objBE.NameOfPerm = txtNmePrem.Text;
                    objBE.Street = txtStreet.Text;
                    objBE.BdrEast = txtEast.Text;
                    objBE.BdrWest = txtWest.Text;
                    objBE.BdrNorth = txtNorth.Text;
                    objBE.BdrSouth = txtSouth.Text;
                    objBE.DistCode = ddlRevDistrict.SelectedValue;
                    objBE.MandCode = ddlMandal.SelectedValue;
                    objBE.VillCode = ddlLocality.SelectedValue;
                    objBE.ExDistCode = lblExDistCode.Text;
                    objBE.ExStation = lblExStationCd.Text;
                    objBE.Rule7 = ddlWhether.SelectedItem.ToString();
                    objBE.EDate = txtEvnDate.Text.ToString(); //DateTime.Parse(txtEvnDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.None).ToString("yyyy-MM-dd");
                    //DateTime regdt = DateTime.Parse(txtEvnDate.Text.ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                    //objBE.Date = regdt;
                    objBE.Eventtime = ddlEvntTm.SelectedItem.Text;
                    objBE.EventOccasion = txtEvent.Text;
                    // objBE.Paymenttype = ddlLicenceFee.SelectedValue;
                    objBE.EventId = ddlEvntType.SelectedValue;
                    objBE.ghmc = lblGHMC.Text;
                    //if (ddlEvntType.SelectedValue == "2")
                    //{
                    //    objBE.EventType = Rbtype.SelectedValue;
                    //}
                    //if (ddlEvntType.SelectedValue == "1")
                    //{
                    //    objBE.EventType = RbTypeP.SelectedValue;
                    //}
                    if (ddlEvntType.SelectedValue == "2")
                    {
                        objBE.EventType = Rbtype.SelectedValue;
                    }
                    else if (ddlEvntType.SelectedValue == "1")
                    {
                        objBE.EventType = RbTypeP.SelectedValue;
                    }
                    else if (ddlEvntType.SelectedValue == "3")
                    {
                        objBE.EventType = "1";
                    }
                    objBE.License_Fee = lblFee.Text;

                    //objBE.TotalFeePaid = Convert.ToDecimal(txtFee.Text);
                    //objBE.TotalFeePaid = Convert.ToDecimal(txtFee.Text.Trim());

                    objBE.Statecode = "36";

                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.Reg_Code = Session["RegId"].ToString();
                    //objBE.UserName = Session["User"].ToString();
                    objBE.Action = "U";
                    DataTable dt = new DataTable();
                    dt = objDL.EventReg_IUR(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        // Clear();
                        // Viewdata();
                        Session["RegNo"] = dt.Rows[0][0].ToString();

                        Response.Redirect("~/Event/UploadDoc.aspx", false);

                    }
                }

            }
            catch
            {

            }

        }
        public void BindRevDistrict()
        {
            try
            {

                objBE.Statecode = "36";
                DataTable dt1 = new DataTable();
                objBE.Action = "RD";
                dt1 = ObjMDL.CommonMasters(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlRevDistrict, dt1, "DistName", "DistCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindRevMandal()
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.Statecode = "36";
                objBE.DistCode = ddlRevDistrict.SelectedValue;
                objBE.Action = "RM";
                dt1 = ObjMDL.CommonMasters(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlMandal, dt1, "MandName", "MandCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindVillage()
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.Statecode = "36";
                objBE.DistCode = ddlRevDistrict.SelectedValue;
                objBE.MandCode = ddlMandal.SelectedValue;
                objBE.Action = "RV";
                dt1 = ObjMDL.CommonMasters(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlLocality, dt1, "VillName", "VillCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        //protected bool Validate()
        //{
        //    if (txtFatherName.Text == "")
        //    {
        //        objCommon.ShowAlertMessage("Enter SGST Number");
        //        txtFatherName.Focus();
        //        return false;
        //    }

        //    return true;


        //}
        protected bool Validate()
        {

            if (txtAppliName.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Name of Applicant");
                txtAppliName.Focus();
                return false;
            }
            if (txtFatherName.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Father Name");
                txtFatherName.Focus();
                return false;
            }
            if (txtMobile.Text == "")
            {

                objCommon.ShowAlertMessage("Enter Mobile Number");
                return false;
            }
            else
            {
                if (!objValidate.ISMobileNo(txtMobile.Text, 9, 9))
                {
                    objCommon.ShowAlertMessage("Enter Valid Mobile Number");
                    return false;
                }
            }

            if (txtAge.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Age Between 21 to 100");
                return false;
            }

            if (txtAdharNum.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Aadhaar Number");
                txtAdharNum.Focus();
                return false;
            }
            else if (txtAdharNum.Text.Trim().Length < 12)
            {
                objCommon.ShowAlertMessage("Enter 12 digit valid Aadhaar Id");
                txtAdharNum.Focus();
                return false;
            }
            else if (txtAdharNum.Text.Trim().Substring(0, 1) == "0")
            {
                objCommon.ShowAlertMessage("Enter  valid Aadhaar Id");
                txtAdharNum.Focus();
                return false;
            }

            //if (txtEmail.Text == "")
            //{
            //    objCommon.ShowAlertMessage("Enter Email ");
            //    txtEmail.Focus();
            //    return false;
            //}
            if (txtAdd.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Residential Address");
                txtAdd.Focus();
                return false;
            }

            if (txtHsNum.Text == "")
            {
                objCommon.ShowAlertMessage("Enter House Number/Door Number");
                txtHsNum.Focus();
                return false;

            }
            if (txtNmePrem.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Name Of the Premises");
                txtNmePrem.Focus();
                return false;

            }
            if (txtStreet.Text == "")
            {
                objCommon.ShowAlertMessage("Enter  Street");
                txtStreet.Focus();
                return false;

            }
            if (txtEast.Text == "")
            {
                objCommon.ShowAlertMessage("Enter East Boundries");
                txtEast.Focus();
                return false;

            }
            if (txtWest.Text == "")
            {
                objCommon.ShowAlertMessage("Enter West Boundries");
                txtWest.Focus();
                return false;

            }
            if (txtNorth.Text == "")
            {
                objCommon.ShowAlertMessage("Enter North Boundries");
                txtNorth.Focus();
                return false;

            }
            if (txtSouth.Text == "")
            {
                objCommon.ShowAlertMessage("Enter South Boundries");
                txtSouth.Focus();
                return false;

            }
            if (ddlRevDistrict.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Select District");
                ddlRevDistrict.Focus();
                return false;

            }
            if (ddlMandal.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Select Mandal");
                ddlMandal.Focus();
                return false;

            }
            if (ddlRevDistrict.SelectedValue != "31")
            {
                if (ddlLocality.SelectedIndex == 0)
                {
                    objCommon.ShowAlertMessage("Select Village/Ward");
                    ddlLocality.Focus();
                    return false;

                }
            }



            if (txtEvnDate.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Date of Event");
                txtEvnDate.Focus();
                return false;

            }
            if (ddlEvntTm.SelectedIndex == 0 || ddlEvntTm.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Select Time/Solt of Event ");
                ddlEvntTm.Focus();
                return false;
            }
            if (ddlEvntType.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Please Select Type Of Event");
                ddlEvntType.Focus();
                return false;

            }

            if (lblFee.Text == "")
            {
                objCommon.ShowAlertMessage("Seelct of tickets");

                return false;
            }

            if (txtEvent.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Event On Occasion");
                txtEvent.Focus();
                return false;

            }

            return true;


        }
        protected void Getdata()
        {
            try
            {
                objBE = new Supplier_BE();
                DataTable dt1 = new DataTable();
                objBE.Reg_Code = Session["RegId"].ToString();//"360200001423"; //
                objBE.Action = "R";
                dt1 = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    //  pannel1.Visible = true;
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
                    BindRevDistrict();
                    ddlRevDistrict.SelectedValue = dt1.Rows[0]["DistCode"].ToString();

                    BindRevMandal();
                    ddlMandal.SelectedValue = dt1.Rows[0]["Mandal"].ToString();

                    BindVillage();
                    ddlLocality.SelectedValue = dt1.Rows[0]["Village"].ToString();

                    BindRevdistVill();
                    lblExDistCode.Text = dt1.Rows[0]["ExDist_Cd"].ToString();
                    lblExStation.Text = dt1.Rows[0]["ExStation"].ToString();
                    lblExDist.Text = dt1.Rows[0]["ExDist"].ToString();
                    lblExStationCd.Text = dt1.Rows[0]["ExStationCode"].ToString();
                    lblGHMC.Text = dt1.Rows[0]["GHMC"].ToString();



                    // ddlWhether.SelectedValue = dt1.Rows[0]["Rule7"].ToString();
                    // ddlEvntTm.SelectedValue = dt1.Rows[0]["Eventtime"].ToString();//comment by r on 05/02/2021

                    BindEventTime();
                    if (dt1.Rows[0]["Eventtime"].ToString().Trim() == "Slot-2 (7PM-11PM)")
                    {
                        ddlEvntTm.SelectedValue = "2";
                    }
                    else if (dt1.Rows[0]["Eventtime"].ToString().Trim() == "Slot-1 (11AM-4PM)")
                    { ddlEvntTm.SelectedValue = "1"; }

                    txtEvnDate.Text = dt1.Rows[0]["Date"].ToString();
                    txtEvent.Text = dt1.Rows[0]["Event_Occasion"].ToString();
                    lblFee.Text = dt1.Rows[0]["Payment_Type"].ToString();
                    BindEventType();
                    ddlEvntType.SelectedValue = dt1.Rows[0]["Event_ID"].ToString();
                    Bindtickes();
                    if (ddlEvntType.SelectedValue == "2")
                    {
                        Rbtype.SelectedValue = dt1.Rows[0]["Event_Type"].ToString();

                    }
                    if (ddlEvntType.SelectedValue == "1")
                    {

                        RbTypeP.SelectedValue = dt1.Rows[0]["Event_Type"].ToString();
                    }


                    BindLicenceFee();
                    //BindLicenceFeeG(dt1.Rows[0]["GHMC"].ToString());

                    lblFee.Text = dt1.Rows[0]["License_Fee"].ToString();

                    //   dt1.Rows[0]["License_Fee"] = txtLicen.Text;
                }
                else
                {

                    objCommon.ShowAlertMessage("There Is No Data Found For this Registration Number");
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("../Error.aspx");
            }
        }
        protected void ddlRevDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEvnDate.Text = "";
            ddlEvntTm.ClearSelection();
            BindRevMandal();
        }
        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRevDistrict.SelectedValue == "31")
            {
                ddlLocality.Enabled = false;
                ddlLocality.ClearSelection();
                BindRevdistVill();
            }
            else
            {
                ddlLocality.Enabled = true;
                BindVillage();
            }

        }

        public void Clear()
        {
            ddlEvntTm.SelectedIndex = 0;
            txtAppliName.Text = "";
            ddlRevDistrict.SelectedIndex = 0;
            txtAdharNum.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtAge.Text = "";
            ddlMandal.SelectedIndex = 0;
            ddlLocality.SelectedIndex = 0;

            txtFatherName.Text = "";
            txtAdd.Text = "";
            ddlWhether.SelectedIndex = 0;
            txtHsNum.Text = "";
            txtNmePrem.Text = "";
            txtStreet.Text = "";
            txtEast.Text = "";
            txtWest.Text = "";
            txtNorth.Text = "";
            txtSouth.Text = "";
            txtEvnDate.Text = "";
            lblFee.Text = "";
            ddlEvntType.SelectedIndex = 0;
            //ddlLicenceFee.SelectedIndex = 0;
            txtEvent.Text = "";

        }

        public void BindEventType()
        {
            try
            {


                DataTable dt1 = new DataTable();
                objBE.Action = "ER";
                dt1 = ObjMDL.GetEventFee(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlEvntType, dt1, "Event", "Event_ID", "0");
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

                objBE.EventId = ddlEvntType.SelectedValue;
                if (ddlEvntType.SelectedValue == "2")
                {

                    objBE.Paymenttype = Rbtype.SelectedValue;
                    objBE.ghmc = "N";
                }
                if (ddlEvntType.SelectedValue == "3")
                {

                    objBE.Paymenttype = "1";
                    objBE.ghmc = "N";
                }
                if (ddlEvntType.SelectedValue == "1")
                {
                    objBE.Paymenttype = RbTypeP.SelectedValue;
                    objBE.ghmc = lblGHMC.Text;
                    if (lblGHMC.Text == "")
                    {
                        objBE.ghmc = "N";
                    }
                }

                DataTable dt1 = new DataTable();

                objBE.Action = "R";
                dt1 = ObjMDL.GetEventFee(objBE, ConnKey);
                //  lblFee.Visible = true;
                lblFee.Text = dt1.Rows[0]["Payment"].ToString();
                // objCommon.BindDropDownLists(ddlLicenceFee, dt1, "Fee", "Payment_Type", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        //public void BindLicenceFeeG(string GHMC)
        //{
        //    try
        //    {

        //        objBE.EventId = ddlEvntType.SelectedValue;
        //        DataTable dt1 = new DataTable();

        //        objBE.Action = "R";
        //        objBE.ghmc = GHMC;
        //        dt1 = ObjMDL.GetEventFee(objBE, ConnKey);
        //        objCommon.BindDropDownLists(ddlLicenceFee, dt1, "Fee", "Payment_Type", "0");
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}
        //protected void ddlEvntType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindLicenceFee();
        //}

        //public void BindLicenceFee()
        //{
        //    try
        //    {

        //        objBE.EventId = ddlEvntType.SelectedValue;
        //        if (ddlEvntType.SelectedValue == "2")
        //        {

        //            objBE.Paymenttype = Rbtype.SelectedValue;
        //            objBE.ghmc = "N";
        //        }
        //        if (ddlEvntType.SelectedValue == "3")
        //        {

        //            objBE.Paymenttype = "1";
        //            objBE.ghmc = "N";
        //        }
        //        if (ddlEvntType.SelectedValue == "1")
        //        {
        //            objBE.Paymenttype = RbTypeP.SelectedValue;
        //            objBE.ghmc = lblGHMC.Text;
        //            if (lblGHMC.Text == "")
        //            {
        //                objBE.ghmc = "N";
        //            }
        //        }

        //        DataTable dt1 = new DataTable();

        //        objBE.Action = "R";
        //        dt1 = ObjMDL.GetEventFee(objBE, ConnKey);
        //        //  lblFee.Visible = true;
        //        lblFee.Text = dt1.Rows[0]["Payment"].ToString();
        //        // objCommon.BindDropDownLists(ddlLicenceFee, dt1, "Fee", "Payment_Type", "0");
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}
        protected void ddlEvntType_SelectedIndexChanged(object sender, EventArgs e)
        {

            Bindtickes();




        }
        public void Bindtickes()
        {
            try
            {
                if (ddlEvntType.SelectedValue == "2")
                {
                    Rbtype.Visible = true;
                    RbTypeP.Visible = false;
                }
                if (ddlEvntType.SelectedValue == "1")
                {
                    Rbtype.Visible = false;
                    RbTypeP.Visible = true;
                }
                if (ddlEvntType.SelectedValue == "3")
                {
                    BindLicenceFee();
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        //protected void ddlLicenceFee_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    objBE.EventId = ddlEvntType.SelectedValue;
        //    objBE.Paymenttype = ddlLicenceFee.SelectedValue;

        //    DataTable dt1 = new DataTable();

        //    objBE.Action = "SR";
        //    dt1 = ObjMDL.GetEventFee(objBE, ConnKey);
        //    if (dt1.Rows.Count > 0)
        //    {
        //       // fee.Visible = true;
        //        lblFee.Text = dt1.Rows[0]["Payment"].ToString();
        //    }
        //}
        protected void RbTypeT_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindLicenceFee();
        }

        protected void RbTypeP_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindLicenceFee();
        }
        protected void ddlLocality_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRevdistVill();
        }
        public void BindRevdistVill()
        {
            try
            {
                //DataTable dt1 = new DataTable();
                //objBE.Statecode = "36";
                //objBE.DistCode = ddlRevDistrict.SelectedValue;
                //objBE.MandCode = ddlMandal.SelectedValue;
                //objBE.VillCode = ddlLocality.SelectedValue;
                //objBE.Action = "R";
                //dt1 = ObjMDL.GetRenDS(objBE, ConnKey);
                //if (dt1.Rows.Count > 0)
                //{
                //    lblExDistCode.Text = dt1.Rows[0]["ExDist_Cd"].ToString();
                //    lblExStation.Text = dt1.Rows[0]["ExStation"].ToString();
                //    lblExDist.Text = dt1.Rows[0]["ExDist"].ToString();
                //    lblExStationCd.Text = dt1.Rows[0]["ExStationCode"].ToString();
                //}
                //else
                //{
                //    lblExDistCode.Text = "";
                //    lblExStation.Text = "";
                //    lblExDist.Text = "";
                //    lblExStationCd.Text = "";
                //}
                DataTable dt1 = new DataTable();
                objBE.Statecode = "36";
                objBE.DistCode = ddlRevDistrict.SelectedValue;
                objBE.MandCode = ddlMandal.SelectedValue;
                objBE.VillCode = ddlLocality.SelectedValue;
                objBE.Action = "R";
                dt1 = ObjMDL.GetRenDS(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    lblExDistCode.Text = dt1.Rows[0]["ExDist_Cd"].ToString();
                    lblExStation.Text = dt1.Rows[0]["ExStation"].ToString();
                    lblExDist.Text = dt1.Rows[0]["ExDist"].ToString();
                    lblExStationCd.Text = dt1.Rows[0]["ExStationCode"].ToString();
                    lblGHMC.Text = dt1.Rows[0]["GHMC"].ToString();
                    //lblSHOMob.Text = dt1.Rows[0]["SHOMob"].ToString();
                    BindEventType();
                }
                else
                {
                    lblExDistCode.Text = "";
                    lblExStation.Text = "";
                    lblExDist.Text = "";
                    lblExStationCd.Text = "";
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void txtEvnDate_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtEvnDate.Text))//txtEvnDate.Text != ""
            {
                objBE.EDate = txtEvnDate.Text; //DateTime.Parse(txtEvnDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.None).ToString("yyyy-MM-dd");
                objBE.DistCode = ddlRevDistrict.SelectedValue;
                objBE.Action = "ERD";
                DataTable dvd = new DataTable();
                dvd = objDL.EventReg_IUR(objBE, ConnKey);
                //dvd = ObjMDL.BindEvent(objBE, ConnKey);
                //if (dvd.Rows.Count > 0)
                //{
                objCommon.BindDropDownLists(ddlEvntTm, dvd, "SlotDesc", "Slot", "0");
            }
            else
            {
                objCommon.ShowAlertMessage("Please select Event Date");
                return;
            }
            //}
            //else
            //{
            //   BindEventTime();
            //}

        }
        public void BindEventTime()
        {
            try
            {


                DataTable dt = new DataTable();
                objBE.Action = "R";
                dt = ObjMDL.CommonMasters(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlEvntTm, dt, "SlotDesc", "Slot", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}