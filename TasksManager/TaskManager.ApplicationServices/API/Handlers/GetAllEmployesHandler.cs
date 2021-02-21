using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers
{
    public class GetAllEmployesHandler : IRequestHandler<GetAllEmployesRequest, GetAllEmployesResponse>
    {
        private readonly IRepository<Employee> employeeRepository;
        private readonly IMapper mapper;

        public GetAllEmployesHandler(IRepository<DataAccess.Entities.Employee> employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }
        public Task<GetAllEmployesResponse> Handle(GetAllEmployesRequest request, CancellationToken cancellationToken)
        {
            var employes = this.employeeRepository.GetAll();

            var domainEmployes = mapper.Map<IEnumerable<EmployeeDto>>(employes);          

            var response = new GetAllEmployesResponse()
            {
                Data = domainEmployes.ToList()
            };

            return Task.FromResult(response);
           
        }
    }
}
