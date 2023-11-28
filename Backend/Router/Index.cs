namespace Backend.Router;

public static class Index
{
  public static IEndpointRouteBuilder FoodyRouter(this IEndpointRouteBuilder endpoints)
  {
    endpoints.MapGroup("/api")
      .CategoryRoutes();
    return endpoints;
  }
}
