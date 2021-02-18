using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolApp.Entities;

#nullable disable

namespace SchoolApp.Data
{
    public partial class SchoolAppDbContext : DbContext
    {
        public SchoolAppDbContext()
        {
        }

        public SchoolAppDbContext(DbContextOptions<SchoolAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SchoolClass> SchoolClasses { get; set; }
        public virtual DbSet<SchoolClassesCourse> SchoolClassesCourses { get; set; }
        public virtual DbSet<SchoolClassesStudent> SchoolClassesStudents { get; set; }
        public virtual DbSet<SchoolCourse> SchoolCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SchoolClass>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TeacherId).HasMaxLength(450);

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<SchoolClassesCourse>(entity =>
            {
                entity.HasKey(e => new { e.SchoolClassId, e.SchoolCourseId })
                    .HasName("PK__SchoolCl__EDA3F0A35C27C374");

                entity.Property(e => e.TeacherId).HasMaxLength(450);

                entity.HasOne(d => d.SchoolClass)
                    .WithMany(p => p.SchoolClassesCourses)
                    .HasForeignKey(d => d.SchoolClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchoolCla__Schoo__2A4B4B5E");

                entity.HasOne(d => d.SchoolCourse)
                    .WithMany(p => p.SchoolClassesCourses)
                    .HasForeignKey(d => d.SchoolCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchoolCla__Schoo__2B3F6F97");
            });

            modelBuilder.Entity<SchoolClassesStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__SchoolCl__32C52B99FBA0FFA1");

                entity.HasOne(d => d.SchoolClass)
                    .WithMany(p => p.SchoolClassesStudents)
                    .HasForeignKey(d => d.SchoolClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchoolCla__Schoo__276EDEB3");
            });

            modelBuilder.Entity<SchoolCourse>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
