using BlazorApp.Helpers;
using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using static BlazorApp.Pages.Login;

namespace BlazorApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public User User { get; private set; }
        public Auth Auth { get; private set; }

        public AuthenticationService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<User>("user");
        }

        public async Task Login(string username, string password, RoleType roleType)
        {
            Auth = new Auth();
            Auth.AuthData = $"{username}:{password}".EncodeBase64();
            Auth.RoleType = roleType;

            await _localStorageService.SetItem("auth", Auth);            
            User = await _httpService.Get<User>("/users/Me");            
            await _localStorageService.SetItem("user", User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem("user");
            _navigationManager.NavigateTo("login");
        }

        public async Task Register(string username, string password)
        {
            Manager manager = new Manager();
            manager.Login = username;
            manager.Password = password;
            manager.Name = "domyslny";
            manager.Surname = "domyslny";
            var test = await _httpService.Post<Manager>("/Managers", manager);
        }
    }
}