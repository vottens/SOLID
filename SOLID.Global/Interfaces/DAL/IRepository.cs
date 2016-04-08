using System;
using System.Linq;
using System.Linq.Expressions;
using RefactorThis.GraphDiff;

namespace SOLID.Global.Interfaces.DAL
{
    public interface IRepository<T>
    {
        IQueryable<T> All();
        void Delete(T entity);
        T FindById(int id);
        void InsertOrUpdate(T entity);
        void InsertOrUpdate(T entity, Expression<Func<IUpdateConfiguration<T>, object>> expression);
        void Save();
    }
}
