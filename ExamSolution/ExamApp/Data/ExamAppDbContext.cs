using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ExamAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Submission> Simissions { get; set; }

        public DbSet<Contest> Contests { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=JudgeAppDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                 .HasIndex(u => u.Email)
                 .IsUnique();

            builder.Entity<User>()
                .HasMany(u => u.Contests)
                .WithOne(uc => uc.Creator)
                .HasForeignKey(uc => uc.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasMany(u => u.Submitions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Contest>()
                .HasMany(c => c.Submitions)
                .WithOne(s => s.Contest)
                .HasForeignKey(s => s.ContestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
