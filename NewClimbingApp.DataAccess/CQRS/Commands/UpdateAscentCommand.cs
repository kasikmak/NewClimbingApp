using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class UpdateAscentCommand : CommandBase<Ascent, Ascent>
{
    public override async Task<Ascent> Execute(NewClimbingAppContext context)
    {
        context.ChangeTracker.Clear();
        context.Update(Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
