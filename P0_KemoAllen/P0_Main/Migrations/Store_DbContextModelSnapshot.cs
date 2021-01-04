﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P0_KemoAllen;

namespace P0_KemoAllen.Migrations
{
    [DbContext(typeof(Store_DbContext))]
    partial class Store_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("P0_KemoAllen.Inventory", b =>
                {
                    b.Property<Guid>("inventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("inventoryLocationlocationGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("inventoryProductproductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("inventoryQuantity")
                        .HasColumnType("int");

                    b.HasKey("inventoryId");

                    b.HasIndex("inventoryLocationlocationGuid");

                    b.HasIndex("inventoryProductproductId");

                    b.ToTable("inventories");
                });

            modelBuilder.Entity("P0_KemoAllen.Location", b =>
                {
                    b.Property<Guid>("locationGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("locationGuid");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("P0_KemoAllen.Order", b =>
                {
                    b.Property<DateTime>("timeCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("orderCustomeruserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("orderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("orderLocationlocationGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("orderProductproductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("orderQuantity")
                        .HasColumnType("int");

                    b.HasKey("timeCreated");

                    b.HasIndex("orderCustomeruserId");

                    b.HasIndex("orderLocationlocationGuid");

                    b.HasIndex("orderProductproductId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("P0_KemoAllen.Product", b =>
                {
                    b.Property<Guid>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("productId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("P0_KemoAllen.Inventory", b =>
                {
                    b.HasOne("P0_KemoAllen.Location", "inventoryLocation")
                        .WithMany()
                        .HasForeignKey("inventoryLocationlocationGuid");

                    b.HasOne("P0_KemoAllen.Product", "inventoryProduct")
                        .WithMany()
                        .HasForeignKey("inventoryProductproductId");

                    b.Navigation("inventoryLocation");

                    b.Navigation("inventoryProduct");
                });

            modelBuilder.Entity("P0_KemoAllen.Order", b =>
                {
                    b.HasOne("P0_KemoAllen.Customer", "orderCustomer")
                        .WithMany()
                        .HasForeignKey("orderCustomeruserId");

                    b.HasOne("P0_KemoAllen.Location", "orderLocation")
                        .WithMany()
                        .HasForeignKey("orderLocationlocationGuid");

                    b.HasOne("P0_KemoAllen.Product", "orderProduct")
                        .WithMany()
                        .HasForeignKey("orderProductproductId");

                    b.Navigation("orderCustomer");

                    b.Navigation("orderLocation");

                    b.Navigation("orderProduct");
                });
#pragma warning restore 612, 618
        }
    }
}
