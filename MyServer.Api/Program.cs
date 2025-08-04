using MyServer.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();
builder.Services.AddDatabaseServices(builder.Configuration, builder.Environment);
builder.Services.AddRedisServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

app.ConfigurePipeline();

app.Run();
