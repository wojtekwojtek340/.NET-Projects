using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.DataAccess.Entities
{    
    public class Board : EntityBase
    {
        [Required]
        public List<Assignment> AssignmentList { get; set; }       

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public Employee Employee { get; set; }
    }
}
