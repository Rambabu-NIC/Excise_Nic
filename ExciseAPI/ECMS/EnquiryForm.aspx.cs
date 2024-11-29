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
    public partial class EnquiryForm : System.Web.UI.Page
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
                ComplaintType();
                AssignedOfficers();
                CrimeDetection();
                IllicitLiquor();
                SeizureType();
                Contraband();
                IllicitLiquor();
                NDPS();
                BindData();




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
            bool Detected = false;
            if (dsComplaints.Tables.Count > 0 && dsComplaints.Tables[0].Rows.Count > 0)
            {
                var item = dsComplaints.Tables[0].Rows[0];
                txtComplaintID.Text = item["ComplaintID"].ToString();
                txtComplaintdtls.Text = item["Name"].ToString();
                ddlComplaintType.SelectedValue = item["ComplaintSource"].ToString();
                //ddlComplaintType.Enabled = false;
                //txtComplaintName.Text = item["Name"].ToString();
                int Dist = Convert.ToInt32(item["DistCode"].ToString());
                BindMandal(Dist);
                ddlMand.SelectedValue = item["MandCode"].ToString();
                BindVillage();
                ddlVill.SelectedValue = item["VillCode"].ToString();
                txtComplaintdtls.Text = item["ComplaintDetails"].ToString();
                lblAttachment.Text = item["DocumentName"].ToString();
                Status();
                txtTimestamp.Text = item["CreatedDate"].ToString();
            }
            if (dsComplaints.Tables.Count > 0 && dsComplaints.Tables[1].Rows.Count > 0)
            {
                var item = dsComplaints.Tables[1].Rows[0];
                txtInspectionDate.Text = item["InspectionDate"].ToString();
                txtIOfficer.Text = item["InspectingOfficerName"].ToString();
                ddl_Crime.SelectedValue = item["CrimeDetectionCode"].ToString();
                if (ddl_Crime.SelectedValue == "1")
                {
                    Detected = true;
                    txtCrimeLocation.Text = item["CrimeLocation"].ToString();
                    txtCOR.Text = item["CorNo"].ToString();
                    txtParrested.Text = item["PersonsArrested"].ToString();
                    txtContrabandSeized.Text = item["ContrabandSeized"].ToString();
                    txtCValue.Text = item["ContrabandValueRs"].ToString();
                    //txtRemarks.Text= item["Remarks"].ToString();
                    txtInspectionDate.ReadOnly = true;
                    txtIOfficer.ReadOnly = true;
                    txtCrimeLocation.ReadOnly = true;
                    txtCOR.ReadOnly = true;
                    txtParrested.ReadOnly = true;
                    txtContrabandSeized.ReadOnly = true;
                    txtCValue.ReadOnly = true;
                    divdetected.Visible = true;
                    divATR.Visible = true;
                }
            }
            if (dsComplaints.Tables.Count > 0 && dsComplaints.Tables[2].Rows.Count > 0)
            {
                divATR.Visible = true;
                var item = dsComplaints.Tables[2].Rows[0];
                txtATR.Text = item["AtrNo"].ToString();
                txtCasesBooked.Text = item["CasesBooked"].ToString();
                txtPersonsArrested.Text = item["PersonsArrested"].ToString();
                ddlSeizure.SelectedValue = item["SeizureType"].ToString();
                txtVehiclesSeized.Text = item["NumberOfVehiclesSeized"].ToString();
                ddlContraband.SelectedValue = item["ContrabandType"].ToString();
                txtQuantity.Text = item["QuantitySeizedInLitres"].ToString();
                ddlIllicitLiquor.SelectedValue = item["IllicitLiquor"].ToString();
                ddlNdps.SelectedValue = item["Ndps"].ToString();
                txtUndersection.Text = item["UnderSection"].ToString().ToUpper();
                if (!string.IsNullOrEmpty(item["Remarks"].ToString()))
                {
                    btn_Submit.Visible = false;
                }

            }
            if (dsComplaints.Tables.Count > 0 && dsComplaints.Tables[0].Rows.Count > 0)
            {
                btn_Submit.Visible = false;
                int Status = Convert.ToInt32(dsComplaints.Tables[0].Rows[0]["StatusID"].ToString());
                if (Status == 4)
                {
                    btn_Submit.Visible = true;
                }
                if (Status == 9 || Status == 10)
                {
                    if (Detected)
                    {
                        btn_Submit.Visible = true;
                    }
                }
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
                //objCommon.BindDropDownLists(ddlDist, dt1, "DistName", "DistCode", "0");
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
                lblError.Text = "";
                if (string.IsNullOrEmpty(txtInspectionDate.Text))
                {
                    lblError.Text = "Please Enter Inspection Date";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(txtIOfficer.Text))
                {
                    lblError.Text = "Please Enter Inspection Officer";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (string.IsNullOrEmpty(ddl_Crime.SelectedValue))
                {
                    lblError.Text = "Please Enter Crime Detection Status";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (ddlStatus.SelectedValue == "0")
                {
                    lblError.Text = "Please Select the Status...";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (divdetected.Visible == true)
                {
                    if (string.IsNullOrEmpty(txtCrimeLocation.Text))
                    {
                        lblError.Text = "Please Enter Crime Location";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (string.IsNullOrEmpty(txtCOR.Text))
                    {
                        lblError.Text = "Please Enter COR No";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (string.IsNullOrEmpty(txtParrested.Text))
                    {
                        lblError.Text = "Please Enter Persons Arrested";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (string.IsNullOrEmpty(txtContrabandSeized.Text))
                    {
                        lblError.Text = "Please Enter Contraband Seized";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    if (string.IsNullOrEmpty(txtCValue.Text))
                    {
                        lblError.Text = "Please Enter Contraband Value(INR)";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                //if (string.IsNullOrEmpty(txtRemarks.Text))
                //{
                //    lblError.Text = "Please Enter Remarks";
                //    lblError.ForeColor = System.Drawing.Color.Red;
                //    return;
                //}
                Byte[] Filebytes = null;
                string FileName1 = null;
                if (divATR.Visible == true)
                {
                    if (string.IsNullOrEmpty(txtATR.Text))
                    {
                        lblError.Text = "Please Enter ATR";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    if (string.IsNullOrEmpty(txtCasesBooked.Text))
                    {
                        lblError.Text = "Please Enter Cases Booked";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (string.IsNullOrEmpty(txtPersonsArrested.Text))
                    {
                        lblError.Text = "Please Enter Persons Arrested";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (string.IsNullOrEmpty(ddlSeizure.SelectedValue))
                    {
                        lblError.Text = "Please Enter Seizure Type";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (string.IsNullOrEmpty(txtVehiclesSeized.Text) && divvehicle.Visible == true)
                    {
                        lblError.Text = "Please Enter Vehicles Seized";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (string.IsNullOrEmpty(ddlContraband.SelectedValue) && divContraband.Visible == true)
                    {
                        lblError.Text = "Please Enter Contraband Type";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (string.IsNullOrEmpty(txtQuantity.Text) && divContraband1.Visible == true)
                    {
                        lblError.Text = "Please Enter Quantity Seized(litres)";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (string.IsNullOrEmpty(ddlIllicitLiquor.SelectedValue) && divIllicit.Visible == true)
                    {
                        lblError.Text = "Please Enter IllicitLiquor";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (string.IsNullOrEmpty(ddlNdps.SelectedValue) && divNDPS.Visible == true)
                    {
                        lblError.Text = "Please Enter Ndps";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (string.IsNullOrEmpty(txtUndersection.Text))
                    {
                        lblError.Text = "Please Enter U/S";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }


                    if (FileUpload_ATR.HasFile)
                    {
                        Stream fs = FileUpload_ATR.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        Filebytes = bytes;
                        string mime = MimeType.GetMimeType(bytes, FileUpload_ATR.PostedFile.FileName);
                        string FileName = FileUpload_ATR.PostedFile.FileName.ToString();
                        FileName1 = FileUpload_ATR.PostedFile.FileName.ToString();
                        if (mime == "application/pdf" || mime == ".jpeg")
                        {
                            int len = FileUpload_ATR.PostedFile.ContentLength;
                            if ((len / 1024) > 5120)
                            {

                                objCommon.ShowAlertMessage("File size is exceeded");
                                FileUpload_ATR.Focus();
                                return;
                            }
                        }
                        else
                        {
                            lblError.Text = "Please Upload Valid Document";
                            lblError.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                    else
                    {
                        lblError.Text = "Please Upload Document";
                        lblError.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                ECMSBE.AtrPreliminaryID = 0;
                ECMSBE.ComplaintID = txtComplaintID.Text;
                ECMSBE.InspectionDate = Convert.ToDateTime(txtInspectionDate.Text.ToString().Trim());
                ECMSBE.InspectingOfficerName = txtIOfficer.Text;
                ECMSBE.CrimeDetectionCode = ddl_Crime.SelectedValue;
                ECMSBE.CrimeLocation = txtCrimeLocation.Text;
                ECMSBE.CorNo = txtCOR.Text;
                ECMSBE.PersonsArrested = txtParrested.Text;
                if (string.IsNullOrEmpty(txtContrabandSeized.Text.ToString()))
                {
                    ECMSBE.ContrabandSeized = 0;
                }
                else
                {
                    ECMSBE.ContrabandSeized = Convert.ToInt32(txtContrabandSeized.Text.ToString());
                }
                ECMSBE.ContrabandValueRs = txtCValue.Text;
                ECMSBE.Remarks = null;
                ECMSBE.Status = ddlStatus.SelectedValue;
                ECMSBE.Action = "AtrPreliminary";
                if (divATR.Visible == true)
                {
                    ECMSBE.AtrNo = Convert.ToInt32(txtATR.Text);
                    ECMSBE.CasesBooked = txtCasesBooked.Text;
                    ECMSBE.SeizureType = Convert.ToInt16(ddlSeizure.SelectedValue);
                    ECMSBE.NumberOfVehiclesSeized = txtVehiclesSeized.Text;
                    ECMSBE.ContrabandType = Convert.ToInt16(ddlContraband.SelectedValue);
                    if (!string.IsNullOrEmpty(txtQuantity.Text))
                    {
                        ECMSBE.QuantitySeizedInLitres = Convert.ToDecimal(txtQuantity.Text);
                    }
                    else
                    {
                        ECMSBE.QuantitySeizedInLitres = 0;
                    }

                    ECMSBE.IllicitLiquor = Convert.ToInt32(ddlIllicitLiquor.SelectedValue);
                    ECMSBE.Ndps = Convert.ToInt32(ddlNdps.SelectedValue);
                    ECMSBE.UnderSection = txtUndersection.Text.ToUpper();
                    //ECMSBE.DocumentFile = null;
                    ECMSBE.DocumentFile = Filebytes;
                    ECMSBE.DocumentName = FileName1.ToString();
                    ECMSBE.Action = "Atr";
                }
                bool result = false;
                result = ECMSDAL.EnquiryForm(ECMSBE, ConnKey);
                if (result)
                {
                    lblResultMessage.Text = "Inserted Successfully..";
                    lblResultMessage.ForeColor = System.Drawing.Color.Green;
                    //clear();
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
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }

        protected void ddlSeizure_SelectedIndexChanged(object sender, EventArgs e)
        {
            divvehicle.Visible = false;
            divContraband.Visible = false;
            divContraband1.Visible = false;
            if (ddlSeizure.SelectedValue == "1")
            {
                divvehicle.Visible = true;
            }
            if (ddlSeizure.SelectedValue == "2")
            {
                divContraband.Visible = true;
                divContraband1.Visible = true;
            }
        }

        protected void ddlContraband_SelectedIndexChanged(object sender, EventArgs e)
        {
            divIllicit.Visible = false;
            divNDPS.Visible = false;
            if (ddlContraband.SelectedValue == "1")
            {
                divIllicit.Visible = true;
            }
            if (ddlContraband.SelectedValue == "2")
            {
                divNDPS.Visible = true;
            }
        }

        protected void ddl_Crime_SelectedIndexChanged(object sender, EventArgs e)
        {
            divdetected.Visible = false;
            if (ddl_Crime.SelectedValue == "1")
            {
                divdetected.Visible = true;
            }
        }
    }
}