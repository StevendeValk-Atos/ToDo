using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.DataAccess.Extensions
{
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            string connectionString
        )
        {
            services.AddDbContext<ToDoContext>(options =>
            {
                options.UseSqlServer(
                    connectionString,
                    sqlOptions => sqlOptions.MigrationsAssembly("ToDo.DataAccess")
                );
            });
            services.AddScoped<Func<ToDoContext>>((provider) => () =>
            {
                return provider.GetService<ToDoContext>()!;
            });

            return services;
        }
    }
}
