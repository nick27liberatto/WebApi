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
            if (context.Elements.Any()) return;

            // Initial data
            context.Elements.AddRange(
                new Element { Name = "Ellie", Password = "immune1234", Text = "i cant turn into a zombie", StaticStatus = ElementEnum.Active},
                new Element { Name = "Joel", Password = "ellie1234", Text = "something pretty funny happens in part two", StaticStatus = ElementEnum.Inactive  }
            );

            context.SaveChanges();
        }
    }
}
