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

namespace ExciseAPI.SHO
{
    public partial class EventUpdate_SHO : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
                //  Response.Redirect("~/Error.aspx");
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


            if (!IsPostBack)
            {


                // Getdata();

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
        public void BindEventTime()
        {
            try
            {


                DataTable dt = new DataTable();

                dt = ObjMDL.GetEventTime(ConnKey);
                objCommon.BindDropDownLists(ddlEvntTm, dt, "SlotDesc", "Slot", "0");


            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
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
        //public void BindRevMandal(string DistCode)
        //{
        //    try
        //    {
        //        DataTable dt1 = new DataTable();
        //        objBE.Statecode = "36";
        //        objBE.DistCode = DistCode;
        //        objBE.Action = "RM";
        //        dt1 = ObjMDL.CommonMasters(objBE, ConnKey);
        //        objCommon.BindDropDownLists(ddlMandal, dt1, "MandName", "MandCode", "0");
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}
        protected void Getdata()
        {
            try
            {
                objBE = new Supplier_BE();
                DataTable dt1 = new DataTable();
                objBE.Reg_Code = txtAppRegNO.Text.ToString();//Session["AppRegNo_SHO"].ToString();// txtAppReg_NO.Text; /*Session["RegId"].ToString();//"360200001423"; //*/

                dt1 = objDL.EventUpdate_SHO(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    diveventdetails.Visible = true;
                    txtAppReg_NO.Text = dt1.Rows[0]["AppReg_NO"].ToString();
                    //  pannel1.Visible = true;
                    txtName.Text = dt1.Rows[0]["App_Name"].ToString();

                    txtMobileNumber.Text = dt1.Rows[0]["Mob_No"].ToString();
                    txtEmail.Text = dt1.Rows[0]["Email"].ToString();
                    txtName_Premises.Text = dt1.Rows[0]["Name_Premises"].ToString();
                    txtStreet.Text = dt1.Rows[0]["Street"].ToString();
                    txtEast.Text = dt1.Rows[0]["Bdr_East"].ToString();
                    txtWest.Text = dt1.Rows[0]["Bdr_West"].ToString();
                    txtNorth.Text = dt1.Rows[0]["Bdr_North"].ToString();
                    txtSouth.Text = dt1.Rows[0]["Bdr_South"].ToString();
                    ddlGHMC.SelectedValue = dt1.Rows[0]["GHMC"].ToString();



                    //ddlEvntTm.SelectedValue = dt1.Rows[0]["Eventtime"].ToString().Trim();
                    //BindEventTime();
                    if (dt1.Rows[0]["Eventtime"].ToString().Trim() == "1" || dt1.Rows[0]["Eventtime"].ToString().Trim() == "Slot-1 (11AM-4PM)") //"Slot-1 (11AM-4PM)")
                    {
                        ddlEvntTm.SelectedIndex = 1;
                    }
                    else if (dt1.Rows[0]["Eventtime"].ToString().Trim() == "2" || dt1.Rows[0]["Eventtime"].ToString().Trim() == "Slot-2 (7PM-11PM)") //"Slot-2 (7PM-11PM)")
                    { ddlEvntTm.SelectedIndex = 2; }


                    txtDate.Text = dt1.Rows[0]["Date"].ToString();
                    //string District= dt1.Rows[0]["DistCode"].ToString();
                    //BindRevMandal(District);
                    //ddlMandal.SelectedValue= dt1.Rows[0]["Mandal"].ToString();
                }

                else
                {

                    objCommon.ShowAlertMessage("There Is No Data Found For this Registration Number");
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("../Error.aspx");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            objBE = new Supplier_BE();
            DataTable dt = new DataTable();
            objBE.Reg_Code = txtAppRegNO.Text.ToString();// txtAppReg_NO.Text; /*Session["RegId"].ToString();//"360200001423"; //*/    
            objBE.AppName = txtName.Text;
            objBE.MobNo = txtMobileNumber.Text;
            objBE.Email = txtEmail.Text;
            objBE.NameOfPerm = txtName_Premises.Text;
            objBE.Street = txtStreet.Text;
            objBE.BdrEast = txtEast.Text;
            objBE.BdrWest = txtWest.Text;
            objBE.BdrNorth = txtNorth.Text;
            objBE.BdrSouth = txtSouth.Text;
            objBE.ToDate = Convert.ToDateTime(txtDate.Text);
            objBE.Eventtime = ddlEvntTm.SelectedValue.ToString();
            objBE.ghmc = ddlGHMC.SelectedValue.ToString();
            //objBE.MandCode = ddlMandal.SelectedValue.ToString();
            if (ddlEvntTm.SelectedValue == "0")
            {
                lblError.Text = "Please select the slot..";
                return;
            }
            lblError.Text = "";
            bool resultdt = objDL.SHO_Event(objBE, ConnKey);
            if (resultdt == true)
            {
                diveventdetails.Visible = false;
                lblError.Text = "Updated successfully";
                lblErrorMessage.Text = "Updated successfully";
                lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                objCommon.ShowAlertMessage("Updated Successfully..");
            }
            else
            {
                lblError.Text = "No Data Found";
            }

        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            lblError.Text = "";
            if (!string.IsNullOrEmpty(txtAppRegNO.Text))
            {
                Getdata();
            }
            else
            {
                lblErrorMessage.Text = "Please Enter AppReg No...";
                return;
            }

        }
    }
}