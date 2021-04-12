using BlazorApp.Models;
using BlazorApp.Services.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services.Assignments
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IHttpService _httpService;

        public AssignmentService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Assignment> Add(Assignment assignment)
        {
            return await _httpService.Post<Assignment>("/Assignments", assignment);
        }

        public async Task<bool> Delete(int id)
        {
            await _httpService.Delete($"/Assignments/{id}");
            return true;
        }

        public async Task<IEnumerable<Assignment>> GetAll()
        {
            return await _httpService.Get<IEnumerable<Assignment>>("/Assignments");
        }

        public async Task<Assignment> GetById(int id)
        {
            return await _httpService.Get<Assignment>($"/Assignments/{id}");
        }

        public async Task<Assignment> Update(Assignment assignment)
        {
            var result = await _httpService.Put<Assignment>("/Assignments", assignment);
            return result;
        }
    }
}
