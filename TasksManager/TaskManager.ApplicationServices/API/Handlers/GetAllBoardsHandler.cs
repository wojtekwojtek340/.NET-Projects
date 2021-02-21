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
    class GetAllBoardsHandler : IRequestHandler<GetAllBoardsRequest, GetAllBoardsResponse>
    {
        private readonly IRepository<Board> boardsRepository;
        private readonly IMapper mapper;

        public GetAllBoardsHandler(IRepository<DataAccess.Entities.Board> boardsRepository, IMapper mapper)
        {
            this.boardsRepository = boardsRepository;
            this.mapper = mapper;
        }

        public Task<GetAllBoardsResponse> Handle(GetAllBoardsRequest request, CancellationToken cancellationToken)
        {
            var boards = boardsRepository.GetAll();

            var domainBoards = mapper.Map<IEnumerable<BoardDto>>(boards);

            var response = new GetAllBoardsResponse()
            {
                Data = domainBoards.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
