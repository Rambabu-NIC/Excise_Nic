using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Admin
{
    public partial class Manufacture : System.Web.UI.Page
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

                GetTypeManFDAL();
                BindState();
                //  BindDistrict();
                Viewdata();
                random();


            }

        }
        protected void BindState()
        {
            DataTable dt = new DataTable();
            try
            {
                objBE.Action = "R";
                dt = ObjMDL.GetStateDL(objBE, Session["ConnKey"].ToString());
                if (dt.Rows.Count > 0)
                {
                    objCommon.BindDropDownLists(ddl_Stae, dt, "StateName", "StateCode", "0");
                }
                else
                {
                    ddl_Stae.Items.Clear();
                    ddl_Stae.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }
        public void GetTypeManFDAL()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Action = "R";
                dt1 = ObjMDL.TypeofManufacturing_IUR(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlTypeofmanu, dt1, "Type_Man_Nm", "Type_Man_Cd", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }


        public void BindDistrict()
        {
            try
            {

                objBE.Statecode = ddl_Stae.SelectedValue;
                DataTable dt1 = new DataTable();
                objBE.Action = "R";
                dt1 = ObjMDL.GetDistDL(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlDist, dt1, "DistName", "DistCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }

        public void BindMandal()
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.Statecode = ddl_Stae.SelectedValue;
                objBE.DistCode = ddlDist.SelectedValue;
                objBE.Action = "R";
                dt1 = ObjMDL.GetmandalsDAL(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlMand, dt1, "MandName", "MandCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
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
                //Response.Redirect("~/Error.aspx");
            }
        }

        protected bool Validate()
        {
            if (ddlTypeofmanu.SelectedValue == "")
            {

                objCommon.ShowAlertMessage("Please Select Type Of Manufacturer");
                ddlTypeofmanu.Focus();
                return false;
            }
            if (txtManufName.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter Manufacturer Name");
                txtManufName.Focus();
                return false;
            }
            if (txtPersonNm.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter Contact Person Name");
                txtPersonNm.Focus();
                return false;
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

            if (ddl_Stae.SelectedValue == "")
            {

                objCommon.ShowAlertMessage("Please Select State");
                ddlDist.Focus();
                return false;
            }
            if (ddlDist.SelectedValue == "")
            {
                objCommon.ShowAlertMessage("Please Select District");
                ddlDist.Focus();
                return false;
            }

            if (ddl_Stae.SelectedValue == "36")
            {

                if (ddlMand.SelectedValue == "")
                {
                    objCommon.ShowAlertMessage("Please Select Mandal");
                    ddlMand.Focus();
                    return false;
                }
                if (ddlVill.SelectedValue == "")
                {
                    objCommon.ShowAlertMessage("Please Select Village");
                    ddlVill.Focus();
                    return false;
                }
            }


            if (txtAdd.Text == "")
            {
                bool val;
                val = obj.CheckInput_new(txtAdd.Text);
                if (val == true)
                {
                    objCommon.ShowAlertMessage("Enter Address");
                    txtAdd.Focus();
                    return false;
                }
                else
                {
                    objCommon.ShowAlertMessage("Enter Address");
                    txtAdd.Focus();
                    return false;
                }

            }

            if (txtPincode.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Pincode");
                txtPincode.Focus();
                return false;
            }
            if (txtLicNo.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Licensee Number ");
                txtLicNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDtFrom.Text))
            {
                objCommon.ShowAlertMessage("Enter Date Valid From");
                txtDtFrom.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDtTo.Text))
            {
                objCommon.ShowAlertMessage("Enter Date Valid To");
                txtDtTo.Focus();
                return false;
            }
            if (txtTinNo.Text == "")
            {
                objCommon.ShowAlertMessage("Enter TIN Number");
                txtTinNo.Focus();
                return false;
            }
            if (txtSgstNo.Text == "")
            {
                objCommon.ShowAlertMessage("Enter SGST Number");
                txtSgstNo.Focus();
                return false;
            }

            //if (txtSupName.Text != "")
            //{
            //    objCommon.ShowAlertMessage("Enter Supplier Name");
            //    txtSupName.Focus();
            //    return false;
            //}

            if (string.IsNullOrEmpty(txtPanNo.Text))
            {
                objCommon.ShowAlertMessage("Enter PAN Number");
                txtPanNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLicCapacity.Text))
            {
                objCommon.ShowAlertMessage("Enter Annual Licensee Capacity");
                txtLicCapacity.Focus();
                return false;
            }

            return true;


        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    objBE.Type_of_Manu = ddlTypeofmanu.SelectedValue;
                    objBE.SupplierName = txtManufName.Text;
                    objBE.Statecode = ddl_Stae.SelectedValue;
                    objBE.NameOfPerm = txtPersonNm.Text;
                    objBE.DistCode = ddlDist.SelectedValue;
                    objBE.MandCode = ddlMand.SelectedValue;
                    objBE.VillCode = ddlVill.SelectedValue;
                    objBE.Address = txtAdd.Text;
                    objBE.LicNo = txtLicNo.Text;

                    objBE.Dt_Valid_Fm = DateTime.Parse(txtDtFrom.Text.ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).ToString("yyyy-MM-dd");
                    objBE.Dt_Valid_To = DateTime.Parse(txtDtTo.Text.ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).ToString("yyyy-MM-dd");
                    objBE.Annual_Lic_Capacity = txtLicCapacity.Text;
                    objBE.PANNo = txtPanNo.Text;
                    objBE.TINNo = txtTinNo.Text;
                    objBE.SGSTNo = txtSgstNo.Text;
                    objBE.MobNo = txtMob.Text;
                    objBE.Pincode = txtPincode.Text;
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.UserName = Session["User"].ToString();
                    objBE.Action = "I";
                    DataTable dt = new DataTable();
                    dt = objDL.Manuf_IUR(objBE, Session["ConnKey"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        Viewdata();
                        ClearAll();

                    }
                }

            }
            catch
            {
                //     Response.Redirect("~/Error.aspx");
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

                    ddlTypeofmanu.SelectedValue = ((Label)(gRow.FindControl("lblTypecode"))).Text;
                    txtPersonNm.Text = ((Label)(gRow.FindControl("lblPeNm"))).Text;
                    txtMob.Text = ((Label)(gRow.FindControl("lblMob"))).Text;
                    txtManufName.Text = ((Label)(gRow.FindControl("lblManufName"))).Text;
                    // GoDownId.Value = ((Label)(gRow.FindControl("lblTypecode"))).Text;
                    //GoDownId.Value = ((Label)(gRow.FindControl("lblSuppCode"))).Text;
                    lblManufCode.Text = ((Label)(gRow.FindControl("lblManufCode"))).Text;
                    BindState();
                    ddl_Stae.SelectedValue = ((Label)(gRow.FindControl("lblStateCode"))).Text;
                    BindDistrict();
                    ddlDist.SelectedValue = ((Label)(gRow.FindControl("lblDistcode"))).Text;
                    BindMandal();
                    ddlMand.SelectedValue = ((Label)(gRow.FindControl("lblMandcode"))).Text;
                    BindVillage();
                    ddlVill.SelectedValue = ((Label)(gRow.FindControl("lblVillcode"))).Text;
                    txtPanNo.Text = ((Label)(gRow.FindControl("lblPANNo"))).Text;
                    txtTinNo.Text = ((Label)(gRow.FindControl("lblTINNo"))).Text;
                    txtAdd.Text = ((Label)(gRow.FindControl("lblAdd"))).Text;
                    txtPincode.Text = ((Label)(gRow.FindControl("lblPincode"))).Text;
                    txtLicNo.Text = ((Label)(gRow.FindControl("lblLicNo"))).Text;
                    txtSgstNo.Text = ((Label)(gRow.FindControl("lblSGSTNo"))).Text;
                    txtLicCapacity.Text = ((Label)(gRow.FindControl("lblLicCap"))).Text;
                    txtDtTo.Text = ((Label)(gRow.FindControl("lblDtValidTo"))).Text;
                    txtDtFrom.Text = ((Label)(gRow.FindControl("lblDtValidFrom"))).Text;
                    btn_Save.Visible = false;
                    btn_Update.Visible = true;


                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
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

                objBE.Action = "R";
                dt = objDL.Manuf_IUR(objBE, Session["ConnKey"].ToString());

                if (dt.Rows.Count > 0)
                {
                    divgrid.Visible = true;
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    GvSupplier.Visible = true;
                    GvSupplier.DataSource = dt;
                    GvSupplier.DataBind();
                    dt.Dispose();



                }
                else
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    //objCommon.ShowAlertMessage("No Data Found For This ");
                    GvSupplier.Visible = false;

                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                // Response.Redirect("~/Error.aspx");
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
        protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMandal();
        }
        protected void ddlMand_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVillage();
        }
        protected void ddl_Stae_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistrict();
        }
        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    objBE.Type_of_Manu = ddlTypeofmanu.SelectedValue;
                    objBE.SupplierName = txtManufName.Text;
                    objBE.SupplierCode = lblManufCode.Text;
                    objBE.Statecode = ddl_Stae.SelectedValue;
                    objBE.NameOfPerm = txtPersonNm.Text;
                    objBE.DistCode = ddlDist.SelectedValue;
                    objBE.MandCode = ddlMand.SelectedValue;
                    objBE.VillCode = ddlVill.SelectedValue;
                    objBE.Address = txtAdd.Text;
                    objBE.LicNo = txtLicNo.Text;
                    objBE.Dt_Valid_Fm = DateTime.Parse(txtDtFrom.Text.ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).ToString("yyyy-MM-dd");
                    objBE.Dt_Valid_To = DateTime.Parse(txtDtTo.Text.ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).ToString("yyyy-MM-dd");
                    objBE.Annual_Lic_Capacity = txtLicCapacity.Text;
                    objBE.PANNo = txtPanNo.Text;
                    objBE.TINNo = txtTinNo.Text;
                    objBE.SGSTNo = txtSgstNo.Text;
                    objBE.MobNo = txtMob.Text;
                    objBE.Pincode = txtPincode.Text;
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.UserName = Session["User"].ToString();
                    objBE.Action = "U";
                    DataTable dt = new DataTable();
                    dt = objDL.Manuf_IUR(objBE, Session["ConnKey"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        Viewdata();

                        ClearAll();

                    }



                }

            }
            catch
            {
                //     Response.Redirect("~/Error.aspx");
            }
        }
        public void ClearAll()
        {

            txtManufName.Text = "";
            txtPersonNm.Text = "";
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
            txtLicNo.Text = "";
            // ddlCaste.ClearSelection();
            txtDtFrom.Text = "";
            txtDtTo.Text = "";
            btn_Save.Visible = true;
            btn_Update.Visible = false;
        }
    }
}