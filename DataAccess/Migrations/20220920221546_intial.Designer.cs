﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(CMSContext))]
    [Migration("20220920221546_intial")]
    partial class intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccess.Models.StockAccessory", b =>
                {
                    b.Property<int>("AccessoryId")
                        .HasColumnType("int")
                        .HasColumnName("AccessoryID");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("StockItemId")
                        .HasColumnType("int")
                        .HasColumnName("StockItemID");

                    b.HasKey("AccessoryId");

                    b.HasIndex("StockItemId");

                    b.ToTable("StockAccessory", (string)null);
                });

            modelBuilder.Entity("DataAccess.Models.StockImage", b =>
                {
                    b.Property<int>("StockImageId")
                        .HasColumnType("int")
                        .HasColumnName("StockImageID");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("StockItemId")
                        .HasColumnType("int")
                        .HasColumnName("StockItemID");

                    b.HasKey("StockImageId");

                    b.HasIndex("StockItemId");

                    b.ToTable("StockImage", (string)null);
                });

            modelBuilder.Entity("DataAccess.Models.StockItem", b =>
                {
                    b.Property<int>("StockItemId")
                        .HasColumnType("int")
                        .HasColumnName("StockItemID");

                    b.Property<string>("Colour")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("CostPrice")
                        .HasColumnType("numeric(18,2)");

                    b.Property<DateTime?>("Dtcreated")
                        .HasColumnType("datetime")
                        .HasColumnName("DTCreated");

                    b.Property<DateTime?>("Dtupdated")
                        .HasColumnType("datetime")
                        .HasColumnName("DTUpdated");

                    b.Property<string>("Kms")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("KMS");

                    b.Property<string>("Make")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ModelYear")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RegNo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("RetailPrice")
                        .HasColumnType("numeric(18,2)");

                    b.Property<string>("Vin")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("VIN");

                    b.HasKey("StockItemId");

                    b.ToTable("StockItem", (string)null);
                });

            modelBuilder.Entity("DataAccess.Models.StockAccessory", b =>
                {
                    b.HasOne("DataAccess.Models.StockItem", "StockItem")
                        .WithMany("StockAccessories")
                        .HasForeignKey("StockItemId")
                        .HasConstraintName("FK_StockAccessory_StockItem");

                    b.Navigation("StockItem");
                });

            modelBuilder.Entity("DataAccess.Models.StockImage", b =>
                {
                    b.HasOne("DataAccess.Models.StockItem", "StockItem")
                        .WithMany("StockImages")
                        .HasForeignKey("StockItemId")
                        .HasConstraintName("fk_StockItem");

                    b.Navigation("StockItem");
                });

            modelBuilder.Entity("DataAccess.Models.StockItem", b =>
                {
                    b.Navigation("StockAccessories");

                    b.Navigation("StockImages");
                });
#pragma warning restore 612, 618
        }
    }
}