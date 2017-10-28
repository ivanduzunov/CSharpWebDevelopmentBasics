using System;
using System.Collections.Generic;
using System.Text;

namespace ModPanel.App.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ModPanelDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=ModPanelDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                 .HasIndex(u => u.Email)
                 .IsUnique();
        }
    }
}
