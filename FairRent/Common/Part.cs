using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairRent.Common
{
    class Part
    {
        public int PartID { get; set; }
        public string PartName { get; set; }
        public int Pieces { get; set; }
        public decimal NetPrice { get; set; }
        public decimal NetTotal => Pieces * NetPrice * (1 + (Multiplier * 10) / 100);
        public decimal Multiplier { get; set; }
        public decimal Tax { get; set; }
        public decimal GrossTotal => NetTotal + (NetTotal * (Tax / 100));  // + (NetTotal * (Multiplier * 10) / 100);
        public decimal PartDiscount { get; set; }
        public decimal PartTotal => GrossTotal - (GrossTotal * (PartDiscount / 100));
    }
}
