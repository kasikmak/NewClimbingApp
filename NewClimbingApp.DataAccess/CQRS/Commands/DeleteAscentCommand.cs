using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class DeleteAscentCommand : CommandBase<Ascent, Ascent>
{
    public override async Task<Ascent> Execute(NewClimbingAppContext context)
    {
        context.Ascents.Remove(Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
