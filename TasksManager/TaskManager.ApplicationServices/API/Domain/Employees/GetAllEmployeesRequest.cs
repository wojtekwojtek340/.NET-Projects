using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Employees
{
    public class GetAllEmployeesRequest : IRequest<GetAllEmployeesResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
