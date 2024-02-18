using System;
using System.Collections.Generic;
using BirthdayParty.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BirthdayParty.Domain.DbContexts;

public partial class PartyDbContext : DbContext
{
    public PartyDbContext()
    {
    }

    public PartyDbContext(DbContextOptions<PartyDbContext> options)
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .Build();
        var strConn = config["ConnectionStrings:PartyDB"];

        return strConn;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__account__3213E83FEE1F2B60");

            entity.ToTable("account");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_deleted");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("phone_number");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83F4BA41AEA");

            entity.ToTable("customer");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DayOfBirth)
                .HasPrecision(6)
                .HasColumnName("day_of_birth");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_deleted");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__customer__user_i__02084FDA");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__discount__3213E83F8F327274");

            entity.ToTable("discount");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DiscountPercent)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("discount_percent");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_deleted");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<HostParty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__host_par__3213E83F372F2D9D");

            entity.ToTable("host_party");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_deleted");
            entity.Property(e => e.Rating)
                .HasMaxLength(255)
                .HasColumnName("rating");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.HostParties)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__host_part__user___02FC7413");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__menu__3213E83F13C84465");

            entity.ToTable("menu");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_deleted");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PartyPackageId).HasColumnName("party_package_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.PartyPackage).WithMany(p => p.Menus)
                .HasForeignKey(d => d.PartyPackageId)
                .HasConstraintName("FK__menu__party_pack__75A278F5");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__message__3213E83FA863F64E");

            entity.ToTable("message");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_deleted");
            entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.SentAt)
                .HasPrecision(6)
                .HasColumnName("sent_at");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK__message__receive__04E4BC85");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__message__sender___03F0984C");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_de__3213E83F88D7431F");

            entity.ToTable("order_detail");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Date)
                .HasPrecision(6)
                .HasColumnName("date");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_deleted");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total_price");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__order_det__custo__76969D2E");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_it__3213E83F3AD7CD6F");

            entity.ToTable("order_items");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Date)
                .HasPrecision(6)
                .HasColumnName("date");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_deleted");
            entity.Property(e => e.IsPreorder).HasColumnName("is_preorder");
            entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");
            entity.Property(e => e.PartyPackageId).HasColumnName("party_package_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
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
            entity.HasKey(e => e.Id).HasName("PK__party_pa__3213E83FA1B7348A");

            entity.ToTable("party_package");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AvailableDates)
                .HasPrecision(6)
                .HasColumnName("available_dates");
            entity.Property(e => e.AvailableForPreorder).HasColumnName("available_for_preorder");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DiscountId).HasColumnName("discount_id");
            entity.Property(e => e.HostPartyId).HasColumnName("host_party_id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
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
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
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
            entity.HasKey(e => e.Id).HasName("PK__payment___3213E83F91C57710");

            entity.ToTable("payment_detail");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_deleted");
            entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");
            entity.Property(e => e.Provider)
                .HasMaxLength(255)
                .HasColumnName("provider");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.OrderDetailId)
                .HasConstraintName("FK__payment_d__order__01142BA1");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__post__3213E83F32E9ECCF");

            entity.ToTable("post");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Date)
                .HasPrecision(6)
                .HasColumnName("date");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((0))")
                .HasColumnName("is_deleted");
            entity.Property(e => e.PartyPackageId).HasColumnName("party_package_id");
            entity.Property(e => e.UpdatedAt)
                .HasPrecision(6)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.PartyPackage).WithMany(p => p.Posts)
                .HasForeignKey(d => d.PartyPackageId)
                .HasConstraintName("FK__post__party_pack__74AE54BC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
