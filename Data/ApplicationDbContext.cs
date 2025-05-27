using Microsoft.EntityFrameworkCore;
using PaymentOptions.Model;

namespace PaymentOptions.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MCarrierCode> MCarrierCode { get; set; }
        public DbSet<MCultureCode> MCultureCode { get; set; }
        public DbSet<MCurrencyCode> MCurrencyCode { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-U0FCH2L;Database=PaymentConfigurations;TrustServerCertificate=True;Trusted_Connection=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MCarrierCode>().Property(m => m.DateCreated).HasDefaultValueSql("GETUTCDATE()");
            //modelBuilder.Entity<MCarrierCode>().Property(m=> m.DateCreated).HasColumnType("DATE");
            modelBuilder.Entity<MCarrierCode>().HasData(
                    new MCarrierCode { CarrierID=1, Code=1, CarrierCode="AK", CreatedBy="admin_2" }
                );
        }
    }
}
