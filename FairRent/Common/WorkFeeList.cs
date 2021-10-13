using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairRent.Common
{
    class WorkFeeList : List<WorkFee>
    {
        public decimal WorkTotal => this.Sum(x => Math.Round(x.WorkTotal));
    }
}
