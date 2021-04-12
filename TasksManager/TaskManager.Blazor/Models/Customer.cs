using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Assignment> AssignmentList { get; set; }
        public int CompanyId { get; set; }
    }
}
