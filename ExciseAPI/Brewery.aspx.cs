using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI
{
    public partial class Brewery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddl_brewery_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grantofloi.Visible = false;
            GrantofLicence.Visible = false;
            DivRenewal.Visible = false;
            if (ddl_brewery.SelectedValue == "1")
            {
                Grantofloi.Visible = true;
            }
            if (ddl_brewery.SelectedValue == "2")
            {
                GrantofLicence.Visible = true;
            }
            if (ddl_brewery.SelectedValue == "3")
            {
                DivRenewal.Visible = true;
            }
        }
    }
}