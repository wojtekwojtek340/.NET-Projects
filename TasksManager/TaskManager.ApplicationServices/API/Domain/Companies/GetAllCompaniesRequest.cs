﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Companies
{
    public class GetAllCompaniesRequest : RequestBase, IRequest<GetAllCompaniesResponse>
    {
    }
}
