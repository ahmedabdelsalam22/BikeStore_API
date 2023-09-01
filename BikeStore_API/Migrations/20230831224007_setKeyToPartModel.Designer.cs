﻿// <auto-generated />
using System;
using BikeStore_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BikeStore_API.Migrations
{
    [DbContext(typeof(BikeStoresContext))]
    [Migration("20230831224007_setKeyToPartModel")]
    partial class setKeyToPartModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BikeStore_API.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("brand_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("brand_name");

                    b.HasKey("BrandId")
                        .HasName("PK__brands__5E5A8E2749CD41AA");

                    b.ToTable("brands", "production");
                });

            modelBuilder.Entity("BikeStore_API.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId")
                        .HasName("PK__categori__D54EE9B46AA0EBAC");

                    b.ToTable("categories", "production");
                });

            modelBuilder.Entity("BikeStore_API.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("city");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("phone");

                    b.Property<string>("State")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("state");

                    b.Property<string>("Street")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("street");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("zip_code");

                    b.HasKey("CustomerId")
                        .HasName("PK__customer__CD65CB85A317CD17");

                    b.ToTable("customers", "sales");
                });

            modelBuilder.Entity("BikeStore_API.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date")
                        .HasColumnName("order_date");

                    b.Property<byte>("OrderStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("order_status");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("date")
                        .HasColumnName("required_date");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnType("date")
                        .HasColumnName("shipped_date");

                    b.Property<int>("StaffId")
                        .HasColumnType("int")
                        .HasColumnName("staff_id");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("store_id");

                    b.HasKey("OrderId")
                        .HasName("PK__orders__46596229A6F335DC");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.HasIndex("StoreId");

                    b.ToTable("orders", "sales");
                });

            modelBuilder.Entity("BikeStore_API.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("item_id");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(4, 2)")
                        .HasColumnName("discount");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("list_price");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("OrderId", "ItemId")
                        .HasName("PK__order_it__837942D433AAA504");

                    b.HasIndex("ProductId");

                    b.ToTable("order_items", "sales");
                });

            modelBuilder.Entity("BikeStore_API.Models.Part", b =>
                {
                    b.Property<int>("PartId")
                        .HasColumnType("int")
                        .HasColumnName("part_id");

                    b.Property<string>("PartName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("part_name");

                    b.ToTable("parts", "production");
                });

            modelBuilder.Entity("BikeStore_API.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("brand_id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("list_price");

                    b.Property<short>("ModelYear")
                        .HasColumnType("smallint")
                        .HasColumnName("model_year");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_name");

                    b.HasKey("ProductId")
                        .HasName("PK__products__47027DF58FDDD2F8");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("products", "production", t =>
                        {
                            t.HasTrigger("trg_product_audit");
                        });
                });

            modelBuilder.Entity("BikeStore_API.Models.ProductAudit", b =>
                {
                    b.Property<int>("ChangeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("change_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChangeId"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("brand_id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("list_price");

                    b.Property<short>("ModelYear")
                        .HasColumnType("smallint")
                        .HasColumnName("model_year");

                    b.Property<string>("Operation")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("char(3)")
                        .HasColumnName("operation")
                        .IsFixedLength();

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("ChangeId")
                        .HasName("PK__product___F4EFE5963A831028");

                    b.ToTable("product_audits", "production");
                });

            modelBuilder.Entity("BikeStore_API.Models.ProductsInfo", b =>
                {
                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("brand_name");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("list_price");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_name");

                    b.ToTable((string)null);

                    b.ToView("products_info", (string)null);
                });

            modelBuilder.Entity("BikeStore_API.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("staff_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<byte>("Active")
                        .HasColumnType("tinyint")
                        .HasColumnName("active");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int")
                        .HasColumnName("manager_id");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("phone");

                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("store_id");

                    b.HasKey("StaffId")
                        .HasName("PK__staffs__1963DD9C8DDE7F17");

                    b.HasIndex("ManagerId");

                    b.HasIndex("StoreId");

                    b.HasIndex(new[] { "Email" }, "UQ__staffs__AB6E61649ED62473")
                        .IsUnique();

                    b.ToTable("staffs", "sales");
                });

            modelBuilder.Entity("BikeStore_API.Models.Stock", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("store_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("StoreId", "ProductId")
                        .HasName("PK__stocks__E68284D30D5A0BC0");

                    b.HasIndex("ProductId");

                    b.ToTable("stocks", "production");
                });

            modelBuilder.Entity("BikeStore_API.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("store_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<string>("City")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("city");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("phone");

                    b.Property<string>("State")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("state");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("store_name");

                    b.Property<string>("Street")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("street");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("zip_code");

                    b.HasKey("StoreId")
                        .HasName("PK__stores__A2F2A30CB5368569");

                    b.ToTable("stores", "sales");
                });

            modelBuilder.Entity("BikeStore_API.Models.TplEmp", b =>
                {
                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Sallary")
                        .HasColumnType("int");

                    b.HasIndex(new[] { "Sallary" }, "IX_PK_tblEmp");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex(new[] { "Sallary" }, "IX_PK_tblEmp"));

                    b.ToTable("tpl_Emp", (string)null);
                });

            modelBuilder.Entity("BikeStore_API.Models.Order", b =>
                {
                    b.HasOne("BikeStore_API.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__orders__customer__47DBAE45");

                    b.HasOne("BikeStore_API.Models.Staff", "Staff")
                        .WithMany("Orders")
                        .HasForeignKey("StaffId")
                        .IsRequired()
                        .HasConstraintName("FK__orders__staff_id__49C3F6B7");

                    b.HasOne("BikeStore_API.Models.Store", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__orders__store_id__48CFD27E");

                    b.Navigation("Customer");

                    b.Navigation("Staff");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("BikeStore_API.Models.OrderItem", b =>
                {
                    b.HasOne("BikeStore_API.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__order_ite__order__4D94879B");

                    b.HasOne("BikeStore_API.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__order_ite__produ__4E88ABD4");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BikeStore_API.Models.Product", b =>
                {
                    b.HasOne("BikeStore_API.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__products__brand___3C69FB99");

                    b.HasOne("BikeStore_API.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__products__catego__3B75D760");

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BikeStore_API.Models.Staff", b =>
                {
                    b.HasOne("BikeStore_API.Models.Staff", "Manager")
                        .WithMany("InverseManager")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK__staffs__manager___44FF419A");

                    b.HasOne("BikeStore_API.Models.Store", "Store")
                        .WithMany("Staff")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__staffs__store_id__440B1D61");

                    b.Navigation("Manager");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("BikeStore_API.Models.Stock", b =>
                {
                    b.HasOne("BikeStore_API.Models.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__stocks__product___52593CB8");

                    b.HasOne("BikeStore_API.Models.Store", "Store")
                        .WithMany("Stocks")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__stocks__store_id__5165187F");

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("BikeStore_API.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BikeStore_API.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BikeStore_API.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BikeStore_API.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BikeStore_API.Models.Product", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("BikeStore_API.Models.Staff", b =>
                {
                    b.Navigation("InverseManager");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BikeStore_API.Models.Store", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Staff");

                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
