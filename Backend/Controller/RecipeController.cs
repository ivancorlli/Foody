using Backend.Dto;
using Backend.Entity;
using Backend.Enum;
using Backend.Interface;
using Backend.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller;


public static class RecipeController
{

    public static async ValueTask<IResult> CreateRecipe(
          [FromServices] IRepository<Recipe> _repo,
          [FromBody] CreateRecipeBody body
      )
    {
        try
        {
            Title title = new(body.Title);
            Description description = new(body.Description);
            Recipe newRecipe = new(title, description, body.CategoryId);
            await _repo.Create(newRecipe);
            return Results.Created(newRecipe.Id.ToString(), newRecipe);
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }
    }

    public static async ValueTask<IResult> ModifyRecipe(
          [FromServices] IRepository<Recipe> _repo,
          [FromBody] ModifyRecipeBody body,
          [FromRoute] Guid RecipeId
      )
    {
        try
        {
            Title title = new(body.Title);
            Description description = new(body.Description);
            Recipe? recipe = await _repo.GetById(RecipeId);
            if (recipe == null) return Results.NotFound();
            recipe.ChangeDescription(description);
            recipe.ChangeTitle(title);
            await _repo.SaveAsync();
            return Results.Ok();
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }
    }

    public static IResult AllMeasurements()
    {
        try
        {
            IList<string> measurements = new List<string>()
            {
              Measure.Cup.ToString(),
              Measure.Gram.ToString(),
              Measure.Liter.ToString(),
              Measure.Ounce.ToString(),
              Measure.Pound.ToString(),
              Measure.Celsius.ToString(),
              Measure.Miligram.ToString(),
              Measure.Teaspoon.ToString(),
              Measure.Mililiter.ToString(),
              Measure.Fahrenheit.ToString(),
              Measure.Unit.ToString()
            };

            return Results.Ok(measurements);
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }
    }


    public static async ValueTask<IResult> AddIngridient(
        [FromServices] IRepository<Recipe> _repo,
        [FromBody] IngridientRecipeBody body,
        [FromRoute] Guid RecipeId
        )
    {
        try
        {
            Ingridient ingridient = new(body.Name, body.Qty, body.Measure);
            Recipe? recipe = await _repo.GetById(RecipeId);
            if (recipe == null) return Results.NotFound();
            recipe.AddIngridient(ingridient);
            await _repo.SaveAsync();
            return Results.Ok();
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }
    }

    public static async ValueTask<IResult> RemoveIngridient(
        [FromServices] IRepository<Recipe> _repo,
        [FromBody] IngridientRecipeBody body,
        [FromRoute] Guid RecipeId
        )
    {
        try
        {
            Ingridient ingridient = new(body.Name, body.Qty, body.Measure);
            Recipe? recipe = await _repo.GetById(RecipeId);
            if (recipe == null) return Results.NotFound();
            recipe.RemoveIngridient(ingridient);
            return Results.Ok();
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }

    }

    public static async ValueTask<IResult> AddStep(
        [FromServices] IRepository<Recipe> _repo,
        [FromBody] StepRecipeBody body,
        [FromRoute] Guid RecipeId
        )
    {
        try
        {
            Step step = new(body.Name, body.Description, body.Picture);
            Recipe? recipe = await _repo.GetById(RecipeId);
            if (recipe == null) return Results.NotFound();
            recipe.AddStep(step);
            return Results.Ok();
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }
    }
    public static async ValueTask<IResult> RemoveStep(
        [FromServices] IRepository<Recipe> _repo,
        [FromBody] StepRecipeBody body,
        [FromRoute] Guid RecipeId
        )
    {
        try
        {
            Step step = new(body.Name, body.Description, body.Picture);
            Recipe? recipe = await _repo.GetById(RecipeId);
            if (recipe == null) return Results.NotFound();
            recipe.RemoveStep(step);
            return Results.Ok();
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }
    }

    public static IResult AllRecipes(
        [FromServices] IRepository<Recipe> _repo
       )
    {
        try
        {
            IAsyncEnumerable<Recipe> recipes = _repo.GetAll();
            return Results.Ok(recipes);
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }
    }

    public static async ValueTask<IResult> RecipeById(
        [FromServices] IRepository<Recipe> _repo,
        [FromRoute] Guid RecipeId
        )
    {
        try
        {
            Recipe? recipe = await _repo.GetById(RecipeId);
            if (recipe == null) return Results.NotFound();
            return Results.Ok(recipe);
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }
    }

}
