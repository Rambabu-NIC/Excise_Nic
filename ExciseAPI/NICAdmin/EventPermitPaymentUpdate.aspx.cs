using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_BE;
using Excise_DAL;
using System.Data;
using System.Configuration;

namespace ExciseAPI.NICAdmin
{
    public partial class EventPermitPaymentUpdate : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
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
            ///*KILL COOKIE & clear Caching*/
            //PrevBrowCache.enforceNoCache();
            //if (Session["Role"] != null && Session["Role"].ToString() == "9" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            //{
            //    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
            //    {
            //        Response.Redirect("~/Error.aspx");
            //    }
            //}
            //else
            //{
            //    Response.Redirect("~/Error.aspx");
            //}

            if (!IsPostBack)
            {

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                //lblUSer.Text = Session["UsrName"].ToString();
                //BindTypeofManf();           

                //random();
                btn_Save.Visible = false;
                data.Visible = false;
            }
        }



        protected bool Validate()
        {
            if (txtRegistrationNO.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter Registration No");
                txtRegistrationNO.Focus();
                return false;
            }

            return true;
        }
        protected bool ValidateSave()
        {
            if (txtChallanNumber.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter ChallanNumber");
                txtChallanNumber.Focus();
                return false;
            }
            if (txtTreasuryDate.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter TreasuryDate");
                txtTreasuryDate.Focus();
                return false;
            }
            if (txtBankDate.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter BankDate");
                txtBankDate.Focus();
                return false;
            }
            if (txtBankCode.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter BankCode");
                txtBankCode.Focus();
                return false;
            }
            if (txtBankTransid.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter BankTransid");
                txtBankTransid.Focus();
                return false;
            }
            if (txtDeptTransid.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter  Dept Trans ID");
                txtDeptTransid.Focus();
                return false;
            }

            return true;
        }

        protected void btn_Get_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    Viewdata();
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSave())
                {


                    objBE.BankStatus = "Success";
                    objBE.ChallanNumber = txtChallanNumber.Text;
                    objBE.TreasuryDate = DateTime.Parse(txtTreasuryDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;// txtTreasuryDate.Text;
                    objBE.BankDate = DateTime.Parse(txtBankDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;// txtBankDate.Text;
                    objBE.BankCode = txtBankCode.Text;
                    objBE.BankTransid = txtBankTransid.Text;
                    objBE.DeptTransid = txtDeptTransid.Text;
                    objBE.SupplierName = txtRegistrationNO.Text;//Reg_Code
                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    objBE.UserName = Session["User"].ToString();
                    objBE.Action = "PUM";
                    DataTable dt = new DataTable();
                    dt = objDL.GetPaymentUpdateDtls(objBE, ConnKey);
                    // dt = objDL.u(objBE, Session["ConnKey"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        Viewdata();

                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());

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
            txtRegistrationNO.Text = "";
        }
        protected void Viewdata()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                objBE.Reg_Code = txtRegistrationNO.Text;
                objBE.Action = "PGR";
                dt = objDL.EventReg_IUR(objBE, Session["ConnKey"].ToString());
                if (dt.Columns.Count == 1)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    return;
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        btn_Save.Visible = true;
                        data.Visible = true;
                        GvDF.Visible = true;
                        GvDF.DataSource = dt;
                        GvDF.DataBind();
                        dt.Dispose();
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("No Data Found");
                        GvDF.Visible = false;
                        data.Visible = false;
                    }
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



        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            txtTreasuryDate.Enabled = true;
            txtBankDate.Enabled = true;
            txtChallanNumber.Enabled = false;
            txtBankCode.Enabled = false;
            txtBankTransid.Enabled = false;
            txtDeptTransid.Enabled = false;
            btn_Save.Visible = false;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objBE.Reg_Code = txtRegistrationNO.Text;
                objBE.TreasuryDate = DateTime.Parse(txtTreasuryDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;// txtTreasuryDate.Text;
                objBE.BankDate = DateTime.Parse(txtBankDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;// txtBankDate.Text;
                objBE.Action = "Update";

                dt = objDL.GetPaymentUpdateDtls(objBE, ConnKey);

                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage("Data Updated Successfully");

                }
                else
                {
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());

            }
        }
    }
}