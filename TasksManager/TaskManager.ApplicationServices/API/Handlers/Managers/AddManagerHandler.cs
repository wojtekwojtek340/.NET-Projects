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
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Managers;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Managers
{
    class AddManagerHandler : IRequestHandler<AddManagerRequest, AddManagerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddManagerHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddManagerResponse> Handle(AddManagerRequest request, CancellationToken cancellationToken)
        {
            var manager = mapper.Map<Manager>(request);
            var command = new AddManagerCommand() { Parameter = manager };
            var managerFromDb = await commandExecutor.Execute(command);
            return new AddManagerResponse()
            {
                Data = mapper.Map<ManagerDto>(managerFromDb)
            };
        }
    }
}
