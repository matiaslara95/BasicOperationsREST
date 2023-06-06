using System;
using System.Collections.Generic;
using BasicOperations.Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BasicOperations.Entity.Models;

public partial class BasicOperationsContext : IdentityDbContext<User>
{
    public BasicOperationsContext(DbContextOptions options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    //public DbSet<Company> Companies { get; set; }
    //public DbSet<Employee> Employees { get; set; }


    //public virtual DbSet<OperationHistory> OperationHistories { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=database-sql-server.chtzsvhnbqgw.ap-southeast-2.rds.amazonaws.com;Database=matias;User Id=admin;Password=Admin123;TrustServerCertificate=True");

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<OperationHistory>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK__OPERATIO__3214EC27D71D6D15");

    //        entity.ToTable("OPERATION_HISTORY");

    //        entity.Property(e => e.Id).HasColumnName("ID");
    //        entity.Property(e => e.Date)
    //            .HasColumnType("datetime")
    //            .HasColumnName("DATE");
    //        entity.Property(e => e.Observations)
    //            .HasMaxLength(255)
    //            .IsUnicode(false)
    //            .HasColumnName("OBSERVATIONS");
    //        entity.Property(e => e.Operation)
    //            .HasMaxLength(25)
    //            .IsUnicode(false)
    //            .HasColumnName("OPERATION");
    //        entity.Property(e => e.Result)
    //            .HasMaxLength(255)
    //            .IsUnicode(false)
    //            .HasColumnName("RESULT");
    //    });

    //    OnModelCreatingPartial(modelBuilder);
    //}

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
