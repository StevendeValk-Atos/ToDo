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
    }
}
