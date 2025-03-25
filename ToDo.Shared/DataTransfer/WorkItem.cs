using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Shared.DataTransfer
{
    public class WorkItem
    {
        public WorkItem(Shared.Entities.WorkItem workItem)
        {
            // TODO: Add AutoMapper for this
            Id = workItem.Id;
            Description = workItem.Description;
            IsDone = workItem.IsDone;
            
            if (workItem.CreatedBy == "Steven") { 
                IsMine = true;
            }
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public bool IsMine { get; set; }
    }
}
