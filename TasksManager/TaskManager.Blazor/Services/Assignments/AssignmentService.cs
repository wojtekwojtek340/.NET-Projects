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

        public async Task<IEnumerable<Assignment>> GetAll()
        {
            return await _httpService.Get<IEnumerable<Assignment>>("/Assignments");
        }
    }
}
