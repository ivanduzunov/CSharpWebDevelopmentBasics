using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Models;

namespace StudentSystem
{
    public class StudentSystemContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=StudentSystemDBContext;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourse>()
                .HasKey(sc => new {sc.StudentId, sc.CourseId});

            builder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithOne(sc => sc.Student)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(sc => sc.Course)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Resource>()
                .HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Homework>()
                .HasOne(h => h.Course)
                .WithMany(c => c.Homeworks)
                .HasForeignKey(h => h.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Homework>()
                .HasOne(h => h.Student)
                .WithMany(s => s.Homeworks)
                .HasForeignKey(h => h.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
