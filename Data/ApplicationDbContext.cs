using Magazin_odejdi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Magazin_odejdi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Clothes> Clothess { get; set; }

    }
}
