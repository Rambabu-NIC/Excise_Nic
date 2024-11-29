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
    public partial class EventRegistration : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                //Calendar1.StartDate = DateTime.Now;
                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                // lblUSer.Text = Session["UsrName"].ToString();
                //GetTypeManFDAL();
                //BindDistrict();
                //Viewdata();
                // random();
                BindRevDistrict();
                //BindEventTime();
                // BindEventTime();
                //BindExciseDistrict();
                 getCaptchaImage();
                GetData();
            }

        }

        public void GetData()
        {
            if (!string.IsNullOrEmpty(Session["EventMobile"].ToString()))
            {
                txtMobile.Text = Session["EventMobile"].ToString();
                txtMobile.Attributes.Add("readonly", "readonly");
            }
            if (!string.IsNullOrEmpty(Session["EventMobile"].ToString()))
            {
                txtEmail.Text = Session["EventEmail"].ToString();
                txtEmail.Attributes.Add("readonly", "readonly");
            }
            //if (!string.IsNullOrEmpty(Session["EventMobile"].ToString()))
            //{
               

            //}
            
        }

        public void BindEventSlot(int IsRegionLevel)
        {
            

            if ((Convert.ToInt16(ddlRevDistrict.SelectedValue) > 0 && IsRegionLevel==1) 
                || (Convert.ToInt16(ddlMandal.SelectedValue) > 0 && IsRegionLevel == 2) || 
                (Convert.ToInt16(ddlLocality.SelectedValue) > 0 && IsRegionLevel == 3))
            {
                txtEvnDate.Text = Session["EventDate"].ToString();
                txtEvnDate.Attributes.Add("readonly", "readonly");
                objBE.EDate = DateTime.Parse(txtEvnDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.None).ToString("yyyy-MM-dd");
                objBE.DistCode = ddlRevDistrict.SelectedValue;
                if (IsRegionLevel == 2 || IsRegionLevel == 3)
                {
                    objBE.MandCode = ddlMandal.SelectedValue;
                }
                if (IsRegionLevel == 3)
                {
                    objBE.VillCode = ddlLocality.SelectedValue;
                }
                objBE.IsRegionLevel = IsRegionLevel;
                objBE.Action = "ERD";
                DataTable dvd = new DataTable();
                dvd = null;
                ddlEvntTm.Items.Clear();
                dvd = objDL.EventReg_IUR(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlEvntTm, dvd, "SlotDesc", "Slot", "0");

            }
            else
            {
                lblError.Text = "Please select District/Mandal/Village .....";
                return;
            }
        }

        protected void btnImgRefresh_Click(object sender, ImageClickEventArgs e)
        {
            captch.Text = "";
            getCaptchaImage();
        }

        public void getCaptchaImage()
        {
            Captcha ci = new Captcha();
            string text = Captcha.generateRandomCode();
            ViewState["captchtext"] = text;
            Image2.ImageUrl = "~/Assets/cpImg/cpImage.aspx?randomNo=" + text;
        }
        protected bool CheckCaptcha()
        {
            if (captch.Text == ViewState["captchtext"].ToString())
            {
                return true;
            }
            else
            {
                lblError.Text = "Invalid Captcha.";
                captch.Text = "";
                return false;
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
        protected void btn_Save_Click(object sender, EventArgs e)
        {

            try
            {
                if (Validate())
                {
                    if (CheckCaptcha())
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
                        objBE.EDate = DateTime.Parse(txtEvnDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.None).ToString("yyyy-MM-dd");
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
                        //objBE.UserName = Session["User"].ToString();
                        objBE.Action = "I";
                        DataTable dt = new DataTable();
                        dt = objDL.EventReg_IUR(objBE, ConnKey);
                        if (dt.Rows.Count > 0)
                        {
                            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                            // Clear();
                            // Viewdata();
                            Session["RegId"] = dt.Rows[0][0].ToString();

                            Response.Redirect("../Event/ACKEventReg.aspx", false);

                        }
                    }

                
                else
                {
                    captch.Text = "";
                    getCaptchaImage();
                    lblError.Text = "Invalid Captcha";

                }
            }
            }
            catch
            {

            }
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
        //public void BindExciseDistrict()
        //{
        //    try
        //    {

        //        objBE.Statecode = "36";
        //        DataTable dt1 = new DataTable();
        //        objBE.Action = "R";
        //        dt1 = ObjMDL.GetDistDL(objBE, ConnKey);
        //        objCommon.BindDropDownLists(ddlExciseDistrict, dt1, "DistName", "DistCode", "0");
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}
        //public void BindExMandal()
        //{
        //    try
        //    {
        //        DataTable dt1 = new DataTable();
        //        objBE.Statecode = "36";
        //        objBE.DistCode = ddlExciseDistrict.SelectedValue;
        //        objBE.Action = "R";
        //        dt1 = ObjMDL.GetmandalsDAL(objBE, ConnKey);
        //        objCommon.BindDropDownLists(ddlExciseStation, dt1, "MandName", "MandCode", "0");
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
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
         
            if (txtAdharNum.Text =="")
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
                //ddlEvntTm.Focus();
                return false;
            }
            if (ddlEvntType.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Please Select Type Of Event");
                //ddlEvntType.Focus();
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
            if (captch.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Captcha");
                captch.Focus();
                return false;

            }

            return true;


        }
        protected void ddlRevDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEvntTm.Items.Clear();
            Distclear();
            ///BindEventSlot(1);
            BindRevMandal();
            if (ddlRevDistrict.SelectedValue == "31")
            {
                lblbmandal.Text = "Police station";
            }
            else
            {
                lblbmandal.Text = "Mandal";
            }
            //txtEvnDate.Text = "";
            //ddlEvntTm.ClearSelection();
        }
        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEvntTm.Items.Clear();
            Distclear();
            if (ddlRevDistrict.SelectedValue == "31")
            {
                lblExDist.Text = "";
                lblExStation.Text = "";
                lblSHOMob.Text = "";
                ddlLocality.Enabled = false;

                ddlLocality.ClearSelection();
                BindEventSlot(2);
                BindRevdistVill();

            }
            else
            {

                lblExDist.Text = "";
                lblExStation.Text = "";
                lblSHOMob.Text = "";
                ddlLocality.Enabled = true;
                //BindEventSlot(2);
                BindVillage();
            }
        }
        //protected void ddlExciseDistrict_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindExMandal();

        //}

        public void Distclear()
        {          
            //ddlMandal.SelectedIndex = 0;
            //ddlLocality.SelectedIndex = 0;
            lblExDist.Text = "";
            lblExStation.Text = "";
            lblSHOMob.Text = "";
            ddlLocality.Enabled = false;
            ddlLocality.ClearSelection();
            //BindEventType();
            lblExDistCode.Text = "";
            lblExStation.Text = "";
            lblExDist.Text = "";
            lblExStationCd.Text = "";
            //ddlEvntTm.DataSource = null;
            //ddlEvntTm.DataBind();
            //ddlEvntTm.SelectedIndex = 0;
            //ddlEvntType.SelectedIndex = 0;
            ddlEvntType.ClearSelection();
            txtEvent.Text = "";
            Rbtype.Visible = false;
            RbTypeP.Visible = false;
            RbTypeP.ClearSelection();
            Rbtype.ClearSelection();
            lblFee.Text = "";
        }
        public void MandalClear()
        {
            lblSHOMob.Text = "";
            lblExDistCode.Text = "";
            lblExStation.Text = "";
            lblExDist.Text = "";
            lblExStationCd.Text = "";
            //ddlEvntTm.SelectedIndex = 0;
            ddlEvntType.ClearSelection();
            txtEvent.Text = "";
            Rbtype.Visible = false;
            RbTypeP.Visible = false;
            RbTypeP.ClearSelection();
            Rbtype.ClearSelection();
            lblFee.Text = "";
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
            // txtLicen.Text = "";
            txtEvent.Text = "";

        }
        public void BindEventType()
        {
            try
            {


                DataTable dt1 = new DataTable();
                objBE.Action = "ER";
                dt1 = ObjMDL.GetEventFee(objBE, ConnKey);
                //ddlEvntType.Items.Insert(0, System.Web.UI.WebControls("--Select--", "0"));
               //ddlEvntType.Items.Insert(0, SyeListItem("--Select--", "0"));
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
            lblFee.Text = "";
            try
            {

                objBE.EventId = ddlEvntType.SelectedValue;
                if (ddlEvntType.SelectedValue == "1")
                {
                    objBE.Paymenttype = RbTypeP.SelectedValue;
                    objBE.ghmc = lblGHMC.Text;
                    if (lblGHMC.Text == "")
                    {
                        objBE.ghmc = "N";
                    }
                }
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
        protected void ddlEvntType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFee.Text = "";
            Bindtickes();
        }
        public void Bindtickes()
        {
            try
            {
                Rbtype.Visible = false;
                RbTypeP.Visible = false;
                RbTypeP.ClearSelection();
                Rbtype.ClearSelection();

                if (ddlEvntType.SelectedValue == "1")
                {
                    RbTypeP.SelectedValue = "1";
                    RbTypeP.Visible = true;
                }
                if (ddlEvntType.SelectedValue == "2")
                {
                    Rbtype.SelectedValue = "1";
                    Rbtype.Visible = true;
                }
                //if (ddlEvntType.SelectedValue == "3")
                //{               
                //    Rbtype.Visible = false;
                //    RbTypeP.Visible = false;
                //}
                if(Convert.ToInt16(ddlEvntType.SelectedValue) > 0)
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
        //    //objBE.Paymenttype = ddlLicenceFee.SelectedValue;

        //    DataTable dt1 = new DataTable();

        //    objBE.Action = "SR";
        //    dt1 = ObjMDL.GetEventFee(objBE, ConnKey);
        //     if (dt1.Rows.Count > 0)
        //        {
        //            fee.Visible = true;
        //            lblFee.Text = dt1.Rows[0]["Payment"].ToString();
        //     }
        //}
        protected void ddlLocality_SelectedIndexChanged(object sender, EventArgs e)
        {
            MandalClear();
            BindEventSlot(3);
            BindRevdistVill();
           
        }
        public void BindRevdistVill()
        {
            try
            {
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
                    lblSHOMob.Text = dt1.Rows[0]["SHOMob"].ToString();
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


        protected void RbTypeT_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindLicenceFee();
        }

        protected void RbTypeP_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindLicenceFee();
        }
        protected void btnReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Event/EventRegistration.aspx", false);
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Event/EditEventRegistration.aspx", false);
        }
        protected void btnUploadDocs_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Event/UploadDoc.aspx", false);
        }
        protected void btnPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Event/PaymentDtls.aspx", false);
        }
        protected void txtEvnDate_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtEvnDate.Text))//txtEvnDate.Text != ""
            {
                objBE.EDate = DateTime.Parse(txtEvnDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.None).ToString("yyyy-MM-dd");
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

        protected void txtAdharNum_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (Verhoeff.validateVerhoeff(txtAdharNum.Text))
                {

                    // string adh= Helper.Decrypt(Helper.Encrypt(aadhar.Text));

                    // string adh = new String('X', 8) + aadhar.Text.Substring(aadhar.Text.Length - 4, 4);

                }
                else
                {
                    txtAdharNum.Text = "";
                    objCommon.ShowAlertMessage("Entered Aadhar Number is Not Valid");
                    // ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Member Registered Sucessfully');", true);
                   
                }

            }
            catch (Exception ex)
            {

            }
        }
        public static class Verhoeff
        {

            // The multiplication table
            static int[,] d = new int[,]
            {
            {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
            {1, 2, 3, 4, 0, 6, 7, 8, 9, 5},
            {2, 3, 4, 0, 1, 7, 8, 9, 5, 6},
            {3, 4, 0, 1, 2, 8, 9, 5, 6, 7},
            {4, 0, 1, 2, 3, 9, 5, 6, 7, 8},
            {5, 9, 8, 7, 6, 0, 4, 3, 2, 1},
            {6, 5, 9, 8, 7, 1, 0, 4, 3, 2},
            {7, 6, 5, 9, 8, 2, 1, 0, 4, 3},
            {8, 7, 6, 5, 9, 3, 2, 1, 0, 4},
            {9, 8, 7, 6, 5, 4, 3, 2, 1, 0}
            };

            // The permutation table
            static int[,] p = new int[,]
            {
            {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
            {1, 5, 7, 6, 2, 8, 3, 0, 9, 4},
            {5, 8, 0, 3, 7, 9, 6, 1, 4, 2},
            {8, 9, 1, 6, 0, 4, 3, 5, 2, 7},
            {9, 4, 5, 3, 1, 2, 6, 8, 7, 0},
            {4, 2, 8, 6, 5, 7, 3, 9, 0, 1},
            {2, 7, 9, 3, 8, 0, 6, 4, 1, 5},
            {7, 0, 4, 6, 9, 1, 3, 2, 5, 8}
            };

            // The inverse table
            static int[] inv = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };


            /// <summary>
            /// Validates that an entered number is Verhoeff compliant.
            /// NB: Make sure the check digit is the last one!
            /// </summary>
            /// <param name="num"></param>
            /// <returns>True if Verhoeff compliant, otherwise false</returns>
            public static bool validateVerhoeff(string num)
            {
                int c = 0;
                int[] myArray = StringToReversedIntArray(num);

                for (int i = 0; i < myArray.Length; i++)
                {
                    c = d[c, p[(i % 8), myArray[i]]];
                }

                return c == 0;

            }

            /// <summary>
            /// For a given number generates a Verhoeff digit
            /// Append this check digit to num
            /// </summary>
            /// <param name="num"></param>
            /// <returns>Verhoeff check digit as string</returns>
            public static string generateVerhoeff(string num)
            {
                int c = 0;
                int[] myArray = StringToReversedIntArray(num);

                for (int i = 0; i < myArray.Length; i++)
                {
                    c = d[c, p[((i + 1) % 8), myArray[i]]];
                }

                return inv[c].ToString();
            }


            /// <summary>
            /// Converts a string to a reversed integer array.
            /// </summary>
            /// <param name="num"></param>
            /// <returns>Reversed integer array</returns>
            private static int[] StringToReversedIntArray(string num)
            {
                int[] myArray = new int[num.Length];

                for (int i = 0; i < num.Length; i++)
                {
                    myArray[i] = int.Parse(num.Substring(i, 1));
                }

                Array.Reverse(myArray);

                return myArray;

            }
        }
    }
}