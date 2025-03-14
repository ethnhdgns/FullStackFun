using Microsoft.EntityFrameworkCore;

namespace FullStackFun.Data
{
    public class BowlerDBContext : DbContext
    {
        public BowlerDBContext(DbContextOptions<BowlerDBContext> options) : base(options) { }

        public DbSet<Bowler> Bowlers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bowler>()
                .HasKey(b => b.BowlerID); // Ensure Primary Key is set

            modelBuilder.Entity<Bowler>()
                .Property(b => b.BowlerID)
                .ValueGeneratedNever(); // Ensures ID is manually inserted

            base.OnModelCreating(modelBuilder);
        }
    }
}