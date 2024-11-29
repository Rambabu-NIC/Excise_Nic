using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.Event
{
    public partial class Verify_Scan : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                if (!string.IsNullOrEmpty(id))
                {
                    GetData(id);
                }
                else
                {
                    GetData(null);
                }
        }
        public string id
        {
            get
            {
                if (Request.QueryString["id"] != null)
                {
                    return Request.QueryString["id"].ToString();
                }
                else
                {
                    return null;
                }
            }
        }


        protected void GetData(String id)
        {
            try
            {

                objBE.Statecode = "36";
                //objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    objBE.Action = "PERN1";
                    objBE.Reg_Code = id.ToString();
                }
                else
                {
                    objBE.Action = "PERN";
                    objBE.PermitId = Request.QueryString["RegNo"].ToString();
                }

                //   objBE.MobNo = txtMobileNumber.Text;

                DataTable dt = new DataTable();
                dt = objDL.EventReg_IUR(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    Panel1.Visible = true;
                    lblExDepoNm.Text = dt.Rows[0]["DPEO_NAME"].ToString();
                    lblPerLic.Text = dt.Rows[0]["PermitId"].ToString();
                    lblPerDt.Text = dt.Rows[0]["PermitDt"].ToString();
                    lblLicFee.Text = dt.Rows[0]["License_Fee"].ToString();
                    lblExdist.Text = dt.Rows[0]["ExDist"].ToString();
                    lblRAddress.Text = dt.Rows[0]["Res_Address"].ToString();
                    lblAddress.Text = dt.Rows[0]["Name_Premises"].ToString();
                    lblAppNAme.Text = dt.Rows[0]["App_Name"].ToString();
                    lblOccasion.Text = dt.Rows[0]["Event_Occasion"].ToString();
                    lblDttime.Text = dt.Rows[0]["Date"].ToString();
                    // lblExStation.Text = dt.Rows[0]["ExStation"].ToString();
                    lblBEast.Text = dt.Rows[0]["Bdr_East"].ToString();
                    lblBWest.Text = dt.Rows[0]["Bdr_West"].ToString();
                    lblBNorth.Text = dt.Rows[0]["Bdr_North"].ToString();
                    lblSouth.Text = dt.Rows[0]["Bdr_South"].ToString();

                    //
                    // Byte[] bytes = Captcha.QRCodeGenerate(dt.Rows[0]["PermitId"].ToString());

                    Byte[] bytes = Captcha.QRCodeGenerate("https://excise.telangana.gov.in/Event/Verify_Scan.aspx?RegNo=" + objBE.PermitId);
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    ImgQR.ImageUrl = "data:image/png;base64," + base64String;
                    ImgQR.Visible = true;

                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");
                    // Panel2.Visible = false;
                    // datadiv.Visible = false;
                    return;
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}