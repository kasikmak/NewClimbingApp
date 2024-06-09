using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Users;
using NewClimbingApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Validators;

public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
{
    public AddUserRequestValidator(NewClimbingAppContext dbContext)
    {
        this.RuleFor(x => x.UserName).NotEmpty()
            .MaximumLength(25)
            .Custom((value, context) =>
            {
                var userNamelInUse = dbContext.Users.Any(x => x.UserName == value);
                if (userNamelInUse)
                {
                    context.AddFailure("UserName", "UserName already in use");
                }
            });
        this.RuleFor(x=>x.FirstName).NotEmpty()
            .MaximumLength(25);
        this.RuleFor(x=>x.LastName).NotEmpty()
            .MaximumLength(25);
        this.RuleFor(x=>x.Nationality).MaximumLength(25);
        this.RuleFor(x => x.Email).NotEmpty()
            .MaximumLength(50)
            .EmailAddress()
            .Custom((value, context) =>
            {
                var emailInUse = dbContext.Users.Any(x => x.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("Email", "Email already in use");
                }
            });
            this.RuleFor(x => x.Password).NotEmpty()
            .MinimumLength(8);            
    }
}
