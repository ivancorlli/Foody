using Backend.Dto;
using Backend.Entity;
using Backend.Enum;
using Backend.Interface;
using Backend.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller;


public static class RecipeController
{

    public static IResult CreateRecipe(
          [FromServices] IRepository<Recipe> _repo,
          [FromBody] CreateRecipeBody body
      )
    {
        try
        {
            Title title = new(body.Title);
            Description description = new(body.Description);
            Recipe newRecipe = new(title, description, body.CategoryId);
            _repo.Create(newRecipe);
            return Results.Created("", newRecipe);
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
              Measure.Fahrenheit.ToString()
            };

            return Results.Ok(measurements);
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }
    }


    public static IResult AddIngridient(
        [FromServices] IRepository<Recipe> _repo,
        [FromBody] IngridientRecipeBody body,
        [FromRoute] Guid RecipeId
        )
    {
        try
        {
            Ingridient ingridient = new(body.Name, body.Qty, body.Measure);
            Recipe recipe = _repo.GetById(RecipeId);
            recipe.AddIngridient(ingridient);
            return Results.Ok();
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }
    }

    public static IResult RemoveIngridient(
        [FromServices] IRepository<Recipe> _repo,
        [FromBody] IngridientRecipeBody body,
        [FromRoute] Guid RecipeId
        )
    {
        try
        {
            Ingridient ingridient = new(body.Name, body.Qty, body.Measure);
            Recipe recipe = _repo.GetById(RecipeId);
            recipe.RemoveIngridient(ingridient);
            return Results.Ok();
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }

    }

}
