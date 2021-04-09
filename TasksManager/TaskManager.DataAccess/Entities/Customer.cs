using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.DataAccess.Entities
{
    public class Customer : EntityBase
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public List<Assignment> AssignmentList { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
}
