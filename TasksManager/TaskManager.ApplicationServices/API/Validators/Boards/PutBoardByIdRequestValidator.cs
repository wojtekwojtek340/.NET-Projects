using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Boards;

namespace TaskManager.ApplicationServices.API.Validators.Boards
{
    public class PutBoardByIdRequestValidator : AbstractValidator<PutBoardByIdRequest>
    {
        public PutBoardByIdRequestValidator()
        {
            this.RuleFor(x => x.EmployeeId).NotEmpty().NotNull();
            this.RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
