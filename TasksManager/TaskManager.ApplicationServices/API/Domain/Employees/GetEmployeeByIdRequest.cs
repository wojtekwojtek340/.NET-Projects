﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Employees
{
    public class GetEmployeeByIdRequest : RequestBase, IRequest<GetEmployeeByIdResponse>
    {
        public int EmployeeId { get; set; }
    }
}
