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
    public partial class Mst_TypeOfManufacturing : System.Web.UI.Page
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

                Viewdata();
                //random();


            }
        }
        protected bool Validate()
        {


            if (txtType.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Type of Manufacturing");
                txtType.Focus();
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
                    objBE.Type_of_Manu = txtType.Text;
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.Action = "I";
                    DataTable dt = new DataTable();
                    dt = ObjMDL.TypeofManufacturing_IUR(objBE, Session["ConnKey"].ToString());
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


        protected void GvDF_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "edt")
                {
                    DataTable dt = new DataTable();

                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    txtType.Text = ((Label)(gRow.FindControl("lbltype"))).Text;
                    ViewState["Id"] = ((Label)(gRow.FindControl("lblID"))).Text;
                    // Label labDFCode = ((Label)(gRow.FindControl("lblDF_Code"))).Text;
                    // //GoDownId.Value = ((Label)(gRow.FindControl("lblSuppCode"))).Text;

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
                objBE.Action = "R";
                dt = ObjMDL.TypeofManufacturing_IUR(objBE, Session["ConnKey"].ToString());

                if (dt.Rows.Count > 0)
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    GvDF.Visible = true;
                    GvDF.DataSource = dt;
                    GvDF.DataBind();
                    dt.Dispose();



                }
                else
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
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


       

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    objBE.Type_of_Manu = txtType.Text;
                    objBE.Id = ViewState["Id"].ToString();
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.Action = "U";

                    DataTable dt = new DataTable();
                    dt = ObjMDL.TypeofManufacturing_IUR(objBE, Session["ConnKey"].ToString());
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


    }
}