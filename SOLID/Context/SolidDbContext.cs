using Microsoft.EntityFrameworkCore;
using SOLID.Domain.User;
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

        public DbSet<UserModel> User { get; set; }
    }
}
