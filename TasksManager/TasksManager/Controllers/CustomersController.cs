using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Customers;

namespace TasksManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ApiControllerBase
    {
        public CustomersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllCustomers([FromQuery] GetAllCustomersRequest request)
        {
            return this.HandleRequest<GetAllCustomersRequest, GetAllCustomersResponse>(request);
        }

        [HttpGet]
        [Route("{CustomerId}")]

        public Task<IActionResult> GetCustomerById([FromRoute] GetCustomerByIdRequest request)
        {
            return this.HandleRequest<GetCustomerByIdRequest, GetCustomerByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddCustomer([FromQuery] AddCustomerRequest request)
        {
            return this.HandleRequest<AddCustomerRequest, AddCustomerResponse>(request);
        }

        [HttpDelete]
        [Route("{CustomerId}")]

        public Task<IActionResult> DeleteCustomerById([FromRoute] DeleteCustomerByIdRequest request)
        {
            return this.HandleRequest<DeleteCustomerByIdRequest, DeleteCustomerByIdResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> PutCustomerById([FromQuery] PutCustomerByIdRequest request)
        {
            return this.HandleRequest<PutCustomerByIdRequest, PutCustomerByIdResponse>(request);
        }
    }
}
