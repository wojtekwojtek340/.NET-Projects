using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Board
    {        
        public int Id { get; set; }
        public List<Assignment> AssignmentList { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
