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
using TaskManager.DataAccess.CQRS.Commands.Managers;
using TaskManager.DataAccess.CQRS.Queries.Managers;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Managers
{
    public class PutManagerByIdHandler : IRequestHandler<PutManagerByIdRequest, PutManagerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutManagerByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<PutManagerByIdResponse> Handle(PutManagerByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticatorRole == AppRole.Employee)
            {
                return new PutManagerByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetManagerQuery()
            { 
                Id = request.Id,
                CompanyId = request.AuthenticatorCompanyId                
            };

            var manager = await queryExecutor.Execute(query);

            if (request.Login == null || request.Password == null)
            {
                request.Login = manager.Login;
                request.Password = manager.Password;
                request.Salt = manager.Salt;
            }

            if (manager == null)
            {
                return new PutManagerByIdResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var updateManager = mapper.Map<Manager>(request);
            var command = new PutManagerCommand
            {
                Parameter = updateManager
            };
            var updatedManager = await commandExecutor.Execute(command);

            var response = mapper.Map<ManagerDto>(updatedManager);
            return new PutManagerByIdResponse
            {
                Data = response
            };
        }
    }
}
