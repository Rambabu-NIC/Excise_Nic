using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;

namespace ExciseAPI.Supplier
{
    public partial class Supplier : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();

        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
                Response.Redirect("~/Error.aspx");
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

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                //lblUSer.Text = Session["UsrName"].ToString();
                GetTypeManFDAL();
                BindDistrict();
                Viewdata();
                //random();


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
                    objBE.Type_of_Manu = ddlTypeofmanu.SelectedValue;
                    objBE.SupplierCode = txtSupCode.Text;
                    objBE.SupplierName = txtSupName.Text;
                    objBE.DistCode = ddlDist.SelectedValue;
                    objBE.MandCode = ddlMand.SelectedValue;
                    objBE.VillCode = ddlVill.SelectedValue;
                    objBE.Address = txtAdd.Text;
                    objBE.LicNo = txtLicNo.Text;

                    // objBE.LicAdd = txtLicAdd.Text;
                    objBE.Dt_Valid_Fm = txtDtFrom.Text;
                    objBE.Dt_Valid_To = txtDtTo.Text;
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

                    }
                }

            }
            catch
            {

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
                    txtAdd.Text = ((Label)(gRow.FindControl("lblDtValidFrom"))).Text;
                    // txtCapacity.Text = ((Label)(gRow.FindControl("lblDtValidTo"))).Text;
                    //txtGoDownIncharge.Text = ((Label)(gRow.FindControl("lblLicCap"))).Text;
                    // txtMobNo.Text = ((Label)(gRow.FindControl("lblDDOCode"))).Text;
                    // txtCapacity.Text = ((Label)(gRow.FindControl("lblPANNo"))).Text;
                    // txtGoDownIncharge.Text = ((Label)(gRow.FindControl("lblTINNo"))).Text;
                    // txtMobNo.Text = ((Label)(gRow.FindControl("lblSGSTNo"))).Text;
                    // txtGoDownIncharge.Text = ((Label)(gRow.FindControl("lblMob"))).Text;
                    // txtMobNo.Text = ((Label)(gRow.FindControl("lblPincode"))).Text;
                    btn_Save.Visible = false;
                    btn_Update.Visible = true;
                    ddlDist.Enabled = false;
                    ddlMand.Enabled = false;
                    ddlVill.Enabled = false;

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
                objBE.Action = "R";
                dt = objDL.Supplier_IUR(objBE, Session["ConnKey"].ToString());

                if (dt.Rows.Count > 0)
                {
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
                Response.Redirect("~/Error.aspx");
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
        //        Response.Redirect("~/Error.aspx", false);
        //    }
        //}
        protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMandal();
        }
        protected void ddlMand_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVillage();
        }
    }
}