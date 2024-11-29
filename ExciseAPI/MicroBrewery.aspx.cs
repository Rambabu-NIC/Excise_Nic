using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI
{
    public partial class MicroBrewery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddl_microbrewery_SelectedIndexChanged(object sender, EventArgs e)
        {
            grantofpriorclearance.Visible = false;
            grantoflicence.Visible = false;
            renewaloflicence.Visible = false;
            brandlabelapproval.Visible = false;
            if (ddl_microbrewery.SelectedValue == "0")
            {

            }
            if (ddl_microbrewery.SelectedValue == "1")
            {
                grantofpriorclearance.Visible = true;
            }
            if (ddl_microbrewery.SelectedValue == "2")
            {
                grantoflicence.Visible = true;
            }
            if (ddl_microbrewery.SelectedValue == "3")
            {
                renewaloflicence.Visible = true;
            }
            if (ddl_microbrewery.SelectedValue == "4")
            {
               
            }
           
        }
    }
}