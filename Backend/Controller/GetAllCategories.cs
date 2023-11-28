using Backend.Entity;
using Backend.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller;

public static class GetAllCategories
{
  public static IResult Exec(
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
}
