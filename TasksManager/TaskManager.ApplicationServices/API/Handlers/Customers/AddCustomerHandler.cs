﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Customers;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Customers;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Customers
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerRequest, AddCustomerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddCustomerHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddCustomerResponse> Handle(AddCustomerRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticatorRole == AppRole.Employee)
            {
                return new AddCustomerResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var customer = mapper.Map<Customer>(request);
            var command = new AddCustomerCommand() { Parameter = customer };
            var customerFromDb = await commandExecutor.Execute(command);
            return new AddCustomerResponse()
            {
                Data = mapper.Map<CustomerDto>(customerFromDb)
            };
        }
    }
}
