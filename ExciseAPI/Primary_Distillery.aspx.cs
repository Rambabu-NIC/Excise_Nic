using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI
{
    public partial class Primary_Distillery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddl_Primary_SelectedIndexChanged(object sender, EventArgs e)
        {
            DivLOID1P.Visible = false;
            LOID1RFully.Visible = false;
            DivLOID1RPartial.Visible = false;
            DivGrantLicenceD1P.Visible = false;
            DivGrantD1RFully.Visible = false;
            DivGrantD1RPartial.Visible = false;
            DivRenewal.Visible = false;
            if (ddl_Primary.SelectedValue == "1")
            {
                DivLOID1P.Visible = true;
            }
            if (ddl_Primary.SelectedValue == "2")
            {
                LOID1RFully.Visible = true;
            }
            if (ddl_Primary.SelectedValue == "3")
            {
                DivLOID1RPartial.Visible = true;
            }
            if (ddl_Primary.SelectedValue == "4")
            {
                DivGrantLicenceD1P.Visible = true;
            }
            if (ddl_Primary.SelectedValue == "5")
            {
                DivGrantD1RFully.Visible = true;
            }
            if (ddl_Primary.SelectedValue == "6")
            {
                DivGrantD1RPartial.Visible = true;
            }
            if (ddl_Primary.SelectedValue == "7")
            {
                DivRenewal.Visible = true;
            }
        }
    }
}