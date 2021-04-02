using BlazorApp.Models;
using BlazorApp.Services.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services.User
{
    public class UserService : IUserService
    {
        private readonly IHttpService _httpService;

        public UserService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<UserData> GetById(int id)
        {
            return await _httpService.Get<UserData>($"/users/{id}");
        }

        public async Task<UserData> GetMe()
        {
            return await _httpService.Get<UserData>("/users/me");
        }
    }
}
