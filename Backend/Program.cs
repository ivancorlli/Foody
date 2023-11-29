using Backend.Router;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.InstallExtensions(builder.Configuration);

var app = builder.Build();

app.ApiV1();

app.Run();
