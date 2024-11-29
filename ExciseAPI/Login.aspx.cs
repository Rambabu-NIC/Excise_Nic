using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excise_DAL;
using System.Data;
using System.Web.Security;
using System.Configuration;
using Excise_BE;
namespace ExciseAPI
{
    public partial class Login : System.Web.UI.Page
    {
        Supplier_BE objBE = new Supplier_BE();
        CommonFuncs objCommon = new CommonFuncs();
        string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        BasePage basePage = new BasePage();
        protected void Page_Load(object sender, EventArgs e)
        {


            txtUname.Attributes.Add("autocomplete", "off");
            txtPwd.Attributes.Add("autocomplete", "off");
            if (!IsPostBack)
            {
                random();
                ViewState["KeyGenerator"] = Guid.NewGuid().ToString("N").Substring(0, 16);
                txtUname.Focus();
                getCaptchaImage();

            }
        }
        protected bool CheckCaptcha()
        {
            //if (captch.Text == ViewState["captchtext"].ToString())
            //{
            //    return true;
            //}
            //else
            //{
            //    lblmsg.Text = "Invalid Captcha.";
            //    captch.Text = "";
            //    return false;
            //}
            return true;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //check();
            if (Session["User"] != null)
            {
                //CheckBrowser();
                Response.Redirect("~/ErrorPage.aspx", false);
                return;
            }

            //check();
            Session.Clear();
            try
            {
                if (txtUname.Text == "")
                {
                    objCommon.ShowAlertMessage("Enter UserName");
                    txtUname.Focus();
                    return;
                }
                if (txtPwd.Text == "")
                {
                    objCommon.ShowAlertMessage("Enter Password");
                    txtPwd.Focus();
                    return;
                }
                //if (captch.Text == "")
                //{
                //    objCommon.ShowAlertMessage("Enter Captcha");
                //    captch.Focus();
                //    return;
                //}
                if (CheckCaptcha())
                {
                    Login_DL objLogin = new Login_DL();
                    objBE.Action = "Exists";
                    DataTable dtLoginExists = objLogin.getLoginDetails(txtUname.Text, objBE, ConnKey);

                    if (dtLoginExists.Rows.Count > 0)
                    {
                        if (dtLoginExists.Rows[0]["Role"].ToString() == "12")
                        {
                            objBE.Action = "RL";
                        }
                        else if (dtLoginExists.Rows[0]["Role"].ToString() == "27" || dtLoginExists.Rows[0]["Role"].ToString() == "51")
                        {
                            objBE.Action = "DCJCEXDist";
                        }
                        //if (dtLoginExists.Rows[0]["Role"].ToString() == "13")
                        //{
                        //    objBE.Action = "Depot";
                        //}
                        else
                        {
                            objBE.Action = "R";
                        }

                    }
                    else if (!string.IsNullOrEmpty(txtUname.Text))
                    {
                        objBE.Action = "Depot";
                    }

                    //if (Session["Apptype"] != null && txtUname.Text != "Admin")
                    //{
                    //    objBE.Action = "RL";
                    //}
                    ////else if (txtUname.Text != "Admin" && txtUname.Text != "DPEO")
                    ////{
                    ////    objBE.Action = "RL";
                    ////}
                    //else
                    //{
                    //    objBE.Action = "R";
                    //}
                    DataTable dtLogin = objLogin.getLoginDetails(txtUname.Text, objBE, ConnKey);


                    //  DataTable dtLogin = objLogin.getLoginDetails(txtUname.Text, ConnKey);

                    if (dtLogin.Rows.Count > 0)
                    {


                        string password = dtLogin.Rows[0]["Password"].ToString();
                        string myval = ShaEncrypt(ViewState["KeyGenerator"].ToString());
                        string value = ShaEncrypt(password.ToLower() + myval.ToLower());


                        //string abc = txtPwdHash.Value;

                        //string value1 = ShaEncrypt(abc.ToLower() + myval.ToLower());


                        if (txtPwdHash.Value == value.ToLower())
                        {

                            string guid = Guid.NewGuid().ToString();
                            Session["AuthToken"] = guid;
                            Response.ClearContent();
                            Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                            Session["ConnKey"] = ConnKey;
                            Session["User"] = txtUname.Text;
                            Session["RetailerPassword"] = password.ToString();
                            Session["UserID"] = dtLogin.Rows[0]["UserId"].ToString();
                            Session["LoginSno"] = objLogin.insertUserLoginStatus(txtUname.Text, DateTime.Now, Request.ServerVariables["REMOTE_ADDR"].ToString(), "Login Successful", ConnKey);

                            var rnd = new Random();
                            int randomNumber = Enumerable.Range(100000, 999999).OrderBy(x => rnd.Next()).Take(1).FirstOrDefault();

                            Session["EncryptDecryptKey"] = randomNumber.ToString();
                            DateTime CurrentDate = DateTime.Now;
                            DateTime PasswordChangeDate = Convert.ToDateTime(dtLogin.Rows[0]["PasswordchangeDate"].ToString());

                            if (dtLogin.Rows[0]["Role"].ToString() == "3")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                Session["SuppName"] = dtLogin.Rows[0]["Supplier_Name"].ToString();
                                Session["Mob"] = dtLogin.Rows[0]["Mobile"].ToString();
                                Session["UsrName"] = txtUname.Text;
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                Session["DDOCode"] = dtLogin.Rows[0]["DDOCode"].ToString();
                                Session["License_No"] = dtLogin.Rows[0]["License_No"].ToString();
                                Session["Type_of_Manufacturing"] = dtLogin.Rows[0]["Type_of_Manufacturing"].ToString();
                                Response.Redirect("~/Supplier/SupplierPaymentDtls.aspx", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "12")
                            {

                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                Session["SuppName"] = dtLogin.Rows[0]["Retailer_Name"].ToString();
                                Session["Mob"] = dtLogin.Rows[0]["Mobile"].ToString();
                                Session["UsrName"] = txtUname.Text;
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                Session["DDOCode"] = dtLogin.Rows[0]["DDOCode"].ToString();
                                Session["License_No"] = dtLogin.Rows[0]["License_No"].ToString();
                                Session["Type_of_Manufacturing"] = dtLogin.Rows[0]["Excise_tax"].ToString();
                                Session["EXDIST_CODE"] = dtLogin.Rows[0]["ExDist_Cd"].ToString();
                                Session["DepotCode"] = dtLogin.Rows[0]["DepotCode"].ToString();
                                Session["Retailer_Type_Short_Name"] = dtLogin.Rows[0]["Retailer_Type_Short_Name"].ToString();
                                Session["Type_Retailer"] = dtLogin.Rows[0]["Type_Retailer"].ToString();
                                Session["IsConfirm"] = dtLogin.Rows[0]["IsConfirm"].ToString();
                                Session["salesprocedDDO"] = dtLogin.Rows[0]["salesprocedDDO"].ToString();
                                Session["IsMultipleDepot"] = dtLogin.Rows[0]["IsMultipleDepot"].ToString();

                                string RoleID = dtLogin.Rows[0]["Role"].ToString();

                                if (password.ToString() == "57885ccd2c3e57b81938837038b8bc21769501f2521f42536e68cf7d7b3d7126" && (RoleID == "2" || RoleID == "3" || RoleID == "4" || RoleID == "12" || RoleID == "13"))
                                {

                                    Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                    return;
                                }
                                else
                                {
                                    if (PasswordChangeDate.AddDays(90) < CurrentDate)
                                    {
                                        Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                        return;
                                    }
                                }
                                Response.Redirect("~/Retailer/DashboardRetailer.aspx", false);

                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "1")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                // Session["RoleName"] = roleNm;
                                Session["UsrName"] = txtUname.Text;
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                string RoleID = dtLogin.Rows[0]["Role"].ToString();

                                if (password.ToString() == "57885ccd2c3e57b81938837038b8bc21769501f2521f42536e68cf7d7b3d7126" && (RoleID == "2" || RoleID == "3" || RoleID == "4" || RoleID == "12" || RoleID == "13"))
                                {

                                    Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                    return;
                                }
                                else
                                {
                                    if (PasswordChangeDate.AddDays(90) < CurrentDate)
                                    {
                                        Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                        return;
                                    }
                                }
                                Response.Redirect("~/Admin/Dashboard.aspx", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "5")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                /// Session["RoleName"] = roleNm;
                                Session["UsrName"] = txtUname.Text;
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                //Response.Redirect("~/PaymentDtls.aspx", false);
                                string RoleID = dtLogin.Rows[0]["Role"].ToString();

                                if (password.ToString() == "57885ccd2c3e57b81938837038b8bc21769501f2521f42536e68cf7d7b3d7126" && (RoleID == "2" || RoleID == "3" || RoleID == "4" || RoleID == "12" || RoleID == "13"))
                                {

                                    Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                    return;
                                }
                                else
                                {
                                    if (PasswordChangeDate.AddDays(90) < CurrentDate)
                                    {
                                        Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                        return;
                                    }
                                }
                                Response.Redirect("~/DAO/StateOfficer/Dashboard.aspx", false);
                            }

                            if (dtLogin.Rows[0]["Role"].ToString() == "6")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                /// Session["RoleName"] = roleNm;
                                Session["UsrName"] = txtUname.Text;
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                //Response.Redirect("~/PaymentDtls.aspx", false);
                                string RoleID = dtLogin.Rows[0]["Role"].ToString();

                                if (password.ToString() == "57885ccd2c3e57b81938837038b8bc21769501f2521f42536e68cf7d7b3d7126" && (RoleID == "2" || RoleID == "3" || RoleID == "4" || RoleID == "12" || RoleID == "13"))
                                {

                                    Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                    return;
                                }
                                else
                                {
                                    if (PasswordChangeDate.AddDays(90) < CurrentDate)
                                    {
                                        Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                        return;
                                    }
                                }
                                Response.Redirect("~/DAO/Support/Dashboard.aspx", false);
                            }

                            if (dtLogin.Rows[0]["Role"].ToString() == "2")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                /// Session["RoleName"] = roleNm;
                                Session["UsrName"] = txtUname.Text;
                                Session["SHOUsername"] = txtUname.Text;
                                Session["SHOID"] = dtLogin.Rows[0]["SHOID"].ToString();
                                Session["EXDIST_CODE"] = dtLogin.Rows[0]["EXDIST_CODE"].ToString();
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                Session["StationName"] = dtLogin.Rows[0]["SHO_ST_NAME"].ToString();
                                Session["UserSection"] = dtLogin.Rows[0]["UserSection"].ToString();
                                //Response.Redirect("~/DAO/SHODashboard.aspx", false);
                                string RoleID = dtLogin.Rows[0]["Role"].ToString();

                                if (password.ToString() == "57885ccd2c3e57b81938837038b8bc21769501f2521f42536e68cf7d7b3d7126" && (RoleID == "2" || RoleID == "3" || RoleID == "4" || RoleID == "12" || RoleID == "13"))
                                {

                                    Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                    return;
                                }
                                else
                                {
                                    if (PasswordChangeDate.AddDays(90) < CurrentDate)
                                    {
                                        Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                        return;
                                    }
                                }
                                Response.Redirect("~/SHO/EventPermission.aspx", false);
                            }

                            if (dtLogin.Rows[0]["Role"].ToString() == "4")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                /// Session["RoleName"] = roleNm;
                                Session["UsrName"] = txtUname.Text;
                                Session["SHOUsername"] = "";
                                Session["ExDist_Cd"] = dtLogin.Rows[0]["ExDist_Cd"].ToString();
                                Session["EXDIST_CODE"] = dtLogin.Rows[0]["EXDIST_CODE"].ToString();
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                Session["DpeoName"] = dtLogin.Rows[0]["DPEO_DistName"].ToString();
                                Session["UserSection"] = dtLogin.Rows[0]["UserSection"].ToString();
                                string RoleID = dtLogin.Rows[0]["Role"].ToString();

                                if (password.ToString() == "57885ccd2c3e57b81938837038b8bc21769501f2521f42536e68cf7d7b3d7126" && (RoleID == "2" || RoleID == "3" || RoleID == "4" || RoleID == "12" || RoleID == "13"))
                                {

                                    Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                    return;
                                }
                                else
                                {
                                    if (PasswordChangeDate.AddDays(90) < CurrentDate)
                                    {
                                        Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                        return;
                                    }
                                }
                                Response.Redirect("~/DPEO/DepeoEventPermission.aspx", false);
                            }
                            //if (dtLogin.Rows[0]["Role"].ToString() == "7")
                            //{
                            //    Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                            //    /// Session["RoleName"] = roleNm;
                            //    Session["UsrName"] = txtUname.Text;
                            //    Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();

                            //    string RoleID = dtLogin.Rows[0]["Role"].ToString();

                            //    if (password.ToString() == "57885ccd2c3e57b81938837038b8bc21769501f2521f42536e68cf7d7b3d7126" && (RoleID == "2" || RoleID == "3" || RoleID == "4" || RoleID == "12" || RoleID == "13"))
                            //    {

                            //        Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                            //        return;
                            //    }
                            //    else
                            //    {
                            //        if (PasswordChangeDate.AddDays(90) < CurrentDate)
                            //        {
                            //            Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                            //            return;
                            //        }
                            //    }
                            //    Response.Redirect("~/Superdent/AbstractRpt.aspx", false);
                            //}

                            if (dtLogin.Rows[0]["Role"].ToString() == "8")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                /// Session["RoleName"] = roleNm;
                                Session["UsrName"] = txtUname.Text;
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();

                                string RoleID = dtLogin.Rows[0]["Role"].ToString();

                                if (password.ToString() == "57885ccd2c3e57b81938837038b8bc21769501f2521f42536e68cf7d7b3d7126" && (RoleID == "2" || RoleID == "3" || RoleID == "4" || RoleID == "12" || RoleID == "13"))
                                {

                                    Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                    return;
                                }
                                else
                                {
                                    if (PasswordChangeDate.AddDays(90) < CurrentDate)
                                    {
                                        Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                        return;
                                    }
                                }
                                Response.Redirect("~/Director/AbstractRpt.aspx", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "9")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                /// Session["RoleName"] = roleNm;
                                Session["UsrName"] = txtUname.Text;
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                Response.Redirect("~/NICAdmin/Dashboard.aspx", false);
                            }

