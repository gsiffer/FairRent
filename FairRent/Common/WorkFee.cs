using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairRent.Common
{
    class WorkFee
    {
        public int WorkID { get; set; }
        public string WorkName { get; set; }
        public decimal WorkHour { get; set; }
        public decimal NetHourFee { get; set; }
        public decimal NetTotalFee { get; set; } //=> WorkHour * NetHourFee; 
        public decimal WorkDiscount { get; set; }
        public decimal WorkTotal => NetTotalFee - (NetTotalFee * (WorkDiscount / 100));
        public bool IsContractor { get; set; }
        public decimal ContractorFee { get; set; }
    }
}
