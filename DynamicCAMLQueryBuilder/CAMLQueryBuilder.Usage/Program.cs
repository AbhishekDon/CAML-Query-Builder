using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAMLQueryBuilder;
using CAMLQueryBuilder.Query;
using CAMLQueryBuilder.Enums;

namespace CAMLQueryBuilder.Usage
{
    class Program
    {
        static void Main(string[] args)
        {
            CAMLQueryWithSubQuery();
            Console.ReadKey();
            CAMLQueryWithSubQueryAndOrderby();
            Console.ReadKey();
        }
        static void SimpleCAMLQuery()
        {

        }
        static void CAMLQueryWithSubQuery()
        {
            List<string> status = new List<string>();
            status.Add("Status1");
            status.Add("Status2");

            List<SubQuery> queries = new List<SubQuery>();
            foreach (string sta in status)
            {
                List<FieldQuery> singleQueries = new List<FieldQuery>();

                QBField Statusfield = new QBField("LU_Status", sta, FieldType.Lookup);
                QBField StatusHiddenfield = new QBField("StatusHidden", sta, FieldType.Text);

                FieldQuery sqe1 = new FieldQuery(StatusHiddenfield, OperationType.Neq, OperatorType.And);
                FieldQuery sqe = new FieldQuery(Statusfield, OperationType.Eq, OperatorType.And);

                singleQueries.Add(sqe1);
                singleQueries.Add(sqe);

                SubQuery subQuery = new SubQuery(singleQueries, OperatorType.Or);
                queries.Add(subQuery);
            }

            CAMLQuery oCAMLquery = new CAMLQuery(queries, 47, null);

            Console.Write(oCAMLquery.ViewExpression);
        }
        static void CAMLQueryWithSubQueryAndOrderby()
        {
            List<string> status = new List<string>();
            status.Add("Status1");
            status.Add("Status2");

            List<SubQuery> queries = new List<SubQuery>();
            foreach (string sta in status)
            {
                List<FieldQuery> singleQueries = new List<FieldQuery>();

                QBField Statusfield = new QBField("LU_Status", sta, FieldType.Lookup);
                QBField StatusHiddenfield = new QBField("StatusHidden", sta, FieldType.Text);

                FieldQuery sqe1 = new FieldQuery(StatusHiddenfield, OperationType.Neq, OperatorType.And);
                FieldQuery sqe = new FieldQuery(Statusfield, OperationType.Eq, OperatorType.And);

                singleQueries.Add(sqe1);
                singleQueries.Add(sqe);

                SubQuery subQuery = new SubQuery(singleQueries, OperatorType.Or);
                queries.Add(subQuery);
            }

            QBField domainName = new QBField();
            domainName.Name = "DomainName";
            QBField statusF = new QBField();
            statusF.Name = "LU_Status";

            List<QBOrderBy> allOrderBy = new List<QBOrderBy>();
            allOrderBy.Add(domainName.OrderByExpressionAsc);
            allOrderBy.Add(statusF.OrderByExpressionDesc);

            OrderByQuery orderByQuery = new OrderByQuery(allOrderBy);

            CAMLQuery oCAMLquery = new CAMLQuery(queries, 47, orderByQuery);

            Console.Write(oCAMLquery.ViewExpression);
        }
    }
}
