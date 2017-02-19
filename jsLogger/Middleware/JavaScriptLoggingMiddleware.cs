using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace jsLogger
{
    public class JavaScriptLoggingMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public JavaScriptLoggingMiddleware(ILoggerFactory loggerFactory, RequestDelegate next)
        {
            _logger = loggerFactory.CreateLogger<JavaScriptLoggingMiddleware>();
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/log" && context.Request.Method == "POST" && context.Request.HasFormContentType)
            {
                var form = await context.Request.ReadFormAsync();
                var level = Convert.ToInt32(form["level"].First());
                var message = form["message"].First();

                switch ((LogLevel)level)
                {
                    case LogLevel.Trace:
                        _logger.LogTrace(message);
                        break;
                    case LogLevel.Debug:
                        _logger.LogDebug(message);
                        break;
                    case LogLevel.Information:
                        _logger.LogInformation(message);
                        break;
                    case LogLevel.Warning:
                        _logger.LogWarning(message);
                        break;
                    case LogLevel.Error:
                        _logger.LogError(message);
                        break;
                    default:
                        return;
                }
            }
            else
            {
                await _next(context);
            }
        }
    }
}
