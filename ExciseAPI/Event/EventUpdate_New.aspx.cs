using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Event
{
    public partial class EventUpdate_New : System.Web.UI.Page
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
            if (!IsPostBack)
            {

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                //lblUSer.Text = Session["UsrName"].ToString();
                //BindTypeofManf();           

                random();
                //btn_Save.Visible = false;
                data.Visible = false;
            }
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
        protected void GvDF_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                //GvDF.PageIndex = e.NewPageIndex;
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
                objBE.Action = "Dataget";
                dt = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt.Columns.Count == 1)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    return;
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        //btn_Save.Visible = true;
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
        public void random()
        {
            try
            {
                string strString = "abcdefghijklmnpqrstuvwxyzABCDQEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                string num = "";
                Random rm = new Random();
                for (int i = 0; i < 16; i++)
                {
                    int randomcharindex = rm.Next(0, strString.Length);
                    char randomchar = strString[randomcharindex];
                    num += Convert.ToString(randomchar);
                }
                hf.Value = num;
                Session["ASPFIXATION2"] = num;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
        public void check()
        {
            try
            {
                string cookie_value = null;
                string session_value = null;

                cookie_value = hf.Value;
                session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
                if (cookie_value != session_value)
                {
                    System.Web.HttpContext.Current.Session.Abandon();
                    HttpContext.Current.Response.Buffer = false;
                    HttpContext.Current.Response.Redirect("~/Error.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx", false);
            }
        }



        //protected void btn_Edit_Click(object sender, EventArgs e)
        //{
        //    txtTreasuryDate.Enabled = true;
        //    txtBankDate.Enabled = true;
        //    txtChallanNumber.Enabled = false;
        //    txtBankCode.Enabled = false;
        //    txtBankTransid.Enabled = false;
        //    txtDeptTransid.Enabled = false;
        //    //btn_Save.Visible = false;
        //}
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                objBE.Reg_Code = lblReg.Text; //txtRegistrationNO.Text;
                objBE.DeptTransid = txtDeptTransid.Text;
                objBE.ChallanNumber = txtChallanNumber.Text;
                objBE.TreasuryDate = DateTime.Parse(txtTreasuryDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;// txtTreasuryDate.Text;
                objBE.BankDate = DateTime.Parse(txtBankDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;// txtBankDate.Text;
                objBE.Action = "Update";

                dt = objDL.GetPaymentUpdateDtls(objBE, ConnKey);

                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage("Data Updated Successfully");
                    DivUpdate.Visible = false;

                }
                else
                {
                    objCommon.ShowAlertMessage("Data Not Updated");
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());

            }
        }
        protected void GvDF_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edt")
                {
                    DataTable dt = new DataTable();
                    objBE = new Supplier_BE();
                    GridViewRow gERow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    int rowIndex = gERow.RowIndex;
                    objBE.Reg_Code = txtRegistrationNO.Text;
                    objBE.Action = "Dataget";
                    dt = objDL.EventReg_IUR(objBE, ConnKey);
                    DataView dvSelectedApplication = new DataView(dt);
                    DataRow drow = dvSelectedApplication.ToTable().Rows[rowIndex];
                    lblReg.Text = drow["AppReg_No"].ToString();
                    txtChallanNumber.Text = drow["ChallanNumber"].ToString();
                    txtTreasuryDate.Text = drow["TreasuryDate"].ToString();
                    txtBankDate.Text = drow["BankDate"].ToString();
                    txtBankCode.Text = drow["BankCode"].ToString();
                    txtBankTransid.Text = drow["BankTransid"].ToString();
                    txtDeptTransid.Text = drow["DeptTransid"].ToString();
                    txtTreasuryDate.Enabled = true;
                    txtBankDate.Enabled = true;
                    txtChallanNumber.Enabled = false;
                    txtBankCode.Enabled = false;
                    txtBankTransid.Enabled = false;
                    txtDeptTransid.Enabled = false;
                    DivUpdate.Visible = true;

                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }
    }
}