using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Boards;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Boards;
using TaskManager.DataAccess.CQRS.Queries.Boards;

namespace TaskManager.ApplicationServices.API.Handlers.Boards
{
    public class DeleteBoardByIdHandler : IRequestHandler<DeleteBoardByIdRequest, DeleteBoardByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteBoardByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteBoardByIdResponse> Handle(DeleteBoardByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBoardQuery()
            {
                Id = request.BoardId
            };

            var board = await queryExecutor.Execute(query);

            if (board == null)
            {
                return new DeleteBoardByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteBoardCommand() { Parameter = board };
            var deletedBoard = await commandExecutor.Execute(command);
            return new DeleteBoardByIdResponse
            {
                Data = deletedBoard
            };
        }
    }
}
