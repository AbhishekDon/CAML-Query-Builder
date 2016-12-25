using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMLQueryBuilder.Query
{
    public class CAMLQuery
    {
        private string _Expression = string.Empty;
        private string _StartExpression = string.Empty;
        private string _EndExpression = string.Empty;
        private string _View = "<View>{0}</View>";
        private string _RowLimit = "<RowLimit>{0}</RowLimit>";
        private string _ViewWithRowLimit = "<View>{0}{1}</View>";
        private string _ViewExpression = string.Empty;
        private string _Query = "<Query>{0}</Query>";
        private string _QueryExpression = string.Empty;
        private string _Where = "<Where>{0}</Where>";
        private string _WhereExpression = string.Empty;
        public CAMLQuery(List<FieldQuery> oQueryExpressions, Nullable<int> iRowLimit, OrderByQuery oOrderByExpression)
        {
            switch (oQueryExpressions.Capacity)
            {
                case 1:
                    foreach (FieldQuery QryExp in oQueryExpressions)
                    {
                        _StartExpression += QryExp.Expression;
                    }
                    break;

                default:
                    FieldQuery oLastQueryExp = oQueryExpressions.Last<FieldQuery>();
                    foreach (FieldQuery QryExp in oQueryExpressions)
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
            _WhereExpression = string.Format(_Where, _Expression);

            if (oOrderByExpression == null)
            {
                _QueryExpression = string.Format(_Query, _WhereExpression);
            }
            else
            {
                _QueryExpression = string.Format("{0}{1}", _WhereExpression, oOrderByExpression.Expression);
                _QueryExpression = string.Format(_Query, _QueryExpression);
            }

            if (iRowLimit.HasValue)
            {
                _RowLimit = string.Format(_RowLimit, iRowLimit);
                _ViewExpression = string.Format(_ViewWithRowLimit, _QueryExpression, _RowLimit);
            }
            else
            {
                _ViewExpression = string.Format(_View, _QueryExpression);
            }

        }

        public CAMLQuery(List<SubQuery> oQueryExpressions, Nullable<int> iRowLimit, OrderByQuery oOrderByExpression)
        {
            switch (oQueryExpressions.Capacity)
            {
                case 1:
                    foreach (SubQuery QryExp in oQueryExpressions)
                    {
                        _StartExpression += QryExp.Expression;
                    }
                    break;

                default:
                    SubQuery oLastQueryExp = oQueryExpressions.Last<SubQuery>();
                    foreach (SubQuery QryExp in oQueryExpressions)
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
            _WhereExpression = string.Format(_Where, _Expression);

            if (oOrderByExpression == null)
            {
                _QueryExpression = string.Format(_Query, _WhereExpression);
            }
            else
            {
                _QueryExpression = string.Format("{0}{1}", _WhereExpression, oOrderByExpression.Expression);
                _QueryExpression = string.Format(_Query, _QueryExpression);
            }

            if (iRowLimit.HasValue)
            {
                _RowLimit = string.Format(_RowLimit, iRowLimit);
                _ViewExpression = string.Format(_ViewWithRowLimit, _QueryExpression, _RowLimit);
            }
            else
            {
                _ViewExpression = string.Format(_View, _QueryExpression);
            }

        }

        public string Expression
        {
            get
            {
                return _Expression;
            }
        }
        public string ViewExpression
        {
            get
            {
                return _ViewExpression;
            }
        }
        public string QueryExpression
        {
            get
            {
                return _QueryExpression;
            }
        }
        public string WhereExpression
        {
            get
            {
                return _WhereExpression;
            }
        }
    }
}
