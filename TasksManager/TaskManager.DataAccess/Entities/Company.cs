using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.DataAccess.Entities
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        public string Description { get; set; }      

        [Required]
        public ICollection<Employee> EmployeesList { get; set; }

        [Required]
        public int ManagerId { get; set; }

        [Required]
        public Manager Manager { get; set; }

    }
}
