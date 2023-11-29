using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Backend.DbContext;

public class DbContextFactory : IDesignTimeDbContextFactory<FoodyContext>
{
    public FoodyContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FoodyContext>();
        optionsBuilder.UseSqlServer();

        return new FoodyContext(optionsBuilder.Options);
    }
}
