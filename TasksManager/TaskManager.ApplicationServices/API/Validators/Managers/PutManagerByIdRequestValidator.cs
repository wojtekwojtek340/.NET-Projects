using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Managers;

namespace TaskManager.ApplicationServices.API.Validators.Managers
{
    public class PutManagerByIdRequestValidator : AbstractValidator<PutManagerByIdRequest>
    {
        public PutManagerByIdRequestValidator()
        {
            this.RuleFor(x => x.Login).MaximumLength(200);
            this.RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(200);
            this.RuleFor(x => x.Password).MaximumLength(200);
            this.RuleFor(x => x.Surname).NotNull().NotEmpty().MaximumLength(200);
            this.RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
