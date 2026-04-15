using System.Diagnostics;

namespace JobAPI.Middlewares
{
    public class LogRequestMiddleware
    {
        public readonly ILogger<LogRequestMiddleware> _logger;
        public readonly RequestDelegate _next;
        public LogRequestMiddleware(ILogger<LogRequestMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();
            _logger.LogInformation($"{context.Request.Method} {context.Request.Path} → {context.Response.StatusCode} (took {stopwatch.ElapsedMilliseconds}ms)");
        }
    }
}