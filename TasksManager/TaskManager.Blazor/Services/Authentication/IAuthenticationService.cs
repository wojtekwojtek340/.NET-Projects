namespace BlazorApp.Services.Authentication
{
    using System.Threading.Tasks;
    using BlazorApp.Models;
    using static BlazorApp.Pages.Login;

    public interface IAuthenticationService
    {
        Auth Auth { get; }
        Task Login(string username, string password, RoleType roleType);
        Task Register(string username, string password);
        Task Logout();
    }
}