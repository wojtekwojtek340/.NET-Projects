using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.DataAccess.Entities
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public ICollection<Assignment> ToBePlanned { get; set; }

        [Required]
        public ICollection<Assignment> Planned { get; set; }

        [Required]
        public ICollection<Assignment> InProgress { get; set; }

        [Required]
        public ICollection<Assignment> Completed { get; set; }

        [Required]
        public ICollection<Assignment> Suspended { get; set; }

        [Required]
        public ICollection<Assignment> Canceled { get; set; }
    }
}
