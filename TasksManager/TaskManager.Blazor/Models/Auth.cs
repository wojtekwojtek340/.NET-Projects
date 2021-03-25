using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public enum RoleType
    {
        Manager,
        Employee
    }
    public class Auth
    {
        public string AuthData { get; set; }
        public RoleType RoleType { get; set; }
    }
}
