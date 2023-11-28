using Backend.Dto;
using Backend.Entity;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller;


public static class CreateCategory
{

  public static IResult Exec(
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

}
