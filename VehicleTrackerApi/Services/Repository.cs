using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleApi.Contexts;
using VehicleTrackerApi.Services.Base;

namespace VehicleTrackerApi.Services
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
           await _dbContext.AddAsync(entity);
           await  _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Delete(int Id)
        {
            var findItem = await _dbContext.Set<T>().FindAsync(Id);

            if (findItem != null)
            {
                _dbContext.Set<T>().Remove(findItem);
                _dbContext.SaveChanges();
               
            }
            return findItem;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public async Task<T> GetById(int Id)
        {
          return  await _dbContext.Set<T>().FindAsync(Id);
     
        }

        public async Task<T> UpdateAsync(T entity)
        {
             _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }

}
