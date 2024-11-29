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
    public partial class Rpt_User_Creation : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Login_DL ObjMDL = new Login_DL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        DataTable dt = new DataTable();
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
                //random();
                BindManufactory();
            }
        }
        public static string MaskMobileNumber(string mobileNumber)
        {
            // Ensure the input is exactly 10 digits long
            if (mobileNumber.Length != 10)
            {
                throw new ArgumentException("Invalid mobile number");
            }

            // Replace the first 6 digits with '*'
            string maskedMobile = new string('*', 6) + mobileNumber.Substring(6);

            return maskedMobile;
        }

        public static void Main()
        {
            string mobile = "9876543210"; // Example mobile number
            string maskedMobile = MaskMobileNumber(mobile);
            Console.WriteLine(maskedMobile);  // Output: ******3210
        }
        public void Getdata()
        {
            try
            {
                objBE.Status = ddlStatus.SelectedValue;
                objBE.Type_of_Manu = ddlManf.SelectedValue;
                objBE.Action = "U";
                DataTable dt = new DataTable();
                dt = ObjMDL.UserCreation_IUDR(objBE, Session["ConnKey"].ToString());
                if (dt.Rows.Count > 0)
                {
                    Div2.Visible = true;
                    //GvSupplier.Visible = true;
                    GvSupplier.DataSource = dt;
                    GvSupplier.DataBind();
                }
                else
                    Div2.Visible = false;
                //GvSupplier.Visible = false;
            }
            catch (Exception ex)
            {
                //Response.Redirect("~/Error.aspx", false);
            }
        }
        protected void ddlTypeofmanu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindManufactory();
            //if (ddlTypeofmanu.SelectedIndex > 0)

            //    Getdata();

            //else
            //{
            //    Div2.Visible = false;
            //    //GvSupplier.Visible = false;
            //}
        }
        protected DataTable CreateDt()
        {
            DataTable ddt = new DataTable();
            ddt.Columns.Add("UserName", typeof(string));
            ddt.Columns.Add("Mobile", typeof(string));
            ddt.Columns.Add("Role", typeof(string));
            ddt.Columns.Add("Statecode", typeof(string));
            ddt.Columns.Add("Distcode", typeof(string));
            ddt.Columns.Add("MandCode", typeof(string));
            ddt.Columns.Add("Villcode", typeof(string));
            return ddt;
        }
        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        dt = new DataTable();
        //        dt = CreateDt();
        //        int i = 0;
        //        foreach (GridViewRow gr in GvSupplier.Rows)
        //        {
        //            if (((CheckBox)gr.FindControl("chk")).Checked)
        //            {
        //                dt.Rows.Add();
        //                dt.Rows[i]["UserName"] = ((Label)gr.FindControl("lblSuppCode")).Text.Trim();
        //                dt.Rows[i]["Mobile"] = ((Label)gr.FindControl("lblMobile")).Text.Trim();
        //                dt.Rows[i]["Role"] = "1";
        //                dt.Rows[i]["Statecode"] = "36";
        //                dt.Rows[i]["Distcode"] = ((Label)gr.FindControl("lblDistcode")).Text.Trim();
        //                dt.Rows[i]["MandCode"] = ((Label)gr.FindControl("lblMandcode")).Text.Trim();
        //                dt.Rows[i]["Villcode"] = ((Label)gr.FindControl("lblVillcode")).Text.Trim();
        //                i++;
        //            }
        //        }
        //        if (dt.Rows.Count <= 0)
        //        {
        //            objCommon.ShowAlertMessage("Please select atleast one record");
        //            return;
        //        }
        //        objBE.Action = "I";
        //        objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
        //        objBE.TVP = dt;
        //        DataTable ddt = ObjMDL.UserCreation_IUDR(objBE, Session["ConnKey"].ToString());
        //        if (ddt.Rows.Count > 0)
        //        {
        //            objCommon.ShowAlertMessage(ddt.Rows[0][0].ToString());
        //            Getdata();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //       // Response.Redirect("~/Error.aspx");
        //    }
        //}
        protected void GvSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //try
            //{
            //    GvSupplier.PageIndex = e.NewPageIndex;
            //    Getdata();
            //}
            //catch (Exception ex)
            //{
            //    ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            //    objCommon.ShowAlertMessage(ex.ToString());
            //}
        }
        public void BindManufactory()
        {
            try
            {

                try
                {

                    DataTable dt1 = new DataTable();
                    objBE.Action = "R";
                    dt1 = objDL.ManufacoryMasters(objBE, Session["ConnKey"].ToString());
                    objCommon.BindDropDownLists_WithAll_0_Option_Last(ddlManf, dt1, "Type_Man_Nm", "Type_Man_Cd", "99");
                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                    Response.Redirect("~/Error.aspx");
                }

                //objCommon.BindDropDownLists_WithAll_0_Option_Last(ddlManf, dt1, "Type_Man_Nm", "Type_Man_Cd", "99");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void GvSupplier_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Find the Label control inside the TemplateField
                Label lblMobile = (Label)e.Row.FindControl("lblMobile");

                if (lblMobile != null)
                {
                    string mobileNumber = lblMobile.Text;

                    // Ensure the mobile number is exactly 10 digits long
                    if (mobileNumber.Length == 10)
                    {
                        // Mask the first 6 digits of the mobile number
                        string maskedMobile = new string('*', 6) + mobileNumber.Substring(6);
                        lblMobile.Text = maskedMobile; // Replace the original number with the masked one
                    }
                }
            }
        }

        protected void BtnGetData_Click(object sender, EventArgs e)
        {
            Getdata();
        }
    }
}