using Backend.Router;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.InstallExtensions(builder.Configuration);

services.AddCors(options =>
    {
      options.AddDefaultPolicy(builder =>
      {
        builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader();
      });
    });

var app = builder.Build();
app.UseCors();
app.ApiV1();

app.Run();
