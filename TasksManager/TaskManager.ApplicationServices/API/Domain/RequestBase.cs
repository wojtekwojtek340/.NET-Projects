using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain
{
    public enum AppRole
    {
        Manager,
        Employee
    }
    public class RequestBase
    {
        public int AuthenticatorId { get; set; }
        public int AuthenticatorCompanyId { get; set; }
        public string AuthenticatorName { get; set; }
        public AppRole AuthenticatorRole { get; set; }

    }
}
