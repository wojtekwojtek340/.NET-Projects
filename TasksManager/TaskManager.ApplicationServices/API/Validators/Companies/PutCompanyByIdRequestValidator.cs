using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Companies;

namespace TaskManager.ApplicationServices.API.Validators.Companies
{
    public class PutCompanyByIdRequestValidator : AbstractValidator<PutCompanyByIdRequest>
    {
        public PutCompanyByIdRequestValidator()
        {

        }
    }
}
