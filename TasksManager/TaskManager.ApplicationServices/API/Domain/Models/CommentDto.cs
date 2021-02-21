using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Models
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int AssignmentId { get; set; }
        public AssignmentDto Assignment { get; set; }
    }
}
