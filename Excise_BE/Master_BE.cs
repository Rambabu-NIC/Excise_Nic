using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Excise_BE
{
   public class Master_BE
    {
        public string Status { get; set; }
        public string AStatus { get; set; }
        public string Role { get; set; }
        public string conn { get; set; }
        public string University { get; set; }
        public string UniversityCode { get; set; }
        public string OStatecode { get; set; }
        public string Statecode { get; set; }
        public string StateNm { get; set; }
        public string CollegeCD { get; set; }
        public string CollegeNM { get; set; }
        public string LoggedInUser { get; set; }
        public string Action { get; set; }
        public string ID { get; set; }
        public Int64 SID { get; set; }

        /*Applicant*/
        public byte[] qrcode { get; set; }
        public string ApplicantId { get; set; }
        public string System { get; set; }
        public string Dist_code { get; set; }
        public string MandCode { get; set; }
        public string Applicantname { get; set; }
        public string vill_code { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public int Caste { get; set; }
        public string Castes { get; set; }
        public string AadhaarId { get; set; }
        public string EmailId { get; set; }
        public string Intenship { get; set; }
        public string MobileNo { get; set; }
        public string PDist_code { get; set; }
        public string Pvill_code { get; set; }
        public string PMandCode { get; set; }
        public string PAddress { get; set; }
        public string PPincode { get; set; }
        public string PMobileNo { get; set; }
        public string Active { get; set; }
        public string IpAddress { get; set; }
        public string PhotoName { get; set; }
        public byte[] UploadFile { get; set; }
        public string UploadFiletype { get; set; }
        public string UploadDco_FileID { get; set; }
        public string UploadDco_Code { get; set; }
        public string SNo { get; set; }

        public string PhotoExt { get; set; }

        public byte[] PhotoContent { get; set; }

        public string UserID { get; set; }

        public string Qualification { get; set; }
        public string RegNo { get; set; }
        public string NameofUni { get; set; }
        public string NameofIns { get; set; }
        public string YOP { get; set; }
        public string YOR { get; set; }

        public string ApplicationType { get; set; }
        public string Type { get; set; }
        public string TypeofState { get; set; }

        public string HOAccount { get; set; }

        public string DeptTransid { get; set; }

        public string RemitterName { get; set; }

        public decimal Amount { get; set; }
        public DateTime BankDate { get; set; }
        public string PaymentRemarks { get; set; }

        public string PaymentMode { get; set; }

        public string BankStatus { get; set; }

        public string ChallanNumber { get; set; }
        /* License Genaration */
        public DateTime EXPDATE { get; set; }
        public DateTime FRMDATE { get; set; }
        public string YEAR { get; set; }
        public string SignedInput { get; set; }
        public string SignedValue { get; set; }
        public string SignedhashValue { get; set; }
        public string LicenseID { get; set; }
        public string DistName { get; set; }
        public string Signedby { get; set; }


        public string InwardNo { get; set; }
        public string TypeofStateDesc { get; set; }
        public string ApplicationTypeDesc { get; set; }
        public string TypeDesc { get; set; }

       /* Mayuri Start*/


        public int Retailer_Code { get; set; }
        public string RetailerName { get; set; }
        public string Retailer_Type { get; set; }
        public string License_Name { get; set; }
        public string License_Gazette_number { get; set; }
        public string Mandal { get; set; }
        public string Village { get; set; }
        public string Primary_Depot_Code { get; set; }
        public string Primary_Depot_Active_YN { get; set; }
        public string Secondary_Depot_Code { get; set; }
        public string Secondary_Depot_Active_YN { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public string DEPOTCODE { get; set; }
        public string DepotName { get; set; }
        public string District { get; set; }
        public string Depot_DDO_Code { get; set; }
        public string HOA_Code { get; set; }
        public string HOA_Description { get; set; }
        public string Ip_Address { get; set; }
        public string WEF_Form { get; set; }
        public string Active_YN { get; set; }
        public string Purpose_Code { get; set; }
        public string purpose_Description { get; set; }
        public string IP_Address { get; set; }
        public string From_Date { get; set; }
        public string To_Date { get; set; }     
        public string Depot_Code { get; set; }       
        public string DDO_Code { get; set; }      
        public string Date_of_Payment { get; set; }      
        public string Dept_Trans_id { get; set; }
        public string Challan_Number { get; set; }
        public string Challan_Date { get; set; }
        public string Payment_Status { get; set; }
        public string Bank_Name { get; set; }
        public string Bank_Transaction_Id { get; set; }
        public string DistCode { get; set; }
        public string retailertypecode { get; set; }
        public string retailername { get; set; }
        public string retailershortname { get; set; }
      
        public string IPAddress { get; set; }
        //public string ID { get; set; }
        /* Mayuri End*/

        public DataTable TVP { get; set; }
		
    }

}
