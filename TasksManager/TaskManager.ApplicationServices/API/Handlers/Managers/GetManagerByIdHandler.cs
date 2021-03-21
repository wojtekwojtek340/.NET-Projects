using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;
using TaskManager.ApplicationServices.API.Domain.Managers;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries.Managers;

namespace TaskManager.ApplicationServices.API.Handlers.Managers
{
    public class GetManagerByIdHandler : IRequestHandler<GetManagerByIdRequest, GetManagerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetManagerByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetManagerByIdResponse> Handle(GetManagerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetManagerQuery()
            {
                Id = request.ManagerId,
                CompanyId = request.AuthenticatorCompanyId
            };
            var manager = await queryExecutor.Execute(query);

            if(manager == null)
            {
                return new GetManagerByIdResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedManager = mapper.Map<ManagerDto>(manager);
            return new GetManagerByIdResponse
            {
                Data = mappedManager
            };
        }
    }
}
