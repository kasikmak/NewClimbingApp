using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class UpdateUserCommand : CommandBase<User, User>
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nationality { get; set; }
    public string Password { get; set; }


    public override async Task<User> Execute(NewClimbingAppContext context)
    {
        context.ChangeTracker.Clear();
        context.Users.Update(this.Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
