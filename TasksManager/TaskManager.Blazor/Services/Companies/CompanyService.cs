using BlazorApp.Models;
using BlazorApp.Services.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly IHttpService _httpService;

        public CompanyService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _httpService.Get<IEnumerable<Company>>("/Companies");
        }
    }
}
