
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDo.DataAccess;
using ToDo.Service;
using ToDo.Shared.Entities;
using ToDo.Shared.Interfaces;

namespace ToDo.Server
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseWebRoot("wwwroot");
                });
        }
    }
}
