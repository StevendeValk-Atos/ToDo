
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

            SeedDb(app);

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

        private async static void SeedDb(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ToDoContext>();
                var repository = services.GetRequiredService<IRepository<WorkItem>>();
                var workItemService = services.GetRequiredService<WorkItemService>();


                if (!workItemService.GetAllAsync().Result.Any())
                {
                    await repository.InsertRangeAsync(new WorkItem[]
                    {
                        new WorkItem
                        {
                            Description = "Design a new logo for the company",
                            IsDone = false,
                            CreatedBy = "Steven",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Steven",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Update the company website with new content",
                            IsDone = true,
                            CreatedBy = "John",
                            CreatedAt = DateTime.Now.AddDays(-5),
                            ModifiedBy = "John",
                            ModifiedAt = DateTime.Now.AddDays(-2)
                        },
                        new WorkItem
                        {
                            Description = "Create a marketing plan for the new product launch",
                            IsDone = false,
                            CreatedBy = "Sarah",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Sarah",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Write a user manual for the new software release",
                            IsDone = true,
                            CreatedBy = "Michael",
                            CreatedAt = DateTime.Now.AddDays(-10),
                            ModifiedBy = "Michael",
                            ModifiedAt = DateTime.Now.AddDays(-3)
                        },
                        new WorkItem
                        {
                            Description = "Test the new feature in the software application",
                            IsDone = false,
                            CreatedBy = "Jessica",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Jessica",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Create training materials for the new software release",
                            IsDone = true,
                            CreatedBy = "David",
                            CreatedAt = DateTime.Now.AddDays(-7),
                            ModifiedBy = "David",
                            ModifiedAt = DateTime.Now.AddDays(-1)
                        },
                        new WorkItem
                        {
                            Description = "Research new technology for use in the company's products",
                            IsDone = false,
                            CreatedBy = "Emily",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Emily",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Brainstorm and develop a new product concept for the company",
                            IsDone = true,
                            CreatedBy = "James",
                            CreatedAt = DateTime.Now.AddDays(-4),
                            ModifiedBy = "James",
                            ModifiedAt = DateTime.Now.AddDays(-2)
                        },
                        new WorkItem
                        {
                            Description = "Develop a social media campaign to promote the company's products",
                            IsDone = false,
                            CreatedBy = "Amanda",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Amanda",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Develop a budget plan for the upcoming quarter",
                            IsDone = true,
                            CreatedBy = "Robert",
                            CreatedAt = DateTime.Now.AddDays(-6),
                            ModifiedBy = "Robert",
                            ModifiedAt = DateTime.Now.AddDays(-3)
                        },
                        new WorkItem
                        {
                            Description = "Organize files on the company's shared drive",
                            IsDone = false,
                            CreatedBy = "Linda",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Linda",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Schedule meetings for the upcoming week",
                            IsDone = true,
                            CreatedBy = "Daniel",
                            CreatedAt = DateTime.Now.AddDays(-2),
                            ModifiedBy = "Daniel",
                            ModifiedAt = DateTime.Now.AddDays(-1)
                        },
                        new WorkItem
                        {
                            Description = "Write a report on the company's financial performance",
                            IsDone = false,
                            CreatedBy = "Karen",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Karen",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Test the software application for bugs and errors",
                            IsDone = true,
                            CreatedBy = "William",
                            CreatedAt = DateTime.Now.AddDays(-8),
                            ModifiedBy = "William",
                            ModifiedAt = DateTime.Now.AddDays(-4)
                        },
                        new WorkItem
                        {
                            Description = "Develop a training program for new employees",
                            IsDone = false,
                            CreatedBy = "Laura",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Laura",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Research competitors in the industry and analyze their strategies",
                            IsDone = true,
                            CreatedBy = "Joseph",
                            CreatedAt = DateTime.Now.AddDays(-3),
                            ModifiedBy = "Joseph",
                            ModifiedAt = DateTime.Now.AddDays(-2)
                        },
                        new WorkItem
                        {
                            Description = "Develop a marketing campaign for the company's new product launch",
                            IsDone = false,
                            CreatedBy = "Michelle",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Michelle",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Create a presentation for the upcoming board meeting",
                            IsDone = true,
                            CreatedBy = "Thomas",
                            CreatedAt = DateTime.Now.AddDays(-1),
                            ModifiedBy = "Thomas",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Develop a sales strategy for the company's products",
                            IsDone = false,
                            CreatedBy = "Lisa",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Lisa",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Design a new product for the company's product line",
                            IsDone = true,
                            CreatedBy = "Charles",
                            CreatedAt = DateTime.Now.AddDays(-9),
                            ModifiedBy = "Charles",
                            ModifiedAt = DateTime.Now.AddDays(-3)
                        },
                        new WorkItem
                        {
                            Description = "Conduct market research to identify customer needs and preferences",
                            IsDone = false,
                            CreatedBy = "Steven",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Steven",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Write a press release to announce the company's new product launch",
                            IsDone = true,
                            CreatedBy = "John",
                            CreatedAt = DateTime.Now.AddDays(-5),
                            ModifiedBy = "John",
                            ModifiedAt = DateTime.Now.AddDays(-2)
                        },
                        new WorkItem
                        {
                            Description = "Develop a pricing strategy for the company's products",
                            IsDone = false,
                            CreatedBy = "Sarah",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Sarah",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Create an advertising campaign to promote the company's products",
                            IsDone = true,
                            CreatedBy = "Michael",
                            CreatedAt = DateTime.Now.AddDays(-4),
                            ModifiedBy = "Michael",
                            ModifiedAt = DateTime.Now.AddDays(-1)
                        },
                        new WorkItem
                        {
                            Description = "Analyze sales data to identify trends and opportunities",
                            IsDone = false,
                            CreatedBy = "Jessica",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Jessica",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Develop a distribution plan for the company's products",
                            IsDone = true,
                            CreatedBy = "David",
                            CreatedAt = DateTime.Now.AddDays(-6),
                            ModifiedBy = "David",
                            ModifiedAt = DateTime.Now.AddDays(-3)
                        },
                        new WorkItem
                        {
                            Description = "Create a customer loyalty program to reward loyal customers",
                            IsDone = false,
                            CreatedBy = "Emily",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Emily",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Conduct a customer satisfaction survey to gather feedback from customers",
                            IsDone = true,
                            CreatedBy = "James",
                            CreatedAt = DateTime.Now.AddDays(-2),
                            ModifiedBy = "James",
                            ModifiedAt = DateTime.Now.AddDays(-1)
                        },
                        new WorkItem
                        {
                            Description = "Develop a social media strategy to engage with customers on social media platforms",
                            IsDone = false,
                            CreatedBy = "Amanda",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Amanda",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Create a product demonstration video to showcase the features of the company's products",
                            IsDone = true,
                            CreatedBy = "Robert",
                            CreatedAt = DateTime.Now.AddDays(-3),
                            ModifiedBy = "Robert",
                            ModifiedAt = DateTime.Now.AddDays(-1)
                        },
                        new WorkItem
                        {
                            Description = "Write an annual report to provide an overview of the company's financial performance and achievements",
                            IsDone = false,
                            CreatedBy = "Linda",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Linda",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Develop a branding strategy to establish and promote the company's brand identity",
                            IsDone = true,
                            CreatedBy = "Daniel",
                            CreatedAt = DateTime.Now.AddDays(-4),
                            ModifiedBy = "Daniel",
                            ModifiedAt = DateTime.Now.AddDays(-2)
                        },
                        new WorkItem
                        {
                            Description = "Create an email marketing campaign to promote the company's products and services to customers via email",
                            IsDone = false,
                            CreatedBy = "Karen",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Karen",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Design a sales brochure to showcase the company's products and services",
                            IsDone = true,
                            CreatedBy = "William",
                            CreatedAt = DateTime.Now.AddDays(-5),
                            ModifiedBy = "William",
                            ModifiedAt = DateTime.Now.AddDays(-1)
                        },
                        new WorkItem
                        {
                            Description = "Develop a customer service plan to improve customer satisfaction and loyalty",
                            IsDone = false,
                            CreatedBy = "Laura",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Laura",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Conduct a competitive analysis to identify the company's strengths and weaknesses compared to its competitors",
                            IsDone = true,
                            CreatedBy = "Joseph",
                            CreatedAt = DateTime.Now.AddDays(-3),
                            ModifiedBy = "Joseph",
                            ModifiedAt = DateTime.Now.AddDays(-1)
                        },
                        new WorkItem
                        {
                            Description = "Write a white paper to provide in-depth information on a specific topic related to the company's industry",
                            IsDone = false,
                            CreatedBy = "Michelle",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Michelle",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Develop a product roadmap to outline the company's plans for future product development and releases",
                            IsDone = true,
                            CreatedBy = "Thomas",
                            CreatedAt = DateTime.Now.AddDays(-2),
                            ModifiedBy = "Thomas",
                            ModifiedAt = DateTime.Now.AddDays(-1)
                        },
                        new WorkItem
                        {
                            Description = "Create a trade show booth design to showcase the company's products and services at industry events",
                            IsDone = false,
                            CreatedBy = "Lisa",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Lisa",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Analyze website traffic data to identify trends and opportunities for improvement",
                            IsDone = true,
                            CreatedBy = "Charles",
                            CreatedAt = DateTime.Now.AddDays(-4),
                            ModifiedBy = "Charles",
                            ModifiedAt = DateTime.Now.AddDays(-2)
                        },
                        new WorkItem
                        {
                            Description = "Develop a content marketing strategy to attract and engage customers through valuable and informative content",
                            IsDone = false,
                            CreatedBy = "Steven",
                            CreatedAt = DateTime.Now,
                            ModifiedBy = "Steven",
                            ModifiedAt = DateTime.Now
                        },
                        new WorkItem
                        {
                            Description = "Create an affiliate marketing program to incentivize partners to promote the company's products and services",
                            IsDone = true,
                            CreatedBy = "John",
                            CreatedAt = DateTime.Now.AddDays(-1),
                            ModifiedBy = "John",
                            ModifiedAt = DateTime.Now
                        }
                    });
                }
            }
        }
    }
}
