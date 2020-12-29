﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P0_KemoAllen;

namespace P0_KemoAllen.Migrations
{
    [DbContext(typeof(Store_DbContext))]
    [Migration("20201229034558_P0_Migration")]
    partial class P0_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("P0_KemoAllen.Customer", b =>
                {
                    b.Property<Guid>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("P0_KemoAllen.Inventory", b =>
                {
                    b.Property<Guid>("inventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("inventoryId");

                    b.ToTable("inventory");
                });

            modelBuilder.Entity("P0_KemoAllen.Location", b =>
                {
                    b.Property<Guid>("locationGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("locationInventoryinventoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("locationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("locationGuid");

                    b.HasIndex("locationInventoryinventoryId");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("P0_KemoAllen.Order", b =>
                {
                    b.Property<Guid>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("orderCustomeruserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("orderLocationlocationGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("timeCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("orderId");

                    b.HasIndex("orderCustomeruserId");

                    b.HasIndex("orderLocationlocationGuid");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("P0_KemoAllen.Location", b =>
                {
                    b.HasOne("P0_KemoAllen.Inventory", "locationInventory")
                        .WithMany()
                        .HasForeignKey("locationInventoryinventoryId");

                    b.Navigation("locationInventory");
                });

            modelBuilder.Entity("P0_KemoAllen.Order", b =>
                {
                    b.HasOne("P0_KemoAllen.Customer", "orderCustomer")
                        .WithMany()
                        .HasForeignKey("orderCustomeruserId");

                    b.HasOne("P0_KemoAllen.Location", "orderLocation")
                        .WithMany()
                        .HasForeignKey("orderLocationlocationGuid");

                    b.Navigation("orderCustomer");

                    b.Navigation("orderLocation");
                });
#pragma warning restore 612, 618
        }
    }
}
