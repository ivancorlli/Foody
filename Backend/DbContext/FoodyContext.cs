using Microsoft.EntityFrameworkCore;
namespace Backend.DbContext;

public sealed class FoodyContext : DbContext
{
    public FoodyContext(DbContextOptions<FoodyContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
