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
    public partial class M1_Preview : System.Web.UI.Page
    {
        SqlHelper sql = new SqlHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDetails();
            }
        }
        public DataSet GetApplicationsDetails
        {
            get
            {
                return ViewState["GetApplicationsDetails"] as DataSet;
            }
            set
            {
                ViewState["GetApplicationsDetails"] = value;
            }
        }


        public void BindDetails()
        {
            divgridDetails.Visible = false;
            divuploadedDocuments.Visible = false;
            try
            {
                SqlParameter[] Params =
                 {
                    new SqlParameter("@P_Section", Session["Section"].ToString()),
                    new SqlParameter("@P_ApplicationNo", Session["ApplicationNo"].ToString()),
                };
                GetApplicationsDetails = sql.GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetApplicationDetailsByApplicationNo", Params);
                if (GetApplicationsDetails != null && GetApplicationsDetails.Tables[0].Rows.Count > 0)
                {
                    gvpersonaldetails.DataSource = GetApplicationsDetails.Tables[0];
                    gvpersonaldetails.DataBind();
                    divgridDetails.Visible = true;

                    if (GetApplicationsDetails.Tables[1].Rows.Count > 0)
                    {
                        var item = GetApplicationsDetails.Tables[1].Rows[0];
                        lblSugarFactory.Text = item["NameofSugarFactory"].ToString();
                        lblDistrict.Text = item["DistrictName"].ToString();
                        lblMandal.Text = item["MandalName"].ToString();
                        lblVillage.Text = item["VillageName"].ToString();
                        lblSurveyNo.Text = item["SurveyNo"].ToString();
                        lblrblOwnLand.Text = item["IS_OwnerLand"].ToString();
                        lbltxtOMobile.Text = item["OMobile"].ToString();
                        lbltxtOPan.Text = item["OPan"].ToString();
                        lbltxtOAadhar.Text = item["OAadhar"].ToString();
                        lbltxtOGst.Text = item["OGst"].ToString();
                        lbltxtOEmail.Text = item["OEmail"].ToString();
                        lbltxtMolasse.Text = item["DetailMolasses"].ToString();
                        lbltxtAnualQty.Text = item["AnualQty"].ToString();
                        lblrblstoragetank.Text = item["IS_StorageTank"].ToString();
                        lbltxtPeriodLicense.Text = item["PeriodLicense"].ToString();
                        lbltxtMProduced.Text = item["TotalQty_Molasses"].ToString();

                    }
                    if (GetApplicationsDetails.Tables[2].Rows.Count > 0)
                    {
                        M1FileUpload = GetApplicationsDetails.Tables[2];
                        gvM1Documents.DataSource = GetApplicationsDetails.Tables[2];
                        gvM1Documents.DataBind();
                        divuploadedDocuments.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("~/EODB/M1.aspx", false);
                    return;
                }
            }
            catch (Exception ex)
            {

            }
            //DataTable dt = Session["ApplicantPersonalDetails"] as DataTable;
            //if (dt != null)
            //{
            //    divgridDetails.Visible = true;
            //    gvpersonaldetails.DataSource = dt;
            //    gvpersonaldetails.DataBind();
            //}

        }

        protected void gvM1Documents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkbtn_Documents")
            {
                string DocumentID = e.CommandArgument.ToString();

                if (M1FileUpload.Rows.Count > 0)
                {
                    DataView dvSelectedApplication = new DataView(M1FileUpload);
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
        private DataTable M1FileUpload
        {
            get
            {
                if (ViewState["M1FileUpload"] == null)

                {
                    DataTable dt = FinalInsertDocumentDetails();
                    ViewState["M1FileUpload"] = dt;
                }
                return ViewState["M1FileUpload"] as DataTable;
            }
            set
            {
                ViewState["M1FileUpload"] = value;
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
    }
}