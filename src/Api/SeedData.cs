using Domain.Models;
using Infrastructure.Context;
using Domain.Enums;

namespace Api
{
    public static class SeedData
    {
        public static void Initialize(OracleContext context)
        {
            context.Database.EnsureCreated();

            //If already has data, doesn't initiate
            if (context.Entities.Any()) return;

            // Initial data
            context.Entities.AddRange(
                new Entity { Name = "Ellie", Password = "immune1234", Text = "i cant turn into a zombie", StaticStatus = EntityEnum.Active},
                new Entity { Name = "Joel", Password = "ellie1234", Text = "something pretty funny happens in part two", StaticStatus = EntityEnum.Inactive  }
            );

            context.SaveChanges();
        }
    }
}
