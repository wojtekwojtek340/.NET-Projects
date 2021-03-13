using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Companies;

namespace TaskManager.ApplicationServices.API.Validators.Companies
{
    public class AddCompanyRequestValidator : AbstractValidator<AddCompanyRequest>
    {
        public AddCompanyRequestValidator()
        {
            this.RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(400);
            this.RuleFor(x => x.ManagerId).NotEmpty().NotNull();
        }
    }
}
