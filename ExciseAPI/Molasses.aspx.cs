using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI
{
    public partial class Molasses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddl_Molasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            GrantofM1Licence.Visible = false;
            GrantofM2Licence.Visible = false;
            GrantofM4Licence.Visible = false;
            GrantofM5Licence.Visible = false;
            if (ddl_Molasses.SelectedValue == "1")
            {
                GrantofM1Licence.Visible = true;
            }
            if (ddl_Molasses.SelectedValue == "2")
            {
                GrantofM2Licence.Visible = true;
            }
            if (ddl_Molasses.SelectedValue == "3")
            {
                GrantofM4Licence.Visible = true;
            }

            if (ddl_Molasses.SelectedValue == "4")
            {
                GrantofM5Licence.Visible = true;
            }


        }
    }
}