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

namespace ExciseAPI.SHO
{
    public partial class EventPermission : System.Web.UI.Page
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
            if (Session["Role"] != null && Session["Role"].ToString() == "2" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                pannelOK.Visible = false;
                Viewdata();
                random();
                txt_DAmount.ReadOnly = true;

                DateTime StartDate = DateTime.Today;
            }
        }
        protected void GvSupplier_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    objBE.Reg_Code = ((Label)(gRow.FindControl("lblTypecode"))).Text;
                    objBE.Action = "SR";
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
                        //lblPaymentDetails.Text = dt1.Rows[0]["PaymentDetails"].ToString();

                        DataTable dt2 = new DataTable();
                        objBE.Reg_Code = ((Label)(gRow.FindControl("lblTypecode"))).Text;
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



                if (e.CommandName == "ViewDoc")
                {
                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                    RegDoc.Visible = true;
                    lblDocReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;
                    lblDocReg.Visible = false;
                    getapplicantdocs(lblDocReg.Text);
                }
                else
                {
                    RegDoc.Visible = false;
                }
                if (e.CommandName == "ViewPay")
                {
                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                    Payment.Visible = true;
                    lblAppReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;
                    //lblAppReg.Visible = false;
                    // getapplicantdocs(lblDocReg.Text);
                }
                else
                {
                    lblAppReg.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void getapplicantdocs(string REgNO)
        {
            try
            {
                // DataTable dt = objRegDL.GetGetUploadDocSelectDAL(Session["Licensetype"].ToString(), Session["System"].ToString(), Session["Licensem"].ToString(), Session["ApplicantId"].ToString(), ddl_Firm.SelectedValue.ToString(), "R");
                DataTable dt = new DataTable();
                objBE.ApplicationType = "1";

                objBE.Reg_Code = REgNO;

                objBE.Action = "DV";
                dt = objDL.GetGetUploadDocSelectDAL(objBE, ConnKey);
                grddocs.DataSource = dt;
                grddocs.DataBind();

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UserId"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");

            }
        }

        //public void Bindtickes()
        //{
        //    try
        //    {
        //        if (lbleventid.Text == "2")
        //        {
        //            Rbtype.Visible = true;
        //            RbTypeP.Visible = false;
        //        }
        //        if (lbleventid.Text == "1")
        //        {
        //            Rbtype.Visible = false;
        //            RbTypeP.Visible = true;
        //        }
        //        if (lbleventid.Text == "3")
        //        {
        //            BindLicenceFee();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}
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

        protected void GvSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvSupplier.PageIndex = e.NewPageIndex;
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
                objBE.Action = "SHO";
                objBE.ExDistCode = Session["EXDIST_CODE"].ToString();
                objBE.ExStation = Session["SHOID"].ToString();
                objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                dt = objDL.EventReg_IUR(objBE, ConnKey);


                if (dt.Rows.Count > 0)
                {
                    Session["RegId"] = dt.Rows[0][0].ToString();
                    lblReg.Text = dt.Rows[0][0].ToString();
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    GvSupplier.Visible = true;
                    GvSupplier.DataSource = dt;
                    GvSupplier.DataBind();
                    dt.Dispose();




                }
                else
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    //objCommon.ShowAlertMessage("No Data Found For This ");
                    GvSupplier.Visible = false;

                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
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
            if (txtDtInsp.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Date of inspection");
                txtDtInsp.Focus();
                return;
            }
            if (txtRemarks.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Remarks");
                txtRemarks.Focus();
                return;
            }
            if (string.IsNullOrEmpty(RbTypeP.SelectedValue))
            {
                objCommon.ShowAlertMessage("Please Select Radio button");
                txtRemarks.Focus();
                return;
            }

            if (RbTypeP.SelectedValue == "2")
            {
                //if (txt_DAmount.Text == "")
                //{
                //    objCommon.ShowAlertMessage("Enter Differential Amount");
                //    txt_DAmount.Focus();
                //    return;
                //}
                if (txt_DAmount.Text == "")
                {
                    objCommon.ShowAlertMessage("Enter Differential Amount");
                    txt_DAmount.Focus();
                    return;
                }
                else
                {
                    if (!objValidate.IsNumberOk(txt_DAmount.Text))
                    {
                        objCommon.ShowAlertMessage("Enter Differential Amount (Numeric)");
                        txt_DAmount.Focus();
                        return;
                    }
                    if (objValidate.IsNumberOk(txt_DAmount.Text))//  || txt_DAmount.Text=="0"
                    {
                        if (txt_DAmount.Text == "0")
                        {
                            objCommon.ShowAlertMessage("Enter Differential Amount(Not Zero) ");
                            txt_DAmount.Focus();
                            return;
                        }
                    }
                }
            }
            try
            {
                // if (Validate())

                objBE.Reg_Code = lblReg.Text;
                DataTable dt = new DataTable();
                //   objBE.Reg_Code = Session["RegId"].ToString(); //lblDocReg.Text; ;//
                objBE.LicData = DateTime.Parse(txtDtInsp.Text.Trim(), provider, System.Globalization.DateTimeStyles.None).ToString("yyyy-MM-dd");
                objBE.Remarks = txtRemarks.Text;
                objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                if (RbTypeP.SelectedValue == "1")
                {
                    objBE.Action = "SHSUB";
                    dt = objDL.EventReg_IUR(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        Session["RegId"] = dt.Rows[0][0].ToString();
                        pnldynamic.Visible = false;
                        Panel2.Visible = false;
                        Viewdata();
                    }
                }
                else if (RbTypeP.SelectedValue == "2")
                {
                    objBE.License_Fee = txt_DAmount.Text;
                    objBE.Action = "DPAY";
                    dt = objDL.EventReg_IUR(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        Session["RegId"] = dt.Rows[0][0].ToString();
                        pnldynamic.Visible = false;
                        Panel2.Visible = false;
                        Viewdata();
                    }
                }
                else
                {
                    objCommon.ShowAlertMessage("Please select forward for approval or return for additional amount ");
                    return;
                }
                //if (RbTypeP.SelectedValue == "1")
                //{
                //    objBE.Action = "SHSUB";
                //}
                //else
                //{
                //    objBE.License_Fee = txt_DAmount.Text;
                //    objBE.Action = "DPAY";
                //}
                //dt = objDL.EventReg_IUR(objBE, ConnKey);
                //if (dt.Rows.Count > 0)
                //{
                //    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());          
                //    Session["RegId"] = dt.Rows[0][0].ToString();
                //    pnldynamic.Visible = false;
                //    Viewdata();
                //}




            }
            catch
            {

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDtInsp.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Date of inspection");
                txtDtInsp.Focus();
                return;
            }
            if (txtRemarks.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Remarks");
                txtRemarks.Focus();
                return;
            }
            if (txt_DAmount.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Diffential Amount");
                txt_DAmount.Focus();
                return;
            }
            DataTable dt = new DataTable();

            objBE.Reg_Code = lblReg.Text;
            objBE.License_Fee = txt_DAmount.Text;
            objBE.DocRemarks = txtRemarks.Text;
            objBE.LicData = DateTime.Parse(txtDtInsp.Text.Trim(), provider, System.Globalization.DateTimeStyles.None).ToString("yyyy-MM-dd");
            objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
            //objBE.UserName = Session["User"].ToString();
            objBE.Action = "DPAY";

            dt = objDL.EventReg_IUR(objBE, ConnKey);
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());

                Session["RegId"] = dt.Rows[0][0].ToString();
                pannelOK.Visible = false;
                Panel2.Visible = false;
                Viewdata();

            }
        }




        //  }
        //protected void btn_DpeoUpdate(object sender, EventArgs e)
        //{

        //    LinkButton btnsubmit = sender as LinkButton;
        //    GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
        //    lblReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;

        //    DataTable dt = new DataTable();
        //    objBE.Reg_Code = lblReg.Text; //lblDocReg.Text; ;//
        //    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
        //    objBE.Action = "SHSUB";
        //    dt = objDL.EventReg_IUR(objBE, ConnKey);
        //    if (dt.Rows.Count > 0)
        //    {
        //        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());          
        //        Session["RegId"] = dt.Rows[0][0].ToString();
        //        Viewdata();
        //    }
        //}
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = new DataTable();
        //    //  string fileNme = "", fileSizee = "", fileTypee = "";
        //    byte[] contentt = null;
        //    if (fluDoc.HasFile)
        //    {
        //        Stream fs = fluDoc.PostedFile.InputStream;
        //        BinaryReader br = new BinaryReader(fs);
        //        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //        string mime = MimeType.GetMimeType(bytes, fluDoc.PostedFile.FileName);

        //        //Set the contenttype based on File Extension
        //        if (mime == "application/pdf")
        //        {
        //            int len = fluDoc.PostedFile.ContentLength;
        //            if ((len / 1024) > 5120)
        //            {

        //                objCommon.ShowAlertMessage("File size is exceeded");
        //                fluDoc.Focus();
        //                return;
        //            }
        //            string fileTypee = Path.GetExtension(fluDoc.PostedFile.FileName);
        //            string fileNme = Path.GetFileName(fluDoc.PostedFile.FileName);
        //            objBE.fileTypee = fileTypee;
        //            objBE.contentt = bytes;
        //            objBE.fileSizee = len.ToString();

        //            byte[] File = br.ReadBytes((Int32)fs.Length);

        //            objBE.fileNme = fileNme;
        //            objBE.fileSizee = len.ToString();
        //            objBE.fileTypee = fileTypee;
        //            objBE.contentt = bytes;
        //            objBE.Reg_Code = lblDocReg.Text;
        //            objBE.DocRemarks = txtDocRemarks.Text;
        //            objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
        //            //objBE.UserName = Session["User"].ToString();
        //            objBE.Action = "Doc";

        //            dt = objDL.EventReg_IUR(objBE, ConnKey);
        //            if (dt.Rows.Count > 0)
        //            {
        //                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
        //                RegDoc.Visible = false;
        //                Session["RegId"] = dt.Rows[0][0].ToString();



        //            }
        //        }




        //    }
        //}
        protected void grddocs_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {

                if (e.CommandName == "View")
                {
                    DataTable dt = new DataTable();
                    GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Label lblDocid = (Label)gvrow.FindControl("lbldoccd");
                    Label lblAppid = (Label)gvrow.FindControl("lblAppid");
                    Label lblDocSno = (Label)gvrow.FindControl("lbldocsno");

                    Label lbl_Apptype = (Label)gvrow.FindControl("lbl_Apptype");

                    objBE.UploadDco_Code = lblDocid.Text;
                    objBE.SNo = lblDocSno.Text;
                    objBE.Reg_Code = lblAppid.Text;
                    objBE.ApplicationType = lbl_Apptype.Text;
                    objBE.Action = "V";
                    dt = objDL.GetGetUploadDocSelectDAL(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["UploadDco_File"];
                        string Filetype = dt.Rows[0]["UploadDco_FileType"].ToString();
                        Session["Ftype"] = Filetype;
                        // string fileName = "Document_Details.pdf"; //dt.Rows[0]["UploadDco_Name"].ToString();
                        //if (Filetype.ToLower() == ".pdf")
                        //{
                        Session["bytes"] = null;
                        Session["bytes"] = bytes;

                        string url = "../PrintPage.aspx";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.open('");
                        sb.Append(url);
                        sb.Append("','_blank');");
                        sb.Append("</script>");

                        ClientScript.RegisterStartupScript(this.GetType(),
                                     "script", sb.ToString());

                        // }
                        //ImgDoc.Visible = false;
                        //IpdfDoc.Visible = true;
                        //System.IO.File.WriteAllBytes(Server.MapPath("~/Files/Uploaded_Bill.pdf"), bytes);
                        //IpdfDoc.Attributes.Add("src", "../../Files/Uploaded_Bill.pdf");
                        //mp1.Show();
                    }


                }
            }

            catch (Exception ex)
            {
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
        protected void RbTypeP_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_DAmount.ReadOnly = true;
            if (RbTypeP.SelectedValue == "1")
            {

            }
            else
            {
                txt_DAmount.ReadOnly = false;
            }
        }
    }
}