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
    class GetAllCommentsHandler : IRequestHandler<GetAllCommentsRequest, GetAllCommentsResponse>
    {
        private readonly IRepository<Comment> commentsRepository;
        private readonly IMapper mapper;

        public GetAllCommentsHandler(IRepository<DataAccess.Entities.Comment> commentsRepository, IMapper mapper)
        {
            this.commentsRepository = commentsRepository;
            this.mapper = mapper;
        }
        public Task<GetAllCommentsResponse> Handle(GetAllCommentsRequest request, CancellationToken cancellationToken)
        {
            var comments = commentsRepository.GetAll();

            var domainComents = mapper.Map<IEnumerable<CommentDto>>(comments);

            var response = new GetAllCommentsResponse()
            {
                Data = domainComents.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
