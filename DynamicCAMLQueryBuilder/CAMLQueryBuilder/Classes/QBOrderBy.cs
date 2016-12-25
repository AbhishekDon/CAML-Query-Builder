using CAMLQueryBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMLQueryBuilder
{
    public class QBOrderBy
    {
        //private string _OrderByExpression = "<FieldRef Name='{0}' Ascending='{1}' />";
        private string _Expression = string.Empty;
        //private string _Value = string.Empty;
        //public QBOrderBy(QBField oField, OrderByType oOrderByType)
        //{
        //    _Value = oOrderByType == OrderByType.Ascending ? "True" : "False";
        //    _Expression = string.Format(_OrderByExpression, oField.Name, _Value);
        //}
        public string Expression
        {
            get
            {
                return _Expression;
            }
            set
            {
                _Expression = value;
            }
        }
    }
}
