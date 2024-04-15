using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class AddAscentToRouteCommand : CommandBase<Route, Route>
{
    public async override Task<Route> Execute(NewClimbingAppContext context)
    {
        context.Update(Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
