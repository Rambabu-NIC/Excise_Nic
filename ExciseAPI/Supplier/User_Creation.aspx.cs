﻿using System;
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
    public partial class User_Creation : System.Web.UI.Page
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
                dt1 = objDL.Duties_IUR(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlTypeofmanu, dt1, "DF_Descr", "DF_Code", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }



        protected bool Validate()
        {


            //if (txtMajor.Text != "")
            //{
            //    objCommon.ShowAlertMessage("Enter Major Head");
            //    txtMajor.Focus();
            //    return false;
            //}
            //if (txt_Minor.Text != "")
            //{
            //    objCommon.ShowAlertMessage("Enter Minor Head");
            //    txt_Minor.Focus();
            //    return false;
            //}
            //if (txt_GPHead.Text != "")
            //{
            //    objCommon.ShowAlertMessage("Enter Group Head");
            //    txt_GPHead.Focus();
            //    return false;
            //}
            //if (txt_SubHead.Text != "")
            //{
            //    objCommon.ShowAlertMessage("Enter Sub Head");
            //    txt_GPHead.Focus();
            //    return false;

            //}
            //  if (txt_DetHead.Text != "")
            //{
            //    objCommon.ShowAlertMessage("Enter Detailed Head");
            //    txt_DetHead.Focus();
            //    return false;
            //}
            //   if (txt_SubDtHead.Text != "")
            //{
            //    objCommon.ShowAlertMessage("Enter Sub Detailed Head");
            //    txt_SubDtHead.Focus();
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
                    objBE.HOACode = ddlTypeofmanu.SelectedValue;
                    objBE.MajorHead = txtMajor.Text;
                    objBE.MinorHead = txt_Minor.Text;
                    //objBE.GPHead = txt_GPHead.Text;
                    //objBE.SubHead = txt_SubHead.Text;
                    //objBE.DtHead = txt_DetHead.Text;
                    //objBE.SubDtHead = txt_SubDtHead.Text;
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.UserName = Session["User"].ToString();
                    objBE.Action = "I";
                    DataTable dt = new DataTable();
                    dt = objDL.HOA_IUDR(objBE, Session["ConnKey"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        Viewdata();

                    }
                }

            }
            catch
            {

            }
        }

        protected void GvHOA_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "edt")
                {
                    //DataTable dt = new DataTable();

                    //GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                    //txtMajor.Text = ((Label)(gRow.FindControl("lblMajHead"))).Text;
                    //txt_Minor.Text = ((Label)(gRow.FindControl("lblMinHead"))).Text;
                    //txt_GPHead.Text = ((Label)(gRow.FindControl("lblGPHead"))).Text;
                    //txt_SubHead.Text = ((Label)(gRow.FindControl("lblSubHead"))).Text;
                    //txt_DetHead.Text = ((Label)(gRow.FindControl("lblDtHead"))).Text;
                    //txt_SubDtHead.Text = ((Label)(gRow.FindControl("lblSubDtHead"))).Text;

                    //btn_Save.Visible = false;
                    //btn_Update.Visible = true;


                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void GvHOA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvHOA.PageIndex = e.NewPageIndex;
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
                dt = objDL.HOA_IUDR(objBE, Session["ConnKey"].ToString());

                if (dt.Rows.Count > 0)
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    GvHOA.Visible = true;
                    GvHOA.DataSource = dt;
                    GvHOA.DataBind();
                    dt.Dispose();



                }
                else
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    //objCommon.ShowAlertMessage("No Data Found For This ");
                    GvHOA.Visible = false;

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

    }
}