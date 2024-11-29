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

namespace ExciseAPI.NICAdmin
{
    public partial class ShamshabadReport : System.Web.UI.Page
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


                //lblUSer.Text = Session["UsrName"].ToString();
                BindExciseDistrict();
            }
        }

        protected void ddlExDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlExDist.SelectedValue) && int.Parse(ddlExDist.SelectedValue) != 0)
            {
                int stationcode = int.Parse(ddlExDist.SelectedValue.ToString());
                BindExciseStation(stationcode);


            }
            else
            {

                Div3.Visible = false;
                //Div3.Visible = false;

            }
        }

        protected void BindExciseDistrict()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.DistCode = "30";
                objBE.ExDistCode = "03";
                objBE.Action = "ExDist";

                dt = objDL.ShamshabadReport(objBE, ConnKey);

                if (dt.Rows.Count > 0)
                {
                    objCommon.BindDropDownLists(ddlExDist, dt, "ExDist", "ExDist_Cd", "0");


                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void BindExciseStation(int stationcode)
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Action = "ST";
                objBE.ExStation = stationcode.ToString();
                objBE.DistCode = ddlExDist.SelectedValue;
                dt = objDL.ExciseMandal(objBE, ConnKey);

                if (dt.Rows.Count > 0)
                {
                    objCommon.BindDropDownLists_WithAll_0_Option_Last(ddlExStation, dt, "ExStation", "ExStationCode", "99");


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
        protected void btnGet_Click(object sender, EventArgs e)
        {

            Div3.Visible = true;
            BindGrid();

        }
        public void BindGrid()
        {
            try
            {
                if (validate())
                {
                    DataTable dt = new DataTable();
                    objBE.DistCode = "30";
                    objBE.ExDistCode = ddlExDist.SelectedValue;
                    //objBE.MandCode = ddlExMnd.SelectedValue;
                    if (!string.IsNullOrEmpty(ddlExStation.SelectedValue))
                    {
                        objBE.ExStation = ddlExStation.SelectedValue;
                    }




                    objBE.Action = "SHD";
                    dt = objDL.ShamshabadReport(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        Div3.Visible = true;
                        GvRptDtls.Visible = true;
                        GvRptDtls.DataSource = dt;
                        GvRptDtls.DataBind();
                        dt.Dispose();
                    }
                }
                //else
                //{
                //    Div2.Visible = false;
                //}
                //objCommon.BindDropDownLists(ddlLicenceFee, dt1, "Fee", "Payment_Type", "0");
            }

            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public bool validate()
        {
            if (ddlExDist.SelectedIndex == 0)
            {

                objCommon.ShowAlertMessage("Please Select Excise District");
                ddlExDist.Focus();
                return false;
            }
            if (ddlExStation.SelectedIndex == 0)
            {

                objCommon.ShowAlertMessage("Please Select Excise Station");
                ddlExStation.Focus();
                return false;
            }

            return true;
        }
    }
}