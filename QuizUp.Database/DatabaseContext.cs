using Microsoft.EntityFrameworkCore;
using QuizUp.Models;

namespace QuizUp.Database
{
    public class DatabaseContext : DbContext
    {
        private string _databasePath;

        public DbSet<User> Users { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Result> Results { get; set; }

        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"FileName={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().Ignore(t => t.Choices);
            base.OnModelCreating(modelBuilder);
        }
    }
}
