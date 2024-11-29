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
    public partial class MBRenewal : System.Web.UI.Page
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
            if (Session["Role"] != null && Session["Role"].ToString() == "3" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                BindDetails();
                BindDocumentDetails();
            }
        }
        public DataTable GetDTDocumentDetails
        {
            get
            {
                return ViewState["GetDTDocumentDetails"] as DataTable;
            }
            set
            {
                ViewState["GetDTDocumentDetails"] = value;
            }
        }
        public void BindDocumentDetails()
        {
            try
            {


                string TypeofUser = "M";
                int Type_Man_Cd = 5;
                int Application_SL_No = 1;

                GetDTDocumentDetails = objDL.GetDocumentDetails(TypeofUser, Type_Man_Cd, Application_SL_No, ConnKey);
                objCommon.BindDropDownLists(ddldocumenttype, GetDTDocumentDetails, "DocumentTypeName", "DocumentTypeID", "0");
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public DataSet GetSupplierDetails
        {
            get
            {
                return ViewState["GetSupplierDetails"] as DataSet;
            }
            set
            {
                ViewState["GetSupplierDetails"] = value;
            }
        }
        public void BindDetails()
        {
            string Supplier_Code = Session["User"].ToString();

            GetSupplierDetails = objDL.GetSupplierDetails(Supplier_Code, ConnKey);
            if (GetSupplierDetails.Tables.Count > 0)
            {
                if (GetSupplierDetails.Tables[0].Rows.Count > 0)
                {
                    gvdetails.DataSource = GetSupplierDetails.Tables[0];
                    gvdetails.DataBind();
                }
                if (GetSupplierDetails.Tables[1].Rows.Count > 0)
                {
                    gvPaymentDetails.DataSource = GetSupplierDetails.Tables[1];
                    gvPaymentDetails.DataBind();
                }
                btnNext.Visible = false;
                if (GetSupplierDetails.Tables.Count > 0 && GetSupplierDetails.Tables[2].Rows.Count == 4)
                {
                    btnNext.Visible = true;
                }
                else
                {
                    btnNext.Visible = false;
                    lblmsg.Text = "Please pay all the required payments..";
                    return;
                }
            }
               
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload.Rows.Count > 0)
                {
                    string Supplier_Code = Session["User"].ToString();
                    string Sd_Bg_FdrNo = txtbgFdrNo.Text.ToString();
                    string Sd_Bg_FdrDate = txtbgFdrDate.Text.ToString();
                    string Sd_CD_Challan_No = txtCdChallanno.Text.ToString();
                    string Sd_CD_challan_date = txtcdChallndate.Text.ToString();
                    decimal Sd_Amount = Convert.ToDecimal(txtsdAmount.Text.ToString());
                    string Sd_Bank = txtBankName.Text.ToString();
                    string Validity_FromDate = txtLicenseValidityFrom.Text.ToString();
                    string Validity_ToDate = txtLicenseValidityTo.Text.ToString();
                    int Status_ID = 1;
                    string SystemIP = "";
                    string CreatedBy = Session["User"].ToString();
                    string Sd_BranchName = txtbranchname.Text.ToString();
                    int Type_Man_Cd = 5;
                    int Application_No = 1;
                    string Ex_Dist = GetSupplierDetails.Tables[0].Rows[0]["ExDist"].ToString();
                    int IsBG_CD1 = Convert.ToInt32(IsBG_CD.SelectedValue);
                    string SHOUsername = GetSupplierDetails.Tables[0].Rows[0]["SHOUsername"].ToString();



                    if (GetSupplierDetails.Tables.Count > 0 && GetSupplierDetails.Tables[2].Rows.Count == 4)
                    {

                        DataTable result = objDL.MBRenewalApplications_Insert(Supplier_Code, Sd_Bg_FdrNo, Sd_Bg_FdrDate, Sd_CD_Challan_No, Sd_CD_challan_date, Sd_Amount, Sd_Bank, Validity_FromDate
                        , Validity_ToDate, Status_ID, SystemIP, CreatedBy, Sd_BranchName, Type_Man_Cd, Application_No, Ex_Dist, SHOUsername, IsBG_CD1, FileUpload, ConnKey);
                        if (result.Rows.Count > 0)
                        {
                            lblmsg.Text = "Renewal Application Submitted";
                            lblmsg.ForeColor = System.Drawing.Color.Green;
                            lblmsg.Font.Size = 16;
                            Session["RenewalID"] = Supplier_Code.ToString();
                            Session["ApplicationNo"] = result.Rows[0]["ApplicationNo"].ToString();
                            Session["Type_Man_Cd"] = Type_Man_Cd;
                            objCommon.ShowAlertMessage("Renewal Application Submitted");
                            Response.Redirect("~/Renewals/ViewMBRenewalApplications.aspx", false);
                            return;
                        }
                        else
                        {
                            lblmsg.Text = "Please check the details ";
                            return;
                        }
                    }
                    else
                    {
                        lblmsg.Text = "Please pay all the required payments..";
                        return;
                    }
                }
                else
                {
                    lblmsg.Text = "Please upload required documents..";
                    return;
                }
            }
            catch (Exception Ex)
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
        protected void btnAddUpload_Click(object sender, EventArgs e)
        {
            divuploaddocumentsdetails.Visible = true;
            DataTable dtUploadDetails = FileUpload;
            DataRow drDetail = dtUploadDetails.NewRow();
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
                        if (mime == "application/pdf")
                        {
                            documenttype = fileuploaddoctype.FileBytes;

                            string FileNameworkExtension = System.IO.Path.GetExtension(FileNamework);
                            FileName = FileNamework.Substring(0, (FileNamework.Length - FileNameworkExtension.Length));
                            drDetail["Type_Man_Cd"] = 5;
                            drDetail["TypeofUser"] = 'M';
                            drDetail["Application_SL_No"] = 1;
                            drDetail["DocumentTypeID"] = ddldocumenttype.SelectedItem.Value;
                            drDetail["DocumentTypeName"] = ddldocumenttype.SelectedItem.Text;
                            drDetail["DocumentFile"] = documenttype;

                            dtUploadDetails.Rows.Add(drDetail);
                        }
                    }
                }
                else
                {
                    lblmsg.Text = "Please Upload Valid Document";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
               
            }
            FileUpload = dtUploadDetails;
            gvaddrecords.DataSource = FileUpload;
            gvaddrecords.DataBind();
            ddldocumenttype.SelectedIndex = 0;
            fileuploaddoctype.Dispose();

            btn_Save.Visible = false;
            if (GetDTDocumentDetails.Rows.Count == dtUploadDetails.Rows.Count)
            {
                btn_Save.Visible = true;
            }
        }

        protected void gvaddrecords_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkbtn_Documents")
            {
                string DocumentID = e.CommandArgument.ToString();

                if (FileUpload.Rows.Count > 0)
                {
                    DataView dvSelectedApplication = new DataView(FileUpload);
                    //RowID=DocumentTypeID
                    dvSelectedApplication.RowFilter = "DocumentTypeID =" + Convert.ToInt32(DocumentID);
                    DataRow drow = dvSelectedApplication.ToTable().Rows[0];
                    string DocumentName = drow["DocumentTypeName"].ToString();
                    ShowDocument(DocumentName + ".pdf", (byte[])drow["DocumentFile"]);
                }
            }
        }
        protected void lknbtndocDelete_Click(object sender, EventArgs e)
        {
            LinkButton lbndocdelete = (sender) as LinkButton;
            GridViewRow gvrow = lbndocdelete.NamingContainer as GridViewRow;
            if (gvaddrecords != null)
            {

                int rowindex = gvrow.RowIndex;

                if (FileUpload.Rows.Count > 0)
                {
                    divuploaddocumentsdetails.Visible = true;
                    FileUpload.Rows.Remove(FileUpload.Rows[rowindex]);

                    gvaddrecords.DataSource = FileUpload;
                    gvaddrecords.DataBind();

                    if (FileUpload.Rows.Count == 0)
                    {
                        divuploaddocumentsdetails.Visible = false;
                    }
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            divfirstpanel.Visible = false;
            divsecondBlock.Visible = true;
        }

        protected void IsBG_CD_SelectedIndexChanged(object sender, EventArgs e)
        {
            divFDR.Visible = false;
            divCD.Visible = false;

            if (IsBG_CD.SelectedValue == "1")
            {
                divFDR.Visible = true;

            }
            else
            {
                divCD.Visible = true;

            }

        }
    }
}