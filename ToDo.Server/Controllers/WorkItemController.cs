using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDo.Service;
using ToDo.Shared.Entities;

namespace ToDo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkItemController : Controller
    {
        private readonly IMapper Mapper;
        private readonly WorkItemService WorkItemService;

        public WorkItemController(
            IMapper mapper,
            WorkItemService workItemService)
        {
            Mapper = mapper;
            WorkItemService = workItemService;
        }

        [HttpGet]
        public async Task<IEnumerable<Shared.DataTransfer.WorkItem>> GetAll()
        {
            var workItems = await WorkItemService.GetAllAsync();
            var dataTransferItems = workItems.Select(workItem =>
            {
                return Mapper.Map<Shared.DataTransfer.WorkItem>(workItem);
            });

            return dataTransferItems;
        }

        [HttpPost]
        public async Task InsertAsync([FromBody] WorkItem workItem)
        {
            await WorkItemService.InsertAsync(workItem);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await WorkItemService.DeleteAsync(id);
        }

        [HttpPut("{id}")]
        public void UpdateAsync(int id, [FromBody] WorkItem workItem)
        {
            WorkItemService.Update(workItem);
        }
    }
}
