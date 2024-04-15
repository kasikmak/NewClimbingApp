using Microsoft.EntityFrameworkCore;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Queries;

public class GetCragQuery : QueryBase<Crag>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public override async Task<Crag> Execute(NewClimbingAppContext context)
    {

        if (!string.IsNullOrEmpty(this.Name))
        {
            return await context.Crags.FirstOrDefaultAsync(x => x.Name == this.Name);
        }        
        if (this.Id != null)
        {
            return await context.Crags
                .Include(x => x.Routes)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }
        return null;        
    }
}
