using Microsoft.EntityFrameworkCore;
using MyServer.Application.Interfaces;
using MyServer.Application.Mappings;
using MyServer.Application.Services;
using MyServer.Infrastructure.Persistence;
using MyServer.Infrastructure.Repositories;
using MyServer.Infrastructure.Services;
using StackExchange.Redis;

namespace MyServer.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();

        return services;
    }

    public static IServiceCollection AddDatabaseServices(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("DefaultConnection not found in configuration");

        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            var interceptor = sp.GetRequiredService<EfQueryTimingInterceptor>();
            options.UseSqlServer(connectionString);
            options.AddInterceptors(interceptor);

            if (environment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            }
        });

        return services;
    }

    public static IServiceCollection AddRedisServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var redisConnectionString = configuration.GetConnectionString("Redis")
            ?? "localhost:6379";

        services.AddSingleton<IConnectionMultiplexer>(serviceProvider =>
        {
            var logger = serviceProvider.GetService<ILogger<Program>>();

            try
            {
                return ConnectionMultiplexer.Connect(redisConnectionString);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Failed to connect to Redis at {ConnectionString}", redisConnectionString);
                throw;
            }
        });

        services.AddScoped<IRedisConfigService, RedisConfigService>();

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(PatientMappingProfile).Assembly);

        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IEpisodeRepository, EpisodeRepository>();
        services.AddScoped<IPerformanceService, PerformanceService>();
        services.AddScoped<EfQueryTimingInterceptor>();

        return services;
    }
}