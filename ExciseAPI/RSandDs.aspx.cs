using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI
{
    public partial class RSandDs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlRSDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            divARsIII.Visible = false;
            divRSIII.Visible = false;
            divARSIIB.Visible = false;
            divRSIIB.Visible = false;
            divDSXI.Visible = false;
            divDSXILicence.Visible = false;
            div1.Visible = false;
            divDSXIALicence.Visible = false;
            if (ddlRSDS.SelectedValue == "1")
            {
                divARsIII.Visible = true;
            }
            if (ddlRSDS.SelectedValue == "2")
            {
                divRSIII.Visible = true;
            }
            if (ddlRSDS.SelectedValue == "3")
            {
                divARSIIB.Visible = true;
            }
            if (ddlRSDS.SelectedValue == "4")
            {
                divDSXI.Visible = true;
            }
            if (ddlRSDS.SelectedValue == "5")
            {
                divRSIIB.Visible = true;
            }
            if (ddlRSDS.SelectedValue == "6")
            {
                divDSXILicence.Visible = true;
            }
            if (ddlRSDS.SelectedValue == "7")
            {
                div1.Visible = true;
            }
            if (ddlRSDS.SelectedValue == "8")
            {
                divDSXIALicence.Visible = true;
            }
        }
    }
}