using System.ComponentModel.DataAnnotations;

namespace TaskManager.DataAccess.Entities
{
    public class Comment : EntityBase
    {
        [Required]
        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        public int AssignmentId { get; set; }

        [Required]        
        public Assignment Assignment { get; set; }
    }
}