                            //added by r on 06/03/2021
                            if (dtLogin.Rows[0]["Role"].ToString() == "10")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                /// Session["RoleName"] = roleNm;
                                Session["UsrName"] = txtUname.Text;
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();

                                string RoleID = dtLogin.Rows[0]["Role"].ToString();

                                if (password.ToString() == "57885ccd2c3e57b81938837038b8bc21769501f2521f42536e68cf7d7b3d7126" && (RoleID == "2" || RoleID == "3" || RoleID == "4" || RoleID == "12" || RoleID == "13"))
                                {

                                    Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                    return;
                                }
                                else
                                {
                                    if (PasswordChangeDate.AddDays(90) < CurrentDate)
                                    {
                                        Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                        return;
                                    }
                                }
                                Response.Redirect("~/DAO/Admin/Dashboard.aspx", false);
                            }
                            //
                            if (dtLogin.Rows[0]["Role"].ToString() == "11")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                /// Session["RoleName"] = roleNm;
                                Session["UsrName"] = txtUname.Text;
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                string RoleID = dtLogin.Rows[0]["Role"].ToString();

                                if (password.ToString() == "57885ccd2c3e57b81938837038b8bc21769501f2521f42536e68cf7d7b3d7126" && (RoleID == "2" || RoleID == "3" || RoleID == "4" || RoleID == "12" || RoleID == "13"))
                                {

                                    Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                    return;
                                }
                                else
                                {
                                    if (PasswordChangeDate.AddDays(90) < CurrentDate)
                                    {
                                        Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                        return;
                                    }
                                }
                                Response.Redirect("~/Retailer/DtlsRetailers.aspx", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "13")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                /// Session["RoleName"] = roleNm;
                                Session["UsrName"] = txtUname.Text;
                                Session["ExDist_Cd"] = dtLogin.Rows[0]["EXDIST_CODE"].ToString();
                                Session["EXDIST_CODE"] = "";
                                Session["StateCode"] = "";
                                Session["salesproceedDepotcode"] = dtLogin.Rows[0]["salesproceedDepotcode"].ToString();
                                //Response.Redirect("~/Depot/DEPOTDashboard.aspx", false);
                                string RoleID = dtLogin.Rows[0]["Role"].ToString();

