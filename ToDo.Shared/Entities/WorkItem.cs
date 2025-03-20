using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Shared.Base;

namespace ToDo.Shared.Entities
{
    public class WorkItem : EntityBase<int>
    {
        public string Description { get; set; }
        public bool IsDone { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreatedAt {  get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
