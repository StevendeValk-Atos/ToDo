using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDo.DataAccess;
using ToDo.Service;
using ToDo.Shared.Interfaces;
using ToDo.DataAccess.Extensions;
using ToDo.Server.Extensions;

namespace ToDo.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMappers();

            string connectionString = Configuration.GetConnectionString("default")!;
            services.AddDatabase(connectionString);

            services.AddScoped<DbFactory>();
            services.AddScoped<IRepository<Shared.Entities.WorkItem>, Repository<Shared.Entities.WorkItem>>();
            services.AddScoped<WorkItemService>();

            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.SeedDatabase();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
