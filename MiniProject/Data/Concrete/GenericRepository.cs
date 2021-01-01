using MiniProject.Data.Abstract;
using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Data.Concrete
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private DataContext context;

        public GenericRepository(DataContext _context)
        {
            context = _context;
        }

        public virtual void Delete(int id)
        {
            context.Remove<TEntity>(Get(id));
            context.SaveChanges();
        }

        public virtual TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            context.Add<TEntity>(entity);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            context.Update<TEntity>(entity);
            context.SaveChanges();
        }
    }
}
