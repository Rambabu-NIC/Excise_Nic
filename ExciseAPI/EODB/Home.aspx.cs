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
    public partial class Home : System.Web.UI.Page
    {
        SqlHelper sql = new SqlHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //divUnitType.Visible = false;
                //divFormType.Visible = false;
                //btnapplicant.Visible = false;
                //divpublicorprivate.Visible = false;
                //divpartenership.Visible = false;
                //divpartenerDetails.Visible = false;
                BindApplicantDetails();
            }
        }

        public void BindApplicantDetails()
        {
            try
            {
                DataSet data = sql.GetDataNew(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetApplicantDetails");
                if (data != null && data.Tables.Count > 0)
                {
                    ddlApplicant.Items.Clear();
                    if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
                    {
                        ddlApplicant.DataSource = data.Tables[0];
                        ddlApplicant.DataTextField = "Type_desc";
                        ddlApplicant.DataValueField = "TypeID";
                        ddlApplicant.DataBind();
                    }
                    ddlApplicant.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlApplicant_SelectedIndexChanged(object sender, EventArgs e)
        {
            divUnitType.Visible = false;
            int Applicant = Convert.ToInt32(ddlApplicant.SelectedValue);
            if (Applicant > 0)
            {
                BindUnitDetails(Applicant);
                divUnitType.Visible = true;
            }
        }
        public void BindUnitDetails(int Applicant)
        {
            try
            {
                SqlParameter[] Params =
                 {
                    new SqlParameter("@P_ApplicantID",Applicant),
                };
                DataSet data = sql.GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetManufactureDetails", Params);
                if (data != null && data.Tables.Count > 0)
                {
                    ddlUnitType.Items.Clear();
                    if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
                    {
                        ddlUnitType.DataSource = data.Tables[0];
                        ddlUnitType.DataTextField = "Name";
                        ddlUnitType.DataValueField = "ID";
                        ddlUnitType.DataBind();
                    }
                    ddlUnitType.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void ddlUnitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            divFormType.Visible = false;
            int ApplicantType = Convert.ToInt32(ddlApplicant.SelectedValue);
            int unitType = Convert.ToInt32(ddlUnitType.SelectedValue);
            if (unitType > 0)
            {
                BindFormDetails(ApplicantType, unitType);
                divFormType.Visible = true;
            }
        }
        
        public void BindFormDetails(int ApplicantType, int unitType)
        {
            try
            {
                SqlParameter[] Params =
                 {
                    new SqlParameter("@P_ApplicantID",ApplicantType),
                     new SqlParameter("@P_ManufactureID",unitType),
                };
                DataSet data = sql.GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetFormDetails", Params);
                if (data != null && data.Tables.Count > 0)
                {
                    ddlFormType.Items.Clear();
                    if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
                    {
                        ddlFormType.DataSource = data.Tables[0];
                        ddlFormType.DataTextField = "FormType";
                        ddlFormType.DataValueField = "FormTypeID";
                        ddlFormType.DataBind();
                    }
                    ddlFormType.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlFormType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnapplicant.Visible = false;
            int ApplicantType = Convert.ToInt32(ddlApplicant.SelectedValue);
            int unitType = Convert.ToInt32(ddlUnitType.SelectedValue);
            int FormType = Convert.ToInt32(ddlFormType.SelectedValue);
            if (FormType > 0)
            {
                divpublicorprivate.Visible = true;
                divpartenership.Visible = true;
                //btnapplicant.Visible = true;
                BindApplicationNo(ApplicantType, unitType, FormType);
            }
        }
        public void BindApplicationNo(int ApplicantType, int unitType,int FormType)
        {
            try
            {
                SqlParameter[] Params =
                 {
                    new SqlParameter("@P_ApplicantID",ApplicantType),
                     new SqlParameter("@P_ManufactureID",unitType),
                     new SqlParameter("@P_FormType",FormType),
                };
                DataSet data = sql.GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetApplicationNo", Params);
                if (data != null && data.Tables.Count > 0)
                {
                    Session["ApplicationNo"] = data.Tables[0].Rows[0]["ApplicationNo"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected void rblpartenerorproperiter_SelectedIndexChanged(object sender, EventArgs e)
        {
            divpartenerDetails.Visible = false;
            btnapplicant.Visible = false;
            divgridDetails.Visible = false;
            if (rblpartenerorproperiter.SelectedValue == "2")
            {
                btnapplicant.Visible = true;
                divpartenerDetails.Visible = true;
            }
            else
            {
                btnapplicant.Visible = true;
            }
            try
            {
                SqlParameter[] Params =
                 {
                    new SqlParameter("@P_UserName", Session["UserName"].ToString()),
                    new SqlParameter("@IsPartener",rblpartenerorproperiter.SelectedValue)
                };
                GetApplicantDetails  = sql.GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetApplicantPersonalDetails", Params);
                if (GetApplicantDetails != null && GetApplicantDetails.Tables.Count > 0)
                {
                    divgridDetails.Visible = true;

                    dtPartenerDetails = null;

                    //var item = GetApplicantDetails.Tables[0].Rows[0];
                    //if (item["status"].ToString() == "SUCCESS")
                    //{
                        dtPartenerDetails = PartenerDetails();
                    foreach (DataRow item in GetApplicantDetails.Tables[0].Rows)
                    {
                        DataRow drDetail = dtPartenerDetails.NewRow();
                        drDetail["UserName"] = item["UserName"];
                        drDetail["MobileNo"] = item["MobileNo"];
                        drDetail["ApplicationNo"] = Session["ApplicationNo"];
                        drDetail["ApplicantName"] = item["ApplicantName"];
                        drDetail["Aadhar"] = item["Aadhar"];
                        drDetail["PanNo"] = item["PanNo"];
                        drDetail["GstNo"] = item["GstNo"];
                        drDetail["Email"] = item["Email"];
                        drDetail["DistrictID"] = item["DistrictID"];
                        drDetail["MandalID"] = item["MandalID"];
                        drDetail["VillageID"] = item["VillageID"];
                        drDetail["HouseNo"] = item["HouseNo"];
                        drDetail["Street"] = item["Street"];
                        dtPartenerDetails.Rows.Add(drDetail);
                    }
                        gvdetails.DataSource = dtPartenerDetails;
                        gvdetails.DataBind();
                    //}
                    //else
                    //{
                    //    lblActionerror.Text = "Please Check the Details";
                    //    return;
                    //}
                }
                else
                {
                    divgridDetails.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public DataSet GetApplicantDetails
        {
            get
            {
                return ViewState["GetApplicantDetails"] as DataSet;
            }
            set
            {
                ViewState["GetApplicantDetails"] = value;
            }
        }
        protected void gvdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lkbtnDelete")
            {
                string DocumentID = e.CommandArgument.ToString();

                if (GetApplicantDetails.Tables.Count >0 &&  GetApplicantDetails.Tables[0].Rows.Count > 0)
                {
                    LinkButton lkbtnDelete = (sender) as LinkButton;
                    if(GetApplicantDetails.Tables[0].Rows.Count > 1)
                    {
                        lkbtnDelete.Visible = true;
                    }
                }
            }
        }

        protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
        private DataTable PartenerDetails()
        {
            DataTable dtPDetail = new DataTable();
            //DataColumn dtSNo = new DataColumn("SNo", typeof(int));
            //dtPDetail.Columns.Add(dtSNo);
            dtPDetail.Columns.Add("UserName", typeof(string));
            dtPDetail.Columns.Add("MobileNo", typeof(string));
            dtPDetail.Columns.Add("ApplicationNo", typeof(string));
            dtPDetail.Columns.Add("ApplicantName", typeof(string));
            dtPDetail.Columns.Add("Aadhar", typeof(string));
            dtPDetail.Columns.Add("PanNo", typeof(string));
            dtPDetail.Columns.Add("GstNo", typeof(string));
            dtPDetail.Columns.Add("Email", typeof(string));
            dtPDetail.Columns.Add("DistrictID", typeof(int));
            dtPDetail.Columns.Add("MandalID", typeof(int));
            dtPDetail.Columns.Add("VillageID", typeof(int));
            dtPDetail.Columns.Add("HouseNo", typeof(string));
            dtPDetail.Columns.Add("Street", typeof(string));
            return dtPDetail;
        }

        private DataTable dtPartenerDetails
        {
            get
            {
                if (ViewState["dtPartenerDetails"] == null)

                {
                    DataTable dt = PartenerDetails();

                    ViewState["dtPartenerDetails"] = dt;
                }
                return ViewState["dtPartenerDetails"] as DataTable;
            }
            set
            {
                ViewState["dtPartenerDetails"] = value;
            }
        }
        protected void lkbtnDelete_Click(object sender, EventArgs e)
        {
            GridViewRow gvrow = (sender as LinkButton).NamingContainer as GridViewRow;
            if (dtPartenerDetails.Rows.Count >0)
            {
                dtPartenerDetails.Rows.Remove(dtPartenerDetails.Rows[gvrow.RowIndex]);
                gvdetails.DataSource = dtPartenerDetails;
                gvdetails.DataBind();
                if (dtPartenerDetails.Rows.Count ==0)
                {
                    divgridDetails.Visible = false;
                }
            }
        }

        protected void btnAddApplicant_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }
            try
            {
                
               // dtPartenerDetails = PartenerDetails();
                DataRow drDetail = dtPartenerDetails.NewRow();
                drDetail["UserName"] = Session["UserName"].ToString();
                drDetail["MobileNo"] = txtMobileNo.Text.ToString();
                drDetail["ApplicationNo"] = Session["ApplicationNo"];
                drDetail["ApplicantName"] = txtApplicantName.Text.ToString();
                drDetail["Aadhar"] = txtAadhar.Text.ToString();
                drDetail["PanNo"] = txtPanNo.Text.ToString();
                drDetail["GstNo"] = txtGstNo.Text.ToString();
                drDetail["Email"] = txtEmail.Text.ToString();
                drDetail["DistrictID"] = 0;//ddlDistrict.SelectedValue;
                drDetail["MandalID"] = 0;//ddlMandal.SelectedValue;
                drDetail["VillageID"] = 0;//ddlVillage.SelectedValue;
                drDetail["HouseNo"] = txtHouseNo.Text.ToString();
                drDetail["Street"] = txtStreet.Text.ToString(); 
                dtPartenerDetails.Rows.Add(drDetail);
                gvdetails.DataSource = dtPartenerDetails;
                gvdetails.DataBind();

            }
            catch (Exception ex)
            {

            }

        }

        //Submit Click
        protected void btnhomeclick_Click(object sender, EventArgs e)
        {
            if(rblpartenerorproperiter.SelectedValue == "2" && dtPartenerDetails.Rows.Count ==0)
            {
                lblActionerror.Text = "Please Add Partnership Details..";
                return;
            }
            else if(dtPartenerDetails.Rows.Count == 0)
            {
                lblActionerror.Text = "Please Check the Proprietory Details";
                return;
            }
            string ParameterTypeName = "@TablePersonalDetails";
            string TypeName = "TablePersonalDetails";
            int ApplicantType = Convert.ToInt32(ddlApplicant.SelectedValue);
            int unitType = Convert.ToInt32(ddlUnitType.SelectedValue);
            int FormType = Convert.ToInt32(ddlFormType.SelectedValue);
            DateTime aDate = DateTime.Now;
            string ApplicationNo = Session["ApplicationNo"].ToString();

            Session["ApplicantPersonalDetails"] = dtPartenerDetails;
            RedirectToPage();


            //try
            //{
            //    SqlParameter[] Params =
            //     {
            //        new SqlParameter("@P_UserName", Session["UserName"].ToString()),
            //        new SqlParameter("@P_ApplicationNo", ApplicationNo.ToString()),
            //    };
            //    DataSet data = sql.GetDataInsert(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "PersonalDetails_Insert", Params,dtPartenerDetails,ParameterTypeName,TypeName);
            //    if (data != null && data.Tables.Count > 0)
            //    {
            //        var item = data.Tables[0].Rows[0];
            //        if (item["Status"].ToString() == "SUCCESS")
            //        {
            //            RedirectToPage();
            //        }
            //        else
            //        {
            //            lblActionerror.Text = item["Message"].ToString();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}



        }

        public void RedirectToPage()
        {
            //GetPageDetails
            int ApplicantType = Convert.ToInt32(ddlApplicant.SelectedValue);
            int unitType = Convert.ToInt32(ddlUnitType.SelectedValue);
            int FormType = Convert.ToInt32(ddlFormType.SelectedValue);
            try
            {
                SqlParameter[] Params =
                 {
                    new SqlParameter("@P_ApplicantID",ApplicantType),
                     new SqlParameter("@P_ManufactureID",unitType),
                     new SqlParameter("@P_FormType",FormType),
                };
                DataSet data = sql.GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetPageDetails", Params);
                if (data != null && data.Tables.Count > 0)
                {
                    Session["ApplicantTypeID"] = ApplicantType;
                    Session["SubApplicantTypeID"] = unitType;
                    Session["FormTypeID"] = FormType;

                    string PageName = "" + data.Tables[0].Rows[0]["Page_Name"].ToString() + "";

                    Response.Redirect(PageName.ToString(), false);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}