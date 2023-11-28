namespace Backend.Router;

public static class Index
{
    public static IEndpointRouteBuilder ApiV1(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGroup("/api")
          .CategoryRoutes();
        return endpoints;
    }
}
