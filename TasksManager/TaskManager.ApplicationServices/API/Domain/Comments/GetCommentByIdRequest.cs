using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Comments
{
    public class GetCommentByIdRequest : RequestBase, IRequest<GetCommentByIdResponse>
    {
        public int CommentId { get; set; }
    }
}
