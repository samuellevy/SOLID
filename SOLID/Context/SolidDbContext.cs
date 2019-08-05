using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Context
{
    public class SolidDbContext : DbContext
    {
        public SolidDbContext(DbContextOptions<SolidDbContext> options)
            : base(options)
        {}

        public DbSet<Models.User> User { get; set; }
    }
}
