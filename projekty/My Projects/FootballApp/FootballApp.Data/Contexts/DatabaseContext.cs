using FootballApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballApp.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }

    }
}
