using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            Environment.GetEnvironmentVariable("ConnectionStrings:DefaultConnection")
                ?? "Server=(localdb)\\mssqllocaldb;Database=FirstDbContextSetupDb;Trusted_Connection=True;MultipleActiveResultSets=true"
        );
        base.OnConfiguring(optionsBuilder);
    }
}
