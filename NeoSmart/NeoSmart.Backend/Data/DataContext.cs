using Microsoft.EntityFrameworkCore;
using NeoSmart.Shared.Entities;

namespace NeoSmart.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CapacitationTheme> CapacitationsThemes { get; set; }

        public DbSet<Capacitation> Capacitations { get; set; }

        public DbSet<Theme> Themes { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Coaching> Coachings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CapacitationTheme>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Capacitation>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Theme>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Position>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Coaching>().HasIndex(s => new { s.PositionId, s.Name }).IsUnique();
            modelBuilder.Entity<User>().HasIndex(c => c.Document).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex(s => new { s.CountryId, s.Name }).IsUnique();
            modelBuilder.Entity<City>().HasIndex(c => new { c.StateId, c.Name }).IsUnique();
        }
    }
}
