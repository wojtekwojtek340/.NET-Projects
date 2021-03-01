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
using TaskManager.DataAccess;
using TaskManager.DataAccess.CQRS;
using TaskManager.DataAccess.CQRS.Queries.Companies;

namespace TaskManager.ApplicationServices.API.Handlers.Companies
{
    public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesRequest, GetAllCompaniesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllCompaniesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllCompaniesResponse> Handle(GetAllCompaniesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCompaniesQuery();
            var companies = await queryExecutor.Execute(query);
            var mappedCompanies = mapper.Map<List<CompaniesDto>>(companies);
            var response = new GetAllCompaniesResponse()
            { 
                Data = mappedCompanies
            };    
            return response;
        }
    }
}
