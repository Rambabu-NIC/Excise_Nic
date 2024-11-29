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
using System.IO;
using System.Text;
using context = System.Web.HttpContext;

namespace ExciseAPI.ECMS
{
    public partial class DC_Form : System.Web.UI.Page
    {
        ECMS_BE ECMSBE = new ECMS_BE();
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        ECMS_DAL ECMSDAL = new ECMS_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ComplaintType();
                AssignedOfficers();
                CrimeDetection();
                Contraband();
                SeizureType();
                IllicitLiquor();
                NDPS();
                Status();
                BindData();
            }

        }
        public string ComplaintID
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

        public DataSet dsComplaints
        {
            get
            {
                if (ViewState["dsComplaints"] == null)
                {
                    DataSet ds = ECMSDAL.GetComplaintsByComplaintID(ComplaintID, ConnKey);
                    ViewState["dsComplaints"] = ds;
                }
                return ViewState["dsComplaints"] as DataSet;
            }
        }
        protected void AVoilation()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                dt = ECMSDAL.GetAVoilation(ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlAVoilation.DataSource = dt;
                    ddlAVoilation.DataTextField = "VoilationName";
                    ddlAVoilation.DataValueField = "VoilationCode";
                    ddlAVoilation.DataBind();
                    ddlAVoilation.Items.Insert(0, new ListItem("--Select--", "0"));
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    dt.Dispose();
                }
                else
                {
                    //GvRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }
        protected void BVoilation()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                dt = ECMSDAL.GetBVoilation(ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlBVoilation.DataSource = dt;
                    ddlBVoilation.DataTextField = "VoilationType";
                    ddlBVoilation.DataValueField = "VoilationCode";
                    ddlBVoilation.DataBind();
                    ddlBVoilation.Items.Insert(0, new ListItem("--Select--", "0"));
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    dt.Dispose();
                }
                else
                {
                    //GvRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }
        public void BindData()
        {
            divAtrPre.Visible = false;
            divATR.Visible = false;
            if (dsComplaints.Tables.Count > 0 && dsComplaints.Tables[0].Rows.Count > 0)
            {
                var item = dsComplaints.Tables[0].Rows[0];
                txtComplaintID.Text = item["ComplaintID"].ToString();
                int Dist = Convert.ToInt32(item["DistCode"].ToString());
                BindMandal(Dist);
                ddlMand.SelectedValue = item["MandCode"].ToString();
                BindVillage();
                ddlVill.SelectedValue = item["VillCode"].ToString();
                txtComplaintdtls.Text = item["ComplaintDetails"].ToString();
                linklblAttachment.Text = item["DocumentName"].ToString();
                //int Status = Convert.ToInt16(item["StatusID"].ToString());
                //BindStatus(Status);
                //ddlStatus.SelectedValue = item["StatusID"].ToString();
                //ViewState["status"] = ddlStatus.SelectedValue;
                txtTimestamp.Text = item["CreatedDate"].ToString();
                ddlComplaintType.SelectedValue = item["ComplaintType"].ToString();
                if (ddlComplaintType.SelectedValue == "4")
                {
                    AVoilation();
                    divvoilation.Visible = true;

                    ddlAVoilation.SelectedValue = item["A4ShopViolationCode"].ToString();
                }
                if (ddlComplaintType.SelectedValue == "5")
                {
                    BVoilation();
                    divshop.Visible = true;
                    ddlBVoilation.SelectedValue = item["B2VioaltionCode"].ToString();
                }
            }
            if (dsComplaints.Tables.Count > 0 && dsComplaints.Tables[1].Rows.Count > 0)
            {
                divAtrPre.Visible = true;
                var item = dsComplaints.Tables[1].Rows[0];
                txtInspectionDate.Text = item["InspectionDate"].ToString();
                txtIOfficer.Text = item["InspectingOfficerName"].ToString();
                ddl_Crime.SelectedValue = item["CrimeDetectionCode"].ToString();
                if (ddl_Crime.SelectedValue == "1")
                {
                    txtCrimeLocation.Text = item["CrimeLocation"].ToString();
                    txtCOR.Text = item["CorNo"].ToString();
                    txtParrested.Text = item["PersonsArrested"].ToString();
                    txtContrabandSeized.Text = item["ContrabandSeized"].ToString();
                    txtCValue.Text = item["ContrabandValueRs"].ToString();
                    txtRemarks.Text = item["Remarks"].ToString();
                    txtInspectionDate.ReadOnly = true;
                    txtIOfficer.ReadOnly = true;
                    txtCrimeLocation.ReadOnly = true;
                    txtCOR.ReadOnly = true;
                    txtParrested.ReadOnly = true;
                    txtContrabandSeized.ReadOnly = true;
                    txtCValue.ReadOnly = true;
                    divdetected.Visible = true;
                    if (!string.IsNullOrEmpty(item["Remarks"].ToString()))
                    {
                        txtRemarks.ReadOnly = true;
                        btn_Submit.Visible = false;
                    }
                }
            }
            if (dsComplaints.Tables.Count > 0 && dsComplaints.Tables[2].Rows.Count > 0)
            {
                divATR.Visible = true;
                divIllicit.Visible = false;
                divNDPS.Visible = false;
                divvehicle.Visible = false;
                divContraband.Visible = false;
                divContraband1.Visible = false;
                var item = dsComplaints.Tables[2].Rows[0];
                txtATR.Text = item["AtrNo"].ToString();
                txtCasesBooked.Text = item["CasesBooked"].ToString();
                txtPersonsArrested.Text = item["PersonsArrested"].ToString();
                ddlSeizure.SelectedValue = item["SeizureType"].ToString();
                if (!string.IsNullOrEmpty(item["NumberOfVehiclesSeized"].ToString()) && Convert.ToInt32(item["NumberOfVehiclesSeized"].ToString()) > 0)
                {
                    divvehicle.Visible = true;
                    txtVehiclesSeized.Text = item["NumberOfVehiclesSeized"].ToString();
                }
                if (!string.IsNullOrEmpty(item["ContrabandType"].ToString()) && Convert.ToInt32(item["ContrabandType"].ToString()) > 0)
                {
                    divContraband.Visible = true;
                    ddlContraband.SelectedValue = item["ContrabandType"].ToString();
                }
                if (!string.IsNullOrEmpty(item["QuantitySeizedInLitres"].ToString()) && Convert.ToInt32(item["QuantitySeizedInLitres"].ToString()) > 0)
                {
                    divContraband1.Visible = true;
                    txtQuantity.Text = item["QuantitySeizedInLitres"].ToString();
                }
                if (!string.IsNullOrEmpty(item["IllicitLiquor"].ToString()) && Convert.ToInt32(item["IllicitLiquor"].ToString()) > 0)
                {
                    divIllicit.Visible = true;
                    ddlIllicitLiquor.SelectedValue = item["IllicitLiquor"].ToString();
                }
                if (!string.IsNullOrEmpty(item["Ndps"].ToString()) && Convert.ToInt32(item["Ndps"].ToString()) > 0)
                {
                    divNDPS.Visible = true;
                    ddlNdps.SelectedValue = item["Ndps"].ToString();
                }
                txtUndersection.Text = item["UnderSection"].ToString();
                linkbtnATR.Text = item["DocumentName"].ToString();
                if (!string.IsNullOrEmpty(item["Remarks"].ToString()))
                {
                    txtRemarks.Text = item["Remarks"].ToString();
                    txtRemarks.ReadOnly = true;
                    btn_Submit.Visible = false;
                }

            }
            if (dsComplaints.Tables.Count > 0 && dsComplaints.Tables[0].Rows.Count > 0)
            {
                btn_Submit.Visible = false;
                int Status = Convert.ToInt32(dsComplaints.Tables[0].Rows[0]["StatusID"].ToString());
                if (Status == 3 || Status == 8 || Status == 9 || Status == 10)
                {
                    btn_Submit.Visible = true;
                }
            }

        }
        protected void linklblAttachment_Click(object sender, EventArgs e)
        {
            if (dsComplaints.Tables.Count > 0)
            {
                DataRow drow = dsComplaints.Tables[0].Rows[0];
                string DocumentName = drow["DocumentName"].ToString();
                ShowDocument(DocumentName + ".pdf", (byte[])drow["DocumentFile"]);
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
        }
        protected void ComplaintType()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                dt = ECMSDAL.GetComplaint_Types(ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlComplaintType.DataSource = dt;
                    ddlComplaintType.DataTextField = "ComplaintType";
                    ddlComplaintType.DataValueField = "ComplaintCode";
                    ddlComplaintType.DataBind();
                    ddlComplaintType.Items.Insert(0, new ListItem("--Select--", "0"));
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    dt.Dispose();
                }
                else
                {
                    //GvRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }

        protected void AssignedOfficers()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                dt = ECMSDAL.GetAssignedOfficers(ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlAssignedto.DataSource = dt;
                    ddlAssignedto.DataTextField = "Officer_Name";
                    ddlAssignedto.DataValueField = "Officer_Code";
                    ddlAssignedto.DataBind();
                    ddlAssignedto.Items.Insert(0, new ListItem("--Select--", "0"));
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    dt.Dispose();
                }
                else
                {
                    //GvRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }

        protected void CrimeDetection()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                dt = ECMSDAL.GetCrimeDetection(ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddl_Crime.DataSource = dt;
                    ddl_Crime.DataTextField = "Detection_Name";
                    ddl_Crime.DataValueField = "Detection_Code";
                    ddl_Crime.DataBind();
                    ddl_Crime.Items.Insert(0, new ListItem("--Select--", "0"));
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    dt.Dispose();
                }
                else
                {
                    //GvRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }
        protected void Contraband()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                dt = ECMSDAL.GetContraband(ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlContraband.DataSource = dt;
                    ddlContraband.DataTextField = "ContrabandName";
                    ddlContraband.DataValueField = "ContrabandCode";
                    ddlContraband.DataBind();
                    ddlContraband.Items.Insert(0, new ListItem("--Select--", "0"));
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    dt.Dispose();
                }
                else
                {
                    //GvRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }


        protected void SeizureType()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                dt = ECMSDAL.GetSeizureType(ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlSeizure.DataSource = dt;
                    ddlSeizure.DataTextField = "Seizure_Type";
                    ddlSeizure.DataValueField = "Seizure_Code";
                    ddlSeizure.DataBind();
                    ddlSeizure.Items.Insert(0, new ListItem("--Select--", "0"));
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    dt.Dispose();
                }
                else
                {
                    //GvRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }

        protected void IllicitLiquor()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                dt = ECMSDAL.GetIllicitLiquor(ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlIllicitLiquor.DataSource = dt;
                    ddlIllicitLiquor.DataTextField = "IllicitLiquor_Name";
                    ddlIllicitLiquor.DataValueField = "IllicitLiquor_Code";
                    ddlIllicitLiquor.DataBind();
                    ddlIllicitLiquor.Items.Insert(0, new ListItem("--Select--", "0"));
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    dt.Dispose();
                }
                else
                {
                    //GvRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }

        protected void NDPS()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                dt = ECMSDAL.GetNDPS(ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlNdps.DataSource = dt;
                    ddlNdps.DataTextField = "NDPS_Name";
                    ddlNdps.DataValueField = "NDPS_Code";
                    ddlNdps.DataBind();
                    ddlNdps.Items.Insert(0, new ListItem("--Select--", "0"));
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    dt.Dispose();
                }
                else
                {
                    //GvRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }
        public void BindMandal(int Dist)
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.Statecode = "36";
                objBE.DistCode = Dist.ToString();
                dt1 = ObjMDL.Getmandal(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlMand, dt1, "MandName", "MandCode", "0");
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }

        public void BindVillage()
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.Statecode = "36";
                //objBE.DistCode = ddlDist.SelectedValue;
                objBE.MandCode = ddlMand.SelectedValue;
                objBE.Action = "R";
                dt1 = ObjMDL.GetvillDAL(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlVill, dt1, "VillName", "VillCode", "0");
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }
        protected void Status()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {
                int Role = Convert.ToInt16(Session["Role"].ToString());
                dt = ECMSDAL.GetComplaint_Status(Role, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlStatus.DataSource = dt;
                    ddlStatus.DataTextField = "Status";
                    ddlStatus.DataValueField = "StatusID";
                    ddlStatus.DataBind();
                    ddlStatus.Items.Insert(0, new ListItem("--Select--", "0"));
                    //ddlDepot.Items.Insert(0, new ListItem("--SelectALL--", "0"));
                    dt.Dispose();
                }
                else
                {
                    //GvRpt.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                lblResultMessage.Text = "";
                if (ddlStatus.SelectedValue.ToString() == "0")
                {
                    lblError.Text = "Please Select Status..";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (ddlAssignedto.SelectedValue.ToString() == "0")
                {
                    lblError.Text = "Please Select Assigned to..";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (divAtrPre.Visible == true && string.IsNullOrEmpty(txtRemarks.Text))
                {
                    lblError.Text = "Please Select Assigned to..";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                string ComplaintID = txtComplaintID.Text.ToString();
                int AssignedToEnquiryOfficerCode = Convert.ToInt16(ddlAssignedto.SelectedValue);
                string EnquiryOfficerPlace = " ";
                int StatusCode = Convert.ToInt32(ddlStatus.SelectedValue);
                //string Reason = ddlStatus.SelectedValue.ToString();
                //int ComplaintType = Convert.ToInt16(ddlComplaintType.SelectedValue);           
                //int AssignedTo = Convert.ToInt16(ddlAssignedto.SelectedValue);
                string CreateBy = Session["User"].ToString();
                int DistrictCode = Convert.ToInt16(ViewState["distcode"]);
                int ExciseDistrictCode = Convert.ToInt16(ViewState["distcode"]);
                string Remarks = txtRemarks.Text;
                bool result = false;

                result = ECMSDAL.Insert_DCFormDetails(ComplaintID, AssignedToEnquiryOfficerCode, EnquiryOfficerPlace, StatusCode, CreateBy, DistrictCode, ExciseDistrictCode, Remarks, ConnKey);
                if (result)
                {
                    lblResultMessage.Text = "Inserted Successfully..";
                    lblResultMessage.ForeColor = System.Drawing.Color.Green;
                    btn_Submit.Visible = false;
                }
                else
                {
                    lblResultMessage.Text = "Please check the values...";
                    lblResultMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void linkbtnATR_Click(object sender, EventArgs e)
        {
            if (dsComplaints.Tables.Count > 0 && dsComplaints.Tables[2].Rows.Count > 0)
            {
                DataRow drow = dsComplaints.Tables[2].Rows[0];
                string DocumentName = drow["DocumentName"].ToString();
                ShowDocument(DocumentName + ".pdf", (byte[])drow["DocumentFile"]);
            }
        }

    }
}