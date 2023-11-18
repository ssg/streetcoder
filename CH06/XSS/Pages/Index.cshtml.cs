using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FoobleXSS.Pages;

public class IndexModel(ILogger<IndexModel> logger) : PageModel
{
    public string? Query { get; set; }

    public void OnGet([Bind(Prefix = "q")] string? query)
    {
        logger.LogDebug("Received GET request");
        this.Query = query;
    }
}