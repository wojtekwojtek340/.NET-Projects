using BlazorApp.Models;
using BlazorApp.Services.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IHttpService _httpService;

        public CommentService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Comment> Add(Comment comment)
        {
            var result = await _httpService.Post<Comment>("/Comments", comment);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            await _httpService.Delete($"/Comments/{id}");
            return true;
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _httpService.Get<IEnumerable<Comment>>("/Comments");
        }

        public async Task<Comment> GetById(int id)
        {
            return await _httpService.Get<Comment>($"/Comments/{id}");
        }

        public async Task<Comment> Update(Comment comment)
        {
            var result = await _httpService.Put<Comment>("/Comments", comment);
            return result;
        }
    }
}
