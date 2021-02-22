using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers
{
    public class GetAllAssignmentsHandler : IRequestHandler<GetAllAssignmentsRequest, GetAllAssignmentsResponse>
    {
        private readonly IRepository<Assignment> assignmentRepository;
        private readonly IMapper mapper;

        public GetAllAssignmentsHandler(IRepository<DataAccess.Entities.Assignment> assignmentRepository, IMapper mapper)
        {
            this.assignmentRepository = assignmentRepository;
            this.mapper = mapper;
        }
        public Task<GetAllAssignmentsResponse> Handle(GetAllAssignmentsRequest request, CancellationToken cancellationToken)
        {
            var assignment = assignmentRepository.GetAll();           

            var domainAssignments = mapper.Map<IEnumerable<AssignmentDto>>(assignment);

            var response = new GetAllAssignmentsResponse()
            {
                Data = domainAssignments.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
