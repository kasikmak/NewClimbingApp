using Microsoft.EntityFrameworkCore;
using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Queries;

public class GetUserQuery : QueryBase<User>
{
    public int? UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
   
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override async Task<User> Execute(NewClimbingAppContext context)
    {
        if(!string.IsNullOrEmpty(this.FirstName)
            && !string.IsNullOrEmpty(this.LastName))
            {
                return await context.Users.FirstOrDefaultAsync(x=>x.FirstName == this.FirstName
                && x.LastName == this.LastName);
            }
        if(!string.IsNullOrEmpty(this.UserName))
            {
                return await context.Users.FirstOrDefaultAsync(x => x.UserName == this.UserName);
            };
        if(this.UserId != null)
        {
            return await context.Users.FirstOrDefaultAsync(x=>x.Id == this.UserId);
        }
        return null;
    }
}
