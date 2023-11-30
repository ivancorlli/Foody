using System;
using Backend.Dto;
using Backend.Entity;
using Backend.Interface;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller;

public static class CategoryController
{

    public static async ValueTask<IResult> CreateCategory(
        [FromServices] CategoryService _service,
        [FromServices] IRepository<Category> _repo,
        [FromBody] CreateCategoryBody body
        )
    {
        try
        {
            Category newCat = await _service.Create(body.Name);
            await _repo.Create(newCat);
            return Results.Created(newCat.Id.ToString(),newCat);
        }
        catch (System.Exception ex)
        {
            return Results.BadRequest(new { Error = ex.Message.ToString() });
        }
    }
    public static IResult GetAllCategories(
    [FromServices] IRepository<Category> _repo
    )
    {
        try
        {
            IAsyncEnumerable<Category> all = _repo.GetAll();
            return Results.Ok(all);
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }
    }
    public static async ValueTask<IResult> ModifyCategory(
        [FromServices] IRepository<Category> _repo,
        [FromRoute] Guid CategoryId,
        [FromBody] ModifyCategoryBody body
        )
    {
        try
        {
            Category? category = await _repo.GetById(CategoryId);
            if(category == null) return Results.NotFound();
            category.ChangeName(body.Name);
            await _repo.SaveAsync();
            return Results.Ok();
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }
    }

     public static async ValueTask<IResult> GetById(
        [FromServices] IRepository<Category> _repo,
        [FromRoute] Guid CategoryId
        )
    {
        try
        {
            Category? category = await _repo.GetById(CategoryId);
            return Results.Ok(category);
        }
        catch (System.Exception)
        {
            return Results.BadRequest();
        }
    }


}
