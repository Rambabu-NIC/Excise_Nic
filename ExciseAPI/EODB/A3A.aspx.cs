using ExciseAPI.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.EODB
{
    public partial class A3A : System.Web.UI.Page
    {
        SqlHelper sql = new SqlHelper();
        private int CurrentTab
        {
            get
            {
                if (ViewState["CurrentTab"] == null)
                    ViewState["CurrentTab"] = 1;
                return (int)ViewState["CurrentTab"];
            }
            set
            {
                ViewState["CurrentTab"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPersonalDetails();
                BindDocuments();
                BinExDistrictDetails();
                ShowCurrentTab();
            }
        }
        public void BinExDistrictDetails()
        {
            DataSet dsEdistrict = sql.BindExciseDistrictDetails();
            if (dsEdistrict != null && dsEdistrict.Tables.Count > 0)
            {
                //ddlDistrict
                ddlExciseDistrict.Items.Clear();

                if (dsEdistrict.Tables.Count > 0 && dsEdistrict.Tables[0].Rows.Count > 0)
                {
                    ddlExciseDistrict.DataSource = dsEdistrict.Tables[0];
                    ddlExciseDistrict.DataTextField = "ExDist";
                    ddlExciseDistrict.DataValueField = "ExDist_Cd";
                    ddlExciseDistrict.DataBind();


                }
                ddlExciseDistrict.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

            }
        }
        public void BindPersonalDetails()
        {
            DataTable dt = Session["ApplicantPersonalDetails"] as DataTable;
            if (dt != null)
            {
                divgridDetails.Visible = true;
                gvpersonaldetails.DataSource = dt;
                gvpersonaldetails.DataBind();
            }

        }

        protected void btnA4_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }
            try
            {
                string ParameterTypeName = "@TablePersonalDetails";
                string TypeName = "TablePersonalDetails";
                DataTable dtPartenerDetails = Session["ApplicantPersonalDetails"] as DataTable;
                string ApplicationNo = Session["ApplicationNo"].ToString();
                SqlParameter[] Params =
                 {
                    new SqlParameter("@P_UserName", Session["UserName"].ToString()),
                    new SqlParameter("@P_ApplicationNo", ApplicationNo.ToString()),
                };
                DataSet data = sql.GetDataInsert(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "PersonalDetails_Insert", Params, dtPartenerDetails, ParameterTypeName, TypeName);
                if (data != null && data.Tables.Count > 0)
                {
                    var item = data.Tables[0].Rows[0];
                    if (item["Status"].ToString() == "SUCCESS")
                    {
                        A3AInsert();
                    }
                    else
                    {
                        lblActionerror.Text = item["Message"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void A3AInsert()
        {
            if (A3AFileUpload.Rows.Count != ddlFileUpload.Items.Count)
            {
                lblFileUploaderror.Text = "Please Upload All Documents";
                return;
            }
            SqlParameter[] Params =
               {
                  new SqlParameter("@ApplicationNo",Session["ApplicationNo"].ToString()),
                   new SqlParameter("@SerialNo",txtSerialNo.Text.ToString()),
                   new SqlParameter("@GazetteNo",txtGazetteNo.Text.ToString()),
                   new SqlParameter("@Shopallotted",rblshopallotted.SelectedValue),
                   new SqlParameter("@Location",txtLocation.Text.ToString()),
                   new SqlParameter("@ExciseDistrict",ddlExciseDistrict.SelectedValue),
                   new SqlParameter("@ExciseStation",ddlExciseStation.SelectedValue),
                   new SqlParameter("@RetailExciseTax",txtRetailExTax.Text.ToString()),
                   new SqlParameter("@Name",txtName.Text.ToString()),
                   new SqlParameter("@F_H_Name",txtFName.Text.ToString()),
                   new SqlParameter("@DateofBirth",txtdateofbirth.Text.ToString()),
                   new SqlParameter("@Age",txtAge.Text.ToString()),
                   new SqlParameter("@Caste",txtCaste.Text.ToString()),
                   new SqlParameter("@PanNumber",txtPan.Text.ToString()),
                   new SqlParameter("@IdentityProof",ddlIdentity.SelectedValue),
                   new SqlParameter("@IdentityProofNo",txtIdentityprrofNo.Text.ToString()),
                   new SqlParameter("@FirmName",txtFirm.Text.ToString()),
                   new SqlParameter("@RegistrationNo",txtRegNo.Text.ToString()),
                   new SqlParameter("@RegistrationDate",txtRegDate.Text.ToString()),
                   new SqlParameter("@GstNo",txtGstIn.Text.ToString()),
                   new SqlParameter("@FirmPan",txtFirmPan.Text.ToString()),
                   new SqlParameter("@Is_Drawl",rblDrawl.SelectedValue),
                   new SqlParameter("@RepresentativeName",txtRepresentativeName.Text.ToString()),
                   new SqlParameter("@RF_H_Name",txtRFName.Text.ToString()),
                   new SqlParameter("@RDOB",txtRDOB.Text.ToString()),
                   new SqlParameter("@RMobile",txtRMobile.Text.ToString()),
                   new SqlParameter("@CreatedBy",Session["UserName"].ToString())
            };

            string ParameterTypeName = "@DocumentDetails_N";
            string TypeName = "DocumentDetails_E";

            DataTable dtdocument = A3AFileUpload;
            try
            {

                DataSet data = sql.GetDataInsert(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "A3A_Insert", Params, dtdocument, ParameterTypeName, TypeName);
                if (data != null && data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
                {


                    lblActionerror.Text = "Submitted Successfully..";
                    lblActionerror.ForeColor = System.Drawing.Color.Green;

                    return;
                }

                else
                {
                    lblActionerror.Text = "Please check the values..";
                    return;
                }

            }
            catch (Exception ex)
            {
                lblActionerror.Text = "Please check the values..";
                return;
            }
        }
      
        protected void ddlExciseDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlExciseDistrict.SelectedValue);
            if (DistID > 0)
            {
                BindExciseStation(DistID, ddlExciseStation);
            }
            else
            {
                lblActionerror.Text = "Please select District";
                return;
            }
        }

        public void BindExciseStation(int DistrictID, DropDownList dropdown)
        {
            DataSet dsMandals = sql.BindExciseStations(DistrictID);
            if (dsMandals != null && dsMandals.Tables.Count > 0)
            {
                dropdown.Items.Clear();
                if (dsMandals.Tables.Count > 0 && dsMandals.Tables[0].Rows.Count > 0)
                {
                    dropdown.DataSource = dsMandals.Tables[0];
                    dropdown.DataTextField = "ExStation";
                    dropdown.DataValueField = "ExStationCode";
                    dropdown.DataBind();
                }
                dropdown.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
        }

        public void BindDocuments()
        {
            int ApplicantType = 2; int SubApplicantType = 2; int FormType = 1;

            DataSet Docs = sql.BindDocumentDetails(ApplicantType, SubApplicantType, FormType);
            if (Docs != null && Docs.Tables.Count > 0)
            {
                ddlFileUpload.Items.Clear();
                if (Docs.Tables.Count > 0 && Docs.Tables[0].Rows.Count > 0)
                {
                    ddlFileUpload.DataSource = Docs.Tables[0];
                    ddlFileUpload.DataTextField = "DocumentName";
                    ddlFileUpload.DataValueField = "DocumentserialNo";
                    ddlFileUpload.DataBind();
                }
                //ddlFileUpload.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
        }
        private DataTable FinalInsertDocumentDetails()
        {
            DataTable dtD1Pdetails = new DataTable();
            dtD1Pdetails.Columns.Add("ApplicationNo", typeof(string));
            dtD1Pdetails.Columns.Add("DocumentSerialNumber", typeof(int));
            dtD1Pdetails.Columns.Add("DocumentName", typeof(string));
            dtD1Pdetails.Columns.Add("DocumentCopy", typeof(byte[]));
            return dtD1Pdetails;
        }
        private DataTable A3AFileUpload
        {
            get
            {
                if (ViewState["A3AFileUpload"] == null)

                {
                    DataTable dt = FinalInsertDocumentDetails();
                    ViewState["A3AFileUpload"] = dt;
                }
                return ViewState["A3AFileUpload"] as DataTable;
            }
            set
            {
                ViewState["A3AFileUpload"] = value;
            }
        }


        protected void btnfileAdd_Click(object sender, EventArgs e)
        {
            DataTable dtD1PUploadDetails = A3AFileUpload;
            divuploadedDocuments.Visible = true;
            lblFileUploaderror.Text = string.Empty;
            bool IsDocumentExists = false;
            string DocumentType = ddlFileUpload.SelectedItem.Text;
            if (dtD1PUploadDetails.Rows.Count > 0)
            {
                foreach (DataRow row in dtD1PUploadDetails.Rows)
                {
                    string DocumentTypeName = row["DocumentName"].ToString();
                    if (DocumentType == DocumentTypeName)
                    {
                        IsDocumentExists = true;
                    }
                }
            }
            else
            {
                IsDocumentExists = false;
            }
            if (IsDocumentExists == false)
            {


                DataRow drD1PDetail = dtD1PUploadDetails.NewRow();
                byte[] documenttype = null;
                string FileName = null;
                if (fileloiuploaddoctype.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(fileloiuploaddoctype.FileName);
                    if (extension.ToUpper() == ".PDF")
                    {
                        documenttype = fileloiuploaddoctype.FileBytes;
                        string FileNamework = fileloiuploaddoctype.PostedFile.FileName;
                        string FileNameworkExtension = System.IO.Path.GetExtension(FileNamework);
                        FileName = FileNamework.Substring(0, (FileNamework.Length - FileNameworkExtension.Length));

                        drD1PDetail["ApplicationNo"] = Session["ApplicationNo"].ToString();
                        drD1PDetail["DocumentSerialNumber"] = ddlFileUpload.SelectedItem.Value;
                        drD1PDetail["DocumentName"] = ddlFileUpload.SelectedItem.Text;
                        drD1PDetail["DocumentCopy"] = documenttype;

                        dtD1PUploadDetails.Rows.Add(drD1PDetail);
                    }
                    else

                    {
                        lblFileUploaderror.Text = "Upload only PDF files";
                    }
                }
                A3AFileUpload = dtD1PUploadDetails;
                gvaddrecordsofLOI.DataSource = A3AFileUpload;
                gvaddrecordsofLOI.DataBind();
                ddlFileUpload.SelectedIndex = 0;
                fileloiuploaddoctype.Dispose();
            }
            else
            {
                lblFileUploaderror.Text = "Selected Document is Already Added";
            }
        }

        protected void gvaddrecordsofLOI_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkbtn_Documents")
            {
                string DocumentID = e.CommandArgument.ToString();

                if (A3AFileUpload.Rows.Count > 0)
                {
                    DataView dvSelectedApplication = new DataView(A3AFileUpload);
                    //RowID=DocumentTypeID
                    dvSelectedApplication.RowFilter = "DocumentSerialNumber =" + DocumentID;
                    DataRow drow = dvSelectedApplication.ToTable().Rows[0];
                    string DocumentName = drow["DocumentName"].ToString();
                    ShowDocument(DocumentName + ".pdf", (byte[])drow["DocumentCopy"]);
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
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "LOIDOC();", true);
        }

        protected void lknbtndocDelete_Click(object sender, EventArgs e)
        {
            LinkButton lbndocdelete = (sender) as LinkButton;
            GridViewRow gvrow = lbndocdelete.NamingContainer as GridViewRow;
            if (gvaddrecordsofLOI != null)
            {

                int rowindex = gvrow.RowIndex;

                if (A3AFileUpload.Rows.Count > 0)
                {
                    divuploadedDocuments.Visible = true;
                    //  divRenewalAmounts.Visible = true;
                    A3AFileUpload.Rows.Remove(A3AFileUpload.Rows[rowindex]);

                    gvaddrecordsofLOI.DataSource = A3AFileUpload;
                    gvaddrecordsofLOI.DataBind();

                    if (A3AFileUpload.Rows.Count == 0)
                    {
                        divuploadedDocuments.Visible = false;
                        //   divRenewalAmounts.Visible = false;
                    }
                }
            }
        }

        protected void btnA4tab2_Click(object sender, EventArgs e)
        {
            CurrentTab = 2;
            if (CurrentTab < 3)
            {

                ShowCurrentTab();
            }
            btnA4tab2.Enabled = false;
            
        }

        protected void btnA4tab1_Click(object sender, EventArgs e)
        {
            CurrentTab = 1;
            if (CurrentTab == 1)
            {

                ShowCurrentTab();
            }
            btnA4tab1.Enabled = false;
        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }
            if (CurrentTab > 1)
            {
                CurrentTab--;
                ShowCurrentTab();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }
            if (CurrentTab < 2)
            {
                CurrentTab++;
                ShowCurrentTab();
            }
        }

        private void ShowCurrentTab()
        {
            A4tab1.Visible = CurrentTab == 1;
            A4tab2.Visible = CurrentTab == 2;

            btnA4tab1.Enabled = true;
            btnA4tab2.Enabled = true;

            if (CurrentTab == 1)
            {
                btnA4tab1.Enabled = false;
            }
            if (CurrentTab == 2)
            {
                btnA4tab2.Enabled = false;
            }

            btnPrevious.Enabled = CurrentTab > 1;
            btnNext.Enabled = CurrentTab < 2;
        }
    }
}