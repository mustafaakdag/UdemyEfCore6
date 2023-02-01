using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EfCore.DatabaseFirstByScaffold.Models;

public partial class UdemyEfCoreDatabaseFirstDbContext : DbContext
{
    public UdemyEfCoreDatabaseFirstDbContext()
    {
    }

    public UdemyEfCoreDatabaseFirstDbContext(DbContextOptions<UdemyEfCoreDatabaseFirstDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=UdemyEfCoreDatabaseFirstDb;User ID=sa;Password=1234;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
