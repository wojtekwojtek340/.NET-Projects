using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Models;

namespace TaskManager.ApplicationServices.API.Domain.Companies
{
    public class PutCompanyByIdRequest : RequestBase, IRequest<PutCompanyByIdResponse>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ManagerId { get; set; }
    }
}
