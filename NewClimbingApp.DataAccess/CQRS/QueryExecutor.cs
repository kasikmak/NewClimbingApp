using NewClimbingApp.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS;

public class QueryExecutor : IQueryExecutor    
{
    private readonly NewClimbingAppContext context;

    public QueryExecutor(NewClimbingAppContext context)
    {
        this.context = context;
    }

    public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
    {
        return query.Execute(this.context);
    }
}
