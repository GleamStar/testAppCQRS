using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Contracts;

namespace Infrastructure
{
    public partial class TestContext : DbContext, ITestContext
    {
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }
        public async Task<bool> CommitAsync()
        {
            return await SaveChangesAsync() >= 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.Property(e => e.ClassId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Teacher)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.StudentId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gpa)
                    .HasColumnName("GPA")
                    .HasColumnType("decimal(3, 1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_To_Classes");
            });
        }
    }
}
