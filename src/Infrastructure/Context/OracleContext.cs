using Domain.Models;
using Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class OracleContext : DbContext
    {
        public OracleContext(DbContextOptions<OracleContext> options)
            : base(options) {}
        
        public DbSet<Element> Elements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ElementMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
