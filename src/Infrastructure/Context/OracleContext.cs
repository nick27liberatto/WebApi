using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class OracleContext : DbContext
    {
        public OracleContext(DbContextOptions<OracleContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
