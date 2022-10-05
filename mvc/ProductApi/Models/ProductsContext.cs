using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductApi.Models;

public partial class ProductsContext : DbContext
{
    public ProductsContext()
    {
    }

    public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; } = null!;

    public virtual DbSet<Image> Images { get; set; } = null!;

    public virtual DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__category__D54EE9B46C3C082D");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnOrder(0)
                .HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnOrder(1)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageLink).HasName("PK__image__5F19F8C45347C091");

            entity.ToTable("image");

            entity.Property(e => e.ImageLink)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnOrder(0)
                .HasColumnName("image_link");
            entity.Property(e => e.Id)
                .HasColumnOrder(1)
                .HasColumnName("id");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.Images)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__image__id__2A4B4B5E");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product__3213E83F2DAA64B1");

            entity.ToTable("product");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnOrder(0)
                .HasColumnName("id");
            entity.Property(e => e.Brand)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnOrder(7)
                .HasColumnName("brand");
            entity.Property(e => e.CategoryId)
                .HasColumnOrder(8)
                .HasColumnName("category_id");
            entity.Property(e => e.Descrip)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnOrder(2)
                .HasColumnName("descrip");
            entity.Property(e => e.DiscountPercentage)
                .HasColumnOrder(4)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("discount_percentage");
            entity.Property(e => e.Price)
                .HasColumnOrder(3)
                .HasColumnName("price");
            entity.Property(e => e.Rating)
                .HasColumnOrder(5)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("rating");
            entity.Property(e => e.Stock)
                .HasColumnOrder(6)
                .HasDefaultValueSql("((0))")
                .HasColumnName("stock");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnOrder(9)
                .HasColumnName("thumbnail");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnOrder(1)
                .HasColumnName("title");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__product__categor__276EDEB3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
