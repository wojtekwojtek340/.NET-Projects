using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.DataAccess.Entities
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
    public class Assignment : EntityBase
    {
        [Required]
        [MaxLength(200)]
        public string Tilte { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }       

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public DateTime DeadlineTime { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public int BoardId { get; set; }

        [Required]
        public Board Board { get; set; }

        [Required]
        public List<Comment> CommentsList { get; set; }

        [Required]
        public AssignmentStatus AssignmentStatus { get; set; }
    }
}
