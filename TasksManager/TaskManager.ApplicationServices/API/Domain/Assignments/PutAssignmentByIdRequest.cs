using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Domain.Assignments
{
    public class PutAssignmentByIdRequest : RequestBase, IRequest<PutAssignmentByIdResponse>
    {
        public int Id { get; set; }
        public string Tilte { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime DeadlineTime { get; set; }
        public int CustomerId { get; set; }
        //  public Customer Customer { get; set; }
        public int BoardId { get; set; }
        // public Board Board { get; set; }
        // public List<Comment> CommentsList { get; set; }
        public AssignmentStatus AssignmentStatus { get; set; }
    }
}
