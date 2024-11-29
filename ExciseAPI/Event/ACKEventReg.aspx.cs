using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Event
{
    public partial class ACKEventReg : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
                //  Response.Redirect("~/Error.aspx");
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
            //if (Session["Role"] != null && Session["Role"].ToString() == "1" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            //{
            //    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }
            //}
            //else
            //{
            //  //  Response.Redirect("~/Error.aspx");
            //}

            if (!IsPostBack)
            {

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                // lblUSer.Text = Session["UsrName"].ToString();
                //GetTypeManFDAL();
                //BindDistrict();
                //Viewdata();
                random();
                objBE.Reg_Code = Session["RegId"].ToString();
                Viewdata();



            }

        }
        public void Viewdata()
        {
            objBE.Reg_Code = Session["RegId"].ToString();

            objBE.Action = "GI";
            DataTable dtCnt = objDL.EventReg_IUR(objBE, ConnKey);
            if (dtCnt.Rows.Count > 0)
            {

                lblInwardNo.Text = dtCnt.Rows[0]["AppReg_No"].ToString();
            }
        }
        public void random()
        {
            try
            {
                string strString = "abcdefghijklmnpqrstuvwxyzABCDQEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                string num = "";
                Random rm = new Random();
                for (int i = 0; i < 16; i++)
                {
                    int randomcharindex = rm.Next(0, strString.Length);
                    char randomchar = strString[randomcharindex];
                    num += Convert.ToString(randomchar);
                }
                hf.Value = num;
                Session["ASPFIXATION2"] = num;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
        public void check()
        {
            try
            {
                string cookie_value = null;
                string session_value = null;

                cookie_value = hf.Value;
                session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
                if (cookie_value != session_value)
                {
                    System.Web.HttpContext.Current.Session.Abandon();
                    HttpContext.Current.Response.Buffer = false;
                    HttpContext.Current.Response.Redirect("~/Error.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx", false);
            }
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            //objBE.Reg_Code = txtRegNum.Text;
            //objBE.Action = "R";
            //DataTable dt = new DataTable();
            //dt = objDL.EventReg_IUR(objBE, ConnKey);
            //if (dt.Rows.Count > 0)
            //{
            //    BtnSubmit.Visible = true;
            //    RptReg.LocalReport.DataSources.Clear();
            //    RptReg.LocalReport.DataSources.Add(new ReportDataSource("DataSet1",dt));
            //    RptReg.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Report_BIMApplicantDtls.rdlc");

            //}

        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                // if (Validate())
                //{
                //    objBE.Reg_Code = txtRegNum.Text;

                //  //  objBE.Status = "1";

                //    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                //    //objBE.UserName = Session["User"].ToString();
                //    objBE.Action = "S";
                //    DataTable dt = new DataTable();
                //    dt = objDL.EventReg_IUR(objBE, ConnKey);
                //    if (dt.Rows.Count > 0)
                //    {
                //        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                //        // Viewdata();
                //        RptReg.Visible = false;

                //    }
                //}

            }
            catch
            {

            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Session["RegNo"] = lblInwardNo.Text;
            Response.Redirect("../Event/UploadDoc.aspx", false);
        }
    }
}