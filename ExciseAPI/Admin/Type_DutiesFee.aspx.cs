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
    public partial class Type_DutiesFee : System.Web.UI.Page
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
                BindTypeofManf();
                //random();


            }
        }

        public void BindTypeofManf()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Action = "R";
                dt = ObjMDL.TypeofManufacturing_IUR(objBE, Session["ConnKey"].ToString());
                if (dt.Rows.Count > 0)
                {
                    objCommon.BindDropDownLists(ddl_Manuf, dt, "Type_Man_Nm", "Type_Man_Cd", "0");
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found For This ");
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }
        protected bool Validate()
        {


            if (txt_TypeDuty.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Type of Duties/Fee");
                txt_TypeDuty.Focus();
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
                    objBE.Type_of_Duties = txt_TypeDuty.Text;
                    objBE.MinorHead = ddlMinorHead.SelectedValue;
                    objBE.SubHead = ddlSubHead.SelectedValue;
                    objBE.Type_of_Manu = ddl_Manuf.SelectedValue;
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.UserName = Session["User"].ToString();
                    objBE.Action = "I";
                    DataTable dt = new DataTable();
                    dt = objDL.Duties_IUR(objBE, Session["ConnKey"].ToString());
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
        public void BindMinorHead()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Type_of_Manu = ddl_Manuf.SelectedValue;
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
        public void BindSubHead()
        {
            try
            {

                DataTable dt1 = new DataTable();
                objBE.Type_of_Manu = ddl_Manuf.SelectedValue;
                objBE.MinorHead = ddlMinorHead.SelectedValue;
                objBE.Action = "SH";
                dt1 = objDL.CommonMasters(objBE, Session["ConnKey"].ToString());
                objCommon.BindDropDownLists(ddlSubHead, dt1, "Sub_Head_Desc", "Sub_Head_Code", "0");
                // Viewdata();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");

            }
        }
        protected void GvDF_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "edt")
                {
                    DataTable dt = new DataTable();

                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    // ddl_Manuf.SelectedValue = ((Label)(gRow.FindControl("lblTypeCd"))).ToString();
                    // ddlMinorHead.SelectedValue = ((Label)(gRow.FindControl("lblMHCd"))).Text;
                    // ddlSubHead.SelectedValue = ((Label)(gRow.FindControl("lblSHNM"))).Text;
                    txt_TypeDuty.Text = ((Label)(gRow.FindControl("lblDFDes"))).Text;
                    lblTDOK.Text = ((Label)(gRow.FindControl("lblTD"))).Text;
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
            ddlMinorHead.SelectedIndex = 0;
            ddlSubHead.SelectedIndex = 0;
            ddl_Manuf.SelectedIndex = 0;
            txt_TypeDuty.Text = "";



        }
        protected void Viewdata()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                objBE.SubHead = ddlSubHead.SelectedValue;
                objBE.Action = "R";
                dt = objDL.Duties_IUR(objBE, Session["ConnKey"].ToString());

                if (dt.Rows.Count > 0)
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    data1.Visible = true;
                    GvDF.Visible = true;
                    GvDF.DataSource = dt;
                    GvDF.DataBind();
                    dt.Dispose();



                }
                else
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    //objCommon.ShowAlertMessage("No Data Found For This ");
                    data1.Visible = false;
                    GvDF.Visible = false;

                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
       
        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    objBE.Type_of_Duties = txt_TypeDuty.Text;
                    objBE.Id = lblTDOK.Text;
                    // objBE.SubHead = ddlSubHead.SelectedValue;
                    //  objBE.Type_of_Manu = ddl_Manuf.SelectedValue;
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.UserName = Session["User"].ToString();
                    objBE.Action = "U";
                    DataTable dt = new DataTable();
                    dt = objDL.Duties_IUR(objBE, Session["ConnKey"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        Viewdata();
                        Clear();
                        btn_Save.Visible = true;
                        btn_Update.Visible = false;
                    }
                }

            }
            catch
            {

            }

        }

        protected void ddlMinorHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubHead();

        }
        protected void ddl_Manuf_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMinorHead();
        }
        protected void ddlSubHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            Viewdata();
        }
    }
}