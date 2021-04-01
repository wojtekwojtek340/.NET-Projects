using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services.Assignments
{
    public interface IAssignmentService
    {
        public Task<IEnumerable<Assignment>> GetAll();
    }
}
