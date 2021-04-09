using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services.Managers
{
    interface IManagerService
    {
        Task<Manager> Update(Manager manager);
        Task<Manager> GetById(int id);
    }
}
