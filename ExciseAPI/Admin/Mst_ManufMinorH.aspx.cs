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
    public partial class Mst_ManufMinorH : System.Web.UI.Page
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
                BindTypeofManf();
                //Viewdata();
                //random();


            }
        }


        protected bool Validate()
        {
            if (ddl_Manuf.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Select Type Of Manfactring");
                ddl_Manuf.Focus();
                return false;
            }

            if (txt_MinorCd.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Minor Head Code");
                txt_MinorCd.Focus();
                return false;
            }

            if (txt_MinorNm.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Minor Head Description");
                txt_MinorNm.Focus();
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
                    objBE.Type_of_Manu = ddl_Manuf.SelectedValue;
                    objBE.MinorHead = txt_MinorCd.Text;
                    objBE.MinorHeadDesc = txt_MinorNm.Text;
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    // objBE.UserName = Session["User"].ToString();
                    objBE.Action = "I";
                    DataTable dt = new DataTable();
                    dt = objDL.Minor_IUR(objBE, Session["ConnKey"].ToString());
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



        protected void GvDF_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "edt")
                {
                    DataTable dt = new DataTable();

                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    txt_MinorNm.Text = ((Label)(gRow.FindControl("lblMHNM"))).Text;
                    txt_MinorCd.Text = ((Label)(gRow.FindControl("lblMHCd"))).Text;
                    lblidok.Text = ((Label)(gRow.FindControl("lblID"))).Text;
                    ddl_Manuf.SelectedValue = ((Label)(gRow.FindControl("lblTypeCd"))).Text;

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


        protected void Viewdata()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                // objBE.ApplicantId = Session["ApplicantId"].ToString();
                // objRegBE.System = Session["System"].ToString();
                objBE.Type_of_Manu = ddl_Manuf.SelectedValue;
                objBE.Action = "R";
                dt = objDL.Minor_IUR(objBE, Session["ConnKey"].ToString());

                if (dt.Rows.Count > 0)
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    DivDF.Visible = true;
                    GvDF.Visible = true;
                    GvDF.DataSource = dt;
                    GvDF.DataBind();
                    dt.Dispose();



                }
                else
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    //objCommon.ShowAlertMessage("No Data Found For This ");
                    DivDF.Visible = false;
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
                    objBE.Id = lblidok.Text;
                    objBE.Type_of_Manu = ddl_Manuf.SelectedValue;
                    objBE.MinorHead = txt_MinorCd.Text;
                    objBE.MinorHeadDesc = txt_MinorNm.Text;
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    // objBE.UserName = Session["User"].ToString();
                    objBE.Action = "U";
                    DataTable dt = new DataTable();
                    dt = objDL.Minor_IUR(objBE, Session["ConnKey"].ToString());
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


        protected void ddl_ManufSelectedIndexChanged(object sender, EventArgs e)
        {
            Viewdata();
        }
        public void Clear()
        {
            txt_MinorNm.Text = "";
            txt_MinorCd.Text = "";
            ddl_Manuf.SelectedIndex = 0;



        }
    }
}