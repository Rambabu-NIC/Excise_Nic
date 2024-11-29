using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Excise_BE;
using Excise_DAL;

namespace ExciseAPI.Supplier
{
    public partial class MST_Retailers : System.Web.UI.Page
    {
        Supplier_BE objSupBE = new Supplier_BE();
        Master_BE objBE = new Master_BE();
        // SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();

        //Retailer_BE objRBE = new Retailer_BE();
        //Retailer_DAL objRDL = new Retailer_DAL();

        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            //{
            //    Response.Redirect("~/Error.aspx");
            //}
            //else
            //{
            //    string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            //    string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            //    int len = http_hos.Length;
            //    if (http_ref.IndexOf(http_hos, 0) < 0)
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }
            //}
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
            //    Response.Redirect("~/Error.aspx");
            //}

            if (!IsPostBack)
            {

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                // lblUSer.Text = Session["UsrName"].ToString();

                Viewdata();
                //random();
                BindDistrict();

                BindRetailerType();
                BindPrimaryDepotCode();
            }
        }
        public void BindDistrict()
        {
            try
            {
                DataTable dt = new DataTable();
                objSupBE = new Supplier_BE();
                objBE.Statecode = "36";
                objSupBE.DistCode = ddlDist.SelectedValue;
                DataTable dt1 = new DataTable();
                objBE.Action = "R";
                dt1 = ObjMDL.GetDistDL(objSupBE, ConnKey);
                objCommon.BindDropDownLists(ddlDist, dt1, "DistName", "DistCode", "0");

            }
            catch (Exception ex)
            {
                // ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                // Response.Redirect("~/Error.aspx");
            }
        }
        public void BindRetailerType()
        {
            try
            {
                DataTable dt1 = new DataTable();
                // objBE.Statecode = "36";
                //objRBE.Retailer_Type = ddlRetailerType.SelectedValue;
                //objRBE.Action = "R";
                //dt1 = objRDL.RetailerTypeIUDR(objRBE, ConnKey);
                objBE.Action = "RT";
                dt1 = ObjMDL.Retailers(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlRetailerType, dt1, "Retailer_Type_Short_Name", "Retailer_Type_Code", "0");

            }
            catch (Exception ex)
            {
                //  ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                // Response.Redirect("~/Error.aspx");
            }
        }
        public void BindPrimaryDepotCode()
        {
            try
            {
                DataTable dt1 = new DataTable();

                //objRBE.Retailer_Type = ddlRetailerType.SelectedValue;
                //DataTable dt1 = new DataTable();

                //objRBE.Action = "R";
                //dt1 = objRDL.RetailerTypeIUDR(objRBE, ConnKey);
                objBE.Action = "DM";// "RM";
                dt1 = ObjMDL.Retailers(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlPrimary, dt1, "DEPOTNAME", "DEPOTCODE", "0");
                objCommon.BindDropDownLists(ddlSecondary, dt1, "DEPOTNAME", "DEPOTCODE", "0");
                //objCommon.BindDropDownLists(ddlPrimary, dt1, "Primary_Depot_Code", "Secondary_Depot_Code", "0");

            }
            catch (Exception ex)
            {
                //  ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                // Response.Redirect("~/Error.aspx");
            }
        }
        public void BindMandal()
        {
            try
            {
                objSupBE = new Supplier_BE();
                DataTable dt = new DataTable();
                objBE.Statecode = "36";
                objBE.DistCode = ddlDist.SelectedValue;
                objBE.Action = "S";
                dt = ObjMDL.GetDistDL(objSupBE, ConnKey);
                objCommon.BindDropDownLists(ddlMandal, dt, "MandName", "MandCode", "0");

            }
            catch (Exception ex)
            {
                //   ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                // Response.Redirect("~/Error.aspx");
            }
        }
        public void BindVillage()
        {
            try
            {
                DataTable dt = new DataTable();
                objBE.Statecode = "36";
                objBE.DistCode = ddlDist.SelectedValue;
                objBE.MandCode = ddlMandal.SelectedValue;
                objBE.Action = "M";
                dt = ObjMDL.GetDistDL(objSupBE, ConnKey);
                objCommon.BindDropDownLists(ddlVillage, dt, "VillName", "VillCode", "0");

            }
            catch (Exception ex)
            {
                //  ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                // Response.Redirect("~/Error.aspx");
            }
        }
        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVillage();

        }
        protected bool Validate()
        {


            if (txtRetailerName.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Retailer Name ");
                txtRetailerName.Focus();
                return false;
            }
            if (ddlRetailerType.Text == "")
            {
                objCommon.ShowAlertMessage("Enter RetailerType");
                ddlRetailerType.Focus();
                return false;
            }
            if (txtLicenseName.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Licensee Name");
                txtLicenseName.Focus();
                return false;
            }
            if (txtLicenseGazettenumber.Text == "")
            {
                objCommon.ShowAlertMessage("Enter LicenseGazette number");
                txtLicenseGazettenumber.Focus();
                return false;
            }
            if (ddlDist.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Select District");
                ddlDist.Focus();
                return false;
            }
            if (ddlMandal.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Select Mandal");
                ddlMandal.Focus();
                return false;
            }
            if (ddlVillage.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Select Village");
                ddlVillage.Focus();
                return false;
            }
            if (txtAddress.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Address");
                txtAddress.Focus();
                return false;
            }
            if (ddlPrimary.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Enter PrimaryDepotCode");
                ddlPrimary.Focus();
                return false;
            }
            if (rblPrimary.Text == "")
            {
                objCommon.ShowAlertMessage("Choose Yes or No");
                rblPrimary.Focus();
                return false;
            }
            if (ddlSecondary.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Enter Secondary DepotCode");
                ddlSecondary.Focus();
                return false;
            }
            if (rblSecondary.Text == "")
            {
                objCommon.ShowAlertMessage("Choose Yes or No");
                rblSecondary.Focus();
                return false;
            }
            if (txtEmailID.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Mail Id");
                txtEmailID.Focus();
                return false;
            }
            if (txtMobileNumber.Text == "")
            {
                objCommon.ShowAlertMessage("Enter MobileNumber");
                txtMobileNumber.Focus();
                return false;
            }


            return true;


        }

        //protected void GvDF_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {

        //        if (e.CommandName == "edt")
        //        {
        //            DataTable dt = new DataTable();

        //            GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        //            txtRetailerName.Text = ((Label)(gRow.FindControl("lblRetailerName"))).Text;
        //            txtRetailerType.Text = ((Label)(gRow.FindControl("lblRetailer_Type"))).Text;
        //            txtLicenseName.Text = ((Label)(gRow.FindControl("lblLicense_Name"))).Text;
        //            txtLicenseGazettenumber.Text = ((Label)(gRow.FindControl("lblLicense_Gazette_number"))).Text;
        //            txtDistrict.Text = ((Label)(gRow.FindControl("lblDistrict"))).Text;
        //            txtMandal.Text = ((Label)(gRow.FindControl("lblMandal"))).Text;
        //            txtVillage.Text = ((Label)(gRow.FindControl("lblVillage"))).Text;
        //            txtAddress.Text = ((Label)(gRow.FindControl("lbllAddress"))).Text;
        //            txtPrimaryDepotCode.Text = ((Label)(gRow.FindControl("lblPrimary_Depot_Code"))).Text;
        //            txtPrimaryDepotActiveYN.Text = ((Label)(gRow.FindControl("lblPrimary_Depot_Active_YN"))).Text;
        //            txtSecondaryDepotCode.Text = ((Label)(gRow.FindControl("lblSecondary_Depot_Code"))).Text;
        //            txtSecondaryDepotActiveYN.Text = ((Label)(gRow.FindControl("lblSecondary_Depot_Active_YN"))).Text;
        //            txtEmaiID.Text = ((Label)(gRow.FindControl("lblEmaiID"))).Text;
        //            txtMobileNumber.Text = ((Label)(gRow.FindControl("lblMobileNumber"))).Text;

        //            ViewState["Id"] = ((Label)(gRow.FindControl("lblID"))).Text;
        //            // Label labDFCode = ((Label)(gRow.FindControl("lblDF_Code"))).Text;
        //            // //GoDownId.Value = ((Label)(gRow.FindControl("lblSuppCode"))).Text;

        //            btn_Save.Visible = false;
        //            btn_Update.Visible = true;


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}

        ////protected void GvDF_PageIndexChanging(object sender, GridViewPageEventArgs e)
        ////{
        ////    try
        ////    {

        ////        GvDF.PageIndex = e.NewPageIndex;
        ////        Viewdata();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        ////        objCommon.ShowAlertMessage(ex.ToString());
        ////    }
        ////}


        protected void Viewdata()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                // objBE.ApplicantId = Session["ApplicantId"].ToString();
                // objRegBE.System = Session["System"].ToString();
                objBE.Action = "R";
                // dt = ObjMDL.TypeofManufacturing_IUR(objBE, Session["ConnKey"].ToString());
                dt = ObjMDL.Retailers(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    GvDF.Visible = true;
                    GvDF.DataSource = dt;
                    GvDF.DataBind();
                    dt.Dispose();



                }
                else
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    //objCommon.ShowAlertMessage("No Data Found For This ");
                    GvDF.Visible = false;

                }

            }
            catch (Exception ex)
            {
                // ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                // Response.Redirect("~/Error.aspx");
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
        //        // Response.Redirect("~/Error.aspx");
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
        //        // Response.Redirect("~/Error.aspx", false);
        //    }
        //}


        protected void btn_Save_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                if (Validate())
                {
                    objBE = new Master_BE();
                    objBE.RetailerName = txtRetailerName.Text;
                    objBE.Retailer_Type = ddlRetailerType.SelectedValue;
                    objBE.License_Name = txtLicenseName.Text;
                    objBE.License_Gazette_number = txtLicenseGazettenumber.Text;
                    objBE.District = ddlDist.SelectedValue;
                    objBE.Mandal = ddlMandal.SelectedValue;
                    objBE.Village = ddlVillage.SelectedValue;
                    objBE.Address = txtAddress.Text;
                    objBE.Primary_Depot_Code = ddlPrimary.SelectedValue;
                    objBE.Primary_Depot_Active_YN = rblPrimary.SelectedValue;
                    objBE.Secondary_Depot_Code = ddlSecondary.SelectedValue;
                    objBE.Secondary_Depot_Active_YN = rblSecondary.SelectedValue;
                    objBE.EmailID = txtEmailID.Text;
                    objBE.MobileNumber = txtMobileNumber.Text;
                    objBE.IP_Address = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.Action = "I";
                    //
                    //  dt = ObjMDL.Retailers(objBE, Session["ConnKey"].ToString());
                    dt = ObjMDL.Retailers(objBE, ConnKey);//Session["ConnKey"].ToString()
                                                          //  dt = ObjMDL.TypeofManufacturing_IUR(objBE, Session["ConnKey"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());

                        Viewdata();
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("Data Saved");
                        Viewdata();
                    }
                }

            }
            catch
            {
                // Response.Redirect("~/Error.aspx");

            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {

                    objBE.RetailerName = txtRetailerName.Text;
                    objBE.Retailer_Type = ddlRetailerType.SelectedValue;
                    objBE.License_Name = txtLicenseName.Text;
                    objBE.License_Gazette_number = txtLicenseGazettenumber.Text;
                    objBE.District = ddlDist.SelectedValue;
                    objBE.Mandal = ddlMandal.SelectedValue;
                    objBE.Village = ddlVillage.SelectedValue;
                    objBE.Address = txtAddress.Text;
                    objBE.Primary_Depot_Code = ddlPrimary.SelectedValue;
                    objBE.Primary_Depot_Active_YN = rblPrimary.SelectedValue;
                    objBE.Secondary_Depot_Code = ddlSecondary.SelectedValue;
                    objBE.Secondary_Depot_Active_YN = rblSecondary.SelectedValue;
                    objBE.EmailID = txtEmailID.Text;
                    objBE.MobileNumber = txtMobileNumber.Text;
                    objBE.Retailer_Code = Convert.ToInt32(ViewState["Id"].ToString());
                    objBE.IP_Address = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.Action = "U";

                    DataTable dt = new DataTable();
                    // dt = ObjMDL.TypeofManufacturing_IUR(objBE, Session["ConnKey"].ToString());
                    dt = ObjMDL.Retailers(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());

                        Viewdata();
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("Updated sucessfully");
                        Viewdata();
                    }
                }

            }
            catch
            {

            }
        }
        protected void ddlDist_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindMandal();
        }
        protected void ddlRetailerType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GvDF_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "edt")
                {
                    DataTable dt = new DataTable();

                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    txtRetailerName.Text = ((Label)(gRow.FindControl("lblRetailerName"))).Text;
                    ddlRetailerType.SelectedValue = ((Label)(gRow.FindControl("lblRetailer_Type"))).Text;
                    txtLicenseName.Text = ((Label)(gRow.FindControl("lblLicense_Name"))).Text;
                    txtLicenseGazettenumber.Text = ((Label)(gRow.FindControl("lblLicense_Gazette_number"))).Text;
                    BindDistrict();
                    ddlDist.SelectedValue = ((Label)(gRow.FindControl("lblDistrict"))).Text;
                    BindMandal();
                    ddlMandal.SelectedValue = ((Label)(gRow.FindControl("lblMandal"))).Text;
                    BindVillage();
                    ddlVillage.SelectedValue = ((Label)(gRow.FindControl("lblVillage"))).Text;
                    txtAddress.Text = ((Label)(gRow.FindControl("lbllAddress"))).Text;
                    ddlPrimary.SelectedValue = ((Label)(gRow.FindControl("lblPrimary_Depot_Code"))).Text;
                    rblPrimary.SelectedValue = ((Label)(gRow.FindControl("lblPrimary_Depot_Active_YN"))).Text;
                    ddlSecondary.SelectedValue = ((Label)(gRow.FindControl("lblSecondary_Depot_Code"))).Text;
                    rblSecondary.SelectedValue = ((Label)(gRow.FindControl("lblSecondary_Depot_Active_YN"))).Text;
                    txtEmailID.Text = ((Label)(gRow.FindControl("lblEmailID"))).Text;
                    txtMobileNumber.Text = ((Label)(gRow.FindControl("lblMobileNumber"))).Text;

                    ViewState["Id"] = ((Label)(gRow.FindControl("lblRetailerCode"))).Text;
                    // Label labDFCode = ((Label)(gRow.FindControl("lblDF_Code"))).Text;
                    // //GoDownId.Value = ((Label)(gRow.FindControl("lblSuppCode"))).Text;

                    btn_Save.Visible = false;
                    btn_Update.Visible = true;


                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }

        }
        protected void GvDF_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                GvDF.PageIndex = e.NewPageIndex;
                Viewdata();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }

        }

        public void clear()
        {
            txtRetailerName.Text = string.Empty;
            ddlRetailerType.SelectedValue = "";
            txtLicenseName.Text = string.Empty;
            txtLicenseGazettenumber.Text = string.Empty;
            ddlDist.SelectedValue = "";
            ddlMandal.SelectedValue = "";
            ddlVillage.SelectedValue = "";
            txtAddress.Text = string.Empty;
            ddlPrimary.SelectedValue = "";
            rblPrimary.SelectedValue = "";
            ddlSecondary.SelectedValue = "";
            rblSecondary.SelectedValue = "";
            txtEmailID.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;

        }

    }

}