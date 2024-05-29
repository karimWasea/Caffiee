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
              builder.Entity<FinancialUserCash>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()");  builder.Entity<Product>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()"); 
            builder.Entity<Category>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()"); 

            builder.Entity<NotPayedmoney>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()"); 
            
            builder.Entity<FinancialAdvanceHistory>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()");  
            
            builder.Entity<PriceProductebytypes>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()");
               builder.Entity<CustomerType>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()"); 
            
            
            builder.Entity<CategoryAttachment>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()"); 
            builder.Entity<ProductAttachment>()
              .Property(e => e.CreationTime)
              .HasDefaultValueSql("GETDATE()");



        }

        public DbSet<FinancialUserCash> FinancialAdvances { get; set; }
        public DbSet<FinancialAdvanceHistory>  FinancialAdvanceHistories { get; set; }
        public DbSet<Category>   Categories { get; set; }
        public DbSet<Product>    products { get; set; }
        public DbSet<PriceProductebytypes> PriceProductebytypes { get; set; }
        public DbSet<NotPayedmoney> NotPayedmoney { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<CategoryAttachment> CategoryAttachments { get; set; }
        public DbSet<ProductAttachment> ProductAttachments { get; set; }
        // DbSet properties for other entities...
    }
}
 







 