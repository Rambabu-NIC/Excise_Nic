using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Excise_BE;
using Excise_DAL;

namespace ExciseAPI.Supplier
{
    public partial class ViewMBRenewal : System.Web.UI.Page
    {
        Supplier_BE objSupBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_BE objBE = new Master_BE();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && (Session["Role"].ToString() == "2" || Session["Role"].ToString() == "4" ||
               Session["Role"].ToString() == "7" || Session["Role"].ToString() == "50" || Session["Role"].ToString() == "27" || Session["Role"].ToString() == "55"
               || Session["Role"].ToString() == "54" || Session["Role"].ToString() == "28" || Session["Role"].ToString() == "29" || Session["Role"].ToString() == "3")
               && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                divdeptActions.Visible = false;
                if(Session["Role"].ToString() != "3")
                {
                    divdeptActions.Visible = true;
                }
                BindDetails();
            }
        }
        public DataSet GetViewSupplierDetails
        {
            get
            {
                return ViewState["GetViewSupplierDetails"] as DataSet;
            }
            set
            {
                ViewState["GetViewSupplierDetails"] = value;
            }
        }
        public void BindDetails()
        {
            string Retailer_Code = Session["RenewalID"].ToString();
            string ApplicationNo = Session["ApplicationNo"].ToString();
            int Type_Man_Cd = Convert.ToInt32(Session["Type_Man_Cd"].ToString());
            GetViewSupplierDetails = objDL.GetViewSupplierRenewalDetails(Retailer_Code,ApplicationNo,Type_Man_Cd, ConnKey);
            if (GetViewSupplierDetails.Tables.Count > 0)
            {
                if (GetViewSupplierDetails.Tables[0].Rows.Count > 0)
                {
                    gvdetails.DataSource = GetViewSupplierDetails.Tables[0];
                    gvdetails.DataBind();
                }
                if (GetViewSupplierDetails.Tables[1].Rows.Count > 0)
                {
                    gvPaymentDetails.DataSource = GetViewSupplierDetails.Tables[1];
                    gvPaymentDetails.DataBind();
                }
                if (GetViewSupplierDetails.Tables[3].Rows.Count > 0)
                {
                    gvFlowDetails.DataSource = GetViewSupplierDetails.Tables[3];
                    gvFlowDetails.DataBind();

                    //if(GetViewSupplierDetails.Tables[3].Rows.Count > 4 && Session["Role"].ToString() == "4") 
                    //{
                    //    btnApprove.Visible = true;
                    //    btnReject.Visible = true;
                    //}
                    int SLNO = GetViewSupplierDetails.Tables[3].Rows.Count - 1;

                    var item = GetViewSupplierDetails.Tables[3].Rows[SLNO];

                    if (item["Current_Level1"].ToString() == "8" && item["Next_Level1"].ToString() == "4" && Session["Role"].ToString() == "54")
                    {
                        btnApprove.Visible = true;
                        btnReject.Visible = true;
                        btnForward.Visible = false;
                    }
                    divendrosement.Visible = false;
                    if (item["Next_Level1"].ToString() == "5")
                    {
                        divendrosement.Visible = true;
                    }
                    else
                    {
                        if (GetViewSupplierDetails.Tables[6].Rows.Count > 0)
                        {
                            var items = GetViewSupplierDetails.Tables[6].Rows[0];
                            divendrosement.Visible = true;
                            txtCrNo.Text = items["E_CrNo"].ToString();
                            txtCrNo.Enabled = false;
                            txtPremises.Text = items["E_premises"].ToString();
                            txtPremises.Enabled = false;
                            txtNorth.Text = items["E_North"].ToString();
                            txtNorth.Enabled = false;
                            txtSouth.Text = items["E_South"].ToString();
                            txtSouth.Enabled = false;
                            txteast.Text = items["E_East"].ToString();
                            txteast.Enabled = false;
                            txtwest.Text = items["E_West"].ToString();
                            txtwest.Enabled = false;
                            txtfromYear.Text = items["E_Fromyear"].ToString();
                            txtfromYear.Enabled = false;
                            txttoYear.Text = items["E_Toyear"].ToString();
                            txttoYear.Enabled = false;
                            txtremitted.Text = items["E_remitted"].ToString();
                            txtremitted.Enabled = false;
                        }
                    }
                }
                if (GetViewSupplierDetails.Tables[4].Rows.Count > 0)
                {
                    DataTable TempTable = null;
                    TempTable = GetViewSupplierDetails.Tables[4];
                    foreach (DataRow row in TempTable.Rows)
                    {
                        FileUpload.Rows.Add(new Object[]
                        { row["Type_Man_Cd"],
                        row["TypeofUser"],
                        row["Application_SL_No"],
                            Convert.ToInt32(row["DocumentTypeID"]),
                          row["DocumentTypeName"].ToString(),
                          (byte[])row["DocumentFile"] });
                    }
                    gvDocumentDetails.DataSource = GetViewSupplierDetails.Tables[4];
                    gvDocumentDetails.DataBind();

                }
                if (GetViewSupplierDetails.Tables[5].Rows.Count > 0)
                { 
                    string ISBG_CD_Value = GetViewSupplierDetails.Tables[5].Rows[0]["IsBG_CD"].ToString();
                    IsBG_CD.SelectedValue = GetViewSupplierDetails.Tables[5].Rows[0]["IsBG_CD"].ToString();
                    if(IsBG_CD.SelectedValue == "1")
                    {
                        divFDR.Visible = true;
                        txtbgFdrNo.Text = GetViewSupplierDetails.Tables[5].Rows[0]["Sd_Bg_FdrNo"].ToString();
                        txtbgFdrDate.Text = GetViewSupplierDetails.Tables[5].Rows[0]["Sd_Bg_FdrDate"].ToString();
                    }
                    else
                    {
                        divCD.Visible = true;
                        txtCdChallanno.Text = GetViewSupplierDetails.Tables[5].Rows[0]["Sd_CD_Challan_No"].ToString();
                        txtcdChallndate.Text = GetViewSupplierDetails.Tables[5].Rows[0]["Sd_CD_challan_date"].ToString();
                    }
                    txtsdAmount.Text = GetViewSupplierDetails.Tables[5].Rows[0]["Sd_Amount"].ToString();
                    txtBankName.Text = GetViewSupplierDetails.Tables[5].Rows[0]["Sd_Bank"].ToString();
                    txtbranchname.Text = GetViewSupplierDetails.Tables[5].Rows[0]["Sd_BranchName"].ToString();
                    txtLicenseValidityFrom.Text = GetViewSupplierDetails.Tables[5].Rows[0]["Validity_FromDate"].ToString();
                    txtLicenseValidityTo.Text = GetViewSupplierDetails.Tables[5].Rows[0]["Validity_ToDate"].ToString();
                }
                    //if (GetSupplierDetails.Tables.Count > 0 && GetSupplierDetails.Tables[2].Rows.Count == 2)
                    //{
                    //    btn_Save.Visible = true;
                    //}
                    //else
                    //{
                    //    btn_Save.Visible = false;
                    //    lblmsg.Text = "Please pay all the required payments..";
                    //    return;
                    //}
                }

        }
       
        protected void btnForward_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtRemarks.Text))
                {
                    lblmessage.Text = "Please enter remarks..";
                    return;
                }

                string ApplicationNo = Session["ApplicationNo"].ToString();
                int Type_Man_Cd = Convert.ToInt32(Session["Type_Man_Cd"].ToString());
                int Application_SL_No = Convert.ToInt32(Session["Application_SL_No"].ToString());
                string TypeofUser = "M";
                int Current_Level = Convert.ToInt32(Session["Current_Level"].ToString()); ;
                string CreatedBy = Session["RenewalID"].ToString();
                int DirectionFlag = 1;
                string Remarks = txtRemarks.Text.ToString();
                byte[] documenttype = null;
                string FileName = null;

                string CrNo = txtCrNo.Text.ToString();
                string Premises =txtPremises.Text.ToString();
                string North = txtNorth.Text.ToString();
                string South = txtSouth.Text.ToString();
                string East = txteast.Text.ToString();
                string West = txtwest.Text.ToString();
                string Fromyear = txtfromYear.Text.ToString();
                string Toyear = txttoYear.Text.ToString();
                string Remitted = txtremitted.Text.ToString();
                string UserID = Session["RenewalID"].ToString();
                if (fileuploaddoctype.HasFile)
                {
                    string mime = MimeType.GetMimeType(fileuploaddoctype.FileBytes, fileuploaddoctype.PostedFile.FileName);
                    string FileNamework = fileuploaddoctype.PostedFile.FileName;
                    string FileName1 = fileuploaddoctype.PostedFile.FileName.ToString();
                    string extension = System.IO.Path.GetExtension(fileuploaddoctype.FileName);
                    if (mime == "application/pdf")
                    {
                        int len = fileuploaddoctype.PostedFile.ContentLength;
                        if ((len / 1024) > 1024)
                        {
                            objCommon.ShowAlertMessage("File is larger than 1MB Please Upload Below 1MB");
                            fileuploaddoctype.Focus();
                            return;
                        }
                        else
                        {
                            documenttype = fileuploaddoctype.FileBytes;
                            string FileNameworkExtension = System.IO.Path.GetExtension(FileNamework);
                            FileName = FileNamework.Substring(0, (FileNamework.Length - FileNameworkExtension.Length));
                        }
                    }
                }
                
               bool result = objDL.RenewalAction_Flow
                    (ApplicationNo, Type_Man_Cd, Application_SL_No, TypeofUser, Current_Level, CreatedBy, DirectionFlag,Remarks,documenttype, ConnKey);
                bool endrosementResult = false;
                if (result)
                {
                    lblmessage.Text = "Forwarded Successfull";
                    lblmessage.Font.Size = 16;
                    lblmessage.ForeColor = System.Drawing.Color.Green;

                    int SLNO = GetViewSupplierDetails.Tables[3].Rows.Count - 1;
                    var item = GetViewSupplierDetails.Tables[3].Rows[SLNO];
                    if (item["Next_Level1"].ToString() == "5")
                    {
                     endrosementResult = objDL.MBEndrosement_Insert
                         (CrNo, Premises, North, South, East, West, Fromyear, Toyear, Remitted, UserID, ApplicationNo, Type_Man_Cd,
                         TypeofUser, CreatedBy, ConnKey);
                    }

                    //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Message", "confirmAction();", true);
                    Response.Redirect("~/Renewals/FWDRenewalApplications.aspx", false);
                    return;
                }
                else
                {
                    lblmessage.Text = "Please check the values.";
                    return;
                }
            }
            catch (Exception ex)
            {
            }

        }
        private DataTable FinalInsertDocumentDetails()
        {
            DataTable dtCreatedetails = new DataTable();
            dtCreatedetails.Columns.Add("Type_Man_Cd", typeof(int));
            dtCreatedetails.Columns.Add("TypeofUser", typeof(string));
            dtCreatedetails.Columns.Add("Application_SL_No", typeof(int));
            dtCreatedetails.Columns.Add("DocumentTypeID", typeof(int));
            dtCreatedetails.Columns.Add("DocumentTypeName", typeof(string));
            dtCreatedetails.Columns.Add("DocumentFile", typeof(byte[]));
            return dtCreatedetails;
        }
        private DataTable FileUpload
        {
            get
            {
                if (ViewState["FileUpload"] == null)

                {
                    DataTable dt = FinalInsertDocumentDetails();
                    ViewState["FileUpload"] = dt;
                }
                return ViewState["FileUpload"] as DataTable;
            }
            set
            {
                ViewState["FileUpload"] = value;
            }
        }
        protected void gvDocumentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkbtn_Documents")
            {
                string DocumentID = e.CommandArgument.ToString();

                if (FileUpload.Rows.Count > 0)
                {
                    DataView dvSelectedApplication = new DataView(FileUpload);
                    //RowID=DocumentTypeID
                    dvSelectedApplication.RowFilter = "DocumentTypeID =" +Convert.ToInt32(DocumentID);
                    DataRow drow = dvSelectedApplication.ToTable().Rows[0];
                    string DocumentName = drow["DocumentTypeName"].ToString();
                    ShowDocument(DocumentName + ".pdf", (byte[])drow["DocumentFile"]);
                }
            }
        }
        private void ShowDocument(string fileName, byte[] fileContent)
        {
            //Split the string by character . to get file extension type  
            string[] stringParts = fileName.Split(new char[] { '.' });
            string strType = stringParts[1];
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            //Set the content type as file extension type  
            Response.ContentType = strType;
            //Write the file content  
            this.Response.BinaryWrite(fileContent);
            this.Response.End();
        }

        protected void btnRevert_Click(object sender, EventArgs e)
        {
            try
            {
               
                string ApplicationNo = Session["ApplicationNo"].ToString();
                int Type_Man_Cd = Convert.ToInt32(Session["Type_Man_Cd"].ToString());
                int Application_SL_No = Convert.ToInt32(Session["Application_SL_No"].ToString());
                string TypeofUser = "M";
                int Current_Level = Convert.ToInt32(Session["Current_Level"].ToString()); ;
                string CreatedBy = Session["RenewalID"].ToString();
                int DirectionFlag = 2;
                string Remarks = txtRemarks.Text.ToString();
                byte[] documenttype = null;
                string FileName = null;
                if (fileuploaddoctype.HasFile)
                {
                    string mime = MimeType.GetMimeType(fileuploaddoctype.FileBytes, fileuploaddoctype.PostedFile.FileName);
                    string FileNamework = fileuploaddoctype.PostedFile.FileName;
                    string FileName1 = fileuploaddoctype.PostedFile.FileName.ToString();
                    string extension = System.IO.Path.GetExtension(fileuploaddoctype.FileName);
                    if (mime == "application/pdf")
                    {
                        int len = fileuploaddoctype.PostedFile.ContentLength;
                        if ((len / 1024) > 1024)
                        {
                            objCommon.ShowAlertMessage("File is larger than 1MB Please Upload Below 1MB");
                            fileuploaddoctype.Focus();
                            return;
                        }
                        else
                        {
                            documenttype = fileuploaddoctype.FileBytes;
                            string FileNameworkExtension = System.IO.Path.GetExtension(FileNamework);
                            FileName = FileNamework.Substring(0, (FileNamework.Length - FileNameworkExtension.Length));
                        }
                    }
                }

                int NextLevel = 0;
                int SLNO = GetViewSupplierDetails.Tables[3].Rows.Count - 1;

                var item = GetViewSupplierDetails.Tables[3].Rows[SLNO];
                bool result;
                if (item["Current_Level1"].ToString() == "8" && item["Next_Level1"].ToString() == "4" && Session["Role"].ToString() == "54")
                {
                    NextLevel = Convert.ToInt16(item["Current_Level1"].ToString());

                    result = objDL.RenewalAction_Revert_Flow
                   (ApplicationNo, Type_Man_Cd, Application_SL_No, TypeofUser, Current_Level, CreatedBy, DirectionFlag, Remarks, documenttype, NextLevel, ConnKey);
                }
                else
                {
                    result = objDL.RenewalAction_Flow
                       (ApplicationNo, Type_Man_Cd, Application_SL_No, TypeofUser, Current_Level, CreatedBy, DirectionFlag, Remarks, documenttype, ConnKey);
                }

                if (result)
                {
                    lblmessage.Text = "Application reverted to applicant";
                    lblmessage.Font.Size = 16;
                    lblmessage.ForeColor = System.Drawing.Color.Green;
                    //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Message", "confirmAction();", true);
                    Response.Redirect("~/Renewals/FWDRenewalApplications.aspx", false);
                    return;
                }
                else
                {
                    lblmessage.Text = "Please check the values.";
                    return;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void gvFlowDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkbtn_Documents")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                LinkButton lb = (LinkButton)row.FindControl("lnkbtn_Documents");
                var commandArgument = e.CommandArgument.ToString();
                DataRow drDetails = GetViewSupplierDetails.Tables[3].Rows[gvFlowDetails.Rows[Convert.ToInt32(commandArgument)].RowIndex];
                string Remarks = drDetails["Remarks"].ToString();
                string Document = drDetails["DocumentFile"].ToString();
                if (string.IsNullOrEmpty(Document))
                {
                    lb.Text = "No Document available";
                }
                else
                {
                    ShowDocument(Remarks + ".pdf", (byte[])drDetails["DocumentFile"]);
                }
                //string DocumentID = e.CommandArgument.ToString();

                //if (FileUpload.Rows.Count > 0)
                //{
                //    ShowDocument(DocumentName + ".pdf", (byte[])drow["DocumentFile"]);
                //}
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                string ApplicationNo = Session["ApplicationNo"].ToString();
                int Type_Man_Cd = Convert.ToInt32(Session["Type_Man_Cd"].ToString());
                int Application_SL_No = Convert.ToInt32(Session["Application_SL_No"].ToString());
                string TypeofUser = "M";
                int Current_Level = Convert.ToInt32(Session["Current_Level"].ToString()); ;
                string CreatedBy = Session["RenewalID"].ToString();
                int DirectionFlag = 4;
                string Remarks = txtRemarks.Text.ToString();
                byte[] documenttype = null;
                string FileName = null;
                if (fileuploaddoctype.HasFile)
                {
                    string mime = MimeType.GetMimeType(fileuploaddoctype.FileBytes, fileuploaddoctype.PostedFile.FileName);
                    string FileNamework = fileuploaddoctype.PostedFile.FileName;
                    string FileName1 = fileuploaddoctype.PostedFile.FileName.ToString();
                    string extension = System.IO.Path.GetExtension(fileuploaddoctype.FileName);
                    if (mime == "application/pdf")
                    {
                        int len = fileuploaddoctype.PostedFile.ContentLength;
                        if ((len / 1024) > 1024)
                        {
                            objCommon.ShowAlertMessage("File is larger than 1MB Please Upload Below 1MB");
                            fileuploaddoctype.Focus();
                            return;
                        }
                        else
                        {
                            documenttype = fileuploaddoctype.FileBytes;
                            string FileNameworkExtension = System.IO.Path.GetExtension(FileNamework);
                            FileName = FileNamework.Substring(0, (FileNamework.Length - FileNameworkExtension.Length));
                        }
                    }
                }
                bool result = objDL.RenewalAction_Flow
                    (ApplicationNo, Type_Man_Cd, Application_SL_No, TypeofUser, Current_Level, CreatedBy, DirectionFlag, Remarks, documenttype, ConnKey);

                if (result)
                {
                    lblmessage.Text = "Application approved..";
                    lblmessage.Font.Size = 16;
                    lblmessage.ForeColor = System.Drawing.Color.Green;
                    objCommon.ShowAlertMessage("Application approved..");
                    Response.Redirect("~/Renewals/FWDRenewalApplications.aspx", false);
                    return;
                }
                else
                {
                    lblmessage.Text = "Please check the values.";
                    return;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                string ApplicationNo = Session["ApplicationNo"].ToString();
                int Type_Man_Cd = Convert.ToInt32(Session["Type_Man_Cd"].ToString());
                int Application_SL_No = Convert.ToInt32(Session["Application_SL_No"].ToString());
                string TypeofUser = "M";
                int Current_Level = Convert.ToInt32(Session["Current_Level"].ToString()); ;
                string CreatedBy = Session["RenewalID"].ToString();
                int DirectionFlag = 3;
                string Remarks = txtRemarks.Text.ToString();
                byte[] documenttype = null;
                string FileName = null;
                if (fileuploaddoctype.HasFile)
                {
                    string mime = MimeType.GetMimeType(fileuploaddoctype.FileBytes, fileuploaddoctype.PostedFile.FileName);
                    string FileNamework = fileuploaddoctype.PostedFile.FileName;
                    string FileName1 = fileuploaddoctype.PostedFile.FileName.ToString();
                    string extension = System.IO.Path.GetExtension(fileuploaddoctype.FileName);
                    if (mime == "application/pdf")
                    {
                        int len = fileuploaddoctype.PostedFile.ContentLength;
                        if ((len / 1024) > 1024)
                        {
                            objCommon.ShowAlertMessage("File is larger than 1MB Please Upload Below 1MB");
                            fileuploaddoctype.Focus();
                            return;
                        }
                        else
                        {
                            documenttype = fileuploaddoctype.FileBytes;
                            string FileNameworkExtension = System.IO.Path.GetExtension(FileNamework);
                            FileName = FileNamework.Substring(0, (FileNamework.Length - FileNameworkExtension.Length));
                        }
                    }
                }
                bool result = objDL.RenewalAction_Flow
                    (ApplicationNo, Type_Man_Cd, Application_SL_No, TypeofUser, Current_Level, CreatedBy, DirectionFlag, Remarks, documenttype, ConnKey);

                if (result)
                {
                    lblmessage.Text = "Application rejected..";
                    lblmessage.Font.Size = 16;
                    lblmessage.ForeColor = System.Drawing.Color.Green;
                  
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Message", "confirmAction();", true);
                    //Response.Redirect("~/Renewals/FWDRenewalApplications.aspx", false);
                    return;
                }
                else
                {
                    lblmessage.Text = "Please check the values.";
                    return;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void gvDocumentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //int temp;
                //int Document = int.TryParse(GetViewRetailerDetails.Tables[3].Rows[e.Row.RowIndex]["DocumentFile"].ToString(), out temp) ? temp : 0;
                string Document = GetViewSupplierDetails.Tables[4].Rows[e.Row.RowIndex]["DocumentFile"].ToString();
                LinkButton lnkbtn_Documents = e.Row.FindControl("lnkbtn_Documents") as LinkButton;


                if (!string.IsNullOrEmpty(Document))
                {
                    lnkbtn_Documents.Enabled = true;
                    lnkbtn_Documents.ToolTip = "Click here for Document";
                    lnkbtn_Documents.Text = "Click..!";

                }
                else
                {
                    lnkbtn_Documents.Enabled = false;
                    lnkbtn_Documents.Text = "";
                    lnkbtn_Documents.ToolTip = "";
                }
            }

        }
        protected void gvFlowDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //int temp;
                //int Document = int.TryParse(GetViewRetailerDetails.Tables[3].Rows[e.Row.RowIndex]["DocumentFile"].ToString(), out temp) ? temp : 0;
                string Document = GetViewSupplierDetails.Tables[3].Rows[e.Row.RowIndex]["DocumentFile"].ToString();
                LinkButton lnkbtn_Documents = e.Row.FindControl("lnkbtn_Documents") as LinkButton;


                if (!string.IsNullOrEmpty(Document))
                {
                    lnkbtn_Documents.Enabled = true;
                    lnkbtn_Documents.ToolTip = "Click here for Document";
                    lnkbtn_Documents.Text = "Click..!";

                }
                else
                {
                    lnkbtn_Documents.Enabled = false;
                    lnkbtn_Documents.Text = "";
                    lnkbtn_Documents.ToolTip = "";
                }
            }
        }

        protected void button_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Renewals/FWDRenewalApplications.aspx", false);
        }

        [System.Web.Services.WebMethod]
        public  void ProcessAction()
        {
            objCommon.ShowAlertMessage("Application rejected..");
        }

        
    }
}