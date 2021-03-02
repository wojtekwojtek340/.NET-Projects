using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Managers
{
    public class GetManagerByIdRequest : IRequest<GetManagerByIdResponse>
    {
        public int ManagerId { get; set; }
    }
}
