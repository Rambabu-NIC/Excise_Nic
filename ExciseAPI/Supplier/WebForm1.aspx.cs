using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using Excise_BE;
using Excise_DAL;
using System.Text;
using System.Net;
using System.IO;

namespace ExciseAPI.Supplier
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
        protected void Page_Load(object sender, EventArgs e)
        {


            if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
                Response.Redirect("~/Error.aspx");
            }
            else
            {
                string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
                string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
                int len = http_hos.Length;
                if (http_ref.IndexOf(http_hos, 0) < 0)
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "3" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Error.aspx");
            }

            if (!IsPostBack)
            {

                



                //try
                //{
                //    string[] keys = Request.Form.AllKeys;
                //    string result = "";
                //    if (keys.Length > 0)
                //    {
                //        t1.Visible = true;
                //        //for (int i = 0; i < keys.Length; i++)
                //        //{
                //        //    Response.Write("i==" + i + "=" + "///" + keys[i] + ": " + Request.Form[keys[i]] + "<br>");
                //        //    result += keys[i] + ": " + Request.Form[keys[i]] + "<br>";
                //        //}
                //        try
                //        {
                //            lblbankStatus.Text = Request.Form[keys[2]].ToString();
                //            lblchno.Text = Request.Form[keys[3]].ToString();
                //            lbldepttransid.Text = Request.Form[keys[4]].ToString();
                //            lbltrydate.Text = Request.Form[keys[5]].ToString();
                //            lblbanktransid.Text = Request.Form[keys[6]].ToString();
                //            lblbankname.Text = Request.Form[keys[7]].ToString();
                //            lblbankdate.Text = Request.Form[keys[8]].ToString();
                //            lblhoa.Text = Request.Form[keys[9]].ToString();
                //            //lblrnm.Text = Request.Form[keys[10]].ToString();
                //            lblddocode.Text = Request.Form[keys[11]].ToString();
                //            lblAmt.Text = Request.Form[keys[12]].ToString();
                //            string flag = Request.Form[keys[13]].ToString();
                //        }
                //        catch
                //        {
                //        }


                //        objBE.TreasuryDate = DateTime.Parse(lbltrydate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                //        objBE.BankStatus = lblbankStatus.Text.Trim();
                //        objBE.ChallanNumber = lblchno.Text.Trim();
                //        objBE.DeptTransid = lbldepttransid.Text.Trim();
                //        objBE.BankTransid = lblbanktransid.Text.Trim();
                //        objBE.BankCode = lblbankname.Text.Trim();
                //        objBE.BankDate = DateTime.Parse(lblbankdate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                //        objBE.IpAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                //        objBE.Action = "UA";
                //        DataTable dt = new DataTable();
                //        dt = objDL.GetPaymentUpdateDtls(objBE,ConnKey);               


                //        string StrContent = Session["UsrName"].ToString() + "|" + "|" + DateTime.Parse(lbltrydate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date + "|" + lblbankStatus.Text.Trim() + "|" + lblchno.Text.Trim() + "|" + lbldepttransid.Text.Trim() + "|" + lblbanktransid.Text.Trim() + "|" + DateTime.Parse(lblbankdate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date + "\n";

                //    }
                //    else
                //        t1.Visible = false;
                //}
                //catch
                //{
                //}




            }
        }
 









  

    }
}