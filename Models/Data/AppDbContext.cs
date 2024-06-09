using Microsoft.EntityFrameworkCore;
using webdersi.Models.Entities;

namespace webdersi.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
