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
    public partial class IHA1 : System.Web.UI.Page
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
                BinDistrictDetails();
                BindDocuments();
                ShowCurrentTab();
            }
        }
        public void BinDistrictDetails()
        {
            DataSet dsdistrict = sql.BindDistrictDetails();
            if (dsdistrict != null && dsdistrict.Tables.Count > 0)
            {
                //ddlDistrict
                ddlDistrict_C.Items.Clear();
                ddlHDistrict.Items.Clear();
                if (dsdistrict.Tables.Count > 0 && dsdistrict.Tables[0].Rows.Count > 0)
                {
                    ddlDistrict_C.DataSource = dsdistrict.Tables[0];
                    ddlDistrict_C.DataTextField = "DistrictName";
                    ddlDistrict_C.DataValueField = "DistrictID";
                    ddlDistrict_C.DataBind();

                    ddlHDistrict.DataSource = dsdistrict.Tables[0];
                    ddlHDistrict.DataTextField = "DistrictName";
                    ddlHDistrict.DataValueField = "DistrictID";
                    ddlHDistrict.DataBind();

                }
                ddlDistrict_C.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                ddlHDistrict.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
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

        protected void btnIha1_Click(object sender, EventArgs e)
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
                        Bar1AInsert();
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

        public void Bar1AInsert()
        {
            if (IHA1FileUpload.Rows.Count != ddlFileUpload.Items.Count)
            {
                lblFileUploaderror.Text = "Please Upload All Documents";
                return;
            }
            SqlParameter[] Params =
                {
                    new SqlParameter("@ApplicationNo",Session["ApplicationNo"].ToString()),
                    new SqlParameter("@LicenceType",ddlLicenceType.SelectedValue),
                    new SqlParameter("@CompanyName",txtcompanyname.Text.ToString()),
                    new SqlParameter("@ROCNumber",txtRocNumber.Text.ToString()),
                    new SqlParameter("@C_HouseNo",txtHouseNo_C.Text.ToString()),
                    new SqlParameter("@C_Street",txtStreet_C.Text.ToString()),
                    new SqlParameter("@C_DistrictID",ddlDistrict_C.SelectedValue),
                    new SqlParameter("@C_MandalID",ddlMandal_C.SelectedValue),
                    new SqlParameter("@C_VillageID",ddlVillage_C.SelectedValue),
                    new SqlParameter("@C_Pincode",txtPincode_C.Text.ToString()),                    
                    new SqlParameter("@Name",txtName.Text.ToString()),
                    new SqlParameter("@TradeLicence",txttradeLicence.Text.ToString()),
                    new SqlParameter("@PilinthArea",txtpilintharea.Text.ToString()),
                    new SqlParameter("@H_HouseNo",txtHHouseNo.Text.ToString()),
                    new SqlParameter("@H_Street",txtHStreet.Text.ToString()),
                    new SqlParameter("@H_DistrictID",ddlHDistrict.SelectedValue),
                    new SqlParameter("@H_MandalID",ddlHMandal.SelectedValue),
                    new SqlParameter("@H_VillageID",ddlHVillage.SelectedValue),
                    new SqlParameter("@H_Pincode",txtHPincode.Text.ToString()),
                    new SqlParameter("@LicenceHeldBy",txtlicenceheld.Text.ToString()),
                    new SqlParameter("@BussinessDate",txtDatebussiness.Text.ToString()),
                    new SqlParameter("@IncaseofEventEP1",txtIncaseofEvent.Text.ToString()),
                    new SqlParameter("@EventRegistrationNo",txtEventRegNo.Text.ToString()),
                    new SqlParameter("@EventDate",txtEventDate.Text.ToString()),
                    new SqlParameter("@CreatedBy",Session["UserName"].ToString()),


            };

            string ParameterTypeName = "@DocumentDetails_N";
            string TypeName = "DocumentDetails_E";

            DataTable dtdocument = IHA1FileUpload;

            try
            {

                DataSet data = sql.GetDataInsert(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "IHA1_Insert", Params, dtdocument, ParameterTypeName, TypeName);
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
    
        protected void ddlDistrict_C_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlDistrict_C.SelectedValue);
            if (DistID > 0)
            {
                BinMandalDetails(DistID, ddlMandal_C);
            }
            else
            {
                lblActionerror.Text = "Please select District";
                return;
            }
        }

       
        protected void ddlHDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlHDistrict.SelectedValue);
            if (DistID > 0)
            {
                BinMandalDetails(DistID, ddlHMandal);
            }
            else
            {
                lblActionerror.Text = "Please select District";
                return;
            }
        }

        public void BinMandalDetails(int DistrictID, DropDownList dropdown)
        {
            DataSet dsMandals = sql.BindMandalDetails(DistrictID);
            if (dsMandals != null && dsMandals.Tables.Count > 0)
            {
                dropdown.Items.Clear();
                if (dsMandals.Tables.Count > 0 && dsMandals.Tables[0].Rows.Count > 0)
                {
                    dropdown.DataSource = dsMandals.Tables[0];
                    dropdown.DataTextField = "MandalName";
                    dropdown.DataValueField = "MandalID";
                    dropdown.DataBind();
                }
                dropdown.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
        }
        protected void ddlMandal_C_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlDistrict_C.SelectedValue);
            int MandalID = Convert.ToInt32(ddlMandal_C.SelectedValue);
            if (DistID > 0 && MandalID > 0)
            {

                BindVillageDetails(DistID, MandalID, ddlVillage_C);
            }
            else
            {
                lblActionerror.Text = "Please select District  && Mandal";
                return;
            }
        }

        protected void ddlHMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlHDistrict.SelectedValue);
            int MandalID = Convert.ToInt32(ddlHMandal.SelectedValue);
            if (DistID > 0 && MandalID > 0)
            {
                BindVillageDetails(DistID, MandalID, ddlHVillage);
            }
            else
            {
                lblActionerror.Text = "Please select District  && Mandal";
                return;
            }
        }



       
        public void BindVillageDetails(int DistrictID, int MandalID, DropDownList dropdown)
        {
            DataSet dsvillage = sql.BindVillageDetails(DistrictID, MandalID);
            if (dsvillage != null && dsvillage.Tables.Count > 0)
            {
                dropdown.Items.Clear();
                if (dsvillage.Tables.Count > 0 && dsvillage.Tables[0].Rows.Count > 0)
                {
                    dropdown.DataSource = dsvillage.Tables[0];
                    dropdown.DataTextField = "VillageName";
                    dropdown.DataValueField = "AddressID";
                    dropdown.DataBind();
                }
                dropdown.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
        }


        public void BindDocuments()
        {
            int ApplicantType = 2; int SubApplicantType = 4; int FormType = 1;

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
                ddlFileUpload.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
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
        private DataTable IHA1FileUpload
        {
            get
            {
                if (ViewState["IHA1FileUpload"] == null)

                {
                    DataTable dt = FinalInsertDocumentDetails();
                    ViewState["IHA1FileUpload"] = dt;
                }
                return ViewState["IHA1FileUpload"] as DataTable;
            }
            set
            {
                ViewState["IHA1FileUpload"] = value;
            }
        }


        protected void btnfileAdd_Click(object sender, EventArgs e)
        {
            DataTable dtD1PUploadDetails = IHA1FileUpload;
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
                IHA1FileUpload = dtD1PUploadDetails;
                gvaddrecordsofLOI.DataSource = IHA1FileUpload;
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

                if (IHA1FileUpload.Rows.Count > 0)
                {
                    DataView dvSelectedApplication = new DataView(IHA1FileUpload);
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

                if (IHA1FileUpload.Rows.Count > 0)
                {
                    divuploadedDocuments.Visible = true;
                    //  divRenewalAmounts.Visible = true;
                    IHA1FileUpload.Rows.Remove(IHA1FileUpload.Rows[rowindex]);

                    gvaddrecordsofLOI.DataSource = IHA1FileUpload;
                    gvaddrecordsofLOI.DataBind();

                    if (IHA1FileUpload.Rows.Count == 0)
                    {
                        divuploadedDocuments.Visible = false;
                        //   divRenewalAmounts.Visible = false;
                    }
                }
            }
        }

        protected void btnIHA1tab1_Click(object sender, EventArgs e)
        {
            CurrentTab = 1;
            if (CurrentTab == 1)
            {

                ShowCurrentTab();
            }
            btnIHA1tab1.Enabled = false;
        }

        protected void btnIHA1tab2_Click(object sender, EventArgs e)
        {
            CurrentTab = 2;
            if (CurrentTab < 3)
            {

                ShowCurrentTab();
            }
            btnIHA1tab2.Enabled = false;
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
            IHA1tab1.Visible = CurrentTab == 1;
            IHA1tab2.Visible = CurrentTab == 2;

            btnIHA1tab1.Enabled = true;
            btnIHA1tab2.Enabled = true;

            if (CurrentTab == 1)
            {
                btnIHA1tab1.Enabled = false;
            }
            if (CurrentTab == 2)
            {
                btnIHA1tab2.Enabled = false;
            }

            btnPrevious.Enabled = CurrentTab > 1;
            btnNext.Enabled = CurrentTab < 2;
        }
    }
}