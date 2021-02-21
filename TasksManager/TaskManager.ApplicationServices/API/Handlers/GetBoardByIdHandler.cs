using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;

namespace TaskManager.ApplicationServices.API.Handlers
{
    public class GetBoardByIdHandler : IRequestHandler<GetBoardByIdRequest, GetBoardByIdResponse>
    {
        public Task<GetBoardByIdResponse> Handle(GetBoardByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
