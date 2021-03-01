using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Comments;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries.Comments;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Comments
{
    public class GetAllCommentsHandler : IRequestHandler<GetAllCommentsRequest, GetAllCommentsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllCommentsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllCommentsResponse> Handle(GetAllCommentsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCommentsQuery();
            var comments = await queryExecutor.Execute(query);
            var mappedComments = mapper.Map<List<CommentsDto>>(comments);
            var response = new GetAllCommentsResponse()
            {
                Data = mappedComments
            };
            return response;
        }
    }
}
