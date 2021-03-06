﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Domain.Customers
{
    public class AddCustomerRequest : RequestBase, IRequest<AddCustomerResponse>
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }

        //public List<Assignment> AssignmentList { get; set; }
    }
}
