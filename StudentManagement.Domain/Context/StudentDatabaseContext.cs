using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentManagement.Api.Models;

namespace StudentManagement.Domain.Context;
public partial class StudentDatabaseContext : DbContext
{
    public StudentDatabaseContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<StudentDetail> StudentDetails { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentDetail>(entity =>
        {
            entity.Property(e => e.Address)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.BloodGroup)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Class)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.DateOfBirth)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
