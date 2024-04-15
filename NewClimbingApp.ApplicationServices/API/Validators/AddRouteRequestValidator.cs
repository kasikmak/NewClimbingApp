using FluentValidation;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Validators;

public class AddRouteRequestValidator : AbstractValidator<AddRouteRequest>
{
    public AddRouteRequestValidator()
    {
        this.RuleFor(x => x.Name).NotEmpty()
            .MaximumLength(100);
        this.RuleFor(x => x.Grade).NotEmpty()
            .MaximumLength(5);
       // this.RuleFor(x => x.GradeAsFloat).InclusiveBetween(4F, 9.3F);
    }
}
