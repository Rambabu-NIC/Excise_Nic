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
    public partial class UploadDoc : System.Web.UI.Page
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
            //if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            //{
            //    //  Response.Redirect("~/Error.aspx");
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
            Check_applicantdocs();
            if (!IsPostBack)
            {

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                // lblUSer.Text = Session["UsrName"].ToString();
                //GetTypeManFDAL();
                //BindDistrict();
                //Viewdata();
                random();
                BindUploadDoc();
                getapplicantdocs();
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
                lblmsg.Text = "Invalid Captcha.";
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
                // hf.Value = num;
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
        protected void BindUploadDoc()
        {                                                                               
            DataTable dt = new DataTable();
            try
            {


                //    objBE.Reg_Code = Session["RegNo"].ToString();
                //    objBE.ApplicationType = "1";
                //    objBE.Action = "E";
                //    dt = objDL.GetGetUploadDocSelectDAL(objBE, ConnKey);
                //    //dt = objRegDL.GetGetUploadDocSelectDAL(Session["Licensetype"].ToString(), Session["System"].ToString(), Session["Licensem"].ToString(), Session["ApplicantId"].ToString(), ddl_Firm.SelectedValue.ToString(), "S");
                //    if (dt.Rows.Count > 0)
                //    {
                //        objCommon.BindDropDownLists(ddl_Doc, dt, "UploadDco_Name", "UploadDco_Code", "0");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
                //    Response.Redirect("~/Error.aspx");

                //}
                objBE.Reg_Code = Session["RegNo"].ToString();
                objBE.ApplicationType = "1";
                objBE.Action = "E1";
                dt = objDL.GetGetUploadDocSelectDAL(objBE, ConnKey);
                //dt = objRegDL.GetGetUploadDocSelectDAL(Session["Licensetype"].ToString(), Session["System"].ToString(), Session["Licensem"].ToString(), Session["ApplicantId"].ToString(), ddl_Firm.SelectedValue.ToString(), "S");
                if (dt.Rows.Count > 0)
                {
                    objCommon.BindDropDownLists(ddl_Doc, dt, "UploadDco_Name", "UploadDco_Code", "0");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
                if (ddl_Doc.SelectedValue != "" && ddl_Doc.SelectedValue != "0")
                {
                    if (FileUpload_docs.HasFile)
                    {
                        Stream fs = FileUpload_docs.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        string mime = MimeType.GetMimeType(bytes, FileUpload_docs.PostedFile.FileName);

                        //Set the contenttype based on File Extension
                        if (mime == "application/pdf")
                        {
                            int len = FileUpload_docs.PostedFile.ContentLength;
                            if ((len / 1024) > 5120)
                            {

                                objCommon.ShowAlertMessage("File size is exceeded");
                                FileUpload_docs.Focus();
                                return;
                            }
                            string fileext = Path.GetExtension(FileUpload_docs.PostedFile.FileName);
                            string filname = Path.GetFileName(FileUpload_docs.PostedFile.FileName);

                            objBE.UploadFiletype = fileext;
                            objBE.UploadFile = bytes;


                            try
                            {


                                byte[] File = br.ReadBytes((Int32)fs.Length);

                                objBE.Reg_Code = Session["RegNo"].ToString().Trim();
                                objBE.ApplicationType = "1";
                                objBE.UploadDco_Code = ddl_Doc.SelectedValue.ToString();
                                objBE.UploadDco_FileID = "1" + ddl_Doc.SelectedValue.ToString();
                                objBE.Action = "I";
                                objDL.GetGetUploadDocSelectDAL(objBE, ConnKey);
                                BindUploadDoc();
                                getapplicantdocs();
                                Check_applicantdocs();
                                objCommon.ShowAlertMessage("Uploaded Successfully");
                                return;

                            }
                             catch (Exception ex)
                             {
                                 ExceptionLogging.SendExcepToDB(ex, Session["UserId"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                                 Response.Redirect("~/Error.aspx");
                             
                             }
                    }

                        if (mime == "image/jpeg" || mime == "image/png" || mime == "image/jpg")
                        {

                            int len = FileUpload_docs.PostedFile.ContentLength;
                            if ((len / 1024) > 2048)
                            {

                                objCommon.ShowAlertMessage("File size is exceeded");
                                FileUpload_docs.Focus();
                                return;
                            }
                            string fileext = Path.GetExtension(FileUpload_docs.PostedFile.FileName);
                            string filname = Path.GetFileName(FileUpload_docs.PostedFile.FileName);
                            objBE.UploadDco_Code = ddl_Doc.SelectedValue.ToString();
                            objBE.UploadFiletype = fileext;
                            //objBE.UploadDco_FileID = fileext;
                            objBE.UploadFile = bytes;
                            objBE.Reg_Code = Session["RegNo"].ToString().Trim();
                            objBE.ApplicationType = "1";
                            objBE.Action = "I";
                            objDL.GetGetUploadDocSelectDAL(objBE, ConnKey);
                            BindUploadDoc();
                            getapplicantdocs();
                             Check_applicantdocs();
                            objCommon.ShowAlertMessage("Uploaded Successfully");
                            return;
                            // objRegBE.PhotoContent = bytes;
                        }
                        else
                        {

                            objCommon.ShowAlertMessage("Invalid file");
                            return;

                        }
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("Please Upload the file");
                        return;

                    }
                }

                else
                {
                    objCommon.ShowAlertMessage("(please select upload Name,");
                    return;
                }
            
           
                //}

            }
        public string GetImage(object img)
        {
            if (img != DBNull.Value)
            {
                return "data:application/pdf;base64," + Convert.ToBase64String((byte[])img);
            }
            else
            {
                return "";
            }
        }
        protected void getapplicantdocs()
        {
            try
            {
                // DataTable dt = objRegDL.GetGetUploadDocSelectDAL(Session["Licensetype"].ToString(), Session["System"].ToString(), Session["Licensem"].ToString(), Session["ApplicantId"].ToString(), ddl_Firm.SelectedValue.ToString(), "R");
                DataTable dt = new DataTable();
                objBE.ApplicationType = "1";

                objBE.Reg_Code = Session["RegNo"].ToString().Trim();

                objBE.Action = "AR";
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

        protected void Check_applicantdocs()
        {
            try
            {
                // DataTable dt = objRegDL.GetGetUploadDocSelectDAL(Session["Licensetype"].ToString(), Session["System"].ToString(), Session["Licensem"].ToString(), Session["ApplicantId"].ToString(), ddl_Firm.SelectedValue.ToString(), "R");
                DataTable dt = new DataTable();
                objBE.ApplicationType = "1";

                objBE.Reg_Code = Session["RegNo"].ToString().Trim();

                objBE.Action = "ARC";
                dt = objDL.GetGetUploadDocSelectDAL(objBE, ConnKey);
                if (dt.Rows.Count >= 2)
                {
                    btnNext.Enabled = true;

                }
                else
                {
                    btnNext.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UserId"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");

            }
        }
        protected void grddocs_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {
                if (e.CommandName == "Dlt")
                {

                    DataTable dt = new DataTable();
                    GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    //DELETE = "D";
                    Label lblDocid = (Label)gvrow.FindControl("lbldoccd");
                    Label lblAppid = (Label)gvrow.FindControl("lblAppid");

                    Label lbl_Apptype = (Label)gvrow.FindControl("lbl_Apptype");

                    Label lblDocSno = (Label)gvrow.FindControl("lbldocsno");

                    objBE.UploadDco_Code = lblDocid.Text;
                    objBE.Reg_Code = lblAppid.Text;
                    objBE.ApplicationType = lbl_Apptype.Text;

                    objBE.SNo = lblDocSno.Text;
                    objBE.Action = "D";

                    dt = objDL.GetGetUploadDocSelectDAL(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        getapplicantdocs();
                        objCommon.ShowAlertMessage("Record Not Deleted Successfully");
                        return;
                    }
                    else
                    {
                        getapplicantdocs();
                        objCommon.ShowAlertMessage("Record Deleted Successfully");
                        BindUploadDoc();
                        Check_applicantdocs();
                        return;

                    }
                    // }
                }
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
                        // string fileName = "Document_Details.pdf"; //dt.Rows[0]["UploadDco_Name"].ToString();
                        //if (Filetype.ToLower() == ".pdf")
                        //{
                        Session["bytes"] = null;
                        Session["bytes"] = bytes;
                        Session["Ftype"] = Filetype;
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
        protected void lnkViewDoc_Click(object sender, EventArgs e)
        {
            // GetDocView();
            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;

            // mp1.Show();
        }
        protected void GetDocView()
        {

            //dt = new DataTable();
            //try
            //{
            //  dt = objRegDL.GetGetUploadDocSelectDAL(Session["Licensetype"].ToString(), Session["System"].ToString(), Session["Licensem"].ToString(), Session["ApplicantId"].ToString(), ddl_Firm.SelectedValue.ToString(), "R");
            //   // dt = objRegDL.GetApplicantFirmIDDAL(Session["ApplicantId"].ToString(), "D");
            //    if (dt.Rows.Count > 0)
            //    {

            //    }
            //    else
            //    {

            //    }
            //}
            //catch (Exception ex)
            //{
            //    ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            //    Response.Redirect("~/Error.aspx");
            //}
        }

        protected void btnPrvious_Click(object sender, EventArgs e)
        {
            Session["RegId"] = Session["RegNo"].ToString().Trim();
            Response.Redirect("~/Event/EditEventRegistration.aspx", false);
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
        if (CheckCaptcha())
        {
            Session["RegId"] = Session["RegNo"].ToString().Trim();
            Response.Redirect("~/Event/PaymentDtls.aspx", false);
        }
        else
        {
            captch.Text = "";
            getCaptchaImage();
            lblmsg.Text = "Invalid Captcha";

        }
        }
        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // if (Validate())
        //        {
        //            objBE.Reg_Code = Session["RegNo"].ToString();

        //            //  objBE.Status = "1";

        //            objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
        //            //objBE.UserName = Session["User"].ToString();
        //            objBE.Action = "S";
        //            DataTable dt = new DataTable();
        //            dt = objDL.EventReg_IUR(objBE, ConnKey);
        //            if (dt.Rows.Count > 0)
        //            {
        //                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
        //                Response.Redirect("~/Event_Default.aspx",false);
        //                // Viewdata();
        //               // RptReg.Visible = false;

        //            }
        //        }

        //    }
        //    catch
        //    {

        //    }
        //}
    }
}