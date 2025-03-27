using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Shared.Interfaces;

namespace ToDo.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbSet<T> _dbSet => _dbContext.Set<T>();
        public DbContext _dbContext { get; private set; }

        public Repository(DbFactory dbFactory)
        {
            _dbContext = dbFactory.DbContext;
        }

        public async Task DeleteAsync(int id, bool saveChanges = true)
        {
            var entity = await _dbSet.FindAsync(id);
            await DeleteAsync(entity);

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(T entity, bool saveChanges = true)
        {
            _dbSet.Remove(entity);
            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
        {
            var enumerable = entities as T[] ?? entities.ToArray();
            if (enumerable.Any())
            {
                _dbSet.RemoveRange(enumerable);
            }

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public T Find(params object[] keyValues)
        {
            var entity = _dbSet.Find(keyValues);
            _dbSet.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual async Task<T> FindAsync(params object[] keyValues)
        {
            var entity = await _dbSet.FindAsync(keyValues);
            _dbSet.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task InsertAsync(T entity, bool saveChanges = true)
        {
            await _dbSet.AddAsync(entity);

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
        {
            await _dbContext.AddRangeAsync(entities);

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        public void Update(T entity, bool saveChanges = true)
        {
            _dbSet.Update(entity);

            if (saveChanges)
                _dbContext.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> entities, bool saveChanges = true)
        {
            _dbSet.UpdateRange(entities);

            if (saveChanges)
                _dbContext.SaveChanges();
        }
    }
}
