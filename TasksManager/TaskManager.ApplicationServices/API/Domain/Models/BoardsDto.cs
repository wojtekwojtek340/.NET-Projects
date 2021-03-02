using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Models
{
    public class BoardsDto
    {
        public int Id { get; set; }
        public List<AssignmentsDto> AssignmentList { get; set; }
        public int EmployeeId { get; set; }
        public EmployeesDto Employee { get; set; }
    }
}
