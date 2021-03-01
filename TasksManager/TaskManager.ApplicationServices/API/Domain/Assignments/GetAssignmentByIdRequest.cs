using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Assignments
{
    public class GetAssignmentByIdRequest : IRequest<GetAssignmentByIdResponse>
    {
        public readonly int assignmentId;

        public GetAssignmentByIdRequest()
        {

        }
        public GetAssignmentByIdRequest(int assignmentId)
        {
            this.assignmentId = assignmentId;
        }
    }
}
