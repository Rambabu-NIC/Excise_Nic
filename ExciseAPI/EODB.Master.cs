using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI
{
    public partial class EODB : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenuDetails();
            }
        }

        public void BindMenuDetails()
        {
            divApplicant.Visible = false;
            divDepartment.Visible = false;
            divSections.Visible = false;
            if (Session["RoleID"] != null)
            {
                int RoleID =Convert.ToInt32(Session["RoleID"].ToString());
                if(RoleID == 1)
                {
                    divDepartment.Visible = true;
                }
                if (RoleID == 7)
                {
                    divSections.Visible = true;
                }
                if (RoleID == 8)
                {
                    divApplicant.Visible = true;
                }
            }
        }


    }
}