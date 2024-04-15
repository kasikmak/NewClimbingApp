using Microsoft.EntityFrameworkCore;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Queries;

public class GetRouteQuery : QueryBase<Route>
{
    public int Id { get; set; }
        
    public override async Task<Route> Execute(NewClimbingAppContext context)
    {        
        var route = await context.Routes.FirstOrDefaultAsync(x => x.Id == Id);
        return route;
    }
}
