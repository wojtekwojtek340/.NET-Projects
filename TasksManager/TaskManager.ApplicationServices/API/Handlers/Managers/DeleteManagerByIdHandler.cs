using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Managers;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Managers;

namespace TaskManager.ApplicationServices.API.Handlers.Managers
{
    public class DeleteManagerByIdHandler : IRequestHandler<DeleteManagerByIdRequest, DeleteManagerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteManagerByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteManagerByIdResponse> Handle(DeleteManagerByIdRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteManagerCommand() { Parameter = request.ManagerId };
            var deletedManager = await commandExecutor.Execute(command);
            return new DeleteManagerByIdResponse
            {
                Data = deletedManager
            };
        }
    }
}
