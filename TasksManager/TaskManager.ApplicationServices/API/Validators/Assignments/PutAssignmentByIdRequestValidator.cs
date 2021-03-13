using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Assignments;

namespace TaskManager.ApplicationServices.API.Validators.Assignments
{
    public class PutAssignmentByIdRequestValidator : AbstractValidator<PutAssignmentByIdRequest>
    {
        public PutAssignmentByIdRequestValidator()
        {
            this.RuleFor(x => x.Id).NotNull().NotEmpty();

            this.RuleFor(x => x.Description).MaximumLength(500).NotNull().NotEmpty();
            this.RuleFor(x => x.Tilte).MaximumLength(200).NotNull().NotEmpty();


            this.RuleFor(x => x.BoardId).NotNull().NotEmpty();
            this.RuleFor(x => x.CustomerId).NotNull().NotEmpty();

            this.RuleFor(x => x.AssignmentStatus).IsInEnum().NotNull();

            this.RuleFor(x => x.DeadlineTime).NotNull().NotEmpty();
            this.RuleFor(x => x.EndTime).NotNull().NotEmpty();
            this.RuleFor(x => x.StartTime).NotNull().NotEmpty();
        }
    }
}
