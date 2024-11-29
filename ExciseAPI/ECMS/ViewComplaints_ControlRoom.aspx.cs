using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.ECMS
{
    public partial class ViewComplaints_ControlRoom : System.Web.UI.Page
    {
        ECMS_DAL ECMSDAL = new ECMS_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }
        public DataSet dtComplaints
        {
            get
            {
                return ViewState["dtComplaints"] as DataSet;
            }
            set
            {
                ViewState["dtComplaints"] = value;
            }
        }


        public void BindData()
        {
            int Role = Convert.ToInt32(Session["Role"].ToString());
            dtComplaints = ECMSDAL.GetComplaintsByRoleID(Role, ConnKey);
            if (dtComplaints.Tables.Count > 0 && dtComplaints.Tables[0].Rows.Count > 0)
            {
                gvcomplaintdetails.DataSource = dtComplaints.Tables[0];
                gvcomplaintdetails.DataBind();
            }
        }

        protected void gvcomplaintdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkView = e.Row.FindControl("lnkview") as LinkButton;
                int Status = Convert.ToInt16(dtComplaints.Tables[0].Rows[0]["StatusID"].ToString());
                //byte[] Document = Encoding.ASCII.GetBytes(dtComplaints.Tables[0].Rows[0]["DocumentFile"].ToString());
                if (Status > 0)
                {
                    lnkView.Enabled = true;
                    lnkView.Text = "Click..!";
                }
                else
                {
                    lnkView.Enabled = false;
                    lnkView.Text = "Not Available";
                    lnkView.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        protected void gvcomplaintdetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                //string CompalientID = e.CommandArgument.ToString();
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string CompalientID = commandArgs[0];
                int Status = Convert.ToInt16(commandArgs[1]);
                int Role = Convert.ToInt16(Session["Role"].ToString());
                if (!string.IsNullOrEmpty(CompalientID) && Role == 1)
                {
                    Response.Redirect("~/ECMS/ControlRoomForm.aspx?id=" + CompalientID + "", false);
                }
                else if (!string.IsNullOrEmpty(CompalientID) && (Role == 21 || Role == 27))//(Status == 3 || Status == 9 || Status ==10 || Status ==5))
                {
                    Response.Redirect("~/ECMS/DC_Form.aspx?id=" + CompalientID + "", false);
                }
                else if (!string.IsNullOrEmpty(CompalientID) && Role == 2)//(Status == 4 || Status ==9))
                {
                    Response.Redirect("~/ECMS/EnquiryForm.aspx?id=" + CompalientID + "", false);
                }
            }
        }
    }
}