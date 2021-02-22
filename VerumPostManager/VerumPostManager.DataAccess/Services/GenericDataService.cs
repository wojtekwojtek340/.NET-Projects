using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerumPostManager.DataAccess;

namespace VerumPostManager.Domain.Services
{
    public class GenericDataService<T> : IGenericDataService<T> where T : class
    {
        private readonly VerumPostmanagerContextFactory _contextFactory;

        public GenericDataService(VerumPostmanagerContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<T> Create(T entity)
        {
            using (VerumPostManagerContext context = _contextFactory.CreateDbContext())
            {
                var createdResault = context.Set<T>().Add(entity);
                await context.SaveChangesAsync();
                return createdResault.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (VerumPostManagerContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FindAsync(id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (VerumPostManagerContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FindAsync(id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (VerumPostManagerContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(T entity)
        {
            using (VerumPostManagerContext context = _contextFactory.CreateDbContext())
            {
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
