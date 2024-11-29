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
    public partial class ControlRoomForm : System.Web.UI.Page
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

                BindDistrict();
                Status();
                Reason();
                BindComplaintSource();
                ComplaintType();
                AssignedOfficers();
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

        public void BindData()
        {
            btn_Submit.Visible = false;
            if (dsComplaints.Tables.Count > 0 && dsComplaints.Tables[0].Rows.Count > 0)
            {
                var item = dsComplaints.Tables[0].Rows[0];
                txtComplaintID.Text = item["ComplaintID"].ToString();
                ddlComplaintSource.SelectedValue = item["ComplaintSource"].ToString();
                txtComplaintName.Text = item["Name"].ToString();
                ddlDist.SelectedValue = item["DistCode"].ToString();
                BindMandal();
                ddlMand.SelectedValue = item["MandCode"].ToString();
                BindVillage();
                ddlVill.SelectedValue = item["VillCode"].ToString();
                txtComplaintdtls.Text = item["ComplaintDetails"].ToString();
                linklblAttachment.Text = item["DocumentName"].ToString();
                ddlStatus.SelectedValue = item["StatusID"].ToString();
                txtTimestamp.Text = item["CreatedDate"].ToString();
                ddlComplaintType.SelectedValue = item["ComplaintType"].ToString();
                ddlAssignedto.SelectedValue = item["AssignedTo"].ToString();
                int StatusID = Convert.ToInt16(item["StatusID"].ToString());
                btn_Submit.Visible = false;
                if (StatusID == 1 || StatusID == 5)
                {
                    btn_Submit.Visible = true;
                }
                else
                {
                    btn_Submit.Visible = false;
                }
            }
            divatr.Visible = false;
            if (dsComplaints.Tables.Count > 0 && dsComplaints.Tables[2].Rows.Count > 0)
            {
                divatr.Visible = true;
                var item = dsComplaints.Tables[2].Rows[0];
                txtATR.Text = item["AtrNo"].ToString();
                linkbtnATR.Text = item["DocumentName"].ToString();
            }
        }

        protected void BindComplaintSource()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                dt = ECMSDAL.GetComplaint_type(ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlComplaintSource.DataSource = dt;
                    ddlComplaintSource.DataTextField = "ComplaintSource";
                    ddlComplaintSource.DataValueField = "ComplaintCode";
                    ddlComplaintSource.DataBind();
                    ddlComplaintSource.Items.Insert(0, new ListItem("--Select--", "0"));
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
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        public void BindDistrict()
        {
            try
            {

                objBE.Statecode = "36";
                DataTable dt1 = new DataTable();
                objBE.Action = "R";
                dt1 = ObjMDL.GetDistDL(objBE, ConnKey);
                objCommon.BindDropDownLists(ddlDist, dt1, "DistName", "DistCode", "0");
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                //Response.Redirect("~/Error.aspx");
            }
        }

        public void BindMandal()
        {
            try
            {
                DataTable dt1 = new DataTable();
                objBE.Statecode = "36";
                objBE.DistCode = ddlDist.SelectedValue;
                objBE.Action = "R";
                dt1 = ObjMDL.GetmandalsDAL(objBE, ConnKey);
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
                objBE.DistCode = ddlDist.SelectedValue;
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


        protected void Reason()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            try
            {

                dt = ECMSDAL.GetComplaint_Reason(ConnKey);
                if (dt.Rows.Count > 0)
                {
                    ddlReason.DataSource = dt;
                    ddlReason.DataTextField = "ReasonName";
                    ddlReason.DataValueField = "ReasonCode";
                    ddlReason.DataBind();
                    ddlReason.Items.Insert(0, new ListItem("--Select--", "0"));
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


        protected void ddlComplaintType_SelectedIndexChanged(object sender, EventArgs e)
        {
            divvoilation.Visible = false;
            divshop.Visible = false;
            divOthers.Visible = false;

            if (ddlComplaintType.SelectedValue == "4")
            {
                AVoilation();
                divvoilation.Visible = true;
            }
            else if (ddlComplaintType.SelectedValue == "5")
            {
                BVoilation();
                divshop.Visible = true;
            }
            else
            {
                divOthers.Visible = true;
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

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            divreason.Visible = false;
            if (ddlStatus.SelectedValue == "6")
            {
                divreason.Visible = true;
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (ddlStatus.SelectedValue == "0")
            {
                lblError.Text = "Please Select a Status..";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (divreason.Visible == true && ddlReason.SelectedValue == "0")
            {
                lblError.Text = "Please Select a Reason..";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlComplaintType.SelectedValue == "0")
            {
                lblError.Text = "Please Select a ComplaintType..";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (divvoilation.Visible == true && ddlAVoilation.SelectedValue == "0")
            {
                lblError.Text = "Please Select a A4 Voilation..";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (divshop.Visible == true && ddlBVoilation.SelectedValue == "0")
            {
                lblError.Text = "Please Select a 2B Voilation..";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (divOthers.Visible == true && string.IsNullOrEmpty(txtOthers.Text))
            {
                lblError.Text = "Please Enter Remarks..";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlAssignedto.SelectedValue == "0")
            {
                lblError.Text = "Please Select a Assignedto..";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                //ECMS_ControlRoomDetails_Insert
                string ComplaintID = txtComplaintID.Text.ToString();
                int Status = Convert.ToInt16(ddlStatus.SelectedValue);
                string Reason = ddlStatus.SelectedValue.ToString();
                int ComplaintType = Convert.ToInt16(ddlComplaintType.SelectedValue);
                int A4ShopViolationCode = 0;
                if (divvoilation.Visible == true)
                {
                    A4ShopViolationCode = Convert.ToInt16(ddlAVoilation.SelectedValue);
                }
                int B2VioaltionCode = 0;
                if (divshop.Visible == true)
                {
                    B2VioaltionCode = Convert.ToInt16(ddlBVoilation.SelectedValue);
                }
                int AtrNo = 0;
                int AssignedTo = Convert.ToInt16(ddlAssignedto.SelectedValue);
                string CreateBy = Session["User"].ToString();
                string FeedbackRemarks = txtFeedback.Text.ToString();
                string Feedback_UpdatedBy = Session["User"].ToString();
                int DistrictCode = Convert.ToInt16(ddlDist.SelectedValue);
                int ExciseDistrictCode = Convert.ToInt16(ddlDist.SelectedValue);

                bool result = false;

                result = ECMSDAL.Insert_ControlRoomDetails(ComplaintID, Status, Reason, ComplaintType, A4ShopViolationCode, B2VioaltionCode, AssignedTo, AtrNo, CreateBy, FeedbackRemarks
                    , Feedback_UpdatedBy, DistrictCode, ExciseDistrictCode, ConnKey);
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