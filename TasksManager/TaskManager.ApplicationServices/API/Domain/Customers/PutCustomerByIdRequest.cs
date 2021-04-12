using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Customers
{
    public class PutCustomerByIdRequest : RequestBase, IRequest<PutCustomerByIdResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string CustomerId { get; set; }
    }
}
