using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Configuration;
using System.Data;

namespace ExciseAPI.Event
{
    public partial class EventDetails : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Validate objValidate = new Validate();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetEventPermitData();
        }
        protected void GetEventPermitData()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                if (!string.IsNullOrEmpty(Session["RptStatus"].ToString()))
                {
                    objBE.AppName = Session["RptStatus"].ToString();
                    if (Session["RptStatus"].ToString() == "4")
                    { objBE.Action = "DBDPI"; }
                    else if (Session["RptStatus"].ToString() == "1,2,3") { objBE.Action = "DBDPC"; }
                    else { objBE.Action = "DBDMY"; }

                    dt = objDL.EventReg_IUR(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        GvRptDtls.Visible = true;
                        GvRptDtls.DataSource = dt;
                        GvRptDtls.DataBind();
                        dt.Dispose();
                    }
                    else
                    {
                        GvRptDtls.Visible = false;
                        objCommon.ShowAlertMessage("No Data Found");
                        return;
                    }

                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void GvRptDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                GvRptDtls.PageIndex = e.NewPageIndex;
                GetEventPermitData();
                //if (gridData.Text == "A")
                //{
                //    if (dateGrid.Text.ToString() == "1")
                //        getData(appType.Text.ToString());
                //    else if (dateGrid.Text.ToString() == "2")
                //        getDataReg(appType.Text.ToString());
                //}
                //else if (gridData.Text == "F")
                //{
                //    getDataF(appType.Text.ToString());
                //}


            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }
        }

    }
}