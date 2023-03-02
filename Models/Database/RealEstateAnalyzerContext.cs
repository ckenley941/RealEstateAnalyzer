using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RealEstateAnalyzer.Models.Database
{
    public partial class RealEstateAnalyzerContext : DbContext
    {
        public RealEstateAnalyzerContext()
        {
        }

        public RealEstateAnalyzerContext(DbContextOptions<RealEstateAnalyzerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiFilterHistory> ApiFilterHistory { get; set; }
        public virtual DbSet<Home> Home { get; set; }
        public virtual DbSet<HomeDetailHistory> HomeDetailHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=RealEstateAnalyzer;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<ApiFilterHistory>(entity =>
            {
                entity.Property(e => e.Channel).HasColumnName("channel");

                entity.Property(e => e.RecordDateTime).HasColumnType("datetime");

                entity.Property(e => e.SearchBathrooms).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SearchBedrooms).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SearchHouseSqft).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SearchLotSqft).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SearchMaxPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SearchMinPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SearchRadius).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.HasIndex(e => e.PropertyId)
                    .HasName("UX_Home_PropertyId")
                    .IsUnique();

                entity.Property(e => e.PropertyId)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.RecordDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<HomeDetailHistory>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PriceChange).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PropertyId).HasMaxLength(256);

                entity.Property(e => e.RecordDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.HomeDetailHistory)
                    .HasPrincipalKey(p => p.PropertyId)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK_HomeDetailHistory_PropertyId");
            });
        }
    }
}
