﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Customers;

namespace TaskManager.ApplicationServices.API.Validators.Customers
{
    public class AddCustomerRequestValidator : AbstractValidator<AddCustomerRequest>
    {
        public AddCustomerRequestValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(200);
            this.RuleFor(x => x.CompanyId).NotEmpty().NotNull();
        }
    }
}
