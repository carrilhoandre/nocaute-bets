using Microsoft.EntityFrameworkCore;
using NocauteBets.Domain.Models;

namespace NocauteBets.Infra.SqlServer.Contexts
{
    public class NocauteBetsDbContext : DbContext
    {
        private readonly string _connectionString;

        public NocauteBetsDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                 .UseSqlServer(_connectionString);
        }

        public DbSet<Fighter> Fighters { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
