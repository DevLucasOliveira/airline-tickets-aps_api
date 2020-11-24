using AirlineTickets.Api.Models;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace AirlineTickets.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<User>().Ignore(x => x.Token);
        }


    }
}
