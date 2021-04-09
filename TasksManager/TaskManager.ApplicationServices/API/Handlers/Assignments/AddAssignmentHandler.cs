using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Assignments;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Assignments;
using TaskManager.DataAccess.CQRS.Queries.Boards;
using TaskManager.DataAccess.CQRS.Queries.Customers;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Assignments
{
    public class AddAssignmentHandler : IRequestHandler<AddAssignmentRequest, AddAssignmentResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public AddAssignmentHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddAssignmentResponse> Handle(AddAssignmentRequest request, CancellationToken cancellationToken)
        {            

            var query = new GetBoardQuery()
            {
                Id = request.BoardId
            };
            var query2 = new GetCustomerQuery()
            {
                Id = request.CustomerId,
                CompanyId = request.AuthenticatorCompanyId
                
            };

            var board = await queryExecutor.Execute(query);
            var customer = await queryExecutor.Execute(query2);

            if(board == null || customer == null)
            {
                return new AddAssignmentResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var assignment = mapper.Map<Assignment>(request);
            var command = new AddAssignmentCommand() { Parameter = assignment };
            var assignmentFromDb = await this.commandExecutor.Execute(command);
            assignmentFromDb.Board.AssignmentList = null;
            assignmentFromDb.Customer.AssignmentList = null;
            return new AddAssignmentResponse()
            {
                Data = mapper.Map<AssignmentDto>(assignmentFromDb)
            };
        }
    }
}
