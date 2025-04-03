using Microsoft.EntityFrameworkCore;
using ToDo.Shared.Entities;

namespace ToDo.DataAccess
{
    public partial class ToDoContext : DbContext
    {
        public ToDoContext() { }
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }
        public virtual DbSet<WorkItem> WorkItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }
}
