using Microsoft.EntityFrameworkCore;

namespace BookStore.EF_Core
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }
            

        
           public DbSet<Books> Books { get; set; }
           public DbSet<shape> Shapes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>();
      
            modelBuilder
                .Entity<shape>()
                .HasOne<Books>(e => e.Books)
                .WithMany(e => e.shape)
                .HasForeignKey(e => e.Id)
                .IsRequired();
        }

    }
}


