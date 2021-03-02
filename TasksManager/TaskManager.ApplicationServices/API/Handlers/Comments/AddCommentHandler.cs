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
    public class AddCommentHandler : IRequestHandler<AddCommentRequest, AddCommentResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddCommentHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddCommentResponse> Handle(AddCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = mapper.Map<Comment>(request);
            var command = new AddCommentCommand() { Parameter = comment };
            var commentFromDb = await commandExecutor.Execute(command);
            return new AddCommentResponse()
            {
                Data = mapper.Map<CommentDto>(commentFromDb)
            };
        }
    }
}
