﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Shared.Entities;
using ToDo.Shared.Interfaces;

namespace ToDo.Service
{
    public class WorkItemService
    {
        private readonly IRepository<WorkItem> _repository;
        
        public WorkItemService(IRepository<WorkItem> repository)
        {
            _repository = repository;
        }

        public async Task<IList<WorkItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task InsertAsync(WorkItem workItem)
        {
            await _repository.InsertAsync(workItem);
        }

        public async Task DeleteAsync(int workItemId)
        {
            var item = await _repository.FindAsync(workItemId);
            if (item == null)
                throw new KeyNotFoundException();

            await _repository.DeleteAsync(workItemId);
        }

        public void Update(WorkItem workItem)
        {
            _repository.Update(workItem);
        }

        public void UpdateRange(IEnumerable<WorkItem> workItems)
        {
            _repository.UpdateRange(workItems);
        }


    }
}
