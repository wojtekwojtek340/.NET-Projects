﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;

namespace TasksManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployesController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public EmployesController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllEmployes([FromQuery] GetAllEmployesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}