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
using TaskManager.DataAccess.CQRS.Queries.Companies;
using TaskManager.DataAccess.CQRS.Queries.Managers;
using TaskManager.DataAccess.Entities;

namespace TaskManager.ApplicationServices.API.Handlers.Companies
{
    public class PutCompanyByIdHandler : IRequestHandler<PutCompanyByIdRequest, PutCompanyByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutCompanyByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<PutCompanyByIdResponse> Handle(PutCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.AuthenticatorRole == AppRole.Employee)
            {
                return new PutCompanyByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.Unauthorized)
                };
            }

            var query = new GetCompanyQuery()
            {
                Id = request.Id
            };
            var query2 = new GetManagerQuery()
            {
                Id = request.ManagerId
            };

            var company = await queryExecutor.Execute(query);
            var manager = await queryExecutor.Execute(query2);

            if(company == null || manager == null)
            {
                return new PutCompanyByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var updateCompany = mapper.Map<Company>(request);
            var command = new PutCompanyCommand
            {
                Parameter = updateCompany
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
