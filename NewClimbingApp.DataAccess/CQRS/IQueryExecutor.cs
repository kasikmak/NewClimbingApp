﻿using NewClimbingApp.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS;

public interface IQueryExecutor
{
    Task<TResult> Execute<TResult>(QueryBase<TResult> query);
}
