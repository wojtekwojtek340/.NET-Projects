using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Managers;

namespace TaskManager.ApplicationServices.API.Validators.Managers
{
    public class AddManagerRequestValidator : AbstractValidator<AddManagerRequest>
    {
        public AddManagerRequestValidator()
        {
            this.RuleFor(x => x.Login).NotNull().NotEmpty().MaximumLength(200);
            this.RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(200);
            this.RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(200);
            this.RuleFor(x => x.Surname).NotNull().NotEmpty().MaximumLength(200);

        }
    }
}
