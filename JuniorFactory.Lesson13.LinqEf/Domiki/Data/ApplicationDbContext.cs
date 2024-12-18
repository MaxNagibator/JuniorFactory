using Domiki.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domiki.Web.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

        public DbSet<Domik> Domiks { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<ModificatorType> ModificatorTypes { get; set; }

        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptResource> ReceiptResources { get; set; }

        public DbSet<DomikType> DomikTypes { get; set; }
        public DbSet<DomikTypeLevel> DomikTypeLevels { get; set; }
        public DbSet<DomikTypeLevelResource> DomikTypeLevelResources { get; set; }
        public DbSet<DomikTypeLevelModificator> DomikTypeLevelModificators { get; set; }
        public DbSet<DomikTypeLevelReceipt> DomikTypeLevelRecepts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Resource>()
                .HasKey(p => new
                {
                    p.PlayerId,
                    p.TypeId
                });

            modelBuilder.Entity<Domik>()
                .HasKey(p => new
                {
                    p.PlayerId,
                    p.Id
                });

            modelBuilder.Entity<Player>()
                .HasIndex(u => u.AspNetUserId)
                .IsUnique();

            modelBuilder.Entity<Player>()
                .Navigation(e => e.Resources)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<Resource>()
                .Navigation(e => e.Player)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<Manufacture>()
                .HasOne(s => s.Domik)
                .WithMany(x => x.Manufactures)
                .HasForeignKey(e => new { e.DomikPlayerId, e.DomikId});


            modelBuilder.Entity<DomikTypeLevel>()
                .HasKey(p => new
                {
                    p.DomikTypeId,
                    p.Value,
                });

            modelBuilder.Entity<DomikTypeLevel>()
                .HasOne(s => s.DomikType)
                .WithMany(x => x.Levels)
                .HasForeignKey(e => e.DomikTypeId);

            modelBuilder.Entity<DomikTypeLevelModificator>()
                .HasKey(p => new
                {
                    p.DomikTypeLevelDomikTypeId,
                    p.DomikTypeLevelValue,
                    p.ModificatorTypeId,
                });

            modelBuilder.Entity<DomikTypeLevelModificator>()
                .Navigation(e => e.DomikTypeLevel)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<DomikTypeLevelModificator>()
                .Navigation(e => e.ModificatorType)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<DomikTypeLevelReceipt>()
                .HasKey(p => new
                {
                    p.DomikTypeLevelDomikTypeId,
                    p.DomikTypeLevelValue,
                    p.ReceiptId,
                });

            modelBuilder.Entity<DomikTypeLevelReceipt>()
                .Navigation(e => e.DomikTypeLevel)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<DomikTypeLevelReceipt>()
                .Navigation(e => e.Receipt)
                .UsePropertyAccessMode(PropertyAccessMode.Property);


            modelBuilder.Entity<DomikTypeLevelResource>()
                .HasKey(p => new
                {
                    p.DomikTypeLevelDomikTypeId,
                    p.DomikTypeLevelValue,
                    p.ResourceTypeId,
                });

            modelBuilder.Entity<DomikTypeLevelResource>()
                .Navigation(e => e.DomikTypeLevel)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<DomikTypeLevelResource>()
                .Navigation(e => e.ResourceType)
                .UsePropertyAccessMode(PropertyAccessMode.Property);


            modelBuilder.Entity<ReceiptResource>()
                .HasKey(p => new
                {
                    p.ReceiptId,
                    p.ResourceTypeId,
                    p.IsInput,
                });

            modelBuilder.Entity<ReceiptResource>()
                .Navigation(e => e.Receipt)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<ReceiptResource>()
                .Navigation(e => e.ResourceType)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}