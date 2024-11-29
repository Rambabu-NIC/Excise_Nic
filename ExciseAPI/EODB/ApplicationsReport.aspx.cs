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
    public partial class ApplicationsReport : System.Web.UI.Page
    {
        SqlHelper sql = new SqlHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDetails();
            }
        }

        public DataSet GetApplicationsReport 
        {
            get
            {
                return ViewState["GetApplicationsReport"] as DataSet;
            }
            set
            {
                ViewState["GetApplicationsReport"] = value;
            }
        }

        public void BindDetails()
        {
            try
            {
                SqlParameter[] Params =
                 {
                    new SqlParameter("@P_Section", Session["Section"].ToString()),
                    //new SqlParameter("@P_UserName", Session["UserName"].ToString()),
                    //new SqlParameter("@P_ApplicantTypeID", Session["ApplicantTypeID"].ToString()),
                    //new SqlParameter("@P_SubApplicantTypeID", Session["SubApplicantTypeID"].ToString()),
                    //new SqlParameter("@P_FormTypeID", Session["FormTypeID"].ToString())
                };
                GetApplicationsReport = sql.GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetApplicationDetails", Params);
                if (GetApplicationsReport != null && GetApplicationsReport.Tables[0].Rows.Count > 0)
                {
                    gvApplicationReportDetails.DataSource = GetApplicationsReport.Tables[0];
                    gvApplicationReportDetails.DataBind();
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
        }

        protected void gvApplicationReportDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvApplicationReportDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lbnViewM1Details")
            {
                string ApplicationNo = e.CommandArgument.ToString();
               
                try
                {
                    if (!string.IsNullOrEmpty(ApplicationNo))
                    {
                        Session["ApplicationNo"] = ApplicationNo.ToString();
                        Response.Redirect("~/EODB/M1_Preview.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("~/EODB/ApplicationsReport.aspx", false);
                    }
                    
                    return;
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}