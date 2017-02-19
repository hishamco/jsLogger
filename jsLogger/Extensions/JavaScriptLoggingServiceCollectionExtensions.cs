using Microsoft.Extensions.DependencyInjection;
using System;

namespace jsLogger.Extensions
{
    public static class JavaScriptLoggingServiceCollectionExtensions
    {
        public static IServiceCollection AddJavaScriptLogging(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddOptions();

            AddJavaScriptLoggingServices(services);

            return services;
        }

        public static IServiceCollection AddJavaScriptLogging(
            this IServiceCollection services,
            Action<JavaScriptLoggingOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            AddJavaScriptLoggingServices(services, setupAction);

            return services;
        }

        internal static void AddJavaScriptLoggingServices(
            IServiceCollection services,
            Action<JavaScriptLoggingOptions> setupAction)
        {
            AddJavaScriptLoggingServices(services);
            services.Configure(setupAction);
        }

        internal static void AddJavaScriptLoggingServices(IServiceCollection services)
        {
            services.AddSingleton<JavaScriptLoggingSnippet>();
        }
    }
}
