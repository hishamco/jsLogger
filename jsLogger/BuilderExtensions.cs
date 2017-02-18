using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jsLogger
{
    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseJavaScriptLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<JavaScriptLoggingMiddleware>();
        }
    }
}
