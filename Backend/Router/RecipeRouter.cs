using Backend.Controller;

namespace Backend.Router;

internal static class RecipeRouter
{
    internal static IEndpointRouteBuilder RecipeRoutes(this IEndpointRouteBuilder e)
    {
        e.MapGroup("/recipes")
        .Endpoints();
        return e;
    }

    private static IEndpointRouteBuilder Endpoints(this IEndpointRouteBuilder e)
    {
        e.MapPost("/", RecipeController.CreateRecipe);
        e.MapPatch("/{RecipeId}/ingridients", RecipeController.AddIngridient);
        e.MapPatch("/{RecipeId}/steps", RecipeController.AddStep);
        e.MapDelete("/{RecipeId}/ingridients", RecipeController.RemoveIngridient);
        e.MapDelete("/{RecipeId}/steps", RecipeController.RemoveStep);
        e.MapGet("/measurements", RecipeController.AllMeasurements);
        e.MapGet("/", RecipeController.AllRecipes);
        e.MapGet("/{RecipeId}", RecipeController.RecipeById);
        return e;
    }
}
