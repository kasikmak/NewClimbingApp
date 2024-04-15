using Microsoft.EntityFrameworkCore;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Queries;

public class GetAscentQuery : QueryBase<Ascent>
{
    public int Id { get; set; }

    public override async Task<Ascent> Execute(NewClimbingAppContext context)
    {
        return await context.Ascents.FirstOrDefaultAsync(x => x.Id == this.Id);
    }
}
