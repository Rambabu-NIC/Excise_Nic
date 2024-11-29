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
    public partial class DSXVII : System.Web.UI.Page
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
                ddlDistrict.Items.Clear();

                if (dsdistrict.Tables.Count > 0 && dsdistrict.Tables[0].Rows.Count > 0)
                {
                    ddlDistrict.DataSource = dsdistrict.Tables[0];
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataValueField = "DistrictID";
                    ddlDistrict.DataBind();

                }
                ddlDistrict.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

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

        protected void btnM1_Click(object sender, EventArgs e)
        {
            if(!this.IsValid)
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
                        RS2Insert();
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

        public void RS2Insert()
        {
            if (DSXVIIFileUpload.Rows.Count != ddlFileUpload.Items.Count)
            {
                lblFileUploaderror.Text = "Please Upload All Documents";
                return;
            }
            SqlParameter[] Params =
               {
                    new SqlParameter("@ApplicationNo",Session["ApplicationNo"].ToString()),
                    new SqlParameter("@FirmName",txtFirmname.Text.ToString()),
                    new SqlParameter("@ROCNumber",txtRocNumber.Text.ToString()),
                    new SqlParameter("@MaxQuantity",txtMaxQty.Text.ToString()),
                    new SqlParameter("@HouseNo",txtHouseNo.Text.ToString()),
                    new SqlParameter("@Street",txtStreet.Text.ToString()),
                    new SqlParameter("@DistrictID",ddlDistrict.SelectedValue),
                    new SqlParameter("@MandalID",ddlMandal.SelectedValue),
                    new SqlParameter("@VillageID",ddlVillage.SelectedValue),
                    new SqlParameter("@SurveyNo",txtSurveyNo.Text.ToString()),
                    new SqlParameter("@Extent",txtExtent.Text.ToString()),
                    new SqlParameter("@Pincode",txtPincode.Text.ToString()),
                    new SqlParameter("@Is_Applicant",rblIsApplicant.SelectedValue),
                    new SqlParameter("@ExprienceDetails",txtexprienceDetails.Text.ToString()),
                    new SqlParameter("@OtherLicences",txtOtherLicences.Text.ToString()),
                    new SqlParameter("@CreatedBy",Session["UserName"].ToString())
            };

            string ParameterTypeName = "@DocumentDetails_N";
            string TypeName = "DocumentDetails_E";

            DataTable dtdocument = DSXVIIFileUpload;
            try
            {

                DataSet data = sql.GetDataInsert(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "DSXVII_Insert", Params, dtdocument, ParameterTypeName, TypeName);
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
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (DistID > 0)
            {
                BinMandalDetails(DistID, ddlMandal);
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
        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlDistrict.SelectedValue);
            int MandalID = Convert.ToInt32(ddlMandal.SelectedValue);
            if (DistID > 0 && MandalID > 0)
            {

                BindVillageDetails(DistID, MandalID, ddlVillage);
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
            int ApplicantType = 1; int SubApplicantType = 7; int FormType = 3;

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
        private DataTable DSXVIIFileUpload
        {
            get
            {
                if (ViewState["DSXVIIFileUpload"] == null)

                {
                    DataTable dt = FinalInsertDocumentDetails();
                    ViewState["DSXVIIFileUpload"] = dt;
                }
                return ViewState["DSXVIIFileUpload"] as DataTable;
            }
            set
            {
                ViewState["DSXVIIFileUpload"] = value;
            }
        }


        protected void btnfileAdd_Click(object sender, EventArgs e)
        {
            DataTable dtD1PUploadDetails = DSXVIIFileUpload;
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
                DSXVIIFileUpload = dtD1PUploadDetails;
                gvaddrecordsofLOI.DataSource = DSXVIIFileUpload;
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

                if (DSXVIIFileUpload.Rows.Count > 0)
                {
                    DataView dvSelectedApplication = new DataView(DSXVIIFileUpload);
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

                if (DSXVIIFileUpload.Rows.Count > 0)
                {
                    divuploadedDocuments.Visible = true;
                    //  divRenewalAmounts.Visible = true;
                    DSXVIIFileUpload.Rows.Remove(DSXVIIFileUpload.Rows[rowindex]);

                    gvaddrecordsofLOI.DataSource = DSXVIIFileUpload;
                    gvaddrecordsofLOI.DataBind();

                    if (DSXVIIFileUpload.Rows.Count == 0)
                    {
                        divuploadedDocuments.Visible = false;
                        //   divRenewalAmounts.Visible = false;
                    }
                }
            }
        }

        protected void btnDStab1_Click(object sender, EventArgs e)
        {
            CurrentTab = 1;
            if (CurrentTab == 1)
            {

                ShowCurrentTab();
            }
            btnDStab1.Enabled = false;
        }

        protected void btnDStab2_Click(object sender, EventArgs e)
        {
            CurrentTab = 2;
            if (CurrentTab < 3)
            {

                ShowCurrentTab();
            }
            btnDStab2.Enabled = false;
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
            DStab1.Visible = CurrentTab == 1;
            DStab2.Visible = CurrentTab == 2;

            btnDStab1.Enabled = true;
            btnDStab2.Enabled = true;

            if (CurrentTab == 1)
            {
                btnDStab1.Enabled = false;
            }
            if (CurrentTab == 2)
            {
                btnDStab2.Enabled = false;
            }

            btnPrevious.Enabled = CurrentTab > 1;
            btnNext.Enabled = CurrentTab < 2;
        }

    }
}