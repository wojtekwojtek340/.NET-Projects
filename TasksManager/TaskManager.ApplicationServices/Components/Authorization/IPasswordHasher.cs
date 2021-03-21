using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.ApplicationServices.Components.Authorization
{
    public interface IPasswordHasher
    {
        public string Hash(string password);
    }
}
