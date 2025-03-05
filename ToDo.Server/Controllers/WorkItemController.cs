﻿using Microsoft.AspNetCore.Mvc;
using ToDo.Service;
using ToDo.Shared.Entities;

namespace ToDo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkItemController : Controller
    {
        private readonly WorkItemService WorkItemService;
        public WorkItemController(WorkItemService workItemService)
        {
            WorkItemService = workItemService;
        }

        [HttpGet]
        public async Task<IEnumerable<WorkItem>> GetAll()
        {
            return await WorkItemService.GetAllAsync();
        }
    }
}
