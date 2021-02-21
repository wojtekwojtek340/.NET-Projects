using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } 
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
        public int BoardId { get; set; }
        public BoardDto Board { get; set; }
    }
}
