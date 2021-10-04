using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VehicleApi.Contexts;
using VehicleTrackerApi.Data.Model;
using VehicleTrackerApi.Services.Base;

namespace VehicleTrackerApi.Services
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : IEntity
    {
        protected readonly ApplicationDbContext _context;
        public GeneralRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IQueryable<T> GetAll( Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null) 
        {
            var result = _context.Set<T>().AsQueryable();

            if (include != null)
                result = include(result);

            return result;
        }
        public T Get(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var result = _context.Set<T>().AsQueryable();

            if (include != null)
                result = include(result);

            return result.FirstOrDefault(x=>x.Id==id);
        }
      
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
      

    }

}
