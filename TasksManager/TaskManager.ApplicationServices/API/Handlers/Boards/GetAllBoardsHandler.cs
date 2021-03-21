using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Boards;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries.Boards;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Boards
{
    public class GetAllBoardsHandler : IRequestHandler<GetAllBoardsRequest, GetAllBoardsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllBoardsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetAllBoardsResponse> Handle(GetAllBoardsRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticatorRole == AppRole.Employee)
            {
                return new GetAllBoardsResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetBoardsQuery();
            var boards = await queryExecutor.Execute(query);
            var mappedBoards = mapper.Map<List<BoardDto>>(boards);
            return  new GetAllBoardsResponse()
            {
                Data = mappedBoards
            };

        }
    }
}
