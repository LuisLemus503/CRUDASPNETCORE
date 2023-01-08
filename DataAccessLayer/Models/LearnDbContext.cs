using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

public partial class LearnDbContext : DbContext
{
    public LearnDbContext()
    {
    }

    public LearnDbContext(DbContextOptions<LearnDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__TblEmplo__CE6D8B9ECCC15FE2");

            entity.ToTable("TblEmployee");

            entity.Property(e => e.FechadeIngreso).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Salario).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
