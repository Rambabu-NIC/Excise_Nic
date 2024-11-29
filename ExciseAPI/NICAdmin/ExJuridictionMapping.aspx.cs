using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;

namespace ExciseAPI.NICAdmin
{
    public partial class ExJuridictionMapping : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();

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
            if (Session["Role"] != null && Session["Role"].ToString() == "9" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                //BindTypeofManf();           
                BindDistrict();
                //random();
                btn_Save.Visible = false;

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
                objCommon.BindDropDownLists(ddlDistrict, dt1, "DistName", "DistCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindExDistricts()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.DistCode = ddlDistrict.SelectedValue.ToString();
                objBE.Action = "ED";
                dt = objDL.DistrictStationMapping(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlExDistrict, dt, "ExDist", "ExDist_Cd", "0");

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindExStations()
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.DistCode = ddlDistrict.SelectedValue.ToString();
                objBE.ExDistCode = ddlExDistrict.SelectedValue.ToString();
                objBE.Action = "ES";
                dt1 = objDL.DistrictStationMapping(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlExStation, dt1, "ExStation", "ExStationCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        public void BindMandals()
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.DistCode = ddlDistrict.SelectedValue.ToString();
                objBE.ExDistCode = ddlExDistrict.SelectedValue.ToString();
                objBE.ExStation = ddlExStation.SelectedValue.ToString();
                objBE.Action = "JM";
                dt1 = objDL.DistrictStationMapping(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlMandal, dt1, "MandName", "MandCode", "0");
                // Viewdata();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected bool Validate()
        {
            if (ddlDistrict.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Please Select District");
                ddlDistrict.Focus();
                return false;
            }
            if (ddlExDistrict.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Please Select Excise District");
                ddlExDistrict.Focus();
                return false;
            }
            if (ddlExStation.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Please Select Excise Station");
                ddlExStation.Focus();
                return false;
            }
            if (ddlMandal.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Please Select Excise Mandal");
                ddlMandal.Focus();
                return false;
            }
            return true;
        }

        protected DataTable CreateDt()
        {
            DataTable ddt = new DataTable();
            ddt.Columns.Add("DistCode", typeof(string));
            ddt.Columns.Add("ExDistCode", typeof(string));
            ddt.Columns.Add("ExStationCode", typeof(string));
            ddt.Columns.Add("MandCode", typeof(string));
            ddt.Columns.Add("VillCode", typeof(string));
            ddt.Columns.Add("VillName", typeof(string));
            ddt.Columns.Add("GHMC", typeof(string));
            return ddt;
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    DataTable ddt = new DataTable();
                    ddt = CreateDt();
                    int i = 0;
                    foreach (GridViewRow gr in GvDF.Rows)
                    {
                        if (((CheckBox)gr.FindControl("ChkSelect")).Checked == true)
                        {
                            ddt.Rows.Add();
                            ddt.Rows[i]["DistCode"] = ddlDistrict.SelectedValue.ToString();
                            ddt.Rows[i]["ExDistCode"] = ddlExDistrict.SelectedValue.ToString();
                            ddt.Rows[i]["ExStationCode"] = ddlExStation.SelectedValue.ToString();
                            ddt.Rows[i]["MandCode"] = ddlMandal.SelectedValue.ToString();
                            ddt.Rows[i]["VillCode"] = ((Label)gr.FindControl("lblVillCode")).Text.Trim();
                            ddt.Rows[i]["VillName"] = ((Label)gr.FindControl("lblVillName")).Text.Trim();
                            ddt.Rows[i]["GHMC"] = ((RadioButtonList)gr.FindControl("rblGHMC")).SelectedValue.Trim();

                            i++;
                        }
                    }

                    objBE.DistCode = ddlDistrict.SelectedValue;
                    objBE.ExDistCode = ddlExDistrict.SelectedValue;
                    objBE.ExStation = ddlExStation.SelectedValue;
                    objBE.MandCode = ddlMandal.SelectedValue;
                    //objBE.NameOfPerm = ddlExStation.SelectedItem.Text.Trim();
                    objBE.TVP = ddt;
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.UserName = Session["User"].ToString();
                    objBE.Action = "UV";
                    DataTable dt = new DataTable();
                    dt = objDL.DistrictStationMapping(objBE, Session["ConnKey"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        //Viewdata();
                        //Clear();

                        //btn_Save.Visible = false;
                        //GvDF.Visible = false;
                        //GvDF.DataSource = null;
                        //GvDF.DataBind();
                        //dt.Dispose();
                    }
                }

            }
            catch (Exception EX)
            {
                objCommon.ShowAlertMessage("Duplicate Record/ Selected Already existed mandal");//EX.Message
                return;

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
        public void Clear()
        {
            ddlDistrict.ClearSelection();
            ddlExDistrict.ClearSelection();
            ddlExStation.ClearSelection();
            ddlMandal.ClearSelection();

        }
        protected void Viewdata()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                
                objBE.DistCode = ddlDistrict.SelectedValue;
                objBE.ExDistCode = ddlExDistrict.SelectedValue;
                objBE.ExStation = ddlExStation.SelectedValue;
                objBE.MandCode = ddlMandal.SelectedValue;
                objBE.Action = "GVV";
                dt = objDL.DistrictStationMapping(objBE, Session["ConnKey"].ToString());

                if (dt.Rows.Count > 0)
                {
                    Jur.Visible = true;
                    btn_Save.Visible = true;
                    GvDF.Visible = true;
                    GvDF.DataSource = dt;
                    GvDF.DataBind();
                    dt.Dispose();
                }
                else
                {
                    //objCommon.ShowAlertMessage("No Data Found For This ");
                    GvDF.Visible = false;

                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void GvDF_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ghmc = DataBinder.Eval(e.Row.DataItem, "GHMC").ToString();
                // string ghmc = (string)?null:"N";
                if (string.IsNullOrEmpty(ghmc))
                    ghmc = "N";

                RadioButtonList rb = (RadioButtonList)e.Row.FindControl("rblGHMC");

                rb.Items.FindByValue(ghmc.ToString()).Selected = true;

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
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindExDistricts();
        }
        protected void ddlExDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindExStations();
        }
        protected void ddlExStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Viewdata();
            BindMandals();
        }
        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Viewdata();
        }



        //protected void btn_Update_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Validate())
        //        {
        //            objBE.Type_of_Duties = txt_TypeDuty.Text;
        //            objBE.Id = lblTDOK.Text;
        //            //objBE.SubHead = ddlSubHead.SelectedValue;
        //            //objBE.Type_of_Manu = ddl_Manuf.SelectedValue;
        //            objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
        //            objBE.UserName = Session["User"].ToString();
        //            objBE.Action = "U";
        //            DataTable dt = new DataTable();
        //            dt = objDL.DistrictStationMapping(objBE, Session["ConnKey"].ToString());
        //            if (dt.Rows.Count > 0)
        //            {
        //                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
        //                Viewdata();
        //                Clear();
        //                btn_Save.Visible = true;
        //                btn_Update.Visible = false;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}


        //protected void GvDF_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName == "edt")
        //        {
        //            DataTable dt = new DataTable();
        //            GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        //            //txt_TypeDuty.Text = ((Label)(gRow.FindControl("lblDFDes"))).Text;
        //            //lblTDOK.Text = ((Label)(gRow.FindControl("lblTD"))).Text;
        //            btn_Save.Visible = false;
        //            // btn_Update.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}
    }
}