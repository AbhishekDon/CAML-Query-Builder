using CAMLQueryBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMLQueryBuilder
{
    public class QBOperator
    {
        public string StartTag { get; }
        public string EndTag { get; }
        public OperatorType Type { get; }
        public QBOperator(OperatorType oOperatorType)
        {
            StartTag = oOperatorType != OperatorType.NULL ? string.Format("<{0}>", oOperatorType) : "";
            EndTag = oOperatorType != OperatorType.NULL ? string.Format("</{0}>", oOperatorType) : "";
            Type = oOperatorType;
        }

    }
}
