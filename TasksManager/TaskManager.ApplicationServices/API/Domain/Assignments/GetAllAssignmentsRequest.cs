﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Assignments
{
    public class GetAllAssignmentsRequest : RequestBase, IRequest<GetAllAssignmentsResponse>
    {
        public int? customerId { get; set; }
    }
}
