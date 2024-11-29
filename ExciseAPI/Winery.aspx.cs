using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI
{
    public partial class Winery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddl_winery_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrantofLOI.Visible = false;
            GrantofLicence.Visible = false;
            RenewalofLicence.Visible = false;
            TransferofLicence.Visible = false;
            if (ddl_winery.SelectedValue == "1")
            {
                GrantofLOI.Visible = true;
            }
            if (ddl_winery.SelectedValue == "2")
            {
                GrantofLicence.Visible = true;
            }
            if (ddl_winery.SelectedValue == "3")
            {
                RenewalofLicence.Visible = true;
            }
            if (ddl_winery.SelectedValue == "4")
            {
                TransferofLicence.Visible = true;
            }

        }
    }
}