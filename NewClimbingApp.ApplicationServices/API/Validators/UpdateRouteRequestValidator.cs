using FluentValidation;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewClimbingApp.ApplicationServices.API.Validators;

public class UpdateRouteRequestValidator : AbstractValidator<UpdateRouteRequest>
{
    public UpdateRouteRequestValidator()
    {
        this.RuleFor(x => x.Name).NotEmpty()
          .MaximumLength(100);
        this.RuleFor(x => x.Grade).NotEmpty()
            .MaximumLength(5);
       // this.RuleFor(x => x.GradeAsFloat).NotEmpty()
       //     .InclusiveBetween(4F, 9.3F);
    }
}
