using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Models
{
    public class BoardDto
    {
        public int Id { get; set; }
        public List<AssignmentDto> AssignmentList { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
