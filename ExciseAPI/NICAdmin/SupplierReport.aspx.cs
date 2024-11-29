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
using System.Globalization;

namespace ExciseAPI.NICAdmin
{
    public partial class SupplierReport : BasePage
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
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "9" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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


                //lblUSer.Text = Session["UsrName"].ToString();

                GetManufacturData();


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

        protected void GetManufacturData()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
               
                dt = objDL.Get_TypeofManfacturer(objBE, ConnKey);

                if (dt.Rows.Count > 0)
                {
                    objCommon.BindDropDownLists_WithAll_0_Option_Last(ddlManf, dt, "Type_Man_Nm", "Type_Man_Cd", "99");

                    //objCommon.BindDropDownLists(ddlExStation, dt, "Station", "DistCode", "0");
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        


        protected void GetSupplierData()
        {

            GvRptDtls.DataSource = null;
            GvRptDtls.DataBind();

            DIVEXS.Visible = false;
            try
            {


                DataTable dt = new DataTable();
                objBE.ManufCd = ddlManf.SelectedValue;
                objBE.SupplierName = ddlManufacturer.SelectedItem.Text;
                String FromDate = null;
                String ToDate = null;
                if (!string.IsNullOrEmpty(txtfrm.Text.ToString()) && !string.IsNullOrEmpty(txtto.Text.ToString()))
                {
                    FromDate = txtfrm.Text.ToString();
                    ToDate = txtto.Text.ToString();
                    objBE.FDate = FromDate;
                    objBE.TDate= ToDate;
                }
                else
                {
                    objBE.FDate = FromDate;
                    objBE.TDate = ToDate;
                }
                dt = objDL.Get_Supplier_Report(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    DIVEXS.Visible = true;
                    //GvRptDtls.Visible = true;
                    GvRptDtls.DataSource = dt;
                    GvRptDtls.DataBind();
                    //btnSupplierImageExportToPdf.Visible = true;
                    btnSupplierExportToExcel.Visible = true;
                    dt.Dispose();
                }
                else
                {
                    DIVEXS.Visible = false;
                    objCommon.ShowAlertMessage("No Data Found");
                }



            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //objCommon.ShowAlertMessage(ex.ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        protected void SupplierDetails()
        {

           
                DataTable dtddlManufacturer = new DataTable();
                dtddlManufacturer = new DataTable();
                try
                {

                objBE.ManufCd = ddlManf.SelectedValue;
                // objBE.SupplierName = ddlManufacturer.SelectedValue;
                dtddlManufacturer = objDL.Get_SupplierDetails(objBE, ConnKey);

                    if (dtddlManufacturer.Rows.Count > 0)
                    {
                        objCommon.BindDropDownLists_WithAll_0_Option_Last(ddlManufacturer, dtddlManufacturer, "Manuf_Name", "Manuf_Code", "99");

                        //objCommon.BindDropDownLists(ddlExStation, dt, "Station", "DistCode", "0");
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                    Response.Redirect("~/Error.aspx");
                }
            }
            
        protected void GvRptDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                GvRptDtls.PageIndex = e.NewPageIndex;
                GetSupplierData();



            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }

            //GvRptDtls.DataSource = null;
            //GvRptDtls.DataBind();

            //GvRptDtls.Visible = false;
            //try
            //{


            //    DataTable dt = new DataTable();


            //    objBE.Action = "Supplier_DT";
            //    objBE.BdrEast = "TMPC_DT_IDT";





            //    dt = objDL.EventReg_IUR(objBE, ConnKey);
            //    if (dt.Rows.Count > 0)
            //    {
            //        DIVEXS.Visible = true;
            //        GvRptDtls.Visible = true;
            //        GvRptDtls.DataSource = dt;
            //        GvRptDtls.DataBind();
            //        dt.Dispose();

            //        GvRptDtls.PageIndex = e.NewPageIndex;
            //        GvRptDtls.DataBind();


            //    }
            //    else
            //    {
            //        GvRptDtls.Visible = false;
            //    }





            //    //if (validateDates())
            //    //{
            //    //    hfDate.Value = "1";
            //    //    //Session["DateHidden"] = "1";
            //    //    dateGrid.Text = "1";
            //    //    objBE.dtfrom = DateTime.Parse(txtfrm.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            //    //    objBE.dtTo = DateTime.Parse(txtto.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            //    //    objBE.Action = "TMPC";
            //    //    DataTable dt = new DataTable();
            //    //    dt = objDL.GetPaymentDtls(objBE, ConnKey);
            //    //    if (dt.Rows.Count > 0)
            //    //    {
            //    //        //GvRpt.Visible = true;
            //    //        //GvRpt.DataSource = dt;
            //    //        //GvRpt.DataBind();
            //    //        dt.Dispose();
            //    //    }
            //    //    else
            //    //    {
            //    //       // GvRpt.Visible = false;
            //    //    }
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            //    //objCommon.ShowAlertMessage(ex.ToString());
            //    Response.Redirect("~/Error.aspx");
            //}
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            GetSupplierData();
        }

        protected void ddlManf_SelectedIndexChanged(object sender, EventArgs e)
        {
            SupplierDetails();
        }

        protected void btnSupplierImageExportToPdf_Click(object sender, ImageClickEventArgs e)
        {
            GridView gridviewid = GvRptDtls;
            gridviewid.AllowPaging = false;
            string GenerateFileName = "Supplier's Report" + ".Pdf";
            System.Web.UI.HtmlControls.HtmlGenericControl div = divDetails;
            ExportGridToPDFWithGeneratedDate(GenerateFileName, div);
        }

        protected void btnSupplierExportToExcel_Click(object sender, ImageClickEventArgs e)
        {
            string GenerateFileName = "Supplier's Report" + ".xls";
            GridView gridviewid = GvRptDtls;
            gridviewid.AllowPaging = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = divDetails;
            ExportGridToExcelWithLabel(GenerateFileName, div);
        }
    }
}