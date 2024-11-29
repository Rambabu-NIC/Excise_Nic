using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;

namespace ExciseAPI.NICAdmin
{
    public partial class Event_Permits : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        protected void Page_Load(object sender, EventArgs e)
        {
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

                //BindPermits();

            }


        }

   

       
        //protected void GvPermits_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //}

        //protected void GvPermits_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //}

        protected void lnkDetailedView_Click(object sender, EventArgs e)
        {
            BindGrid();
        }


        public void BindGrid()
        {
            try
            {

                
                DataTable dt1 = new DataTable();
                String FromDate = null;
                String ToDate = null;
                if (!string.IsNullOrEmpty(txtFrom.Text.ToString()) && !string.IsNullOrEmpty(txtTo.Text.ToString()))
                {
                    FromDate = txtFrom.Text.ToString();
                    ToDate = txtTo.Text.ToString();
                    objBE.FDate = FromDate;
                    objBE.TDate = ToDate;
                }
                else
                {
                    objBE.FDate = FromDate;
                    objBE.TDate = ToDate;
                }
                dt1 = objDL.Events_DetailedView(objBE, ConnKey);
                        if (dt1.Rows.Count > 0)
                        {
                            Div3.Visible = true;
                            GvDetailedView.DataSource = dt1;
                            GvDetailedView.DataBind();
                            dt1.Dispose();
                        }
                    }
                  
                
            
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }



        public void BindPermits()
        {
            try
            {

                
                DataTable dt1 = new DataTable();
                String FromDate = null;
                String ToDate = null;
                if (!string.IsNullOrEmpty(txtFrom.Text.ToString()) && !string.IsNullOrEmpty(txtTo.Text.ToString()))
                {
                    FromDate = txtFrom.Text.ToString();
                    ToDate = txtTo.Text.ToString();
                    objBE.FDate = FromDate;
                    objBE.TDate = ToDate;
                }
                else
                {
                    objBE.FDate = FromDate;
                    objBE.TDate = ToDate;
                }
                dt1 = objDL.Events_Permits(objBE, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    //Div3.Visible = true;
                    GvPermits.Visible = true;
                    GvPermits.DataSource = dt1;
                    GvPermits.DataBind();
                    dt1.Dispose();
                }
                


            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void GvPermits_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvPermits.PageIndex = e.NewPageIndex;
        }

        protected void GvDetailedView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDetailedView.PageIndex = e.NewPageIndex;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            BindPermits();
        }
    }
}