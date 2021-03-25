namespace BlazorApp.Services
{
    using System.Threading.Tasks;
    using BlazorApp.Models;
    using static BlazorApp.Pages.Login;

    public interface IAuthenticationService
    {
        User User { get; }
        Task Initialize();
        Task Login(string username, string password, RoleType roleType);
        Task Logout();
    }
}