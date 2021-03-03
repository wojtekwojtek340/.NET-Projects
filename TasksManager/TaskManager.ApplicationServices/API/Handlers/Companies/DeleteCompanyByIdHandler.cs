using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain.Companies;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Commands.Companies;

namespace TaskManager.ApplicationServices.API.Handlers.Companies
{
    public class DeleteCompanyByIdHandler : IRequestHandler<DeleteCompanyByIdRequest, DeleteCompanyByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public DeleteCompanyByIdHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<DeleteCompanyByIdResponse> Handle(DeleteCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteCompanyCommand() { Parameter = request.CompanyId };
            var deletedCompany = await commandExecutor.Execute(command);
            return new DeleteCompanyByIdResponse
            {
                Data = deletedCompany
            };
        }
    }
}
