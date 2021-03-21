using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Comments
{
    public class PutCommentByIdRequest : RequestBase, IRequest<PutCommentByIdResponse>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int AssignmentId { get; set; }
    }
}
