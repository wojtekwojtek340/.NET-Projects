﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Boards
{
    public class GetBoardByIdRequest : RequestBase, IRequest<GetBoardByIdResponse>
    {
        public int BoardId { get; set; }
    }
}
