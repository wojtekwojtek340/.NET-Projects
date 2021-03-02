using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Employees
{
    public class AddEmployeeRequest : IRequest<AddEmployeeResponse>
    {       
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CompanyId { get; set; }
       // public Company Company { get; set; }
        //public int BoardId { get; set; }

        //public Board Board { get; set; }
    }
}
