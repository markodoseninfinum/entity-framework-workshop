using Microsoft.EntityFrameworkCore;

namespace EF.WOrkshop.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
