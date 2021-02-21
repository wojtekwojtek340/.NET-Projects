using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly TaskManagerContext context;
        private DbSet<T> entities;

        public Repository(TaskManagerContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public void Delete(int id)
        {
            T entity = entities.Find(id);

            if (entity == null)
            {
                throw new ArgumentNullException("this id no exist");
            }

            entities.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("null entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("null entity");
            }

            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
