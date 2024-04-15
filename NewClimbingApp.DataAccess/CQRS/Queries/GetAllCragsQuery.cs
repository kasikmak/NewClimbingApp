using Microsoft.EntityFrameworkCore;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Queries;

public class GetAllCragsQuery : QueryBase<List<Crag>>
{
     

    public override  async Task<List<Crag>> Execute(NewClimbingAppContext context)
    {
        return await context.Crags
            .Include(x => x.Routes)
            .AsNoTracking()
            .ToListAsync();
    }
}
