# CAML-Query-Builder Guidelines
  List<string> status = new List<string>();
  status.Add("Status1");
  status.Add("Status2");

  List<SubQuery> subQueries = new List<SubQuery>();
  foreach (string sta in status)
  {
      List<FieldQuery> fieldQueries = new List<FieldQuery>();

      QBField Statusfield = new QBField("LU_Status", sta, FieldType.Lookup);
      QBField StatusHiddenfield = new QBField("StatusHidden", sta, FieldType.Text);

      FieldQuery fq1 = new FieldQuery(StatusHiddenfield, OperationType.Neq, OperatorType.And);
      FieldQuery fq2 = new FieldQuery(Statusfield, OperationType.Eq, OperatorType.And);

      fieldQueries.Add(fq1);
      fieldQueries.Add(fq2);

      SubQuery subQuery = new SubQuery(singleQueries, OperatorType.Or);
      subQueries.Add(subQuery);
   }

    CAMLQuery oCAMLquery = new CAMLQuery(subQueries, 47, null);
    
    Console.WriteLine(oCAMLquery.ViewExpression);
  
  //end of file
