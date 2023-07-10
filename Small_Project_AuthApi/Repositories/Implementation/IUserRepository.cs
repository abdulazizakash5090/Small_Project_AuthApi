using Microsoft.EntityFrameworkCore;
using Small_Project_AuthApi.Context;
using Small_Project_AuthApi.Repositories.Contract;

namespace Small_Project_AuthApi.Repositories.Implementation
{
    public class IUserRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;
        public IUserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        TEntity IGenericRepository<TEntity>.GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
