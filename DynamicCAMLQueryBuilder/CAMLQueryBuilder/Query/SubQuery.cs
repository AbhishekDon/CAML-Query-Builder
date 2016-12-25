using CAMLQueryBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMLQueryBuilder.Query
{
    public class SubQuery
    {
        private string _Expression = string.Empty;
        private string _StartExpression = string.Empty;
        private string _EndExpression = string.Empty;

        private QBOperator _ExpressionOpearator;
        

        public SubQuery(List<FieldQuery> oFieldQueries, OperatorType oOperatorType)
        {
            switch (oFieldQueries.Capacity)
            {
                case 1:
                    foreach (FieldQuery QryExp in oFieldQueries)
                    {
                        _StartExpression += QryExp.Expression;
                    }
                    break;

                default:
                    FieldQuery oLastQueryExp = oFieldQueries.Last<FieldQuery>();
                    foreach (FieldQuery QryExp in oFieldQueries)
                    {
                        if (!QryExp.Equals(oLastQueryExp))
                        {
                            _StartExpression += QryExp.ExpressionOpearator.StartTag;
                            _StartExpression += QryExp.Expression;
                            _EndExpression += QryExp.ExpressionOpearator.EndTag;
                        }
                        else
                        {
                            _StartExpression += QryExp.Expression;
                        }
                    }
                    break;
            }
            _Expression += _StartExpression;
            _Expression += _EndExpression;
            QBOperator oOperator = new QBOperator(oOperatorType);
            _ExpressionOpearator = oOperator;
        }
        public string Expression
        {
            get
            {
                return _Expression;
            }
        }
        public QBOperator ExpressionOpearator
        {
            get
            {
                return _ExpressionOpearator;
            }
        }
    }
}
