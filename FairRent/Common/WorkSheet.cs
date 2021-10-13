using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairRent.Common
{
    class WorkSheet
    {
        public int ID { get; set; }
        public string PlateNumber { get; set; }                     // Field size 20
        public string ClientName { get; set; }                            // Field size 60
        public string Phone1 { get; set; }                          // Field size 30
        public decimal Discount { get; set; }                        // Field size 5
        public decimal Multiplier { get; set; }
        public string EmailAddress { get; set; }                    // Field size 60
        public string CarManufacturer { get; set; }                 // Field size 60
        public string CarType { get; set; }                         // Field size 60
        public DateTime InspectionDate { get; set; }          // Field size 15
        public int Odometer { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }                 // Field size 20
        public string Notes { get; set; }
        public decimal NetHourFee { get; set; }
        public decimal Tax { get; set; }
        public PartsList Parts { get; set; }
        public WorkFeeList WorkFees { get; set; }
    }
}
