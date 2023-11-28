using Backend.Dto;
using Backend.Entity;
using Backend.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller;


public static class ModifyCategory
{
  public static IResult Exec(
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
