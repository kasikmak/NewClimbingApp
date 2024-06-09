using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class AddRouteCommand : CommandBase<Route, Route>
{
    public string Grade {  get; set; }

    public float GradeAsFloat { get; set; }

    public int ClimberId { get; set; }

    public override async Task<Route> Execute(NewClimbingAppContext context)
    {        
        Parameter.Grade = Grade;
        Parameter.GradeAsFloat = GradeAsFloat;
        context.Routes.Add(this.Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
