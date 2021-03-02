using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain.Customers
{
    public class GetCustomerByIdRequest : IRequest<GetCustomerByIdResponse>
    {
        public int CustomerId { get; set; }
    }
}
