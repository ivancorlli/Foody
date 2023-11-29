
using Backend.Context;
using Backend.Entity;
using Backend.Interface;
using Backend.Service;
using Microsoft.EntityFrameworkCore;

public static class Index
{

    public static IServiceCollection InstallExtensions(this IServiceCollection services,IConfiguration configuration)
    {
        services.ConfigureDb(configuration);
        services.ConfigureRepository();
        return services;
    }

    internal static IServiceCollection ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Category>>();
        services.AddScoped<IRepository<Recipe>>();
        services.AddScoped<CategoryService>();
        return services;
    }

    internal static IServiceCollection ConfigureDb(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<FoodyContext>(opts=>{
            opts.UseSqlServer(configuration.GetConnectionString("Database"))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
        });
        return services;
    }
}