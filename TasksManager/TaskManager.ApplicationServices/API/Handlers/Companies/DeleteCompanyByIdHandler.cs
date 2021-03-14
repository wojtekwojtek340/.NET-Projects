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
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Companies;
using TaskManager.DataAccess.CQRS.Queries.Companies;

namespace TaskManager.ApplicationServices.API.Handlers.Companies
{
    public class DeleteCompanyByIdHandler : IRequestHandler<DeleteCompanyByIdRequest, DeleteCompanyByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteCompanyByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteCompanyByIdResponse> Handle(DeleteCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCompanyQuery() { Id = request.CompanyId };
            var company = await queryExecutor.Execute(query);

            if (company == null)
            {
                return new DeleteCompanyByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var command = new DeleteCompanyCommand() { Parameter = company };
            var deletedCompany = await commandExecutor.Execute(command);
            return new DeleteCompanyByIdResponse
            {
                Data = deletedCompany
            };
        }
    }
}
