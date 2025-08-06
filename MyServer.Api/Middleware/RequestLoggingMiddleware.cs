using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation("MIDDLEWARE RUNNING for {path}", context.Request.Path);

        var stopwatch = Stopwatch.StartNew();
        var startMemory = GC.GetTotalMemory(forceFullCollection: false);

        // Start a query timer accumulator
        context.Items["EFQueryTime"] = TimeSpan.Zero;

        await _next(context);

        stopwatch.Stop();
        var endMemory = GC.GetTotalMemory(forceFullCollection: false);
        var memoryUsedKB = (endMemory - startMemory) / 1024;

        var totalDbMicro = (long?)context.Items["EFQueryTimeMicros"] ?? 0;

        _logger.LogInformation(
              "Request {method} {path} completed in {durationMs} ms | DB time: {dbTimeUs} µs | Memory used: {memoryKb} KB",
              context.Request.Method,
              context.Request.Path,
              stopwatch.ElapsedMilliseconds,
              totalDbMicro,
              memoryUsedKB
        );
    }
}
