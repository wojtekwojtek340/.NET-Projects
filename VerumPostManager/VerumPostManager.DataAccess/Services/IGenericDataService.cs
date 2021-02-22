using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerumPostManager.Domain.Services
{
    interface IGenericDataService<T> where T : class
    {
        public Task<T> Create(T entity);
        public Task<bool> Delete(int id);
        public Task<T> Get(int id);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Update(T entity);
    }
}
