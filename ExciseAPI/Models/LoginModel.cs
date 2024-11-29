using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExciseAPI.Models
{
    public class LoginModel
    {
        public class LoginResponse : Responses.responseMessage
        {

            public List<RowLoginDetails> Details { get; set; }

        }
        public class LoginRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }


        public class RowLoginDetails
        {
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string Role { get; set; }
            public string Password { get; set; }
            public string StateCode { get; set; }
            public string DistCode { get; set; }
            public string MandCode { get; set; }
            public string Active { get; set; }
            public string Supplier_Name { get; set; }
            public string Mobile { get; set; }
            public string DDOCode { get; set; }
            public string License_No { get; set; }
            public string Type_of_Manufacturing { get; set; }
            public string ExDistCode { get; set; }
            public string EXDIST_CODE { get; set; }
            public string SHOID { get; set; }
            public string ExDist_Cd { get; set; }
            public string Retailer_Name { get; set; }
            public string Excise_tax { get; set; }
            public string DepotCode { get; set; }
            public string Type_Retailer { get; set; }
            public string Retailer_Type_Short_Name { get; set; }
            public string Role_Name { get; set; }
            public string SHO_ST_NAME { get; set; }
            public string DPEO_DistName { get; set; }
        }
    }
}