using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;

namespace ExciseAPI.DPEO_Admin
{
    public partial class ExciseDPEORpt : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        protected void Page_Load(object sender, EventArgs e)
        {

            
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "4" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                //lblUSer.Text = Session["UsrName"].ToString();
                // BindTypeofManf();
                // pannelOK.Visible = false;
                Viewdata();
                //random();


            }
        }

        //public void random()
        //{
        //    try
        //    {
        //        string strString = "abcdefghijklmnpqrstuvwxyzABCDQEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //        string num = "";
        //        Random rm = new Random();
        //        for (int i = 0; i < 16; i++)
        //        {
        //            int randomcharindex = rm.Next(0, strString.Length);
        //            char randomchar = strString[randomcharindex];
        //            num += Convert.ToString(randomchar);
        //        }
        //        hf.Value = num;
        //        Session["ASPFIXATION2"] = num;
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}
        //public void check()
        //{
        //    try
        //    {
        //        string cookie_value = null;
        //        string session_value = null;

        //        cookie_value = hf.Value;
        //        session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
        //        if (cookie_value != session_value)
        //        {
        //            System.Web.HttpContext.Current.Session.Abandon();
        //            HttpContext.Current.Response.Buffer = false;
        //            HttpContext.Current.Response.Redirect("~/Error.aspx");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Redirect("~/Error.aspx", false);
        //    }
        //}
        protected void GvRpt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                GvRpt.PageIndex = e.NewPageIndex;
                Viewdata();
                //if (Session["dt1"] != null)
                //{
                //    DataTable dt = new DataTable();
                //    dt = (DataTable)Session["dt1"];
                //    Viewdata();
                //    GvHOA.DataSource = dt;
                //    GvHOA.DataBind();
                //     dt.Dispose();
                //    decimal net = 0;
                //    decimal total = dt.AsEnumerable().Where(row => decimal.TryParse(row["Amount"].ToString(), out net)).Sum(row => net > 0 ? net : 0);
                //    GvHOA.FooterRow.Cells[4].Text = "Total";
                //    GvHOA.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                //    GvHOA.FooterRow.Cells[5].Text = total.ToString("N2");
                //}
                //else
                //{
                //    this.Viewdata();
                //}
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }
        }

        protected void Viewdata()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                //objBE.dtfrom = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                //objBE.dtTo = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                objBE.Action = "DPR";
                // DataTable dt = new DataTable();
                dt = objDL.DistrictStationMapping(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    GvRpt.Visible = true;
                    GvRpt.DataSource = dt;
                    GvRpt.DataBind();
                    dt.Dispose();
                    //Button1.Visible = true;

                }
                else
                {
                    GvRpt.Visible = false;
                    //ReptReg.Visible = false;
                    //objCommon.ShowAlertMessage("No data found");
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        //protected void btn_Submit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        //objBE.dtfrom = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
        //        //objBE.dtTo = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
        //        objBE.Action = "R";
        //        DataTable dt = new DataTable();
        //        dt = objDL.GetPaymentDtls(objBE,ConnKey);
        //        if (dt.Rows.Count > 0)
        //        {
        //            Session["dt1"] = dt;

        //            GvRpt.Visible = true;
        //            GvRpt.DataSource = dt;
        //            GvRpt.DataBind();
        //            dt.Dispose();

        //        }
        //        else
        //        {
        //            GvRpt.Visible = false;
        //            //ReptReg.Visible = false;
        //            objCommon.ShowAlertMessage("No data found");
        //        }
        //    }

        //    catch
        //    {

        //    }
        //}
    }

}