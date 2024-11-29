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
    public partial class Retailer_ResetPassword : System.Web.UI.Page
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
            if (Session["Role"] != null && (Session["Role"].ToString() == "50" ||  Session["Role"].ToString() == "52") && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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

               



            }

        }

        protected void BtnGet_Click(object sender, EventArgs e)
        {
            divreset.Visible = false;
            try
            {
                if (string.IsNullOrEmpty(txtretailer.Text))
                {
                    lblRetailererror.Text = "Please Enter Retailer Code";
                    lblRetailererror.ForeColor = System.Drawing.Color.Red;
                    return;
                }
               
                DataTable dtt = new DataTable();
                dtt = new DataTable();
                
               
                objBE.RetailerCode = txtretailer.Text;
                dtt = objDL.GetRetailer(objBE, ConnKey);
                if (dtt.Rows.Count > 0)
                {
                    divreset.Visible = true;
                    return;
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");
                    return;
                }
            }
            catch (Exception Ex)
            {

            }

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = new DataTable();
                objBE.RetailerCode = txtretailer.Text;
                dt = objDL.R_ResetPassword(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage("Password Updated Successfully");
                    divreset.Visible = false;
                    return;
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");
                    divreset.Visible = false;
                    return;
                }
            }
            catch (Exception Ex)
            {

            }
        }
    }
}