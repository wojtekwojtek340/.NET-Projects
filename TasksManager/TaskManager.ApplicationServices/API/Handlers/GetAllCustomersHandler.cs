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
    class GetAllCustomersHandler : IRequestHandler<GetAllCustomersRequest, GetAllCustomersResponse>
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IMapper mapper;

        public GetAllCustomersHandler(IRepository<DataAccess.Entities.Customer> customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }
        public Task<GetAllCustomersResponse> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
        {
            var customers = customerRepository.GetAll();

            var domainCustomers = mapper.Map<IEnumerable<CustomerDto>>(customers);

            var response = new GetAllCustomersResponse()
            {
                Data = domainCustomers.ToList()
            };

            return Task.FromResult(response);

        }
    }
}
