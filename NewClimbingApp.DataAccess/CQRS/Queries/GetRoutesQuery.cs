using Microsoft.EntityFrameworkCore;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Queries;

public class GetRoutesQuery : QueryBase<List<Route>>
{
    public string Name { get; set; }

    public string Grade { get; set; }

    public float GradeAsFloat { get; set; }

    public override async Task<List<Route>> Execute(NewClimbingAppContext context)
    {
        if (!string.IsNullOrEmpty(this.Name))
        {
            return await context.Routes.Where(x=> x.Name == this.Name).ToListAsync();
        }
        if (!string.IsNullOrEmpty(this.Grade))
        {
            return await context.Routes
                .Where(x => x.Grade == this.Grade)
                .OrderByDescending(x => x.Name)
                .ToListAsync();
        }
        
        return await context.Routes            
            .OrderBy(x => x.GradeAsFloat)
            .Include(x => x.Ascent)          
            .ToListAsync();                   
    }
}