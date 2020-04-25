using MusicTour.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MusicTour.DataAccess.Context
{
    public partial class MusicTourContext : DbContext
    {
        public MusicTourContext()
        {
        }

        public MusicTourContext(DbContextOptions<MusicTourContext> options) : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Concert> Concert { get; set; }
        public virtual DbSet<Band> Band { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
                {
                    entity.Property(c => c.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(c => c.Name).IsRequired();
                    entity.Property(c => c.Country).IsRequired();
                    entity.Property(c => c.UTCTimezone).IsRequired();
                });

            modelBuilder.Entity<Band>(entity =>
                {
                    entity.Property(m => m.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(m => m.Name).IsRequired();
                    entity.Property(m => m.Members).IsRequired();
                    entity.Property(m => m.Genre).IsRequired();
                });

            modelBuilder.Entity<Concert>(entity =>
                {
                    entity.Property(s=>s.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(s => s.Date).IsRequired();
                    entity.Property(s => s.Time).IsRequired();
                    entity.HasOne(s => s.City)
                        .WithMany(c => c.Concert)
                        .HasForeignKey(s => s.CityId)
                        .HasConstraintName("FK_Concert_City");
                    entity.HasOne(s => s.Band)
                        .WithMany(m => m.Concert).HasForeignKey(s=>s.BandId)
                        .HasConstraintName("FK_Concert_Band");
                });
            
            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}