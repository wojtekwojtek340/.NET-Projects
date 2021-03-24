namespace BlazorApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public object Company { get; set; }
        public object Board { get; set; }

        public string AuthData { get; set; }
    }
}