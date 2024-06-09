using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class AddAscentCommand : CommandBase<Ascent, Ascent>
{
    public bool IsClimbed { get; set; }

    public string Notes { get; set; }

    public int Rating { get; set; }

    public int ClimberId { get; set; }

    public override async Task<Ascent> Execute(NewClimbingAppContext context)
    {
        Parameter.ClimberId = ClimberId;
        Parameter.IsClimbed = true;
        context.Ascents.Add(Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
