using Domain.Models;
using Infrastructure.Context;
using Domain.Enums;

namespace Api.Configuration
{
    public static class SeedData
    {
        public static void Initialize(OracleContext context)
        {
            context.Database.EnsureCreated();

            // Se já houver dados, não faz nada
            if (context.Users.Any()) return;

            // Adiciona dados iniciais
            context.Users.AddRange(
                new User { Username = "admin01", Name = "Admin Teste", Email = "admin@example.com", Password = "12345", Status = StatusUserEnum.Working },
                new User { Username = "user01", Name = "Usuario Teste", Email = "user@example.com", Password = "Queijo123", Status = StatusUserEnum.Sleeping  }
            );

            context.SaveChanges();
        }
    }
}
