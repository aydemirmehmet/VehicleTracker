using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VehicleTrackerApi.Data.Model;

namespace VehicleTrackerApi.Services.Base
{
    public interface IGeneralRepository<T> where T : IEntity
    {
   
        T Get(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        IQueryable<T> GetAll( Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
      
    }
}
