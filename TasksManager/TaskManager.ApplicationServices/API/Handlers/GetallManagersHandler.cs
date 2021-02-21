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
    public class GetallManagersHandler : IRequestHandler<GetAllManagersRequest, GetAllManagersResponse>
    {
        private readonly IRepository<Manager> managerRepository;
        private readonly IMapper mapper;

        public GetallManagersHandler(IRepository<DataAccess.Entities.Manager> managerRepository, IMapper mapper)
        {
            this.managerRepository = managerRepository;
            this.mapper = mapper;
        }

        public Task<GetAllManagersResponse> Handle(GetAllManagersRequest request, CancellationToken cancellationToken)
        {
            var managers = managerRepository.GetAll();

            var domainManagers = mapper.Map<IEnumerable<ManagerDto>>(managers);            

            var response = new GetAllManagersResponse()
            {
                Data = domainManagers.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
