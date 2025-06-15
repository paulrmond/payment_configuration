using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PaymentOptions.Model;

namespace PaymentOptions.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MCarrierCode> MCarrierCode { get; set; }
        public DbSet<MCultureCode> MCultureCode { get; set; }
        public DbSet<MCurrencyCode> MCurrencyCode { get; set; }
        public DbSet<PaymentTab> PaymentTabs { get; set; }
        public DbSet<PaymentChannel> PaymentChannels { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<MLob> MLobs { get; set; }
        public DbSet<MChannelDetail> ChannelDetails { get; set; }
        public DbSet<MChannelHash> MChannelHashes { get; set; }
        public DbSet<LOBCurrencyMapping> LOBCurrencyMappings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Pass the options to the base class.
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=DESKTOP-U0FCH2L;Database=PaymentConfigurations;TrustServerCertificate=True;Trusted_Connection=True");
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));

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
