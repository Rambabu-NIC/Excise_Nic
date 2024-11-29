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
    public partial class ViewRenewalApplications : System.Web.UI.Page
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
               Session["Role"].ToString() == "7" || Session["Role"].ToString() == "50" || Session["Role"].ToString() == "27" || Session["Role"].ToString() == "55"
               || Session["Role"].ToString() == "54" || Session["Role"].ToString() == "28" || Session["Role"].ToString() == "29" || Session["Role"].ToString() == "12")
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
        public DataSet GetViewRetailerDetails
        {
            get
            {
                return ViewState["GetViewRetailerDetails"] as DataSet;
            }
            set
            {
                ViewState["GetViewRetailerDetails"] = value;
            }
        }
        public void BindDetails()
        {
            string Retailer_Code = Session["RenewalID"].ToString();
            string ApplicationNo = Session["ApplicationNo"].ToString();
            int Type_Man_Cd = Convert.ToInt32(Session["Type_Man_Cd"].ToString());
            GetViewRetailerDetails = objDL.GetViewRetailerRenewalDetails(Retailer_Code,ApplicationNo,Type_Man_Cd, ConnKey);
            if (GetViewRetailerDetails.Tables.Count > 0)
            {
                if (GetViewRetailerDetails.Tables[0].Rows.Count > 0)
                {
                    gvdetails.DataSource = GetViewRetailerDetails.Tables[0];
                    gvdetails.DataBind();
                }
                if (GetViewRetailerDetails.Tables[1].Rows.Count > 0)
                {
                    gvPaymentDetails.DataSource = GetViewRetailerDetails.Tables[1];
                    gvPaymentDetails.DataBind();
                }
                if (GetViewRetailerDetails.Tables[3].Rows.Count > 0)
                {
                    gvFlowDetails.DataSource = GetViewRetailerDetails.Tables[3];
                    gvFlowDetails.DataBind();

                    if(GetViewRetailerDetails.Tables[3].Rows.Count > 4 && Session["Role"].ToString() == "4") 
                    {
                        //btnApprove.Visible = true;
                        //btnReject.Visible = true;
                    }

                }
                if (GetViewRetailerDetails.Tables[4].Rows.Count > 0)
                {
                    DataTable TempTable = null;
                    TempTable = GetViewRetailerDetails.Tables[4];
                    foreach (DataRow row in TempTable.Rows)
                    {
                        FileUpload.Rows.Add(new Object[]
                        { row["Type_Man_Cd"],
                        row["TypeofUser"],
                        row["Application_SL_No"],
                            Convert.ToInt32(row["DocumentTypeID"]),
                          row["DocumentTypeName"].ToString(),
                          (byte[])row["DocumentFile"] });
                    }
                    gvDocumentDetails.DataSource = GetViewRetailerDetails.Tables[4];
                    gvDocumentDetails.DataBind();

                }
                if (GetViewRetailerDetails.Tables[5].Rows.Count > 0)
                { 
                    string ISBG_CD_Value = GetViewRetailerDetails.Tables[5].Rows[0]["IsBG_CD"].ToString();
                    IsBG_CD.SelectedValue = GetViewRetailerDetails.Tables[5].Rows[0]["IsBG_CD"].ToString();
                    if(IsBG_CD.SelectedValue == "1")
                    {
                        divFDR.Visible = true;
                        txtbgFdrNo.Text = GetViewRetailerDetails.Tables[5].Rows[0]["Sd_Bg_FdrNo"].ToString();
                        txtbgFdrDate.Text = GetViewRetailerDetails.Tables[5].Rows[0]["Sd_Bg_FdrDate"].ToString();
                    }
                    else
                    {
                        divCD.Visible = true;
                        txtCdChallanno.Text = GetViewRetailerDetails.Tables[5].Rows[0]["Sd_CD_Challan_No"].ToString();
                        txtcdChallndate.Text = GetViewRetailerDetails.Tables[5].Rows[0]["Sd_CD_challan_date"].ToString();
                    }
                    txtsdAmount.Text = GetViewRetailerDetails.Tables[5].Rows[0]["Sd_Amount"].ToString();
                    txtBankName.Text = GetViewRetailerDetails.Tables[5].Rows[0]["Sd_Bank"].ToString();
                    txtbranchname.Text = GetViewRetailerDetails.Tables[5].Rows[0]["Sd_BranchName"].ToString();
                    txtLicenseValidityFrom.Text = GetViewRetailerDetails.Tables[5].Rows[0]["Validity_FromDate"].ToString();
                    txtLicenseValidityTo.Text = GetViewRetailerDetails.Tables[5].Rows[0]["Validity_ToDate"].ToString();
                }
                if (GetViewRetailerDetails.Tables[2].Rows[0]["Installmet"].ToString() == "5")
                {
                    divbgDetails.Visible = false;
                }
                //if (GetSupplierDetails.Tables.Count > 0 && GetSupplierDetails.Tables[2].Rows.Count == 2)
                //{
                //    btn_Save.Visible = true;
                //}
                //else
                //{
                //    btn_Save.Visible = false;
                //    lblmsg.Text = "Please pay all the required payments..";
                //    return;
                //}
            }

        }
       
        private DataTable FinalInsertDocumentDetails()
        {
            DataTable dtCreatedetails = new DataTable();
            dtCreatedetails.Columns.Add("Type_Man_Cd", typeof(int));
            dtCreatedetails.Columns.Add("TypeofUser", typeof(string));
            dtCreatedetails.Columns.Add("Application_SL_No", typeof(int));
            dtCreatedetails.Columns.Add("DocumentTypeID", typeof(int));
            dtCreatedetails.Columns.Add("DocumentTypeName", typeof(string));
            dtCreatedetails.Columns.Add("DocumentFile", typeof(byte[]));
            return dtCreatedetails;
        }
        private DataTable FileUpload
        {
            get
            {
                if (ViewState["FileUpload"] == null)

                {
                    DataTable dt = FinalInsertDocumentDetails();
                    ViewState["FileUpload"] = dt;
                }
                return ViewState["FileUpload"] as DataTable;
            }
            set
            {
                ViewState["FileUpload"] = value;
            }
        }
        protected void gvDocumentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkbtn_Documents")
            {
                string DocumentID = e.CommandArgument.ToString();

                if (FileUpload.Rows.Count > 0)
                {
                    DataView dvSelectedApplication = new DataView(FileUpload);
                    //RowID=DocumentTypeID
                    dvSelectedApplication.RowFilter = "DocumentTypeID =" +Convert.ToInt32(DocumentID);
                    DataRow drow = dvSelectedApplication.ToTable().Rows[0];
                    string DocumentName = drow["DocumentTypeName"].ToString();
                    ShowDocument(DocumentName + ".pdf", (byte[])drow["DocumentFile"]);
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
        }
        
        protected void gvFlowDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkbtn_Documents")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                LinkButton lb = (LinkButton)row.FindControl("lnkbtn_Documents");
                var commandArgument = e.CommandArgument.ToString();
                DataRow drDetails = GetViewRetailerDetails.Tables[3].Rows[gvFlowDetails.Rows[Convert.ToInt32(commandArgument)].RowIndex];
                string Remarks = drDetails["Remarks"].ToString();
                string Document = drDetails["DocumentFile"].ToString();
                if (string.IsNullOrEmpty(Document))
                {
                    lb.Text = "No Document available";
                }
                else
                {
                    ShowDocument(Remarks + ".pdf", (byte[])drDetails["DocumentFile"]);
                }
                //string DocumentID = e.CommandArgument.ToString();

                //if (FileUpload.Rows.Count > 0)
                //{
                //    ShowDocument(DocumentName + ".pdf", (byte[])drow["DocumentFile"]);
                //}
            }
        }

        protected void gvFlowDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //int temp;
                //int Document = int.TryParse(GetViewRetailerDetails.Tables[3].Rows[e.Row.RowIndex]["DocumentFile"].ToString(), out temp) ? temp : 0;
                string Document = GetViewRetailerDetails.Tables[3].Rows[e.Row.RowIndex]["DocumentFile"].ToString();
                LinkButton lnkbtn_Documents = e.Row.FindControl("lnkbtn_Documents") as LinkButton;


                if (!string.IsNullOrEmpty(Document))
                {
                    lnkbtn_Documents.Enabled = true;
                    lnkbtn_Documents.ToolTip = "Click here for Document";
                    lnkbtn_Documents.Text = "Click..!";

                }
                else
                {
                    lnkbtn_Documents.Enabled = false;
                    lnkbtn_Documents.Text = "";
                    lnkbtn_Documents.ToolTip = "";
                }
            }
        }
    }
}