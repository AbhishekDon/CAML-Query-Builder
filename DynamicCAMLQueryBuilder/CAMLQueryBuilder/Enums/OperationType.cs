using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMLQueryBuilder.Enums
{
    public enum OperationType
    {
        BeginsWith,
        Contains,
        DateRangesOverlap,
        Eq,
        Geq,
        Gt,
        IsNull,
        IsNotNull,
        Leq,
        Lt,
        Neq
    }
}
