using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Assignments;

namespace TaskManager.ApplicationServices.API.Validators.Assignments
{
    public class AddAssignmentRequestValidator : AbstractValidator<AddAssignmentRequest>
    {
        public AddAssignmentRequestValidator()
        {
            this.RuleFor(x => x.BoardId).InclusiveBetween(0, 10);
            this.RuleFor(x => x.Description).Length(1, 10);
        }
    }
}
