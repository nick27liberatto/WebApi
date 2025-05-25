using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class OracleContext : DbContext
    {
        public readonly OracleOptions _options;
        public OracleContext(
            DbContextOptions<OracleContext> options, 
            OracleOptions oracleOptions)
            : base(options) { _options = oracleOptions; }
        
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(_options.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
