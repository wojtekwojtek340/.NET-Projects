using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.DataAccess;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers
{
    public class GetManagersHandler : IRequestHandler<GetManagersRequest, GetManagersResponse>
    {
        private readonly IRepository<Manager> managerRepository;

        public GetManagersHandler(IRepository<DataAccess.Entities.Manager> managerRepository)
        {
            this.managerRepository = managerRepository;
        }

        public Task<GetManagersResponse> Handle(GetManagersRequest request, CancellationToken cancellationToken)
        {
            var managers = managerRepository.GetAll();

            var domainManagers = managers.Select(x => new Domain.Models.Manager()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            });

            var response = new GetManagersResponse()
            {
                Data = domainManagers.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
