using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Excise_BE;
using Excise_DAL;

namespace ExciseAPI.Supplier
{
    public partial class DepartmentApplications : System.Web.UI.Page
    {
        Supplier_BE objSupBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_BE objBE = new Master_BE();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && (Session["Role"].ToString() == "2" || Session["Role"].ToString() == "4" ||
                Session["Role"].ToString() == "7" || Session["Role"].ToString() == "50" || Session["Role"].ToString() == "27" || Session["Role"].ToString() == "55"
                || Session["Role"].ToString() == "54" || Session["Role"].ToString() == "28" || Session["Role"].ToString() == "29")
                && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Error.aspx");
            }

            if (!IsPostBack)
            {
                BindDetails();
            }
        }
        public DataSet GetDeptDetails
        {
            get
            {
                return ViewState["GetDeptDetails"] as DataSet;
            }
            set
            {
                ViewState["GetDeptDetails"] = value;
            }
        }
        public void BindDetails()
        {
            int Role = Convert.ToInt32(Session["Role"].ToString());
            string SHOUsername = Session["SHOUsername"].ToString();
            string EXDIST_CODE = Session["EXDIST_CODE"].ToString();
            string UserSection = Session["UserSection"].ToString();
            GetDeptDetails = objDL.GetDepartmentRenewalApplications(Role, SHOUsername, EXDIST_CODE, UserSection, ConnKey);
            if (GetDeptDetails.Tables.Count > 0)
            {
                if (GetDeptDetails.Tables[0].Rows.Count > 0)
                {
                    gvdetails.DataSource = GetDeptDetails.Tables[0];
                    gvdetails.DataBind();
                }
                
            }

        }

        protected void gvdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var commandArgument = e.CommandArgument.ToString();
            DataRow drDetails = GetDeptDetails.Tables[0].Rows[gvdetails.Rows[Convert.ToInt32(commandArgument)].RowIndex];
            if (e.CommandName == "lkbApplicationView")
            {
                Session["ApplicationType"] = drDetails[0].ToString() + drDetails[1].ToString();
                int ApplicationNo =Convert.ToInt32(e.CommandArgument);
                Response.Redirect("~/Renewals/DepartmentActionGrid.aspx", false );
            }
        }
    }
}