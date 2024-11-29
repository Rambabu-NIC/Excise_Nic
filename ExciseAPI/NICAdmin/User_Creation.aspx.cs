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
    public partial class User_Creation : System.Web.UI.Page
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
                //random();
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

        protected void ddlRoleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRoleType.SelectedIndex > 0)
            {
                nform.Visible = true;
            }
            else
            {
                nform.Visible = false;
            }
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
        public bool ValidateSave()
        {
            if (txtUserName.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter User Name");
                txtUserName.Focus();
                return false;
            }
            if (txtMobileNo.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter Mobile Number");
                txtMobileNo.Focus();
                return false;
            }


            return true;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSave())
                {
                    dt = new DataTable();
                    dt = CreateDt();
                    int i = 0;
                    //foreach (GridViewRow gr in GvSupplier.Rows)
                    //{
                    //    if (((CheckBox)gr.FindControl("chk")).Checked)
                    //    {
                    dt.Rows.Add();
                    dt.Rows[i]["UserName"] = txtUserName.Text;// ((Label)gr.FindControl("lblSuppCode")).Text.Trim();
                    dt.Rows[i]["Mobile"] = txtMobileNo.Text;//((Label)gr.FindControl("lblMobile")).Text.Trim();
                    dt.Rows[i]["Role"] = ddlRoleType.SelectedValue.ToString().Trim();//;
                    dt.Rows[i]["Statecode"] = "36";
                    dt.Rows[i]["Distcode"] = "";//((Label)gr.FindControl("lblDistcode")).Text.Trim();
                    dt.Rows[i]["MandCode"] = "";//((Label)gr.FindControl("lblMandcode")).Text.Trim();
                    dt.Rows[i]["Villcode"] = "";//((Label)gr.FindControl("lblVillcode")).Text.Trim();
                                                // i++;
                                                //    }
                                                //}
                                                //if (dt.Rows.Count <= 0)
                                                //{
                                                //    objCommon.ShowAlertMessage("Please select atleast one record");
                                                //    return;
                                                //}
                    objBE.Action = "EPI";
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.TVP = dt;
                    DataTable ddt = ObjMDL.UserCreation_IUDR(objBE, Session["ConnKey"].ToString());
                    if (ddt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(ddt.Rows[0][0].ToString());
                        // Getdata();
                    }
                }

            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                // Response.Redirect("~/Error.aspx");
            }
        }

    }
}