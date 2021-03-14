using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Companies;
using TaskManager.ApplicationServices.API.Domain.ErrorHandling;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Companies;
using TaskManager.DataAccess.CQRS.Queries.Managers;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Companies
{
    public class AddCompanyHandler : IRequestHandler<AddCompanyRequest, AddCompanyResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public AddCompanyHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddCompanyResponse> Handle(AddCompanyRequest request, CancellationToken cancellationToken)
        {
            var query = new GetManagerQuery() { Id = request.ManagerId };
            var manager = await queryExecutor.Execute(query);
            
            if(manager == null)
            {
                return new AddCompanyResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var company = mapper.Map<Company>(request);
            company.Manager = manager;
            var command = new AddCompanyCommand() { Parameter = company };
            var companyFromDb = await commandExecutor.Execute(command);
            return new AddCompanyResponse()
            {
                Data = mapper.Map<CompanyDto>(companyFromDb)
            };
        }
    }
}
