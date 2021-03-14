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
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Managers;
using TaskManager.DataAccess.CQRS.Queries.Managers;

namespace TaskManager.ApplicationServices.API.Handlers.Managers
{
    public class DeleteManagerByIdHandler : IRequestHandler<DeleteManagerByIdRequest, DeleteManagerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteManagerByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteManagerByIdResponse> Handle(DeleteManagerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetManagerQuery() { Id = request.ManagerId };
            var manager = await queryExecutor.Execute(query);

            if(manager == null)
            {
                return new DeleteManagerByIdResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteManagerCommand() { Parameter = manager };
            var deletedManager = await commandExecutor.Execute(command);

            return new DeleteManagerByIdResponse
            {
                Data = deletedManager
            };
        }
    }
}
