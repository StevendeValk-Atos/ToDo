using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDo.DataAccess;
using ToDo.Service;
using ToDo.Shared.Interfaces;

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
            // AutoMapper Configuration
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton<IMapper>(mapper);

            services.AddDbContext<ToDoContext>(options =>
            {
                string connString = Configuration.GetConnectionString("default")!;
                options.UseSqlServer(
                    connString,
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("ToDo.DataAccess");
                    }
                );
            });

            services.AddScoped<Func<ToDoContext>>(
                (provider) => () => provider.GetService<ToDoContext>()!
            );
            services.AddScoped<DbFactory>();
            services.AddScoped<IRepository<Shared.Entities.WorkItem>, Repository<Shared.Entities.WorkItem>>();
            services.AddScoped<WorkItemService>();

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
        }
    }
}
