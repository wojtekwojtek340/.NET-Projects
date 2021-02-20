using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.DataAccess.Entities
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        public string Tilte { get; set; }

        [Required]
        public string Description { get; set; }       

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public DateTime DeadlineTime { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Board Board { get; set; }

        [Required]
        public ICollection<Comment> CommentsList { get; set; }       
    }
}
