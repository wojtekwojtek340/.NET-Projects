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
using TaskManager.DataAccess.CQRS.Queries.Assignments;
using TaskManager.DataAccess.CQRS.Queries.Boards;
using TaskManager.DataAccess.CQRS.Queries.Customers;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Assignments
{
    public class PutAssignmentByIdHandler : IRequestHandler<PutAssignmentByIdRequest, PutAssignmentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutAssignmentByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<PutAssignmentByIdResponse> Handle(PutAssignmentByIdRequest request, CancellationToken cancellationToken)
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
            var query3 = new GetAssignmentQuery()
            {
                Id = request.Id                
            };

            var board = await queryExecutor.Execute(query);
            var customer = await queryExecutor.Execute(query2);
            var assignment = await queryExecutor.Execute(query3);

            if (board == null || customer == null || assignment == null)
            {
                return new PutAssignmentByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var updateAssignment = mapper.Map<Assignment>(request);
            var command = new PutAssignmentCommand
            {
                Parameter = updateAssignment
            };
            var updatedAssignment = await commandExecutor.Execute(command);
            var response = mapper.Map<AssignmentDto>(updatedAssignment);

            return new PutAssignmentByIdResponse
            {
                Data = response  
            };
        }
    }
}
