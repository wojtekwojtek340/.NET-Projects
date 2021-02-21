using System.ComponentModel.DataAnnotations;

namespace TaskManager.DataAccess.Entities
{
    public class Employee : EntityBase
    {
        [Required]
        [MaxLength(200)]
        public string Login { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Surname { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public Company Company { get; set; }

        [Required]
        public int BoardId { get; set; }

        [Required]
        public Board Board { get; set; }
    }
}
