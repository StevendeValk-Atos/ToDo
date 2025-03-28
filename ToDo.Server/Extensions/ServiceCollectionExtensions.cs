using AutoMapper;

namespace ToDo.Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton<IMapper>(mapper);

            return services;
        }
    }
}
