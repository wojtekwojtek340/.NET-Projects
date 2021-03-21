using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Customers
{
    public class DeleteCustomerByIdRequest : RequestBase, IRequest<DeleteCustomerByIdResponse>
    {
        public int CustomerId { get; set; }
    }
}
