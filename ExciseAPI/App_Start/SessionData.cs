using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExciseAPI.App_Start
{
    public class SessionData
    {
        public SessionData()
        {

        }

        public string EncryptDecryptKey { get; set; }
        public string AuthToken { get; set; }
        public string ConnKey { get; set; }

        public string User { get; set; }
        public string UserID { get; set; }
        public string LoginSno { get; set; }
        public string Role { get; set; }
        public string SuppName { get; set; }
        public string Mob { get; set; }
        public string UsrName { get; set; }
        public string StateCode { get; set; }
        public string DDOCode { get; set; }
        public string License_No { get; set; }
        public string Type_of_Manufacturing { get; set; }
        public string EXDIST_CODE { get; set; }
        public string DepotCode { get; set; }
        public string Retailer_Type_Short_Name { get; set; }
        public string Type_Retailer { get; set; }

        public string IsConfirm { get; set; }


        private void Clear()
        {
            HttpContext.Current.Session.Clear();
        }

        private void Abandon()
        {
            HttpContext.Current.Session.Abandon();
        }

        public void LogOff()
        {
            HttpContext.Current.Session.Contents.RemoveAll();
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session["tab_id"] = "";


            ClearCache();
        }

        private void ClearCache()
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetExpires(DateTime.Now);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
        }
    }
}