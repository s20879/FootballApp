using Microsoft.EntityFrameworkCore;

namespace FootballApp.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Footballer> Footballers { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-D0B461L\\DB01;Initial Catalog=FootballDatabase;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
        base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Footballer>(opt =>
            {
                opt.HasKey(e => e.IdFootballer);
                opt.Property(e => e.IdFootballer).ValueGeneratedOnAdd();
                opt.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                opt.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                opt.Property(e => e.Position).IsRequired().HasMaxLength(20);
                opt.HasOne(e => e.Country).WithMany(p => p.Footballers).HasForeignKey(e => e.IdCoutry).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Country>(opt =>
            {
                opt.HasKey(e => e.IdCountry);
                opt.Property(e => e.IdCountry).ValueGeneratedOnAdd();
                opt.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });
        }
    }
}
