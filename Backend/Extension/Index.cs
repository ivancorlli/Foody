
using System.Text.Json.Serialization;
using Backend.Context;
using Backend.Entity;
using Backend.Interface;
using Backend.Repository;
using Backend.Service;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

public static class Index
{

    public static IServiceCollection InstallExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
        services.ConfigureDb(configuration);
        services.ConfigureRepository();
        return services;
    }

    internal static IServiceCollection ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Category>, CategoryRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IRepository<Recipe>, RecipeRepository>();
        services.AddScoped<CategoryService>();
        return services;
    }

    internal static IServiceCollection ConfigureDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FoodyContext>(opts =>
        {
            opts.UseSqlServer(configuration.GetConnectionString("Database"))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
        });
        return services;
    }
}