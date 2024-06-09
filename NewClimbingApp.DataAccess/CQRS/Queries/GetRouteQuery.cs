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

    public string Name { get; set; }
        
    public override async Task<Route> Execute(NewClimbingAppContext context)
    {      
        if(this.Id != null)
        {
            var route = await context.Routes
           .Include(x => x.Climbers)
           .Include(x => x.Ascents.Select(x => x.Rating).Average())
           .FirstOrDefaultAsync(x => x.Id == Id);
            return route;
        }
        if (!string.IsNullOrEmpty(this.Name))
        {
            var route = await context.Routes
           .Include(x => x.Climbers)
           .Include(x => x.Ascents.Select(x => x.Rating).Average())
           .FirstOrDefaultAsync(x => x.Name == Name);
            return route;
        }
        return null;
    }
}
