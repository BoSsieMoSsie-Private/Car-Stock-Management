using System;
using System.Collections.Generic;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess
{
    public partial class CMSContext : DbContext
    {
        public CMSContext()
        {
        }

        public CMSContext(DbContextOptions<CMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StockAccessory> StockAccessories { get; set; } = null!;
        public virtual DbSet<StockImage> StockImages { get; set; } = null!;
        public virtual DbSet<StockItem> StockItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=BOSSIE-LAPTOP;Database=CMS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockAccessory>(entity =>
            {
                entity.HasKey(e => e.AccessoryId);

                entity.ToTable("StockAccessory");

                entity.Property(e => e.AccessoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("AccessoryID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StockItemId).HasColumnName("StockItemID");

                entity.HasOne(d => d.StockItem)
                    .WithMany(p => p.StockAccessories)
                    .HasForeignKey(d => d.StockItemId)
                    .HasConstraintName("FK_StockAccessory_StockItem");
            });

            modelBuilder.Entity<StockImage>(entity =>
            {
                entity.ToTable("StockImage");

                entity.Property(e => e.StockImageId)
                    .ValueGeneratedNever()
                    .HasColumnName("StockImageID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StockItemId).HasColumnName("StockItemID");

                entity.HasOne(d => d.StockItem)
                    .WithMany(p => p.StockImages)
                    .HasForeignKey(d => d.StockItemId)
                    .HasConstraintName("fk_StockItem");
            });

            modelBuilder.Entity<StockItem>(entity =>
            {
                entity.ToTable("StockItem");

                entity.Property(e => e.StockItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("StockItemID");

                entity.Property(e => e.Colour).HasMaxLength(50);

                entity.Property(e => e.CostPrice).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Dtcreated)
                    .HasColumnType("datetime")
                    .HasColumnName("DTCreated");

                entity.Property(e => e.Dtupdated)
                    .HasColumnType("datetime")
                    .HasColumnName("DTUpdated");

                entity.Property(e => e.Kms)
                    .HasMaxLength(50)
                    .HasColumnName("KMS");

                entity.Property(e => e.Make).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ModelYear).HasMaxLength(50);

                entity.Property(e => e.RegNo).HasMaxLength(50);

                entity.Property(e => e.RetailPrice).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Vin)
                    .HasMaxLength(50)
                    .HasColumnName("VIN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
