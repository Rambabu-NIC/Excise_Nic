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
    public partial class Event_MandalTransfer : System.Web.UI.Page
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
        //public void BindEventTime()
        //{
        //    try
        //    {


        //        DataTable dt = new DataTable();

        //        dt = ObjMDL.GetEventTime(ConnKey);
        //        objCommon.BindDropDownLists(ddlEvntTm, dt, "SlotDesc", "Slot", "0");


        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}
        public void BindRevDistrict()
        {
            try
            {

                objBE.Statecode = "36";
                DataTable dt1 = new DataTable();
                objBE.Action = "RD";
                dt1 = ObjMDL.CommonMasters(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlRevDistrict, dt1, "DistName", "DistCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindRevMandal()
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.Statecode = "36";
                objBE.DistCode = ddlRevDistrict.SelectedValue;
                objBE.Action = "RM";
                dt1 = ObjMDL.CommonMasters(objBE, ConnKey);
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
                objBE.DistCode = ddlRevDistrict.SelectedValue;
                objBE.MandCode = ddlMandal.SelectedValue;
                objBE.Action = "RV";
                dt1 = ObjMDL.CommonMasters(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlLocality, dt1, "VillName", "VillCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void ddlRevDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRevMandal();
            if (ddlRevDistrict.SelectedValue == "31")
            {
                lblbmandal.Text = "Police station";
            }
            else
            {
                lblbmandal.Text = "Mandal";
            }

        }
        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRevDistrict.SelectedValue == "31")
            {
                lblExDist.Text = "";
                lblExStation.Text = "";

                ddlLocality.Enabled = false;

                ddlLocality.ClearSelection();
                BindRevdistVill();

            }
            else
            {

                lblExDist.Text = "";
                lblExStation.Text = "";

                ddlLocality.Enabled = true;
                BindVillage();
            }
        }
        protected void ddlLocality_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRevdistVill();
        }
        public void BindRevdistVill()
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.Statecode = "36";
                objBE.DistCode = ddlRevDistrict.SelectedValue;
                objBE.MandCode = ddlMandal.SelectedValue;
                objBE.VillCode = ddlLocality.SelectedValue;
                objBE.Action = "R";
                dt1 = ObjMDL.GetRenDS(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    lblExDistCode.Text = dt1.Rows[0]["ExDist_Cd"].ToString();
                    lblExStation.Text = dt1.Rows[0]["ExStation"].ToString();
                    lblExDist.Text = dt1.Rows[0]["ExDist"].ToString();
                    lblExStationCd.Text = dt1.Rows[0]["ExStationCode"].ToString();
                    lblGHMC.Text = dt1.Rows[0]["GHMC"].ToString();

                }
                else
                {
                    lblExDistCode.Text = "";
                    lblExStation.Text = "";
                    lblExDist.Text = "";
                    lblExStationCd.Text = "";
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        public DataTable dtGetData
        {
            get
            {
                return ViewState["dtGetData"] as DataTable;
            }
            set
            {
                ViewState["dtGetData"] = value;
            }
        }

        protected void Getdata()
        {
            try
            {
                objBE = new Supplier_BE();
                //DataTable dt1 = new DataTable();
                objBE.Reg_Code = txtAppRegNO.Text.ToString();//Session["AppRegNo_SHO"].ToString();// txtAppReg_NO.Text; /*Session["RegId"].ToString();//"360200001423"; //*/
                if (Session["Role"].ToString() == "50")
                {
                    dtGetData = objDL.EventMandalAC(objBE, ConnKey);
                }
                else
                {
                    objBE.ExStation = Session["SHOID"].ToString();
                    dtGetData = objDL.EventMandal(objBE, ConnKey);
                }
                if (dtGetData.Rows.Count > 0)
                {
                    diveventMandal.Visible = true;
                    txtAppReg_NO.Text = dtGetData.Rows[0]["AppReg_NO"].ToString();
                    //  pannel1.Visible = true;
                    txtName.Text = dtGetData.Rows[0]["App_Name"].ToString();

                    txtMobileNumber.Text = dtGetData.Rows[0]["Mob_No"].ToString();
                    txtEmail.Text = dtGetData.Rows[0]["Email"].ToString();
                    //txtName_Premises.Text = dt1.Rows[0]["Name_Premises"].ToString();
                    //txtStreet.Text = dt1.Rows[0]["Street"].ToString();
                    //txtEast.Text = dt1.Rows[0]["Bdr_East"].ToString();
                    //txtWest.Text = dt1.Rows[0]["Bdr_West"].ToString();
                    //txtNorth.Text = dt1.Rows[0]["Bdr_North"].ToString();
                    //txtSouth.Text = dt1.Rows[0]["Bdr_South"].ToString();
                    //ddlGHMC.SelectedValue = dt1.Rows[0]["GHMC"].ToString();
                    //BindEventTime();
                    //if (dt1.Rows[0]["Eventtime"].ToString().Trim() == "Slot-1 (11AM-4PM)")
                    //{
                    //    ddlEvntTm.SelectedValue = "1";
                    //}
                    //else if (dt1.Rows[0]["Eventtime"].ToString().Trim() == "Slot-2 (7PM-11PM)")
                    //{ ddlEvntTm.SelectedValue = "2"; }


                    //txtDate.Text = dt1.Rows[0]["Date"].ToString();
                    objBE.Statecode = "36";

                    BindRevDistrict();

                    ddlRevDistrict.SelectedValue = dtGetData.Rows[0]["DistCode"].ToString();

                    BindRevMandal();

                    ddlMandal.SelectedValue = dtGetData.Rows[0]["Mandal"].ToString();
                    if (dtGetData.Rows[0]["DistCode"].ToString() == "31")
                    {
                        BindRevdistVill();
                        ddlLocality.SelectedValue = dtGetData.Rows[0]["Village"].ToString();

                    }
                    else
                    {
                        ddlLocality.ClearSelection();
                        BindVillage();

                        if (!string.IsNullOrEmpty(ddlLocality.SelectedValue))
                        {
                           
                            ddlLocality.SelectedValue = dtGetData.Rows[0]["Village"].ToString();
                        }
                        else
                        {
                            ddlLocality.SelectedValue = dtGetData.Rows[0]["Village"].ToString();
                        }
                    }
                }

                else
                {

                    objCommon.ShowAlertMessage("No Data Found...");
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("../Error.aspx");
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                objBE = new Supplier_BE();
                DataTable dt1 = new DataTable();
                objBE.Reg_Code = txtAppRegNO.Text.ToString();
                //Session["AppRegNo_SHO"].ToString();// txtAppReg_NO.Text; /*Session["RegId"].ToString();//"360200001423"; //*/
                objBE.DistCode = ddlRevDistrict.SelectedValue;
                objBE.MandCode = ddlMandal.SelectedValue;
                objBE.VillCode = ddlLocality.SelectedValue;
                //objBE.ExDistCode = dtGetData.Rows[0]["ExDist_Cd"].ToString();
                bool result = false;

                result = objDL.Mandal_Update(objBE, ConnKey);
                if (result)
                {
                    lblError.Text = "Updated Successfully..";
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblErrorMessage.Text = "Updated Successfully..";
                    lblErrorMessage.ForeColor = System.Drawing.Color.Green;
                    diveventMandal.Visible = false;
                    txtAppRegNO.Text = "";


                    objCommon.ShowAlertMessage("Updated Successfully..");

                }
                else
                {
                    lblError.Text = "Please check the values...";
                    lblError.ForeColor = System.Drawing.Color.Red;

                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}