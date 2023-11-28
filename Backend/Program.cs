using Backend.Entity;
using Backend.Interface;
using Backend.Router;
using Backend.Service;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddScoped<IRepository<Category>>();
services.AddScoped<IRepository<Recipe>>();
services.AddScoped<CategoryService>();


var app = builder.Build();

app.ApiV1();

app.Run();
