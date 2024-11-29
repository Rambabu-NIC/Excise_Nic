using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

public partial class PrintPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Stream[] s = Request.QueryString["b"];
        byte[] b = (byte[])Session["bytes"];
        string filetype = Session["Ftype"].ToString();
        if (filetype == ".pdf")
        {
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "inline; filename=Report.pdf");
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(b);
            Response.Flush();
        }
        else if (filetype == ".jpeg" || filetype == ".jpg")
        {
            Response.Clear();
            Response.ContentType = "image/jpeg";
            Response.AddHeader("Content-Disposition", "inline; filename=Report.jpeg");
            Response.ContentType = "image/jpeg";
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(b);
            Response.Flush();
        }
        else if (filetype == ".png")
        {

            Response.Clear();
            Response.ContentType = "image/png";
            Response.AddHeader("Content-Disposition", "inline; filename=Report.png");
            Response.ContentType = "image/png";
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(b);
            Response.Flush();
        }
    }
}