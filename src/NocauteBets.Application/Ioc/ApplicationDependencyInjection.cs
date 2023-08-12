using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NocauteBets.Infra.MongoDb;

namespace NocauteBets.Application.Ioc
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddNocauteBets(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationDependencyInjection).Assembly));
            services.AddMongoDbInfra(configuration);
            services.AddSqlServerInfra(configuration);
            return services;
        }
    }
}
