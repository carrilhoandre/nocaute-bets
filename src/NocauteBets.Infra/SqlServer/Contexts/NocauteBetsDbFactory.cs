using Microsoft.EntityFrameworkCore.Design;

namespace NocauteBets.Infra.SqlServer.Contexts
{
    public class NocauteBetsDbFactory : IDesignTimeDbContextFactory<NocauteBetsDbContext>
    {
        public NocauteBetsDbContext CreateDbContext(string[] args)
        {
            return new NocauteBetsDbContext("Server=localhost,1433;Initial Catalog=DB_NOCAUTEBETS;Persist Security Info=False;User ID=sa;Password=yourStrong(!)Password;MultipleActiveResultSets=True;TrustServerCertificate=True;Connection Timeout=30;");
        }
    }
}
