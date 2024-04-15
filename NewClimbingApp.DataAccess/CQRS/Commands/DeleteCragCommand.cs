using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class DeleteCragCommand : CommandBase<Crag, Crag>
{
    public override async Task<Crag> Execute(NewClimbingAppContext context)
    {
        context.Crags.Remove(Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
