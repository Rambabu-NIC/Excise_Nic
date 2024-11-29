﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Excise_BE;
using Excise_DAL;

namespace ExciseAPI.Supplier
{
    public partial class BAREndorsement : System.Web.UI.Page
    {
        Supplier_BE objSupBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_BE objBE = new Master_BE();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && (Session["Role"].ToString() == "2" || Session["Role"].ToString() == "4" ||
                Session["Role"].ToString() == "7" || Session["Role"].ToString() == "50"
                || Session["Role"].ToString() == "54" || Session["Role"].ToString() == "28" || Session["Role"].ToString() == "29")
                && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
                BindDetails();
            }
        }
        public DataSet GetProceedings
        {
            get
            {
                return ViewState["GetProceedings"] as DataSet;
            }
            set
            {
                ViewState["GetProceedings"] = value;
            }
        }


        public void BindDetails()
        {
            string UserID = Session["RenewalID"].ToString();
            string ApplicationNo = Session["ApplicationNo"].ToString();
            int Type_Man_Cd = Convert.ToInt32(Session["Type_Man_Cd"].ToString());
            string TypeofUser = Session["TypeofUser"].ToString();

            GetProceedings = objDL.GetProceedings(UserID, ApplicationNo, Type_Man_Cd, TypeofUser, ConnKey);
            if (GetProceedings.Tables.Count > 0 && GetProceedings.Tables[0].Rows.Count > 0)
            {
                var item = GetProceedings.Tables[0].Rows[0];
                lblProceeding.Text = item["ProceedingNo"].ToString();
                lblDate.Text = item["CreatedDate"].ToString();
                lblbearingNo.Text = item["Bearing_LicenceNo"].ToString();
                lblbearingdate.Text = item["E_LicenceDate"].ToString();
                lblLicenseeName.Text = item["License_Name"].ToString();
                lblPremisesbearingNo.Text = item["E_PremisesBearingNO"].ToString();
                lblName.Text = item["License_Name"].ToString();
                lblplintharea.Text = item["E_PlinthArea"].ToString();
                lblAmount.Text = item["BETRemittedAmount"].ToString();
                lblRupees.Text = item["AmountinWords"].ToString();

                if (GetProceedings.Tables[2].Rows.Count > 0)
                {
                    string stringADbytes = GetProceedings.Tables[2].Rows[0]["Signature"].ToString();
                    if (!String.IsNullOrEmpty(stringADbytes))
                    {
                        byte[] bytes = (byte[])GetProceedings.Tables[2].Rows[0]["Signature"];
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

                        DPEOImageSign.ImageUrl = "data:image/jpeg;base64," + base64String;
                    }
                    else
                    {
                        DPEOImageSign.ImageUrl = "";
                    }
                }
            }

        }


    }
}