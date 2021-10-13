using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairRent.Common
{
    public class StringList : List<string>
    {
        public IEnumerable<string> GetNoDuplicates()
                                 => this.OrderBy(x => x)
                                        .Where(x => x != null)
                                        .Where(x => x != string.Empty)
                                        .Select(x => x).Distinct();
    }
}
