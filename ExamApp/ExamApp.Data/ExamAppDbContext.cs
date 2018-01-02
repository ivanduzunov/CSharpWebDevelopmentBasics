namespace ExamApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ExamAppDbContext : DbContext
    {       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=ExamAppDb;Integrated Security=True;");
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                 .HasIndex(u => u.Email)
                 .IsUnique();
        }
    }
}
