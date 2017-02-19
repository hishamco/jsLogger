using jsLogger.Extensions;
using Microsoft.Extensions.Options;
using System;

namespace jsLogger
{
    public class JavaScriptLoggingSnippet
    {
        private readonly JavaScriptLoggingOptions _loggingOptions;

        private static readonly string JavaScriptLoggingScript = Resources.Script;

        private static readonly string JavaScriptLoggingGlobalExceptionHandlingScript = Resources.GlobalExceptionHandlingScript;

        public JavaScriptLoggingSnippet(IOptions<JavaScriptLoggingOptions> loggingOptions)
        {
            _loggingOptions = loggingOptions.Value;
        }

        public string Script =>
            _loggingOptions.HandleGlobalExceptions ?
                string.Concat(JavaScriptLoggingScript, Environment.NewLine,
                    JavaScriptLoggingGlobalExceptionHandlingScript): JavaScriptLoggingScript;
    }
}
