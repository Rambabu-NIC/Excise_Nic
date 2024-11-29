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
    public partial class FWDRenewalApplications : System.Web.UI.Page
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
            string UserName = Session["SHOUsername"].ToString();
            string EXDIST_CODE = Session["EXDIST_CODE"].ToString();
            string ApplicationType = Session["ApplicationType"].ToString();
            string UserSection = Session["UserSection"].ToString();
            GetDeptDetails = objDL.GetFWDRenewalAPPDetails(Role,UserName,EXDIST_CODE, ApplicationType, UserSection, ConnKey);
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
            Session["RenewalID"] = drDetails["ID"].ToString();
            Session["ApplicationNo"] = drDetails["ApplicationNo"].ToString();
            Session["Type_Man_Cd"] = drDetails["Type_Man_Cd"].ToString();
            Session["Application_SL_No"] = drDetails["Application_No"].ToString();
            Session["Current_Level"] = drDetails["Current_Level"].ToString();
            Session["TypeofUser"] = drDetails["UserType"].ToString();
            string UserType = drDetails["UserType"].ToString();
            string TypeManCD = drDetails["Type_Man_Cd"].ToString();
            string ApplicationSLNO = drDetails["Application_No"].ToString();
            if (e.CommandName == "lkbApplicationView")
            {
                int ApplicationNo = Convert.ToInt32(e.CommandArgument);
                
                if (UserType== "R" &&  TypeManCD== "2" && ApplicationSLNO=="1")
                {
                    Response.Redirect("~/Renewals/ViewRenewalApplications.aspx", false);
                }
                else if(UserType == "M" && TypeManCD == "5" && ApplicationSLNO == "1")
                {
                    Response.Redirect("~/Renewals/ViewMBRenewalApplications.aspx", false);
                }
            }
            if (e.CommandName == "lkbProceedingView")
            {
                int ApplicationNo = Convert.ToInt32(e.CommandArgument);
                if (UserType == "R" && TypeManCD == "2" && ApplicationSLNO == "1")
                {
                    Response.Redirect("~/Renewals/BARRenewalProceedings.aspx", false);
                }
                else if (UserType == "M" && TypeManCD == "5" && ApplicationSLNO == "1")
                {
                    
                }
            }
            if (e.CommandName == "lkbEndorsementView")
            {
                int ApplicationNo = Convert.ToInt32(e.CommandArgument);
                if (UserType == "R" && TypeManCD == "2" && ApplicationSLNO == "1")
                {
                    Response.Redirect("~/Renewals/BAREndorsement.aspx", false);
                }
                else if (UserType == "M" && TypeManCD == "5" && ApplicationSLNO == "1")
                {
                    Response.Redirect("~/Renewals/MBEndorsement.aspx", false);
                }
            }
        }

        protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int temp;
                int StatusID = int.TryParse(GetDeptDetails.Tables[0].Rows[e.Row.RowIndex]["StatusID"].ToString(), out temp) ? temp : 0;
                string UserType = GetDeptDetails.Tables[0].Rows[e.Row.RowIndex]["UserType"].ToString();
                LinkButton lkbProceedingView = e.Row.FindControl("lkbProceedingView") as LinkButton;
                LinkButton lkbEndorsementView = e.Row.FindControl("lkbEndorsementView") as LinkButton;
                if (StatusID ==5 && UserType =="R")
                {
                    lkbProceedingView.Enabled = true;
                    lkbProceedingView.ToolTip = "Click here for Proceedings";
                    lkbProceedingView.Text = "Click..!";

                    lkbEndorsementView.Enabled = true;
                    lkbEndorsementView.ToolTip = "Click here for Endorsement";
                    lkbEndorsementView.Text = "Click..!";

                }
                else if (StatusID == 5 && UserType == "M")
                {
                    lkbProceedingView.Enabled = false;
                    lkbProceedingView.ToolTip = "";
                    lkbProceedingView.Text = "";

                    lkbEndorsementView.Enabled = true;
                    lkbEndorsementView.ToolTip = "Click here for Endorsement";
                    lkbEndorsementView.Text = "Click..!";

                }
                else
                {
                    lkbProceedingView.Enabled = false;
                    lkbProceedingView.Text = "";
                    lkbProceedingView.ToolTip = "";

                    lkbEndorsementView.Enabled = false;
                    lkbEndorsementView.ToolTip = "";
                    lkbEndorsementView.Text = "";


                }
            }
        }
    }
}