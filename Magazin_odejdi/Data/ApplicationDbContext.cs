using Magazin_odejdi.Model;
using Magazin_odejdi.Model.AuthApp;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<AuthUser> AuthUsers { get; set; }
    }
}
