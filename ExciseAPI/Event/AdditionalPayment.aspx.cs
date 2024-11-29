using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Event
{
    public partial class AdditionalPayment : System.Web.UI.Page
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


            if (!IsPostBack)
            {

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                // lblUSer.Text = Session["UsrName"].ToString();

                // BindTypeofManf();
                pannelOK.Visible = false;
                // Viewdata();
                random();
                getCaptchaImage();


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
                        //ddlEvntType.SelectedValue = dt1.Rows[0]["Event_ID"].ToString();
                        Label5.Text = dt1.Rows[0]["Event"].ToString();
                        BindLicenceFee();
                        // ddlLicenceFee.SelectedValue = dt1.Rows[0]["Payment_Type"].ToString();
                        lblFee.Text = dt1.Rows[0]["License_Fee"].ToString();


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
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                if (CheckCaptcha())
                {

                    Viewdata();
                }
                else
                {
                    captch.Text = "";
                    getCaptchaImage();
                    lblError.Text = "Invalid Captcha";

                }


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

        //protected void GvSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    try
        //    {
        //        GvSupplier.PageIndex = e.NewPageIndex;
        //        Viewdata();
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        objCommon.ShowAlertMessage(ex.ToString());
        //    }
        //}
        protected void Viewdata()
        {

            objBE.Reg_Code = txtRegistrationNo.Text;//"360200001423"; //
            objBE.Action = "DAPP";
           

            DataTable dt1 = new DataTable();
            dt1 = objDL.EventReg_IUR(objBE, ConnKey);

            try
            {
                if (dt1.Rows.Count > 0)
                {
                    pannelOK.Visible = true;
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
                    //ddlEvntType.SelectedValue = dt1.Rows[0]["Event_ID"].ToString();
                    Label5.Text = dt1.Rows[0]["Event"].ToString();
                    BindLicenceFee();
                    // ddlLicenceFee.SelectedValue = dt1.Rows[0]["Payment_Type"].ToString();
                    lblFee.Text = dt1.Rows[0]["License_Fee"].ToString();
                    txtDtInsp.Text = dt1.Rows[0]["Diffential_Amt"].ToString();
                    txtRemarks.Text = dt1.Rows[0]["PaymentRemarks"].ToString();
                    lblError.Text = string.Empty;


                }

                else
                {
                    pannelOK.Visible = false;
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    objCommon.ShowAlertMessage("No Data Found");
                    // GvSupplier.Visible = false;

                    lblError.Text = string.Empty;

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

            try
            {
                // if (Validate())

                objBE.Reg_Code = lblReg.Text;
                Session["RegId"] = lblReg.Text;
                Session["DiffAmt"] = txtDtInsp.Text;
                DataTable dt = new DataTable();
                //   objBE.Reg_Code = Session["RegId"].ToString(); //lblDocReg.Text; ;//
                //       objBE.LicData = DateTime.Parse(txtDtInsp.Text.Trim(), provider, System.Globalization.DateTimeStyles.None).ToString("yyyy-MM-dd");
                //       objBE.Remarks = txtRemarks.Text;
                //objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                //objBE.Action = "SHSUB";
                //dt = objDL.EventReg_IUR(objBE, ConnKey);
                //if (dt.Rows.Count > 0)
                //{
                //    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());          
                //    Session["RegId"] = dt.Rows[0][0].ToString();
                //    pnldynamic.Visible = false;
                //    Viewdata();
                //}
                Response.Redirect("../Event/DiffPaymentDtls.aspx", false);



            }
            catch
            {

            }
        }


        protected bool Validate()
        {

            if (txtRegistrationNo.Text == "")
            {
                objCommon.ShowAlertMessage("Enter RegistrationNo");
                txtRegistrationNo.Focus();
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
        //protected void btnSave_Click(object sender, EventArgs e)
        //{



        //    DataTable dt = new DataTable();

        //    string fileNme = "", fileSizee = "", fileTypee = "";
        //    byte[] contentt = null;
        //    if (fluDoc.HasFile)
        //    {
        //        Stream fs = fluDoc.PostedFile.InputStream;
        //        BinaryReader br = new BinaryReader(fs);
        //        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //        string fileext = Path.GetExtension(fluDoc.PostedFile.FileName);
        //        //string mime =  MimeType.GetMimeType(bytes, FileUpload1.PostedFile.FileName);
        //        if (fileext == ".jpg" || fileext == ".PNG" || fileext == ".png" || fileext == ".jpeg" || fileext == ".JPG")
        //        {
        //            int len = fluDoc.PostedFile.ContentLength;
        //            if ((len / 1024) > 2048)
        //            {
        //                objCommon.ShowAlertMessage("File size is exceeded");
        //                fluDoc.Focus();
        //                return;
        //            }

        //            string fn = Path.GetFileName(fluDoc.PostedFile.FileName);
        //            fileNme = fn;
        //            fileSizee = len.ToString();
        //            fileTypee = fileext;
        //            contentt = bytes;
        //            dt = new DataTable();

        //        }

        //        else
        //        {
        //            objCommon.ShowAlertMessage("Please Upload .JPG/.jpg/.png/.PNG/.jpeg");
        //        }

        //        objBE.fileNme = fileNme;
        //        objBE.fileSizee = fileSizee;
        //        objBE.fileTypee = fileTypee;
        //        objBE.contentt = bytes;
        //        objBE.Reg_Code = lblDocReg.Text;
        //        objBE.DocRemarks = txtDocRemarks.Text;
        //        objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
        //        //objBE.UserName = Session["User"].ToString();
        //        objBE.Action = "Doc";

        //        dt = objDL.EventReg_IUR(objBE, ConnKey);
        //        if (dt.Rows.Count > 0)
        //        {
        //            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());

        //            Session["RegId"] = dt.Rows[0][0].ToString();



        //        }
        //    }  




        //}
        protected void btn_DpeoUpdate(object sender, EventArgs e)
        {

            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
            lblReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;

            DataTable dt = new DataTable();
            objBE.Reg_Code = lblReg.Text; //lblDocReg.Text; ;//
            objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
            objBE.Action = "SHSUB";
            dt = objDL.EventReg_IUR(objBE, ConnKey);
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                Session["RegId"] = dt.Rows[0][0].ToString();
                Viewdata();
            }
        }
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
                        // string Filetype = dt.Rows[0]["UploadDco_FileType"].ToString();
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
    }
}