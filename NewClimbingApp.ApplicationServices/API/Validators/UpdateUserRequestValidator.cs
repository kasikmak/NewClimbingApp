using FluentValidation;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Users;
using NewClimbingApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Validators;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator(NewClimbingAppContext dbContext)
    {
        this.RuleFor(x => x.UserName).NotEmpty()
           .MaximumLength(25);
        this.RuleFor(x => x.LastName).NotEmpty()
            .MaximumLength(25);
        this.RuleFor(x => x.LastName).NotEmpty()
            .MaximumLength(25);
        this.RuleFor(x => x.Nationality).MaximumLength(25);
        this.RuleFor(x => x.Email).NotEmpty()
            .MaximumLength(50)
            .EmailAddress();            
            this.RuleFor(x => x.Password).NotEmpty()
            .MinimumLength(8);           
    }
}
