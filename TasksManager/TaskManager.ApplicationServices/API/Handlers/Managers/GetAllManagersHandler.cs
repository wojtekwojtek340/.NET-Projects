using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Managers;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries.Managers;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Managers
{
    public class GetAllManagersHandler : IRequestHandler<GetAllManagersRequest, GetAllManagersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetAllManagersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllManagersResponse> Handle(GetAllManagersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetManagersQuery();
            var managers = await queryExecutor.Execute(query);
            var mappednManagers = mapper.Map<List<ManagerDto>>(managers);          
            return new GetAllManagersResponse()
            {
                Data = mappednManagers
            };
        }
    }
}
