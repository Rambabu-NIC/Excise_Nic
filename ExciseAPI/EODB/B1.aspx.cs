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
    public partial class B1 : System.Web.UI.Page
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
            if(dsdistrict !=null && dsdistrict.Tables.Count > 0)
            {
                //ddlDistrict
                ddlDistrict.Items.Clear();
                ddlDistrict_A.Items.Clear();
                ddlEDistrict.Items.Clear();
                if (dsdistrict.Tables.Count > 0 && dsdistrict.Tables[0].Rows.Count > 0)
                {
                    ddlDistrict.DataSource = dsdistrict.Tables[0];
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataValueField = "DistrictID";
                    ddlDistrict.DataBind();

                    ddlDistrict_A.DataSource = dsdistrict.Tables[0];
                    ddlDistrict_A.DataTextField = "DistrictName";
                    ddlDistrict_A.DataValueField = "DistrictID";
                    ddlDistrict_A.DataBind();

                    ddlEDistrict.DataSource = dsdistrict.Tables[0];
                    ddlEDistrict.DataTextField = "DistrictName";
                    ddlEDistrict.DataValueField = "DistrictID";
                    ddlEDistrict.DataBind();
                    
                }
                ddlDistrict.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                ddlDistrict_A.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                ddlEDistrict.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
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

        protected void btnd1p_Click(object sender, EventArgs e)
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
                        DM1insert();
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

        public void DM1insert()
        {
            if (D1PFileUpload.Rows.Count != ddlFileUpload.Items.Count)
            {
                lblFileUploaderror.Text = "Please Upload All Documents";
                return;
            }
            SqlParameter[] Params =
                {
                    new SqlParameter("@ApplicationNo",Session["ApplicationNo"].ToString()),
                    new SqlParameter("@Notify_no ",txtNotify_no.Text.ToString()),
                    new SqlParameter("@Applicanttype","0"),// ddlFirmType.SelectedValue),
                    new SqlParameter("@FirmName",txtFirmname.Text.ToString()),//,txtapplicantname.Text.ToString()),
                    new SqlParameter("@ROC_NO",txtRocNumber.Text.ToString()),//,txtRocNumber.Text.ToString()),
                    new SqlParameter("@U_Name",txtUndertaking.Text.ToString()),
                    new SqlParameter("@U_District",ddlDistrict.SelectedValue),
                    new SqlParameter("@U_Mandal",ddlMandal.SelectedValue),
                    new SqlParameter("@U_Village",ddlVillage.SelectedValue),
                    new SqlParameter("@U_House_No",txtHouseNo.Text.ToString()),
                    new SqlParameter("@U_Street_Road",txtStreet.Text.ToString()),
                    new SqlParameter("@UA_Name",txtUndertaking_A.Text.ToString()),
                    new SqlParameter("@UA_District",ddlDistrict_A.SelectedValue),
                    new SqlParameter("@UA_Mandal",ddlMandal_A.SelectedValue),
                    new SqlParameter("@UA_Village",ddlVillage_A.SelectedValue),
                    new SqlParameter("@UA_House_No",txtHouseNo_A.Text.ToString()),
                    new SqlParameter("@UA_Street_Road",txtStreet_A.Text.ToString()),
                    new SqlParameter("@DL_District",ddlEDistrict.SelectedValue),
                    new SqlParameter("@DL_Mandal",ddlEMandal.SelectedValue),
                    new SqlParameter("@DL_Village",ddlEVillage.SelectedValue),
                    new SqlParameter("@DL_Survey_No",txtSurveyNo.Text.ToString()),
                    new SqlParameter("@DL_Extent",txtExtent.Text.ToString()),
                    new SqlParameter("@Is_Eaxpansion",rblbrewary.SelectedValue),
                    new SqlParameter("@LicenceNo",txtExistingLicense.Text.ToString()),
                    new SqlParameter("@Nature_Activity",txtnature_of_activity.Text.ToString()),
                    new SqlParameter("@Ex_Prod_Capacity",txtexisting_production_capacity.Text.ToString()),
                    new SqlParameter("@Incresing_Prod_Capacity",txtproposed_production_capacity.Text.ToString()),
                    new SqlParameter("@Is_sufLand_owns",rbl_sufLand_owns.SelectedValue),
                    new SqlParameter("@Invest_Capital",txtcapital_investment.Text.ToString()),
                    new SqlParameter("@Invest_Borrowings",txtborrowings.Text.ToString()),
                    new SqlParameter("@Invest_OnLand",txtinvestment_land.Text.ToString()),
                    new SqlParameter("@Invest_OnBuilding",txtinvestment_building.Text.ToString()),
                    new SqlParameter("@Invest_OnPlantMachine",txtinvestment_machinery.Text.ToString()),
                    new SqlParameter("@Invest_WorkingCapital",txtworking_capital.Text.ToString()),
                    new SqlParameter("@Is_Available_Water",rblsufficient_water.SelectedValue),
                    new SqlParameter("@Is_Available_PowerSupply",rblpower_supply.SelectedValue),
                    //
                    new SqlParameter("@Q_RawMaterial_Imported",txtRImported_Quantity.Text.ToString()),
                    new SqlParameter("@Q_RawMaterial_Imported_Other",txtRImported_Value.Text.ToString()),
                    new SqlParameter("@Q_RawMaterial_Indigenous",txtRIndigenous_Quantity.Text.ToString()),
                    new SqlParameter("@Q_RawMaterial_Indigenous_Other",txtRIndigenous_Value.Text.ToString()),

                 
                    new SqlParameter("@Is_able_secure_raw",rblsecuretherawmaterial.SelectedValue),
                    new SqlParameter("@Is_Machinery_imported",rblimportedorindigenous.SelectedValue),
                    new SqlParameter("@Imported_Indigenous_Details",txtimportIndigenous.Text.ToString()),
                    new SqlParameter("@Name_Spirits",txtsprit_name.Text.ToString()),
                    new SqlParameter("@Product_Standards",txtstandards.Text.ToString()),
                    new SqlParameter("@Brief_Process_Man",txtmanufacture_process.Text.ToString()),
                    new SqlParameter("@Product_Eastimte_Anually",txtEstimatedAprod.Text.ToString()),
                    new SqlParameter("@Is_BuyBack",rblbuybackarrange.SelectedValue),
                    new SqlParameter("@BuyBack_Details",txtforeignexchangeinvolved.Text.ToString()),
                    new SqlParameter("@Time_req_sec_land",txtsecureland.Text.ToString()),
                    new SqlParameter("@Time_req_erect_plant_machine",txtplantandmechinery.Text.ToString()),
                    new SqlParameter("@Staff_Supervisors",txtsupervisorystaff.Text.ToString()),
                    new SqlParameter("@Staff_SkilledWorkers",txtskilledworkers.Text.ToString()),
                    new SqlParameter("@Staff_UnSkilledWorkers",txtunskilledworkers.Text.ToString()),
                    new SqlParameter("@Is_Facility_govt_req",rblspecialfacilties.SelectedValue),
                    new SqlParameter("@Facility_Details",""),
                    new SqlParameter("@CreatedBy",Session["UserName"].ToString()),


            };

            string ParameterTypeName = "@DocumentDetails_N";
            string TypeName = "DocumentDetails_E";

            DataTable dtdocument = D1PFileUpload;

            try
            {

                DataSet data = sql.GetDataInsert(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "B1_Insert", Params, dtdocument,ParameterTypeName, TypeName);
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

        protected void ddlDistrict_A_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlDistrict_A.SelectedValue);
            if (DistID > 0)
            {
                BinMandalDetails(DistID, ddlMandal_A);
            }
            else
            {
                lblActionerror.Text = "Please select District";
                return;
            }
        }
        protected void ddlEDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlEDistrict.SelectedValue);
            if (DistID > 0)
            {
                BinMandalDetails(DistID, ddlEMandal);
            }
            else
            {
                lblActionerror.Text = "Please select District";
                return;
            }
        }

        public void BinMandalDetails(int DistrictID,DropDownList dropdown)
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
            if (DistID > 0 && MandalID >0)
            {

                BindVillageDetails(DistID,MandalID, ddlVillage);
            }
            else
            {
                lblActionerror.Text = "Please select District  && Mandal";
                return;
            }
        }

        protected void ddlMandal_A_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlDistrict_A.SelectedValue);
            int MandalID = Convert.ToInt32(ddlMandal_A.SelectedValue);
            if (DistID > 0 && MandalID >0)
            {
                BindVillageDetails(DistID,MandalID, ddlVillage_A);
            }
            else
            {
                lblActionerror.Text = "Please select District  && Mandal";
                return;
            }
        }



        protected void ddlEMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlEDistrict.SelectedValue);
            int MandalID = Convert.ToInt32(ddlEMandal.SelectedValue);
            if (DistID > 0 && MandalID > 0)
            {
                BindVillageDetails(DistID, MandalID, ddlEVillage);
            }
            else
            {
                lblActionerror.Text = "Please select District && Mandal";
                return;
            }
        }
        public void BindVillageDetails(int DistrictID,int MandalID, DropDownList dropdown)
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
            int ApplicantType = 1; int SubApplicantType = 3; int FormType = 1;

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
        private DataTable D1PFileUpload
        {
            get
            {
                if (ViewState["D1PFileUpload"] == null)

                {
                    DataTable dt = FinalInsertDocumentDetails();
                    ViewState["D1PFileUpload"] = dt;
                }
                return ViewState["D1PFileUpload"] as DataTable;
            }
            set
            {
                ViewState["D1PFileUpload"] = value;
            }
        }


        protected void btnfileAdd_Click(object sender, EventArgs e)
        {
            DataTable dtD1PUploadDetails = D1PFileUpload;
            divuploadedDocuments.Visible = true;
            lblFileUploaderror.Text = string.Empty;
            bool IsDocumentExists = false;
            string DocumentType = ddlFileUpload.SelectedItem.Text;
            if (dtD1PUploadDetails.Rows.Count >0)
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
                D1PFileUpload = dtD1PUploadDetails;
                gvaddrecordsofLOI.DataSource = D1PFileUpload;
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

                if (D1PFileUpload.Rows.Count > 0)
                {
                    DataView dvSelectedApplication = new DataView(D1PFileUpload);
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

                if (D1PFileUpload.Rows.Count > 0)
                {
                    divuploadedDocuments.Visible = true;
                    //  divRenewalAmounts.Visible = true;
                    D1PFileUpload.Rows.Remove(D1PFileUpload.Rows[rowindex]);

                    gvaddrecordsofLOI.DataSource = D1PFileUpload;
                    gvaddrecordsofLOI.DataBind();

                    if (D1PFileUpload.Rows.Count == 0)
                    {
                        divuploadedDocuments.Visible = false;
                        //   divRenewalAmounts.Visible = false;
                    }
                }
            }
        }

        protected void btnB1tab1_Click(object sender, EventArgs e)
        {
            CurrentTab = 1;
            if (CurrentTab == 1)
            {

                ShowCurrentTab();
            }
            btnB1tab1.Enabled = false;
        }

        protected void btnB1tab2_Click(object sender, EventArgs e)
        {
            CurrentTab = 2;
            if (CurrentTab < 3)
            {

                ShowCurrentTab();
            }
            btnB1tab2.Enabled = false;
        }

        protected void btnB1tab3_Click(object sender, EventArgs e)
        {
            CurrentTab = 3;
            if (CurrentTab < 4)
            {

                ShowCurrentTab();
            }
            btnB1tab3.Enabled = false;

        }

        protected void btnB1tab4_Click(object sender, EventArgs e)
        {
            CurrentTab = 4;
            if (CurrentTab < 5)
            {

                ShowCurrentTab();
            }
            btnB1tab4.Enabled = false;
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
            if (CurrentTab < 5)
            {
                CurrentTab++;
                ShowCurrentTab();
            }
        }
        private void ShowCurrentTab()
        {
            B1tab1.Visible = CurrentTab == 1;
            B1tab2.Visible = CurrentTab == 2;
            B1tab3.Visible = CurrentTab == 3;
            B1tab4.Visible = CurrentTab == 4;

            btnB1tab1.Enabled = true;
            btnB1tab2.Enabled = true;
            btnB1tab3.Enabled = true;
            btnB1tab4.Enabled = true;
            if (CurrentTab == 1)
            {
                btnB1tab1.Enabled = false;
            }
            if (CurrentTab == 2)
            {
                btnB1tab2.Enabled = false;
            }
            if (CurrentTab == 3)
            {
                btnB1tab3.Enabled = false;
            }
            if (CurrentTab == 4)
            {
                btnB1tab4.Enabled = false;
            }

            btnPrevious.Enabled = CurrentTab > 1;
            btnNext.Enabled = CurrentTab < 4;
        }
    }
}