using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class UpdateCragCommand : CommandBase<Crag, Crag>
{
    public override async Task<Crag> Execute(NewClimbingAppContext context)
    {
        context.ChangeTracker.Clear();
        context.Crags.Update(Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
