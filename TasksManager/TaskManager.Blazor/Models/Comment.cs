using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
    }
}
