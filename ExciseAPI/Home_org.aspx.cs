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

namespace ExciseAPI
{
    public partial class Home_org : System.Web.UI.Page
    {
        SqlHelper sql = new SqlHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divUnitType.Visible = false;
                divFormType.Visible = false;
                btnapplicant.Visible = false;
                divpublicorprivate.Visible = false;
                divpartenership.Visible = false;
                divpartenerDetails.Visible = false;
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
            catch(Exception ex)
            {

            }
        }

        protected void ddlApplicant_SelectedIndexChanged(object sender, EventArgs e)
        {
            divUnitType.Visible = false;
            int Applicant = Convert.ToInt32(ddlApplicant.SelectedValue);
            if( Applicant > 0)
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
                BindFormDetails(ApplicantType,unitType);
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
            int FormType = Convert.ToInt32(ddlFormType.SelectedValue);
            if (FormType > 0)
            {
                divpublicorprivate.Visible = true;
                divpartenership.Visible = true;
                //btnapplicant.Visible = true;
                
            }
        }

        protected void rblpartenerorproperiter_SelectedIndexChanged(object sender, EventArgs e)
        {
            divpartenerDetails.Visible = false;
            btnapplicant.Visible = false;
            if(rblpartenerorproperiter.SelectedValue == "2")
            {
                btnapplicant.Visible = true;
                divpartenerDetails.Visible = true;
            }
            else
            {
                btnapplicant.Visible = true;
            }
        }
        protected void btnregsubmit_Click(object sender, EventArgs e)
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