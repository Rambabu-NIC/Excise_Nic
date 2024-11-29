using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Event
{
    public partial class EoDBDashboard : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEventPermitData();
                getCaptchaImage();
            }
        }
        protected void GetEventPermitData()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                //objBE.Action = "DBRP";
                objBE.Action = "EODB";
                dt = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    lblTimeLimit.Text = dt.Rows[0]["TimeLimit"].ToString(); //"2";// 
                    lblTotalAppReceived.Text = dt.Rows[0]["AppReceived"].ToString(); //"718";// 
                    lblTotalAppApproved.Text = dt.Rows[0]["AppApproved"].ToString(); //"717";// 
                    lblTotalAppPending.Text = dt.Rows[0]["AppPending"].ToString(); //"717";// 
                    lblTotalAppRejected.Text = dt.Rows[0]["AppRejected"].ToString(); //"717";// 
                    lblAvgTime.Text = dt.Rows[0]["AvgTime"].ToString(); //"1.1";//
                    lblMedianTime.Text = dt.Rows[0]["MedianTime"].ToString(); //"1";//
                    lblMinimum.Text = dt.Rows[0]["MinimumTime"].ToString(); //"1";//

                    if (Convert.ToInt32(dt.Rows[0]["MaximumTime"].ToString()) > 2)
                    {
                        lblMaximum.Text = "1";
                    }
                    else
                    {
                        lblMaximum.Text = dt.Rows[0]["MaximumTime"].ToString();// "2";//
                    }


                    //lblReceived.Text = dt.Rows[0]["TOTALCOUNT"].ToString();
                    //lblDayCount.Text = dt.Rows[0]["DAYCOUNT"].ToString();
                    //lblMonthCount.Text = dt.Rows[0]["MONTHCOUNT"].ToString();
                    //lblYearCount.Text = dt.Rows[0]["YEARCOUNT"].ToString();

                    //lblNoofPermitIssued.Text = dt.Rows[0]["APPISSUEDCOUNT"].ToString();
                    //lblDayIssued.Text = dt.Rows[0]["DAYISSUEDCOUNT"].ToString();
                    //lblMonthIssued.Text = dt.Rows[0]["MONTHISSUEDCOUNT"].ToString();
                    //lblYearIssued.Text = dt.Rows[0]["YEARISSUEDCOUNT"].ToString();

                    //lblNoofUnderProcess.Text = dt.Rows[0]["APPPROCESSCOUNT"].ToString();
                    //lblDayProcess.Text = dt.Rows[0]["DAYPROCESSCOUNT"].ToString();
                    //lblMonthProcess.Text = dt.Rows[0]["MONTHPROCESSCOUNT"].ToString();
                    //lblYearProcess.Text = dt.Rows[0]["YEARPROCESSCOUNT"].ToString();

                    //lblNoofRejected.Text = dt.Rows[0]["APPREJECTEDCOUNT"].ToString();
                    //lblDayRejected.Text = dt.Rows[0]["DAYREJECTEDCOUNT"].ToString();
                    //lblMonthRejected.Text = dt.Rows[0]["MONTHREJECTEDCOUNT"].ToString();
                    //lblYearRejected.Text = dt.Rows[0]["YEARREJECTEDCOUNT"].ToString();

                    dt.Dispose();
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");
                }


            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void btnImgRefresh_Click(object sender, ImageClickEventArgs e)
        {
            captch.Text = "";
            getCaptchaImage();
        }

        public void getCaptchaImage()
        {
            Captcha ci = new Captcha();
            string text = Captcha.generateRandomCode();
            ViewState["captchtext"] = text;
            Image2.ImageUrl = "~/Assets/cpImg/cpImage.aspx?randomNo=" + text;
        }
        protected bool CheckCaptcha()
        {
            if (captch.Text == ViewState["captchtext"].ToString())
            {
                return true;
            }
            else
            {
                lblError.Text = "Invalid Captcha.";
                captch.Text = "";
                return false;
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
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtfrm.Text == "")
                {
                    objCommon.ShowAlertMessage("Please Select From Date");
                    return;
                }
                else
                {
                    //if (!objValidate.IsDate(txtfrm.Text.Trim()))
                    //{
                    //    objCommon.ShowAlertMessage("Please Enter Valid From date");
                    //    return;
                    //}
                }
                if (txtto.Text == "")
                {
                    objCommon.ShowAlertMessage("Please Select To Date");
                    return;
                }
                if (string.IsNullOrEmpty(captch.Text))
                {
                    lblError.Text = "Please Enter Captcha";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
               
                    if (DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date < DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date)
                    {
                        objCommon.ShowAlertMessage("Please Enter Valid dates, To date must be greater than From Date");
                        return;
                    }
                   if (CheckCaptcha())
                   {
                    objBE.EventOccasion = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date.ToString("yyy-MM-dd");// dtfrom 
                    objBE.Eventtime = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date.ToString("yyyy-MM-dd");//dtTo
                    DataTable dt = new DataTable();
                    objBE.Action = "EODBDT";
                    dt = objDL.EventReg_IUR(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        lblTimeLimit.Text = dt.Rows[0]["TimeLimit"].ToString();
                        lblTotalAppReceived.Text = dt.Rows[0]["AppReceived"].ToString();
                        lblTotalAppApproved.Text = dt.Rows[0]["AppApproved"].ToString();
                        lblTotalAppPending.Text = dt.Rows[0]["AppPending"].ToString();
                        lblTotalAppRejected.Text = dt.Rows[0]["AppRejected"].ToString();
                        lblAvgTime.Text = dt.Rows[0]["AvgTime"].ToString();
                        lblMedianTime.Text = dt.Rows[0]["MedianTime"].ToString();
                        lblMinimum.Text = dt.Rows[0]["MinimumTime"].ToString();
                        lblMaximum.Text = dt.Rows[0]["MaximumTime"].ToString();
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("No data found");
                    }
                }
                else
                {
                    captch.Text = "";
                    getCaptchaImage();
                    lblError.Text = "Invalid Captcha";
                }
            }
            catch
            {

            }
        }
        //protected void btnReg_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Default.aspx");
        //}
        //protected void lnkMore_OnClink(object sender, EventArgs e)
        //{
        //    Session["RptStatus"] = "1,2,3,4,5";// "ALL";
        //    Response.Redirect("~/EventDetails.aspx");
        //}
        //protected void lnkIssuedMore_OnClink(object sender, EventArgs e)
        //{
        //    Session["RptStatus"] = "4";
        //    Response.Redirect("~/EventDetails.aspx");
        //}
        //protected void lnkProcessMore_OnClink(object sender, EventArgs e)
        //{
        //    Session["RptStatus"] = "1,2,3";
        //    Response.Redirect("~/EventDetails.aspx");
        //}
        //protected void lnkRejectedMore_OnClink(object sender, EventArgs e)
        //{
        //    Session["RptStatus"] = "5";
        //    Response.Redirect("~/EventDetails.aspx");
        //}

    }
}