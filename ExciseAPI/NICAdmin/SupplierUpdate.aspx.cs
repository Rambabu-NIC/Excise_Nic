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
    public partial class SupplierUpdate : System.Web.UI.Page
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
            if (Session["Role"] != null && Session["Role"].ToString() == "50" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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

                btn_Update.Visible = false;

            }
        }

        public void GetTypeManFDAL()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Action = "R";
                dt1 = ObjMDL.TypeofManufacturing_IUR(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlManufactureType, dt1, "Type_Man_Nm", "Type_Man_Cd", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindDistrict()
        {
            try
            {

                objBE.Statecode = "36";
                DataTable dt1 = new DataTable();
                objBE.Action = "R";
                dt1 = ObjMDL.GetDistDL(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlDist, dt1, "DistName", "DistCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        public void BindMandal()
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.Statecode = "36";
                objBE.DistCode = ddlDist.SelectedValue;
                objBE.Action = "R";
                dt1 = ObjMDL.GetmandalsDAL(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlMandal, dt1, "MandName", "MandCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        public void BindVillage()
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.Statecode = "36";
                objBE.DistCode = ddlDist.SelectedValue;
                objBE.MandCode = ddlMandal.SelectedValue;
                objBE.Action = "R";
                dt1 = ObjMDL.GetvillDAL(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlVillage, dt1, "VillName", "VillCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        public void BindData()
        {
            try
            {
                objBE = new Supplier_BE();
                DataTable dt1 = new DataTable();

                objBE.SupplierCode = txtSupplier.Text.ToString();

                dt1 = objDL.SupplierDtls(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    divRetailer.Visible = true;
                    txtSupplierCode.Text = dt1.Rows[0]["Supplier_Code"].ToString();

                    txtSupplierName.Text = dt1.Rows[0]["Supplier_Name"].ToString();
                    GetTypeManFDAL();
                    ddlManufactureType.SelectedValue = dt1.Rows[0]["Type_of_Manufacturing"].ToString();
                    BindDistrict();
                    ddlDist.SelectedValue = dt1.Rows[0]["Dist"].ToString();

                    BindMandal();
                    ddlMandal.SelectedValue = dt1.Rows[0]["Mandal"].ToString();
                    BindVillage();
                    ddlVillage.SelectedValue = dt1.Rows[0]["Village"].ToString();
                    txtLicenseNo.Text = dt1.Rows[0]["License_No"].ToString();

                    txtAddress.Text = dt1.Rows[0]["Address"].ToString();
                    txtMobile.Text = dt1.Rows[0]["Mobile"].ToString();

                    txtPincode.Text = dt1.Rows[0]["Pincode"].ToString();

                    bool Active = Convert.ToBoolean(dt1.Rows[0]["Active"].ToString());

                    if (Active == false)
                    {
                        ddlActive.SelectedValue = "0";
                    }
                    else
                    {
                        ddlActive.SelectedValue = "1";
                    }

                    txtSupplierCode.Text = txtSupplier.Text.ToString();
                    txtSupplierCode.ReadOnly = true;
                    btn_Update.Visible = true;
                }
                else
                {

                    divRetailer.Visible = true;
                    txtSupplierCode.Text = txtSupplier.Text.ToString();
                    txtSupplierCode.ReadOnly = true;
                }

            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("../Error.aspx");
            }
        }



        protected void BtnGet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSupplier.Text))
            {
                lblError.Text = "Please Enter Supplier Code";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            BindData();
        }



        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                objBE = new Supplier_BE();
                DataTable dt = new DataTable();

                objBE.SupplierCode = txtSupplierCode.Text.ToString();
                objBE.SupplierName = txtSupplierName.Text.ToString();
                objBE.Type_of_Manu = ddlManufactureType.SelectedValue;
                objBE.DistCode = ddlDist.SelectedValue;
                objBE.MandCode = ddlMandal.SelectedValue;
                objBE.VillCode = ddlVillage.SelectedValue;
                objBE.Address = txtAddress.Text;
                objBE.MobNo = txtMobile.Text;
                objBE.Pincode = txtPincode.Text;
                objBE.IsActive =Convert.ToInt32 (ddlActive.SelectedValue);

                bool result = objDL.SupplierUpdate(objBE, ConnKey);
                if (result)
                {
                    objCommon.ShowAlertMessage("Updated Successfully");
                    txtSupplier.Text = "";
                    btn_Update.Visible = false;
                    divRetailer.Visible = false;
                    Clear();
                    return;
                   
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");
                    btn_Update.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("../Error.aspx");
            }
        }

        public void Clear()
        {
            txtSupplier.Text = "";
            txtSupplierCode.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            txtPincode.Text = "";
            txtSupplierName.Text = ""; 
           
        }
        protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMandal();
            
        }

        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVillage();
        }
    }
}