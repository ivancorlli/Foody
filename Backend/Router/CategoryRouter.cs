using Backend.Controller;
namespace Backend.Router;

internal static class CategoryRouter
{
    internal static IEndpointRouteBuilder CategoryRoutes(this IEndpointRouteBuilder e)
    {
        e.MapGroup("/categories").MapEndpoints();
        return e;
    }

    private static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder e)
    {
        e.MapPost("/", CategoryController.CreateCategory);
        e.MapGet("/", CategoryController.GetAllCategories);
        e.MapPatch("/{CategoryId}", CategoryController.ModifyCategory);
        e.MapGet("/{CategoryId}", CategoryController.GetById);
        return e;
    }


}
