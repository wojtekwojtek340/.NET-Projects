using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Comments;

namespace TaskManager.ApplicationServices.API.Validators.Comments
{
    public class PutCommentByIdRequestValidator : AbstractValidator<PutCommentByIdRequest>
    {
        public PutCommentByIdRequestValidator()
        {

        }
    }
}
