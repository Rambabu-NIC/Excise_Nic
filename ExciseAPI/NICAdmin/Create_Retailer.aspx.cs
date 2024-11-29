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
    public partial class Create_Retailer : System.Web.UI.Page
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
            if (Session["Role"] != null && (Session["Role"].ToString() == "50" || Session["Role"].ToString() == "52") && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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

                BindRevDistrict();
                BindRetailerType();
                BindDepot();



            }

        }
        public void BindSlab()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.RetailerType = ddlRType.SelectedValue;
                objBE.Amount = Convert.ToDecimal(txtExTax.Text);
                dt1 = objDL.GetSlab(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    txtSlabNo.Text = dt1.Rows[0]["SlabNo"].ToString();
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");
                    return;

                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        public void BindData()
        {
            try
            {
                objBE = new Supplier_BE();
                DataTable dt1 = new DataTable();

                objBE.RetailerCode = txtretailer.Text.ToString();//Session["AppRegNo_SHO"].ToString();// txtAppReg_NO.Text; /*Session["RegId"].ToString();//"360200001423"; //*/

                dt1 = objDL.GetRetailer(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    divRetailer.Visible = true;
                    txtRetailerCode.Text = dt1.Rows[0]["Retailer_Code"].ToString();

                    txtRetailerName.Text = dt1.Rows[0]["Retailer_Name"].ToString();

                    ddlRType.SelectedValue = dt1.Rows[0]["Type_Retailer"].ToString();
                    ddlDepot.SelectedValue = dt1.Rows[0]["DEPOTCODE"].ToString();
                    BindRevDistrict();
                    ddlDist.SelectedValue = dt1.Rows[0]["RDist"].ToString();
                    BindExciseDistrict();
                    ddlExDist.SelectedValue = dt1.Rows[0]["ExDist"].ToString();
                    txtEmail.Text = dt1.Rows[0]["Email_Id"].ToString();
                    txtLicenseName.Text = dt1.Rows[0]["License_Name"].ToString();
                    txtLicenseNo.Text = dt1.Rows[0]["License_No"].ToString();
                    txtExTax.Text = dt1.Rows[0]["Excise_tax"].ToString();
                    txtSlabNo.Text = dt1.Rows[0]["SlabNo"].ToString();
                    //txtInstallment.Text = dt1.Rows[0]["Installment_Amt"].ToString();
                    txtAddress.Text = dt1.Rows[0]["Address"].ToString();
                    txtMobile.Text = dt1.Rows[0]["Mobile"].ToString();
                    txtGazette.Text = dt1.Rows[0]["Gazette_Code"].ToString();
                    txtPincode.Text = dt1.Rows[0]["Pincode"].ToString();
                    txtPan.Text = dt1.Rows[0]["Pan_Number"].ToString();
                    //ddlDDO_Code.SelectedValue = dt1.Rows[0]["DDOCode"].ToString();
                    //txtValidFrom.Text = dt1.Rows[0]["LicenseValid_From"].ToString();
                    //txtValidTo.Text = dt1.Rows[0]["LicenseValid_To"].ToString();
                    txtRetailerCode.Text = txtretailer.Text.ToString();
                    txtRetailerCode.ReadOnly = true;
                }
                else
                {

                    divRetailer.Visible = true;
                    txtRetailerCode.Text = txtretailer.Text.ToString();
                    txtRetailerCode.ReadOnly = true;
                }

            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("../Error.aspx");
            }
        }
        public void BindDepot()
        {
            try
            {

                DataTable dt1 = new DataTable();
                //objBE.Type_of_Manu = Session["Type_Retailer"].ToString();
                dt1 = objDL.GetDepot(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlDepot, dt1, "DepotName", "DeptCode", "0");
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindRetailerType()
        {
            try
            {

                DataTable dt1 = new DataTable();
                //objBE.Type_of_Manu = Session["Type_Retailer"].ToString();
                dt1 = objDL.GetRetailerType(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlRType, dt1, "Retailer_Type_Description", "Retailer_Type_Code", "0");
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        public void BindRevDistrict()
        {
            try
            {

                objBE.Statecode = "36";
                DataTable dt1 = new DataTable();
                objBE.Action = "RD";
                dt1 = ObjMDL.CommonMasters(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlDist, dt1, "DistName", "DistCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        public void BindExciseDistrict()
        {
            try
            {

                //objBE.Statecode = "36";
                objBE.DistCode = ddlDist.SelectedValue;
                DataTable dt1 = new DataTable();

                dt1 = objDL.GetExDistrict(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlExDist, dt1, "ExDist", "ExDist_Cd", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindExciseDistrict();

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRetailerName.Text))
                {
                    lblError.Text = "Please Enter Retailer Name";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(ddlRType.SelectedValue) || ddlRType.SelectedValue == "0")
                {
                    lblError.Text = "Please Select Retailer Type";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(ddlDepot.SelectedValue) || ddlDepot.SelectedValue == "0")
                {
                    lblError.Text = "Please Select Depot";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(ddlDist.SelectedValue) || ddlDist.SelectedValue == "0")
                {
                    lblError.Text = "Please Select District";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(ddlExDist.SelectedValue) || ddlExDist.SelectedValue == "0")
                {
                    lblError.Text = "Please Select Excise District";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtLicenseName.Text))
                {
                    lblError.Text = "Please Enter License Name";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtLicenseNo.Text))
                {
                    lblError.Text = "Please Enter License No";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtExTax.Text))
                {
                    lblError.Text = "Please Enter Excise Tax";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtAddress.Text))
                {
                    lblError.Text = "Please Enter Address";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    lblError.Text = "Please Enter Email";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtMobile.Text))
                {
                    lblError.Text = "Please Enter Mobile";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtMobile.Text))
                {
                    lblError.Text = "Please Enter Mobile";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtGazette.Text))
                {
                    lblError.Text = "Please Enter Gazette Code";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtPincode.Text))
                {
                    lblError.Text = "Please Enter PinCode";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtPan.Text))
                {
                    lblError.Text = "Please Enter PAN Number";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                DataTable dtt = new DataTable();
                dtt = new DataTable();
                objBE.Retailer_Code = txtRetailerCode.Text;
                objBE.RetailerName = txtRetailerName.Text;
                objBE.RetailerType = ddlRType.SelectedValue;
                objBE.DepotCode = ddlDepot.SelectedValue;
                objBE.RDist = ddlDist.SelectedValue;
                objBE.ExDist = ddlExDist.SelectedValue;
                objBE.LicenseName = txtLicenseName.Text;
                objBE.LicenseNO = txtLicenseNo.Text;
                objBE.ExTax = txtExTax.Text;
                objBE.slabNo = txtSlabNo.Text;
                //objBE.Installment = txtInstallment.Text;
                objBE.Address = txtAddress.Text;
                objBE.Email = txtEmail.Text;
                objBE.MobNo = txtMobile.Text;
                objBE.GazetteCode = txtGazette.Text;
                objBE.Pincode = txtPincode.Text;
                objBE.PANNo = txtPan.Text;
                //objBE.DDoCode = ddlDDO_Code.SelectedValue;
                //objBE.from = txtValidFrom.Text;
                //objBE.To = txtValidTo.Text;
                objBE.CreatedBy = Session["UsrName"].ToString();
                objBE.IsActive = Convert.ToInt32(ddlStatus.SelectedValue);
                bool result = objDL.CreateRetailer(objBE, ConnKey);
                if (result)
                {
                    objCommon.ShowAlertMessage("Submitted Successfully");
                    txtretailer.Text = "";
                    divRetailer.Visible = false;
                    Clear();
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

        public void Clear()
        {
            txtRetailerCode.Text = "";
            txtRetailerName.Text = "";
            txtLicenseName.Text = "";
            txtLicenseNo.Text = "";
            txtExTax.Text = "";
            txtSlabNo.Text = ""; txtAddress.Text = ""; txtEmail.Text = "";
            txtMobile.Text = "";
            txtGazette.Text = "";
            txtPincode.Text = "";
            txtPan.Text = "";
            //ddlRType.SelectedValue = "0";
            //ddlDepot.SelectedValue = "0";
            //ddlDist.SelectedValue = "0";
            //ddlExDist.SelectedValue = "0";
        }
        protected void txtExTax_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtExTax.Text))
            {
                BindSlab();
            }
            else
            {
                objCommon.ShowAlertMessage("No Data Found");
            }
        }

        protected void BtnGet_Click(object sender, EventArgs e)
        {
            Clear();
            if (string.IsNullOrEmpty(txtretailer.Text))
            {
                lblRetailererror.Text = "Please Enter Retailer Code";
                lblRetailererror.ForeColor = System.Drawing.Color.Red;
                return;
            }
            BindData();
        }

        //protected void txtretailer_TextChanged(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(txtretailer.Text))
        //    {
        //        lblRetailererror.Text = "Please Enter Retailer Code";
        //        lblRetailererror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    else
        //    {
        //        txtRetailerCode.Text = txtretailer.Text.ToString();
        //        txtRetailerCode.ReadOnly = true;
        //    }
        //}
    }
}
