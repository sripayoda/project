using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FootHub.Models;

public partial class FootHubContext : DbContext
{
    public FootHubContext()
    {
    }

    public FootHubContext(DbContextOptions<FootHubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BrandTable> BrandTables { get; set; }

    public virtual DbSet<CartTable> CartTables { get; set; }

    public virtual DbSet<OcassionTable> OcassionTables { get; set; }

    public virtual DbSet<OrderLinkTable> OrderLinkTables { get; set; }

    public virtual DbSet<OrderTable> OrderTables { get; set; }

    public virtual DbSet<ProductTable> ProductTables { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BrandTable>(entity =>
        {
            entity.HasKey(e => e.BId).HasName("brand_pri");

            entity.ToTable("BrandTable");

            entity.HasIndex(e => e.BName, "brand_unique").IsUnique();

            entity.Property(e => e.BId).HasColumnName("b_id");
            entity.Property(e => e.BName)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("b_name");
            entity.Property(e => e.IsAvailable).HasColumnName("isAvailable");
        });

        modelBuilder.Entity<CartTable>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("cart_pri");

            entity.ToTable("CartTable");

            entity.HasIndex(e => new { e.PId, e.UId }, "cart_unique").IsUnique();

            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.PId).HasColumnName("p_id");
            entity.Property(e => e.UId).HasColumnName("u_id");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.CartTables)
                .HasForeignKey(d => d.PId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_for2");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.CartTables)
                .HasForeignKey(d => d.UId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_for1");
        });

        modelBuilder.Entity<OcassionTable>(entity =>
        {
            entity.HasKey(e => e.OId).HasName("ocassion_pri");

            entity.ToTable("OcassionTable");

            entity.HasIndex(e => e.OName, "ocassion_unique").IsUnique();

            entity.Property(e => e.OId).HasColumnName("o_id");
            entity.Property(e => e.IsAvailable).HasColumnName("isAvailable");
            entity.Property(e => e.OName)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("o_name");
        });

        modelBuilder.Entity<OrderLinkTable>(entity =>
        {
            entity.HasKey(e => e.OrderLink).HasName("orderLink_pri");

            entity.ToTable("OrderLinkTable");

            entity.HasIndex(e => new { e.PId, e.UId, e.OrderId }, "orderLink_unique").IsUnique();

            entity.Property(e => e.OrderLink).HasColumnName("order_link");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PId).HasColumnName("p_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UId).HasColumnName("u_id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderLinkTables)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_fore0");

            entity.HasOne(d => d.PIdNavigation).WithMany(p => p.OrderLinkTables)
                .HasForeignKey(d => d.PId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_fore2");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.OrderLinkTables)
                .HasForeignKey(d => d.UId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_fore1");
        });

        modelBuilder.Entity<OrderTable>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("order_pri");

            entity.ToTable("OrderTable");

            entity.HasIndex(e => new { e.UId, e.OrderId }, "order_unique").IsUnique();

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderDate)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("order_date");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.UAddress)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("u_address");
            entity.Property(e => e.UId).HasColumnName("u_id");
            entity.Property(e => e.UName)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("u_name");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.OrderTables)
                .HasForeignKey(d => d.UId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_for");
        });

        modelBuilder.Entity<ProductTable>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("product_pri");

            entity.ToTable("ProductTable");

            entity.HasIndex(e => new { e.OId, e.TId, e.BId, e.PName, e.Size }, "product_unique").IsUnique();

            entity.Property(e => e.PId).HasColumnName("p_id");
            entity.Property(e => e.BId).HasColumnName("b_id");
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("category_name");
            entity.Property(e => e.OId).HasColumnName("o_id");
            entity.Property(e => e.PDesc)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("p_desc");
            entity.Property(e => e.PImage)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("p_image");
            entity.Property(e => e.PName)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("p_name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.TId).HasColumnName("t_id");
            entity.Property(e => e.TotalStock).HasColumnName("total_stock");

            entity.HasOne(d => d.BIdNavigation).WithMany(p => p.ProductTables)
                .HasForeignKey(d => d.BId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("brand_fore");

            entity.HasOne(d => d.OIdNavigation).WithMany(p => p.ProductTables)
                .HasForeignKey(d => d.OId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ocassion_fore");

            entity.HasOne(d => d.TIdNavigation).WithMany(p => p.ProductTables)
                .HasForeignKey(d => d.TId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("type_fore");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.TId).HasName("type_pri");

            entity.ToTable("ProductType");

            entity.HasIndex(e => e.TName, "productType_unique").IsUnique();

            entity.Property(e => e.TId).HasColumnName("t_id");
            entity.Property(e => e.IsAvailable).HasColumnName("isAvailable");
            entity.Property(e => e.TName)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("t_name");
        });

        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("user_pri");

            entity.ToTable("UserTable");

            entity.HasIndex(e => new { e.UEmail, e.UPhone }, "user_unique").IsUnique();

            entity.Property(e => e.UId).HasColumnName("u_id");
            entity.Property(e => e.UEmail)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("u_email");
            entity.Property(e => e.UName)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("u_name");
            entity.Property(e => e.UPassword)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("u_password");
            entity.Property(e => e.UPhone)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("u_phone");
            entity.Property(e => e.URole)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("u_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
