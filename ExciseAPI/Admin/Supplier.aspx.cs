using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;

namespace ExciseAPI.Admin
{
    public partial class Supplier : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        protected void Page_Load(object sender, EventArgs e)
        {

            
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "1" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                GvSupplier.Width = Unit.Percentage(100);
                GetTypeManFDAL();
                BindDistrict();
                //  Viewdata();
                //random();


            }
        }

        public void GetTypeManFDAL()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Action = "MR";
                dt1 = ObjMDL.TypeofManufacturing_IUR(objBE, Session["ConnKey"].ToString());
                if (dt1.Rows.Count > 0)
                {
                    objCommon.BindDropDownLists(ddlTypeofmanu, dt1, "Manuf_Name", "Manuf_Code", "0");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void GetMaufDtls()
        {
            try
            {

                DataTable dt = new DataTable();
                objBE.Id = ddlTypeofmanu.SelectedValue;
                objBE.Action = "VR";
                dt = ObjMDL.TypeofManufacturing_IUR(objBE, Session["ConnKey"].ToString());
                if (dt.Rows.Count > 0)
                {
                    txtPanNo.Text = dt.Rows[0]["PAN_No"].ToString();
                    txtSgstNo.Text = dt.Rows[0]["SGST_No"].ToString();
                    txtTinNo.Text = dt.Rows[0]["TIN_No"].ToString();
                    lblTypeofmanyf.Text = dt.Rows[0]["Type_Man_Nm"].ToString();
                    lblmfcd.Text = dt.Rows[0]["Type_of_Manufacturing"].ToString();
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found For This Manufcturer");
                }

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
                objCommon.BindDropDownLists(ddlMand, dt1, "MandName", "MandCode", "0");
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
                objBE.MandCode = ddlMand.SelectedValue;
                objBE.Action = "R";
                dt1 = ObjMDL.GetvillDAL(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlVill, dt1, "VillName", "VillCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected bool Validate()
        {
            if (ddlDist.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Please Select District");
                ddlDist.Focus();
                return false;
            }
            if (ddlMand.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Please Select Mandal");
                ddlMand.Focus();
                return false;
            }
            if (ddlVill.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Please Select Village");
                ddlVill.Focus();
                return false;
            }

            if (ddlTypeofmanu.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Please Select Type Of Manufacturer");
                ddlTypeofmanu.Focus();
                return false;
            }
            if (txtAdd.Text == "")
            {
                bool val;
                val = obj.CheckInput_new(txtAdd.Text);
                if (val == true)
                {
                    Response.Redirect("~/Error.aspx");
                }

            }
            if (txtMob.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Mobile Number");
                txtMob.Focus();
                return false;
            }
            else
            {
                if (!objValidate.ISMobileNo(txtMob.Text, 9, 9))
                {
                    objCommon.ShowAlertMessage("Please Enter Valid Mobile Number");
                    return false;
                }
            }
            //if (txtLicDate.Text != "")
            //{
            //    bool val;
            //    val = obj.CheckInput_new(txtLicDate.Text);
            //    if (val == true)
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }

            //}
            if (txtLicNo.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Licensee Number");
                txtLicNo.Focus();
                return false;
            }
            //if (txtPanNo.Text != "")
            //{
            //    bool val;
            //    val = obj.CheckInput_new(txtPanNo.Text);
            //    if (val == true)
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }

            //}
            if (txtPincode.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Pincode");
                txtPincode.Focus();
                return false;
            }

            //if (txtSgstNo.Text != "")
            //{
            //    objCommon.ShowAlertMessage("Enter SGST Number");
            //    txtSgstNo.Focus();
            //    return false;
            //}
            //if (txtSupName.Text != "")
            //{
            //    objCommon.ShowAlertMessage("Enter Supplier Name");
            //    txtSupName.Focus();
            //    return false;
            //}
            //if (txtTinNo.Text != "")
            //{
            //    objCommon.ShowAlertMessage("Enter TIN Number");
            //    txtTinNo.Focus();
            //    return false;
            //}

            return true;


        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    objBE.Type_of_Manu = lblmfcd.Text;
                    objBE.ManufCd = ddlTypeofmanu.SelectedValue;
                    objBE.Supplier_Code = txtSupCode.Text;
                    objBE.SupplierName = txtSupName.Text;
                    objBE.Statecode = "36";
                    objBE.DistCode = ddlDist.SelectedValue;
                    objBE.MandCode = ddlMand.SelectedValue;
                    objBE.VillCode = ddlVill.SelectedValue;
                    objBE.Address = txtAdd.Text;
                    objBE.LicNo = txtLicNo.Text;

                    // objBE.LicAdd = txtLicAdd.Text;
                    objBE.Dt_Valid_Fm = DateTime.Parse(txtDtFrom.Text.ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).ToString("yyyy-MM-dd");
                    objBE.Dt_Valid_To = DateTime.Parse(txtDtTo.Text.ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).ToString("yyyy-MM-dd");
                    objBE.Annual_Lic_Capacity = txtLicCapacity.Text;
                    objBE.DDoCode = txtDDOCode.Text;
                    objBE.PANNo = txtPanNo.Text;
                    objBE.TINNo = txtTinNo.Text;
                    objBE.SGSTNo = txtSgstNo.Text;
                    objBE.MobNo = txtMob.Text;
                    objBE.Pincode = txtPincode.Text;
                    //objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.UserName = Session["User"].ToString();
                    objBE.Action = "I";
                    DataTable dt = new DataTable();
                    dt = objDL.Supplier_IUR(objBE, Session["ConnKey"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        Viewdata();
                        ClearAll();

                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void GvSupplier_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "edt")
                {
                    DataTable dt = new DataTable();

                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    txtSupName.Text = ((Label)(gRow.FindControl("lblSuppName"))).Text;
                    txtSupCode.Text = ((Label)(gRow.FindControl("lblSuppCode"))).Text;
                    txtMob.Text = ((Label)(gRow.FindControl("lblMob"))).Text;
                    txtDDOCode.Text = ((Label)(gRow.FindControl("lblDDOCode"))).Text;
                    // GoDownId.Value = ((Label)(gRow.FindControl("lblTypecode"))).Text;
                    //GoDownId.Value = ((Label)(gRow.FindControl("lblSuppCode"))).Text;
                    BindDistrict();
                    ddlDist.SelectedValue = ((Label)(gRow.FindControl("lblDistcode"))).Text;
                    BindMandal();
                    ddlMand.SelectedValue = ((Label)(gRow.FindControl("lblMandcode"))).Text;
                    BindVillage();
                    ddlVill.SelectedValue = ((Label)(gRow.FindControl("lblVillcode"))).Text;

                    // ddlGoDownType.SelectedValue = ((Label)(gRow.FindControl("lblAdd"))).Text;
                    // txtGoDownName.Text = ((Label)(gRow.FindControl("lblLicNo"))).Text;
                    txtAdd.Text = ((Label)(gRow.FindControl("lblAdd"))).Text;
                    txtPincode.Text = ((Label)(gRow.FindControl("lblPincode"))).Text;
                    txtLicNo.Text = ((Label)(gRow.FindControl("lblLicNo"))).Text;
                    txtLicCapacity.Text = ((Label)(gRow.FindControl("lblLicCap"))).Text;
                    txtDtTo.Text = ((Label)(gRow.FindControl("lblDtValidTo"))).Text;
                    txtDtFrom.Text = ((Label)(gRow.FindControl("lblDtValidFrom"))).Text;

                    btn_Save.Visible = false;
                    btn_Update.Visible = true;
                    txtSupCode.Enabled = false;
                    //ddlDist.Enabled = false;
                    //ddlMand.Enabled = false;
                    //ddlVill.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void GvSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvSupplier.PageIndex = e.NewPageIndex;
                Viewdata();
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
                // objBE.ApplicantId = Session["ApplicantId"].ToString();
                // objRegBE.System = Session["System"].ToString();
                objBE.ManufCd = ddlTypeofmanu.SelectedValue;
                objBE.Action = "R";
                dt = objDL.Supplier_IUR(objBE, Session["ConnKey"].ToString());

                if (dt.Rows.Count > 0)
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    Div1.Visible = true;
                    GvSupplier.Visible = true;
                    GvSupplier.DataSource = dt;
                    GvSupplier.DataBind();
                    dt.Dispose();



                }
                else
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    //objCommon.ShowAlertMessage("No Data Found For This ");
                    Div1.Visible = false;
                    GvSupplier.Visible = false;

                }

            }
            catch (Exception ex)
            {
                // ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


      
        protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMandal();
        }
        protected void ddlMand_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVillage();
        }
        protected void ddlTypeofmanu_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMaufDtls();
            Viewdata();
        }
        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    objBE.Type_of_Manu = lblmfcd.Text;
                    objBE.ManufCd = ddlTypeofmanu.SelectedValue;
                    objBE.Supplier_Code = txtSupCode.Text;
                    objBE.SupplierName = txtSupName.Text;
                    objBE.Statecode = "36";
                    objBE.DistCode = ddlDist.SelectedValue;
                    objBE.MandCode = ddlMand.SelectedValue;
                    objBE.VillCode = ddlVill.SelectedValue;
                    objBE.Address = txtAdd.Text;
                    objBE.LicNo = txtLicNo.Text;

                    // objBE.LicAdd = txtLicAdd.Text;
                    objBE.Dt_Valid_Fm = DateTime.Parse(txtDtFrom.Text.ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).ToString("yyyy-MM-dd");
                    objBE.Dt_Valid_To = DateTime.Parse(txtDtTo.Text.ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).ToString("yyyy-MM-dd");
                    objBE.Annual_Lic_Capacity = txtLicCapacity.Text;
                    objBE.DDoCode = txtDDOCode.Text;
                    objBE.PANNo = txtPanNo.Text;
                    objBE.TINNo = txtTinNo.Text;
                    objBE.SGSTNo = txtSgstNo.Text;
                    objBE.MobNo = txtMob.Text;
                    objBE.Pincode = txtPincode.Text;
                    //objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.UserName = Session["User"].ToString();
                    objBE.Action = "U";
                    DataTable dt = new DataTable();
                    dt = objDL.Supplier_IUR(objBE, Session["ConnKey"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        Viewdata();
                        ClearAll();

                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        public void ClearAll()
        {

            txtSupCode.Text = "";
            txtSupName.Text = "";
            txtMob.Text = "";
            ddlDist.ClearSelection();
            ddlMand.ClearSelection();
            ddlVill.ClearSelection();
            txtPanNo.Text = "";
            txtPincode.Text = "";
            txtTinNo.Text = "";
            ddlTypeofmanu.ClearSelection();
            txtSgstNo.Text = "";
            txtMob.Text = "";
            txtAdd.Text = "";
            txtLicCapacity.Text = "";
            txtSupCode.Enabled = true;
            // ddlCaste.ClearSelection();
            txtDtFrom.Text = "";
            txtDtTo.Text = "";
            txtDDOCode.Text = "";
            txtLicCapacity.Text = "";
            btn_Save.Visible = true;
            btn_Update.Visible = false;
        }
    }
}