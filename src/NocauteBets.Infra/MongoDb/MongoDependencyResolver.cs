using DevKreator.Projects.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NocauteBets.Infra.MongoDb.Contexts;
using NocauteBets.Infra.MongoDb.Repositories;
using NocauteBets.Infra.MongoDb.Repositories.Interfaces;

namespace NocauteBets.Infra.MongoDb
{
    public static class MongoDependencyResolver
    {
        public static IServiceCollection AddMongoDbInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoDbContext, MongoDbContext>();
            services.Configure<MongoSettings>(options =>
            {
                options.ConnectionString = configuration.GetSection("ConnectionStrings")["MongoConnectionString"];
                options.Database = configuration.GetSection("ConnectionStrings")["MongoDatabaseName"];

            });

            services.AddScoped<IFighterRepository, FighterRepository>();
            return services;
        }
    }
}
