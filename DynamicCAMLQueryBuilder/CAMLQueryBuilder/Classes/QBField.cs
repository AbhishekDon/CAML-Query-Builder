using CAMLQueryBuilder.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMLQueryBuilder
{
    public class QBField
    {
        private string _Expression;
        private string _QueryExpression = "<FieldRef Name='{0}' /><Value Type='{1}'>{2}</Value>";
        private string _NullExpression;
        private string _NullQueryExpression = "<FieldRef Name='{0}' />";
        private string _OrderByExpression = "<FieldRef Name='{0}' Ascending='{1}' />";

        public QBField(string Name, string Value, FieldType Type)
        {
            this.Name = Name;
            this.Value = Value;
            this.Type = Type;

            _Expression = string.Format(_QueryExpression, Name, Type, Value);
            _NullExpression = string.Format(_NullQueryExpression, Name);
        }
        public QBField()
        {
            _Expression = string.Format(_QueryExpression, Name, Type, Value);
            _NullExpression = string.Format(_NullQueryExpression, Name);

        }
        public string Name { get; set; }
        public string Value { get; set; }
        public FieldType Type { get; set; }
        public string Expression
        {
            get
            {
                return _Expression;
            }
        }
        public string NullExpression
        {
            get
            {
                return _NullExpression;
            }
        }

        public QBOrderBy OrderByExpressionAsc
        {
            get
            {
                QBOrderBy AscOrderBy = new QBOrderBy();
                AscOrderBy.Expression = string.Format(_OrderByExpression, Name, "True");
                return AscOrderBy;
            }
        }
        public QBOrderBy OrderByExpressionDesc
        {
            get
            {
                QBOrderBy DescOrderBy = new QBOrderBy();
                DescOrderBy.Expression = string.Format(_OrderByExpression, Name, "False");
                return DescOrderBy;
            }
        }
    }
}
