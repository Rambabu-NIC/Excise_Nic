using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Excise_BE
{
    public class Supplier_BE
    {
       
        public string UploadDco_Code { get; set; }
        public byte[] UploadFile { get; set; }
        public string UploadFiletype { get; set; }
        public string UploadDco_FileID { get; set; }
        public string SNo { get; set; }
        public string Id { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string Type_of_Manu { get; set; }
        public string Type_of_Duties { get; set; }
        public string Supplier_Code { get; set; }
        public string SupplierName { get; set; }
        public string SupplierCode { get; set; }
        public string DistCode { get; set; }
        public string  MandCode{ get; set; }
        public string VillCode { get; set; }
        public string  Address{ get; set; }
        public string  LicNo{ get; set; }
        public string  LicData{ get; set; }
        public string  LicAdd{ get; set; }
        public string  Dt_Valid_Fm{ get; set; }
        public string Dt_Valid_To { get; set; }
        public string  Annual_Lic_Capacity{ get; set; }
        public string  DDoCode{ get; set; }
        public string  TINNo{ get; set; }
        public string  PANNo{ get; set; }
        public string  SGSTNo{ get; set; }
        public string IPAddress { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public string MobNo { get; set; }
        public string Pincode { get; set; }
        public string UserType { get; set; }
        public string Statecode { get; set; }
        public string ghmc { get; set; }

        public string HOACode { get; set; }
        public string HOA { get; set; }
        public string HOAccount { get; set; }
        public string MajorHead { get; set; }
        public string MinorHead { get; set; }
        public string MinorHeadDesc { get; set; }
        public string GPHead { get; set; }
        public string SubHead { get; set; }
        public string SubHeadDesc { get; set; }
        public string DtHead { get; set; }
        public string SubDtHead { get; set; }

        public string SubMajorHead { get; set; }

        public string ManufCd { get; set; }
        public string MAnufNm { get; set; }
        public string NameOfTreasury { get; set; }
        public DataTable TVP { get; set; }

        //EventReg @@@@Bdr_East
        public string Paymenttype { get; set; }
        public string EventType { get; set; }
        public string EventId { get; set; }
        public string AppName { get; set; }
        public string Aadhaar { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string FatherName { get; set; }
        public string HouseNo { get; set; }
        public string NameOfPerm { get; set; }
        public string Street { get; set; }
        public string BdrEast { get; set; }
        public string BdrWest { get; set; }
        public string BdrNorth { get; set; }
        public string Division { get; set; }

        public string BdrSouth { get; set; }
        public string Circle { get; set; }
        public string ExStation { get; set; }
        public string Rule7 { get; set; }
        public string EDate { get; set; }
        public DateTime Date { get; set; }
        public string Eventtime { get; set; }
        public string EventOccasion { get; set; }
        public string License_Fee { get; set; }
        public decimal TotalFeePaid { get; set; }

        public string ExDistCode { get; set; }
        //public string TotalFeePaid { get; set; }
        public string Reg_Code { get; set; }
        public string ApplicationType { get; set; }

        public string fileNme { get; set; }
        public string fileSizee { get; set; }
        public string fileTypee { get; set; }
        public byte[] contentt { get; set; }
        public string DocRemarks { get; set; }
        public string SupStatus { get; set; }
        public string RemitterName { get; set; }
        public decimal Amount { get; set; }
        public string DeptCode { get; set; }
        public string DeptTransid { get; set; }        
       public string PaymentRemarks { get; set; }
        public string BankStatus { get; set; }
        public string ChallanNumber { get; set; }
        public DateTime TreasuryDate { get; set; }
        public string BankCode { get; set; }
        public DateTime BankDate { get; set; }
        public string BankTransid { get; set; }
        public string PaymentMode { get; set; }
        public DateTime ? dtfrom { get; set; }
        public DateTime ? dtTo { get; set; }
        public string IpAddress { get; set; }
        public string Retailer_Code { get; set; }

        public string Installment { get; set; }
        public string PermitId { get; set; }

        public int TofM { get; set; }
        public int TofP { get; set; }


        public string DepotCode { get; set; }
        public string RetailerCode { get; set; }
        public string UnitCode { get; set; }
        public string RetailerType { get; set; }
        public string BankName { get; set; }
        public string from { get; set; }
        public string To { get; set; }

        public string RetailerName { get; set; }
        public string RDist { get; set; }
        public string ExDist { get; set; }
        public string LicenseName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }


        public string LicenseNO { get; set; }
        public string Purpose { get; set; }
        public string CreatedBy { get; set; }

        public string PendingAction { get; set; }
        public string PendingAction1 { get; set; }
        public string InstallmentEDate { get; set; }
        public int InstallmentNo { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int? Installment_No { get; set; }

        public string ActivityType { get; set; }

        public string RetailerTypeCode { get; set; }
        public string TypePayment { get; set; }
        public string PaymentDesc { get; set; }
        public string Year { get; set; }

        public string FDate { get; set; }
        public string TDate { get; set; }

        public string SHOID { get; set; }

        public string ExTax { get; set; }
        public string slabNo { get; set; }
        public string GazetteCode { get; set; }
        public string PenaltyAmount { get; set; }
        public int? IsRegionLevel { get; set; }
        public int Role { get; set; }
        public int? Verified { get; set; }

        public string DepotName { get; set; }


        
        public string StartYear { get; set; }
        public string EndYear { get; set; }


        public int IsActive { get; set; }
        public string Active { get; set; }
        public string EODBFormName { get; set; }
        public string EODBFromDate { get; set; }
        public string EODBToDate { get; set; }
        public string EODBCreatedBy { get; set; }
        public int FinID { get; set; }
        
        public string DFCode { get; set; }
    }
}
