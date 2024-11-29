﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExciseAPI
{
    public partial class Site_M : System.Web.UI.MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
                if (Session["Role_Name"] != null)
                {
                    //if (Session["Role"].ToString() == "2")
                    //{
                    //    Master_spn_RoleName.InnerHtml = Session["Role_Name"].ToString() + " -" + Session["StationName"].ToString();
                    //}
                    //else if (Session["Role"].ToString() == "4")
                    //{
                    //    Master_spn_RoleName.InnerHtml = Session["Role_Name"].ToString() + " -" + Session["DpeoName"].ToString();
                    //}
                    //else
                    //{
                    //    Master_spn_RoleName.InnerHtml = Session["Role_Name"].ToString();
                    //}
                }
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Login.aspx", false);
            }


            if (!IsPostBack)
            {

            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }
        string http_ref, http_hos;

        public bool isURLNotOk()
        {
            //--------------------------------------------------------------------------------------------------------
            // Check HTTP Referrer : Checking whether black list strings are found ..
            //---------------------------------------------------------------------------------------------------------
            try
            {
                if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
                {
                    Response.Redirect("~/Error.aspx", false);
                    return true;
                }
                else
                {
                    Uri uri = Request.UrlReferrer;
                    //here checking urlreferrer host name.
                    if (uri.Host.Equals(Request.ServerVariables["Server_Name"]))
                    {
                        http_ref = Request.ServerVariables["HTTP_REFERER"].ToString().Trim();
                        http_hos = Request.ServerVariables["HTTP_HOST"].ToString().Trim();
                        return false;
                    }
                    else
                    {
                        Response.Redirect("~/Error.aspx", false);
                        return true;
                    }
                }
            }

            catch (System.Exception)
            {
                Response.Redirect("~/Error.aspx", false);
                return true;
            }

        }

        public bool isnewtab()
        {
            //----------------------------------------
            // Check Session exists or not : FOR NEW TAB
            //-----------------------------------------

            try
            {
                if (Session["tab_id"] != null)
                {
                    if (!Session["tab_id"].Equals("new"))
                    {

                        Response.Redirect("~/Error.aspx", false);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx", false);
                return true;
            }
        }
    }
}