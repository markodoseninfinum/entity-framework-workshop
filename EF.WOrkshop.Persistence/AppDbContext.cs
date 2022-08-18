using EF.WOrkshop.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace EF.WOrkshop.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
