using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BasicOperations.Domain.Entity;

public partial class MatiasContext : DbContext
{
    public MatiasContext()
    {
    }

    public MatiasContext(DbContextOptions<MatiasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OperationHistory> OperationHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=database-sql-server.chtzsvhnbqgw.ap-southeast-2.rds.amazonaws.com;Database=matias;User Id=admin;Password=Matias639;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OperationHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OPERATIO__3214EC27D71D6D15");

            entity.ToTable("OPERATION_HISTORY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("DATE");
            entity.Property(e => e.Observations)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("OBSERVATIONS");
            entity.Property(e => e.Operation)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("OPERATION");
            entity.Property(e => e.Result)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RESULT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
