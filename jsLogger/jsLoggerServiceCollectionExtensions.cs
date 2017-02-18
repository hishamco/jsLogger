using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jsLogger
{
    public static class jsLoggerServiceCollectionExtensions
    {
        public static IServiceCollection AddJavaScriptLogging(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSingleton<jsLoggerSnippet>();

            return services;
        }
    }
}
