using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excise_BE
{
    public class ECMS_BE
    {
        public string Statecode { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Aadhaar { get; set; }
        public string Email { get; set; }
        public string DistrictID { get; set; }
        public string MandalID { get; set; }
        public string VillageID { get; set; }
        public string ComplaintDetails { get; set; }
        public string ComplaintSource { get; set; }

        public string CreatedBy { get; set; }
        public byte[] DocumentFile { get; set; }

        public string DocumentName  { get; set; }
        public int AtrPreliminaryID { get; set; }
        public string ComplaintID { get; set; }
        public string InspectingOfficerName { get; set; }
        public string CrimeDetectionCode { get; set; }
        public string CrimeLocation { get; set; }
        public string CorNo { get; set; }
        public string PersonsArrested { get; set; }
        public int ContrabandSeized { get; set; }
        public string ContrabandValueRs { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public DateTime InspectionDate { get; set; }
        public int AtrNo { get; set; }
        public string CasesBooked { get; set; }
        public int SeizureType { get; set; }
        public string NumberOfVehiclesSeized { get; set; }
        public int ContrabandType { get; set; }
        public decimal QuantitySeizedInLitres { get; set; }
        public int IllicitLiquor { get; set; }
        public int Ndps { get; set; }
        public string UnderSection { get; set; }
    }
}
