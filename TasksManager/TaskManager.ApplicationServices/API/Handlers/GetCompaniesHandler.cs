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
    public class GetCompaniesHandler : IRequestHandler<GetCompaniesRequest, GetCompaniesResponse>
    {
        private readonly IRepository<DataAccess.Entities.Company> companyRepository;

        public GetCompaniesHandler(IRepository<DataAccess.Entities.Company> companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        public Task<GetCompaniesResponse> Handle(GetCompaniesRequest request, CancellationToken cancellationToken)
        {
            var companies = this.companyRepository.GetAll();

            var domainCompanies = companies.Select(x => new Domain.Models.Company()
            {
                Id = x.Id,
                Description = x.Description
            });

            var response = new GetCompaniesResponse()
            { 
                Data = domainCompanies.ToList()
            };
       

            return Task.FromResult(response);
        }
    }
}
