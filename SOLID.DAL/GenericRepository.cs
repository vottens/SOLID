using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RefactorThis.GraphDiff;
using SOLID.Context;
using SOLID.Global.Interfaces.Context;
using SOLID.Global.Interfaces.DAL;

namespace SOLID.DAL
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly SOLIDContext _context;

        public GenericRepository(ISOLIDContext context)
        {
            _context = context as SOLIDContext;
        }

        public IQueryable<T> All()
        {
            return _context.Set<T>();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T FindById(int id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public void InsertOrUpdate(T entity)
        {
            if (entity.Id == default(long))
            {
                _context.Set<T>().Add(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void InsertOrUpdate(T entity, Expression<Func<IUpdateConfiguration<T>,object>> expression) 
        {
            _context.UpdateGraph(entity, expression);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
