using Microsoft.EntityFrameworkCore;
using SOLID.Models.User;

namespace SOLID.Context
{
    public class SolidDbContext : DbContext
    {
        public SolidDbContext(DbContextOptions<SolidDbContext> options)
            : base(options)
        {}

        public DbSet<UserModel> User { get; set; }
    }
}
