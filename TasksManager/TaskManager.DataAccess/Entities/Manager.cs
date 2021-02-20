using System.ComponentModel.DataAnnotations;

namespace TaskManager.DataAccess.Entities
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public int Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public Company Company { get; set; }
    }
}
