using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Backend.Context;

public class DbContextFactory : IDesignTimeDbContextFactory<FoodyContext>
{
    public FoodyContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FoodyContext>();
        optionsBuilder.UseSqlServer(args[0].ToString().Trim());

        return new FoodyContext(optionsBuilder.Options);
    }
}
