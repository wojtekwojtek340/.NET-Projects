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
using TaskManager.ApplicationServices.Components.Authorization;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Managers;
using TaskManager.DataAccess.CQRS.Queries;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Managers
{
    class AddManagerHandler : IRequestHandler<AddManagerRequest, AddManagerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;
        private readonly IPasswordHasher passwordHasher;

        public AddManagerHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IPasswordHasher passwordHasher)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
            this.passwordHasher = passwordHasher;
        }

        public async Task<AddManagerResponse> Handle(AddManagerRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery<Manager>()
            {
                Login = request.Login
            };
            var availableManager = await queryExecutor.Execute(query);

            if(availableManager != null)
            {
                return new AddManagerResponse()
                {
                    Error = new ErrorModel(ErrorType.Conflict)
                };
            }

            request.Password = passwordHasher.Hash(request.Password);
            var manager = mapper.Map<Manager>(request);
            
            if(manager.Company == null)
            {
                Company company = new Company();
                company.Description = "BasicCompany";
                company.Manager = manager;
                manager.Company = company;
            }

            var command = new AddManagerCommand() { Parameter = manager };
            var managerFromDb = await commandExecutor.Execute(command);

            return new AddManagerResponse()
            {
                Data = mapper.Map<ManagerDto>(managerFromDb)
            };
        }
    }
}
