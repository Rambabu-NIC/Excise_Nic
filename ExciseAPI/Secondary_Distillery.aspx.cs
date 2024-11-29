using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI
{
    public partial class Secondary_Distillery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddl_secondary_dist_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrantofLicence.Visible = false;
            RenewalofLicence.Visible = false;
            TransferofLicence.Visible = false;
            if (ddl_secondary_dist.SelectedValue == "1")
            {
                GrantofLicence.Visible = true;
            }
            if (ddl_secondary_dist.SelectedValue == "2")
            {
                RenewalofLicence.Visible = true;
            }
            if (ddl_secondary_dist.SelectedValue == "3")
            {
                TransferofLicence.Visible = true;
            }
        }
    }
}