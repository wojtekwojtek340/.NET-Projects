using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Boards;

namespace TaskManager.ApplicationServices.API.Validators.Boards
{
    public class AddBoardRequestValidator : AbstractValidator<AddBoardRequest>
    {
        public AddBoardRequestValidator()
        {

        }
    }
}
