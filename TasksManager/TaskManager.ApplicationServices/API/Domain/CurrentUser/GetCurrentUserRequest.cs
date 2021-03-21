using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.CurrentUser
{
    public class GetCurrentUserRequest : RequestBase, IRequest<GetCurrentUserResponse>
    {
        public string Me { get; set; }
    }
}
