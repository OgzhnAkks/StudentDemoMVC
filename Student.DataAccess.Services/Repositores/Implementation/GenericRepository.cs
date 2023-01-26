using Student.DataAccess.Services.Contexts;
using Student.DataAccess.Services.Repositores.Abstract;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace Student.DataAccess.Services.Repositores.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly StudentContext _studentContext;

        public GenericRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _studentContext.AddAsync(entity);
            await _studentContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> entity)
        {
            await _studentContext.AddRangeAsync(entity);
            await _studentContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(TEntity entity)
        {
            _studentContext.Remove(entity);

            return await _studentContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _studentContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return await (filter == null ?
                   _studentContext.Set<TEntity>().ToListAsync() :
                   _studentContext.Set<TEntity>().Where(filter).ToListAsync());
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _studentContext.Update(entity);
            await _studentContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> UpdateRange(List<TEntity> entity)
        {
            _studentContext.UpdateRange(entity);
            await _studentContext.SaveChangesAsync();
            return entity;
        }
    }
}
