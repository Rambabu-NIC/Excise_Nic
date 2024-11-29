using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Admin
{
    public partial class TypeOfPayment : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (string.IsNullOrEmpty(txtTypeOfPayment.Text))
                {
                    lblError.Text = "Please Enter Type Of Payment";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                DataTable dt = new DataTable();
                dt = new DataTable();
                //objBE.TypePayment
                objBE.PaymentDesc = txtTypeOfPayment.Text;



                bool result = objDL.Type_Of_Payment(objBE, ConnKey);
                if (result)
                {
                    txtTypeOfPayment.Text = "";
                    objCommon.ShowAlertMessage("Saved Successfully");
                    //clear();
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");

                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }
    }
}