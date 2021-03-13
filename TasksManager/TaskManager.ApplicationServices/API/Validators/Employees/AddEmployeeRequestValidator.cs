using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Employees;

namespace TaskManager.ApplicationServices.API.Validators.Employees
{
    public class AddEmployeeRequestValidator : AbstractValidator<AddEmployeeRequest>
    {
        public AddEmployeeRequestValidator()
        {
            this.RuleFor(x => x.Login).NotNull().NotEmpty().MaximumLength(200);
            this.RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(200);
            this.RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(200);
            this.RuleFor(x => x.Surname).NotNull().NotEmpty().MaximumLength(200);
        }
    }
}
