namespace BlazorApp.Services
{
    using System.Threading.Tasks;

    public enum RoleType
    {
        Manager,
        Employee
    }
    public interface IHttpService
    {
        public string AuthData { get; set; }
        public RoleType RoleType { get; set; }
        Task<T> Get<T>(string uri);
        Task<T> Post<T>(string uri, object value);
        Task<T> Put<T>(string uri, object value);
        Task Delete(string uri);
    }
}