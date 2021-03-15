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
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries.Boards;

namespace TaskManager.ApplicationServices.API.Handlers.Boards
{
    public class GetBoardByIdHandler : IRequestHandler<GetBoardByIdRequest, GetBoardByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetBoardByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetBoardByIdResponse> Handle(GetBoardByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBoardQuery()
            {
                Id = request.BoardId
            };
            var board = await queryExecutor.Execute(query);

            if(board == null)
            {
                return new GetBoardByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedBoard = mapper.Map<BoardDto>(board);
            return new GetBoardByIdResponse()
            {
                Data = mappedBoard
            };          
        }
    }
}
