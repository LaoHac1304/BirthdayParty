using System;
using System.Collections.Generic;
using BirthdayParty.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BirthdayParty.Domain.DbContexts;

public partial class PartydbContext : DbContext
{
    public PartydbContext()
    {
    }

    public PartydbContext(DbContextOptions<PartydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<HostParty> HostParties { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<PartyPackage> PartyPackages { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=database-1.c7cae8e8mcxf.ap-southeast-2.rds.amazonaws.com;uid=admin;pwd=7LwPyzbw4KfMBu6;database=partydb");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("account");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");

            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_deleted");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");

            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("customer");

            entity.HasIndex(e => e.UserId, "FK__customer__user_i__02084FDA");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("phone_number");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.DayOfBirth)
                .HasMaxLength(6)
                .HasColumnName("day_of_birth");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_deleted");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasMaxLength(64)
                .HasColumnName("user_id");

            //entity.HasOne(d => d.User).WithMany(p => p.Customers)
            //    .HasForeignKey(d => d.UserId)
            //    .HasConstraintName("FK__customer__user_i__02084FDA");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("discount");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.DiscountPercent).HasColumnName("discount_percent");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_deleted");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<HostParty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("host_party");

            entity.HasIndex(e => e.UserId, "FK__host_part__user___02FC7413");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("phone_number");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_deleted");
            entity.Property(e => e.Rating)
                .HasMaxLength(255)
                .HasColumnName("rating");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasMaxLength(64)
                .HasColumnName("user_id");

            //entity.HasOne(d => d.User).WithMany(p => p.HostParties)
            //    .HasForeignKey(d => d.UserId)
            //    .HasConstraintName("FK__host_part__user___02FC7413");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("menu");

            entity.HasIndex(e => e.PartyPackageId, "FK__menu__party_pack__7D439ABD");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_deleted");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PartyPackageId)
                .HasMaxLength(64)
                .HasColumnName("party_package_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");

            entity.HasOne(d => d.PartyPackage).WithMany(p => p.Menus)
                .HasForeignKey(d => d.PartyPackageId)
                .HasConstraintName("FK__menu__party_pack__75A278F5");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("message");

            entity.HasIndex(e => e.ReceiverId, "FK__message__receive__04E4BC85");

            entity.HasIndex(e => e.SenderId, "FK__message__sender___03F0984C");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_deleted");
            entity.Property(e => e.ReceiverId)
                .HasMaxLength(64)
                .HasColumnName("receiver_id");
            entity.Property(e => e.SenderId)
                .HasMaxLength(64)
                .HasColumnName("sender_id");
            entity.Property(e => e.SentAt)
                .HasMaxLength(6)
                .HasColumnName("sent_at");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");

            //entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers)
            //    .HasForeignKey(d => d.ReceiverId)
            //    .HasConstraintName("FK__message__receive__04E4BC85");

            //entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders)
            //    .HasForeignKey(d => d.SenderId)
            //    .HasConstraintName("FK__message__sender___03F0984C");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("order_detail");

            entity.HasIndex(e => e.CustomerId, "FK__order_det__custo__7E37BEF6");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(64)
                .HasColumnName("customer_id");
            entity.Property(e => e.Date)
                .HasMaxLength(6)
                .HasColumnName("date");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_deleted");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");

            //entity.HasOne(d => d.Customer).WithMany(p => p.OrderDetails)
            //    .HasForeignKey(d => d.CustomerId)
            //    .HasConstraintName("FK__order_det__custo__76969D2E");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("order_items");

            entity.HasIndex(e => e.OrderDetailId, "FK__order_ite__order__7F2BE32F");

            entity.HasIndex(e => e.PartyPackageId, "FK__order_ite__party__787EE5A0");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Date)
                .HasMaxLength(6)
                .HasColumnName("date");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_deleted");
            entity.Property(e => e.IsPreorder).HasColumnName("is_preorder");
            entity.Property(e => e.OrderDetailId)
                .HasMaxLength(64)
                .HasColumnName("order_detail_id");
            entity.Property(e => e.PartyPackageId)
                .HasMaxLength(64)
                .HasColumnName("party_package_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderDetailId)
                .HasConstraintName("FK__order_ite__order__778AC167");

            entity.HasOne(d => d.PartyPackage).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.PartyPackageId)
                .HasConstraintName("FK__order_ite__party__00200768");
        });

        modelBuilder.Entity<PartyPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("party_package");

            entity.HasIndex(e => e.DiscountId, "FK__party_pac__disco__05D8E0BE");

            entity.HasIndex(e => e.HostPartyId, "FK__party_pac__host___7B5B524B");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.AvailableDates)
                .HasMaxLength(6)
                .HasColumnName("available_dates");
            entity.Property(e => e.AvailableForPreorder).HasColumnName("available_for_preorder");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DiscountId)
                .HasMaxLength(64)
                .HasColumnName("discount_id");
            entity.Property(e => e.HostPartyId)
                .HasMaxLength(64)
                .HasColumnName("host_party_id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_deleted");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Discount).WithMany(p => p.PartyPackages)
                .HasForeignKey(d => d.DiscountId)
                .HasConstraintName("FK__party_pac__disco__05D8E0BE");

            entity.HasOne(d => d.HostParty).WithMany(p => p.PartyPackages)
                .HasForeignKey(d => d.HostPartyId)
                .HasConstraintName("FK__party_pac__host___73BA3083");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("payment_detail");

            entity.HasIndex(e => e.OrderDetailId, "FK__payment_d__order__797309D9");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_deleted");
            entity.Property(e => e.OrderDetailId)
                .HasMaxLength(64)
                .HasColumnName("order_detail_id");
            entity.Property(e => e.Provider)
                .HasMaxLength(255)
                .HasColumnName("provider");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.OrderDetailId)
                .HasConstraintName("FK__payment_d__order__01142BA1");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("post");

            entity.HasIndex(e => e.PartyPackageId, "FK__post__party_pack__7C4F7684");

            entity.Property(e => e.Id)
                .HasMaxLength(64)
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.Date)
                .HasMaxLength(6)
                .HasColumnName("date");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_deleted");
            entity.Property(e => e.PartyPackageId)
                .HasMaxLength(64)
                .HasColumnName("party_package_id");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");

            entity.HasOne(d => d.PartyPackage).WithMany(p => p.Posts)
                .HasForeignKey(d => d.PartyPackageId)
                .HasConstraintName("FK__post__party_pack__74AE54BC");
        });

        modelBuilder.Entity<Sysdiagram>(entity =>
        {
            entity.HasKey(e => e.DiagramId).HasName("PRIMARY");

            entity.ToTable("sysdiagrams");

            entity.HasIndex(e => new { e.PrincipalId, e.Name }, "UK_principal_name").IsUnique();

            entity.Property(e => e.DiagramId).HasColumnName("diagram_id");
            entity.Property(e => e.Definition).HasColumnName("definition");
            entity.Property(e => e.Name)
                .HasMaxLength(160)
                .HasColumnName("name");
            entity.Property(e => e.PrincipalId).HasColumnName("principal_id");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
