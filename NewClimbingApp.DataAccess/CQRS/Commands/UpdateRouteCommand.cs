using NewClimbingApp.DataAccess.Entities;
using NewClimbingApp.DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class UpdateRouteCommand : CommandBase<Route, Route>
{
    public string Grade {  get; set; }
    public float GradeAsFloat { get; set; }

    public override async Task<Route> Execute(NewClimbingAppContext context)
    {
        context.ChangeTracker.Clear();
        Parameter.Grade = Grade;
        Parameter.GradeAsFloat = GradeAsFloat;
        context.Routes.Update(Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
