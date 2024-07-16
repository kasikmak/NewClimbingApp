﻿using NewClimbingApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.DataAccess.CQRS.Commands;

public class DeleteUserCommand : CommandBase<User, bool>
{
    public override async Task<bool> Execute(NewClimbingAppContext context)
    {
        context.ChangeTracker.Clear();
        context.Users.Remove(this.Parameter);
        await context.SaveChangesAsync();
        return true;
    }
}
