using Markdig;
using Microsoft.AspNetCore.Components;

namespace BlazorOpenApi;

internal static class ApiUtils
{
    public static MarkupString MarkdownToHtml(string? md)
    {
        if (string.IsNullOrWhiteSpace(md))
            return new();
        
        var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        var html     = Markdown.ToHtml(md, pipeline).ToString() ?? "";
        
        return new (html);
    }

}
