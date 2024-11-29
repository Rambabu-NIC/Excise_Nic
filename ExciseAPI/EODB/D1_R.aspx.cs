using ExciseAPI.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.EODB
{
    public partial class D1_R : System.Web.UI.Page
    {
        SqlHelper sql = new SqlHelper();
        private int CurrentTab
        {
            get
            {
                if (ViewState["CurrentTab"] == null)
                    ViewState["CurrentTab"] = 1;
                return (int)ViewState["CurrentTab"];
            }
            set
            {
                ViewState["CurrentTab"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPersonalDetails();
                BinDistrictDetails();
                BindDocuments();
                ShowCurrentTab();
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }
            if (CurrentTab > 1)
            {
                CurrentTab--;
                ShowCurrentTab();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (!this.IsValid)
            {
                return;
            }
            if (CurrentTab < 6)
            {
                CurrentTab++;
                ShowCurrentTab();
            }
        }
        private void ShowCurrentTab()
        {
            tab1.Visible = CurrentTab == 1;
            tab2.Visible = CurrentTab == 2;
            tab3.Visible = CurrentTab == 3;
            tab4.Visible = CurrentTab == 4;
            tab5.Visible = CurrentTab == 5;
            tab6.Visible = CurrentTab == 6;

            btntab1.Enabled = true;
            btntab2.Enabled = true;
            btntab3.Enabled = true;
            btntab4.Enabled = true;
            btntab5.Enabled = true;
            btntab6.Enabled = true;
            if (CurrentTab == 1)
            {
                btntab1.Enabled = false;
            }
            if (CurrentTab == 2)
            {
                btntab2.Enabled = false;
            }
            if (CurrentTab == 3)
            {
                btntab3.Enabled = false;
            }
            if (CurrentTab == 4)
            {
                btntab4.Enabled = false;
            }
            if (CurrentTab == 5)
            {
                btntab5.Enabled = false;
            }
            if (CurrentTab == 6)
            {
                btntab6.Enabled = false;
            }
            btnPrevious.Enabled = CurrentTab > 1;
            btnNext.Enabled = CurrentTab < 6;
        }


        protected void btntab1_Click(object sender, EventArgs e)
        {
            CurrentTab = 1;
            if (CurrentTab == 1)
            {

                ShowCurrentTab();
            }
            btntab1.Enabled = false;
        }
        protected void btntab2_Click(object sender, EventArgs e)
        {
            CurrentTab = 2;
            if (CurrentTab < 3)
            {

                ShowCurrentTab();
            }
            btntab2.Enabled = false;
        }
        protected void btntab3_Click(object sender, EventArgs e)
        {
            CurrentTab = 3;
            if (CurrentTab < 4)
            {

                ShowCurrentTab();
            }
            btntab3.Enabled = false;
        }

        protected void btntab4_Click(object sender, EventArgs e)
        {
            CurrentTab = 4;
            if (CurrentTab < 5)
            {

                ShowCurrentTab();
            }
            btntab4.Enabled = false;
        }

        protected void btntab5_Click(object sender, EventArgs e)
        {
            CurrentTab = 5;
            if (CurrentTab < 6)
            {

                ShowCurrentTab();
            }
            btntab5.Enabled = false;
        }

        protected void btntab6_Click(object sender, EventArgs e)
        {
            CurrentTab = 6;
            if (CurrentTab < 7)
            {

                ShowCurrentTab();
            }
            btntab6.Enabled = false;
        }
        public void BinDistrictDetails()
        {
            DataSet dsdistrict = sql.BindDistrictDetails();
            if(dsdistrict !=null && dsdistrict.Tables.Count > 0)
            {
                //ddlDistrict
                ddlDistrict.Items.Clear();
                ddlDistrict_A.Items.Clear();
                ddlEDistrict.Items.Clear();
                if (dsdistrict.Tables.Count > 0 && dsdistrict.Tables[0].Rows.Count > 0)
                {
                    ddlDistrict.DataSource = dsdistrict.Tables[0];
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataValueField = "DistrictID";
                    ddlDistrict.DataBind();

                    ddlDistrict_A.DataSource = dsdistrict.Tables[0];
                    ddlDistrict_A.DataTextField = "DistrictName";
                    ddlDistrict_A.DataValueField = "DistrictID";
                    ddlDistrict_A.DataBind();

                    ddlEDistrict.DataSource = dsdistrict.Tables[0];
                    ddlEDistrict.DataTextField = "DistrictName";
                    ddlEDistrict.DataValueField = "DistrictID";
                    ddlEDistrict.DataBind();
                    
                }
                ddlDistrict.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                ddlDistrict_A.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
                ddlEDistrict.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
        }

       

        public void BindPersonalDetails()
        {
            DataTable dt = Session["ApplicantPersonalDetails"] as DataTable;
            if (dt != null)
            {
                divgridDetails.Visible = true;
                gvpersonaldetails.DataSource = dt;
                gvpersonaldetails.DataBind();
            }
            
        }
        //protected void validate()
        //{
        //    if (!string.IsNullOrEmpty(txtNotify_no.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Notification Number";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtFirmname.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Firm Name";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtRocNumber.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Roc Number";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtRocNumber.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Roc Number";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtUndertaking.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Name of the Undertaking";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtHouseNo.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter House No";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtStreet.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Street and Landmark";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if(ddlDistrict.SelectedValue=="")
        //    {
        //        lblActionerror.Text = "Please Select District";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (ddlMandal.SelectedValue == "")
        //    {
        //        lblActionerror.Text = "Please Select Mandal";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (ddlVillage.SelectedValue == "")
        //    {
        //        lblActionerror.Text = "Please Select Village";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtPincode.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter PinCode";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtSurveyNo.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Survey No";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtExtent.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Extent";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (ddlManufacture.SelectedValue == "")
        //    {
        //        lblActionerror.Text = "Please Select Nature of the manufacture";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtFermentative.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Mention the name of the fermentative base";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (rblMalt.SelectedValue == "")
        //    {
        //        lblActionerror.Text = "Please Select Whether it is manufacture of Malt Spirit";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (rblDistillery.SelectedValue == "")
        //    {
        //        lblActionerror.Text = "Please Select >Whether it is the expansion of existing distillery";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtExistingLicense.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Existing License held by the applicant";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtnature_of_activity.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Nature of activity";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtexisting_production_capacity.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Existing production capacity";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtproposed_production_capacity.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Production capacity proposed to be increased";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (rbl_sufLand_owns.SelectedValue == "")
        //    {
        //        lblActionerror.Text = "Please Select Whether applicant owns sufficient land";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtNActivity.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Nature of activity";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtcapital_investment.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Capital Investment";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtborrowings.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Borrowings";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtinvestment_land.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Investment on Land";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtinvestment_building.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Investment on Building";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtinvestment_machinery.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Investment on Plant and Machinery";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtworking_capital.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Working Capital";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (rblsufficient_water.SelectedValue == "")
        //    {
        //        lblActionerror.Text = "Please Select Whether sufficient water is available at the proposed place";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (rblpower_supply.SelectedValue == "")
        //    {
        //        lblActionerror.Text = "Please Select Whether the proper power supply is available at proposed place to meet the requirements of the unit";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (ddlfermentative_base.SelectedValue == "")
        //    {
        //        lblActionerror.Text = "Please Select Details of the raw materials";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtfermentative_name.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Mention the name of the fermentative base as main(Other) raw material";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (rblsecuretherawmaterial.SelectedValue == "")
        //    {
        //        lblActionerror.Text = "Please Select Whether the applicant is able to secure the raw material stated in Col.No.9 without the aid of the government";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (rblimportedorindigenous.SelectedValue == "")
        //    {
        //        lblActionerror.Text = "Please Select Whether the plant and machinery to be installed is of imported or indigenous";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtsprit_name.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Name(s) of the spirits proposed to be manufactured";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtstandards.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter  Standards of the product(s) proposed to manufacture";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtmanufacture_process.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Brief process of manufacture";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (rbforiegncollab.SelectedValue == "")
        //    {
        //        lblActionerror.Text = "Please Select Whether the proposed plant requires any technical assistance/know how many from any foriegn collaboration";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtforeignexchange.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter If So, the foreign exchange involved";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtsecureland.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Time required to secure land";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtplantandmechinery.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Time required for erecting plant and machinery";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtsupervisorystaff.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Supervisory Staff";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtskilledworkers.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Skilled Workers";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (!string.IsNullOrEmpty(txtunskilledworkers.Text.ToString()))
        //    {
        //        lblActionerror.Text = "Please Enter Un-skilled workers";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //    if (rblspecialfacilties.SelectedValue == "")
        //    {
        //        lblActionerror.Text = "Please Select Any special facilities required from the Government";
        //        lblActionerror.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }
        //}
        protected void btnd1p_Click(object sender, EventArgs e)
        {
           
                    try
            {
                string ParameterTypeName = "@TablePersonalDetails";
                string TypeName = "TablePersonalDetails";
                DataTable dtPartenerDetails = Session["ApplicantPersonalDetails"] as DataTable;
                string ApplicationNo = Session["ApplicationNo"].ToString();
                SqlParameter[] Params =
                 {
                    new SqlParameter("@P_UserName", Session["UserName"].ToString()),
                    new SqlParameter("@P_ApplicationNo", ApplicationNo.ToString()),
                };
                DataSet data = sql.GetDataInsert(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "PersonalDetails_Insert", Params, dtPartenerDetails, ParameterTypeName, TypeName);
                        if (data != null && data.Tables.Count > 0)
                        {
                            var item = data.Tables[0].Rows[0];
                            if (item["Status"].ToString() == "SUCCESS")
                            {
                                D1Pinsert();
                            }
                            else
                            {
                                lblActionerror.Text = item["Message"].ToString();
                            }
                        }
                }
            
            catch (Exception ex)
            {

            }
        }

        public void D1Pinsert()
        {
            if(D1PFileUpload.Rows.Count !=ddlFileUpload.Items.Count)
            {
                lblFileUploaderror.Text = "Please Upload All Documents";
                return;
            }
            SqlParameter[] Params =
                {
                    new SqlParameter("@Notify_no ",txtNotify_no.Text.ToString()),
                    new SqlParameter("@Applicanttype","0"),// ddlFirmType.SelectedValue),
                    new SqlParameter("@FirmName",txtFirmname.Text.ToString()),//,txtapplicantname.Text.ToString()),
                    new SqlParameter("@ROC_NO",txtRocNumber.Text.ToString()),//,txtRocNumber.Text.ToString()),
                    new SqlParameter("@U_Name",txtUndertaking.Text.ToString()),
                    new SqlParameter("@U_District",ddlDistrict.SelectedValue),
                    new SqlParameter("@U_Mandal",ddlMandal.SelectedValue),
                    new SqlParameter("@U_Village",ddlVillage.SelectedValue),
                    new SqlParameter("@U_House_No",txtHouseNo.Text.ToString()),
                    new SqlParameter("@U_Street_Road",txtStreet.Text.ToString()),
                    new SqlParameter("@UA_Name",txtUndertaking_A.Text.ToString()),
                    new SqlParameter("@UA_District",ddlDistrict_A.SelectedValue),
                    new SqlParameter("@UA_Mandal",ddlMandal_A.SelectedValue),
                    new SqlParameter("@UA_Village",ddlVillage_A.SelectedValue),
                    new SqlParameter("@UA_House_No",txtHouseNo_A.Text.ToString()),
                    new SqlParameter("@UA_Street_Road",txtStreet_A.Text.ToString()),
                    new SqlParameter("@DL_District",ddlEDistrict.SelectedValue),
                    new SqlParameter("@DL_Mandal",ddlEMandal.SelectedValue),
                    new SqlParameter("@DL_Village",ddlEVillage.SelectedValue),
                    new SqlParameter("@DL_Survey_No",txtSurveyNo.Text.ToString()),
                    new SqlParameter("@DL_Extent",txtExtent.Text.ToString()),
                    new SqlParameter("@Ferm_base_Manu",ddlManufacture.SelectedValue),
                    new SqlParameter("@Is_man_Spirit_MaltSpirit",rblMalt.SelectedValue),
                    new SqlParameter("@Is_Eaxpansion",rblDistillery.SelectedValue),
                    new SqlParameter("@LicenceNo",txtExistingLicense.Text.ToString()),
                    new SqlParameter("@Nature_Activity",txtnature_of_activity.Text.ToString()),
                    new SqlParameter("@Ex_Prod_Capacity",txtexisting_production_capacity.Text.ToString()),
                    new SqlParameter("@Incresing_Prod_Capacity",txtproposed_production_capacity.Text.ToString()),
                    new SqlParameter("@Is_sufLand_owns",rbl_sufLand_owns.SelectedValue),
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
                    new SqlParameter("@CreatedBy",Session["UserName"].ToString()),
                    new SqlParameter("@ApplicationNo",Session["ApplicationNo"].ToString()),

            };

            string ParameterTypeName = "@DocumentDetails_N";
            string TypeName = "DocumentDetails_E";

            DataTable dtdocument = D1PFileUpload;

            try
            {

                DataSet data = sql.GetDataInsert(ConfigurationManager.ConnectionStrings["Excise_IMS"].ConnectionString, "D1R_Insert", Params, dtdocument,ParameterTypeName, TypeName);
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

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlDistrict.SelectedValue);
            if (DistID > 0)
            {
                BinMandalDetails(DistID, ddlMandal);
            }
            else
            {
                lblActionerror.Text = "Please select District";
                return;
            }
        }

        protected void ddlDistrict_A_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlDistrict_A.SelectedValue);
            if (DistID > 0)
            {
                BinMandalDetails(DistID, ddlMandal_A);
            }
            else
            {
                lblActionerror.Text = "Please select District";
                return;
            }
        }
        protected void ddlEDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlEDistrict.SelectedValue);
            if (DistID > 0)
            {
                BinMandalDetails(DistID, ddlEMandal);
            }
            else
            {
                lblActionerror.Text = "Please select District";
                return;
            }
        }

        public void BinMandalDetails(int DistrictID,DropDownList dropdown)
        {
            DataSet dsMandals = sql.BindMandalDetails(DistrictID);
            if (dsMandals != null && dsMandals.Tables.Count > 0)
            {
                dropdown.Items.Clear();
                if (dsMandals.Tables.Count > 0 && dsMandals.Tables[0].Rows.Count > 0)
                {
                    dropdown.DataSource = dsMandals.Tables[0];
                    dropdown.DataTextField = "MandalName";
                    dropdown.DataValueField = "MandalID";
                    dropdown.DataBind();
                }
                dropdown.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
        }
        protected void ddlMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlDistrict.SelectedValue);
            int MandalID = Convert.ToInt32(ddlMandal.SelectedValue);
            if (DistID > 0 && MandalID >0)
            {

                BindVillageDetails(DistID,MandalID, ddlVillage);
            }
            else
            {
                lblActionerror.Text = "Please select District  && Mandal";
                return;
            }
        }

        protected void ddlMandal_A_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlDistrict_A.SelectedValue);
            int MandalID = Convert.ToInt32(ddlMandal_A.SelectedValue);
            if (DistID > 0 && MandalID >0)
            {
                BindVillageDetails(DistID,MandalID, ddlVillage_A);
            }
            else
            {
                lblActionerror.Text = "Please select District  && Mandal";
                return;
            }
        }



        protected void ddlEMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DistID = Convert.ToInt32(ddlEDistrict.SelectedValue);
            int MandalID = Convert.ToInt32(ddlEMandal.SelectedValue);
            if (DistID > 0 && MandalID > 0)
            {
                BindVillageDetails(DistID, MandalID, ddlEVillage);
            }
            else
            {
                lblActionerror.Text = "Please select District && Mandal";
                return;
            }
        }
        public void BindVillageDetails(int DistrictID,int MandalID, DropDownList dropdown)
        {
            DataSet dsvillage = sql.BindVillageDetails(DistrictID, MandalID);
            if (dsvillage != null && dsvillage.Tables.Count > 0)
            {
                dropdown.Items.Clear();
                if (dsvillage.Tables.Count > 0 && dsvillage.Tables[0].Rows.Count > 0)
                {
                    dropdown.DataSource = dsvillage.Tables[0];
                    dropdown.DataTextField = "VillageName";
                    dropdown.DataValueField = "AddressID";
                    dropdown.DataBind();
                }
                dropdown.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
        }


        public void BindDocuments()
        {
            int ApplicantType = 1; int SubApplicantType = 1; int FormType = 1;

            DataSet Docs = sql.BindDocumentDetails(ApplicantType, SubApplicantType, FormType);
            if (Docs != null && Docs.Tables.Count > 0)
            {
                ddlFileUpload.Items.Clear();
                if (Docs.Tables.Count > 0 && Docs.Tables[0].Rows.Count > 0)
                {
                    ddlFileUpload.DataSource = Docs.Tables[0];
                    ddlFileUpload.DataTextField = "DocumentName";
                    ddlFileUpload.DataValueField = "DocumentserialNo";
                    ddlFileUpload.DataBind();
                }
                //ddlFileUpload.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            }
        }
        private DataTable FinalInsertDocumentDetails()
        {
            DataTable dtD1Pdetails = new DataTable();
            dtD1Pdetails.Columns.Add("ApplicationNo", typeof(string));
            dtD1Pdetails.Columns.Add("DocumentSerialNumber", typeof(int));
            dtD1Pdetails.Columns.Add("DocumentName", typeof(string));
            dtD1Pdetails.Columns.Add("DocumentCopy", typeof(byte[]));
            return dtD1Pdetails;
        }
        private DataTable D1PFileUpload
        {
            get
            {
                if (ViewState["D1PFileUpload"] == null)

                {
                    DataTable dt = FinalInsertDocumentDetails();
                    ViewState["D1PFileUpload"] = dt;
                }
                return ViewState["D1PFileUpload"] as DataTable;
            }
            set
            {
                ViewState["D1PFileUpload"] = value;
            }
        }


        protected void btnfileAdd_Click(object sender, EventArgs e)
        {
            DataTable dtD1PUploadDetails = D1PFileUpload;
            divuploadedDocuments.Visible = true;
            lblFileUploaderror.Text = string.Empty;
            bool IsDocumentExists = false;
            string DocumentType = ddlFileUpload.SelectedItem.Text;
            if (dtD1PUploadDetails.Rows.Count >0)
            {
                foreach (DataRow row in dtD1PUploadDetails.Rows)
                {
                    string DocumentTypeName = row["DocumentName"].ToString();
                    if (DocumentType == DocumentTypeName)
                    {
                        IsDocumentExists = true;
                    }
                }
            }
            else
            {
                IsDocumentExists = false;
            }
            if (IsDocumentExists == false)
            {


                DataRow drD1PDetail = dtD1PUploadDetails.NewRow();
                byte[] documenttype = null;
                string FileName = null;
                if (fileloiuploaddoctype.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(fileloiuploaddoctype.FileName);
                    if (extension.ToUpper() == ".PDF")
                    {
                        documenttype = fileloiuploaddoctype.FileBytes;
                        string FileNamework = fileloiuploaddoctype.PostedFile.FileName;
                        string FileNameworkExtension = System.IO.Path.GetExtension(FileNamework);
                        FileName = FileNamework.Substring(0, (FileNamework.Length - FileNameworkExtension.Length));

                        drD1PDetail["ApplicationNo"] = Session["ApplicationNo"].ToString();
                        drD1PDetail["DocumentSerialNumber"] = ddlFileUpload.SelectedItem.Value;
                        drD1PDetail["DocumentName"] = ddlFileUpload.SelectedItem.Text;
                        drD1PDetail["DocumentCopy"] = documenttype;

                        dtD1PUploadDetails.Rows.Add(drD1PDetail);
                    }
                    else

                    {
                        lblFileUploaderror.Text = "Upload only PDF files";
                    }
                }
                D1PFileUpload = dtD1PUploadDetails;
                gvaddrecordsofLOI.DataSource = D1PFileUpload;
                gvaddrecordsofLOI.DataBind();
                ddlFileUpload.SelectedIndex = 0;
                fileloiuploaddoctype.Dispose();
            }
            else
            {
                lblFileUploaderror.Text = "Selected Document is Already Added";
            }
        }

        protected void gvaddrecordsofLOI_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkbtn_Documents")
            {
                string DocumentID = e.CommandArgument.ToString();

                if (D1PFileUpload.Rows.Count > 0)
                {
                    DataView dvSelectedApplication = new DataView(D1PFileUpload);
                    //RowID=DocumentTypeID
                    dvSelectedApplication.RowFilter = "DocumentSerialNumber =" + DocumentID;
                    DataRow drow = dvSelectedApplication.ToTable().Rows[0];
                    string DocumentName = drow["DocumentName"].ToString();
                    ShowDocument(DocumentName + ".pdf", (byte[])drow["DocumentCopy"]);
                }
            }
        }
        private void ShowDocument(string fileName, byte[] fileContent)
        {
            //Split the string by character . to get file extension type  
            string[] stringParts = fileName.Split(new char[] { '.' });
            string strType = stringParts[1];
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            //Set the content type as file extension type  
            Response.ContentType = strType;
            //Write the file content  
            this.Response.BinaryWrite(fileContent);
            this.Response.End();
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "LOIDOC();", true);
        }

        protected void lknbtndocDelete_Click(object sender, EventArgs e)
        {
            LinkButton lbndocdelete = (sender) as LinkButton;
            GridViewRow gvrow = lbndocdelete.NamingContainer as GridViewRow;
            if (gvaddrecordsofLOI != null)
            {

                int rowindex = gvrow.RowIndex;

                if (D1PFileUpload.Rows.Count > 0)
                {
                    divuploadedDocuments.Visible = true;
                    //  divRenewalAmounts.Visible = true;
                    D1PFileUpload.Rows.Remove(D1PFileUpload.Rows[rowindex]);

                    gvaddrecordsofLOI.DataSource = D1PFileUpload;
                    gvaddrecordsofLOI.DataBind();

                    if (D1PFileUpload.Rows.Count == 0)
                    {
                        divuploadedDocuments.Visible = false;
                        //   divRenewalAmounts.Visible = false;
                    }
                }
            }
        }
    }
}