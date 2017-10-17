using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyCoolWebServer.GameStoreApplication.Models;

namespace MyCoolWebServer.GameStoreApplication.Data
{
    public class GameStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<UserGame> UserGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=GameStoreDb;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserGame>()
                .HasKey(ug => new {ug.UserId, ug.GameId});

            builder.Entity<User>()
                .HasMany(u => u.Games)
                .WithOne(ug => ug.User)
                .HasForeignKey(ug => ug.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
                .HasMany(u => u.Users)
                .WithOne(ug => ug.Game)
                .HasForeignKey(ug => ug.GameId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
