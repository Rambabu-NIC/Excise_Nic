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
    public partial class Public_Complaint_Form : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        ECMS_BE ECMSBE = new ECMS_BE();
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
                BindComplaintSource();


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
        protected void btn_Submit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtName.Text))
            {
                lblError.Text = "Please Enter Name";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                lblError.Text = "Please Enter Valid Phone Number";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (!string.IsNullOrEmpty(txtPhone.Text) && txtPhone.Text.Length < 10)
            {
                lblError.Text = "Please Enter Valid Phone Number";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }

            //if (string.IsNullOrEmpty(txtAadhaar.Text))
            //{
            //    lblError.Text = "Please Enter Aadhaar Number";
            //    lblError.ForeColor = System.Drawing.Color.Red;
            //    return;
            //}
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                lblError.Text = "Please Enter Email";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlDist.SelectedValue.ToString() == "")
            {
                lblError.Text = "Please Select District";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlMand.SelectedValue.ToString() == "")
            {
                lblError.Text = "Please Select Mandal";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (ddlVill.SelectedValue.ToString() == "")
            {
                lblError.Text = "Please Select Village";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (string.IsNullOrEmpty(txtComplaintdtls.Text))
            {
                lblError.Text = "Please Enter Complaint Details";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (FileUpload1.HasFile)
            {
                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string mime = MimeType.GetMimeType(bytes, FileUpload1.PostedFile.FileName);
                string FileName = FileUpload1.PostedFile.FileName.ToString();
                if (mime == "application/pdf" || mime == ".jpeg")
                {
                    int len = FileUpload1.PostedFile.ContentLength;
                    if ((len / 1024) > 5120)
                    {

                        objCommon.ShowAlertMessage("File size is exceeded");
                        FileUpload1.Focus();
                        return;
                    }
                }
                else
                {
                    lblError.Text = "Please Upload Valid Document";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                DataTable dtt = new DataTable();
                dtt = new DataTable();
                ECMSBE.Name = txtName.Text.ToUpper();
                ECMSBE.Phone = txtPhone.Text;
                ECMSBE.Aadhaar = txtAadhaar.Text;
                ECMSBE.Email = txtEmail.Text;
                ECMSBE.DistrictID = ddlDist.SelectedValue;
                ECMSBE.MandalID = ddlMand.SelectedValue;
                ECMSBE.VillageID = ddlVill.SelectedValue;
                ECMSBE.ComplaintDetails = txtComplaintdtls.Text;
                ECMSBE.ComplaintSource = ddlComplaintSource.SelectedValue;
                ECMSBE.CreatedBy = "";
                ECMSBE.DocumentFile = bytes;
                ECMSBE.DocumentName = "Complaint Attachment";

                DataTable result = ECMSDAL.ComplaintRegistration(ECMSBE, ConnKey);
                if (result.Rows.Count > 0)
                {
                    lblError.Text = "";
                    lblError.Text = "Your complaint is lodged successfully with Complaint ID:" + result.Rows[0]["ComplaintID"].ToString() + " ";
                    lblError.ForeColor = System.Drawing.Color.Green;
                    objCommon.ShowAlertMessage("Your complaint is lodged successfully with Complaint ID:" + result.Rows[0]["ComplaintID"].ToString() + " ");
                    Clear();
                    lblError.Visible = false;
                }
                else
                {
                    objCommon.ShowAlertMessage("No Data Found");

                }
            }
            else
            {
                lblError.Text = "Please Upload Document";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }

        }

        protected void Clear()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtAadhaar.Text = "";
            txtEmail.Text = "";
            ddlDist.SelectedValue = "";
            ddlMand.SelectedValue = "";
            ddlVill.SelectedValue = "";
            txtComplaintdtls.Text = "";
            ddlComplaintSource.SelectedValue = "0";
            FileUpload1.Dispose();
            btn_Submit.Visible = false;
        }
        protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMandal();
        }

        protected void ddlMand_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVillage();
        }
    }
}