using System.ComponentModel.DataAnnotations;

namespace TaskManager.DataAccess.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]        
        public Assignment Assignment { get; set; }
    }
}
