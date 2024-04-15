using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Queries;

public abstract class QueryBase<TResult>
{
    public abstract Task<TResult> Execute(NewClimbingAppContext context);
}
