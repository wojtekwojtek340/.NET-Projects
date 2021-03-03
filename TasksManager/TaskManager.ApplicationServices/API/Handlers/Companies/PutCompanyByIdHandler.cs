using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Companies;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Companies;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Companies
{
    public class PutCompanyByIdHandler : IRequestHandler<PutCompanyByIdRequest, PutCompanyByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public PutCompanyByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<PutCompanyByIdResponse> Handle(PutCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            var company = mapper.Map<Company>(request);
            var command = new PutCompanyCommand
            {
                Parameter = company
            };
            var updatedCompany = await commandExecutor.Execute(command);
            var response = mapper.Map<CompanyDto>(updatedCompany);
            return new PutCompanyByIdResponse
            {
                Data = response
            };
        }
    }
}
