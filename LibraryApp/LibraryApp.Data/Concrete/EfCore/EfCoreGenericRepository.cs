using System.Linq.Expressions;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Concrete.EfCore.Context;

using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Concrete.EfCore
{
    //Genel CRUD i�lemleri 
    public class EfCoreGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;

        public EfCoreGenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChangesAsync();
        }
    }
}