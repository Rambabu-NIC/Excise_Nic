using ExciseAPI.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ExciseAPI.EODB
{
    public partial class RS_III : System.Web.UI.Page
    {
        SqlHelper sql = new SqlHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRS3_Click(object sender, EventArgs e)
        {
            SqlParameter[] Params =
               {


                    new SqlParameter("@ApplicantType ",ddlFirmType.SelectedValue),
                    new SqlParameter("@ApplicantName",txtName.Text.ToString()),
                    new SqlParameter("@MobileNo",txtMobile.Text.ToString()),
                    new SqlParameter("@PanNo",txtPan.Text.ToString()),
                    new SqlParameter("@AadharNo",txtAadhar.Text.ToString()),
                    new SqlParameter("@Gst",txtGst.Text.ToString()),
                    new SqlParameter("@Email",txtEmail.Text.ToString()),
                    new SqlParameter("@U_House_No",txtPHouseNo.Text.ToString()),
                    new SqlParameter("@U_Street_Road",txtPStreet.Text.ToString()),
                    new SqlParameter("@DL_District",ddlPDistrict.SelectedValue),
                    new SqlParameter("@DL_Mandal",ddlPMandal.SelectedValue),
                    new SqlParameter("@DL_Village",ddlPVillage.SelectedValue),
                    new SqlParameter("@Pincode",txtPPinCode.Text.ToString()),
                    new SqlParameter("@District",ddlPDistrict.SelectedValue),
                    new SqlParameter("@Mandal",ddlPMandal.SelectedValue),
                    new SqlParameter("@Village",ddlPVillage.SelectedValue),
                    new SqlParameter("@U_House_No",txtHouseNo.Text.ToString()),
                    new SqlParameter("@U_Street_Road",txtStreet.Text.ToString()),
                    new SqlParameter("@DL_District",ddlDistrict.SelectedValue),
                    new SqlParameter("@DL_Mandal",ddlMandal.SelectedValue),
                    new SqlParameter("@DL_Village",ddlVillage.SelectedValue),
                    new SqlParameter("@Pincode",txtPincode.Text.ToString()),
                    new SqlParameter("@Rectified",txtRectified.Text.ToString()),
                    new SqlParameter("@Manufacture",txtManufacture.Text.ToString()),
                    new SqlParameter("@OtherLicenses",rblOtherLicenses.SelectedValue),
                    new SqlParameter("@Quantity",txtQuantity.Text.ToString()),
                    new SqlParameter("@Manufacture_Purpose",txtManfPurpose.Text.ToString()),
                    new SqlParameter("@Current_Manufacture_Purpose",txtCurrentManf.Text.ToString()),



            };

            try
            {

                DataSet data = sql.GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "D1P_Insert", Params);
                if (data != null && data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
                {


                    lblActionerror.Text = "Submitted Successfully..";
                    lblActionerror.ForeColor = System.Drawing.Color.Green;

                    return;
                }

                else
                {
                    lblActionerror.Text = "Please check the values..";
                    return;
                }

            }
            catch (Exception ex)
            {
                lblActionerror.Text = "Please check the values..";
                return;
            }
        }
    }
}