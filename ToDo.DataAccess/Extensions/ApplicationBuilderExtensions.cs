using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ToDo.DataAccess.Seeders;

namespace ToDo.DataAccess.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder builder)
        {
            ToDoContext toDoContext = builder.ApplicationServices.GetRequiredService<ToDoContext>();
            ToDoContextSeeder.Seed(toDoContext);
            
            return builder;
        }
    }
}
