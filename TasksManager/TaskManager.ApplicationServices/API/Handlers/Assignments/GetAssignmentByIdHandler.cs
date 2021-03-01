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
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Assignments
{
    public class GetAssignmentByIdHandler : IRequestHandler<GetAssignmentByIdRequest, GetAssignmentByIdResponse>
    {
        private readonly IRepository<Assignment> assignmentRepository;
        private readonly IMapper mapper;

        public GetAssignmentByIdHandler(IRepository<DataAccess.Entities.Assignment> assignmentRepository, IMapper mapper)
        {
            this.assignmentRepository = assignmentRepository;
            this.mapper = mapper;
        }
        public async Task<GetAssignmentByIdResponse> Handle(GetAssignmentByIdRequest request, CancellationToken cancellationToken)
        {
            var assignment = await assignmentRepository.GetById(request.assignmentId);       
           
            var mappedAssignment = mapper.Map<AssignmentsDto>(assignment);

            var response = new GetAssignmentByIdResponse()
            {
                Data = mappedAssignment
            };

            return response;


        }
    }
}
