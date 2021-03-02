using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Boards;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Boards;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Boards
{
    public class AddBoardHandler : IRequestHandler<AddBoardRequest, AddBoardResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddBoardHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddBoardResponse> Handle(AddBoardRequest request, CancellationToken cancellationToken)
        {
            var board = mapper.Map<Board>(request);
            var command = new AddBoardCommand() { Parameter = board };
            var boardFromDb = await commandExecutor.Execute(command);
            return new AddBoardResponse()
            {
                Data = mapper.Map<BoardsDto>(boardFromDb)
            };
        }
    }
}
