using Common.Global.DataService;
using Contact.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Data.Core
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public readonly DbSet<T> Table;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            Table = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return Table.SingleOrDefault(predicate);
        }

        public T Find(params object[] keyValues)
        {
            return Table.Find(keyValues);
        }

        public IReadOnlyList<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return predicate == null ? Table.ToList() : Table.Where(predicate).ToList();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
