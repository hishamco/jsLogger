using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace jsLogger.TagHelpers
{
    public class JavaScriptLoggingTagHelperComponent : TagHelperComponent
    {
        private readonly string _script;

        public JavaScriptLoggingTagHelperComponent(JavaScriptLoggingSnippet jsLoggingSnippet)
        {
            _script = jsLoggingSnippet.Script;
        }

        public override int Order => 1;

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "head", StringComparison.Ordinal))
            {
                output.PostContent.AppendHtml(_script);
            }

            return Task.CompletedTask;
        }
    }
}
