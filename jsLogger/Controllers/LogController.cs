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
        public void Index(string logLevel, string message)
        {
            switch (logLevel)
            {
                case "trace":
                    _logger.LogTrace(message);
                    break;
                case "debug":
                    _logger.LogDebug(message);
                    break;
                case "info":
                    _logger.LogInformation(message);
                    break;
                case "warn":
                    _logger.LogWarning(message);
                    break;
                case "error":
                    _logger.LogError(message);
                    break;
                default:
                    return;
            }
        }
    }
}
