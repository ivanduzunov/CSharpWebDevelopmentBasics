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

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                 .HasIndex(u => u.Email)
                 .IsUnique();

            //Ticket
            builder.Entity<Ticket>()
                .HasOne(t => t.Customer)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Ticket>()
                .HasOne(t => t.Flight)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.FlightId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
