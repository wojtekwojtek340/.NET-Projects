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
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Comments;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Comments
{
    public class PutCommentByIdHandler : IRequestHandler<PutCommentByIdRequest, PutCommentByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public PutCommentByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<PutCommentByIdResponse> Handle(PutCommentByIdRequest request, CancellationToken cancellationToken)
        {
            var comment = mapper.Map<Comment>(request);
            var command = new PutCommentCommand
            {
                Parameter = comment
            };
            var updatedComment = await commandExecutor.Execute(command);
            var response = mapper.Map<CommentDto>(updatedComment);
            return new PutCommentByIdResponse
            {
                Data = response
            };
        }
    }
}
