using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    


    protected void Default(object sender, EventArgs e)
    {
        Response.Redirect("~/ERCSDefault.aspx", false);
    }
    protected void EventDefault(object sender, EventArgs e)
    {
        Response.Redirect("~/Event_Default.aspx", false);
    }
    protected void RLogin(object sender, EventArgs e)
    {
        Session["Apptype"] = "R";
        Response.Redirect("~/Login.aspx", false);
    }
    protected void btnGeetaBima_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("~/geeta/Login.aspx", false);
    }
}