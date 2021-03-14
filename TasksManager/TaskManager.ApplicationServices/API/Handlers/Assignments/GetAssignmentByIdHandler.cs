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
using TaskManager.DataAccess;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries.Assignments;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Assignments
{
    public class GetAssignmentByIdHandler : IRequestHandler<GetAssignmentByIdRequest, GetAssignmentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAssignmentByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAssignmentByIdResponse> Handle(GetAssignmentByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAssignmentQuery()
            {
                Id = request.AssignmentId
            };
            var assignment = await queryExecutor.Execute(query);
            
            if(assignment == null)
            {
                return new GetAssignmentByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedAssignment = mapper.Map<AssignmentDto>(assignment);
            return new GetAssignmentByIdResponse()
            {
                Data = mappedAssignment
            };
        }
    }
}
