using BlazorApp.Models;
using BlazorApp.Services.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services.Managers
{
    public class ManagerService : IManagerService
    {
        private readonly IHttpService _httpService;

        public ManagerService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Manager> GetById(int id)
        {
            return await _httpService.Get<Manager>($"/Managers/{id}");
        }

        public async Task<Manager> Update(Manager manager)
        {
            var result = await _httpService.Put<Manager>("/Managers", manager);
            return result;
        }
    }
}
