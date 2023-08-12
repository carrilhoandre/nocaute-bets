using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NocauteBets.Infra.SqlServer.Contexts;
using NocauteBets.Infra.SqlServer.Repositories;
using NocauteBets.Infra.SqlServer.Repositories.Interfaces;
using NocauteBets.Infra.SqlServer.Uow;

namespace NocauteBets.Infra.MongoDb
{
    public static class SqlDependencyResolver
    {
        public static IServiceCollection AddSqlServerInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(c => new NocauteBetsDbContext(configuration.GetSection("ConnectionStrings")["SqlConnection"]));
            services.AddScoped<IFighterRepository, FighterRepository>();
            return services;
        }
    }
}
