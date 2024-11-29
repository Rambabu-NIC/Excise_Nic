using Excise_BE;
using Excise_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI.DPEO
{
    public partial class DepeoEventPermission : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        SupplierDAL objDL = new SupplierDAL();
        Master_DAL ObjMDL = new Master_DAL();
        CommonFuncs objCommon = new CommonFuncs();
        SampleSqlInjectionScreeningModule obj = new SampleSqlInjectionScreeningModule();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        Validate objValidate = new Validate();
        IFormatProvider provider = new System.Globalization.CultureInfo("en-IN", true);
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
                Response.Redirect("~/Error.aspx");
            }
            else
            {
                string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
                string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
                int len = http_hos.Length;
                if (http_ref.IndexOf(http_hos, 0) < 0)
                {
                    Response.Redirect("~/Error.aspx");
                }
            }
            /*KILL COOKIE & clear Caching*/
            PrevBrowCache.enforceNoCache();
            if (Session["Role"] != null && Session["Role"].ToString() == "4" && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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

                //lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

                // BindTypeofManf();
                pannelOK.Visible = false;
                Viewdata();
                ViewdataT();
                

            }
        }
        protected void GvSupplier_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "View")
                {
                    DataTable dt = new DataTable();

                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                    pannelOK.Visible = true;
                    objBE = new Supplier_BE();
                    DataTable dt1 = new DataTable();
                    objBE.Reg_Code = ((Label)(gRow.FindControl("lblTypecode"))).Text;
                    objBE.Action = "SUPDEV";
                    dt1 = objDL.EventReg_IUR(objBE, ConnKey);
                    if (dt1.Rows.Count > 0)
                    {
                        lblReg.Text = dt1.Rows[0]["AppReg_No"].ToString();
                        txtAppliName.Text = dt1.Rows[0]["App_Name"].ToString();
                        txtAdharNum.Text = dt1.Rows[0]["Aadhaar"].ToString();
                        txtMobile.Text = dt1.Rows[0]["Mob_No"].ToString();
                        txtEmail.Text = dt1.Rows[0]["Email"].ToString();
                        txtAge.Text = dt1.Rows[0]["Age"].ToString();
                        txtFatherName.Text = dt1.Rows[0]["FName"].ToString();
                        txtAdd.Text = dt1.Rows[0]["Res_Address"].ToString();
                        txtHsNum.Text = dt1.Rows[0]["HNo"].ToString();
                        txtNmePrem.Text = dt1.Rows[0]["Name_Premises"].ToString();
                        txtStreet.Text = dt1.Rows[0]["Street"].ToString();
                        txtEast.Text = dt1.Rows[0]["Bdr_East"].ToString();
                        txtWest.Text = dt1.Rows[0]["Bdr_West"].ToString();
                        txtNorth.Text = dt1.Rows[0]["Bdr_North"].ToString();
                        txtSouth.Text = dt1.Rows[0]["Bdr_South"].ToString();
                        objBE.Statecode = "36";
                        lblRDist.Text = dt1.Rows[0]["DistName"].ToString();
                        lblbRMand.Text = dt1.Rows[0]["MandName"].ToString();
                        lblbRVill.Text = dt1.Rows[0]["VillName"].ToString();
                        // BindRevdistVill();
                        lblExDistCode.Text = dt1.Rows[0]["ExDist_Cd"].ToString();
                        lblExStation.Text = dt1.Rows[0]["ExStation"].ToString();
                        lblExDist.Text = dt1.Rows[0]["ExDist"].ToString();
                        lblExStationCd.Text = dt1.Rows[0]["ExStationCode"].ToString();
                        lblGHMC.Text = dt1.Rows[0]["GHMC"].ToString();
                        //BindExciseDistrict();
                        //ddlExciseDistrict.SelectedValue = dt1.Rows[0]["ExDist_Cd"].ToString();

                        //BindExMandal();
                        ////  ddlExciseStation.SelectedValue = dt1.Rows[0]["ExStationCode"].ToString();
                        ////  ddlWhether.SelectedValue = dt1.Rows[0]["Rule7"].ToString();
                        ddlEvntTm.Text = dt1.Rows[0]["Eventtime"].ToString();
                        lblRule7.Text = dt1.Rows[0]["Rule7"].ToString();
                        txtEvnDate.Text = dt1.Rows[0]["Date"].ToString();
                        txtEvent.Text = dt1.Rows[0]["Event_Occasion"].ToString();

                        //ddlEvntType.SelectedValue = dt1.Rows[0]["Event_ID"].ToString();
                        Label5.Text = dt1.Rows[0]["Event"].ToString();

                        // ddlLicenceFee.SelectedValue = dt1.Rows[0]["Payment_Type"].ToString();
                        lblFee.Text = dt1.Rows[0]["License_Fee"].ToString();

                        //string a = dt1.Rows[0]["ShoInspecDt"].ToString();
                        //added
                        txtDtInsp.Text = dt1.Rows[0]["ShoInspecDt"].ToString();
                        txtDtInsp.Enabled = false;
                        txtRemarks.Text = dt1.Rows[0]["ShoRemarks"].ToString();
                        txtRemarks.Enabled = false;
                        // lblPaymentDetails.Text = dt1.Rows[0]["PaymentDetails"].ToString();


                        DataTable dt2 = new DataTable();
                        objBE.Reg_Code = ((Label)(gRow.FindControl("lblTypecode"))).Text;
                        objBE.Action = "PDR";
                        dt2 = objDL.EventReg_IUR(objBE, ConnKey);
                        if (dt2.Rows.Count > 0)
                        {
                            lblPaymentDetailsNo.Visible = false;
                            dltPaymentDetails.Visible = true;
                            dltPaymentDetails.DataSource = dt2;
                            dltPaymentDetails.DataBind();
                        }
                        else
                        {
                            dltPaymentDetails.Visible = false;
                            lblPaymentDetailsNo.Visible = true;
                            lblPaymentDetailsNo.Text = "No Payment Details";
                        }

                    }

                }
                else
                {
                    pannelOK.Visible = false;
                }

                if (e.CommandName == "InsView")
                {
                    //  getapplicantdocs();

                    DataTable dt = new DataTable();
                    GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Label lblTypecode = (Label)gvrow.FindControl("lblTypecode");

                    objBE.Reg_Code = lblTypecode.Text;
                    //objBE.ApplicationType = lbl_Apptype.Text;
                    objBE.Action = "DPGET";
                    dt = objDL.EventReg_IUR(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["Doccontentt"];
                        // string Filetype = dt.Rows[0]["UploadDco_FileType"].ToString();
                        // string fileName = "Document_Details.pdf"; //dt.Rows[0]["UploadDco_Name"].ToString();
                        //if (Filetype.ToLower() == ".pdf")
                        //{
                        Session["bytes"] = null;
                        Session["bytes"] = bytes;
                        string url = "../PrintPage.aspx";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.open('");
                        sb.Append(url);
                        sb.Append("','_blank');");
                        sb.Append("</script>");

                        ClientScript.RegisterStartupScript(this.GetType(),
                                     "script", sb.ToString());

                        // }
                        //ImgDoc.Visible = false;
                        //IpdfDoc.Visible = true;
                        //System.IO.File.WriteAllBytes(Server.MapPath("~/Files/Uploaded_Bill.pdf"), bytes);
                        //IpdfDoc.Attributes.Add("src", "../../Files/Uploaded_Bill.pdf");
                        //mp1.Show();
                    }

                }

                if (e.CommandName == "ViewDoc")
                {
                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                    RegDoc.Visible = true;
                    lblDocReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;
                    lblDocReg.Visible = false;
                    getapplicantdocs(lblDocReg.Text);
                }
                else
                {
                    RegDoc.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        protected void GvSupplier_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    DropDownList ddl_TransDPEO = (e.Row.FindControl("ddl_TransDPEO") as DropDownList);

                    objBE.Action = "DPR";
                    DataTable dt = new DataTable();
                    dt = objDL.DistrictStationMapping(objBE, ConnKey);
                    objCommon.BindDropDownLists(ddl_TransDPEO, dt, "ExDist", "ExDist_Cd", "0");
                    Label lblTransDPEO = (e.Row.FindControl("lblTransDPEO") as Label);
                    if (lblTransDPEO.Text != "")
                        ddl_TransDPEO.SelectedValue = lblTransDPEO.Text;
                }
                catch { }
            }
        }

        protected void GvTransApp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "View")
                {
                    DataTable dt = new DataTable();

                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                    pannelOK.Visible = true;
                    objBE = new Supplier_BE();
                    DataTable dt1 = new DataTable();
                    objBE.Reg_Code = ((Label)(gRow.FindControl("lblTypecode"))).Text;
                    objBE.Action = "SUPDEV";
                    dt1 = objDL.EventReg_IUR(objBE, ConnKey);
                    if (dt1.Rows.Count > 0)
                    {
                        lblReg.Text = dt1.Rows[0]["AppReg_No"].ToString();
                        txtAppliName.Text = dt1.Rows[0]["App_Name"].ToString();
                        txtAdharNum.Text = dt1.Rows[0]["Aadhaar"].ToString();
                        txtMobile.Text = dt1.Rows[0]["Mob_No"].ToString();
                        txtEmail.Text = dt1.Rows[0]["Email"].ToString();
                        txtAge.Text = dt1.Rows[0]["Age"].ToString();
                        txtFatherName.Text = dt1.Rows[0]["FName"].ToString();
                        txtAdd.Text = dt1.Rows[0]["Res_Address"].ToString();
                        txtHsNum.Text = dt1.Rows[0]["HNo"].ToString();
                        txtNmePrem.Text = dt1.Rows[0]["Name_Premises"].ToString();
                        txtStreet.Text = dt1.Rows[0]["Street"].ToString();
                        txtEast.Text = dt1.Rows[0]["Bdr_East"].ToString();
                        txtWest.Text = dt1.Rows[0]["Bdr_West"].ToString();
                        txtNorth.Text = dt1.Rows[0]["Bdr_North"].ToString();
                        txtSouth.Text = dt1.Rows[0]["Bdr_South"].ToString();
                        objBE.Statecode = "36";
                        lblRDist.Text = dt1.Rows[0]["DistName"].ToString();
                        lblbRMand.Text = dt1.Rows[0]["MandName"].ToString();
                        lblbRVill.Text = dt1.Rows[0]["VillName"].ToString();
                        // BindRevdistVill();
                        lblExDistCode.Text = dt1.Rows[0]["ExDist_Cd"].ToString();
                        lblExStation.Text = dt1.Rows[0]["ExStation"].ToString();
                        lblExDist.Text = dt1.Rows[0]["ExDist"].ToString();
                        lblExStationCd.Text = dt1.Rows[0]["ExStationCode"].ToString();
                        lblGHMC.Text = dt1.Rows[0]["GHMC"].ToString();
                        //BindExciseDistrict();
                        //ddlExciseDistrict.SelectedValue = dt1.Rows[0]["ExDist_Cd"].ToString();

                        //BindExMandal();
                        ////  ddlExciseStation.SelectedValue = dt1.Rows[0]["ExStationCode"].ToString();
                        ////  ddlWhether.SelectedValue = dt1.Rows[0]["Rule7"].ToString();
                        ddlEvntTm.Text = dt1.Rows[0]["Eventtime"].ToString();
                        lblRule7.Text = dt1.Rows[0]["Rule7"].ToString();
                        txtEvnDate.Text = dt1.Rows[0]["Date"].ToString();
                        txtEvent.Text = dt1.Rows[0]["Event_Occasion"].ToString();

                        //ddlEvntType.SelectedValue = dt1.Rows[0]["Event_ID"].ToString();
                        Label5.Text = dt1.Rows[0]["Event"].ToString();

                        // ddlLicenceFee.SelectedValue = dt1.Rows[0]["Payment_Type"].ToString();
                        lblFee.Text = dt1.Rows[0]["License_Fee"].ToString();

                        //string a = dt1.Rows[0]["ShoInspecDt"].ToString();
                        //added
                        txtDtInsp.Text = dt1.Rows[0]["ShoInspecDt"].ToString();
                        txtDtInsp.Enabled = false;
                        txtRemarks.Text = dt1.Rows[0]["ShoRemarks"].ToString();
                        txtRemarks.Enabled = false;
                        //  lblPaymentDetails.Text = dt1.Rows[0]["PaymentDetails"].ToString();

                        DataTable dt2 = new DataTable();
                        objBE.Reg_Code = ((Label)(gRow.FindControl("lblTypecode"))).Text;
                        objBE.Action = "PDR";
                        dt2 = objDL.EventReg_IUR(objBE, ConnKey);
                        if (dt2.Rows.Count > 0)
                        {
                            lblPaymentDetailsNo.Visible = false;
                            dltPaymentDetails.Visible = true;
                            dltPaymentDetails.DataSource = dt2;
                            dltPaymentDetails.DataBind();
                        }
                        else
                        {
                            dltPaymentDetails.Visible = false;
                            lblPaymentDetailsNo.Visible = true;
                            lblPaymentDetailsNo.Text = "No Payment Details";
                        }

                    }

                }
                else
                {
                    pannelOK.Visible = false;
                }

                if (e.CommandName == "InsView")
                {
                    //  getapplicantdocs();

                    DataTable dt = new DataTable();
                    GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Label lblTypecode = (Label)gvrow.FindControl("lblTypecode");

                    objBE.Reg_Code = lblTypecode.Text;
                    //objBE.ApplicationType = lbl_Apptype.Text;
                    objBE.Action = "DPGET";
                    dt = objDL.EventReg_IUR(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["Doccontentt"];
                        // string Filetype = dt.Rows[0]["UploadDco_FileType"].ToString();
                        // string fileName = "Document_Details.pdf"; //dt.Rows[0]["UploadDco_Name"].ToString();
                        //if (Filetype.ToLower() == ".pdf")
                        //{
                        Session["bytes"] = null;
                        Session["bytes"] = bytes;
                        string url = "../PrintPage.aspx";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.open('");
                        sb.Append(url);
                        sb.Append("','_blank');");
                        sb.Append("</script>");

                        ClientScript.RegisterStartupScript(this.GetType(),
                                     "script", sb.ToString());

                        // }
                        //ImgDoc.Visible = false;
                        //IpdfDoc.Visible = true;
                        //System.IO.File.WriteAllBytes(Server.MapPath("~/Files/Uploaded_Bill.pdf"), bytes);
                        //IpdfDoc.Attributes.Add("src", "../../Files/Uploaded_Bill.pdf");
                        //mp1.Show();
                    }

                }

                if (e.CommandName == "ViewDoc")
                {
                    GridViewRow gRow = (GridViewRow)((Control)e.CommandSource).NamingContainer;

                    RegDoc.Visible = true;
                    lblDocReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;
                    lblDocReg.Visible = false;
                    getapplicantdocs(lblDocReg.Text);
                }
                else
                {
                    RegDoc.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


        protected void GvTransApp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    DropDownList ddl_TransDPEO = (e.Row.FindControl("ddl_TransDPEO") as DropDownList);

                    objBE.Action = "DPR";
                    DataTable dt = new DataTable();
                    dt = objDL.DistrictStationMapping(objBE, ConnKey);
                    objCommon.BindDropDownLists(ddl_TransDPEO, dt, "ExDist", "ExDist_Cd", "0");
                    Label lblTransDPEO = (e.Row.FindControl("lblTransDPEO") as Label);
                    if (lblTransDPEO.Text != "")
                        ddl_TransDPEO.SelectedValue = lblTransDPEO.Text;
                }
                catch { }
            }
        }

        protected void GvTransApp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvTransApp.PageIndex = e.NewPageIndex;
                ViewdataT();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }
        }
        protected void grddocs_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            try
            {

                if (e.CommandName == "View")
                {
                    DataTable dt = new DataTable();
                    GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    Label lblDocid = (Label)gvrow.FindControl("lbldoccd");
                    Label lblAppid = (Label)gvrow.FindControl("lblAppid");
                    Label lblDocSno = (Label)gvrow.FindControl("lbldocsno");

                    Label lbl_Apptype = (Label)gvrow.FindControl("lbl_Apptype");

                    objBE.UploadDco_Code = lblDocid.Text;
                    objBE.SNo = lblDocSno.Text;
                    objBE.Reg_Code = lblAppid.Text;
                    objBE.ApplicationType = lbl_Apptype.Text;
                    objBE.Action = "V";
                    dt = objDL.GetGetUploadDocSelectDAL(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        byte[] bytes = (byte[])dt.Rows[0]["UploadDco_File"];
                        // string Filetype = dt.Rows[0]["UploadDco_FileType"].ToString();
                        // string fileName = "Document_Details.pdf"; //dt.Rows[0]["UploadDco_Name"].ToString();
                        //if (Filetype.ToLower() == ".pdf")
                        //{
                        Session["bytes"] = null;
                        Session["bytes"] = bytes;
                        string url = "../PrintPage.aspx";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.open('");
                        sb.Append(url);
                        sb.Append("','_blank');");
                        sb.Append("</script>");

                        ClientScript.RegisterStartupScript(this.GetType(),
                                     "script", sb.ToString());

                        // }
                        //ImgDoc.Visible = false;
                        //IpdfDoc.Visible = true;
                        //System.IO.File.WriteAllBytes(Server.MapPath("~/Files/Uploaded_Bill.pdf"), bytes);
                        //IpdfDoc.Attributes.Add("src", "../../Files/Uploaded_Bill.pdf");
                        //mp1.Show();
                    }


                }
            }

            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }


        }

        protected void ddl_TransDPEO_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList lb = (DropDownList)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;

            DropDownList ddl_TransDPEO = (DropDownList)gvRow.FindControl("ddl_TransDPEO");

            if (ddl_TransDPEO.SelectedIndex != 0)
            {

                string strmfg = ddl_TransDPEO.SelectedValue;
                string[] strmfgsupplier = strmfg.Split('/');
                objBE.Action = "DPR";
                DataTable ddt = new DataTable();
                ddt = objDL.DistrictStationMapping(objBE, ConnKey);
                if (ddt.Rows.Count > 0)
                {
                    objCommon.BindDropDownLists(ddl_TransDPEO, ddt, "ExDist", "ExDist_Cd", "0");
                }
            }
            else
            {
                //ddl_UOM.Items.Clear();
                //ddl_UOM.Items.Insert(0, new ListItem("--Select---", ""));
            }
        }

        protected void getapplicantdocs(string REgNO)
        {
            try
            {
                // DataTable dt = objRegDL.GetGetUploadDocSelectDAL(Session["Licensetype"].ToString(), Session["System"].ToString(), Session["Licensem"].ToString(), Session["ApplicantId"].ToString(), ddl_Firm.SelectedValue.ToString(), "R");
                DataTable dt = new DataTable();
                objBE.ApplicationType = "1";

                objBE.Reg_Code = REgNO;

                objBE.Action = "DV";
                dt = objDL.GetGetUploadDocSelectDAL(objBE, ConnKey);
                grddocs.DataSource = dt;
                grddocs.DataBind();
                //RegDoc.Visible = true;

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UserId"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");

            }
        }



        protected void GvSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GvSupplier.PageIndex = e.NewPageIndex;
                Viewdata();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                objCommon.ShowAlertMessage(ex.ToString());
            }
        }
        protected void Viewdata()
        {
          
            DataTable dt = null;
            try
            {
                objBE.Action = "SUPDE";
                objBE.ExDistCode = Session["ExDist_Cd"].ToString();//"07";//
                                                                   // objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                dt = objDL.EventReg_IUR(objBE, ConnKey);


                if (dt.Rows.Count > 0)
                {
                    Session["RegId"] = dt.Rows[0][0].ToString();

                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    GvSupplier.Visible = true;
                    GvSupplier.DataSource = dt;
                    GvSupplier.DataBind();
                    dt.Dispose();




                }
                else
                {
                    GvSupplier.Visible = false;
                    GvSupplier.DataSource = null;
                    GvSupplier.DataBind();
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    //objCommon.ShowAlertMessage("No Data Found For This ");

                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        protected void ViewdataT()
        {

            DataTable dt = null;
            try
            {
                objBE.Action = "TSUPDE";
                objBE.ExDistCode = Session["ExDist_Cd"].ToString();//"07";//
                                                                   // objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                dt = objDL.EventReg_IUR(objBE, ConnKey);


                if (dt.Rows.Count > 0)
                {
                    Session["RegId"] = dt.Rows[0][0].ToString();

                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    GvTransApp.Visible = true;
                    GvTransApp.DataSource = dt;
                    GvTransApp.DataBind();
                    dt.Dispose();




                }
                else
                {
                    // lblTypeOfFirm.Text = dt.Rows[0]["FirmType_Name"].ToString();
                    //objCommon.ShowAlertMessage("No Data Found For This ");
                    GvTransApp.DataSource = null;
                    GvTransApp.DataBind();
                    GvTransApp.Visible = false;
                }

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
       
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
            lblReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;

            DataTable dt = new DataTable();
            objBE.Reg_Code = lblReg.Text; //lblDocReg.Text; ;//
            objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
            objBE.Action = "DPAPR";
            dt = objDL.EventReg_IUR(objBE, ConnKey);
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                Session["RegId"] = dt.Rows[0][0].ToString();
                Viewdata();
            }
        }
        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
            lblReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;
            lblTDPEO.Text = ((DropDownList)(gRow.FindControl("ddl_TransDPEO"))).SelectedValue;

            DataTable dt = new DataTable();
            objBE.Reg_Code = lblReg.Text; //lblDocReg.Text; ;//
            objBE.ExDistCode = lblTDPEO.Text;
            objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
            objBE.Action = "TDPEO";
            dt = objDL.EventReg_IUR(objBE, ConnKey);
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                //Session["RegId"] = dt.Rows[0][0].ToString();
                Viewdata();
            }
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
            lblReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;

            DataTable dt = new DataTable();
            objBE.Reg_Code = lblReg.Text; //lblDocReg.Text; ;//
            objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
            objBE.Action = "DPREJ";
            dt = objDL.EventReg_IUR(objBE, ConnKey);
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                Session["RegId"] = dt.Rows[0][0].ToString();
                Viewdata();
            }
        }
        protected void btn_Update_Click(object sender, EventArgs e)
        {

            try
            {
                // if (Validate())
                {
                    objBE.Reg_Code = lblReg.Text;
                    //objBE.AppName = txtAppliName.Text;
                    //objBE.Aadhaar = txtAdharNum.Text;
                    //objBE.MobNo = txtMobile.Text;
                    //objBE.Email = txtEmail.Text;
                    //objBE.Age = txtAge.Text;
                    //objBE.FatherName = txtFatherName.Text;
                    //objBE.Address = txtAdd.Text;
                    //objBE.HouseNo = txtHsNum.Text;
                    //objBE.NameOfPerm = txtNmePrem.Text;
                    //objBE.Street = txtStreet.Text;
                    //objBE.BdrEast = txtEast.Text;
                    //objBE.BdrWest = txtWest.Text;
                    //objBE.BdrNorth = txtNorth.Text;
                    //objBE.BdrSouth = txtSouth.Text;
                    //objBE.DistCode = ddlRevDistrict.SelectedValue;
                    //objBE.MandCode = ddlMandal.SelectedValue;
                    //objBE.VillCode = ddlLocality.SelectedValue;
                    //objBE.ExDistCode = ddlExciseDistrict.SelectedValue;
                    //objBE.ExStation = ddlExciseStation.SelectedValue;
                    //objBE.Rule7 = ddlWhether.SelectedItem.ToString();
                    //objBE.EDate = DateTime.Parse(txtEvnDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.None).ToString("yyyy-MM-dd");
                    //objBE.Eventtime = ddlEvntTm.SelectedValue;
                    //objBE.EventOccasion = txtEvent.Text;
                    //objBE.License_Fee = txtLicen.Text;
                    objBE.LicData = DateTime.Parse(txtDtInsp.Text.Trim(), provider, System.Globalization.DateTimeStyles.None).ToString("yyyy-MM-dd");
                    objBE.Remarks = txtRemarks.Text;
                    //objBE.TotalFeePaid = Convert.ToDecimal(txtFee.Text);
                    //objBE.TotalFeePaid = Convert.ToDecimal(txtFee.Text.Trim());

                    objBE.Statecode = "36";

                    objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
                    //objBE.UserName = Session["User"].ToString();
                    objBE.Action = "SHINS";
                    DataTable dt = new DataTable();
                    dt = objDL.EventReg_IUR(objBE, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        pannelOK.Visible = false;
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        //if (dt.Rows[0]["Status"].ToString() == "2")
                        //{

                        //   lblLock.Visible = true;
                        //   btnUpdate.Visible = true;


                        //}
                        //else { 

                        //lblLock.Visible=false;
                        //lblLock.Visible = false;

                        //}

                        // Viewdata();

                    }
                }

            }
            catch
            {

            }
        }
        //protected void btnSave_Click(object sender, EventArgs e)
        //{



        //    DataTable dt = new DataTable();

        //    string fileNme = "", fileSizee = "", fileTypee = "";
        //    byte[] contentt = null;
        //    if (fluDoc.HasFile)
        //    {
        //        Stream fs = fluDoc.PostedFile.InputStream;
        //        BinaryReader br = new BinaryReader(fs);
        //        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //        string fileext = Path.GetExtension(fluDoc.PostedFile.FileName);
        //        //string mime =  MimeType.GetMimeType(bytes, FileUpload1.PostedFile.FileName);
        //        if (fileext == ".jpg" || fileext == ".PNG" || fileext == ".png" || fileext == ".jpeg" || fileext == ".JPG")
        //        {
        //            int len = fluDoc.PostedFile.ContentLength;
        //            if ((len / 1024) > 2048)
        //            {
        //                objCommon.ShowAlertMessage("File size is exceeded");
        //                fluDoc.Focus();
        //                return;
        //            }

        //            string fn = Path.GetFileName(fluDoc.PostedFile.FileName);
        //            fileNme = fn;
        //            fileSizee = len.ToString();
        //            fileTypee = fileext;
        //            contentt = bytes;
        //            dt = new DataTable();

        //        }

        //        else
        //        {
        //            objCommon.ShowAlertMessage("Please Upload .JPG/.jpg/.png/.PNG/.jpeg");
        //        }

        //        objBE.fileNme = fileNme;
        //        objBE.fileSizee = fileSizee;
        //        objBE.fileTypee = fileTypee;
        //        objBE.contentt = bytes;
        //        objBE.Reg_Code = lblDocReg.Text;
        //        objBE.DocRemarks = txtDocRemarks.Text;
        //        objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
        //        //objBE.UserName = Session["User"].ToString();
        //        objBE.Action = "Doc";

        //        dt = objDL.EventReg_IUR(objBE, ConnKey);
        //        if (dt.Rows.Count > 0)
        //        {
        //            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());

        //            Session["RegId"] = dt.Rows[0][0].ToString();



        //        }
        //    }  




        //}
        protected void btn_DpeoUpdate(object sender, EventArgs e)
        {

            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
            lblReg.Text = ((Label)(gRow.FindControl("lblTypecode"))).Text;

            DataTable dt = new DataTable();
            objBE.Reg_Code = lblReg.Text; //lblDocReg.Text; ;//
            objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
            objBE.Action = "SHSUB";
            dt = objDL.EventReg_IUR(objBE, ConnKey);
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                Session["RegId"] = dt.Rows[0][0].ToString();
                Viewdata();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            //byte[] contentt = null;
            //if (fluDoc.HasFile)
            //{
            //    Stream fs = fluDoc.PostedFile.InputStream;
            //    BinaryReader br = new BinaryReader(fs);
            //    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            //    string mime = MimeType.GetMimeType(bytes, fluDoc.PostedFile.FileName);

            //    //Set the contenttype based on File Extension
            //    if (mime == "application/pdf")
            //    {
            //        int len = fluDoc.PostedFile.ContentLength;
            //        if ((len / 1024) > 5120)
            //        {

            //            objCommon.ShowAlertMessage("File size is exceeded");
            //            fluDoc.Focus();
            //            return;
            //        }
            //        string fileTypee = Path.GetExtension(fluDoc.PostedFile.FileName);
            //        string fileNme = Path.GetFileName(fluDoc.PostedFile.FileName);
            //        objBE.fileTypee = fileTypee;
            //        objBE.contentt = bytes;
            //        objBE.fileSizee = len.ToString();

            //        byte[] File = br.ReadBytes((Int32)fs.Length);

            //        objBE.fileNme = fileNme;
            //        objBE.fileSizee = len.ToString();
            //        objBE.fileTypee = fileTypee;
            //        objBE.contentt = bytes;
            //        objBE.Reg_Code = lblDocReg.Text;
            //        objBE.DocRemarks = txtDocRemarks.Text;
            //        objBE.IPAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
            //        //objBE.UserName = Session["User"].ToString();
            //        objBE.Action = "Doc";

            //        dt = objDL.EventReg_IUR(objBE, ConnKey);
            //        if (dt.Rows.Count > 0)
            //        {
            //            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
            //            RegDoc.Visible = false;
            //            Session["RegId"] = dt.Rows[0][0].ToString();



            //        }
            //    }




            //}
        }


    }
}