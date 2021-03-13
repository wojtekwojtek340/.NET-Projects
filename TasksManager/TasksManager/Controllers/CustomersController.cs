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
    public class CustomersController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCustomers([FromQuery] GetAllCustomersRequest request)
        {
            var response = await mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{CustomerId}")]

        public async Task<IActionResult> GetCustomerById([FromRoute] GetCustomerByIdRequest request)
        {           
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCustomer([FromQuery] AddCustomerRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{CustomerId}")]

        public async Task<IActionResult> DeleteCustomerById([FromRoute] DeleteCustomerByIdRequest request)
        {           
            var response = await mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutCustomerById([FromQuery] PutCustomerByIdRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
