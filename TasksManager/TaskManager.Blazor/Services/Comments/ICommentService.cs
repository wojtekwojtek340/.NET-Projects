using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services.Comments
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetAll();
        Task<Comment> Add(Comment comment);
        Task<bool> Delete(int id);
        Task<Comment> Update(Comment comment);
        Task<Comment> GetById(int id);
    }
}
