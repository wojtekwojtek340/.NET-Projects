using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.API.Domain
{
    public class RequestBase
    {
        public int AuthenticatorId { get; set; }
        public string AuthenticatorName { get; set; }
        public string AuthenticatorRole { get; set; }

    }
}
