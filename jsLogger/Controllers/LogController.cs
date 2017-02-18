using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace jsLogger.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogger _logger;

        public LogController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LogController>();
        }

        [HttpPost]
        public void Index(int level, string message)
        {
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
    }
}
