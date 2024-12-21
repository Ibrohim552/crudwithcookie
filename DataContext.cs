using Microsoft.EntityFrameworkCore;

namespace BlazorCrud;

public class DataContext:DbContext
{
    public DbSet<Developer> Developers { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Developer>().ToTable("Developers");
    }
}