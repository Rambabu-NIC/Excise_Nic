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
    public partial class D1P_GSection_ : System.Web.UI.Page
    {
        SqlHelper sql = new SqlHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnd1p_Click(object sender, EventArgs e)
        {
            SqlParameter[] Params =
                {
                    new SqlParameter("@Notify_no ",txtNotify_no.Text.ToString()),
                    new SqlParameter("@Applicanttype",ddlFirmType.SelectedValue),
                    new SqlParameter("@FirmName ",txtapplicantname.Text.ToString()),
                    new SqlParameter("@ROC_NO",txtRocNumber.Text.ToString()),
                    new SqlParameter("@U_District",ddlDistrict.SelectedValue),
                    new SqlParameter("@U_Mandal",ddlMandal.SelectedValue),
                    new SqlParameter("@U_Village",ddlVillage.SelectedValue),
                    new SqlParameter("@U_House_No",txtHouseNo.Text.ToString()),
                    new SqlParameter("@U_Street_Road",txtStreet.Text.ToString()),
                    new SqlParameter("@DL_District",ddlEDistrict.SelectedValue),
                    new SqlParameter("@DL_Mandal",ddlEMandal.SelectedValue),
                    new SqlParameter("@DL_Village",ddlEVillage.SelectedValue),
                    new SqlParameter("@DL_Survey_No",txtSurveyNo.Text.ToString()),
                    new SqlParameter("@DL_Extent",txtExtent.Text.ToString()),
                    new SqlParameter("@Ferm_base_Manu",ddlManufacture.SelectedValue),
                    new SqlParameter("@Is_man_Spirit_MaltSpirit",""),
                    new SqlParameter("@Is_Eaxpansion",""),
                    new SqlParameter("@LicenceNo",txtExistingLicense.Text.ToString()),
                    new SqlParameter("@Nature_Activity",txtnature_of_activity.Text.ToString()),
                    new SqlParameter("@Ex_Prod_Capacity",txtexisting_production_capacity.Text.ToString()),
                    new SqlParameter("@Incresing_Prod_Capacity",txtproposed_production_capacity.Text.ToString()),
                    new SqlParameter("@Is_sufLand_owns",""),
                    new SqlParameter("@Invest_Capital",txtcapital_investment.Text.ToString()),
                    new SqlParameter("@Invest_Borrowings",txtborrowings.Text.ToString()),
                    new SqlParameter("@Invest_OnLand",txtinvestment_land.Text.ToString()),
                    new SqlParameter("@Invest_OnBuilding",txtinvestment_building.Text.ToString()),
                    new SqlParameter("@Invest_OnPlantMachine",txtinvestment_machinery.Text.ToString()),
                    new SqlParameter("@Invest_WorkingCapital",txtworking_capital.Text.ToString()),
                    new SqlParameter("@Is_Available_Water",rblsufficient_water.SelectedValue),
                    new SqlParameter("@Is_Available_PowerSupply",rblpower_supply.SelectedValue),
                    new SqlParameter("@RawMaterial",ddlfermentative_base.SelectedValue),
                    new SqlParameter("@RawMaterial_Other",txtfermentative_name.Text.ToString()),
                    new SqlParameter("@Is_able_secure_raw",rblsecuretherawmaterial.SelectedValue),
                    new SqlParameter("@Is_Machinery_imported",rblimportedorindigenous.SelectedValue),
                    new SqlParameter("@Name_Spirits",txtsprit_name.Text.ToString()),
                    new SqlParameter("@Product_Standards",txtstandards.Text.ToString()),
                    new SqlParameter("@Brief_Process_Man",txtmanufacture_process.Text.ToString()),
                    new SqlParameter("@Is_Foriegn_asst_req",rbforiegncollab.SelectedValue),
                    new SqlParameter("@Foreign_Exchange",txtforeignexchange.Text.ToString()),
                    new SqlParameter("@Product_Eastimte_Anually",txtEstimatedAprod.Text.ToString()),
                    new SqlParameter("@Is_BuyBack",rblbuybackarrange.SelectedValue),
                    new SqlParameter("@BuyBack_Details",txtforeignexchangeinvolved.Text.ToString()),
                    new SqlParameter("@Time_req_sec_land",txtsecureland.Text.ToString()),
                    new SqlParameter("@Time_req_erect_plant_machine",txtplantandmechinery.Text.ToString()),
                    new SqlParameter("@Staff_Supervisors",txtsupervisorystaff.Text.ToString()),
                    new SqlParameter("@Staff_SkilledWorkers",txtskilledworkers.Text.ToString()),
                    new SqlParameter("@Staff_UnSkilledWorkers",txtunskilledworkers.Text.ToString()),
                    new SqlParameter("@Is_Facility_govt_req",rblspecialfacilties.SelectedValue),
                    new SqlParameter("@Facility_Details",""),
                    new SqlParameter("@CreatedBy",""),


            };

            try
            {

                DataSet data = sql.GetData(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "D1P_Insert", Params);
                if (data != null && data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0 )
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