using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyServer.Application.Interfaces;
using MyServer.Application.Mappings;
using MyServer.Application.Services;
using MyServer.Infrastructure.Persistence;
using MyServer.Infrastructure.Repositories;
using MyServer.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITodoRepository, EfTodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.LogTo(Console.WriteLine, LogLevel.Information); // Logs SQL to console
});
builder.Services.AddAutoMapper(typeof(PatientMappingProfile).Assembly);
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
