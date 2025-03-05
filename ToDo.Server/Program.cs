
using Microsoft.EntityFrameworkCore;
using ToDo.DataAccess;
using ToDo.Service;
using ToDo.Shared.Entities;
using ToDo.Shared.Interfaces;

namespace ToDo.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ToDoContext>(options =>
            {
                string connString = builder.Configuration.GetConnectionString("default")!;
                options.UseSqlServer(
                    connString,
                    b => b.MigrationsAssembly("ToDo.DataAccess")
                );
            });

            builder.Services.AddScoped<Func<ToDoContext>>((provider) => () => provider.GetService<ToDoContext>());
            builder.Services.AddScoped<DbFactory>();
            builder.Services.AddScoped<IRepository<WorkItem>, Repository<WorkItem>>();
            builder.Services.AddScoped<WorkItemService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
