using FluentValidation;
using NewClimbingApp.ApplicationServices.API.Domain.Requests.Ascents;
using NewClimbingApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NewClimbingApp.ApplicationServices.API.Validators;
 public class UpdateAscentValidator : AbstractValidator<UpdateAscentRequest>
    {
    public UpdateAscentValidator(NewClimbingAppContext dbcontext)
    {
        this.RuleFor(x => x.Notes).MaximumLength(250);
    }
 }

