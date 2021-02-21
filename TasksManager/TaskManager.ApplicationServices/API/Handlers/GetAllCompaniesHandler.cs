using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.API.Domain;
using TaskManager.ApplicationServices.API.Domain.Models;
using TaskManager.DataAccess;

namespace TaskManager.ApplicationServices.API.Handlers
{
    public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesRequest, GetAllCompaniesResponse>
    {
        private readonly IRepository<DataAccess.Entities.Company> companyRepository;
        private readonly IMapper mapper;

        public GetAllCompaniesHandler(IRepository<DataAccess.Entities.Company> companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }
        public Task<GetAllCompaniesResponse> Handle(GetAllCompaniesRequest request, CancellationToken cancellationToken)
        {
            var companies = this.companyRepository.GetAll();

            var domainCompanies = mapper.Map<IEnumerable<CompanyDto>>(companies);

            var response = new GetAllCompaniesResponse()
            { 
                Data = domainCompanies.ToList()
            };
       

            return Task.FromResult(response);
        }
    }
}
