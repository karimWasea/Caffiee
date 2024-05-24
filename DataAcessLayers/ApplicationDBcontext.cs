using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAcessLayers
{
  
    public class ApplicationDBcontext : IdentityDbContext<Applicaionuser>
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options)
            : base(options)
        { }
     

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Set default value for CreationTime for all entities inheriting from BaseEntity

            builder.Entity<Applicaionuser>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()");
              builder.Entity<FinancialAdvance>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()");  builder.Entity<Product>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()"); 
            builder.Entity<Category>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()"); 
            builder.Entity<UserProduct>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()"); 
            
            builder.Entity<FinancialAdvanceHistory>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()");



        }

        public DbSet<FinancialAdvance> FinancialAdvances { get; set; }
        public DbSet<FinancialAdvanceHistory>  FinancialAdvanceHistories { get; set; }
        public DbSet<Category>   Categories { get; set; }
        public DbSet<Product>    products { get; set; }
        public DbSet<UserProduct>     UserProducts { get; set; }
        // DbSet properties for other entities...
    }
}
 







 