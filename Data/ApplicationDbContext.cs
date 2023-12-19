using Microsoft.EntityFrameworkCore;
using MVC2.Models;

namespace MVC2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> products { get; set; }

    }
}