                                if (password.ToString() == "57885ccd2c3e57b81938837038b8bc21769501f2521f42536e68cf7d7b3d7126" && (RoleID == "2" || RoleID == "3" || RoleID == "4" || RoleID == "12" || RoleID == "13"))
                                {

                                    Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                    return;
                                }
                                else
                                {
                                    if (PasswordChangeDate.AddDays(90) < CurrentDate)
                                    {
                                        Response.Redirect("~/Retailer/ChangePassword_M.aspx", false);
                                        return;
                                    }
                                }
                                Response.Redirect("~/Depot/SalesProceedReport.aspx", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "26")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                Session["UsrName"] = txtUname.Text;
                                Session["ExDist_Cd"] = null;
                                Session["EXDIST_CODE"] = null;
                                Session["StateCode"] = null;
                                Response.Redirect("~/ECMS/Public_Complaint_Form.aspx", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "27")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                Session["UsrName"] = txtUname.Text;
                                Session["SHOUsername"] = "";
                                Session["ExDist_Cd"] = dtLogin.Rows[0]["ExDist_Cd"].ToString();
                                Session["EXDIST_CODE"] = dtLogin.Rows[0]["EXDIST_CODE"].ToString();
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                Session["DpeoName"] = dtLogin.Rows[0]["DPEO_DistName"].ToString();
                                Session["UserSection"] = dtLogin.Rows[0]["UserSection"].ToString();

