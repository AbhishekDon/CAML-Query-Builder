using CAMLQueryBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMLQueryBuilder
{
    public class QBOperation
    {
        public string StartTag { get; }
        public string EndTag { get; }
        public QBOperation(OperationType oOperationType)
        {
            StartTag = string.Format("<{0}>", oOperationType);
            EndTag = string.Format("</{0}>", oOperationType);
        }

    }
}
