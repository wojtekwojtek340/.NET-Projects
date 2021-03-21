using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Comments;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;
using TaskManager.ApplicationServices.API.Domain.Managers;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries.Comments;

namespace TaskManager.ApplicationServices.API.Handlers.Comments
{
    public class GetCommentByIdHandler : IRequestHandler<GetCommentByIdRequest, GetCommentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetCommentByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetCommentByIdResponse> Handle(GetCommentByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticatorRole == AppRole.Employee)
            {
                return new GetCommentByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetCommentQuery()
            {
                CompanyId = request.AuthenticatorCompanyId,
                Id = request.CommentId
            };
            var comment = await queryExecutor.Execute(query);

            if(comment == null)
            {
                return new GetCommentByIdResponse
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedComment = mapper.Map<CommentDto>(comment);
            return new GetCommentByIdResponse
            {
                Data = mappedComment
            };
        }
    }
}
