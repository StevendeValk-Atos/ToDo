﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Shared.Interfaces
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> _dbSet { get; }
        DbContext _dbContext { get; }

        /// <summary>
        /// Get all items of an entity by asynchronous method
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> GetAllAsync();

        /// <summary>
        /// Find one item of an entity asynchronous method
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        T Find(params object[] keyValues);

        /// <summary>
        /// Find one item of an entity by asynchronous method
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<T> FindAsync(params object[] keyValues);

        /// <summary>
        /// Insert item into an entity by asynchronous method
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task InsertAsync(T entity, bool saveChanges = true);

        /// <summary>
        /// Insert multiple items into an entity by asynchronous mehtod
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task InsertRangeAsync(IEnumerable<T> entities, bool saveChanges = true);

        /// <summary>
        /// Remove one item from an entity by asynchronous method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task DeleteAsync(int id, bool saveChanges = true);

        /// <summary>
        /// Remove multiple items from an entity by asynchronous method
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="saveChanges"></param>
        /// <returns></returns>
        Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true);

        void Update(T entity, bool saveChanges = true);

        void UpdateRange(IEnumerable<T> entities, bool saveChanges = true);
    }
}
