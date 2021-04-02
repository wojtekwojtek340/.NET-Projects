using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Managers
{
    public class PutManagerByIdRequest : RequestBase, IRequest<PutManagerByIdResponse>
    {
        public int Id { get; set; }
        public string Login { get; set; } 
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
