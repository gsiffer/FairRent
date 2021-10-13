using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairRent.Common
{
    public class Client
    {
        public string PlateNumber { get; set; }                     // Field size 20
        public string ClientName { get; set; }                            // Field size 60
        public string PostalCode { get; set; }                      // Field size 10
        public string City { get; set; }                            // Field size 60
        public string Address { get; set; }                         // Field size 60
        public string Phone1 { get; set; }                          // Field size 30
        public string Phone2 { get; set; }                          // Field size 30
        public string EmailAddress { get; set; }                    // Field size 60
        public decimal Discount { get; set; }                        // Field size 5
        public string CarManufacturer { get; set; }                 // Field size 60
        public string CarType { get; set; }                         // Field size 60
        public DateTime InspectionDate { get; set; }          // Field size 15
        public int Year { get; set; }                               // Field size 5
        public string IdentificationNumber { get; set; }            // Field size 40
        public string EngineNumber { get; set; }                    // Field size 40
        public int CubicCentimetre { get; set; }                    // Field size 6
        public int KW { get; set; }                                 // Field size 6
        public string Fuel { get; set; }                            // Field size 30
        public string InsuranceName { get; set; }                   // Field size 60
        public DateTime InsuranceDate { get; set; }                 // Field size 20
        public decimal InsuranceFee { get; set; }                    // Field size 10
        public string CascoName { get; set; }                       // Field size 60
        public string CascoType { get; set; }                       // Field size 60
        public string CascoDeduction { get; set; }                  // Field size 60
        public bool Filtered { get; set; }
        public bool IsHungarian { get; set; }
    }
}
