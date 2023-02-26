using Microsoft.EntityFrameworkCore;

namespace Product.Entity.Entity
{
    public partial class AppDbContext: DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<Product> Products { get; set;}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
