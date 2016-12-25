using CAMLQueryBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMLQueryBuilder.Query
{
    public class FieldQuery
    {
        /// <summary>
        /// oField for field details, like internalName, Value, and DataType
        /// oOperationType for same field opeartion, ex eq, neq etc
        /// oOperatorType for next field operator, ex And or
        /// </summary>
        /// <param name="oField"></param>
        /// <param name="oOperationType"></param>
        /// <param name="oOperatorType"></param>
        public FieldQuery(QBField oField, OperationType oOperationType, OperatorType oOperatorType)
        {
            QBOperation oOperation = new QBOperation(oOperationType);
            if (oOperationType == OperationType.IsNull || oOperationType == OperationType.IsNotNull)
            {
                _Expression = string.Format("{0}{1}{2}", oOperation.StartTag, oField.NullExpression, oOperation.EndTag);
            }
            else
            {
                _Expression = string.Format("{0}{1}{2}", oOperation.StartTag, oField.Expression, oOperation.EndTag);
            }

            QBOperator oOperator = new QBOperator(oOperatorType);
            _ExpressionOpearator = oOperator;
        }

        private QBOperator _ExpressionOpearator;
        public QBOperator ExpressionOpearator
        {
            get
            {
                return _ExpressionOpearator;
            }
        }
        private string _Expression;
        public string Expression
        {
            get
            {
                return _Expression;
            }
        }

    }
}
