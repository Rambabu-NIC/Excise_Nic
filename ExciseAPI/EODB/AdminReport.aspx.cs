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
    public partial class AdminReport : System.Web.UI.Page
    {
        SqlHelper sql = new SqlHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDetails();
            }
        }
        
        public void BindDetails()
        {
            try
            {
                DataSet data = sql.GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "GetAllReportDetails");
                if (data != null && data.Tables.Count > 0)
                {
                    gvreportdetails.DataSource = data.Tables[0];
                    gvreportdetails.DataBind();
                }
                else
                {
                    gvreportdetails.DataSource = "";
                    gvreportdetails.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}