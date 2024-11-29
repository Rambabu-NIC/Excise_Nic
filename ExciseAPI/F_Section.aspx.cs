using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI
{
    public partial class F_Section : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlA4_Shops_SelectedIndexChanged(object sender, EventArgs e)
        {
            A4Shops.Visible = false;
            Bars.Visible = false;
            clubs.Visible = false;
            Tourism.Visible = false;
            TODDYSHOPLICENSE.Visible = false;
            DivCS1.Visible = false;
            DivCS2.Visible = false;
            if (ddlA4_Shops.SelectedValue == "1")
            {
                A4Shops.Visible = true;
            }
            if (ddlA4_Shops.SelectedValue == "2")
            {
                Bars.Visible = true;
            }
            if (ddlA4_Shops.SelectedValue == "3")
            {
                clubs.Visible = true;
            }
            if (ddlA4_Shops.SelectedValue == "4")
            {
                Tourism.Visible = true;
            }
            if (ddlA4_Shops.SelectedValue == "5")
            {
                TODDYSHOPLICENSE.Visible = true;
            }
            if (ddlA4_Shops.SelectedValue == "6")
            {
                DivCS1.Visible = true;
            }
            if (ddlA4_Shops.SelectedValue == "7")
            {
                DivCS2.Visible = true;
            }
        }
    }
}