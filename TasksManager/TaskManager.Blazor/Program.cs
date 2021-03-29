using BlazorApp.Helpers;
using BlazorApp.Services;
using BlazorApp.Services.Authentication;
using BlazorApp.Services.Employees;
using BlazorApp.Services.Http;
using BlazorApp.Services.LocalStorage;
using BlazorApp.Services.User;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IBookCasesService, BookCasesService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IEmployeeService, EmployeeService>();

            // configure http client
            builder.Services.AddScoped(x =>
            {
                var apiUrl = new Uri(builder.Configuration["apiUrl"]);
                return new HttpClient() { BaseAddress = apiUrl };
            });

            var host = builder.Build();
            var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
            await host.RunAsync();
        }
    }
}