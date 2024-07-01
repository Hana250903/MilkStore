using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models;

public partial class MilkstoreContext : DbContext
{
    public MilkstoreContext()
    {
    }

    public MilkstoreContext(DbContextOptions<MilkstoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Commentpicture> Commentpictures { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Milk> Milk { get; set; }

    public virtual DbSet<Milkpicture> Milkpictures { get; set; }

    public virtual DbSet<Milktype> Milktypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PRIMARY");

            entity.ToTable("admin");

            entity.HasIndex(e => e.UserId, "FK_Admin_User");

            entity.Property(e => e.Desciption).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Admins)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admin_User");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PRIMARY");

            entity.ToTable("brand");

            entity.Property(e => e.BrandName).HasMaxLength(50);
            entity.Property(e => e.Picture).HasMaxLength(500);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PRIMARY");

            entity.ToTable("comment");

            entity.HasIndex(e => e.MemberId, "FK_Comment_Member");

            entity.HasIndex(e => e.MilkId, "FK_Comment_Milk");

            entity.Property(e => e.Content).HasMaxLength(500);
            entity.Property(e => e.DateCreate).HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Member");

            entity.HasOne(d => d.Milk).WithMany(p => p.Comments)
                .HasForeignKey(d => d.MilkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_Milk");
        });

        modelBuilder.Entity<Commentpicture>(entity =>
        {
            entity.HasKey(e => e.CommentPictureId).HasName("PRIMARY");

            entity.ToTable("commentpicture");

            entity.HasIndex(e => e.CommentId, "FK_CommentPicture_Comment");

            entity.Property(e => e.Picture).HasMaxLength(500);

            entity.HasOne(d => d.Comment).WithMany(p => p.Commentpictures)
                .HasForeignKey(d => d.CommentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CommentPicture_Comment");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PRIMARY");

            entity.ToTable("member");

            entity.HasIndex(e => e.UserId, "FK_Member_User");

            entity.Property(e => e.Desciption).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Members)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Member_User");
        });

        modelBuilder.Entity<Milk>(entity =>
        {
            entity.HasKey(e => e.MilkId).HasName("PRIMARY");

            entity.ToTable("milk");

            entity.HasIndex(e => e.BrandId, "FK_Milk_Brand");

            entity.HasIndex(e => e.MilkTypeId, "FK_Milk_MilkType");

            entity.Property(e => e.AppropriateAge).HasMaxLength(50);
            entity.Property(e => e.Capacity).HasMaxLength(20);
            entity.Property(e => e.MilkName).HasMaxLength(150);
            entity.Property(e => e.StorageInstructions).HasMaxLength(300);

            entity.HasOne(d => d.Brand).WithMany(p => p.Milk)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Milk_Brand");

            entity.HasOne(d => d.MilkType).WithMany(p => p.Milk)
                .HasForeignKey(d => d.MilkTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Milk_MilkType");
        });

        modelBuilder.Entity<Milkpicture>(entity =>
        {
            entity.HasKey(e => e.MilkPictureId).HasName("PRIMARY");

            entity.ToTable("milkpicture");

            entity.HasIndex(e => e.MilkId, "FK_MilkPicture_Milk");

            entity.Property(e => e.Picture).HasMaxLength(500);

            entity.HasOne(d => d.Milk).WithMany(p => p.Milkpictures)
                .HasForeignKey(d => d.MilkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MilkPicture_Milk");
        });

        modelBuilder.Entity<Milktype>(entity =>
        {
            entity.HasKey(e => e.MilkTypeId).HasName("PRIMARY");

            entity.ToTable("milktype");

            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("order");

            entity.HasIndex(e => e.MemberId, "FK_Order_Member");

            entity.HasIndex(e => e.VoucherId, "FK_Order_Voucher");

            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.OrderStatus).HasMaxLength(20);

            entity.HasOne(d => d.Member).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Member");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK_Order_Voucher");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PRIMARY");

            entity.ToTable("orderdetail");

            entity.HasIndex(e => e.MilkId, "FK_OrderDetail_Milk");

            entity.HasIndex(e => e.OrderId, "FK_OrderDetail_Order");

            entity.HasOne(d => d.Milk).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.MilkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Milk");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderDetail_Order");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.RoleName).HasMaxLength(20);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PRIMARY");

            entity.ToTable("staff");

            entity.HasIndex(e => e.UserId, "FK_Staff_User");

            entity.Property(e => e.Desciption).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.Staff)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.RoleId, "FK_User_Role");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.DateCreate).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Phone).HasMaxLength(10);
            entity.Property(e => e.ProfilePicture).HasMaxLength(500);
            entity.Property(e => e.UserName).HasMaxLength(20);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.VoucherId).HasName("PRIMARY");

            entity.ToTable("voucher");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
