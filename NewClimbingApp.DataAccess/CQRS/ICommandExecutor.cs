using NewClimbingApp.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS;

public interface ICommandExecutor
{
    Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command);
}
