using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Global.DataService
{
    public interface IRepository<T> where T : class
    {
        T Find(params object[] keyValues);
        T Get(Expression<Func<T, bool>> predicate);
        List<T> GetList(Expression<Func<T, bool>> predicate = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> ToQueryable();

    }
}
