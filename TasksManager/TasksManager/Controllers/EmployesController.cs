﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Employees;

namespace TasksManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployesController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllEmployes([FromQuery] GetAllEmployeesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddEmployee([FromQuery] AddEmployeeRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
