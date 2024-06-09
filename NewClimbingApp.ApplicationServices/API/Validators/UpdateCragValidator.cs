using FluentValidation;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Crags;
using NewClimbingApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Validators;

public class UpdateCragValidator : AbstractValidator<UpdateCragRequest>
{
    public UpdateCragValidator(NewClimbingAppContext dbcontext)
    {
        this.RuleFor(x => x.Name).NotEmpty()
            .MaximumLength(100);
        this.RuleFor(x => x.Description).MaximumLength(1000);
        this.RuleFor(x => x.Location).MaximumLength(50);
    }
}
