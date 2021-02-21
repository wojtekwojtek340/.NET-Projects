using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.DataAccess.Entities
{
    public class Company : EntityBase
    {
        [Required]
        [MaxLength(400)]
        public string Description { get; set; }      

        [Required]
        public List<Employee> EmployeesList { get; set; }

        [Required]
        public int ManagerId { get; set; }

        [Required]
        public Manager Manager { get; set; }

    }
}
