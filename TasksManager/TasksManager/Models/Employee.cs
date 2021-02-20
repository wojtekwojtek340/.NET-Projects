using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksManager.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public int Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Company Company { get; set; }
        public Board Board { get; set; }
    }
}