                                //Response.Redirect("~/ECMS/ViewComplaints_ControlRoom.aspx", false);
                                Response.Redirect("~/Renewals/DepartmentApplications.aspx.aspx", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "50")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                Session["UsrName"] = txtUname.Text;
                                Session["SHOUsername"] = "";
                                Session["ExDist_Cd"] = dtLogin.Rows[0]["ExDist_Cd"].ToString();
                                Session["EXDIST_CODE"] = dtLogin.Rows[0]["EXDIST_CODE"].ToString();
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                Session["DpeoName"] = dtLogin.Rows[0]["DPEO_DistName"].ToString();
                                Session["UserSection"] = dtLogin.Rows[0]["UserSection"].ToString();
                                Response.Redirect("~/SHO/EventUpdate_SHO", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "51")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                Session["UsrName"] = txtUname.Text;
                                Session["SHOUsername"] = "";
                                Session["ExDist_Cd"] = dtLogin.Rows[0]["ExDist_Cd"].ToString();
                                Session["EXDIST_CODE"] = dtLogin.Rows[0]["EXDIST_CODE"].ToString();
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                Session["DpeoName"] = dtLogin.Rows[0]["DPEO_DistName"].ToString();
                                Session["UserSection"] = dtLogin.Rows[0]["UserSection"].ToString();
                                Response.Redirect("~/NICAdmin/RetailerReport_Individual", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "55")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                Session["UsrName"] = txtUname.Text;
                                Session["SHOUsername"] = "";
                                Session["ExDist_Cd"] = dtLogin.Rows[0]["ExDist_Cd"].ToString();
                                Session["EXDIST_CODE"] = dtLogin.Rows[0]["EXDIST_CODE"].ToString();
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                Session["DpeoName"] = dtLogin.Rows[0]["DPEO_DistName"].ToString();
                                Session["UserSection"] = dtLogin.Rows[0]["UserSection"].ToString();
                                Response.Redirect("~/Renewals/DepartmentApplications.aspx", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "52")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                Session["UsrName"] = txtUname.Text;
                                Session["ExDist_Cd"] = null;
                                Session["EXDIST_CODE"] = null;
                                Session["StateCode"] = null;
                                Response.Redirect("~/NICAdmin/CTELintegration.aspx", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "53")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                Session["UsrName"] = txtUname.Text;
                                Session["ExDist_Cd"] = null;
                                Session["EXDIST_CODE"] = null;
                                Session["StateCode"] = null;
                                Response.Redirect("~/Admin/TSBCLDashboard.aspx", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "54")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                Session["UsrName"] = txtUname.Text;
                                Session["SHOUsername"] = "";
                                Session["ExDist_Cd"] = dtLogin.Rows[0]["ExDist_Cd"].ToString();
                                Session["EXDIST_CODE"] = dtLogin.Rows[0]["EXDIST_CODE"].ToString();
                                Session["StateCode"] = dtLogin.Rows[0]["StateCode"].ToString();
                                Session["DpeoName"] = dtLogin.Rows[0]["DPEO_DistName"].ToString();
                                Session["UserSection"] = dtLogin.Rows[0]["UserSection"].ToString();
                                Response.Redirect("~/Admin/EventPermitDashboard.aspx", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "7")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                Session["UsrName"] = txtUname.Text;
                                Session["ExDist_Cd"] = null;
                                Session["EXDIST_CODE"] = null;
                                Session["StateCode"] = null;
                                Response.Redirect("~/Renewals/DepartmentApplications.aspx", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "28")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                Session["UsrName"] = txtUname.Text;
                                Session["SHOUsername"] = "";
                                Session["ExDist_Cd"] = "";
                                Session["EXDIST_CODE"] = "";
                                Session["StateCode"] = "";
                                Session["UserSection"] = dtLogin.Rows[0]["UserSection"].ToString();
                                Response.Redirect("~/Renewals/DepartmentApplications.aspx", false);
                            }
                            if (dtLogin.Rows[0]["Role"].ToString() == "29")
                            {
                                Session["Role"] = dtLogin.Rows[0]["Role"].ToString();
                                Session["UsrName"] = txtUname.Text;
                                Session["SHOUsername"] = "";
                                Session["ExDist_Cd"] = "";
                                Session["EXDIST_CODE"] = "";
                                Session["StateCode"] = "";
                                Session["UserSection"] = dtLogin.Rows[0]["UserSection"].ToString();
                                Response.Redirect("~/Renewals/DepartmentApplications.aspx", false);
                            }
                            if (dtLogin.Rows.Count > 0)
                            {
                                Session["Role_Name"] = dtLogin.Rows[0]["Role_Name"].ToString();
                            }
                        }
                        else
                        {
                            captch.Text = "";
                            ViewState["KeyGenerator"] = Guid.NewGuid().ToString("N").Substring(0, 16);
                            getCaptchaImage();
                            Session["LoginSno"] = objLogin.insertUserLoginStatus(txtUname.Text, DateTime.Now, Request.ServerVariables["REMOTE_ADDR"].ToString(), "Login Failed", ConnKey);
                            objCommon.ShowAlertMessage("Please check the password..");
                        }
                    }
                    else
                    {
                        captch.Text = "";
                        ViewState["KeyGenerator"] = Guid.NewGuid().ToString("N").Substring(0, 16);
                        getCaptchaImage();
                        Session["LoginSno"] = objLogin.insertUserLoginStatus(txtUname.Text, DateTime.Now, Request.ServerVariables["REMOTE_ADDR"].ToString(), "Login Failed", ConnKey);
                        objCommon.ShowAlertMessage("Invalid login details");

                    }
                }
                else
                {
                    captch.Text = "";
                    ViewState["KeyGenerator"] = Guid.NewGuid().ToString("N").Substring(0, 16);
                    getCaptchaImage();
                    lblmsg.Text = "Invalid Captcha";

                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
                // Response.Redirect("~/Error.aspx");
            }
        }


        public string ShaEncrypt(string Ptext)
        {
            string hash = "";
            System.Security.Cryptography.SHA256CryptoServiceProvider m1 = new System.Security.Cryptography.SHA256CryptoServiceProvider();
            byte[] s1 = System.Text.Encoding.ASCII.GetBytes(Ptext);
            s1 = m1.ComputeHash(s1);
            foreach (byte bt in s1)
            {
                hash = hash + bt.ToString("x2");
            }
            return hash;
        }

        public void getCaptchaImage()
        {
            Captcha ci = new Captcha();
            string text = Captcha.generateRandomCode();
            ViewState["captchtext"] = text;
            Image2.ImageUrl = "~/Assets/cpImg/cpImage.aspx?randomNo=" + text;
        }
        protected void btnImgRefresh_Click(object sender, ImageClickEventArgs e)
        {
            captch.Text = "";
            getCaptchaImage();
        }



        public void random()
        {
            try
            {
                string strString = "abcdefghijklmnpqrstuvwxyzABCDQEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                string num = "";
                Random rm = new Random();
                for (int i = 0; i < 16; i++)
                {
                    int randomcharindex = rm.Next(0, strString.Length);
                    char randomchar = strString[randomcharindex];
                    num += Convert.ToString(randomchar);
                }

                Response.Cookies.Add(new HttpCookie("ASPFIXATION2", num));
                hf.Value = num;
                Session["ASPFIXATION2"] = num;
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx", false);
            }
        }
        public void check()
        {
            try
            {
                string cookie_value = null;
                string session_value = null;
                //cookie_value = System.Web.HttpContext.Current.Request.Cookies["ASPFIXATION2"].Value;
                cookie_value = hf.Value;
                session_value = System.Web.HttpContext.Current.Session["ASPFIXATION2"].ToString();
                if (cookie_value != session_value)
                {
                    System.Web.HttpContext.Current.Session.Abandon();
                    HttpContext.Current.Response.Buffer = false;
                    HttpContext.Current.Response.Redirect("~/Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}