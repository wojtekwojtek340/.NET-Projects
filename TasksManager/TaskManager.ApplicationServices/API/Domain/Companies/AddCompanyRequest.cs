using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Domain.Companies
{
    public class AddCompanyRequest : RequestBase, IRequest<AddCompanyResponse>
    {
        public string Description { get; set; }
        //public List<Employee> EmployeesList { get; set; }
        public int ManagerId { get; set; }
        //public Manager Manager { get; set; }
    }
}
