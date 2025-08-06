using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Diagnostics;

public class EfQueryTimingInterceptor : DbCommandInterceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EfQueryTimingInterceptor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private void AddElapsedTime(long elapsedTicks)
    {
        if (_httpContextAccessor.HttpContext is null) return;
        var micros = elapsedTicks * 1_000_000L / Stopwatch.Frequency;
        var current = (long?)_httpContextAccessor.HttpContext.Items["EFQueryTimeMicros"] ?? 0;
        _httpContextAccessor.HttpContext.Items["EFQueryTimeMicros"] = current + micros;
    }

    public override DbDataReader ReaderExecuted(
        DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
    {
        AddElapsedTime(eventData.Duration.Ticks);
        return base.ReaderExecuted(command, eventData, result);
    }

    public override async ValueTask<DbDataReader> ReaderExecutedAsync(
        DbCommand command, CommandExecutedEventData eventData,
        DbDataReader result, CancellationToken cancellationToken = default)
    {
        AddElapsedTime(eventData.Duration.Ticks);
        return await base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
    }
}
