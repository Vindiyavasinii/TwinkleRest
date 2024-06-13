using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TwinkleRestaurant.Models;

namespace TwinkleRestaurant.Data
{
    public static class AppsDbContextSeed
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new AppsDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppsDbContext>>());

            if (context.Tables.Any() || context.Reservations.Any())
            {
                return; // DB has been seeded
            }

            context.Tables.AddRange(
                new Table { Number = 1, Capacity = 4, Status = "available", Date = DateTime.Today, Time = new TimeSpan(18, 0, 0) },
                new Table { Number = 2, Capacity = 2, Status = "available", Date = DateTime.Today, Time = new TimeSpan(18, 0, 0) },
                new Table { Number = 3, Capacity = 6, Status = "booked", Date = DateTime.Today, Time = new TimeSpan(18, 0, 0) }
            );

            context.SaveChanges();
        }
    }
}
