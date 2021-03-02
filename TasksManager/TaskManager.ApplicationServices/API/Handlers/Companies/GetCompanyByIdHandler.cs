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
using TaskManager.DataAccess.CQRS.Queries.Companies;

namespace TaskManager.ApplicationServices.API.Handlers.Companies
{
    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdRequest, GetCompanyByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetCompanyByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetCompanyByIdResponse> Handle(GetCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCompanyQuery()
            {
                Id = request.CompanyId
            };
            var company = await queryExecutor.Execute(query);
            var mappedCompany = mapper.Map<CompanyDto>(company);
            return new GetCompanyByIdResponse
            {
                Data = mappedCompany
            };
        }
    }
}
