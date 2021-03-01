using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Models
{
    public enum AssignmentStatus
    {
        ToBePlanned,
        Planned,
        InProgress,
        Completed,
        Suspended,
        Canceled
    }
    public class AssignmentsDto
    {       
        public int Id { get; set; }
        public string Tilte { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime DeadlineTime { get; set; }
        public int CustomerId { get; set; }
        public CustomersDto Customer { get; set; }
        public int BoardId { get; set; }
        public BoardsDto Board { get; set; }
        public List<CommentsDto> CommentsList { get; set; }
        public AssignmentStatus AssignmentStatus { get; set; }

    }
}
