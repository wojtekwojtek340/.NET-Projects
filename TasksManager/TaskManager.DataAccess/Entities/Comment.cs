using System.ComponentModel.DataAnnotations;

namespace TaskManager.DataAccess.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]        
        public Assignment Task { get; set; }
    }
}
