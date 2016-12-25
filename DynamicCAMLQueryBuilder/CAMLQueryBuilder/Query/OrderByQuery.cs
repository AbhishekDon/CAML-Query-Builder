using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMLQueryBuilder
{
    public class OrderByQuery
    {
        private string _Expression = string.Empty;
        private string _OrderBy = "<OrderBy>{0}</OrderBy>";
        public OrderByQuery(List<QBOrderBy> oQueryorderBy)
        {
            foreach (QBOrderBy Order in oQueryorderBy)
            {
                _Expression += Order.Expression;
            }
            _Expression = string.Format(_OrderBy, _Expression);
        }
        public string Expression
        {
            get
            {
                return _Expression;
            }
        }
    }
}
