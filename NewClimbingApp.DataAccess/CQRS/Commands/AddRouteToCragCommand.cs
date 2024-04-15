using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class AddRouteToCragCommand : CommandBase<Crag, Crag>
{
    public override async Task<Crag> Execute(NewClimbingAppContext context)
    {
        context.Update(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
