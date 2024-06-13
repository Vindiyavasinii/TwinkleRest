using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace TwinkleRestaurant.Models
{
    public class AppsDbContext:DbContext
    {
        public AppsDbContext(DbContextOptions<AppsDbContext> options)
        : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<admin> admins  { get; set; }
        public DbSet<Reservation> Reservations { get; set; }



    }
}
