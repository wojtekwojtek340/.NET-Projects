using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.DataAccess.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ICollection<Assignment> AssignmentList { get; set; }
    }
}
