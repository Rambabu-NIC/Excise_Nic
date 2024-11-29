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
    public partial class BARRenewal : System.Web.UI.Page
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
            if (Session["Role"] != null && Session["Role"].ToString() == "12" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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

               
                string TypeofUser = "R";
                int Type_Man_Cd = 2;
                int Application_SL_No = 1;

                GetDTDocumentDetails = objDL.GetDocumentDetails(TypeofUser,Type_Man_Cd, Application_SL_No, ConnKey);
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
            string Retailer_Code = Session["User"].ToString();

            GetSupplierDetails = objDL.GetRetailerDetails(Retailer_Code, ConnKey);
            if (GetSupplierDetails.Tables.Count > 0)
            {
                if (GetSupplierDetails.Tables[3].Rows.Count > 0)
                {
                    Session["RenewalID"] = GetSupplierDetails.Tables[3].Rows[0]["Retailer_Code"].ToString();
                    Session["ApplicationNo"] = GetSupplierDetails.Tables[3].Rows[0]["ApplicationNo"].ToString();
                    Session["Type_Man_Cd"] = 2;
                    Response.Redirect("~/Renewals/ViewRenewalApplications.aspx", false);
                }

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
                btn_Save.Visible = false;
                btnNext.Visible = false;
                divbgDetails.Visible = true;
                if (GetSupplierDetails.Tables.Count > 0 && 
                    GetSupplierDetails.Tables[2].Rows.Count>0 && GetSupplierDetails.Tables[4].Rows.Count > 0)
                {
                    if(GetSupplierDetails.Tables[2].Rows[0]["Installmet"].ToString() == "5")
                    {
                        divbgDetails.Visible = false;
                    }
                    //btn_Save.Visible = true;
                    btnNext.Visible = true;
                }
                else
                {
                    btn_Save.Visible = false;
                    btnNext.Visible = false;
                    lblNextError.Text = "Please pay all the required payments..";
                    return;
                }
            }

        }

        protected void rbBGFDR_CheckedChanged(object sender, EventArgs e)
        {
            //divFDR.Visible = false;
            //divCD.Visible = false;
            //if (rbBGFDR.Checked == true)
            //{
            //    divFDR.Visible = true;
            //}
        }

        protected void rbCD_CheckedChanged(object sender, EventArgs e)
        {
            //divFDR.Visible = false;
            //divCD.Visible = false;
            //if (rbCD.Checked == true)
            //{
            //    divCD.Visible = true;
            //}
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload.Rows.Count > 0)
                {
                    if (GetSupplierDetails.Tables.Count > 0 && GetSupplierDetails.Tables[2].Rows.Count > 0 && GetSupplierDetails.Tables[4].Rows.Count > 0)
                    {
                        string Retailer_Code = Session["User"].ToString();
                        string Sd_Bg_FdrNo = "0";
                        string Sd_Bg_FdrDate = DateTime.Now.ToString("yyyy-MM-dd");
                        string Sd_CD_Challan_No = "0";
                        string Sd_CD_challan_date = DateTime.Now.ToString("yyyy-MM-dd");
                        decimal Sd_Amount = 0;
                        string Sd_Bank = "0";
                        int IsBG_CD1 = 0;

                        if (GetSupplierDetails.Tables[2].Rows[0]["Installmet"].ToString() != "5")
                        {
                            Sd_Bg_FdrNo = txtbgFdrNo.Text.ToString();
                            Sd_Bg_FdrDate = txtbgFdrDate.Text.ToString();
                            Sd_CD_Challan_No = txtCdChallanno.Text.ToString();
                            Sd_CD_challan_date = txtcdChallndate.Text.ToString();
                            Sd_Amount = Convert.ToDecimal(txtsdAmount.Text.ToString());
                            Sd_Bank = txtBankName.Text.ToString();
                            IsBG_CD1 = Convert.ToInt32(IsBG_CD.SelectedValue);
                        }

                        string Validity_FromDate = txtLicenseValidityFrom.Text.ToString();
                        string Validity_ToDate = txtLicenseValidityTo.Text.ToString();
                        int Status_ID = 1;
                        string SystemIP = "";
                        string CreatedBy = Session["User"].ToString();
                        string Sd_BranchName = txtbranchname.Text.ToString();
                        int Type_Man_Cd = 2;
                        int Application_No = 1;
                        string Ex_Dist = GetSupplierDetails.Tables[0].Rows[0]["ExDist"].ToString();
                        
                        string SHOUsername = GetSupplierDetails.Tables[0].Rows[0]["SHOUsername"].ToString();





                        DataTable result = objDL.BARRenewalApplications_Insert(Retailer_Code, Sd_Bg_FdrNo, Sd_Bg_FdrDate, Sd_CD_Challan_No, Sd_CD_challan_date, Sd_Amount, Sd_Bank, Validity_FromDate
                        , Validity_ToDate, Status_ID, SystemIP, CreatedBy, Sd_BranchName, Type_Man_Cd, Application_No, Ex_Dist, SHOUsername, IsBG_CD1, FileUpload, ConnKey);
                        if (result.Rows.Count > 0)
                        {
                            lblmsg.Text = "Renewal Application Submitted";
                            lblmsg.ForeColor = System.Drawing.Color.Green;
                            lblmsg.Font.Size = 16;
                            Session["RenewalID"] = Retailer_Code.ToString();
                            Session["ApplicationNo"] = result.Rows[0]["ApplicationNo"].ToString();
                            Session["Type_Man_Cd"] = Type_Man_Cd;
                            objCommon.ShowAlertMessage("Renewal Application Submitted");
                            Response.Redirect("~/Renewals/ViewBARRenewal.aspx", false);
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
                string extension = System.IO.Path.GetExtension(fileuploaddoctype.FileName);
                if (extension.ToUpper() == ".PDF")
                {
                    documenttype = fileuploaddoctype.FileBytes;
                    string FileNamework = fileuploaddoctype.PostedFile.FileName;
                    string FileNameworkExtension = System.IO.Path.GetExtension(FileNamework);
                    FileName = FileNamework.Substring(0, (FileNamework.Length - FileNameworkExtension.Length));
                    drDetail["Type_Man_Cd"] = 2;
                    drDetail["TypeofUser"] = 'R';
                    drDetail["Application_SL_No"] = 1;
                    drDetail["DocumentTypeID"] = ddldocumenttype.SelectedItem.Value;
                    drDetail["DocumentTypeName"] = ddldocumenttype.SelectedItem.Text;
                    drDetail["DocumentFile"] = documenttype;

                    dtUploadDetails.Rows.Add(drDetail);
                    
                }
            }
            FileUpload = dtUploadDetails;
            gvaddrecords.DataSource = FileUpload;
            gvaddrecords.DataBind();
            ddldocumenttype.SelectedIndex = 0;
            fileuploaddoctype.Dispose();

            btn_Save.Visible = false;
            if(GetDTDocumentDetails.Rows.Count == dtUploadDetails.Rows.Count)
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
                    dvSelectedApplication.RowFilter = "DocumentTypeID =" +Convert.ToInt32(DocumentID);
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

            if (IsBG_CD.SelectedValue == "1") {
                divFDR.Visible = true;

            }
            else
            {
                divCD.Visible = true;

            }

        }
    }
}