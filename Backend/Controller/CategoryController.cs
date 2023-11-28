using Backend.Dto;
using Backend.Entity;
using Backend.Interface;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller;

public static class CategoryController
{

  public static IResult CreateCategory(
      [FromServices] CategoryService _service,
      [FromBody] CreateCategoryBody body
      )
  {
    try
    {
      Category newCat = _service.Create(body.Name);
      return Results.Created("", newCat);
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
      IEnumerable<Category> all = _repo.GetAll();
      return Results.Ok(all);
    }
    catch (System.Exception)
    {
      return Results.BadRequest();
    }
  }
  public static IResult ModifyCategory(
      [FromServices] IRepository<Category> _repo,
      [FromRoute] Guid CategoryId,
      [FromBody] ModifyCategoryBody body
      )
  {
    try
    {
      Category category = _repo.GetById(CategoryId);
      category.ChangeName(body.Name);
      _repo.Save(category);
      return Results.Ok();
    }
    catch (System.Exception)
    {
      return Results.BadRequest();
    }
  }

}
