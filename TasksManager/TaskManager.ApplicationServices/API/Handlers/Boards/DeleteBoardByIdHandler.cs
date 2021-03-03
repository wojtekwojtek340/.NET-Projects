using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Boards;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Boards;

namespace TaskManager.ApplicationServices.API.Handlers.Boards
{
    public class DeleteBoardByIdHandler : IRequestHandler<DeleteBoardByIdRequest, DeleteBoardByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteBoardByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteBoardByIdResponse> Handle(DeleteBoardByIdRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteBoardCommand() { Parameter = request.BoardId };
            var deletedBoard = await commandExecutor.Execute(command);
            return new DeleteBoardByIdResponse
            {
                Data = deletedBoard
            };
        }
    }
}
