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
    public partial class HOA : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();

        protected void Page_Load(object sender, EventArgs e)
        {

           
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && (Session["Role"].ToString() == "1" || Session["Role"].ToString() == "50") && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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

                BindManufactory();
                Viewdata();
                //random();


            }
        }

        public void BindMinorHead()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Type_of_Manu = ddlManFac.SelectedValue;
                objBE.Action = "MH";
                dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlMinorHead, dt1, "Minor_Head_Desc", "Minor_Head_Code", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindManufactory()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Action = "R";
                dt1 = objDL.ManufacoryMasters(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlManFac, dt1, "Type_Man_Nm", "Type_Man_Cd", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        public void BindSubHead()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Action = "SH";
                objBE.Type_of_Manu = ddlManFac.SelectedValue;
                objBE.MinorHead = ddlMinorHead.SelectedValue;
                dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlSubHead, dt1, "Sub_Head_Desc", "Sub_Head_Code", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        //public void BindReceipts()
        //{
        //    try
        //    {

        //        DataTable dt1 = new DataTable();
        //        objBE.Action = "TR";
        //        objBE.MajorHead = txtMajor.Text;
        //        objBE.MinorHead = ddlMinorHead.SelectedValue;
        //        objBE.SubHead= ddlSubHead.SelectedValue;
        //        dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
        //        objCommon.BindDropDownLists(ddlReceipts, dt1, "Name_Of_Treasury", "", "0");
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //        Response.Redirect("~/Error.aspx");
        //    }
        //}

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
                    objBE.Type_of_Manu = ddlManFac.SelectedValue;
                    objBE.MajorHead = txtMajor.Text;
                    objBE.SubMajorHead = txtSMajor.Text;
                    objBE.MinorHead = ddlMinorHead.SelectedValue;
                    objBE.GPHead = txt_GPHead.Text;
                    objBE.SubHead = ddlSubHead.SelectedValue;
                    objBE.DtHead = txt_DetHead.Text;
                    objBE.SubDtHead = txt_SubDtHead.Text;
                    //objBE.NameOfTreasury = ddlReceipts.SelectedValue;
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.Action = "I";
                    DataTable dt = new DataTable();
                    dt = objDL.HOA_IUDR(objBE, Session["ConnKey"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        Viewdata();
                        Clear();

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
                    DataTable dt = new DataTable();

                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    BindManufactory();
                    lblIDok.Text = ((Label)(gRow.FindControl("lblID"))).Text;
                    ddlManFac.SelectedValue = ((Label)(gRow.FindControl("lblTypeMan"))).Text;

                    txtMajor.Text = ((Label)(gRow.FindControl("lblMajHead"))).Text;
                    txtSMajor.Text = ((Label)(gRow.FindControl("lblSMajHead"))).Text;
                    BindMinorHead();
                    ddlMinorHead.SelectedValue = ((Label)(gRow.FindControl("lblMinHead"))).Text;
                    txt_GPHead.Text = ((Label)(gRow.FindControl("lblGPHead"))).Text;
                    BindSubHead();
                    ddlSubHead.SelectedValue = ((Label)(gRow.FindControl("lblSubHead"))).Text.ToString().Trim();
                    txt_DetHead.Text = ((Label)(gRow.FindControl("lblDtHead"))).Text;
                    txt_SubDtHead.Text = ((Label)(gRow.FindControl("lblSubDtHead"))).Text;
                    btn_Save.Visible = false;
                    btn_Update.Visible = true;


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
                    divH.Visible = false;
                    GvHOA.Visible = false;

                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        

        protected void ddlMinorHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubHead();
        }

        //protected void ddlSubHead_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindReceipts();
        //}
        protected void ddlManFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMinorHead();
        }
        public void Clear()
        {
            txtMajor.Text = "";
            txtSMajor.Text = "";
            txt_GPHead.Text = "";
            txt_DetHead.Text = "";
            txt_SubDtHead.Text = "";
            ddlManFac.SelectedIndex = 0;
            ddlMinorHead.SelectedIndex = 0;
            ddlSubHead.SelectedIndex = 0;



        }
        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    objBE.Id = lblIDok.Text;
                    objBE.Type_of_Manu = ddlManFac.SelectedValue;
                    objBE.MajorHead = txtMajor.Text;
                    objBE.SubMajorHead = txtSMajor.Text;
                    objBE.MinorHead = ddlMinorHead.SelectedValue;
                    objBE.GPHead = txt_GPHead.Text;
                    objBE.SubHead = ddlSubHead.SelectedValue;
                    objBE.DtHead = txt_DetHead.Text;
                    objBE.SubDtHead = txt_SubDtHead.Text;
                    //objBE.NameOfTreasury = ddlReceipts.SelectedValue;
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.Action = "U";
                    DataTable dt = new DataTable();
                    dt = objDL.HOA_IUDR(objBE, Session["ConnKey"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        Viewdata();
                        Clear();

                    }
                }

            }
            catch
            {

            }

        }
    }
}