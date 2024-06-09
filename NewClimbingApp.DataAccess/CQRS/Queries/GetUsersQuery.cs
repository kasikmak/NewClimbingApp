using Microsoft.EntityFrameworkCore;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Queries;

public class GetUsersQuery : QueryBase<List<User>>
{
    public override Task<List<User>> Execute(NewClimbingAppContext context)
    {
        return context.Users
            .OrderBy (x => x.UserName)
            .ThenBy (x => x.Role)
            .Include(x => x.Routes)
            .Include(x => x.Ascents)
            .AsNoTracking()
            .ToListAsync();
    }
}
