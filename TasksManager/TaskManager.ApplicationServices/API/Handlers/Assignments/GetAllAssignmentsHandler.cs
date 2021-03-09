using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Assignments;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries.Assignments;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Assignments
{
    public class GetAllAssignmentsHandler : IRequestHandler<GetAllAssignmentsRequest, GetAllAssignmentsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllAssignmentsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllAssignmentsResponse> Handle(GetAllAssignmentsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAssignmentsQuery()
            {
                customerId = request.customerId
            };
            var assignments = await queryExecutor.Execute(query);
            var mappedAssignments = mapper.Map<List<AssignmentDto>>(assignments);
            return new GetAllAssignmentsResponse()
            {
                Data = mappedAssignments
            };
        }
    }
}