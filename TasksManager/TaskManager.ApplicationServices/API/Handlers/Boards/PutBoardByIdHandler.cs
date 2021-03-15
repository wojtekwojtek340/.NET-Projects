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
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Boards;
using TaskManager.DataAccess.CQRS.Queries.Boards;
using TaskManager.DataAccess.CQRS.Queries.Employees;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Boards
{
    public class PutBoardByIdHandler : IRequestHandler<PutBoardByIdRequest, PutBoardByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutBoardByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<PutBoardByIdResponse> Handle(PutBoardByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBoardQuery()
            {
                Id = request.Id                       
            };
            var query2 = new GetEmployeeQuery()
            {
                Id = request.EmployeeId
            };
            var board = await queryExecutor.Execute(query);
            var employee = await queryExecutor.Execute(query2);

            if(board == null || employee == null)
            {
                return new PutBoardByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var updateBoard = mapper.Map<Board>(request);
            var command = new PutBoardCommand
            {
                Parameter = updateBoard
            };
            var updatedBoard = await commandExecutor.Execute(command);
            var response = mapper.Map<BoardDto>(updatedBoard);
            return new PutBoardByIdResponse
            {
                Data = response
            };
        }
    }
}
