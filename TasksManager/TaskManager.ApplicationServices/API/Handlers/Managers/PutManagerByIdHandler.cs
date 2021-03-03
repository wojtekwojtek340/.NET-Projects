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
    public class PutManagerByIdHandler : IRequestHandler<PutManagerByIdRequest, PutManagerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public PutManagerByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<PutManagerByIdResponse> Handle(PutManagerByIdRequest request, CancellationToken cancellationToken)
        {
            var manager = mapper.Map<Manager>(request);
            var command = new PutManagerCommand
            {
                Parameter = manager
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
