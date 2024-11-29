using System;
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
    public partial class MBEndorsement : System.Web.UI.Page
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
        public DataSet GetMBEndrosement
        {
            get
            {
                return ViewState["GetMBEndrosement"] as DataSet;
            }
            set
            {
                ViewState["GetMBEndrosement"] = value;
            }
        }
        public void BindDetails()
        {
            string UserID = Session["RenewalID"].ToString();
            string ApplicationNo = Session["ApplicationNo"].ToString();
            int Type_Man_Cd = Convert.ToInt32(Session["Type_Man_Cd"].ToString());
            string TypeofUser = Session["TypeofUser"].ToString();

            GetMBEndrosement = objDL.GetMBEndrosement(UserID, ApplicationNo, Type_Man_Cd, TypeofUser, ConnKey);
            if (GetMBEndrosement.Tables.Count > 0 && GetMBEndrosement.Tables[0].Rows.Count > 0)
            {
                var item = GetMBEndrosement.Tables[0].Rows[0];

                lblcrNo.Text = item["E_CrNo"].ToString();
                lblDate.Text = item["CreatedDate"].ToString();
                lbllicenceYear.Text = item["E_Fromyear"].ToString();
                lblmbtaxamount.Text = item["MBET_Challan_Amount"].ToString();
                lblmbchallanNo.Text = item["MBET_Challan"].ToString();
                lblmbchallanDate.Text = item["MBET_Challan_Date"].ToString();
                lblmbyear.Text = item["E_Fromyear"].ToString();
                lblremitted.Text = item["E_remitted"].ToString();
                lblApplicantName.Text = item["Supplier_Name"].ToString();
                lblpremises.Text = item["E_premises"].ToString();
                lblpremises1.Text = item["E_premises"].ToString();
                lblNorth.Text = item["E_North"].ToString();
                lblsouth.Text = item["E_South"].ToString();
                lbleast.Text = item["E_East"].ToString();
                lblwest.Text = item["E_West"].ToString();
                lblfromyear.Text = item["E_Fromyear"].ToString();
                lbltoyear.Text = item["E_Toyear"].ToString();
                lblName2.Text = item["Supplier_Name"].ToString();
                lbldycommi.Text = item["DCName"].ToString();
                lbldistoffice.Text = item["DPEOName"].ToString();

                if (GetMBEndrosement.Tables[2].Rows.Count > 0)
                {
                    string stringADbytes = GetMBEndrosement.Tables[2].Rows[0]["Signature"].ToString();
                    if (!String.IsNullOrEmpty(stringADbytes))
                    {
                        byte[] bytes = (byte[])GetMBEndrosement.Tables[2].Rows[0]["Signature"];
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