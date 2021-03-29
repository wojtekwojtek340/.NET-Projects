using BlazorApp.Helpers;
using BlazorApp.Models;
using BlazorApp.Services.Http;
using BlazorApp.Services.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

using static BlazorApp.Pages.Login;

namespace BlazorApp.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public AuthenticationService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public Auth Auth { get; private set; }

        public async Task Login(string username, string password, RoleType roleType)
        {
            Auth = new Auth();
            Auth.AuthData = $"{username}:{password}".EncodeBase64();
            Auth.RoleType = roleType;
            await _localStorageService.SetItem("auth", Auth);

            if (Auth.RoleType == RoleType.Manager)
            {
                Manager manager = await _httpService.Get<Manager>("/users/Me");
                await _localStorageService.SetItem("user", manager);
            }
            else if(Auth.RoleType == RoleType.Employee)
            {
                Employee manager = await _httpService.Get<Employee>("/users/Me");
                await _localStorageService.SetItem("user", manager);
            }        
        }

        public async Task Logout()
        {
            Auth = null;
            await _localStorageService.RemoveItem("user");
            await _localStorageService.RemoveItem("auth");
            _navigationManager.NavigateTo("login");
        }

        public async Task Register(string username, string password)
        {
            UserData userData = new UserData();
            userData.Login = username;
            userData.Password = password;
            userData.Name = "domyslny";
            userData.Surname = "domyslny";
            await _httpService.Post<UserData>("/Managers", userData);
        }
    }
}