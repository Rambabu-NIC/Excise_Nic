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
    public partial class View_M1Details : System.Web.UI.Page
    {
        SqlHelper sql = new SqlHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDetails();
            }
        }

        public DataSet GetdsM1 
        {
            get
            {
                return ViewState["GetdsM1"] as DataSet;
            }
            set
            {
                ViewState["GetdsM1"] = value;
            }
        }

        public void BindDetails()
        {
            try
            {
                SqlParameter[] Params =
                 {
                    new SqlParameter("@P_UserName", Session["UserName"].ToString()),
                    new SqlParameter("@P_ApplicantTypeID", Session["ApplicantTypeID"].ToString()),
                    new SqlParameter("@P_SubApplicantTypeID", Session["SubApplicantTypeID"].ToString()),
                    new SqlParameter("@P_FormTypeID", Session["FormTypeID"].ToString())
                };
                GetdsM1 = sql.GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetM1DraftDetails",Params);
                if (GetdsM1 != null && GetdsM1.Tables[0].Rows.Count > 0)
                {
                    gvM1DraftDetails.DataSource = GetdsM1.Tables[0];
                    gvM1DraftDetails.DataBind();
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

        protected void gvM1DraftDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvM1DraftDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lbnViewM1Details")
            {
                string UserName = e.CommandArgument.ToString();

                try
                {
                    Response.Redirect("~/EODB/M1.aspx", false);
                    return;
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}