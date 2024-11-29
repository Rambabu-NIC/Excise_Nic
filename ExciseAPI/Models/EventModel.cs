using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExciseAPI.Models
{
    public class EventModel
    {
        public class EventResponse : Responses.responseMessage
        {

            public List<RowEventDetails> Details { get; set; }
           
        }

        public class SHORequest
        {
            public string AppRegNo{ get; set; }
        }


        public class RowEventDetails
        {
            public string Applicant_Name { get; set; }
            public string Applicant { get; set; }
            public string Aadhaar { get; set; }
            public string MobileNo { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
            public string Father_Name { get; set; }
            public string Residential_Address { get; set; }
            public string House_Number { get; set; }
            public string Street { get; set; }
            public string Name_Premises { get; set; }
            public string East { get; set; }
            public string West { get; set; }
            public string North { get; set; }
            public string South { get; set; }
            public string Revenue_District { get; set; }
            public string Mandal { get; set; }
            public string Village { get; set; }
            public string Excise_District { get; set; }
            public string Excise_Station { get; set; }
            public string GHMC { get; set; }
            public string Date_TimeofEvent { get; set; }
            public string TypeOf_Event { get; set; }
            public string Occassion { get; set; }
            public string Licence_Fee { get; set; }
            public string Differential_Fee { get; set; }
            public string Premises_Address { get; set; }

            public List<RowEventPaymentDetails> PaymentDetails { get; set; }
            public List<RowEventDocumentsDetails> DocumentDetails { get; set; }
        }
        //Response
        public class RowEventPaymentDetails
        {
            public string Depttrans_id { get; set; }
            public string banktrans_id { get; set; }
            public string challan_num { get; set; }
            public string bank_name { get; set; }
            public string trans_date { get; set; }
            public string bank_status { get; set; }
            public string amount { get; set; }
            //public string hoa { get; set; }
            public string BankDate { get; set; }

        }

        public class RowEventDocumentsDetails
        {
            public string UploadDco_File { get; set; }
            public string UploadDco_FileType { get; set; }
            public string UploadDocs_Sno { get; set; }
            

        }

            public class EventPermissionResponse : Responses.responseMessage
        {

            public List<RowEventPermissionDetails> Details { get; set; }
            

        }

        public class SHOEventPermissionRequest
        {
            public string EXDIST_CODE { get; set; }
            public string SHOID { get; set; }
        }

        public class RowEventPermissionDetails
        {
            public string AppReg_NO { get; set; }
            public string Reg_No { get; set; }
            public string App_Name { get; set; }
            
            public string Aadhaar { get; set; }
            public string MobileNo { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
            public string FName { get; set; }
            public string Res_Address { get; set; }
            public string HNo { get; set; }
            public string Name_Premises { get; set; }
            public string Street { get; set; }
            
            public string Bdr_East { get; set; }
            public string Bdr_West { get; set; }
            public string Bdr_North { get; set; }
            public string Bdr_South { get; set; }
            public string State { get; set; }
            public string DistCode { get; set; }
            public string DistName { get; set; }
            

            public string Mandal { get; set; }
            public string MandName { get; set; }

            public string Division { get; set; }
            public string Circle { get; set; }
            public string Village { get; set; }
            public string VillName { get; set; }
            public string Pincode { get; set; }
            public string ExDist_Cd { get; set; }
            public string ExStationCode { get; set; }
            public string ExDist { get; set; }
            public string ExStation { get; set; }
            public string Rule7 { get; set; }
            public string Date { get; set; }
            public string Eventtime { get; set; }
            public string Event_Occasion { get; set; }

            public string License_Fee { get; set; }
            public string Event_ID { get; set; }
           
           
        }


        public class RowDPEOEventDetails
        {
            public string AppReg_NO { get; set; }
            public string Reg_No { get; set; }
            public string Status { get; set; }
            public string SubmitDt { get; set; }
            public string App_Name { get; set; }
            //public string Applicant { get; set; }
            public string Aadhaar { get; set; }
            public string Mob_No { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
            public string FName { get; set; }
            public string Res_Address { get; set; }
            public string HNo { get; set; }
            public string Street { get; set; }
            public string Name_Premises { get; set; }
            public string Bdr_East { get; set; }
            public string Bdr_West { get; set; }
            public string Bdr_North { get; set; }
            public string Bdr_South { get; set; }
            public string State { get; set; }
            public string DistCode { get; set; }
            public string DistName { get; set; }
            public string Mandal { get; set; }
            public string Village { get; set; }
            public string Division { get; set; }
            public string Circle { get; set; }
            public string Pincode { get; set; }
            public string ExDist_Cd { get; set; }
            public string ExStationCode { get; set; }

            public string Rule7 { get; set; }
            public string Date { get; set; }
            
            public string GHMC { get; set; }
            public string Eventtime { get; set; }
           
            public string Event_Occasion { get; set; }
            public string License_Fee { get; set; }

            public string Event_ID { get; set; }
            public string Payment_Type { get; set; }
            public string MandName { get; set; }
            public string VillName { get; set; }

            public string ExDist { get; set; }
            public string ExStation { get; set; }

            public string Event_Type { get; set; }
            public string Event { get; set; }
            public string ShoInspecDt { get; set; }

            public string ShoInspecTime { get; set; }
            public string ShoRemarks { get; set; }

            public string Diffential_Amt { get; set; }

           
            public List<RowDPEOEventPaymentDetails> DPEOPaymentDetails { get; set; }
            public List<RowEventDocumentsDetails> DocumentDetails { get; set; }

        }

        public class DPEOEventPermissionRequest
        {
            public string ExDist_Cd { get; set; }
           
        }
        public class DPEOEventPermissionResponse : Responses.responseMessage
        {

            public List<RowDPEOEventDetails>Details{ get; set; }
           


        }

        public class RowDPEOEventPaymentDetails
        {
            public string DeptTransid { get; set; }
            public string BankTransid { get; set; }
            public string ChallanNumber { get; set; }
            public string BankCode { get; set; }
            public string TreasuryDate { get; set; }
            public string BankStatus { get; set; }
            public string Amount { get; set; }
            //public string hoa { get; set; }
            public string BankDate { get; set; }

        }




        public class DPEOEventResponse : Responses.responseMessage
        {

            public List<RowDPEOEventDetails> Details { get; set; }

        }

        public class DPEORequest
        {
            public string AppRegNo { get; set; }
        }


       
    }
}