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
using TaskManager.DataAccess.CQRS.Queries.Employees;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Boards
{
    public class AddBoardHandler : IRequestHandler<AddBoardRequest, AddBoardResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public AddBoardHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddBoardResponse> Handle(AddBoardRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticatorRole == AppRole.Employee)
            {
                return new AddBoardResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetEmployeeQuery()
            {
                Id = request.EmployeeId
            };

            var employee = await queryExecutor.Execute(query);

            if(employee == null)
            {
                return new AddBoardResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            if(employee.Board != null)
            {
                return new AddBoardResponse()
                {
                    Error = new ErrorModel(ErrorType.UnsupportedMethod)
                };
            }

            var board = mapper.Map<Board>(request);
            var command = new AddBoardCommand() { Parameter = board };
            var boardFromDb = await commandExecutor.Execute(command);
            return new AddBoardResponse()
            {
                Data = mapper.Map<BoardDto>(boardFromDb)
            };
        }
    }
}
