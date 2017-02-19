using Microsoft.AspNetCore.Builder;

namespace jsLogger.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseJavaScriptLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<JavaScriptLoggingMiddleware>();
        }
    }
}
