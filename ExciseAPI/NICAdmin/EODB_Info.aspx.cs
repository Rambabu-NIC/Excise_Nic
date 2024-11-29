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
using System.Net;
using System.Text;

namespace ExciseAPI.NICAdmin
{
    
    public partial class EODB_Info : System.Web.UI.Page
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
                BindFormType();
            }
        }
        protected void BindFormType()
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = ObjMDL.GetEODB_FormsType(ConnKey);
                objCommon.BindDropDownLists(ddlFormType, dt1, "FormName", "FormID", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public DataTable FormType()
        {
            DataTable dtForms = new DataTable();
            dtForms.Columns.Add("Service_desc", typeof(string));
            dtForms.Columns.Add("Neworrenewal", typeof(int));
            dtForms.Columns.Add("NoofLicenceRegistered", typeof(int));
            dtForms.Columns.Add("NoofAppRec", typeof(int));
            dtForms.Columns.Add("NofAppAproved", typeof(int));
            return dtForms;
        }
        private DataTable dtFormtype
        {
            get
            {
                if(ViewState["dtFormtype"]== null)
                {
                    DataTable dt = FormType();
                    ViewState["dtFormtype"] = dt;
                }
                return ViewState["dtFormtype"] as DataTable;
            }
            set
            {
                ViewState["dtFormtype"] = value;
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string FormType = ddlFormType.SelectedValue;
            string FormDate = txtfrm.Text.ToString();
            string ToDate = txtto.Text.ToString();
            DataRow drForms = dtFormtype.NewRow();
            drForms["Service_desc"] = FormType;
            drForms["Neworrenewal"] = 1;
            drForms["NoofLicenceRegistered"] = txtLicenceNew.Text.ToString();
            drForms["NoofAppRec"] = txtApplicationsNew.Text.ToString();
            drForms["NofAppAproved"] = txtApprovedApplicationsNew.Text.ToString();
            dtFormtype.Rows.Add(drForms);

            drForms = dtFormtype.NewRow();
            drForms["Service_desc"] = FormType;
            drForms["Neworrenewal"] = 2;
            drForms["NoofLicenceRegistered"] = txtLicenceRenewal.Text.ToString();
            drForms["NoofAppRec"] = txtApplicationsRenewal.Text.ToString();
            drForms["NofAppAproved"] = txtApprovedApplicationsRenewal.Text.ToString();
            dtFormtype.Rows.Add(drForms);
            DataTable dt = dtFormtype;

            objBE.EODBFormName=FormType;
            objBE.EODBFromDate=txtfrm.Text.ToString();
            objBE.EODBToDate=txtto.Text.ToString();
            objBE.EODBCreatedBy=Session["User"].ToString();

            DataTable result = objDL.EODB_Dashboard_Insert(dt, objBE, ConnKey);
            if (result.Rows.Count  >0)
            {
                lblError.Text = "Data Submitted Successfully..";
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Font.Size = 16;

                clear();
                return;
            }
            else
            {
                lblError.Text = "Please check the values..";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        public void clear()
        {
            txtfrm.Text = "";
            txtto.Text = "";
            txtLicenceNew.Text = "";
            txtLicenceRenewal.Text = "";
            txtApplicationsNew.Text = "";
            txtApplicationsRenewal.Text = "";
            txtApprovedApplicationsNew.Text = "";
            txtApprovedApplicationsRenewal.Text = "";
            txtAvgTimeTakenNew.Text = "";
            txtAvgTimeTakenRenewal.Text = "";
            txtMedianNew.Text = "";
            txtMedianRenewal.Text = "";
            txtMinTimeTakenNew.Text = "";
            txtMinTimeTakenRenewal.Text = "";
            txtMaxTimeTakenNew.Text = "";
            txtMaxTimeTakenRenewal.Text = "";
        }
       
    }
}