using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairRent.Common
{
    class PartsList : List<Part>
    {
        public decimal TotalParts => this.Sum(x => Math.Round(x.PartTotal));
    }
    
}
