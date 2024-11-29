using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Collections.Specialized;


namespace ExciseAPI.App_Code
{
    public class AppSettings
    {

        BasePage basePage = new BasePage();
        //public static double CacheTimeSpan
        //{
        //    get
        //    {
        //        return ConfigurationManager.AppSettings["CacheTimeSpan"].ToDouble();
        //    }

        //}

        public static string ErrorPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ErrorPath"].ToString();
            }
        }


        public static string PaymentGatewayErrorLog
        {
            get
            {
                return ConfigurationManager.AppSettings["PaymentGatewayErrorLog"].ToString();
            }
        }
        public static string GetFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["CamFilePath"].ToString();
            }
        }

    }
}