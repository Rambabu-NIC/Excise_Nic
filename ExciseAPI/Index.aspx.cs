using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Default(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx", false);
        }
        protected void EventDefault(object sender, EventArgs e)
        {
            Response.Redirect("~/Event/EventStatus.aspx", false);
        }
        protected void RLogin(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx", false);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login1.aspx", false);
        }
    }
}