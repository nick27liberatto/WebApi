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
            if (context.Entities.Any()) return;

            // Adiciona dados iniciais
            context.Entities.AddRange(
                new Entity { Name = "Ellie", Password = "imune1234", Text = "sou um personagem de tlou nova", StaticStatus = EntityEnum.Active},
                new Entity { Name = "Joel", Password = "ellie1234", Text = "sou um personagem de tlou velho", StaticStatus = EntityEnum.Inactive  }
            );

            context.SaveChanges();
        }
    }
}
