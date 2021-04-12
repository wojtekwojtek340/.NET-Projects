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
        Task<Assignment> Add(Assignment assignment);
        Task<Assignment> Update(Assignment assignment);
        Task<Assignment> GetById(int id);
        Task<bool> Delete(int id);
    }
}
